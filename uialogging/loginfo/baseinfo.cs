// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Text;

namespace Microsoft.Test.UIAutomation.Logging.InfoObjects
{
    public class BaseInfo
    {
        DateTime _now = DateTime.Now;

        public BaseInfo()
        {
        }

        public override string ToString()
        {
            return string.Format("[{0}:{1}:{2}:{3}]",DateTime.Now.Hour.ToString("00"), DateTime.Now.Minute.ToString("00"), DateTime.Now.Second.ToString("00"), DateTime.Now.Millisecond.ToString("00").Substring(0, 2));
        }
    }
}
