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
        public void LoadConversation(SlackAdapter slackAdapter, string conversation)
        {
            _slackAdapter = slackAdapter;
            _currentConversation = ConversationControler.History(conversation);
            this.Controls.Clear();
            this.BackColor = Color.WhiteSmoke;

            LoadData();
        }
        #endregion

        #region Methods private
        private void LoadData()
        {
            _slackAdapter.CurrentMessages.Clear();
            SlackMessage slackMessage;
            if (_currentConversation != null)
            {
                foreach (var item in _currentConversation.Messages.OrderByDescending(m => m.Ts).Take(25))
                {
                    slackMessage = new SlackMessage();
                    slackMessage.LoadMessage(_slackAdapter, item);
                    slackMessage.Dock = DockStyle.Top;
                    this.Controls.Add(slackMessage);
                    _slackAdapter.CurrentMessages.Add(slackMessage);
                }
            }
        }
        #endregion
    }
}
