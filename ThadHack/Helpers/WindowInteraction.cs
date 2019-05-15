using System.Drawing;
using ZzukBot.Constants;
using ZzukBot.Settings;

namespace ZzukBot.Helpers
{
    public class WindowInteraction
    {
        const short SWP_NOMOVE = 0X2;
        const short SWP_NOSIZE = 1;
        const short SWP_NOZORDER = 0X4;
        const int SWP_SHOWWINDOW = 0x0040;

        /// <summary>
        /// set wow window size and location
        /// </summary>
        public static void SetWowWindow()
        {
            if (!string.IsNullOrEmpty(Settings.Settings.WowWindowHeight) && Settings.Settings.WowWindowHeight != "0" &&
               !string.IsNullOrEmpty(Settings.Settings.WowWindowWidth) && Settings.Settings.WowWindowWidth != "0" &&
               !string.IsNullOrEmpty(Settings.Settings.WowWindowX) && !string.IsNullOrEmpty(Settings.Settings.WowWindowY))
            {
                WinImports.SetWindowPos(Mem.WindowProcHook.HWnD, 0, int.Parse(Settings.Settings.WowWindowX), int.Parse(Settings.Settings.WowWindowY), int.Parse(Settings.Settings.WowWindowWidth), int.Parse(Settings.Settings.WowWindowHeight), SWP_NOZORDER | SWP_SHOWWINDOW);
            }            
        }
        /// <summary>
        /// Set Bot Window location
        /// </summary>
        public static void SetBotWindow()
        {
            if (!string.IsNullOrEmpty(Settings.Settings.BotWindowX) && Settings.Settings.BotWindowX != "0" &&
               !string.IsNullOrEmpty(Settings.Settings.BotWindowY) && Settings.Settings.BotWindowY != "0")
            {
                GuiCore.MainForm.Location = new Point(int.Parse(Settings.Settings.BotWindowX), int.Parse(Settings.Settings.BotWindowY));
            }
        }
    }
}
