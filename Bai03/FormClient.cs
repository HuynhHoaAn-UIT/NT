using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Bai03
{
    public partial class FormClient : Form
    {
        TcpClient tcpClient;
        NetworkStream ns;
        public FormClient()
        {
            InitializeComponent();
        }
        private void InitClient()
        {
            this.tcpClient = new TcpClient();
        }
        private void ConnectToServer()
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 5000);
                this.tcpClient.Connect(ipEndPoint);
                this.ns = tcpClient.GetStream();
                MessageBox.Show("Đã kết nối đến server!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }
        private void SendData(string message)
        {
            try
            {
                if (ns != null)
                {
                    byte[] data = Encoding.ASCII.GetBytes(message + "\n");
                    ns.Write(data, 0, data.Length);
                    MessageBox.Show("Đã gửi dữ liệu: " + message);
                }
                else
                {
                    MessageBox.Show("Chưa kết nối server!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi dữ liệu: " + ex.Message);
            }
        }
        private void Disconnect()
        {
            try
            {
                if (ns != null)
                {
                    byte[] data = Encoding.ASCII.GetBytes("quit\n");
                    ns.Write(data, 0, data.Length);
                    ns.Close();
                }
                if (tcpClient != null)
                    tcpClient.Close();
                MessageBox.Show("Đã ngắt kết nối server!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ngắt kết nối: " + ex.Message);
            }
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            InitClient();
            ConnectToServer();
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            string msg = rtbMessage.Text.Trim();
            if (msg != "")
                SendData(msg);
            else
                MessageBox.Show("Vui lòng nhập nội dung!");
        }
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }
    }
}
