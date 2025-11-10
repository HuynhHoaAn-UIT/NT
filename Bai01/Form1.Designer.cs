namespace Bai01
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
            btnSever = new Button();
            btnClient = new Button();
            SuspendLayout();
            // 
            // btnSever
            // 
            btnSever.BackColor = SystemColors.Highlight;
            btnSever.ImageAlign = ContentAlignment.MiddleLeft;
            btnSever.Location = new Point(112, 90);
            btnSever.Name = "btnSever";
            btnSever.Size = new Size(143, 76);
            btnSever.TabIndex = 0;
            btnSever.Text = "UDP Server";
            btnSever.UseVisualStyleBackColor = false;
            btnSever.Click += btnSever_Click;
            // 
            // btnClient
            // 
            btnClient.BackColor = SystemColors.Highlight;
            btnClient.ImageAlign = ContentAlignment.MiddleLeft;
            btnClient.Location = new Point(511, 90);
            btnClient.Name = "btnClient";
            btnClient.Size = new Size(143, 76);
            btnClient.TabIndex = 1;
            btnClient.Text = "UDP Client";
            btnClient.UseVisualStyleBackColor = false;
            btnClient.Click += btnClient_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.anh_mo_ta;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 308);
            Controls.Add(btnClient);
            Controls.Add(btnSever);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnSever;
        private Button btnClient;
    }
}
