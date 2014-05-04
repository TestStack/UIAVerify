// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Globalization;

namespace Microsoft.Test.UIAutomation.Logging
{
    using SystemConsole = System.Console;
    using Microsoft.Test.UIAutomation.Logging.InfoObjects;
    using Microsoft.Test.UIAutomation.TestManager;

    public class LogTypes
    {
        public const string ConsoleLogger = "CONSOLE";
        public const string PiperLogger = "PIPER";
        public const string WTTLogger = "WTT";
        public const string XmlLogger = "XML";
        public const string DefaultLogger = WTTLogger;

        internal const string PiperLoggerDll = "WUIALoggerPiper.dll";
        internal const string WTTLoggerDll = "WUIALoggerWTT.dll";
        internal const string XMLLoggerDll = "WUIALoggerXML.dll";
    }

    public class GenericLogger : ILoggedComponent
    {
        protected int _numberOfTests = 0;
        protected int _numberOfPasses = 0;
        protected int _numberOfTestFailures = 0;
        protected int _numberOfUnexpectedExceptions = 0;
        protected DateTime _DateTimeStart = DateTime.Now;
        protected TestResultInfo _testResultInfo;

        /// --------------------------------------------------------------------
        /// <summary>This will return the type of logger based on logType</summary>
        /// --------------------------------------------------------------------
        public static ILogger GetLogger(LogTypes logType)
        {
            return GetLogger(logType.ToString());
        }

        /// --------------------------------------------------------------------
        /// <summary>This will return the type of logger based on logType</summary>
        /// <param name="logType">Name of the dynamic link library which the 
        /// logger is obtained from</param>
        /// --------------------------------------------------------------------
        public static ILogger GetLogger(string loggerFileName)
        {
            switch (loggerFileName)
            {
                case LogTypes.PiperLogger:
                    loggerFileName = LogTypes.PiperLoggerDll;
                    break;
                case LogTypes.WTTLogger:
                    loggerFileName = LogTypes.WTTLoggerDll;
                    break;
                case LogTypes.XmlLogger:
                    loggerFileName = LogTypes.XMLLoggerDll;
                    break;
                case LogTypes.ConsoleLogger:
                    return new Microsoft.Test.UIAutomation.Logging.ConsoleLogger();
            }

            loggerFileName = string.Format(@"{0}".ToLowerInvariant() + Path.DirectorySeparatorChar + "{1}".ToLowerInvariant(), Directory.GetCurrentDirectory(), loggerFileName);

            PreLogCommentor("Attempting to loading logging file : {0}", loggerFileName);

            if (!File.Exists(loggerFileName))
                throw new ArgumentException("Logging file ({0}) does not exists", loggerFileName);
            else
                PreLogCommentor("File.Exists({0})", loggerFileName);

            PreLogCommentor("Assembly.LoadFrom({0})", loggerFileName);
            Assembly loggerAssembly = Assembly.LoadFrom(loggerFileName);
            PreLogCommentor("Assembly.LoadFrom({0}) succeeded", loggerFileName);

            try
            {
                foreach (Type type in loggerAssembly.GetTypes())
                {
                    if (type.IsClass && type.IsVisible && type.IsPublic)
                    {
                        Type iLoggerInterfaceType = type.GetInterface(typeof(ILogger).Name, true);

                        if (iLoggerInterfaceType != null)
                        {
                            PreLogCommentor("Found interface (ILoggedComponent) so CreateInstance of object");
                            return (ILogger)Activator.CreateInstance(type);
                        }
                    }
                }
            }
            catch (ReflectionTypeLoadException reflectionTypeLoadException)
            {
                Trace.WriteLine(reflectionTypeLoadException.LoaderExceptions[0].Message);
            }
            throw new Exception("unable to fing logger class in assembly " + loggerFileName);
        }


        private static void PreLogCommentor(string comment, params object[] args)
        {
            if (args.Length > 0)
            {
                comment = String.Format(comment, args);
            }
            
            Trace.WriteLine(comment);
            Console.WriteLine(comment);
        }

        /// --------------------------------------------------------------------
        /// <summary>Call this to write out the info object</summary>
        /// --------------------------------------------------------------------
        public virtual void Persist(object Object)
        {
            if (Object is CommentInfo)
                LogComment((CommentInfo)Object);
            else if (Object is ExceptionInfo)
                LogException((ExceptionInfo)Object);
            else if (Object is MonitorProcessInfo)
                MonitorProcess((MonitorProcessInfo)Object);
            else if (Object is ReportResultsInfo)
                LogFinalResultsSummary((ReportResultsInfo)Object);
            else if (Object is StartTestInfo)
                LogStartTest((StartTestInfo)Object);
            else if (Object is TestEndInfo)
                LogEndTest((TestEndInfo)Object);
            else if (Object is TestResultInfo)
                SetTestResult((TestResultInfo)Object);
            else
                LogComment(Object.ToString());
        }

        /// --------------------------------------------------------------------
        /// <summary></summary>
        /// --------------------------------------------------------------------
        virtual protected void LogComment(string comment)
        {
            SystemConsole.WriteLine(comment);
        }

        /// --------------------------------------------------------------------
        /// <summary></summary>
        /// --------------------------------------------------------------------
        virtual protected void LogComment(CommentInfo commentInfo)
        {
            LogComment(commentInfo.ToString());
        }

        /// --------------------------------------------------------------------
        /// <summary></summary>
        /// --------------------------------------------------------------------
        virtual protected void LogComment(string comment, ConsoleColor color)
        {
            ConsoleColor consoleColor = SystemConsole.ForegroundColor;
            SystemConsole.ForegroundColor = color;
            LogComment(comment);
            SystemConsole.ForegroundColor = consoleColor;
        }

        /// --------------------------------------------------------------------
        /// <summary></summary>
        /// --------------------------------------------------------------------
        virtual protected void LogException(ExceptionInfo exceptionInfo)
        {
            SetTestResult(new TestResultInfo(TestResultInfo.TestResults.UnexpectedError));
            LogComment(string.Format("######: \"{0}\"\n Exception Type: {1}\n StackTrace : {2}",
                exceptionInfo.Exception.Message,
                exceptionInfo.Exception.GetType().ToString(),
                exceptionInfo.FullStackTrace), 
                ConsoleColor.Red);
            //_testResultInfo.Result = TestResultInfo.TestResults.UnexpectedError;
        }

        /// --------------------------------------------------------------------
        /// <summary></summary>
        /// --------------------------------------------------------------------
        virtual protected void LogStartTest(StartTestInfo startTestInfo)
        {
            _numberOfTests++;

            // Assume pass unless we call fail
            _testResultInfo = new TestResultInfo(TestResultInfo.TestResults.Passed);
            const string delim = "\r\n";
            string info = startTestInfo.ToString();
            int iLocE = info.IndexOf(delim);
            int iLocS = 0;

            LogComment("".PadLeft(80, '='));
            while (iLocE != -1)
            {
                LogComment(string.Format("Description : {0}", info.Substring(iLocS, iLocE - iLocS)));
                iLocS = iLocE + delim.Length;
                iLocE = info.IndexOf("\r\n", iLocS);
            }
            LogComment("".PadLeft(80, '='));

        }

        /// --------------------------------------------------------------------
        /// <summary></summary>
        /// --------------------------------------------------------------------
        virtual protected void LogEndTest(TestEndInfo testEndInfo)
        {

            switch (_testResultInfo.Result)
            {
                case TestResultInfo.TestResults.Passed:
                    _numberOfPasses++;
                    break;

                case TestResultInfo.TestResults.Failed:
                    _numberOfTestFailures++;
                    LogTestResult("Failed", ConsoleColor.Red);
                    break;

                case TestResultInfo.TestResults.UnexpectedError:
                    _numberOfUnexpectedExceptions++;
                    LogTestResult("Failed", ConsoleColor.Red);
                    break;
            }            
        }

        /// --------------------------------------------------------------------
        /// <summary></summary>
        /// --------------------------------------------------------------------
        virtual protected void LogTestResult(string passFail, ConsoleColor color)
        {
            LogComment("-".PadLeft(80) + "\n" + "###### " + passFail + "\n" + "-".PadLeft(80), color);
        }

        /// --------------------------------------------------------------------
        /// <summary></summary>
        /// --------------------------------------------------------------------
        virtual protected void LogFinalResultsSummary(ReportResultsInfo reportResultsInfo)
        {
            LogComment("");
            LogComment("");
            LogComment("".PadRight(90, '='));
            LogComment("Test started at : " + _DateTimeStart.ToLongTimeString());
            LogComment("Test ended at : " + DateTime.Now.ToLongTimeString());
            LogComment("Total test run time : " + ((TimeSpan)(DateTime.Now - _DateTimeStart)).ToString());
            LogComment("");
            LogComment("TOTAL TESTS: " + _numberOfTests);
            LogComment("TOTAL PASSES: " + _numberOfPasses);
            LogComment("TOTAL VERIFICATION FAILURES: " + _numberOfTestFailures);
            LogComment("TOTAL UNEXPECTED EXCEPTIONS FAILURES: " + _numberOfUnexpectedExceptions);
        }

        /// --------------------------------------------------------------------
        /// <summary></summary>
        /// --------------------------------------------------------------------
        virtual protected void SetTestResult(TestResultInfo testResultInfo)
        {
            _testResultInfo = testResultInfo;
        }

        /// --------------------------------------------------------------------
        /// <summary></summary>
        /// --------------------------------------------------------------------
        protected virtual void MonitorProcess(MonitorProcessInfo monitorProcessInfo)
        {
            MonitorProcess(monitorProcessInfo.Process);
        }

        /// --------------------------------------------------------------------
        /// <summary></summary>
        /// --------------------------------------------------------------------
        protected virtual void MonitorProcess(Process process)
        {
        }
    }

    /// <summary>
    /// Static class wrapper for the different loggers
    /// </summary>
    public class Logger
    {
        /// -------------------------------------------------------------------
        /// <summary>
        /// Connection to the logging interface
        /// </summary>
        /// -------------------------------------------------------------------
        static internal ILogger _ILogger;

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        static public void CloseLog()
        {
            ((IDisposable)_ILogger).Dispose();
        }

        /// ---------------------------------------------------------------
        /// <summary>
        /// Call to set the specific logger.  There are some default loggers
        /// already defined.  Use the LogTypes class for a list of them.
        /// </summary>
        /// <param name="logFile">Ful path and name of the log file</param>
        /// ---------------------------------------------------------------
        static public void SetLogger(string logFile)
        {
            _ILogger = SetLoggerType(logFile);
        }

        #region ILogger wrapper

        /// ---------------------------------------------------------------
        /// <summary>
        /// Some frameworks such as Piper will kill a process if it
        /// is closed incorrectly and hangs around.  If the framework
        /// does not support this, it will NOP out there
        /// </summary>
        /// <param name="process"></param>
        /// ---------------------------------------------------------------
        public static void MonitorProcess(Process process)
        {
            ValidateLogger();
            _ILogger.Log(new MonitorProcessInfo(process));
        }

        /// ---------------------------------------------------------------
        /// <summary>
        /// Specifies that a test is starting
        /// </summary>
        /// ---------------------------------------------------------------
        public static void StartTest(string testName)
        {
            ValidateLogger();
            _ILogger.Log(new StartTestInfo(null, 
                new TestCaseAttribute(testName), null));
        }

        /// ---------------------------------------------------------------
        /// <summary>
        /// Specifies that a test is ending
        /// </summary>
        /// ---------------------------------------------------------------
        public static void EndTest()
        {
            ValidateLogger();
            _ILogger.Log(new TestEndInfo());
        }

        /// ---------------------------------------------------------------
        /// <summary>
        /// Report that the test had an error
        /// </summary>
        /// ---------------------------------------------------------------
        public static void LogError(string errorMessage)
        {
            ValidateLogger();
            _ILogger.Log(new ExceptionInfo(new Exception(errorMessage)));
        }

        /// ---------------------------------------------------------------
        /// <summary>
        /// Report that the test had an error
        /// </summary>
        /// ---------------------------------------------------------------
        public static void LogError(Exception exception, bool TBD)
        {
            ValidateLogger();
            _ILogger.Log(new ExceptionInfo(exception));
        }

        /// ---------------------------------------------------------------
        /// <summary></summary>
        /// ---------------------------------------------------------------
        public static void LogPass()
        {
            ValidateLogger();
            _ILogger.Log(new TestResultInfo(TestResultInfo.TestResults.Passed));
        }

        /// ---------------------------------------------------------------
        /// <summary>
        /// Returns a report summary
        /// </summary>
        /// ---------------------------------------------------------------
        public static void ReportResults()
        {
            ValidateLogger();
            _ILogger.Log(new ReportResultsInfo());
        }

        /// ---------------------------------------------------------------
        /// <summary>
        /// Add a comment to the test summary
        /// </summary>
        /// ---------------------------------------------------------------
        public static void LogComment(object comment)
        {
            ValidateLogger();
            _ILogger.Log(comment.ToString());
        }

        /// ---------------------------------------------------------------
        /// <summary>
        /// Add a comment to the test summary
        /// </summary>
        /// <param name="format">The format string</param>
        /// <param name="args">An array of objects to write using format</param>
        /// ---------------------------------------------------------------
        public static void LogComment(string format, params object[] args)
        {
            ValidateLogger();

            // format may have formating characters '{' & '}', only call
            // String.Format if there is a valid args arrray. Calling it
            // without and arg will throw an exception if you have formating 
            // chars and no args array.
            if (args.Length == 0)
            {
                _ILogger.Log(format.ToString());
            }
            else
            {
                _ILogger.Log(String.Format(format, args));
            }
        }

        #endregion

        /// -------------------------------------------------------------------
        /// <summary>
        /// Loads a logger DLL binary that impements WUIALogging interface.
        /// If you specify the LogTypes.DefaultLogger, then WttLogger
        /// will be loaded if the executable has INTERNAL in the name, else
        /// PIper logger will be loaded
        /// </summary>
        /// <param name="filename">Filename with path</param>
        /// -------------------------------------------------------------------
        static private ILogger SetLoggerType(string filename)
        {
            _ILogger = GenericLogger.GetLogger(filename);
            return _ILogger;
        }

        /// -------------------------------------------------------------------
        /// <summary>TODO$: ClientTestRuntime should be able to do this in the future</summary>
        /// -------------------------------------------------------------------
        static bool IsRunningUnderWTT()
        {
            //For debugging
            if (Environment.GetEnvironmentVariable("LOG_TO_WTT") != null)
                return true;

            //The WTT Client sets this variable when it runs the process
            return Environment.GetEnvironmentVariable("WTTTASKGUID") != null;
        }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        internal static void ValidateLogger()
        {
            if (_ILogger == null)
                SetLoggerType(LogTypes.DefaultLogger);
        }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public static void LogUnexpectedError(Exception exception, bool displayTrace)
        {
            _ILogger.Log(exception);
        }
    }
}


