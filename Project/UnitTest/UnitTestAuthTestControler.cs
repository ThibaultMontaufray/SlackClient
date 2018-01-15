using System;
using SlackClient;

namespace SlackClient.Test
{
    [TestClass]
    public class UnitTestAuthTestControler
    {
        [TestMethod]
        public void TestMethod1()
        {
            Authorisation ret = SlackClient.Auth.TestControler.Get();
            Assert.IsTrue(ret.Ok);
        }
    }
}
