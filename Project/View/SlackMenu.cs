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
        public event SlackMenuEventHandler OnChannelsLoaded;
        public event SlackMenuEventHandler OnUsersLoaded;
        public event SlackMenuEventHandler OnInfoLoaded;
        private SlackAdapter _slackAdapter;

        private TreeView _tmpTnChannels;
        private TreeView _tmpTnUsers;
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
            Init();
        }
        #endregion

        #region Methods public
        public async void LoadData(SlackAdapter slackAdapter)
        {
            try
            {
                _slackAdapter = slackAdapter;

                Task tInfo = new Task(LoadInfo);
                tInfo.Start();
                await tInfo;
                OnInfoLoaded?.Invoke(null);

                Task tChannels = new Task(LoadChannels);
                tChannels.Start();
                await tChannels;
                OnChannelsLoaded?.Invoke(null);

                Task tUsers = new Task(LoadUsers);
                tUsers.Start();
                await tUsers;
                OnUsersLoaded?.Invoke(null);
            }
            catch (Exception exp)
            {

            }
        }
        #endregion

        #region Methods private
        private void Init()
        {
            OnChannelsLoaded += _slackMenu_OnChannelsLoaded;
            OnInfoLoaded += _slackMenu_OnInfoLoaded;
            OnUsersLoaded += _slackMenu_OnUsersLoaded;
        }
        private void LoadChannels()
        {
            try
            {
                TreeNode tn;
                if (_tmpTnChannels == null) { _tmpTnChannels = new TreeView(); }
                _tmpTnChannels.Nodes.Clear();
                if (SlackAdapter.Channels != null)
                {
                    TreeNode root = _tmpTnChannels.Nodes.Add("Channels");
                    foreach (Channel item in SlackAdapter.Channels.Where(c => !c.Is_Archived && c.Is_Member))
                    {
                        tn = new TreeNode(item.Name);
                        tn.Tag = item;
                        root.Nodes.Add(tn);
                    }
                }
            }
            catch (Exception exp)
            {

            }
        }
        private void LoadUsers()
        {
            try
            {
                Status connected;
                TreeNode tn;
                if (_tmpTnUsers == null) { _tmpTnUsers = new TreeView(); }
                _tmpTnUsers.Nodes.Clear();
                if (SlackAdapter.Users != null)
                {
                    TreeNode root = _tmpTnUsers.Nodes.Add("Members");
                    foreach (Member item in SlackAdapter.Users)
                    {
                        connected = UserControler.GetStatus(item);
                        tn = new TreeNode(item.Name);
                        tn.Tag = item;
                        switch (connected.Presence)
                        {
                            case "active":
                                tn.ImageKey = connected.Last_Activity == null ? "connected" : "unactive";
                                break;
                            case "away":
                                tn.ImageKey = "disconnected";
                                break;
                            default:
                                tn.ImageKey = "unknow";
                                break;
                        }
                        tn.ImageIndex = imageListStatus.Images.IndexOfKey(tn.ImageKey);
                        root.Nodes.Add(tn);
                    }
                    root.ExpandAll();
                }
            }
            catch (Exception exp)
            {

            }
        }
        private void LoadInfo()
        {
            try
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
            catch (Exception exp)
            {

            }
        }
        private void UpdateTreeNodeUsers()
        {
            Copy(_tmpTnUsers, _treeViewUsers);
            _treeViewUsers.ExpandAll();
            panelUsers.Height = 30 + _treeViewUsers.Nodes[0].Nodes.Count * 20;
            this.Refresh();
            this.Invalidate();
        }
        private void UpdateTreeNodeChannels()
        {
            Copy(_tmpTnChannels, _treeViewChannels);
            _treeViewChannels.ExpandAll();
            panelChannels.Height = 30 + _treeViewChannels.Nodes[0].Nodes.Count * 20;
            this.Refresh();
            this.Invalidate();
        }
        private void Copy(TreeView treeviewSrc, TreeView treeviewTarget)
        {
            TreeNode newTn;
            if (treeviewTarget != null) { treeviewTarget.Nodes.Clear(); }
            foreach (TreeNode tn in treeviewSrc.Nodes)
            {
                newTn = new TreeNode(tn.Text, tn.ImageIndex, tn.SelectedImageIndex);
                CopyChilds(newTn, tn);
                treeviewTarget.Nodes.Add(newTn);
            }
        }
        private void CopyChilds(TreeNode parent, TreeNode willCopied)
        {
            TreeNode newTn;
            foreach (TreeNode tn in willCopied.Nodes)
            {
                newTn = new TreeNode(tn.Text, tn.ImageIndex, tn.SelectedImageIndex);
                parent.Nodes.Add(newTn);
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
        private void _slackMenu_OnUsersLoaded(object o)
        {
            UpdateTreeNodeUsers();
        }
        private void _slackMenu_OnInfoLoaded(object o)
        {
            this.Refresh();
            this.Invalidate();
        }
        private void _slackMenu_OnChannelsLoaded(object o)
        {
            UpdateTreeNodeChannels();
        }
        #endregion
    }
}
