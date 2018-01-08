using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackClient
{
    public class RtmControler
    {
        #region Attributes
        private const string URL = "https://slack.com/api/rtm";
        #endregion

        #region Properties
        #endregion

        #region Methods public
        public static Rtm Connect()
        {
            Rtm rtm = null;

            try
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("batch_presence_aware", "1");
                
                string answer = Accessor.JsonPostFormData(URL + ".connect", data);
                Response response = Accessor.Deserialize<Response>(answer);
                if (response.Ok)
                {
                    rtm = Accessor.Deserialize<Rtm>(answer);
                }
            }
            catch
            {
            }

            return rtm == null ? null : rtm;
        }
        public static Rtm Start()
        {
            Rtm rtm = null;

            try
            {
                string answer = Accessor.JsonPostFormData(URL + ".start");
                Response response = Accessor.Deserialize<Response>(answer);
                if (response.Ok)
                {
                    rtm = Accessor.Deserialize<Rtm>(answer);
                }
            }
            catch
            {
            }

            return rtm == null ? null : rtm;
        }
        #endregion

        #region Methods private
        #endregion

        #region Event
        #endregion
    }
}
