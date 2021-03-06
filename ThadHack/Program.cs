﻿using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using ZzukBot.Constants;
using ZzukBot.Helpers;
using ZzukBot.OOP;
using ZzukBot.Settings;

namespace ZzukBot
{
    [Obfuscation(Feature = "Apply to member * when method or constructor: virtualization", Exclude = false)]
    internal static class Program
    {
        private static bool debugMode = false;

        private const int mmapVersionConst = 2;

        private static EventWaitHandle s_event;

        private static bool AreWeInjected => !Process.GetCurrentProcess().ProcessName.StartsWith("ZzukBot");

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var name = new AssemblyName(args.Name).Name;
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + name + ".dll";
            return Assembly.LoadFile(path);
        }

        private static bool IsAlreadyRunning()
        {
            bool created;
            s_event = new EventWaitHandle(false,
                EventResetMode.ManualReset, Assembly.GetExecutingAssembly().Location.Replace("\\", "#"), out created);
            return !created;
        }

        [STAThread]
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void Main()
        {
            if (!IsAlreadyRunning())
            {
                AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
                LaunchBot();
            }
            else
            {
                QuitWithMessage("An instance is already running from this location");
            }
        }

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void LaunchBot()
        {
            // Setting culture for float etc (. instead of ,)
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!AreWeInjected)
            {
                //var attForm = new AttachForm();
                //attForm.ShowDialog();
                //switch (attForm.Result)
                //{
                //    case AttachFormResult.Fresh:
                        PrepareAndInject();
                //        break;

                //    case AttachFormResult.Attach:
                //        PrepareAndInject(attForm.AttachTo.PID);
                //        break;
                //}
            }
            else
            {
                if (debugMode)
                {
                    Debugger.Launch();
                    WinImports.AllocConsole();
                    Logger.Append("DEBUG BUILD");
                    DebugAssist.Init();
                }

                SetPaths();
                SetRealmlist();
                try
                {
                    GuiCore.MainForm = new Forms.GraphicalMainForm();
                    GuiCore.SettingsForm = new Forms.GraphicalSettingsForm();

                    Application.Run(GuiCore.MainForm);
                }
                catch (Exception e)
                {
                    Logger.Append("Startup: " + e.Message + "\r\n", Logger.LogType.Console, "Exceptions.txt");
                }
            }
            Environment.Exit(0);
        }

        private static void PrepareAndInject(int? pId = null)
        {
            if (!Directory.Exists("mmaps"))
            {
                QuitWithMessage("Download the mmaps first please");
            }
            if (Directory.GetFileSystemEntries("mmaps").Length < 1000)
            {
                QuitWithMessage("Download the mmaps first please");
            }
            else
            {
                if (!File.Exists("mmaps\\Version.ini"))
                    QuitWithMessage("Wrong mmaps version! Please redownload");

                int mmapVersion;
                var result = int.TryParse(File.ReadAllText("mmaps\\Version.ini"), out mmapVersion);
                if (!result)
                    QuitWithMessage("Bad mmaps version identifier! Please check mmaps\\Version.ini");

                if (mmapVersion != mmapVersionConst)
                    QuitWithMessage("Wrong mmaps version! Please redownload");
            }
          /*  if (GetMD5AsBase64("Fasm.NET.dll") != Resources.FasmNetMd5)
            {
                QuitWithMessage("Fastm.NET.dll is broken. Please redownload");
            } */

            // Do the settings exist?
            if (!File.Exists(GuiCore.SettingsFilePath))
            {
                while (true)
                {
                    var loc = new OpenFileDialog
                    {
                        CheckFileExists = true,
                        CheckPathExists = true,
                        Filter = "executable (*.exe)|*.exe",
                        FilterIndex = 1,
                        Title = "Please locate your WoW.exe"
                    };
                    if (loc.ShowDialog() == DialogResult.OK)
                    {
                        if (loc.FileName == Assembly.GetExecutingAssembly().Location)
                        {
                            MessageBox.Show(
                                "FFS DIDNT THE WINDOW TITLE STATE TO TARGET THE WOW.EXE? WHY THE FCK SHOULD YOU SELECT THE ZZUKBOT.EXE?!?! FFS");
                        }
                        else
                        {
                            Settings.Settings.WowExePath = loc.FileName;
                            //write minimal settings doc file to hdd
                            SettingsManager.InitialSetupSettingsFile();
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            s_event.Close();
            Launch.Run(pId);
        }

        private static void SetPaths()
        {
            Paths.WowDirectory = Directory.GetCurrentDirectory();
            // get all kind of paths the bot need to operate
            var strPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Paths.SettingsFile = Path.GetDirectoryName(strPath) + GuiCore.SettingsFilePath;
            Paths.WorkingDirectory = Path.GetDirectoryName(strPath);
            Paths.ProfilesDirectory = Path.GetDirectoryName(strPath) + "\\Profiles";
            Paths.BotAssemblyFile = strPath + "\\ZzukBot.exe";            
            Paths.InternalDirectory = strPath;
        }

        private static void SetRealmlist()
        {
            var rlmList = Paths.WowDirectory + "\\realmlist.wtf";
            var project = File.ReadAllLines(rlmList);
            var name = "";
            foreach (var x in project)
            {
                if (x.ToLower().StartsWith("set realmlist "))
                    name = x.ToLower();
            }
            Settings.Settings.RealmList = name;
        }


        internal static string GetMD5AsBase64(string parFile)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(parFile))
                {
                    return Convert.ToBase64String(md5.ComputeHash(stream));
                }
            }
        }

        internal static void QuitWithMessage(string parMessage)
        {
            MessageBox.Show(parMessage);
            Environment.Exit(0);
        }
    }
}