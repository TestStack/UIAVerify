// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Diagnostics;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Automation;
using System.Xml;
using System.Xml.Serialization;
#if NATIVE_UIA
using QueryStringWrapper;
#endif

namespace Microsoft.Test.UIAutomation.Logging
{
    using Microsoft.Test.UIAutomation.Logging.XmlSerializableObjects;
    using Microsoft.Test.UIAutomation.TestManager;
    using Microsoft.Test.UIAutomation.Logging.InfoObjects;
    using Microsoft.Test.UIAutomation.Core;

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Loggin object for InternalHelper
    /// </summary>
    /// -----------------------------------------------------------------------
    sealed public class UIVerifyLogger
    {
        public class UILogger
        {
            public List<ILogger> uivLogger = new List<ILogger>();

            public void Log(object Object)
            {
                foreach (ILogger currentLogger in uivLogger)
                {
                    currentLogger.Log(Object);
                }
            }
        }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        static int _incorrectConfigurations = 0;

        /// <summary>
        /// this holds Logger to use
        /// </summary>
        static UILogger _currentLogger = new UILogger();

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        static string _uivLogFile = String.Empty;

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

            if (exception.GetType() == typeof(InternalHelper.Tests.IncorrectElementConfigurationForTestException))
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
        /// Loads a logger DLL binary that impements WUIALogging interface.
        /// </summary>
        /// <param name="filename">Filename with path</param>
        /// -------------------------------------------------------------------
        public static void SetLogger(string filename)
        {
            SetLogger(GenericLogger.GetLogger(filename));
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Loads a logger DLL binary that impements WUIALogging interface
        /// </summary>
        /// <param name="filename">Filename with path</param>
        /// -------------------------------------------------------------------
        static public void SetLogger(ILogger logger)
        {            
            // Clear the _currentLogger if it is set by old runs
            _currentLogger.uivLogger.Clear();
            if (logger == null)
                throw new ArgumentNullException();
            List<ILogger> loggerList = new List<ILogger>();

            if (logger is XmlLogger)
            {
                loggerList.Add(logger);
            }
            else
            {
                loggerList.Add(logger);
                loggerList.Add(new XmlLogger());                                
            }
            SetLogger(loggerList);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Loads a logger DLL binary that impements WUIALogging interface
        /// </summary>
        /// <param name="filename">Filename with path</param>
        /// -------------------------------------------------------------------
        static public void SetLogger(List<ILogger> logger)
        {
            for (int i=0; i<logger.Count; i++)
            {
                if (logger[i] == null)
                    throw new ArgumentNullException();
                _currentLogger.uivLogger.Add(logger[i]);
            }            
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

        /// ---------------------------------------------------------------
        /// <summary>The call will generate the XML log if the logger is 
        /// XML </summary>
        /// ---------------------------------------------------------------
        public static void GenerateXMLLog(string filePath)
        {            
            String logSaveLocation;
            if (filePath == string.Empty)
            {
                String newLog1 = Path.Combine(Directory.GetCurrentDirectory(), "UIAVerifyLogs"); //Default UIAVerifyLogs Log directory = %Desktop%\UIAVerifyLogs

                String logTimeStamp = String.Format("[{0:yyyy}.{0:mm}.{0:dd}]_({0:HH}.{0:mm}.{0:ss})", DateTime.Now);

                if (!Directory.Exists(newLog1))
                    Directory.CreateDirectory(newLog1);

                //Save file format: UserName_OSVersion_[Year.Month.Day]_(Hour.Minute.Second).xml
                String newLog2 = String.Format("{0}_{1}_{2}.xml", Environment.UserName, Environment.OSVersion.VersionString, logTimeStamp);
                logSaveLocation = Path.Combine(newLog1, newLog2);
            }
            else
            {
                if (Path.GetExtension(filePath).ToLower() == ".xml")
                {
                    logSaveLocation = filePath;
                }
                else
                {
                    logSaveLocation = Path.ChangeExtension(filePath, "xml");
                }
            }
            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.Indent = true;

            #if NATIVE_UIA
            // Add the machine configuration details as another test
            Microsoft.Test.UIAutomation.TestManager.TestCaseAttribute tca = new Microsoft.Test.UIAutomation.TestManager.TestCaseAttribute("Configuration", TestPriorities.Pri0, Microsoft.Test.UIAutomation.TestManager.TestStatus.Works, "Microsoft Corp.", new string[] { "This test logs Machine Configuration" });
            StringBuilder pathXmlString = new StringBuilder();
            using (XmlWriter xmlConfigLog = XmlTextWriter.Create(pathXmlString))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(QueryString.LogSystemInformationObject.GetType());
                xmlSerializer.Serialize(xmlConfigLog, QueryString.LogSystemInformationObject);
            }
            // Now return only the InnerDocument
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(pathXmlString.ToString());

            StartTest(doc.DocumentElement.FirstChild.Clone(), tca, null);
            LogPass();
            EndTest();
            #endif

            //lets save log file
            _uivLogFile = logSaveLocation;
            using (XmlWriter xmlLogFile = XmlTextWriter.Create(logSaveLocation, writerSettings))
            {
                XmlLog.GetTestRunXml(xmlLogFile);
            } 
        }
    }
}