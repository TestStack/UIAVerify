//---------------------------------------------------------------------------
//
// <copyright file="TestResultsControl" company="Microsoft">
//    Copyright (C) Microsoft Corporation.  All rights reserved.
// </copyright>
// 
//
// Description: User Control showing result log of performed tests
//
// History:  
//  08/29/2006 : Ondrej Lehecka, created
//
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace VisualUIAVerify.Controls
{
    //using WUIATestLibrary.Logging.Xml;
    using Microsoft.Test.UIAutomation.Logging.XmlSerializableObjects;
    using Microsoft.Test.UIAutomation.Logging;

    /// <summary>
    /// Control showing result log of performed tests
    /// </summary>
    public partial class TestResultsControl : UserControl
    {
        //declaration of temporary file names
        private const string constOverallResultsFileName = "OverallResults";
        private const string constAllResultsFileName = "AllResults";
        private const string constFullDetailResultsFileName = "FullDetailResults";
        private const string constTestLogTemplateFileName = "TestLog";
        private const string constTestLogFileNamePrefix = "test";
        private const string constXmlOutputFileName = "XmlOutput.xml";

        //definition of MARKS used in XSLT files (for replace)
        private const string constAllTestsHrefPassedMark = "ALLTESTS_HREF_PASSED";
        private const string constAllTestsHrefFailedMark = "ALLTESTS_HREF_FAILED";
        private const string constAllTestsHrefUnexpectedErrorMark = "ALLTESTS_HREF_UNEXPECTEDERROR";
        private const string constTempFilesPrefixMark = "TEMP_FILES_PREFIX";

        /// <summary>
        /// log types
        /// </summary>
        public enum LogTypes
        {
            /// <summary>
            /// brief results summary
            /// </summary>
            OverallResults,

            /// <summary>
            /// all results
            /// </summary>
            AllResults,

            /// <summary>
            /// full detailed all results
            /// </summary>
            FullDetailResults,

            /// <summary>
            /// log of one single test
            /// </summary>
            TestLog,

            /// <summary>
            /// plain xml log file
            /// </summary>
            XmlOutput
        }

        /// <summary>
        /// holds current log type
        /// </summary>
        private LogTypes _logType;

        /// <summary>
        /// id of last shown testlog
        /// </summary>
        private string _lastTestId;

        /// <summary>
        /// indicates if temporary log files were generated (xml files)
        /// </summary>
        private bool _logFilesGenerated;

        /// <summary>
        /// indicates if xslt templated was emited to temporary directory
        /// </summary>
        private static bool _templatesEmited;

        /// <summary>
        /// evnet indicating that some navigation in web control occured (it is time to enable/disable Back/Forward buttons)
        /// </summary>
        public event NavigationChangedEventHandler NavigationChanged;

        /// <summary>
        /// initilaizes control
        /// </summary>
        public TestResultsControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// get/set current log type
        /// </summary>
        [DefaultValue(LogTypes.OverallResults)]
        public LogTypes LogType
        {
            get { return this._logType; }
            set
            {
                this._logType = value;
                if (value != LogTypes.TestLog)
                    this._lastTestId = null;

                RefreshLog();
            }
        }

        /// <summary>
        /// indicating if previous page is available
        /// </summary>
        public bool CanGoBack
        {
            get { return _webBrowser.CanGoBack; }
        }

        /// <summary>
        /// indicating if subsequent page is available
        /// </summary>
        public bool CanGoForward
        {
            get { return _webBrowser.CanGoForward; }
        }

        /// <summary>
        /// go back in log history
        /// </summary>
        public void GoBack()
        {
            _webBrowser.GoBack();
        }

        /// <summary>
        /// go forward in log history
        /// </summary>
        public void GoForward()
        {
            _webBrowser.GoForward();
        }

        /// <summary>
        /// reads and shows log
        /// </summary>
        public void ReadAndRefreshLog()
        {
            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.Indent = true;

            //lets save log file
            using(XmlWriter xmlLogFile = XmlTextWriter.Create(GetXmlLogFilePath(), writerSettings))
            {
                XmlLog.GetTestRunXml(xmlLogFile);
            }

            //delete all test log files
            string[] testLogFiles = Directory.GetFiles(Path.GetTempPath(), GetTempFilesPrefix() + "." + constTestLogFileNamePrefix + "*.xml", SearchOption.TopDirectoryOnly);
            foreach (string testLogFile in testLogFiles)
            {
                File.Delete(testLogFile);
            }

            //lets save log for each test
            foreach (XmlTest test in XmlLog.Tests)
            {
                using (XmlWriter xmlTestLogFile = XmlTextWriter.Create(GetXmlTestFilePath(test.Id), writerSettings))
                {
                    xmlTestLogFile.WriteProcessingInstruction("xml-stylesheet", "type=\"text/xsl\" href=\"" + GetTemplateFileName(LogTypes.TestLog) + "\"");
                    test.ToXml(xmlTestLogFile);
                }
            }

            this._logFilesGenerated = false;

            //TODO: remove _webBrowser history
            //_webBrowser.

            RefreshLog();
        }

        /// <summary>
        /// refresh the log window
        /// </summary>
        public void RefreshLog()
        {
            if (File.Exists(GetXmlLogFilePath()))
            {
                string fileName;

                if(this._logType == LogTypes.XmlOutput)
                    fileName = GetXmlLogFilePath();
                else
                    fileName = GetLogTypeFilePath();

                _webBrowser.Navigate(fileName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void OpenInNewWindow()
        {
            _webBrowser.Navigate(_webBrowser.Url, true);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ShowQuickFind()
        {
            try
            {
                _webBrowser.Focus();
                SendKeys.Send("^f");
            }
            catch
            {
                MessageBox.Show("To access this feature on system running Windows Vista, press Ctrl+F key");
            }
        }


        private string GetLogTypeFilePath()
        {
            if (!this._logFilesGenerated)
            {
                EmitTemplates();

                foreach (LogTypes logType in Enum.GetValues(typeof(LogTypes)))
                {
                    if(logType != LogTypes.XmlOutput && logType != LogTypes.TestLog)
                    {
                        WriteLogFile(GetTemplateFileName(logType), GetLogFilePath(logType));
                    }
                }
                this._logFilesGenerated = true;
            }

            if (this._logType == LogTypes.TestLog)
            {
                string testLogFileName = GetXmlTestFilePath(this._lastTestId);
                if (File.Exists(testLogFileName))
                    return testLogFileName;

                this._logType = LogTypes.OverallResults;
            }

            return GetLogFilePath(this._logType);
        }


        private static void WriteLogFile(string xsltTransformationFileName, string logFileName)
        {
            using (XmlWriter newLogFile = XmlTextWriter.Create(logFileName))
            {
                using (XmlReader xmlLogFile = XmlReader.Create(GetXmlLogFilePath()))
                {
                    xmlLogFile.MoveToContent();

                    newLogFile.WriteProcessingInstruction("xml-stylesheet", "type=\"text/xsl\" href=\"" + xsltTransformationFileName + "\"");
                    newLogFile.WriteNode(xmlLogFile, false);
                }
            }
        }


        private static void EmitTemplates()
        {
            if (!_templatesEmited)
            {
                string allResultsLogFileName = GetLogFileName(LogTypes.AllResults);

                StringBuilder overallResultsXsltTemplate = new StringBuilder(VisualUIAVerifyResources.OverallResultsXsltTemplate);
                overallResultsXsltTemplate.Replace(constAllTestsHrefPassedMark, allResultsLogFileName + "#Passed");
                overallResultsXsltTemplate.Replace(constAllTestsHrefFailedMark, allResultsLogFileName + "#Failed");
                overallResultsXsltTemplate.Replace(constAllTestsHrefUnexpectedErrorMark, allResultsLogFileName + "#UnexpectedError");

                StringBuilder testResultsXsltTemplate = new StringBuilder(VisualUIAVerifyResources.TestResultsXsltTemplate);
                testResultsXsltTemplate.Replace(constTempFilesPrefixMark, GetTempFilesPrefix());

                StringBuilder fullDetailResultsXsltTemplate = new StringBuilder(VisualUIAVerifyResources.FullDetailResultsXsltTemplate);
                fullDetailResultsXsltTemplate.Replace(constTempFilesPrefixMark, GetTempFilesPrefix());

                string[] xsltTemplates = new string[]
                    { overallResultsXsltTemplate.ToString(), testResultsXsltTemplate.ToString(),
                      fullDetailResultsXsltTemplate.ToString(), VisualUIAVerifyResources.TestLogXsltTemplate };

                string[] templateFileNames = new string[]
                    { GetTemplateFilePath(LogTypes.OverallResults), GetTemplateFilePath(LogTypes.AllResults),
                      GetTemplateFilePath(LogTypes.FullDetailResults), GetTemplateFilePath(LogTypes.TestLog) };

                for (int i = 0; i < xsltTemplates.Length; i++)
                {
                    using (StreamWriter templateFile = new StreamWriter(templateFileNames[i]))
                    {
                        templateFile.Write(xsltTemplates[i]);
                    }
                }

                _templatesEmited = true;
            }
        }

        #region helper methods

        /// <summary>
        /// returns path to test log file
        /// </summary>
        private static string GetXmlTestFilePath(string testId)
        {
            return Path.GetTempPath() + GetTempFilesPrefix() + ".test" + testId + ".xml";
        }

        /// <summary>
        /// return path to a log file
        /// </summary>
        private static string GetLogFilePath(LogTypes logType)
        {
            return GetLogFilePathWithoutExtension(logType) + ".xml";
        }

        /// <summary>
        /// return log file name for log type
        /// </summary>
        private static string GetLogFileName(LogTypes logType)
        {
            return GetLogFileNameWithoutExtension(logType) + ".xml";
        }

        /// <summary>
        /// returns template file path for given type
        /// </summary>
        private static string GetTemplateFilePath(LogTypes logType)
        {
            return GetLogFilePathWithoutExtension(logType) + ".xslt";
        }

        /// <summary>
        /// returns template file name for given type
        /// </summary>
        private static string GetTemplateFileName(LogTypes logType)
        {
            return GetLogFileNameWithoutExtension(logType) + ".xslt";
        }

        /// <summary>
        /// returns temporary file path without extension for given logType
        /// </summary>
        private static string GetLogFilePathWithoutExtension(LogTypes logType)
        {
            return Path.GetTempPath() + GetLogFileNameWithoutExtension(logType);
        }

        /// <summary>
        /// returns temporary filename without extension for given logType
        /// </summary>
        private static string GetLogFileNameWithoutExtension(LogTypes logType)
        {
            string fileName = null;

            switch (logType)
            {
                case LogTypes.OverallResults: fileName = constOverallResultsFileName; break;
                case LogTypes.AllResults: fileName = constAllResultsFileName; break;
                case LogTypes.FullDetailResults: fileName = constFullDetailResultsFileName; break;
                case LogTypes.TestLog: fileName = constTestLogTemplateFileName; break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return GetTempFilesPrefix() + "." + fileName;
        }

        /// <summary>
        /// to store prefix for temporary file names
        /// </summary>
        static string __tempXmlFilesPrefix;

        /// <summary>
        /// returns prefix used for temporary file names
        /// </summary>
        /// <returns></returns>
        static string GetTempFilesPrefix()
        {
            if(__tempXmlFilesPrefix == null)
                __tempXmlFilesPrefix = Path.GetRandomFileName();

            return __tempXmlFilesPrefix;
        }

        /// <summary>
        /// returns filepath to xml log file.
        /// </summary>
        /// <returns></returns>
        static string GetXmlLogFilePath()
        {
            return Path.GetTempPath() + GetXmlLogFileName();
        }

        /// <summary>
        /// returns filename to xml log file.
        /// </summary>
        /// <returns></returns>
        static string GetXmlLogFileName()
        {
            return GetTempFilesPrefix() + "." + constXmlOutputFileName;
        }
        #endregion

        #region events

        /// <summary>
        /// fires event that navigation changed
        /// </summary>
        protected virtual void OnNavigationChanged(Uri url)
        {
            string urlFileName = Path.GetFileNameWithoutExtension(url.LocalPath);

            LogTypes newLogType = this._logType;

            if (urlFileName.StartsWith(GetLogFileNameWithoutExtension(LogTypes.OverallResults)))
                newLogType = LogTypes.OverallResults;
            else if (urlFileName.StartsWith(GetLogFileNameWithoutExtension(LogTypes.AllResults)))
                newLogType = LogTypes.AllResults;
            else if (urlFileName.StartsWith(GetLogFileNameWithoutExtension(LogTypes.FullDetailResults)))
                newLogType = LogTypes.FullDetailResults;
            else
            {
                string testLogFileNamePrefix = GetTempFilesPrefix() + ".test";
                if (urlFileName.StartsWith(testLogFileNamePrefix))
                {
                    newLogType = LogTypes.TestLog;
                    this._lastTestId = urlFileName.Substring(testLogFileNamePrefix.Length);
                }
                else if (urlFileName.StartsWith(GetXmlLogFileName()))
                    newLogType = LogTypes.XmlOutput;
            }

            if (newLogType != this._logType)
            {
                this._logType = newLogType;

                if (this.NavigationChanged != null)
                    this.NavigationChanged(this, new NavigationChangedEventArgs(newLogType));
            }
        }

        private void _webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            OnNavigationChanged(e.Url);
        }

        private void TestResultsControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.XButton1)
                GoBack();
            else if (e.Button == MouseButtons.XButton2)
                GoForward();
        }

        #endregion
    }
}
