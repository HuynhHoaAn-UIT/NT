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

namespace Bai01
{
    public partial class FormServer : Form
    {
        UdpClient udpServer;
        Thread threadReceive;
        bool isListening = false;
        public FormServer()
        {
            InitializeComponent();
        }

        private void ttnListen_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isListening)
                {
                    int port = int.Parse(txtPort.Text);
                    udpServer = new UdpClient(port);
                    threadReceive = new Thread(ReceiveData);
                    threadReceive.IsBackground = true;
                    threadReceive.Start();
                    isListening = true;
                    AddMessage($"Server đang lắng nghe ở cổng {port}...");
                    btnListen.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở cổng: " + ex.Message);
            }
        }
    
    void ReceiveData()
        {
            while (isListening)
            {
                try
                {
                    IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
                    byte[] data = udpServer.Receive(ref remoteEP);
                    string message = Encoding.UTF8.GetString(data);
                    AddMessage($"Từ {remoteEP}: {message}");
                }
                catch
                {

                }
            }
        }

        void AddMessage(string msg)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AddMessage), msg);
                return;
            }
            listBox1.Items.Add(msg);
        }
    }
}
