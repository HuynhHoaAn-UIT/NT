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

namespace Bai01
{
    public partial class FormClient : Form
    {
        UdpClient udpClient = new UdpClient();
        public FormClient()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = txtIP.Text;
                int port = int.Parse(txtPort.Text);
                string message = rtbMessage.Text;  
                byte[] data = Encoding.UTF8.GetBytes(message);
                udpClient.Send(data, data.Length, ip, port);
                rtbMessage.Clear();  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
