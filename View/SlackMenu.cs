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
    public delegate void SlackMenuEventHandler(object o);
    public partial class SlackMenu : UserControl
    {
        #region Attributes
        public event SlackMenuEventHandler OnChannelChanged;
        public event SlackMenuEventHandler OnUserChanged;
        private SlackAdapter _slackAdapter;
        #endregion

        #region Properties
        public SlackAdapter SlackAdapter
        {
            get { return _slackAdapter; }
            set { _slackAdapter = value; }
        }
        #endregion

        #region Construction
        public SlackMenu()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods public
        public void LoadData(SlackAdapter slackAdapter)
        {
            _slackAdapter = slackAdapter;
            LoadChannels();
            LoadUsers();
            LoadInfo();
        }
        #endregion

        #region Methods private
        private void LoadChannels()
        {
            TreeNode tn;
            panelChannels.Height = 30;
            _treeViewChannels.Nodes.Clear();
            if (SlackAdapter.Channels != null)
            { 
                TreeNode root = _treeViewChannels.Nodes.Add("Channels");
                foreach (Channel item in SlackAdapter.Channels)
                {
                    tn = new TreeNode(item.Name);
                    tn.Tag = item;
                    root.Nodes.Add(tn);
                    panelChannels.Height += 20;
                }
                root.ExpandAll();
            }
        }
        private void LoadUsers()
        {
            TreeNode tn;
            panelUsers.Height = 30;
            _treeViewUsers.Nodes.Clear();
            if (SlackAdapter.Users != null)
            { 
                TreeNode root = _treeViewUsers.Nodes.Add("Members");
                foreach (Member item in SlackAdapter.Users)
                {
                    tn = new TreeNode(item.Name);
                    tn.Tag = item;
                    root.Nodes.Add(tn);
                    panelUsers.Height += 20;
                }
                root.ExpandAll();
            }
        }
        private void LoadInfo()
        {
            if (_slackAdapter.Team != null)
            { 
                labelTitle.Text = _slackAdapter.Team.Name;
                pictureBoxIcon.Load(_slackAdapter.Team.Icon.Image_34);
            }
            else
            {
                labelTitle.Text = "Slack";
                pictureBoxIcon.Image = null;
            }
        }
        #endregion

        #region Event
        private void _treeViewChannels_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            OnChannelChanged?.Invoke(e.Node.Tag);
        }
        private void _treeViewUsers_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            OnUserChanged?.Invoke(e.Node.Tag);
        }
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            SlackSettings ss = new SlackSettings();
            ss.StartPosition = FormStartPosition.Manual;
            ss.Top = this.ParentForm.Top + buttonSettings.Top + buttonSettings.Height + 30;
            ss.Left = this.ParentForm.Left + buttonSettings.Left;
            ss.LoadData(_slackAdapter);

            ss.ShowDialog();
        }
        #endregion
    }
}
