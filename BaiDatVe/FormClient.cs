using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiDatVe
{
    public partial class FormClient : Form
    {
        TcpClient client;
        NetworkStream ns;
        Thread listenThread;
        public FormClient()
        {
            InitializeComponent();
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            client = new TcpClient("127.0.0.1", 8088);
            ns = client.GetStream();
            listenThread = new Thread(ListenServer) { IsBackground = true };
            listenThread.Start();
            rtbLog.AppendText(" Đã kết nối server\n");
        }
        private void ListenServer()
        {
            byte[] buffer = new byte[1024];
            int bytesRead;
            while ((bytesRead = ns.Read(buffer, 0, buffer.Length)) > 0)
            {
                string msg = Encoding.ASCII.GetString(buffer, 0, bytesRead).Trim();
                this.Invoke((MethodInvoker)(() => rtbLog.AppendText($"Server: {msg}\n")));
            }
        }
        private void btnBook_Click(object sender, EventArgs e)
        {
            string seat = txtTicket.Text.Trim();
            if (seat == "") { MessageBox.Show("Nhập ghế cần đặt"); return; }
            byte[] data = Encoding.ASCII.GetBytes("BOOK:" + seat + "\n");
            ns.Write(data, 0, data.Length);
        }
    }
}
