// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

//this makes easier for custom loggers to find logging objects
namespace WUIATestLibrary.Logging
{
    public class TestResultInfo
    {
        public enum TestResults
        {
            Passed,
            Failed,
            UnexpectedError
        }

        public readonly TestResults Result;

        public TestResultInfo(TestResults result)
        {
            this.Result = result;
        }

        public override string ToString()
        {
            return "TestResult: " + this.Result.ToString();
        }

    }
}
