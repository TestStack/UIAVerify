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
    public class XmlCommentInfo
    {
        public XmlCommentInfo() { }
        public XmlCommentInfo(string comment) { this.Comment = comment; }

        [XmlText]
        public string Comment;
    }
}
