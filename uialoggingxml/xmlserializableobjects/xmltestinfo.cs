// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Xml.Serialization;
using System.Xml;
using System.Windows.Automation;

namespace Microsoft.Test.UIAutomation.Logging.XmlSerializableObjects
{
    using Microsoft.Test.UIAutomation.TestManager;
    using Microsoft.Test.UIAutomation.Logging.InfoObjects;

    public class XmlMethodInfo
    {
        public string AssemblyFile = "";
        public string Class = "";
        public string Method = "";
    }


    public class XmlTestInfo
    {
        public string Name, Summary, Priority, Status, Author, TestCaseType;
        
        [XmlElement()]
        public string[] Description;

        public XmlMethodInfo MethodInfo = new XmlMethodInfo();

        [XmlElement("AutomationElement")]
        public XmlTestElementInfo ElementInfo = new XmlTestElementInfo();

        public XmlTestInfo() { }

        public XmlTestInfo(StartTestInfo startTestInfo)
            : this(startTestInfo.TestAttribute, startTestInfo.MethodInfo, startTestInfo.XmlNodeObjectID) 
        { }

        private XmlTestInfo(
            TestCaseAttribute testCaseAttribute, 
            MethodInfo methodInfo,
            XmlNode xmlElementPathNode)
        {
            this.Name = testCaseAttribute.TestName;
            this.Summary = testCaseAttribute.TestSummary;
            this.Priority = testCaseAttribute.Priority.ToString();
            this.Status = testCaseAttribute.Status.ToString();
            this.Author = testCaseAttribute.Author;
            this.TestCaseType = testCaseAttribute.TestCaseType.ToString();
            this.Description = testCaseAttribute.Description;
            
            if (methodInfo != null)
            {
                this.MethodInfo.AssemblyFile = methodInfo.DeclaringType.Assembly.FullName;
                this.MethodInfo.Class = methodInfo.DeclaringType.FullName;
                this.MethodInfo.Method = methodInfo.Name;
            }

            this.ElementInfo = new XmlTestElementInfo(xmlElementPathNode); 
        }
    }
}
