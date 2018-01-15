using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SlackClient
{
    public partial class SlackMessage : UserControl
    {
        #region Attributes
        private Message _currentMessage;
        private Member _currentMember;
        private SlackAdapter _slackAdapter;
        #endregion

        #region Properties
        public Member CurrentMember
        {
            get { return _currentMember; }
            set { _currentMember = value; }
        }
        public SlackAdapter SlackAdapter
        {
            get { return _slackAdapter; }
            set { _slackAdapter = value; }
        }
        public Message CurrentMessage
        {
            get { return _currentMessage; }
            set { _currentMessage = value; }
        }
        #endregion

        #region Constructor
        public SlackMessage()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods public
        public void LoadMessage(SlackAdapter slackAdapter, Message message)
        {
            _currentMessage = message;
            _slackAdapter = slackAdapter;
            if (message.User != null)
            {
                _currentMember = _slackAdapter.Users.Where(s => s.Id.Equals(message.User)).First();
                pictureBox1.Load(_currentMember.Profile.Image_48);
                labelName.Text = _currentMember.Name;
            }
            if (_currentMessage != null)
            {
                System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddSeconds(double.Parse(_currentMessage.Ts.Replace('.', ','))).ToLocalTime();
                labelDate.Text = dtDateTime.ToString("hh:mm tt");
                _textBox.Text = CleanText(_currentMessage.Text);
            }
        }
        #endregion

        #region Methods private
        private string CleanText(string text)
        {
            if (!string.IsNullOrEmpty(text) && Regex.IsMatch(text, "<(.*?)>"))
            {
                foreach (var item in Regex.Matches(text, "<http(.*?)>"))
                {
                    text = text.Replace(item.ToString(), item.ToString().Substring(1, item.ToString().Length - 2));
                }
                foreach (var item in Regex.Matches(text, "<(.*?)>"))
                {
                    foreach (var user in _slackAdapter.Users)
                    {
                        text = text.Replace(string.Format("<@{0}>", user.Id), string.Format("@{0}", user.Name));
                    }
                }
            }
            text = text.Replace("<!channel>", "@Channel");
            return text;
        }
        #endregion
    }
}
