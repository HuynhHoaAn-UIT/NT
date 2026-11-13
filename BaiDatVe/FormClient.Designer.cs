namespace BaiDatVe
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
            btnConnect = new Button();
            btnBook = new Button();
            txtTicket = new TextBox();
            label1 = new Label();
            rtbLog = new RichTextBox();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.BackColor = SystemColors.Highlight;
            btnConnect.Location = new Point(600, 69);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(128, 52);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnBook
            // 
            btnBook.BackColor = SystemColors.Highlight;
            btnBook.Location = new Point(600, 202);
            btnBook.Name = "btnBook";
            btnBook.Size = new Size(128, 52);
            btnBook.TabIndex = 1;
            btnBook.Text = "Book";
            btnBook.UseVisualStyleBackColor = false;
            btnBook.Click += btnBook_Click;
            // 
            // txtTicket
            // 
            txtTicket.Location = new Point(45, 132);
            txtTicket.Name = "txtTicket";
            txtTicket.Size = new Size(236, 27);
            txtTicket.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(45, 85);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(167, 28);
            label1.TabIndex = 3;
            label1.Text = "Nhập ghế cần đặt";
            // 
            // rtbLog
            // 
            rtbLog.Location = new Point(36, 202);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(479, 220);
            rtbLog.TabIndex = 4;
            rtbLog.Text = "";
            // 
            // FormClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.pngtree_3d_rendered_movie_theatre_with_white_screen_image_3732826;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbLog);
            Controls.Add(label1);
            Controls.Add(txtTicket);
            Controls.Add(btnBook);
            Controls.Add(btnConnect);
            Name = "FormClient";
            Text = "FormClient";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConnect;
        private Button btnBook;
        private TextBox txtTicket;
        private Label label1;
        private RichTextBox rtbLog;
    }
}