using System;
using System.ComponentModel;
using System.Text;
using ZzukBot.Constants;
using ZzukBot.Engines;
using ZzukBot.Settings;

namespace ZzukBot.Mem
{
    /// <summary>
    ///     Important for relogging
    /// </summary>
    internal static class Relog
    {
        internal static int NumCharacterCount => Offsets.CharacterScreen.NumCharacters.ReadAs<int>();

        internal static string GetCharacterNameAtPos(int index)
        {
            return Offsets.CharacterScreen.Pointer.ReadAs<IntPtr>().Add(0x120 * index + 0x8).ReadString();
        }
        internal static Enums.LoginState LoginState
        {
            get
            {
                Constants.Enums.LoginState LoginState = (Constants.Enums.LoginState)Enum.Parse(typeof(Constants.Enums.LoginState), Offsets.CharacterScreen.LoginState.ReadString(), true);
                return LoginState;
            }
        }


        internal static string CurrentWindowName
        {
            get
            {
                try
                {
                    var first = Memory.Reader.Read<IntPtr>((IntPtr)0xCF0BD8);
                    var curWindow = Memory.Reader.Read<IntPtr>(IntPtr.Add(first, 0x7c));
                    if (curWindow == IntPtr.Zero) return "";
                    return Memory.Reader.ReadString(Memory.Reader.Read<IntPtr>(IntPtr.Add(curWindow, 0x98)), Encoding.ASCII);
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        internal static void ResetLogin()
        {
            Functions.DoString("arg1 = 'ESCAPE' GlueDialog_OnKeyDown()");
            Functions.DoString(
                "if RealmListCancelButton ~= nil then if RealmListCancelButton:IsVisible() then RealmListCancelButton:Click(); end end");
            ClearGlueDialogText();
        }

        internal static BackgroundWorker backgroundWorker;
        internal static void LoginHandling()
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync();
        }

        private static void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Helpers.Logger.Append("bgworker completed");

            if (EngineManager.CurrentEngineType != Engines.Engines.None) return;

            EngineManager.StartGrinder(GuiCore.MainForm.cbLoadLastProfile.Checked);
        }

        private static void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Random rand = new Random();
            if (Relog.LoginState == Enums.LoginState.login && !ObjectManager.IsInGame)
            {
                Helpers.Logger.Append("Logging in..");
                Relog.Login();
                while (Relog.LoginState == Enums.LoginState.login) { System.Threading.Thread.Sleep(100); }
            }

            if (Relog.LoginState == Enums.LoginState.charselect && !ObjectManager.IsInGame)
            {
                //only one char on the account? simply enter the world on that one
                if (Relog.NumCharacterCount == 1)
                {
                    Helpers.Logger.Append("Entering world..");
                    Relog.EnterWorld();
                    SleepWhileNotIngame();
                }
                else if (Relog.NumCharacterCount > 1)
                {
                    Helpers.Logger.Append("We got " + Relog.NumCharacterCount + " characters on this account.");
                    for (var i = 0; i < Relog.NumCharacterCount; i++)
                    {
                        var tmpCharName = Relog.GetCharacterNameAtPos(i);
                        Helpers.Logger.Append(i + " is " + tmpCharName);

                        if (tmpCharName.ToLower().Equals(Options.CharacterName.ToLower()))
                        {
                            Helpers.Logger.Append("Entering world with " + tmpCharName);
                            Relog.EnterWorld();
                            SleepWhileNotIngame();
                        }
                    }
                }
            }
        }

        internal static bool SleepWhileNotIngame()
        {
            while (!ObjectManager.IsInGame)
            {
                System.Threading.Thread.Sleep(100);
            }

            return true;
        }

        internal static bool Login()
        {
            Functions.DoString("DefaultServerLogin('" + Options.AccountName + "', '" + Options.AccountPassword + "');");
            
            if (LoginState == Enums.LoginState.charselect)
                return true;

            return false;
        }

        internal static void EnterWorld()
        {
            Functions.EnterWorld();
        }

        internal static string GetGlueDialogText()
        {
            var enc = "myShit".GenLuaVarName();
            Functions.DoString(enc + " = GlueDialogText:GetText()");
            return Functions.GetText(enc);
        }

        internal static void ClearGlueDialogText()
        {
            Functions.DoString("GlueDialogText:SetText('')");
        }
    }
}