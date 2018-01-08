using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlackClient.View
{
    public delegate void SlackInputEventHandler(object o);
    public partial class SlackInput : UserControl
    {
        #region Attributes
        public event SlackInputEventHandler OnMessageSendingRequest;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public SlackInput()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods private
        private void SendMessage()
        {
            OnMessageSendingRequest?.Invoke(_textBoxInput.Text);
            _textBoxInput.Clear();
        }
        #endregion

        #region Event
        private void buttonSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }
        private void _textBoxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\n')
            {
                SendMessage();
            }
        }
        #endregion
    }
}
