using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodePasswordDLL;
using System.Diagnostics;

namespace CodePasswordDll.Test
{
    [TestClass]
    public class CodePasswordTest
    {
        string str_abc;
        string str_bcd;

        [TestInitialize]
        public void TestInitialize()
        {
            Debug.WriteLine($"Test Initialize {DateTime.Now}");
            str_abc = "abc";
            str_bcd = "bcd";
        }

        [TestCleanup]
        public void Cleanup()
        {
            Debug.WriteLine($"Test Cleanup {DateTime.Now}");
        }

        [TestMethod]
        public void GetEncryptPassword_abc_bcd()
        {
            // act
            string strActual = CodePassword.EncryptPassword(str_abc);
            // assert
            Assert.AreEqual(str_bcd, strActual);

            Debug.WriteLine($"Первый тест пройден {DateTime.Now}");
        }

        [TestMethod]
        public void GetPassword_bcd_abc()
        {
            string strActual = CodePassword.GetPassword(str_bcd);
            Assert.AreEqual(str_abc, strActual);
            Debug.WriteLine($"Второй тест пройден {DateTime.Now}");
        }

    }
}
