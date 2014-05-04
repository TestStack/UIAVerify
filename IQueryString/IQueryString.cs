// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections.Generic;

// The namespace is retained as AccCheck.Verification because this interface definition was part of AccChecker initially
// Changing this namespace will have compilation errors all over
namespace AccCheck.Verification
{
    // If we can find an object with this interface in a dll with-in the current directory 
    // it will be used to generate strings used for suppressions that use language independent 
    // resources so that suppressions will work on UI that is in a different language then the 
    // suppressions were generated on.
    public interface IQueryString
    {
        // This method will create a string that will uniquely identify an element called a QueryString.   
        // This will work with MSAA or UIA.  MSAA clients will pass an IAccessible object and a child and 
        // UIA client will pass a IUIAutomationElement object and child id will be ignored.   This method
        // is used in the verification dll that deal with each of these accessible frameworks.
        string Generate(Object element, object childId);

        // This method will create a string that will uniquely identify an element called a QueryString.  From  
        // an hwnd.  It uses UIA to do this.
        string Generate(IntPtr hwnd);

        // This method takes a list of QueryStrings that came from one of the two methods above and a list 
        // of modules to search and return a list of QueryStrings that do not have any strings that are localized.
        // This allows these string to be used on builds of different languages.
        string[] Globalize(List<string> ids, List<string> loadedModules, out List<string> ambiguousResources);

        // Used to compare two different kids of QueryStrings
        bool Compare(string globalizedQueryString, string localQueryString);
    }
}

namespace QueryStringWrapper
{
    using AccCheck.Verification;
    /// -----------------------------------------------------------------------
    /// <summary>Properties that will be used by the UIUploaderUI and the UIUploader</summary>
    /// -----------------------------------------------------------------------
    public static class QueryString
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr GetDesktopWindow();

        static char QueryStringDelimiter = (char)177;
        static IQueryString _queryString;
        static LogSystemInformation _systemInformation = new LogSystemInformation();

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public static string[] Tokenized(string queryString)
        {
            return queryString.Split(new char[] { QueryStringDelimiter }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public static StringBuilder AppendChild(StringBuilder sbQs, string p)
        {
            return sbQs.Append(QueryStringDelimiter).Append(p);
        }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public static string Generate(object element, object childId, string processName)
        {
            return StandardizeQueryStringFromAccCheckerLog(QueryStringObject.Generate(element, childId), processName);
        }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public static string StandardizeQueryStringFromAccCheckerLog(string queryString, string processName)
        {
            if (string.IsNullOrEmpty(queryString))
                return string.Empty;

            StringBuilder sb = new StringBuilder(queryString);

            if (queryString[0] != QueryStringDelimiter)
            {
                // Get the token defined by RPF
                char t = queryString[0];

                // We need to parse the string, so determine all the tokens with the character added
                string[] tokens = new string[] { 
                        TokenMe(t, "Role"), 
                        TokenMe(t, "Name"), 
                        TokenMe(t, "AutomationId"), 
                        TokenMe(t, "ControlId"), 
                        TokenMe(t, "ClassName"), 
                        TokenMe(t, "ControlName")};

                // Replace with common delimiter
                foreach (string s in tokens)
                {
                    sb.Replace(s, s.Replace(t, QueryStringDelimiter));
                    sb.Replace('{', '[');
                    sb.Replace('}', ']');
                }
            }

            // Associate with process
            string[] elements = sb.ToString().Split(new char[] { QueryStringDelimiter }, StringSplitOptions.RemoveEmptyEntries);

            if (elements.Length > 1)
            {
                string[] element = elements[1].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int iName = elements[1].IndexOf("Name", 0);

                // Replace the Name with the processname for better identification of the unique elements
                if (iName > -1)
                {
                    int iStart = elements[1].IndexOf("'", iName) + 1;
                    int iEnd = elements[1].IndexOf("'", iStart);
                    elements[1] = elements[1].Substring(0, iStart) + processName + elements[1].Substring(iEnd);
                    sb = new StringBuilder(QueryStringDelimiter.ToString()).Append(string.Join(QueryStringDelimiter.ToString(), elements));
                }
            }
            return sb.ToString();
        }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        private static string TokenMe(char token, string p)
        {
            return string.Format("{0}{1}", token, p);
        }        

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public static string[] Globalize(List<string> queryStrings, List<string> list, out List<string> ambiguousResources)
        {
            return QueryString.QueryStringObject.Globalize(queryStrings, list, out ambiguousResources);
        }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public static string GlobalizeQueryString(List<string> loadedModules, string queryString)
        {
            string result = string.Empty;
            List<string> queryStrings = new List<string>();
            List<string> ambiguousResources;

            queryStrings.Add(queryString);

            try
            {
                if (loadedModules.Count > 0)
                {
                    string[] globalizedQueryStrings = QueryStringWrapper.QueryString.QueryStringObject.Globalize(queryStrings, loadedModules, out ambiguousResources);
                    result = globalizedQueryStrings.GetLength(0) > 0 ? globalizedQueryStrings[0] : string.Empty;
                }
            }
            catch (Exception error)
            {
                throw error;
            }

            return result;
        }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public static string BuildQueryString(string[] tokens, int index)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < index + 1; i++)
            {
                sb.AppendFormat("{0}{1}", QueryStringDelimiter, tokens[i]);
            }

            return sb.ToString();
        }

        /// -------------------------------------------------------------------
        /// <summary>Returns a IQueryString object, which provides functionality that allows us
        /// to generate a QueryString for a given element</summary>
        /// -------------------------------------------------------------------
        static IQueryString QueryStringObject
        {
            get
            {
                if (_queryString == null)
                {
                    String currentDirectory = Directory.GetCurrentDirectory();
                    string[] dlls = Directory.GetFiles(currentDirectory, "QueryString.dll", SearchOption.TopDirectoryOnly);

                    foreach (string filename in dlls)
                    {
                        try
                        {
                            Assembly assembly = Assembly.LoadFile(filename);
                            if (assembly != null)
                            {
                                foreach (Type type in assembly.GetTypes())
                                {
                                    if (type.GetInterface("IQueryString") != null)
                                    {
                                        _queryString = (IQueryString)Activator.CreateInstance(type);

                                        // this call is here to make the assembly pull in all its dependencies so if there are missing
                                        // dlls this will fallback gracefully
                                        _queryString.Generate(GetDesktopWindow());
                                        return _queryString;
                                    }
                                }
                            }
                        }
                        catch (ArgumentException)
                        {
                            // LoadFile fails to load some
                        }
                        catch (Exception error)
                        {
                            Debug.Assert(false, error.Message);
                        }
                    }
                }

                return _queryString;
            }
        }

        /// <summary>
        /// Returns a LogSystemInformation object, which provides all the system information
        /// </summary>        
        public static LogSystemInformation LogSystemInformationObject
        {
            get
            {
                return _systemInformation;
            }
        }

    }
}
