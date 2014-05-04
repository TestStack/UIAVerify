//---------------------------------------------------------------------------
//
// <copyright file="Program.cs" company="Microsoft">
// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.
// </copyright>
// 
//
//---------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using Microsoft.Test.UIAutomation;
using Microsoft.Test.UIAutomation.Core;
using Microsoft.Test.UIAutomation.TestManager;
using Microsoft.Test.UIAutomation.Tests.Controls;
using Microsoft.Test.UIAutomation.Tests.Patterns;
using Microsoft.Test.UIAutomation.Logging;

namespace SampleDriver
{
    public sealed class TestMain
    {

        /// -------------------------------------------------------------------
        /// <summary>
        /// This sample will start up Notepad and run UI Automation tests on it
        /// </summary>
        /// -------------------------------------------------------------------
        [STAThread]
        static void Main(string[] args)
        {
            // Dump the info to the console window.  Use a different LogTypes if
            // you need to dump to another logger, of create your own that complies 
            // to the interface.
            UIVerifyLogger.SetLogger(LogTypes.ConsoleLogger);

            // Get the automation element you want to test
            AutomationElement element = StartApplication("NOTEPAD.EXE", null);

            // Call the UI Automation Verify tests
            TestRuns.RunAllTests(element, true, TestPriorities.Pri0, TestCaseType.Generic, false, true, null);

            // Clean up
            ((WindowPattern)element.GetCurrentPattern(WindowPattern.Pattern)).Close();

            // Dumps the summary of results
            UIVerifyLogger.ReportResults();
        }

        /// -------------------------------------------------------------------------
        /// <summary>
        /// Start the application and retrieve it's AutomationElement 
        /// </summary>
        /// -------------------------------------------------------------------------
        static public AutomationElement StartApplication(string appPath, string arguments)
        {
            int MAXTIME = 5000; //   Total length in milliseconds to wait for the application to start
            int TIMEWAIT = 100; //   Timespan to wait till trying to find the window

            Process process;

            Library.ValidateArgumentNonNull(appPath, "appPath");

            ProcessStartInfo psi = new ProcessStartInfo();

            process = new Process();
            psi.FileName = appPath;

            if (arguments != null)
            {
                psi.Arguments = arguments;
            }

            UIVerifyLogger.LogComment("Starting({0})", appPath);
            process.StartInfo = psi;

            process.Start();

            // this is for piper, but is a nop for others such as wtt
            UIVerifyLogger.MonitorProcess(process);

            int runningTime = 0;
            while (process.MainWindowHandle.Equals(IntPtr.Zero))
            {
                if (runningTime > MAXTIME)
                    throw new Exception("Could not find " + appPath);

                Thread.Sleep(TIMEWAIT);
                runningTime += TIMEWAIT;

                process.Refresh();
            }

            UIVerifyLogger.LogComment("{0} started", appPath);

            UIVerifyLogger.LogComment("Obtained an AutomationElement for {0}", appPath);
            return AutomationElement.FromHandle(process.MainWindowHandle);

        }
    }
}