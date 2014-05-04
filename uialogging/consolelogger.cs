// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Test.UIAutomation.Logging
{
    using Microsoft.Test.UIAutomation.Logging;

    public class ConsoleLogger : ILogger
    {
        private GenericLogger _logger = new GenericLogger();

        public void Log(object logType)
        {
            _logger.Persist(logType);
        }
    }
}
