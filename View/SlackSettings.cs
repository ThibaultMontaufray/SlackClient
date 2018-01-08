using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlackClient
{
    public partial class SlackSettings : Form
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
        public SlackSettings()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods public
        public void LoadData(SlackAdapter slackAdapter)
        {
            _slackAdapter = slackAdapter;
            RefreshDgv();
        }
        #endregion

        #region Methods private
        private void RefreshDgv()
        {
            DataGridViewRow row;
            _dataGridViewToken.Rows.Clear();

            if (_slackAdapter != null && _slackAdapter.Tokens != null)
            {
                foreach (var item in _slackAdapter.Tokens)
                {
                    _dataGridViewToken.Rows.Add();

                    row = _dataGridViewToken.Rows[_dataGridViewToken.Rows.Count - 1];
                    row.Cells[ColumnKey.Index].Value = item.Key;
                    row.Cells[ColumnActive.Index].Value = item.IsUsed;
                    row.Cells[ColumnDelete.Index].Value = Tools4Libraries.Resources.ResourceIconSet16Default.bin_empty;
                }
            }
            _dataGridViewToken.Height =( _dataGridViewToken.Rows.Count > 0 ? _dataGridViewToken.Rows.Count * 24 : 24) -1;
            this.Height = 135 + (_dataGridViewToken.Rows.Count > 0 ? ((_dataGridViewToken.Rows.Count - 1) * 24) : 0);
        }
        #endregion

        #region Event
        private void _buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SlackSettings_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\u001b')
            {
                this.Close();
            }
        }
        #endregion
    }
}
