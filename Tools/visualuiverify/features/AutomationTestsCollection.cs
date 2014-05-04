//---------------------------------------------------------------------------
//
// <copyright file="AutomationTestsCollection" company="Microsoft">
// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.
// </copyright>
// 
//
// Description: Definition of AutomationTestsCollection which is collection of all available
//              tests.
//
// History:  
//  09/18/2006 : Ondrej Lehecka, created
//
//---------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using WUILib=Microsoft.Test.UIAutomation.TestManager;

namespace VisualUIAVerify.Features
{
    /// <summary>
    /// this class is collection of all available automation tests
    /// </summary>
    class AutomationTestCollection
    {
        private const string WUITestLibratyAssemblyName = "WUIATestLibrary";

        //we cache collection of all tests
        private static List<AutomationTest> _allTestsCache;

        #region Filter enumerator

        /// <summary>
        /// this class is used to enumerate thru the automation tests collection and returns all tests
        /// that fit into the filter
        /// </summary>
        class FilterEnumerator : IEnumerator<AutomationTest>, IEnumerable<AutomationTest>
        {
            //enumerator for all automation tests
            private IEnumerator<AutomationTest> _baseEnumerator;

            //filter to be applied
            private AutomationTestsFilter _filter;

            /// <summary>
            /// initializes new instance of filter enumerator
            /// </summary>
            public FilterEnumerator(IEnumerator<AutomationTest> baseEnumerator, AutomationTestsFilter filter)
            {
                this._baseEnumerator = baseEnumerator;
                this._filter = filter;
            }

            /// <summary>
            /// finds next item matching the filter
            /// </summary>
            private bool MoveToNextItemMatchingFilter()
            {
                while (this._baseEnumerator.MoveNext())
                {
                    if (this._filter.Fit(this._baseEnumerator.Current))
                        return true;
                }
                return false;
            }

            #region implementation of IEnumerator<AutomationTest>

            public AutomationTest Current
            {
                get { return this._baseEnumerator.Current; }
            }

            #endregion

            #region implementation of IDisposable

            public void Dispose()
            {
                this._baseEnumerator.Dispose();
            }

            #endregion

            #region implementation of IEnumerator

            object System.Collections.IEnumerator.Current
            {
                get { return this._baseEnumerator.Current; }
            }

            public bool MoveNext()
            {
                return MoveToNextItemMatchingFilter();
            }

            public void Reset()
            {
                this._baseEnumerator.Reset();
            }

            #endregion

            #region IEnumerable<AutomationTest> Members

            public IEnumerator<AutomationTest> GetEnumerator()
            {
                return this;
            }

            #endregion

            #region IEnumerable Members

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this;
            }

            #endregion
        }

        #endregion 

        public static IEnumerable<AutomationTest> Filter(AutomationTestsFilter filter)
        {
            PrepareTestCollection();

            return new FilterEnumerator(_allTestsCache.GetEnumerator(), filter);
        }

        public static void RefreshTests()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// this method creates the cache of all available automation tests.
        /// </summary>
        private static void PrepareTestCollection()
        {
            if (AutomationTestCollection._allTestsCache != null)
                return;

            //create the cache, expect 1500 tests
            AutomationTestCollection._allTestsCache = new List<AutomationTest>(1500);

            //this is unfortunately hard coded
            Assembly testAssembly = null;
            try
            {
                testAssembly = Assembly.Load(WUITestLibratyAssemblyName);
            }
            catch (Exception ex)
            {
                string message = "Cannon load assembly " + WUITestLibratyAssemblyName + " with automation tests.\n" +
                    "There will be no tests to run!";

                MessageBox.Show(message);

                Trace.Fail(message, ex.Message);
            }

            if(testAssembly != null)
            {
                Type[] mytypes = testAssembly.GetTypes();

                //go thru all types in library
                foreach (Type type in mytypes)
                {
                    //if the type has this field the assume this is the test class
                    FieldInfo suite = type.GetField("TestSuite");

                    if (suite != null)
                    {
                        string TestSuite = suite.GetValue(null) as string;

                        if (!string.IsNullOrEmpty(TestSuite))
                        {
                            //go thru all methods and if it has TestCaseAttribute then it is test method
                            foreach (MethodInfo method in type.GetMethods())
                            {
                                foreach (Attribute attr in method.GetCustomAttributes(true))
                                {
                                    if (attr is WUILib.TestCaseAttribute)
                                    {
                                        WUILib.TestCaseAttribute test = (WUILib.TestCaseAttribute)attr;
      
                                        if(test.Status == WUILib.TestStatus.Works &&
                                            (test.TestCaseType & WUILib.TestCaseType.Arguments) != WUILib.TestCaseType.Arguments)
                                        //TODO: sort items
                                        _allTestsCache.Add(new AutomationTest(test, method));
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
