// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Test.UIAutomation.Logging.InfoObjects
{
    using Microsoft.Test.UIAutomation.Logging.XmlSerializableObjects;

    class TestResultInfoObject : ILoggedComponent
    {
        /// <summary></summary>
        /// <param name="testResultsInfo">TestResultInfo</param>
        public void Persist(object testResultsInfo)
        {
            if (testResultsInfo is TestResultInfo)
            {
                XmlLog.CurrentTest.Result = new XmlTestResult((TestResultInfo)testResultsInfo);
            }
            else
                ExceptionsHelper.ThrowObjectLoggerDoesNotSupportThisObjectType(testResultsInfo, typeof(TestResultInfo));
        }
    }
}
