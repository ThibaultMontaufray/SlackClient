using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackClient
{
    public class UserControler
    {
        private const string URL = "https://slack.com/api/users";

        public static List<Member> List()
        {
            Users users = null;

            try
            {
                string answer = Accessor.JsonPostFormData(URL + ".list");
                Response response = Accessor.Deserialize<Response>(answer);
                if (response.Ok)
                {
                    users = Accessor.Deserialize<Users>(answer);
                }
            }
            catch
            {
            }

            return users == null ? null : users.Members;
        }
    }
}
