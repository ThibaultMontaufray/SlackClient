using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackClient
{
    public class ConversationControler
    {
        private const string URL = "https://slack.com/api/conversations";

        public static Conversation History(SlackAdapter sa, string channel)
        {
            Conversation conversation = null;

            try
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("channel", channel);
                string answer = Accessor.JsonPostFormData(sa, URL + ".history", data);
                Response response = Accessor.Deserialize<Response>(answer);
                if (response.Ok)
                {
                    conversation = Accessor.Deserialize<Conversation>(answer);
                }
            }
            catch (Exception exp)
            {
            }

            return conversation;
        }
    }
}
