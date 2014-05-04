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

    public class XmlExceptionInfo
    {
        [XmlAttribute]
        public bool Unexpected;

        [XmlAttribute]
        public bool KnownBug;

        [XmlAttribute]
        public bool IncorrectConfiguration;

        public string Message;

        public string StackTrace;

        public XmlExceptionInfo() { }

        public XmlExceptionInfo(ExceptionInfo exceptionInfo)
        {
            this.Unexpected = exceptionInfo.Unexpected;
            this.KnownBug = exceptionInfo.KnowBug;
            this.IncorrectConfiguration = exceptionInfo.IncorrectConfiguration;

            this.Message = exceptionInfo.Exception.Message;
            this.StackTrace = exceptionInfo.FullStackTrace;
        }
    }
}
