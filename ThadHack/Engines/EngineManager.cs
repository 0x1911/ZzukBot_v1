﻿using System.Windows.Forms;
using ZzukBot.Engines.Grind;
using ZzukBot.Engines.ProfileCreation;
using ZzukBot.Forms;
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

        private static volatile bool IsWaitingForGeneration;
        private static Grinder tmpGrind;

        private static bool IsEngineRunning => _Engine != null;

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
            if (IsEngineRunning) return;
            string tmpProfileName;
            if (parLoadLast && Options.LastProfileFileName != "")
            {
                tmpProfileName = Options.LastProfileFileName;
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
            if (!IsWaitingForGeneration && tmpGrind.Prepare(tmpProfileName, Callback))
            {
                GuiCore.MainForm.Invoke(new MethodInvoker(delegate
                {
                    GuiCore.MainForm.lGrindState.Text = "State: Loading mmaps";
                    IsWaitingForGeneration = true;
                    string profileFileName = tmpProfileName.Replace(Paths.ProfileFolder, "");
                    Options.LastProfileFileName = profileFileName;
                }));
            }
        }

        private static void Callback()
        {
            if (tmpGrind != null && tmpGrind.Run())
            {
                GuiCore.MainForm.Invoke(new MethodInvoker(delegate
                {
                    GuiCore.MainForm.lGrindLoadProfile.Text = "Profile: " + Options.LastProfileFileName + " Loaded";
                    _Engine = tmpGrind;
                    IsWaitingForGeneration = false;
                }));
            }
        }

        internal static void StopCurrentEngine()
        {
            var dispose = true;
            if (!IsEngineRunning) return;
            if (_Engine.GetType() == typeof (ProfileCreator))
                dispose = EngineAs<ProfileCreator>().Dispose();

            if (_Engine.GetType() == typeof (Grinder))
            {
                EngineAs<Grinder>().Stop();
                IsWaitingForGeneration = false;
                tmpGrind = null;
            }

            if (dispose)
                _Engine = null;
        }
    }
}