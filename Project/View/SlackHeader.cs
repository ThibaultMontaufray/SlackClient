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
    public partial class SlackHeader : UserControl
    {
        #region Attributes
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public SlackHeader()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods public
        public void LoadData(SlackAdapter slackAdapter)
        {
            labelChannel.Text = "#" + slackAdapter.CurrentChannel.Name;
        }
        #endregion

        #region Methods private
        #endregion

        #region Event
        #endregion
    }
}
