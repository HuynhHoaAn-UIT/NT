namespace Bai04
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
            btnClient = new Button();
            SuspendLayout();
            // 
            // btnServer
            // 
            btnServer.BackColor = SystemColors.Info;
            btnServer.Location = new Point(135, 101);
            btnServer.Name = "btnServer";
            btnServer.Size = new Size(140, 76);
            btnServer.TabIndex = 0;
            btnServer.Text = "Open Server";
            btnServer.UseVisualStyleBackColor = false;
            btnServer.Click += btnServer_Click;
            // 
            // btnClient
            // 
            btnClient.BackColor = SystemColors.Info;
            btnClient.Location = new Point(484, 237);
            btnClient.Name = "btnClient";
            btnClient.Size = new Size(140, 76);
            btnClient.TabIndex = 1;
            btnClient.Text = "Open Client";
            btnClient.UseVisualStyleBackColor = false;
            btnClient.Click += btnClient_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bo_suu_tap_hinh_nen_powerpoint_mau_toi;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClient);
            Controls.Add(btnServer);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnServer;
        private Button btnClient;
    }
}
