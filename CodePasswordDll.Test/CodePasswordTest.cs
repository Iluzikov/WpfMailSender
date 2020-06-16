using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodePasswordDLL;
namespace CodePasswordDll.Test
{
    [TestClass]
    public class CodePasswordTest
    {
        [TestMethod]
        public void GetCodePassword_abc_bcd()
        {
            // arrange
            string strIn = "abc";
            string strExpected = "bcd";

            // act
            string strActual = CodePassword.EncryptPassword(strIn);

            // assert
            Assert.AreEqual(strExpected, strActual);
        }
    }
}
