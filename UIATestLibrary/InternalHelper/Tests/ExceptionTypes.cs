// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Runtime.Serialization;

// This suppresses warnings #'s not recognized by the compiler.
#pragma warning disable 1634, 1691

namespace InternalHelper.Tests
{
	/// -----------------------------------------------------------------------
	/// <summary>
	/// Control is not configured for the desired test
	/// </summary>
	/// -----------------------------------------------------------------------
	[Serializable]
	internal class IncorrectElementConfigurationForTestException : ApplicationException
	{
        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public IncorrectElementConfigurationForTestException() : base() { }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public IncorrectElementConfigurationForTestException(string Reason) : base(Reason) { }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public IncorrectElementConfigurationForTestException(string Reason, Exception e) : base(Reason, e) { }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        protected IncorrectElementConfigurationForTestException(SerializationInfo serializationInfo, StreamingContext streamContext) : base(serializationInfo, streamContext) { }
	}

	/// -----------------------------------------------------------------------
	/// <summary>
	/// Warning that the test has a problem but cannot determine if this
	/// is an error.  Tester will need to determine if this scenario
	/// is a problem or not.
	/// </summary>
    /// -----------------------------------------------------------------------
    [Serializable]
	internal class TestWarningException : ApplicationException
	{
        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public TestWarningException() : base() { }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public TestWarningException(string Reason) : base(Reason) { }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public TestWarningException(string Reason, Exception e) : base(Reason, e) { }

		protected TestWarningException(SerializationInfo serializationInfo, StreamingContext streamContext) : base(serializationInfo, streamContext) { }
	}

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Error when the test fails according to the test plan
    /// </summary>
    /// -----------------------------------------------------------------------
    [Serializable]
    internal class TestErrorException : ApplicationException
    {
        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public TestErrorException() : base() { }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public TestErrorException(string Reason) : base(Reason) { }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public TestErrorException(string Reason, Exception e) : base(Reason, e) { }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        protected TestErrorException(SerializationInfo serializationInfo, StreamingContext streamContext) : base(serializationInfo, streamContext) { }
    }
}

