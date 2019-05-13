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
            if (!string.IsNullOrEmpty(Options.WowWindowHeight) && Options.WowWindowHeight != "0" &&
               !string.IsNullOrEmpty(Options.WowWindowWidth) && Options.WowWindowWidth != "0" &&
               !string.IsNullOrEmpty(Options.WowWindowX) && !string.IsNullOrEmpty(Options.WowWindowY))
            {
                WinImports.SetWindowPos(Mem.WindowProcHook.HWnD, 0, int.Parse(Options.WowWindowX), int.Parse(Options.WowWindowY), int.Parse(Options.WowWindowWidth), int.Parse(Options.WowWindowHeight), SWP_NOZORDER | SWP_SHOWWINDOW);
            }            
        }
        /// <summary>
        /// Set Bot Window location
        /// </summary>
        public static void SetBotWindow()
        {
            if (!string.IsNullOrEmpty(Options.BotWindowX) && Options.BotWindowX != "0" &&
               !string.IsNullOrEmpty(Options.BotWindowY) && Options.BotWindowY != "0")
            {
                GuiCore.MainForm.Location = new Point(int.Parse(Options.BotWindowX), int.Parse(Options.BotWindowY));
            }
        }
    }
}
