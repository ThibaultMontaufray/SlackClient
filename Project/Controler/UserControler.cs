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
        public static Status GetStatus(Member user)
        {
            Status status = null;

            try
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("user", user.Id);
                string answer = Accessor.JsonPostFormData(URL + ".getPresence", data);
                Response response = Accessor.Deserialize<Response>(answer);
                if (response.Ok)
                {
                    status = Accessor.Deserialize<Status>(answer);
                }
            }
            catch
            {
            }

            return status;
        }
    }
}
