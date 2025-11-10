using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai03
{
    public partial class FormServer : Form
    {
        TcpListener server;
        TcpClient client;
        NetworkStream ns;
        Thread thread;
        public FormServer()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            thread = new Thread(StartServer);
            thread.IsBackground = true;
            thread.Start();
        }
        void StartServer()
        {
            try
            {
                IPAddress ip = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(ip, 5000);
                server.Start();
                this.Invoke((MethodInvoker)(() => rtbLog.AppendText("Server đang lắng nghe...\n")));
                client = server.AcceptTcpClient();
                this.Invoke((MethodInvoker)(() => rtbLog.AppendText("Client đã kết nối!\n")));
                ns = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = ns.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string msg = Encoding.ASCII.GetString(buffer, 0, bytesRead).Trim();
                    this.Invoke((MethodInvoker)(() => rtbLog.AppendText("..." + msg + "\n")));
                    if (msg.ToLower() == "quit")
                        break;
                }
                ns.Close();
                client.Close();
                server.Stop();
                this.Invoke((MethodInvoker)(() => rtbLog.AppendText("Server đã dừng.\n")));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi server: " + ex.Message);
            }
        }
    }
}
