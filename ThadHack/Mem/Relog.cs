using System;
using System.Text;
using ZzukBot.Constants;
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
            if (Relog.LoginState == Enums.LoginState.login)
            {
                if(Relog.Login())
                    LoginHandling();
            }

            if (Relog.LoginState == Enums.LoginState.charselect && !ObjectManager.IsInGame)
            {
                //only one char on the account? simply enter the world on that one
                if (Relog.NumCharacterCount == 1)
                {
                    Relog.EnterWorld();
                    return;
                }

                Helpers.Logger.Append("We got " + Relog.NumCharacterCount + " characters on this account.");
                for (var i = 0; i < Relog.NumCharacterCount; i++)
                {
                    var tmpCharName = Relog.GetCharacterNameAtPos(i);
                    Helpers.Logger.Append(i + " is " + tmpCharName);

                    if (tmpCharName.ToLower().Equals(Options.CharacterName.ToLower()))
                    {
                        Relog.EnterWorld();
                    }
                }
            }            
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