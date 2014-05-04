// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Automation;
using System.Xml;

namespace WUIATestLibrary.InternalTestHelper
{
    public class AutomationElementPathFromRoot
    {
        public class PathItem
        {
            [XmlAttribute]
            public string AutomationId, ClassName, LocalizedControlType, ControlType, Name, RuntimeId, QueryString, GlobalizedQryString, ProviderDescription;

            [XmlElement("Path")]
            public PathItem ChildItem;
        }

        public PathItem Path;

        public XmlNode XmlNode
        {
            get
            {
                StringBuilder pathXmlString = new StringBuilder();

                // Serialize the object to the StringBuilder
                using (XmlWriter xmlTestLog = XmlTextWriter.Create(pathXmlString))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(AutomationElementPathFromRoot));
                    xmlSerializer.Serialize(xmlTestLog, this);
                }

                // Now return only the InnerDocument
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(pathXmlString.ToString());
                return doc.DocumentElement.FirstChild.Clone();
            }
        }
        public string InnerXml
        {
            get
            {
                return XmlNode.InnerXml;
            }
        }

        public AutomationElementPathFromRoot() { }
        public AutomationElementPathFromRoot(AutomationElement element, string qryString, string glbQryString)
        {
            Stack<AutomationElement> pathToRoot = new Stack<AutomationElement>();

            while (element != null)
            {
                pathToRoot.Push(element);
                try
                {
                    element = TreeWalker.RawViewWalker.GetParent(element);
                }
                catch
                {
                    element = null;
                }
            }

            if (pathToRoot.Count > 0)
            {
                this.Path = new PathItem();
                PathItem tempPathItem = this.Path;
                PathItem lastPathItem = null;

                while (pathToRoot.Count > 0)
                {
                    AutomationElement e = pathToRoot.Pop();
                    tempPathItem.AutomationId = e.Current.AutomationId;
                    tempPathItem.ClassName = e.Current.ClassName;
                    tempPathItem.LocalizedControlType = e.Current.LocalizedControlType;
                    tempPathItem.ControlType = e.Current.ControlType.ProgrammaticName;
                    tempPathItem.Name = e.Current.Name;
                    tempPathItem.RuntimeId = string.Join(".", Array.ConvertAll<int, string>(e.GetRuntimeId(),
                            new Converter<int, string>(delegate(int i) { return i.ToString(); })));

                    #if NATIVE_UIA
                    if (pathToRoot.Count == 1)                    
                    {
                        tempPathItem.ProviderDescription = (string)e.GetCurrentPropertyValue(AutomationElement.ProviderDescriptionProperty);
                        if (qryString != String.Empty)
                        {
                            tempPathItem.QueryString = qryString;
                        }                        
                        if (glbQryString != String.Empty)
                        {
                            tempPathItem.GlobalizedQryString = glbQryString;                            
                        }
                    }
                    #endif

                    lastPathItem = tempPathItem;
                    tempPathItem = tempPathItem.ChildItem = new PathItem();
                }

                if (lastPathItem != null)
                    lastPathItem.ChildItem = null;

            }
        }
    }
}
