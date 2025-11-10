using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Bai06
{
    public partial class FormClient : Form
    {
        TcpClient client;
        NetworkStream ns;
        Thread thread;

        public FormClient()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            client = new TcpClient(txtIP.Text, int.Parse(txtPort.Text));
            ns = client.GetStream();
            byte[] nameData = Encoding.UTF8.GetBytes("NAME|" + txtName.Text);
            ns.Write(nameData, 0, nameData.Length);

            thread = new Thread(ReceiveMessage) { IsBackground = true };
            thread.Start();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string msg = txtMessage.Text;
            if (txtToUser.Text != "") 
                msg = $"PRIVATE|{txtToUser.Text}|{msg}";
            byte[] data = Encoding.UTF8.GetBytes(msg);
            ns.Write(data, 0, data.Length);
            txtMessage.Clear();
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Tất cả tệp tin|*.txt;*.jpg;*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                string fileName = System.IO.Path.GetFileName(filePath);
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                string base64 = Convert.ToBase64String(fileBytes);
                string data = $"FILE|{fileName}|{base64}";
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                ns.Write(buffer, 0, buffer.Length);
                rtbChat.AppendText($"(Bạn đã gửi file: {fileName})\n");
            }
        }

        void ReceiveMessage()
        {
            byte[] buffer = new byte[4096];
            while (true)
            {
                int byteCount = ns.Read(buffer, 0, buffer.Length);
                if (byteCount == 0) break;
                string msg = Encoding.UTF8.GetString(buffer, 0, byteCount);
                Invoke(new Action(() => rtbChat.AppendText(msg + "\n")));
            }
        }
    }
}
