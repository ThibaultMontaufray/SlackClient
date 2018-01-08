using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackClient
{
    public class SlackAdapter
    {
        #region Attributes
        private List<SlackMessage> _currentMessages;
        private List<Channel> _channels;
        private List<Member> _users;
        private List<Token> _tokens;
        private Channel _currentChannel;
        private Team _team;
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
        public List<Token> Tokens
        {
            get { return _tokens; }
            set { _tokens = value; }
        }
        public List<SlackMessage> CurrentMessages
        {
            get { return _currentMessages; }
            set { _currentMessages = value; }
        }
        #endregion

        #region Constructor
        public SlackAdapter()
        {
            _channels = new List<Channel>();
            _users = new List<Member>();
            Init();
        }
        #endregion

        #region Methods public
        public void Init()
        {
            _channels = ChannelsControler.List();
            _users = UserControler.List();
            _team = TeamControler.Info();
            _currentMessages = new List<SlackMessage>();

            _tokens = new List<Token>();
            _tokens.Add(new Token() { IsUsed = true, Key = "AZERTY" });
            _tokens.Add(new Token() { IsUsed = false, Key = "testtesttest" });
        }
        public void SendMessage(string message)
        {
            if (_currentChannel != null)
            {
                SlackMessage lastMessage = _currentMessages.First();
                ConversationControler.Send(_currentChannel.Id, lastMessage.CurrentMessage.Ts, message);
            }
        }
        #endregion

        #region Methods private
        #endregion
    }
}
