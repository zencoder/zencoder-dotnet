using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZencoderDotNet;

namespace ZencoderDotNetTest
{
    [TestClass]
    public class ZencoderTest
    {
        [TestMethod]
        public void TestSetApiKey()
        {
            Zencoder.api_key = "123";
            Assert.AreEqual("123", Zencoder.api_key);
        }

        [TestMethod]
        public void TestGetApiKeyFromEnv()
        {
            Zencoder.api_key = null;
            Environment.SetEnvironmentVariable("ZENCODER_API_KEY", "321");
            Assert.AreEqual("321", Zencoder.api_key);
        }

        [TestMethod]
        public void TestUserSuppliedApiKeyTakesPrecedenceOverEnv()
        {
            Zencoder.api_key = "123";
            Environment.SetEnvironmentVariable("ZENCODER_API_KEY", "321");
            Assert.AreEqual("123", Zencoder.api_key);
        }
    }
}
