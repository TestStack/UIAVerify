// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

//this makes easier for custom loggers to find logging objects
namespace Microsoft.Test.UIAutomation.Logging.InfoObjects
{
    public class MonitorProcessInfo
    {
        public readonly Process Process;

        public MonitorProcessInfo(Process process)
        {
            this.Process = process;
        }
    }
}
