using System;
using System.Runtime.InteropServices;

namespace Latite
{
    class User32
    {
        public struct RECT
        {
            public int left, top, right, bottom;
        }
        public static RECT rect;
        [DllImport("user32.dll")]
        public static extern short GetKeyState(int nVirtKey);
        // winuser.h
        [DllImport("user32.dll")]
        // LatiteCore.LocalPlayer.CSTR lpClassName, LatiteCore.LocalPlayer.CSTR lpWindowName
        public static extern IntPtr FindWindowA(string IpClassName, string IpWindowName);
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        // needed for size of minecraft window, pos, etc.
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT IpRect);
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow(); // get the window on the foreground

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);
    }
}
