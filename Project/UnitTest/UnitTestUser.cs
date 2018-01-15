using System;
using SlackClient;
using System.Collections.Generic;

namespace SlackClient.Test
{
    [TestClass]
    public class UnitTestUser
    {
        [TestMethod]
        public void TestMethodUserList()
        {
            List<Member> ret = SlackClient.UserControler.List();
            Assert.IsTrue(ret.Count > 0);
            Assert.IsTrue(ret[0] != null);
        }
    }
}
