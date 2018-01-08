using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackClient;
using System.Collections.Generic;

namespace SlackClient.Test
{
    [TestClass]
    public class UnitTestEmoji
    {
        [TestMethod]
        public void TestMethodEmojisList()
        {
            Emoji ret = SlackClient.EmojiControler.List();
            Assert.IsTrue(ret.Slack != null);
        }
    }
}
