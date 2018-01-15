using System;
using SlackClient;
using System.Collections.Generic;

namespace SlackClient.Test
{
    [TestClass]
    public class UnitTestChannels
    {
        [TestMethod]
        public void TestMethodChannelsList()
        {
            List<Channel> ret = SlackClient.ChannelsControler.List();
            Assert.IsTrue(ret.Count > 0);
            Assert.IsTrue(ret[0].Id != null);
        }
    }
}
