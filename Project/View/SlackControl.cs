using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlackClient
{
    public partial class SlackControl : UserControl
    {
        #region Attributes
        private SlackAdapter _slackAdapter;
        #endregion

        #region Properties
        public SlackAdapter SlackAdapter
        {
            get { return _slackAdapter; }
            set { _slackAdapter = value; }
        }
        #endregion

        #region Constructor
        public SlackControl()
        {
            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        public void LoadData()
        {
            _slackMenu.LoadData(_slackAdapter);
        }
        #endregion

        #region Methods private
        private void Init()
        {
            _slackAdapter = new SlackAdapter();
            _slackMenu.LoadData(_slackAdapter);
            _slackMenu.OnChannelChanged += _slackMenu_OnChannelChanged;
            _slackMenu.OnUserChanged += _slackMenu_OnUserChanged;
            _slackInput.OnMessageSendingRequest += _slackInput_OnMessageSendingRequest;
            
            if (_slackAdapter.Channels.Count > 0)
            {
                Channel defaultChannel = _slackAdapter.Channels.Where(c => c.Name.ToLower().Equals("general")).Count() > 0 ? _slackAdapter.Channels.Where(c => c.Name.ToLower().Equals("general")).FirstOrDefault() : _slackAdapter.Channels.FirstOrDefault();
                RefreshConversation(defaultChannel);
            }
        }
        private void RefreshConversation(Channel channel)
        {
            _slackConversation.LoadConversation(_slackAdapter, channel.Id);
            _slackAdapter.CurrentChannel = channel;
        }
        #endregion

        #region Event
        private void _slackMenu_OnUserChanged(object o)
        {
            //_slackConversation.LoadConversation(_slackAdapter, "");
        }
        private void _slackMenu_OnChannelChanged(object o)
        {
            Channel channel = (Channel)o;
            RefreshConversation(channel);
        }
        private void _slackInput_OnMessageSendingRequest(object o)
        {
            _slackAdapter.SendMessage((string)o);
        }
        #endregion
    }
}
