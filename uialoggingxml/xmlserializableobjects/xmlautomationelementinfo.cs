// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Windows.Automation;

namespace Microsoft.Test.UIAutomation.Logging.XmlSerializableObjects
{
    public class XmlTestElementInfo
    {
        public XmlNode ElementPath;

        public XmlTestElementInfo() { }
        public XmlTestElementInfo(XmlNode xmlNodeElementPath)
        {
            this.ElementPath = xmlNodeElementPath; 
        }
    }
}
