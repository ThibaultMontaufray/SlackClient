using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackClient.Api
{
    public static class TestControler
    {
        private const string URL = "https://slack.com/api/api.test";

        public static bool TestSuccess()
        {
            bool ret = false;

            try
            {
                string answer = Accessor.JsonGet(URL);
                Response response = Accessor.Deserialize<Response>(answer);
                ret = response.Ok;
            }
            catch
            {

            }

            return ret;
        }
    }
}
