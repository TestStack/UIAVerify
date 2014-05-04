// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.Test.UIAutomation.TestManager;
using System.Xml.Serialization;

namespace Microsoft.Test.UIAutomation.Logging.XmlSerializableObjects

{
    [XmlRoot("Test")]
    public class XmlTest
    {
        /// <summary>
        /// id of the test, to be able to navigate between tests
        /// </summary>
        [XmlAttribute]
        public string Id;

        public XmlTestInfo TestInfo = new XmlTestInfo();

        [XmlArrayItem("Comment", typeof(XmlCommentInfo))]
        [XmlArrayItem("Exception", typeof(XmlExceptionInfo))]
        public ArrayList Messages = new ArrayList();

        public XmlTestResult Result = new XmlTestResult();

        public XmlTest()
        {
            this.Id = XmlLog.GetUniqueTestId();
        }

        internal void AddComment(XmlCommentInfo xmlCommentInfo)
        {
            this.Messages.Add(xmlCommentInfo);
        }

        internal void AddException(XmlExceptionInfo xmlExceptionInfo)
        {
            this.Messages.Add(xmlExceptionInfo);
        }

        public void ToXml(System.Xml.XmlWriter writer)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(XmlTest));
            xmlSerializer.Serialize(writer, this);
        }
    }
}
