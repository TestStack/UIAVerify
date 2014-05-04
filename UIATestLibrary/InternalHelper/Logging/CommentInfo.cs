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
    public class CommentInfo
    {
        string _comment;

        public CommentInfo(string comment)
        {
            this._comment = comment;
        }

        public override string ToString()
        {
            return this._comment;
        }
    }
}
