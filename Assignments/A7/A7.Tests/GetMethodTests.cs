﻿using System;
using A7;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace A7.Tests
{

    [TestClass]
    public class GetMethodTests
    {
        #region GetMethodTest
        [TestMethod]
        public void TestNoGetMethodException()
        {
            ExceptionHandler eh = new ExceptionHandler("test", false);
            Assert.AreEqual(eh.Input, "test");
            Assert.AreEqual(eh.ErrorMsg, null);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestThrowGetMethodException()
        {
            ExceptionHandler eh = new ExceptionHandler(null, false);
            Assert.AreEqual(eh.Input, null);
        }

        [TestMethod]
        public void TestCatchGetMethodException()
        {
            ExceptionHandler eh = new ExceptionHandler(null, false, true);
            Assert.AreEqual(eh.Input, null);
            Assert.AreEqual(
                "Caught exception in GetMethod",
                eh.ErrorMsg);
        }
        #endregion
    }
}