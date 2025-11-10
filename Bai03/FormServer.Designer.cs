namespace Bai03
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
            btnListen.BackColor = SystemColors.Highlight;
            btnListen.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnListen.Location = new Point(747, 60);
            btnListen.Margin = new Padding(4, 4, 4, 4);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(239, 91);
            btnListen.TabIndex = 0;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = false;
            btnListen.Click += btnListen_Click;
            // 
            // rtbLog
            // 
            rtbLog.Location = new Point(34, 172);
            rtbLog.Margin = new Padding(4, 4, 4, 4);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(952, 309);
            rtbLog.TabIndex = 1;
            rtbLog.Text = "";
            // 
            // FormServer
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.image_cache__1_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1016, 495);
            Controls.Add(rtbLog);
            Controls.Add(btnListen);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 4, 4, 4);
            Name = "FormServer";
            Text = "FormServer";
            ResumeLayout(false);
        }

        #endregion

        private Button btnListen;
        private RichTextBox rtbLog;
    }
}