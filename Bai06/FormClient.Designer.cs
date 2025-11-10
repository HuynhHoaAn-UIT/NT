namespace Bai06
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtName = new TextBox();
            txtIP = new TextBox();
            txtPort = new TextBox();
            txtMessage = new TextBox();
            rtbChat = new RichTextBox();
            btnConnect = new Button();
            btnSend = new Button();
            btnFile = new Button();
            openFileDialog1 = new OpenFileDialog();
            txtToUser = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 45);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 0;
            label1.Text = "User";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(293, 45);
            label2.Name = "label2";
            label2.Size = new Size(21, 20);
            label2.TabIndex = 1;
            label2.Text = "IP";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(533, 45);
            label3.Name = "label3";
            label3.Size = new Size(35, 20);
            label3.TabIndex = 2;
            label3.Text = "Port";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(368, 102);
            label4.Name = "label4";
            label4.Size = new Size(67, 20);
            label4.TabIndex = 3;
            label4.Text = "Message";
            // 
            // txtName
            // 
            txtName.Location = new Point(130, 45);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 4;
            // 
            // txtIP
            // 
            txtIP.Location = new Point(343, 45);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(125, 27);
            txtIP.TabIndex = 5;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(603, 38);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(125, 27);
            txtPort.TabIndex = 6;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(84, 135);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(670, 27);
            txtMessage.TabIndex = 7;
            // 
            // rtbChat
            // 
            rtbChat.Location = new Point(60, 189);
            rtbChat.Name = "rtbChat";
            rtbChat.Size = new Size(694, 162);
            rtbChat.TabIndex = 8;
            rtbChat.Text = "";
            // 
            // btnConnect
            // 
            btnConnect.BackColor = SystemColors.Highlight;
            btnConnect.Location = new Point(60, 384);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(107, 54);
            btnConnect.TabIndex = 9;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnSend
            // 
            btnSend.BackColor = SystemColors.Highlight;
            btnSend.Location = new Point(315, 384);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(107, 54);
            btnSend.TabIndex = 10;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // btnFile
            // 
            btnFile.BackColor = SystemColors.Highlight;
            btnFile.Location = new Point(559, 384);
            btnFile.Name = "btnFile";
            btnFile.Size = new Size(107, 54);
            btnFile.TabIndex = 11;
            btnFile.Text = "File";
            btnFile.UseVisualStyleBackColor = false;
            btnFile.Click += btnFile_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtToUser
            // 
            txtToUser.Location = new Point(603, 99);
            txtToUser.Name = "txtToUser";
            txtToUser.Size = new Size(125, 27);
            txtToUser.TabIndex = 12;
            // 
            // FormClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bo_suu_tap_hinh_nen_powerpoint_mau_toi;
            ClientSize = new Size(800, 450);
            Controls.Add(txtToUser);
            Controls.Add(btnFile);
            Controls.Add(btnSend);
            Controls.Add(btnConnect);
            Controls.Add(rtbChat);
            Controls.Add(txtMessage);
            Controls.Add(txtPort);
            Controls.Add(txtIP);
            Controls.Add(txtName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormClient";
            Text = "FormClient";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtName;
        private TextBox txtIP;
        private TextBox txtPort;
        private TextBox txtMessage;
        private RichTextBox rtbChat;
        private Button btnConnect;
        private Button btnSend;
        private Button btnFile;
        private OpenFileDialog openFileDialog1;
        private TextBox txtToUser;
    }
}