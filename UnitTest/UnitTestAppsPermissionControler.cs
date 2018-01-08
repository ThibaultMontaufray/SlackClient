using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackClient;

namespace SlackClient.Test
{
    [TestClass]
    public class UnitTestAppsPermissionControler
    {
        [TestMethod]
        public void TestPermissionGetInfo()
        {
            var ret = SlackClient.Apps.PermissionControler.GetInfo();
            Assert.IsNotNull(ret);
        }
    }
}
