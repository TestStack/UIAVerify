// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Microsoft.Test.UIAutomation.Logging
{
    using Microsoft.Test.UIAutomation.Logging.InfoObjects;

    public class XmlLogger : ILogger
    {
        ILoggedComponent _commentInfoObject = new CommentInfoObject();
        ILoggedComponent _exceptionInfoObject = new ExceptionInfoObject();
        ILoggedComponent _startTestInfoObject = new StartTestInfoObject();
        ILoggedComponent _testResultInfoObject = new TestResultInfoObject();
        ILoggedComponent _nullInfoObject = new NullInfoObject();

        public void Log(object logType)
        {
            if (logType is CommentInfo)
                this._commentInfoObject.Persist(logType);
            else if (logType is ExceptionInfo)
                this._exceptionInfoObject.Persist(logType);
            else if (logType is StartTestInfo)
                _startTestInfoObject.Persist(logType);
            else if (logType is TestResultInfo)
                _testResultInfoObject.Persist(logType);
            else
            {
                Debug.WriteLine("XmlLogger cannot recognize the type to log. XmlLogger will use NullXmlLogger.");
                this._nullInfoObject.Persist(logType);
            }
        }
    }
}
