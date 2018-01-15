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
        private void Init()
        {
            //const { RtmClient, CLIENT_EVENTS } = require('@slack/client');

            //// An access token (from your Slack app or custom integration - usually xoxb)
            //const token = process.env.SLACK_TOKEN;

            //// Cache of data
            //const appData = { };

            //// Initialize the RTM client with the recommended settings. Using the defaults for these
            //// settings is deprecated.
            //const rtm = new RtmClient(token, {
            //  dataStore: false,
            //  useRtmConnect: true,
            //});

            //// The client will emit an RTM.AUTHENTICATED event on when the connection data is avaiable
            //// (before the connection is open)
            //rtm.on(CLIENT_EVENTS.RTM.AUTHENTICATED, (connectData) => {
            //  // Cache the data necessary for this app in memory
            //  appData.selfId = connectData.self.id;
            //  console.log(`Logged in as ${appData.selfId
            //    }
            //    of team ${connectData.team.id
            //}`);
            //});

            //// The client will emit an RTM.RTM_CONNECTION_OPEN the connection is ready for
            //// sending and recieving messages
            //rtm.on(CLIENT_EVENTS.RTM.RTM_CONNECTION_OPEN, () => {
            //  console.log(`Ready`);
            //});

            //// Start the connecting process
            //rtm.start();
        }
        #endregion

        #region Event
        #endregion
    }
}
