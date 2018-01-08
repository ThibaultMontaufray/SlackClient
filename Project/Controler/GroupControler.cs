using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackClient
{
    public class GroupControler
    {
        private const string URL = "https://slack.com/api/groups";

        public static List<Group> List()
        {
            GroupList groups = null;

            try
            {
                string answer = Accessor.JsonPostFormData(URL + ".list");
                Response response = Accessor.Deserialize<Response>(answer);
                if (response.Ok)
                {
                    groups = Accessor.Deserialize<GroupList>(answer);
                }
            }
            catch
            {
            }

            return groups == null ? null : groups.Groups;
        }
    }
}
