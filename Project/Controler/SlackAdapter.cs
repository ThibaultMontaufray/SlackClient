using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackClient
{
    public class SlackAdapter
    {
        #region Attributes
        public static Token CurrentToken;

        private List<SlackMessage> _currentMessages;
        private List<Channel> _channels;
        private List<Member> _users;
        private Channel _currentChannel;
        private Team _team;
        private SlackRtm _slackRtm;
        #endregion

        #region Properties
        public List<Member> Users
        {
            get { return _users; }
            set { _users = value; }
        }
        public List<Channel> Channels
        {
            get { return _channels; }
            set { _channels = value; }
        }
        public Team Team
        {
            get { return _team; }
            set { _team = value; }
        }
        public Channel CurrentChannel
        {
            get { return _currentChannel; }
            set { _currentChannel = value; }
        }
        public List<SlackMessage> CurrentMessages
        {
            get { return _currentMessages; }
            set { _currentMessages = value; }
        }
        public SlackRtm SlackRtm
        {
            get { return _slackRtm; }
            set { _slackRtm = value; }
        }
        #endregion

        #region Constructor
        public SlackAdapter()
        {
            Init();
        }
        #endregion

        #region Methods public
        public void Init()
        {
            _channels = new List<Channel>();
            _users = new List<Member>();
            _currentMessages = new List<SlackMessage>();

            _slackRtm = new SlackRtm();
            _slackRtm.OnEvent += Instance_OnEvent1;
            _slackRtm.OnAck += Instance_OnAck;

            LoadData();
        }
        public void LoadData()
        {
            _channels = ChannelsControler.List();
            _users = UserControler.List();
            _team = TeamControler.Info();

            InitRtm();
        }
        public void InitRtm()
        {
            if (_slackRtm != null)
            {
                _slackRtm.OnEvent -= Instance_OnEvent1;
                _slackRtm.OnAck -= Instance_OnAck;
            }

            _slackRtm = new SlackRtm(SlackAdapter.CurrentToken.Key);
            _slackRtm.OnEvent += Instance_OnEvent1;
            _slackRtm.OnAck += Instance_OnAck;
            _slackRtm.Connect();
        }
        public void SendMessage(string message)
        {
            if (_currentChannel != null)
            {
                SlackMessage lastMessage = _currentMessages.First();
                _slackRtm.SendMessage(_currentChannel, message, null);
            }
        }
        #endregion

        #region Methods private
        #endregion

        #region Event
        private static void Instance_OnAck(object sender, SlackEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("log.txt", true))
            {
                sw.WriteLine(string.Format("{0} Ack : {1}", DateTime.Now, e.Data.ToJson()));
            }
        }
        private static void Instance_OnEvent1(object sender, SlackEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("log.txt", true))
            {
                sw.WriteLine(string.Format("{0} Event : {1}", DateTime.Now, e.Data.ToJson()));
            }
        }
        #endregion
    }
}
