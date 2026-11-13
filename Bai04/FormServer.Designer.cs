namespace Bai04
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
            btnStart = new Button();
            rtbLog = new RichTextBox();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.BackColor = SystemColors.Info;
            btnStart.Location = new Point(526, 32);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(175, 81);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // rtbLog
            // 
            rtbLog.Location = new Point(23, 119);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(726, 303);
            rtbLog.TabIndex = 1;
            rtbLog.Text = "";
            // 
            // FormServer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bo_suu_tap_hinh_nen_powerpoint_mau_toi;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbLog);
            Controls.Add(btnStart);
            Name = "FormServer";
            Text = "FormServer";
            ResumeLayout(false);
        }

        #endregion

        private Button btnStart;
        private RichTextBox rtbLog;
    }
}