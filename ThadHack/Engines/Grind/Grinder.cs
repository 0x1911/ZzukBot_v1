using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ZzukBot.AntiWarden;
using ZzukBot.Engines.CustomClass;
using ZzukBot.Engines.Grind.States;
using ZzukBot.FSM;
using ZzukBot.Helpers;
using ZzukBot.Hooks;
using ZzukBot.Mem;
using ZzukBot.Settings;
using System.Runtime.InteropServices;

namespace ZzukBot.Engines.Grind
{
    internal class Grinder
    {
        internal static Grinder Access;

        internal Grinder()
        {
            Access = this;
            ErrorEnumHook.OnNewError += ErrorEnum_OnNewError;
        }

        internal _StuckHelper StuckHelper { get; set; }
        // holds details about the currently loaded profile
        internal GrindProfile Profile { get; private set; }
        // the fsm for our grindbot
        internal _Engine Engine { get; private set; }
        // ingame informations
        internal _Info Info { get; private set; }
        // the last state that got run
        internal string LastState { get; private set; }

        private void ErrorEnum_OnNewError(ErrorEnumArgs e)
        {
            if (e.Message.StartsWith("Target not"))
            {
                if (Access.Info.Combat.IsMovingBack) return;
                if (!Access.Info.Target.InSightWithTarget) return;
                // LosTimer is used within info.target.combatdistance
                Access.Info.Target.InSightWithTarget = false;
                Access.Info.Target.ResetToNormalAt = Environment.TickCount + 3000;
            }
            else if (e.Message.StartsWith("You must be standing") ||
                     e.Message.StartsWith("You need to be standing up to loot"))
            {
                Functions.DoString("SitOrStand()");
            }
            else if (e.Message.StartsWith("You cannot attack that target") || e.Message.StartsWith("Invalid target"))
            {
                var target = ObjectManager.Target;
                if (target == null) return;
                if (target.Health != 0)
                {
                    Access.Info.Combat.AddToBlacklist(target.Guid);
                }
            }
            else if (e.Message.StartsWith("You are facing the") || e.Message.StartsWith("Target needs to be"))
            {
                var tar = ObjectManager.Target;
                if (tar == null) return;
                if (Access.Info.Combat.IsMoving) return;
                Access.Info.Target.FixFacing = true;
                Wait.Remove("FixFacingTimer");
            }
            else if (e.Message.StartsWith("Target too close"))
            {
                if (!Access.Info.Combat.IsMoving)
                    Access.Info.PathBackup.SetToCloseForRanged();
            }
            else if (e.Message.StartsWith("You can't carry any")
                     || e.Message.StartsWith("Requires Skinning"))
            {
                Access.Info.Loot.BlacklistCurrentLoot = true;
            }
            else if (e.Message.Contains("that while moving"))
            {
                ObjectManager.Player.StopMovement(Constants.Enums.ControlBits.All);
            }
        }

        /// <summary>
        ///     Code of the grindbot to run in Endscene
        /// </summary>
        private void RareCheck()
        {
            if (Options.StopOnRare || Options.NotifyOnRare)
            {
                if (Wait.For("RareScan12", 10000))
                {
                    if (Options.NotifyOnRare)
                    {
                        var tmp = ObjectManager.Npcs.FirstOrDefault(i => i.IsRareElite && i.Health != 0);
                        if (tmp != null)
                        {
                            if (Calc.Distance3D(ObjectManager.Player.Position, tmp.Position) < 25)
                            {
                                if (!Info.RareSpotter.Notified(tmp.Guid))
                                {
                                    GuiCore.MainForm.updateNotification("Found a rare: " + tmp.Name);
                                }
                            }
                        }
                    }
                    if (Options.StopOnRare)
                    {
                        Stop();
                    }
                }
            }
        }

        private void Refreshments()
        {
            Info.Latency = ObjectManager.Player.GetLatency()*2;
        }



        private void RelogRoutine()
        {
            if (Relog.CurrentWindowName == "RealmList")
            {
                if (Wait.For("CancelRealmSelection", 2000))
                {
                    Wait.Remove("PressLogin");
                    Relog.ResetLogin();
                }
            }
            switch (Relog.LoginState)
            {
                case Constants.Enums.LoginState.login:
                    {
                        var glueText = Relog.GetGlueDialogText().ToLower();
                        if (!glueText.Contains("is full"))
                        {
                            if (Wait.For("WrongInfo", 5000, false) && (glueText.Contains("the information you have") ||
                                                                       glueText.Contains("disconnected")))
                            {
                                if (!Wait.For("RelogReset", 2000, false))
                                {
                                    if (!Wait.For("RelogReset2", 1, false))
                                    {
                                        Wait.Remove("PressLogin");
                                        Relog.ResetLogin();
                                    }
                                }
                            }
                        }
                        if (glueText == "" && Wait.For("SendAccountDetailsWait", 5000))
                        {
                            Relog.Login();
                            Wait.Remove("RelogReset");
                            Wait.Remove("RelogReset2");
                            Wait.Remove("StartGhostWalk");
                            Access.Info.SpiritWalk.GeneratePath = true;
                            Wait.Remove("WrongInfo");
                        }
                    }
                    break;

                case Constants.Enums.LoginState.charselect:
                    if (Wait.For("EnterWorldClicker", 2000))
                        Functions.EnterWorld();
                    break;
            }
        }

        int exceptionThrown = 0;
        private void RunGrinder(ref int FrameCounter, bool IsIngame)
        {
            try
            {
                if (FrameCounter%3 == 0)
                {
                    exceptionThrown = 1;
                    if (FrameCounter%15 == 0 && IsIngame)
                    {
                        exceptionThrown = 2;
                        var dottedUnitsToRemove =
                           Info.Combat.UnitsDottedByPlayer.Where(kvp => Environment.TickCount - kvp.Value >= 40000).ToList();
                        foreach (var item in dottedUnitsToRemove)
                        {
                            Info.Combat.UnitsDottedByPlayer.Remove(item.Key);
                        }
                        exceptionThrown = 3;
                        var target = ObjectManager.Target;
                        if (target != null)
                        {
                            var debuffCount = target.Debuffs.Count;
                            if (!target.TappedByOther && !target.TappedByMe && debuffCount > 0)
                            {
                                if (!Info.Combat.UnitsDottedByPlayer.ContainsKey(target.Guid))
                                    Info.Combat.UnitsDottedByPlayer.Add(target.Guid, Environment.TickCount);
                            }
                        }
                        exceptionThrown = 4;
                    }
                    ObjectManager.Player.AntiAfk();

                    if (IsIngame)
                    {
                        if (FrameCounter%300 == 0)
                        {
                            exceptionThrown = 5;
                            RareCheck();
                            if (FrameCounter%1800 == 0)
                            {
                                Refreshments();
                                exceptionThrown = 6;
                            }
                        }

                        LastState = Engine.Pulse();
                        exceptionThrown = 7;
                        GuiCore.MainForm.UpdateControl("State: " + LastState, GuiCore.MainForm.lGrindState);
                        exceptionThrown = 8;
                        #region Update OverView labels
                        try
                        {
                            var target = ObjectManager.Target;
                            if (target != null)
                            {
                                GuiCore.MainForm.lbl_targetX.Text = "X: " + target.Position.X.ToString();
                                GuiCore.MainForm.lbl_targetY.Text = "Z: " + target.Position.Y.ToString();
                                GuiCore.MainForm.lbl_targetZ.Text = "Y: " + target.Position.Z.ToString();

                                GuiCore.MainForm.pBar_targetHealth.Value = target.HealthPercent;
                                GuiCore.MainForm.lbl_targetFaction.Text = "Faction: " + target.FactionID.ToString();
                                GuiCore.MainForm.lbl_targetId.Text = "Id: " + target.NpcID.ToString();


                                GuiCore.MainForm.lbl_targetName.Text = "Name: " + target.Name.ToString();
                            }
                            else
                            {
                                GuiCore.MainForm.lbl_targetX.Text = "X: 0";
                                GuiCore.MainForm.lbl_targetY.Text = "Z: 0";
                                GuiCore.MainForm.lbl_targetZ.Text = "Y: 0";

                                GuiCore.MainForm.pBar_targetHealth.Value = 0;
                                GuiCore.MainForm.lbl_targetFaction.Text = "Faction: 0";
                                GuiCore.MainForm.lbl_targetId.Text = "Id: 0";


                                GuiCore.MainForm.lbl_targetName.Text = "Name: Unknown";
                            }

                            var player = ObjectManager.Player;
                            if (player != null)
                            {
                                GuiCore.MainForm.lbl_playerX.Text = "X: " + player.Position.X.ToString();
                                GuiCore.MainForm.lbl_playerY.Text = "Z: " + player.Position.Y.ToString();
                                GuiCore.MainForm.lbl_playerZ.Text = "Y: " + player.Position.Z.ToString();

                                GuiCore.MainForm.pBar_playerHealth.Value = player.HealthPercent;
                                if (player.MaxMana > 0) { GuiCore.MainForm.pBar_playerMana.Value = player.ManaPercent; GuiCore.MainForm.pBar_playerMana.ForeColor = System.Drawing.Color.Blue; }
                                else if (player.Class == Constants.Enums.ClassIds.Rogue) { GuiCore.MainForm.pBar_playerMana.Value = player.Energy; GuiCore.MainForm.pBar_playerMana.ForeColor = System.Drawing.Color.Yellow; }
                                else if (player.Class == Constants.Enums.ClassIds.Warrior) { GuiCore.MainForm.pBar_playerMana.Value = player.Rage; GuiCore.MainForm.pBar_playerMana.ForeColor = System.Drawing.Color.Red; }

                                if (player.Level < 60)
                                {
                                    decimal tmpCurXp = player.CurrentXp;
                                    decimal tmpMaxXp = player.NextLevelXp;
                                    decimal lvlPercentDone = (tmpCurXp / tmpMaxXp) * 100;
                                    GuiCore.MainForm.pBar_playerExperience.Value = (int)lvlPercentDone;
                                }
                                else { GuiCore.MainForm.pBar_playerExperience.Visible = false; }

                                GuiCore.MainForm.lbl_playerZone.Text = "Zone: " + player.RealZoneText.ToString();
                                GuiCore.MainForm.lbl_playerSubZone.Text = "Sub-Zone: " + player.MinimapZoneText.ToString();
                            }

                            GuiCore.MainForm.lbl_playerLevel.Text = "Level: " + player.Level.ToString();
                            GuiCore.MainForm.lbl_playerClass.Text = "Class: " + player.Class.ToString();
                            GuiCore.MainForm.lbl_playerRace.Text = "Race: " + player.Race.ToString();
                            GuiCore.MainForm.lbl_playerAccountName.Text = "Account: " + Options.AccountName;

                            GuiCore.MainForm.lbl_Runtime.Text = "runtime: " + API.BMain.RunTimeSpan();
                        }
                        catch(Exception crap)
                        {
                            Logger.Append("Update OverView labels: " + crap.Message + "\r\n", Logger.LogType.Console, "Exceptions.txt");
                        }
                        #endregion
                        exceptionThrown = 9;
                    }
                    else
                    {
                        if (Info.BreakHelper.NeedToBreak)
                            return;
                        RelogRoutine();
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Append("Grinder frame: " + FrameCounter + " at " + exceptionThrown + " || message: " + e.Message + "\r\n", Logger.LogType.Console, "Exceptions.txt");
            }
        }        

        private void StopGrinder(ref int FrameCounter, bool IsIngame)
        {
            Memory.GetHack("Ctm").Remove();
            if (IsIngame)
            {
                // disable all current ingame movements if we are ingame
                ObjectManager.Player.CtmStopMovement();
            }
            HookWardenMemScan.GetHack("Collision3").Remove();
            HookWardenMemScan.GetHack("Collision").Remove();
            // we arent running anymore
            Access = null;
            ErrorEnumHook.OnNewError -= ErrorEnum_OnNewError;
            DirectX.StopRunning();
        }

        /// <summary>
        ///     Prepare everything (setup fsm, parse profile etc.)
        ///     return true if ingame and profile is valid
        /// </summary>
        [Obfuscation(Feature = "virtualization", Exclude = false)]
        internal bool Prepare(string parProfilePath, Action parCallback)
        {
            if (!ObjectManager.EnumObjects()) return false;
            Profile = new GrindProfile(parProfilePath);
            if (!Profile.ProfileValid) return false;

            if (!CCManager.ChooseCustomClassByWowClass((byte) ObjectManager.Player.Class))
            {
                MessageBox.Show("Couldnt find a Custom Class we can use");
                return false;
            }

            StuckHelper = new _StuckHelper();
            Info = new _Info();
            Info.Waypoints.LoadFirstWaypointsAsync(parCallback);

            var tmpStates = new List<State>
            {
                new StateIdle(),
                new StateLoadNextHotspot(),
                new StateLoadNextWaypoint(),
                new StateWalk(),
                new StateFindTarget(),
                new StateApproachTarget(),
                new StateWalkToGather(),
                new StateFight(),
                new StateRest(),
                new StateBuff()
            };
            if (Options.LootUnits)
            {
                tmpStates.Add(new StateLoot());
            }
            tmpStates.Add(new StateReleaseSpirit());
            tmpStates.Add(new StateGhostWalk());
            tmpStates.Add(new StateWalkToRepair());
            tmpStates.Add(new StateWalkBackToGrind());
            tmpStates.Add(new StateAfterFightToPath());
            tmpStates.Add(new StateWaitAfterFight());
            tmpStates.Add(new StateDoRandomShit());

            if (Options.BreakFor != 0 && Options.ForceBreakAfter != 0)
            {
                Info.BreakHelper.SetBreakAt(60000);
                tmpStates.Add(new StateStartBreak());
            }

            if (Profile.RepairNPC != null)
                tmpStates.Add(new StateRepair());
            tmpStates.Sort();

            Engine = new _Engine(tmpStates);

            return true;
        }

        /// <summary>
        ///     Start running the fsm
        /// </summary>
        [Obfuscation(Feature = "virtualization", Exclude = false)]
        internal bool Run()
        {
            if (!ObjectManager.EnumObjects()) return false;
            // start running the grindbot in endscene
            if (DirectX.RunInEndScene(RunGrinder))
            {
                // Enable the ctm patch to not stutter while walking
                Memory.GetHack("Ctm").Apply();
                ObjectManager.Player.TurnOnSelfCast();
                if (ObjectManager.Player.InGhostForm) Access.Info.SpiritWalk.GeneratePath = true;
                // we are running now
                Shared.ResetJumper();
                Wait.RemoveAll();
                return true;
            }
            return false;
        }

        internal void Stop()
        {
            DirectX.ForceRunInEndScene(StopGrinder);
        }

        internal void SetWaypointModifier(float parModifier)
        {
            Options.WaypointModifier = (decimal) parModifier;
        }
    }
}