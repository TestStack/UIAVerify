// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;


namespace VisualUIAVerify.Win32
{
    internal static class SafeNativeMethods
    {
        // Methods
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern bool BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", ExactSpelling = true)]
        internal static extern bool SetProcessDPIAware();
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern bool SetWindowPos(IntPtr hWnd, IntPtr hwndAfter, int x, int y, int width, int height, int flags);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }

}
