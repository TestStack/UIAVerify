// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Xml;

//this makes easier for custom loggers to find logging objects
namespace Microsoft.Test.UIAutomation.Logging.InfoObjects
{
    using Microsoft.Test.UIAutomation.TestManager;

    public class StartTestInfo
    {
        private const int _headerWidth = 90;

        public readonly XmlNode XmlNodeObjectID;
        public readonly string RunTimeId;
        public readonly TestCaseAttribute TestAttribute;
        public readonly MethodInfo MethodInfo;
        public readonly string PossibleIssuesMessage;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlNodeObjectID">XmlNode that idetifies the object to test.  This can be as simple as the name of the control, to a node that represents the path</param>
        /// <param name="testCaseAttribute"></param>
        /// <param name="methodInfo">MethodInfo of the method of the test</param>
        public StartTestInfo(XmlNode xmlNodeObjectID, TestCaseAttribute testCaseAttribute, MethodInfo methodInfo)
        {
            this.XmlNodeObjectID = xmlNodeObjectID; 
            this.TestAttribute = testCaseAttribute;
            this.MethodInfo = methodInfo;

            StringBuilder possibleIssuesMessageBuilder = new StringBuilder();

            this.PossibleIssuesMessage = possibleIssuesMessageBuilder.ToString();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            int step = 0;

            output.AppendLine("Test          : " + this.TestAttribute.TestName);
            output.AppendLine("Summary       : " + this.TestAttribute.TestSummary);
            output.AppendLine("Test Pri      : " + this.TestAttribute.Priority.ToString());
            output.AppendLine("TestCaseType  : " + this.TestAttribute.TestCaseType);
            output.AppendLine("Element       : " + this.TestAttribute.UISpyLookName);
            if (null != this.XmlNodeObjectID)
            {
                output.AppendLine("Path          : " + this.XmlNodeObjectID.InnerXml);
            }

            output.AppendLine(this.PossibleIssuesMessage);

            if (!string.IsNullOrEmpty(this.TestAttribute.ProblemDescription))
                output.AppendLine("Problem Desc : " + this.TestAttribute.ProblemDescription);

            output.AppendLine("Planned steps to be executed       :");
            foreach (string str in this.TestAttribute.Description)
            {
                output.AppendLine("             " + step++ + ") " + str);
            }

            return output.ToString();
        }
    }
}
