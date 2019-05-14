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

        
        internal static void LoginHandling()
        {
            if(API.BMain.IsInGame) { return; }

            BackgroundWorker bgWorker_Login;
            bgWorker_Login = new BackgroundWorker();
            bgWorker_Login.WorkerSupportsCancellation = true;
            bgWorker_Login.DoWork += bgWorker_Login_DoWork;
            bgWorker_Login.RunWorkerCompleted += bgWorker_Login_RunWorkerCompleted;
            bgWorker_Login.RunWorkerAsync();
        }
        private static void bgWorker_Login_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Relog.LoginState == Enums.LoginState.login && !API.BMain.IsInGame)
            {
                Helpers.Logger.Append("Logging in..");
                Relog.Login();
            }
        }
        private static void bgWorker_Login_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (EngineManager.CurrentEngineType != Engines.Engines.None) { return; }

            Helpers.Logger.Append("login worker completed");

         /*   BackgroundWorker bgWorker_EnterWorld;
            bgWorker_EnterWorld = new BackgroundWorker();
            bgWorker_EnterWorld.WorkerSupportsCancellation = true;
            bgWorker_EnterWorld.DoWork += bgWorker_EnterWorld_DoWork;
            bgWorker_EnterWorld.RunWorkerCompleted += bgWorker_EnterWorld_RunWorkerCompleted;
            bgWorker_EnterWorld.RunWorkerAsync(); */
        }
        private static void bgWorker_EnterWorld_DoWork(object sender, DoWorkEventArgs e)
        {
            Random rand = new Random();

            for (int i = 0; i <= rand.Next(8, 12); i++)
            {
                System.Threading.Thread.Sleep(500);
            }

            if (Relog.LoginState == Enums.LoginState.charselect && !API.BMain.IsInGame)
            {
                Helpers.Logger.Append("Entering world..");
                Relog.EnterWorld();
                //only one char on the account? simply enter the world on that one
                /*  if (Relog.NumCharacterCount == 1)
                  {
                      Helpers.Logger.Append("Entering world..");
                      Relog.EnterWorld();
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
                          }
                      }
                  } */
            }
        }
        private static void bgWorker_EnterWorld_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (EngineManager.CurrentEngineType != Engines.Engines.None) return;

            Helpers.Logger.Append("enter world worker completed");

            EngineManager.StartGrinder(GuiCore.MainForm.cbLoadLastProfile.Checked);
        }
               


        internal static void Login()
        {
            Functions.DoString("DefaultServerLogin('" + Options.AccountName + "', '" + Options.AccountPassword + "');");
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