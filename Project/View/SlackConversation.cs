using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools4Libraries;

namespace SlackClient
{
    public partial class SlackConversation : PanelScrollable
    {
        #region Attributes
        private Conversation _currentConversation;
        private SlackAdapter _slackAdapter;
        #endregion

        #region Properties
        public SlackAdapter SlackAdapter
        {
            get { return _slackAdapter; }
            set { _slackAdapter = value; }
        }
        public Conversation CurrentConversation
        {
            get { return _currentConversation; }
            set { _currentConversation = value; }
        }
        #endregion

        #region Constructor
        public SlackConversation()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods public
        public async void LoadConversation(SlackAdapter slackAdapter, string conversation)
        {
            _slackAdapter = slackAdapter;
            _slackAdapter.OnMessagesUpdated += _slackAdapter_OnMessagesUpdated;
            _currentConversation = ConversationControler.History(conversation);
            this.Controls.Clear();
            this.BackColor = Color.WhiteSmoke;

            LoadData();
            //Task t = new Task(LoadData);
            //t.Start();
            // await t; // TODO : add async way to do it
            BuildMessagesInterface();
        }
        #endregion

        #region Methods private
        private void LoadData()
        {
            this.Width = 10;
            this.Height = 10;
            _slackAdapter.CurrentMessages.Clear();
            SlackMessage slackMessage;
            if (_currentConversation != null)
            {
                foreach (var item in _currentConversation.Messages.OrderByDescending(m => m.Ts).Take(25))
                {
                    slackMessage = new SlackMessage();
                    slackMessage.LoadMessage(_slackAdapter, item);
                    slackMessage.Dock = DockStyle.Top;
                    //this.Controls.Add(slackMessage);
                    _slackAdapter.CurrentMessages.Add(slackMessage);
                }
            }
        }
        private void BuildMessagesInterface()
        {
            foreach (SlackMessage control in _slackAdapter.CurrentMessages)
            {
                this.Controls.Add(control);
            }
            if (_slackAdapter.CurrentMessages.Count > 0)
            { 
                _slackAdapter.CurrentMessages[0].Select();
                this.ScrollToControl(_slackAdapter.CurrentMessages[0]);
            }
        }
        private void ParseMessage(Message msg)
        {
            if (msg.Channel == _currentConversation.Messages.FirstOrDefault().Channel)
            {
                _currentConversation.Messages.Add(msg);

                SlackMessage slackMessage = new SlackMessage();
                slackMessage.LoadMessage(_slackAdapter, msg);
                slackMessage.Dock = DockStyle.Top;
                this.Controls.Add(slackMessage);
                _slackAdapter.CurrentMessages.Add(slackMessage);
            }
        }
        #endregion

        #region Event
        private void _slackAdapter_OnMessagesUpdated(object o)
        {
            ParseMessage((Message)o);
        }
        #endregion
    }
}
