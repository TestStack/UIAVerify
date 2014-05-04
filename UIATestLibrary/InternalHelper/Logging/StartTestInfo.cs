// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;
using System.Reflection;

//this makes easier for custom loggers to find logging objects
namespace WUIATestLibrary.Logging
{
    using Microsoft.Test.UIAutomation.TestManager;

    public class StartTestInfo
    {
        private const int _headerWidth = 90;

        public readonly AutomationElement AutomationElement;
        public readonly TestCaseAttribute TestAttribute;
        public readonly MethodInfo MethodInfo;
        public readonly string PossibleIssuesMessage;

        public StartTestInfo(AutomationElement automationElement, TestCaseAttribute testAttribute, MethodInfo methodInfo)
        {
            this.AutomationElement = automationElement;
            this.TestAttribute = testAttribute;
            this.MethodInfo = methodInfo;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            int step = 0;

            output.AppendLine("".PadRight(_headerWidth, '='));
            output.AppendLine("Test          : " + this.TestAttribute.TestName);
            output.AppendLine("Summary       : " + this.TestAttribute.TestSummary);
            output.AppendLine("Test Pri      : " + this.TestAttribute.Priority.ToString());
            output.AppendLine("TestCaseType  : " + this.TestAttribute.TestCaseType);
            output.AppendLine("Element       : " + this.TestAttribute.UISpyLookName);

            output.AppendLine(this.PossibleIssuesMessage);

            if (!string.IsNullOrEmpty(this.TestAttribute.ProblemDescription))
                output.AppendLine("Problem Desc : " + this.TestAttribute.ProblemDescription);

            output.AppendLine("Planned steps to be executed       :");
            foreach (string str in this.TestAttribute.Description)
            {
                output.AppendLine("             " + step++ + ") " + str);
            }

            output.AppendLine("".PadRight(_headerWidth, '='));

            return output.ToString();
        }
    }
}
