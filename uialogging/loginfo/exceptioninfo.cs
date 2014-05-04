// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

//this makes easier for custom loggers to find logging objects
namespace Microsoft.Test.UIAutomation.Logging.InfoObjects
{
    public class ExceptionInfo
    {
        public readonly Exception Exception;
        public readonly bool Unexpected;
        public readonly bool KnowBug;
        public readonly bool IncorrectConfiguration;

        /// -------------------------------------------------------------------
        /// <summary>Returns the complete stack for the exception including inner 
        /// exceptions</summary>
        /// -------------------------------------------------------------------
        public string FullStackTrace
        {
            get
            {
                Exception e = Exception;
                StringBuilder buffer = new StringBuilder(e.StackTrace);

                while (null != (e = e.InnerException))
                {
                    buffer.AppendLine("---------INNER_EXCEPTION---------");
                    buffer.AppendLine(e.StackTrace);
                }
                return buffer.ToString();
            }
        }

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

            if (this.KnowBug || this.IncorrectConfiguration)
                output.AppendLine("Message:");
            else
                output.Append("Message(######): \n");

            output.AppendLine(this.Exception.Message);

            if (showStackTrace)
            {
                Exception exc = Exception;
                do
                {
                    output.AppendLine("StackTrace:\n");
                    output.AppendLine(this.Exception.StackTrace);
                    exc = exc.InnerException;
                }
                while (exc != null);
            }

            return output.ToString();
        }
    }
}
