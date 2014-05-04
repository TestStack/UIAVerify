// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Microsoft.Test.UIAutomation.Logging
{
    using Microsoft.Test.UIAutomation.Logging.XmlSerializableObjects;

    public static class XmlLog
    {
        private static XmlTestRun _lastTestRun;
        private static XmlTest _lastTest;

        /// <summary>
        /// for generating unique testIds
        /// </summary>
        private static int _nextTestId;

        public static IEnumerable<XmlTest> Tests
        {
            get { return _lastTestRun.Tests; }
        }

        internal static XmlTestRun CurrentTestRun
        {
            get
            {
                if (_lastTestRun == null)
                    _lastTestRun = new XmlTestRun();

                return _lastTestRun;
            }
        }

        internal static XmlTest CurrentTest
        {
            get
            {
                if (_lastTest == null)
                    StartNewTest();

                return _lastTest;
            }
        }

        internal static void StartNewTest()
        {
            _lastTest = new XmlTest();
            CurrentTestRun.AddTest(_lastTest);
        }

        public static void GetTestRunXml(XmlWriter writer)
        {
            new XmlSerializer(typeof(XmlTestRun)).Serialize(writer, CurrentTestRun);
        }

        public static void ClearTestRunLog()
        {
            _lastTestRun = null;
            _lastTest = null;
            _nextTestId = 0;
        }

        internal static string GetUniqueTestId()
        {
            return (++_nextTestId).ToString();
        }
    }
}
