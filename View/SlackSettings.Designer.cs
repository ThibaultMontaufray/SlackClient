namespace SlackClient
{
    partial class SlackSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SlackSettings));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this._buttonClose = new System.Windows.Forms.Button();
            this.labelTokent = new System.Windows.Forms.Label();
            this.labelSettings = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._dataGridViewToken = new System.Windows.Forms.DataGridView();
            this.ColumnActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDelete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewToken)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonClose
            // 
            this._buttonClose.BackColor = System.Drawing.Color.Transparent;
            this._buttonClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_buttonClose.BackgroundImage")));
            this._buttonClose.FlatAppearance.BorderSize = 0;
            this._buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this._buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this._buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._buttonClose.Location = new System.Drawing.Point(269, 12);
            this._buttonClose.Name = "_buttonClose";
            this._buttonClose.Size = new System.Drawing.Size(16, 16);
            this._buttonClose.TabIndex = 0;
            this._buttonClose.UseVisualStyleBackColor = false;
            this._buttonClose.Click += new System.EventHandler(this._buttonClose_Click);
            // 
            // labelTokent
            // 
            this.labelTokent.AutoSize = true;
            this.labelTokent.BackColor = System.Drawing.Color.Transparent;
            this.labelTokent.Location = new System.Drawing.Point(13, 105);
            this.labelTokent.Name = "labelTokent";
            this.labelTokent.Size = new System.Drawing.Size(38, 15);
            this.labelTokent.TabIndex = 1;
            this.labelTokent.Text = "Token";
            // 
            // labelSettings
            // 
            this.labelSettings.AutoSize = true;
            this.labelSettings.BackColor = System.Drawing.Color.Transparent;
            this.labelSettings.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettings.Location = new System.Drawing.Point(12, 13);
            this.labelSettings.Name = "labelSettings";
            this.labelSettings.Size = new System.Drawing.Size(73, 23);
            this.labelSettings.TabIndex = 3;
            this.labelSettings.Text = "Settings";
            // 
            // textBoxUser
            // 
            this.textBoxUser.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxUser.Location = new System.Drawing.Point(97, 44);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(191, 23);
            this.textBoxUser.TabIndex = 5;
            this.textBoxUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SlackSettings_KeyPress);
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.BackColor = System.Drawing.Color.Transparent;
            this.labelUser.Location = new System.Drawing.Point(13, 47);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(32, 15);
            this.labelUser.TabIndex = 4;
            this.labelUser.Text = "User";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxPassword.Location = new System.Drawing.Point(97, 73);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(191, 23);
            this.textBoxPassword.TabIndex = 7;
            this.textBoxPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SlackSettings_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(13, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password";
            // 
            // _dataGridViewToken
            // 
            this._dataGridViewToken.AllowUserToAddRows = false;
            this._dataGridViewToken.AllowUserToDeleteRows = false;
            this._dataGridViewToken.AllowUserToResizeColumns = false;
            this._dataGridViewToken.AllowUserToResizeRows = false;
            this._dataGridViewToken.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this._dataGridViewToken.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewToken.ColumnHeadersVisible = false;
            this._dataGridViewToken.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnActive,
            this.ColumnKey,
            this.ColumnDelete});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dataGridViewToken.DefaultCellStyle = dataGridViewCellStyle1;
            this._dataGridViewToken.Location = new System.Drawing.Point(97, 102);
            this._dataGridViewToken.Name = "_dataGridViewToken";
            this._dataGridViewToken.RowHeadersVisible = false;
            this._dataGridViewToken.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dataGridViewToken.Size = new System.Drawing.Size(191, 23);
            this._dataGridViewToken.TabIndex = 8;
            // 
            // ColumnActive
            // 
            this.ColumnActive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnActive.HeaderText = "Active";
            this.ColumnActive.Name = "ColumnActive";
            this.ColumnActive.Width = 5;
            // 
            // ColumnKey
            // 
            this.ColumnKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnKey.HeaderText = "Key";
            this.ColumnKey.Name = "ColumnKey";
            // 
            // ColumnDelete
            // 
            this.ColumnDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnDelete.HeaderText = "Delete";
            this.ColumnDelete.Name = "ColumnDelete";
            this.ColumnDelete.Width = 5;
            // 
            // SlackSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(300, 135);
            this.Controls.Add(this._dataGridViewToken);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.labelSettings);
            this.Controls.Add(this.labelTokent);
            this.Controls.Add(this._buttonClose);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SlackSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SlackSettings";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SlackSettings_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewToken)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _buttonClose;
        private System.Windows.Forms.Label labelTokent;
        private System.Windows.Forms.Label labelSettings;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView _dataGridViewToken;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKey;
        private System.Windows.Forms.DataGridViewImageColumn ColumnDelete;
    }
}