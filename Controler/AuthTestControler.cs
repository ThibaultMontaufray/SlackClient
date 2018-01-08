using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackClient.Auth
{
    public class TestControler
    {
        private const string URL = "https://slack.com/api/auth.test";

        public static Authorisation Get()
        {
            Authorisation auth = null;

            try
            {
                string answer = Accessor.JsonPostFormData(URL);
                Response response = Accessor.Deserialize<Response>(answer);
                if (response.Ok)
                {
                    auth = Accessor.Deserialize<Authorisation>(answer);
                }
            }
            catch
            {
            }

            return auth;
        }
    }
}
