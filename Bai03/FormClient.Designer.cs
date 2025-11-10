namespace Bai03
{
    partial class FormClient
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
            rtbMessage = new RichTextBox();
            btnConnect = new Button();
            btnSend = new Button();
            btnDisconnect = new Button();
            SuspendLayout();
            // 
            // rtbMessage
            // 
            rtbMessage.Location = new Point(12, 65);
            rtbMessage.Name = "rtbMessage";
            rtbMessage.Size = new Size(563, 373);
            rtbMessage.TabIndex = 0;
            rtbMessage.Text = "";
            // 
            // btnConnect
            // 
            btnConnect.BackColor = SystemColors.Highlight;
            btnConnect.Location = new Point(600, 64);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(168, 68);
            btnConnect.TabIndex = 1;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnSend
            // 
            btnSend.BackColor = SystemColors.Highlight;
            btnSend.Location = new Point(600, 187);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(168, 68);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.BackColor = SystemColors.Highlight;
            btnDisconnect.Location = new Point(600, 327);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(168, 68);
            btnDisconnect.TabIndex = 3;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = false;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // FormClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.istockphoto_1720696730_612x612;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDisconnect);
            Controls.Add(btnSend);
            Controls.Add(btnConnect);
            Controls.Add(rtbMessage);
            Name = "FormClient";
            Text = "FormClient";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rtbMessage;
        private Button btnConnect;
        private Button btnSend;
        private Button btnDisconnect;
    }
}