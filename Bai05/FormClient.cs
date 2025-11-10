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

namespace Bai05
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtMon.Text == "")
            {
                MessageBox.Show("Nhập tên và món ăn!");
                return;
            }
            string msg = $"ADD:{txtMon.Text}:{txtUser.Text}";
            byte[] data = Encoding.UTF8.GetBytes(msg + "\n");
            ns.Write(data, 0, data.Length);
        }

        private void btnNgauNhienToanBo_Click(object sender, EventArgs e)
        {
            string msg = "RANDOM:ALL";
            ns.Write(Encoding.UTF8.GetBytes(msg + "\n"), 0, msg.Length + 1);
        }

        private void btnNgauNhienCaNhan_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                MessageBox.Show("Nhập tên trước!");
                return;
            }
            string msg = $"RANDOM:SELF:{txtUser.Text}";
            ns.Write(Encoding.UTF8.GetBytes(msg + "\n"), 0, msg.Length + 1);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            client = new TcpClient("127.0.0.1", 8085);
            ns = client.GetStream();
            listenThread = new Thread(ListenServer) { IsBackground = true };
            listenThread.Start();
            rtbLog.AppendText("Đã kết nối server\n");
        }
        void ListenServer()
        {
            byte[] buffer = new byte[1024];
            int bytes;
            while ((bytes = ns.Read(buffer, 0, buffer.Length)) > 0)
            {
                string msg = Encoding.UTF8.GetString(buffer, 0, bytes).Trim();
                this.Invoke((MethodInvoker)(() => rtbLog.AppendText("Server: " + msg + "\n")));
            }
        }
    }
}
