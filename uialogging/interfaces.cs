// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Test.UIAutomation.Logging
{
    public interface ILogger
    {
        void Log(object Object);
    }

    public interface ILoggedComponent
    {
        void Persist(object persistObject);
    }
}
