namespace SlackClient
{
    partial class SlackControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this._slackMenu = new SlackClient.SlackMenu();
            this._slackInput = new SlackClient.View.SlackInput();
            this._slackConversation = new SlackClient.SlackConversation();
            this.SuspendLayout();
            // 
            // _slackMenu
            // 
            this._slackMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this._slackMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this._slackMenu.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._slackMenu.ForeColor = System.Drawing.Color.WhiteSmoke;
            this._slackMenu.Location = new System.Drawing.Point(0, 0);
            this._slackMenu.Name = "_slackMenu";
            this._slackMenu.Size = new System.Drawing.Size(300, 560);
            this._slackMenu.SlackAdapter = null;
            this._slackMenu.TabIndex = 0;
            // 
            // slackInput1
            // 
            this._slackInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._slackInput.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._slackInput.Location = new System.Drawing.Point(300, 518);
            this._slackInput.Name = "slackInput1";
            this._slackInput.Size = new System.Drawing.Size(685, 42);
            this._slackInput.TabIndex = 2;
            // 
            // _slackConversation
            // 
            this._slackConversation.AutoScroll = true;
            this._slackConversation.AutoScrollHorizontalMaximum = 100;
            this._slackConversation.AutoScrollHorizontalMinimum = 0;
            this._slackConversation.AutoScrollHPos = 0;
            this._slackConversation.AutoScrollVerticalMaximum = 100;
            this._slackConversation.AutoScrollVerticalMinimum = 0;
            this._slackConversation.AutoScrollVPos = 0;
            this._slackConversation.CurrentConversation = null;
            this._slackConversation.Dock = System.Windows.Forms.DockStyle.Fill;
            this._slackConversation.EnableAutoScrollHorizontal = true;
            this._slackConversation.EnableAutoScrollVertical = true;
            this._slackConversation.Location = new System.Drawing.Point(300, 0);
            this._slackConversation.Name = "_slackConversation";
            this._slackConversation.Size = new System.Drawing.Size(685, 518);
            this._slackConversation.SlackAdapter = null;
            this._slackConversation.TabIndex = 3;
            this._slackConversation.VisibleAutoScrollHorizontal = true;
            this._slackConversation.VisibleAutoScrollVertical = true;
            // 
            // SlackControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Controls.Add(this._slackConversation);
            this.Controls.Add(this._slackInput);
            this.Controls.Add(this._slackMenu);
            this.Name = "SlackControl";
            this.Size = new System.Drawing.Size(985, 560);
            this.ResumeLayout(false);

        }

        #endregion

        private SlackMenu _slackMenu;
        private View.SlackInput _slackInput;
        private SlackConversation _slackConversation;
    }
}
