namespace SlackWinformDemo
{
    partial class Form1
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.slackControl1 = new SlackClient.SlackControl();
            this.SuspendLayout();
            // 
            // slackControl1
            // 
            this.slackControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.slackControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slackControl1.Location = new System.Drawing.Point(0, 0);
            this.slackControl1.Name = "slackControl1";
            this.slackControl1.Size = new System.Drawing.Size(1334, 761);
            this.slackControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 761);
            this.Controls.Add(this.slackControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Text = "Slack client";
            this.ResumeLayout(false);

        }

        #endregion

        private SlackClient.SlackControl slackControl1;
    }
}

