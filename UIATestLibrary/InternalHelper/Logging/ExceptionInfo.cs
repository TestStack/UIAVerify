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
    public class ExceptionInfo
    {
        public readonly Exception Exception;
        public readonly bool Unexpected;
        public readonly bool KnowBug;
        public readonly bool IncorrectConfiguration;

        public ExceptionInfo(Exception exception, bool unexpected, bool knownBug, bool incorrectConfiguration)
        {
            this.Exception = exception;
            this.Unexpected = unexpected;
            this.KnowBug = knownBug;
            this.IncorrectConfiguration = incorrectConfiguration;
        }

        public ExceptionInfo(Exception exception) : this(exception, false, false, false) { }


        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.Append("!! EXCEPTION !!\n");

            bool showStackTrace = true;

            if (this.KnowBug)
            {
                output.Append("Known Product Failure. Bug: \n");
                showStackTrace = false;
            }

            if (this.IncorrectConfiguration)
            {
                output.Append("Incorrect configurations. Reason: \n");
                showStackTrace = false;
            }

            output.Append("Message:\n");
            output.Append(this.Exception.Message);

            if (showStackTrace)
            {
                output.Append("StackTrace:\n");
                output.Append(this.Exception.StackTrace);
            }

            return output.ToString();
        }
    }
}
