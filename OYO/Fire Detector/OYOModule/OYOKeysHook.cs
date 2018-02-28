using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace oyo
{
    public static class OYOKeysHook
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);


        private delegate IntPtr                 LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private static LowLevelKeyboardProc     callbackProc = HookCallback;

        public delegate void                    KeyboardHookEvent(Keys key, bool isDown);

        private const int                       WH_KEYBOARD_LL = 13;
        private const int                       WM_KEYDOWN = 0x0100;

        private static IntPtr                   hookId;
        public static event KeyboardHookEvent   OnKeyboardHook;



        public static void Set()
        {
            if(hookId != IntPtr.Zero)
                return;

            using (var curProcess = Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {
                hookId = SetWindowsHookEx(WH_KEYBOARD_LL, callbackProc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        public static void Unset()
        {
            if(hookId == IntPtr.Zero)
                return;

            UnhookWindowsHookEx(hookId);
            hookId = IntPtr.Zero;
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                var isDown = wParam == (IntPtr)WM_KEYDOWN;

                if (OnKeyboardHook != null)
                    OnKeyboardHook.Invoke((Keys)vkCode, isDown);
            }

            return CallNextHookEx(hookId, nCode, wParam, lParam);
        }
    }
}
