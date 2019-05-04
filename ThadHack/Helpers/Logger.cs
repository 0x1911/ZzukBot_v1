using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ZzukBot.Helpers
{
    internal static class Logger
    {
        private static string previousMsg = string.Empty;
        internal static void Append(string parMessage, LogType logType = LogType.Console, string toFile = "")
        {
            //dont want to spam the same message over and over
            if (parMessage == previousMsg || GuiCore.MainForm == null) { return; }

            string dateTimeString = "[" + DateTime.Now.ToString("HH:mm:ss") + "] ";
            var msg = dateTimeString + parMessage;

            if (logType == LogType.Info) { GuiCore.MainForm.Invoke(new MethodInvoker(delegate { GuiCore.MainForm.rtb_MainLog.Text = GuiCore.MainForm.rtb_MainLog.Text.Insert(0, msg + "\n"); })); }
            if (logType == LogType.Debug) { GuiCore.MainForm.Invoke(new MethodInvoker(delegate { GuiCore.MainForm.rtb_DebugLog.Text = GuiCore.MainForm.rtb_MainLog.Text.Insert(0, msg + "\n"); })); }

            if (logType == LogType.Exception) { GuiCore.MainForm.Invoke(new MethodInvoker(delegate { GuiCore.MainForm.rtb_ExceptionLog.Text = GuiCore.MainForm.rtb_MainLog.Text.Insert(0, msg + "\n"); })); }

#if DEBUG
            //write to debug console
            Console.WriteLine(msg);

            if (toFile != "")
            {
                File.AppendAllText(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\"
                    + toFile, msg);
            }
#endif
        }

        internal enum LogType
        {
            Console = 0,
            Info = 1,
            Debug = 2,
            Exception = 3
        }
    }
}