using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackClient;

namespace SlackClient.Test
{
    [TestClass]
    public class UnitTestIm
    {
        [TestMethod]
        public void TestMethodImList()
        {
            ImList ret = SlackClient.ImControler.List();
            Assert.IsTrue(ret.Ok);
        }
    }
}
