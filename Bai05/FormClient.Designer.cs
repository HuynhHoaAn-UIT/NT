namespace Bai05
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
            txtUser = new TextBox();
            txtMon = new TextBox();
            btnConnect = new Button();
            btnAdd = new Button();
            rtbLog = new RichTextBox();
            btnNgauNhienCaNhan = new Button();
            btnNgauNhienToanBo = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(79, 28);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 0;
            label1.Text = "User";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(423, 28);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 1;
            label2.Text = "Mon an";
            // 
            // txtUser
            // 
            txtUser.Location = new Point(156, 21);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(125, 27);
            txtUser.TabIndex = 2;
            // 
            // txtMon
            // 
            txtMon.Location = new Point(508, 25);
            txtMon.Name = "txtMon";
            txtMon.Size = new Size(237, 27);
            txtMon.TabIndex = 3;
            // 
            // btnConnect
            // 
            btnConnect.BackColor = SystemColors.Info;
            btnConnect.Location = new Point(91, 111);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(94, 49);
            btnConnect.TabIndex = 4;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.Info;
            btnAdd.Location = new Point(536, 111);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 49);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // rtbLog
            // 
            rtbLog.Location = new Point(91, 180);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(539, 184);
            rtbLog.TabIndex = 6;
            rtbLog.Text = "";
            // 
            // btnNgauNhienCaNhan
            // 
            btnNgauNhienCaNhan.BackColor = SystemColors.Info;
            btnNgauNhienCaNhan.Location = new Point(91, 389);
            btnNgauNhienCaNhan.Name = "btnNgauNhienCaNhan";
            btnNgauNhienCaNhan.Size = new Size(94, 49);
            btnNgauNhienCaNhan.TabIndex = 7;
            btnNgauNhienCaNhan.Text = "Random Riêng";
            btnNgauNhienCaNhan.UseVisualStyleBackColor = false;
            btnNgauNhienCaNhan.Click += btnNgauNhienCaNhan_Click;
            // 
            // btnNgauNhienToanBo
            // 
            btnNgauNhienToanBo.BackColor = SystemColors.Info;
            btnNgauNhienToanBo.Location = new Point(536, 389);
            btnNgauNhienToanBo.Name = "btnNgauNhienToanBo";
            btnNgauNhienToanBo.Size = new Size(94, 49);
            btnNgauNhienToanBo.TabIndex = 8;
            btnNgauNhienToanBo.Text = "Random Chung";
            btnNgauNhienToanBo.UseVisualStyleBackColor = false;
            btnNgauNhienToanBo.Click += btnNgauNhienToanBo_Click;
            // 
            // FormClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.images;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btnNgauNhienToanBo);
            Controls.Add(btnNgauNhienCaNhan);
            Controls.Add(rtbLog);
            Controls.Add(btnAdd);
            Controls.Add(btnConnect);
            Controls.Add(txtMon);
            Controls.Add(txtUser);
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
        private TextBox txtUser;
        private TextBox txtMon;
        private Button btnConnect;
        private Button btnAdd;
        private RichTextBox rtbLog;
        private Button btnNgauNhienCaNhan;
        private Button btnNgauNhienToanBo;
    }
}