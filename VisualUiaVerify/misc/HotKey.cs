// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace VisualUIAVerify.Misc
{
    struct HotKey
    {
        public readonly string MaskString;
        public readonly string Key;

        public readonly EventHandler Handler;

        public HotKey(string MaskString, string Key, EventHandler Handler)
        {
            this.MaskString = MaskString;
            this.Key = Key;
            this.Handler = Handler;
        }

        public string Description
        {
            get
            {
                if (string.IsNullOrEmpty(MaskString))
                    return this.Key;
                else
                    return this.MaskString + "+" + this.Key;
            }
        }

        public uint Mask
        {
            get
            {
                if (this.MaskString.Length <= 0)
                {
                    return 0;
                }
                uint num1 = 0;
                foreach (string text in this.MaskString.Split(new char[] { '+' }))
                {
                    switch (text.Trim())
                    {
                        case "Ctrl":
                            num1 |= 2;
                            break;

                        case "Shift":
                            num1 |= 4;
                            break;

                        case "Alt":
                            num1 |= 1;
                            break;

                        default:
                            return uint.MaxValue;
                    }
                }
                return num1;
            }
        }

        public uint VKCode
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Key))
                {
                    if (this.Key.Length == 1)
                    {
                        return this.Key[0];
                    }
                    if (this.Key[0] == 'F')
                    {
                        return (0x6f + Convert.ToUInt32(this.Key.Substring(1), CultureInfo.InvariantCulture));
                    }
                }
                return uint.MaxValue;
            }
        }
    }
}
