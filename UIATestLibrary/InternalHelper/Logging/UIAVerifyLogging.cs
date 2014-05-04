// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Diagnostics;
using System.Reflection;
using System.Collections;
using System.IO;
using System.Text;
using System.Windows.Automation;
using System.Xml;

namespace Microsoft.Test.UIAutomation.Logging
{
    using Microsoft.Test.UIAutomation.TestManager;
    using Microsoft.Test.UIAutomation.Logging.InfoObjects;
    using Microsoft.Test.UIAutomation.Core;

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Loggin object for InternalHelper
    /// </summary>
    /// -----------------------------------------------------------------------
    sealed public class UIAVerifyLogger
    {
        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        static int _incorrectConfigurations = 0;

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        static int _knownIssues = 0;

        /// <summary>
        /// this holds Logger to use
        /// </summary>
        static ILogger _currentLogger;

        /// -------------------------------------------------------------------
        /// <summary>
        /// Report that the test had an error
        /// </summary>
        /// -------------------------------------------------------------------
        public static void LogError(Exception exception)
        {
            // Our test framework calls using Invoke, and throw is returned 
            if (exception is TargetInvocationException)
                exception = exception.InnerException;

            // If a test catches the exception, and then rethrows the excpeption later, it uses "RETHROW" 
            // to allow this global exception handler to peel this rethrow and analyze the actual exception.
            if (exception.Message == "RETHROW")
                exception = exception.InnerException;

            if (exception.GetType() == typeof(InternalHelper.Tests.KnownProductIssueException))
            {
                _knownIssues++;
                _currentLogger.Log(new ExceptionInfo(exception, false, true, false));
                LogPass();
            }
            else if (exception.GetType() == typeof(InternalHelper.Tests.IncorrectElementConfigurationForTestException))
            {
                _incorrectConfigurations++;
                _currentLogger.Log(new CommentInfo(exception.Message));
                LogPass();
            }
            else if (exception.GetType() == typeof(InternalHelper.Tests.TestErrorException))
            {
                _currentLogger.Log(new ExceptionInfo(exception));
                _currentLogger.Log(new TestResultInfo(TestResultInfo.TestResults.Failed));
            }
            else
            {
                LogUnexpectedError(exception);
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Report an excepetion that was not expected
        /// </summary>
        /// -------------------------------------------------------------------
        public static void LogUnexpectedError(Exception exception)
        {
            _currentLogger.Log(new ExceptionInfo(exception, true, false, false));
            _currentLogger.Log(new TestResultInfo(TestResultInfo.TestResults.UnexpectedError));
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Loads a logger DLL binary that impements UI Automation Logging interface.
        /// </summary>
        /// <param name="filename">Filename with path</param>
        /// -------------------------------------------------------------------
        public static void SetLogger(string filename)
        {
            SetLogger(GenericLogger.GetLogger(filename));
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Loads a logger DLL binary that impements UI Automation Logging interface
        /// </summary>
        /// <param name="filename">Filename with path</param>
        /// -------------------------------------------------------------------
        static public void SetLogger(ILogger logger)
        {
            if (logger == null)
                throw new ArgumentNullException();

            _currentLogger = logger;
        }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public static void LogComment(object comment)
        {
            LogComment(comment.ToString());
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Log comment to the output
        /// </summary>
        /// <param name="format">The format string</param>
        /// <param name="args">An array of objects to write using format</param>
        /// -------------------------------------------------------------------
        public static void LogComment(string format, params object[] args)
        {
            // format may have formating characters '{' & '}', only call
            // String.Format if there is a valid args arrray. Calling it
            // without and arg will throw an exception if you have formating 
            // chars and no args array.

            string comment = format;

            if (args.Length > 0)
            {
                comment = String.Format(format, args);
            }
            _currentLogger.Log(new CommentInfo(comment));
        }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public static void StartTest(XmlNode xmlElementIdentifier, TestCaseAttribute testAttribute, MethodInfo methodInfo)
        {
            _currentLogger.Log(new StartTestInfo(xmlElementIdentifier, testAttribute, methodInfo));
        }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public static void LogPass()
        {
            _currentLogger.Log(new TestResultInfo(TestResultInfo.TestResults.Passed));
        }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public static void EndTest()
        {
            _currentLogger.Log(new TestEndInfo());
        }

        /// ---------------------------------------------------------------
        /// <summary></summary>
        /// ---------------------------------------------------------------
        public static void MonitorProcess(Process process)
        {
            _currentLogger.Log(new MonitorProcessInfo(process));
        }

        /// ---------------------------------------------------------------
        /// <summary>Last call to close the channel down to the logger.  
        /// No tests should be ran after this call</summary>
        /// ---------------------------------------------------------------
        public static void CloseLog()
        {
            if (_currentLogger is IDisposable)
            {
                ((IDisposable)_currentLogger).Dispose();
            }
        }
        /// ---------------------------------------------------------------
        /// <summary></summary>
        /// ---------------------------------------------------------------
        public static void ReportResults()
        {
            _currentLogger.Log(new ReportResultsInfo());
        }
    }
}