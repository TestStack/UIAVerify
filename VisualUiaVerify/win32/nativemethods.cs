// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace VisualUIAVerify.Win32
{
    static class NativeMethods
    {
        public const int DLGC_STATIC = 0x100;
        public const int GWL_EXSTYLE = -20;
        public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        public const uint MOD_ALT = 1;
        public const uint MOD_CONTROL = 2;
        public const uint MOD_SHIFT = 4;
        public const uint OBJ_BITMAP = 7;
        public const int SRCCOPY = 0xcc0020;
        public const int SW_RESTORE = 9;
        public const int SW_SHOWNA = 8;
        public const int SWP_NOACTIVATE = 0x10;
        public const int TOKEN_ELEVATION = 20;
        public const int TOKEN_ELEVATION_TYPE = 0x12;
        public const int TOKEN_ELEVATION_TYPE_DEFAULT = 1;
        public const int TOKEN_ELEVATION_TYPE_FULL = 2;
        public const int TOKEN_ELEVATION_TYPE_LIMITED = 3;
        public const int TOKEN_QUERY = 8;
        public const int VK_F1 = 0x70;
        public const uint VK_R = 0x52;
        public const int VK_SHIFT = 0x10;
        public const int WM_GETDLGCODE = 0x87;
        public const int WM_HOTKEY = 0x312;
        public const int WM_KEYDOWN = 0x100;
        public const int WM_NCLBUTTONDBLCLK = 0xa3;
        public const int WS_EX_TOOLWINDOW = 0x80;
    }
}
