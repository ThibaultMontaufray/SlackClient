using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackClient;

namespace SlackClient.Test
{
    [TestClass]
    public class UnitTestApiTestControler
    {
        [TestMethod]
        public void TestMethod1()
        {
            bool ret = SlackClient.Api.TestControler.TestSuccess();
            Assert.IsTrue(ret);
        }
    }
}
