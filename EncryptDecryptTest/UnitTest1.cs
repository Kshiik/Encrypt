using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Encrypt;

namespace EncryptDecryptTest
{
    [TestClass]
    public class UnitTest1
    {
        string key = "HvaDpgEZ5oMin IIpsW7Q9kpHSnoltGzeCBgQA6HZg=";
        string IV = "MSDyyaDjwMmR6giMeyUpTA==";
        [TestMethod]
        public void TestMethod1()
        {
            string textString = "swhdfiuwehfiohf";

            string actual = ClassEncrypt.EncryptText(textString, key, IV);

            Assert.AreEqual(textString, actual);
        }
        [TestMethod]
        public void NegativeTest_EmptyString()
        {
            string textString = "";

            Action actual = () => ClassEncrypt.DecryptText(textString, key, IV);

            Assert.ThrowsException<ArgumentException>(actual);
        }
    }
}
