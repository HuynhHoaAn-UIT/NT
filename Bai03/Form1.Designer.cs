namespace Bai03
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnServer = new Button();
            btnTCPClient = new Button();
            SuspendLayout();
            // 
            // btnServer
            // 
            btnServer.BackColor = SystemColors.Highlight;
            btnServer.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnServer.Location = new Point(278, 85);
            btnServer.Name = "btnServer";
            btnServer.Size = new Size(228, 92);
            btnServer.TabIndex = 0;
            btnServer.Text = "Open TcpServer";
            btnServer.UseVisualStyleBackColor = false;
            btnServer.Click += btnServer_Click;
            // 
            // btnTCPClient
            // 
            btnTCPClient.BackColor = SystemColors.Highlight;
            btnTCPClient.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTCPClient.Location = new Point(278, 269);
            btnTCPClient.Name = "btnTCPClient";
            btnTCPClient.Size = new Size(228, 92);
            btnTCPClient.TabIndex = 1;
            btnTCPClient.Text = "Open TCPClient\r\n";
            btnTCPClient.UseVisualStyleBackColor = false;
            btnTCPClient.Click += btnTCPClient_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bo_suu_tap_hinh_nen_powerpoint_mau_toi;
            ClientSize = new Size(800, 450);
            Controls.Add(btnTCPClient);
            Controls.Add(btnServer);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnServer;
        private Button btnTCPClient;
    }
}
