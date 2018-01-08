using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackClient;
using System.Collections.Generic;

namespace SlackClient.Test
{
    [TestClass]
    public class UnitTestGroup
    {
        [TestMethod]
        public void TestMethodGroupList()
        {
            List<Group> ret = SlackClient.GroupControler.List();
            Assert.IsTrue(ret.Count > 0);
            Assert.IsTrue(ret[0].Id != null);
        }
    }
}
