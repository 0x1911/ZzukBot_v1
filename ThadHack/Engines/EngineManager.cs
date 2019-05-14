using System;
using System.ComponentModel;
using System.Windows.Forms;
using ZzukBot.Engines.Grind;
using ZzukBot.Engines.ProfileCreation;
using ZzukBot.Helpers;
using ZzukBot.Settings;

namespace ZzukBot.Engines
{
    internal enum Engines
    {
        None = 0,
        ProfileCreation = 1,
        Grind = 2
    }

    internal static class EngineManager
    {
        private static object _Engine;

        private static Grinder tmpGrind;

        private static bool IsEngineRunning => _Engine != null;

        public static long StartTick = 0;
        
        internal static Engines CurrentEngineType
        {
            get
            {
                if (IsEngineRunning)
                {
                    if (_Engine.GetType() == typeof (ProfileCreator))
                        return Engines.ProfileCreation;

                    if (_Engine.GetType() == typeof (Grinder))
                        return Engines.Grind;
                }
                return Engines.None;
            }
        }

        internal static T EngineAs<T>()
        {
            return (T) _Engine;
        }

        internal static void RestartOutOfEngine()
        {
            Helpers.Logger.Append("Looks like we are Stuck.. Reseting most of the path stuff");
            Grinder.Access.Info.Vendor.RegenerateSubPath = true;
            Grinder.Access.Info.Vendor.HotspotsToVendor = null;
            Grinder.Access.Info.PathAfterFightToWaypoint.AdjustPath();
            Grinder.Access.Info.PathToPosition = new Grind.Info.Path._PathToPosition();
            Grinder.Access.Info.PathAfterFightToWaypoint = new Grind.Info.Path._PathAfterFightToWaypoint();
            Grinder.Access.Info.PathManager = new Grind.Info.Path._PathManager();
            Grinder.Access.Info.PathToObject = new Grind.Info.Path._PathToObject();
            Grinder.Access.Info.PathToUnit = new Grind.Info.Path._PathToUnit();
            Grinder.Access.Info.PathSafeGhostwalk = new Grind.Info.Path._PathSafeGhostwalk();
            Grinder.Access.Info.Waypoints = new Grind.Info._Waypoints();
            Grinder.Access.Info.Vendor = new Grind.Info._Vendor();
            Grinder.Access.Info.PathToPosition = new Grind.Info.Path._PathToPosition();

            /*  BackgroundWorker bgWorker_EngineRestart;
              bgWorker_EngineRestart = new BackgroundWorker();
              bgWorker_EngineRestart.WorkerSupportsCancellation = true;
              bgWorker_EngineRestart.DoWork += bgWorker_EngineRestart_DoWork;
              bgWorker_EngineRestart.RunWorkerAsync(); */
        }
        private static void bgWorker_EngineRestart_DoWork(object sender, DoWorkEventArgs e)
        {
            int  StartTickCount = Environment.TickCount + 3000;

            while(StartTickCount >= Environment.TickCount)
            {
                EngineManager.StopCurrentEngine();
            }
            

            EngineManager.StartGrinder(true);
        }
        internal static void StartProfileCreation(Forms.GraphicalProfileCreationForm targetForm)
        {
            GuiCore.MainForm.Invoke(new MethodInvoker(delegate
            {
                if (IsEngineRunning) return;
                _Engine = new ProfileCreator(targetForm);
            }));
        }

        internal static void StartGrinder(bool parLoadLast)
        {
            Helpers.Logger.Append("Grinder starting up");
            GuiCore.MainForm.runToolStripMenuItem.Enabled = false;
            GuiCore.MainForm.pauseToolStripMenuItem.Enabled = true;
            GuiCore.MainForm.stopToolStripMenuItem.Enabled = true;

            if (IsEngineRunning) return;
            string tmpProfileName;
            if (parLoadLast && Options.LastProfileFileName != "")
            {
                tmpProfileName = Paths.ProfileFolder + Options.LastProfileFileName;
            }
            else
            {
                using (var locateProfile = new OpenFileDialog())
                {
                    locateProfile.CheckFileExists = true;
                    locateProfile.CheckPathExists = true;
                    locateProfile.Filter = "xml Profile (*.xml)|*.xml";
                    locateProfile.FilterIndex = 1;
                    locateProfile.InitialDirectory = Paths.ProfileFolder;
                    if (locateProfile.ShowDialog() == DialogResult.OK)
                    {
                        tmpProfileName = locateProfile.FileName;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            Helpers.Logger.Append("ccfolder: " + Paths.CCFolder.ToString());
            Helpers.Logger.Append("internal: " + Paths.Internal.ToString());
            Helpers.Logger.Append("wowPath: " + Paths.PathToWoW.ToString());
            Helpers.Logger.Append("profiles: " + Paths.ProfileFolder.ToString());
            Helpers.Logger.Append("root: " + Paths.Root.ToString());
            Helpers.Logger.Append("settings: " + Paths.Settings.ToString());
            Helpers.Logger.Append("thadhack exe: " + Paths.ThadHack.ToString());

            tmpGrind = new Grinder();
            if (tmpGrind.Prepare(tmpProfileName, Callback))
            {
                GuiCore.MainForm.Invoke(new MethodInvoker(delegate
                {
                    GuiCore.MainForm.lGrindState.Text = "State: Loading mmaps";
                    string profileFileName = tmpProfileName.Replace(Paths.ProfileFolder, "");
                    Options.LastProfileFileName = profileFileName;
                }));
            }

            StartTick = DateTime.Now.Ticks;
        }

        private static void Callback()
        {
            if (tmpGrind != null && tmpGrind.Run())
            {
                GuiCore.MainForm.Invoke(new MethodInvoker(delegate
                {
                    GuiCore.MainForm.lGrindLoadProfile.Text = "Profile: " + Options.LastProfileFileName + " Loaded";
                    _Engine = tmpGrind;
                }));
            }
        }

        internal static bool PauseCurrentEngine()
        {            
            if(!IsEngineRunning || _Engine.GetType() == typeof(ProfileCreator)) { return false; }


            GuiCore.MainForm.runToolStripMenuItem.Enabled = true;
            GuiCore.MainForm.stopToolStripMenuItem.Enabled = true;

            if (_Engine.GetType() == typeof(Grinder))
            {
                if(!EngineAs<Grinder>().Engine.IsPaused)
                {
                    EngineAs<Grinder>().Engine.IsPaused = true;
                    GuiCore.MainForm.pauseToolStripMenuItem.Enabled = false;
                    GuiCore.MainForm.runToolStripMenuItem.Text = "Resume";
                    return true;
                }                   
            }


            return false;
        }

        internal static bool ResumeCurrentEngine()
        {
            if (!IsEngineRunning || _Engine.GetType() == typeof(ProfileCreator)) { return false; }


            GuiCore.MainForm.runToolStripMenuItem.Enabled = false;
            GuiCore.MainForm.runToolStripMenuItem.Text = "Run";
            GuiCore.MainForm.stopToolStripMenuItem.Enabled = true;

            if (_Engine.GetType() == typeof(Grinder))
            {
                if (EngineAs<Grinder>().Engine.IsPaused)
                {
                    EngineAs<Grinder>().Engine.IsPaused = false;
                    GuiCore.MainForm.pauseToolStripMenuItem.Enabled = true;
                    return true;
                }
            }

            return false;
        }

        internal static void StopCurrentEngine()
        {
            GuiCore.MainForm.runToolStripMenuItem.Enabled = true;
            GuiCore.MainForm.stopToolStripMenuItem.Enabled = false;
            GuiCore.MainForm.lGrindLoadProfile.Text = "Profile: ";
            GuiCore.MainForm.lGrindState.Text = "State: ";

            var dispose = true;
            if (!IsEngineRunning) return;
            if (_Engine.GetType() == typeof (ProfileCreator))
                dispose = EngineAs<ProfileCreator>().Dispose();

            if (_Engine.GetType() == typeof (Grinder))
            {
                EngineAs<Grinder>().Stop();

                if (tmpGrind != null)
                {
                    tmpGrind.Stop();
                    tmpGrind = null;
                }
            }

            if (dispose)
                _Engine = null;

            Helpers.Logger.Append("Stopped all.");            
        }
    }
}