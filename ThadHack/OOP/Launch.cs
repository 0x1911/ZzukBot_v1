﻿using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using GreyMagic;
using ZzukBot.Constants;

namespace ZzukBot.OOP
{
    internal static class Launch
    {
        private static int? LaunchWowProcess()
        {
            var doc = XDocument.Load(GuiCore.SettingsFilePath);
            var element = doc.Element("Settings");
            var tmpPath = element.Element("WowExePath").Value;

            var si = new WinImports.STARTUPINFO();
            WinImports.PROCESS_INFORMATION pi;
            WinImports.CreateProcess(tmpPath, null,
                IntPtr.Zero, IntPtr.Zero, false,
                WinImports.ProcessCreationFlags.CREATE_DEFAULT_ERROR_MODE,
                IntPtr.Zero, null, ref si, out pi);

            return (int)pi.dwProcessId;
        }
        
        internal static void Run(int? pId = null)
        {
            int? tmpPiD = pId;

            try
            {
                IntPtr? procHandle = null;
                if (tmpPiD == null)
                {
                    tmpPiD = LaunchWowProcess();
                }
                else
                {
                    procHandle = WinImports.OpenProcess(0x001F0FFF, false, tmpPiD.Value);
                }

                var proc = Process.GetProcessById(tmpPiD.Value);
                //MessageBox.Show("ID:" + proc.Id);


                if (procHandle == null)
                    procHandle = proc.Handle;
                //MessageBox.Show("Handle:" + proc.Handle);

                if (proc.Id == 0)
                {
                    MessageBox.Show(
                        "Couldnt get the WoW process. Is the path in Settings.xml right? If no delete it and rerun ZzukBot");
                    return;
                }
                proc.WaitForInputIdle();
                //MessageBox.Show("Wait for input handle");
                var reader = new ExternalProcessReader(proc);

                var loadDllPtr = WinImports.GetProcAddress(WinImports.GetModuleHandle("kernel32.dll"), "LoadLibraryW");
                //MessageBox.Show("loadDllPtr: " + loadDllPtr.ToString("X"));
                if (loadDllPtr == IntPtr.Zero)
                {
                    MessageBox.Show("Couldnt get address of LoadLibraryW");
                    return;
                }

                var LoaderStrPtr = reader.AllocateMemory(500);
                if (LoaderStrPtr == IntPtr.Zero)
                {
                    MessageBox.Show("Couldnt allocate memory 2");
                    return;
                }

                var LoaderStr =
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                    + "\\Loader.dll";
                //MessageBox.Show(LoaderStr);

                var res = reader.WriteString(LoaderStrPtr, LoaderStr, Encoding.Unicode);
                if (!res)
                {
                    MessageBox.Show("Couldnt write dll path to WoW's memory");
                    return;
                }

                var test = WinImports.CreateRemoteThread(procHandle.Value, (IntPtr) null, (IntPtr) 0, loadDllPtr,
                    LoaderStrPtr, 0,
                    (IntPtr) null);
                if (test
                     == (IntPtr) 0)
                {
                    MessageBox.Show("Couldnt inject the dll");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}