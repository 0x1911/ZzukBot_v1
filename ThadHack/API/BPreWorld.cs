using System;
using System.Text;
using ZzukBot.Mem;

namespace ZzukBot.API
{
    public static class BPreWorld
    {
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
                    return string.Empty;
                }
            }
        }
    }
}
