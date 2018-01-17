using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackClient
{
    public delegate void SlackAdapterEventHandler(object o);
    public class SlackAdapter
    {
        #region Attributes
        public const string LOGFILE = "log.txt";
        public event SlackAdapterEventHandler OnMessagesUpdated;

        private Token _currentToken;
        private List<SlackMessage> _currentMessages;
        private List<Channel> _channels;
        private List<Member> _users;
        private Channel _currentChannel;
        private Team _team;
        private SlackRtm _slackRtm;
        private Member _currentUser;
        #endregion

        #region Properties
        public List<Member> Users
        {
            get { return _users; }
            set { _users = value; }
        }
        public Token CurrentToken
        {
            get { return _currentToken; }
            set
            {
                _currentToken = value;
                Init();
            }
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
        public Member CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }
        #endregion

        #region Constructor
        public SlackAdapter()
        {
        }
        #endregion

        #region Methods public
        public void LoadData()
        {
            _channels = ChannelsControler.List(this);
            _channels.AddRange(GroupControler.List(this));
            _channels.AddRange(ImControler.List(this));
            _users = UserControler.List(this);
            _team = TeamControler.Info(this);

            InitRtm();
        }
        public void InitRtm()
        {
            if (_slackRtm != null)
            {
                _slackRtm.OnEvent -= Instance_OnEvent1;
                _slackRtm.OnAck -= Instance_OnAck;
            }

            if (_currentToken != null)
            { 
                _slackRtm = new SlackRtm(_currentToken.Key);
                _slackRtm.OnEvent += Instance_OnEvent1;
                _slackRtm.OnAck += Instance_OnAck;
                _slackRtm.Connect();
            }
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
        private void Init()
        {
            _currentUser = UserControler.GetProfile(this);
            _channels = new List<Channel>();
            _users = new List<Member>();
            _currentMessages = new List<SlackMessage>();

            _slackRtm = new SlackRtm();
            _slackRtm.OnEvent += Instance_OnEvent1;
            _slackRtm.OnAck += Instance_OnAck;

            LoadData();
        }
        private void ProcessEvent(SlackEventArgs eventArg)
        {
            ProcessEventLog(eventArg);
            switch (eventArg.Data.Type)
            {
                case "message":
                    ProcessEventMessage(Accessor.Deserialize<Message>(eventArg.Data.ToJson()));
                    break;
                case "hello":
                    break;
                case "reconnect_url":
                    break;
                case "channel_marked":
                    break;
                case "error":
                    break;
                case "user_typing":
                    break;
                default:
                    break;
            }
        }
        private void ProcessEventLog(SlackEventArgs eventArg)
        {
            if (System.IO.File.Exists(LOGFILE))
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(LOGFILE);
                if (fi.Length > 100000)
                {
                    if (System.IO.File.Exists(LOGFILE + ".backup"))
                    {
                        System.IO.File.Delete(LOGFILE + ".backup");
                    }
                    System.IO.File.Move(LOGFILE, LOGFILE + ".backup");
                }
            }
            using (StreamWriter sw = new StreamWriter(LOGFILE, true))
            {
                sw.WriteLine(string.Format("{0} Event : {1} [{2}]", DateTime.Now, eventArg.Data.ToJson()), eventArg.Data.ToString());
            }
        }
        private void ProcessEventMessage(Message msg)
        {
            if (_currentChannel.Id == msg.Channel)
            { 
                SlackMessage smsg = new SlackMessage();
                smsg.LoadMessage(this, msg);
                _currentMessages.Add(smsg);
                OnMessagesUpdated?.Invoke(msg);
            }
        }
        #endregion

        #region Event
        private void Instance_OnAck(object sender, SlackEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("log.txt", true))
            {
                sw.WriteLine(string.Format("{0} Ack : {1}", DateTime.Now, e.Data.ToJson()));
            }
        }
        private void Instance_OnEvent1(object sender, SlackEventArgs e)
        {
            ProcessEvent(e);
        }
        #endregion
    }
}
