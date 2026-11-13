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
            if (client != null)
                return;
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                !int.TryParse(txtPort.Text, out int port) || port < 1 || port > 65535)
            {
                MessageBox.Show("Nhập tên và cổng từ 1 đến 65535.");
                return;
            }

            try
            {
                client = new TcpClient(txtIP.Text.Trim(), port);
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi kết nối");
                return;
            }
            ns = client.GetStream();
            byte[] nameData = Encoding.UTF8.GetBytes("NAME|" + txtName.Text.Trim() + "\n");
            ns.Write(nameData, 0, nameData.Length);

            thread = new Thread(ReceiveMessage) { IsBackground = true };
            thread.Start();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (ns == null || string.IsNullOrWhiteSpace(txtMessage.Text))
                return;
            string msg = txtMessage.Text.Replace("\r", " ").Replace("\n", " ");
            if (txtToUser.Text != "") 
                msg = $"PRIVATE|{txtToUser.Text}|{msg}";
            byte[] data = Encoding.UTF8.GetBytes(msg + "\n");
            ns.Write(data, 0, data.Length);
            txtMessage.Clear();
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            if (ns == null)
                return;
            openFileDialog1.Filter = "Tất cả tệp tin|*.txt;*.jpg;*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                string fileName = System.IO.Path.GetFileName(filePath);
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                string base64 = Convert.ToBase64String(fileBytes);
                string data = $"FILE|{fileName}|{base64}";
                byte[] buffer = Encoding.UTF8.GetBytes(data + "\n");
                ns.Write(buffer, 0, buffer.Length);
                rtbChat.AppendText($"(Bạn đã gửi file: {fileName})\n");
            }
        }

        void ReceiveMessage()
        {
            try
            {
                using var reader = new StreamReader(ns, Encoding.UTF8);
                while (reader.ReadLine() is string message)
                {
                    if (IsDisposed || !IsHandleCreated)
                        break;
                    Invoke(new Action(() => rtbChat.AppendText(message + "\n")));
                }
            }
            catch (Exception ex) when (ex is IOException or InvalidOperationException)
            {
                if (!IsDisposed && IsHandleCreated)
                    BeginInvoke(new Action(() => rtbChat.AppendText("Đã ngắt kết nối.\n")));
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            client?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
