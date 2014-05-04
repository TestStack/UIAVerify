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
    [XmlRoot("TestRun")]
    public class XmlTestRun
    {
        DateTime Time = DateTime.Now;
        
        [XmlElement("Test")]
        public List<XmlTest> Tests = new List<XmlTest>();

        public void AddTest(XmlTest test)
        {
            this.Tests.Add(test);
        }
    }
}
