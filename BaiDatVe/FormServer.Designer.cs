namespace BaiDatVe
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
            lstSeats = new ListBox();
            rtbLog = new RichTextBox();
            SuspendLayout();
            // 
            // btnListen
            // 
            btnListen.BackColor = SystemColors.HotTrack;
            btnListen.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnListen.Location = new Point(548, 29);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(172, 71);
            btnListen.TabIndex = 0;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = false;
            btnListen.Click += btnListen_Click;
            // 
            // lstSeats
            // 
            lstSeats.FormattingEnabled = true;
            lstSeats.Location = new Point(37, 115);
            lstSeats.Name = "lstSeats";
            lstSeats.Size = new Size(635, 124);
            lstSeats.TabIndex = 1;
            // 
            // rtbLog
            // 
            rtbLog.Location = new Point(37, 257);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(683, 181);
            rtbLog.TabIndex = 2;
            rtbLog.Text = "";
            // 
            // FormServer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.pngtree_3d_rendered_movie_theatre_with_white_screen_image_3732826;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbLog);
            Controls.Add(lstSeats);
            Controls.Add(btnListen);
            Name = "FormServer";
            Text = "FormServer";
            ResumeLayout(false);
        }

        #endregion

        private Button btnListen;
        private ListBox lstSeats;
        private RichTextBox rtbLog;
    }
}