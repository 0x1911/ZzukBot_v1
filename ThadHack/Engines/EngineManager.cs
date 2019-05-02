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
            BackgroundWorker bgWorker_EngineRestart;
            bgWorker_EngineRestart = new BackgroundWorker();
            bgWorker_EngineRestart.WorkerSupportsCancellation = true;
            bgWorker_EngineRestart.DoWork += bgWorker_EngineRestart_DoWork;
            bgWorker_EngineRestart.RunWorkerAsync();
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
            Helpers.Logger.Append("Grinder starting up", Logger.LogType.Info);
            GuiCore.MainForm.runToolStripMenuItem.Enabled = false;
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

            Helpers.Logger.Append("Stopped all.", Logger.LogType.Info);            
        }
    }
}