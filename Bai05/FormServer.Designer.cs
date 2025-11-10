namespace Bai05
{
    partial class FormServer
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
            btnListen = new Button();
            rtbLog = new RichTextBox();
            SuspendLayout();
            // 
            // btnListen
            // 
            btnListen.BackColor = SystemColors.Info;
            btnListen.Location = new Point(515, 28);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(168, 59);
            btnListen.TabIndex = 0;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = false;
            btnListen.Click += btnListen_Click;
            // 
            // rtbLog
            // 
            rtbLog.Location = new Point(40, 131);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(653, 280);
            rtbLog.TabIndex = 1;
            rtbLog.Text = "";
            // 
            // FormServer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.images;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbLog);
            Controls.Add(btnListen);
            Name = "FormServer";
            Text = "FormServer";
            ResumeLayout(false);
        }

        #endregion

        private Button btnListen;
        private RichTextBox rtbLog;
    }
}