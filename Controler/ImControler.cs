using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackClient
{
    public class ImControler
    {
        private const string URL = "https://slack.com/api/im";

        public static ImList List()
        {
            ImList ims = null;

            try
            {
                string answer = Accessor.JsonPostFormData(URL + ".list");
                Response response = Accessor.Deserialize<Response>(answer);
                if (response.Ok)
                {
                    ims = Accessor.Deserialize<ImList>(answer);
                }
            }
            catch
            {
            }

            return ims;
        }
    }
}
