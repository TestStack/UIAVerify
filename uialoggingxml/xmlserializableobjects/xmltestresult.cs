// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Microsoft.Test.UIAutomation.Logging.XmlSerializableObjects
{
    using Microsoft.Test.UIAutomation.Logging.InfoObjects;

    public class XmlTestResult
    {
        public enum Results
        {
            Passed,
            Failed,
            UnexpectedError
        }

        [XmlAttribute()]
        public Results Status = Results.Failed;

        public XmlTestResult() { }

        public XmlTestResult(TestResultInfo testResultInfo)
        {
            switch (testResultInfo.Result)
            {
                case TestResultInfo.TestResults.Passed: this.Status = Results.Passed; break;
                case TestResultInfo.TestResults.Failed: this.Status = Results.Failed; break;
                case TestResultInfo.TestResults.UnexpectedError: this.Status = Results.UnexpectedError; break;
            }
        }

    }
}
