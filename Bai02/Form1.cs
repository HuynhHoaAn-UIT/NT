using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Bai02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread serverThread = new Thread(new ThreadStart(StartUnsafeThread));
            serverThread.Start();
        }
        void StartUnsafeThread()
        {
            try
            {
                int bytesReceived = 0;
                byte[] recv = new byte[1];
                Socket clientSocket;
                Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                listenerSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse("192.168.56.1"), 8083);
                listenerSocket.Bind(ipepServer);
                listenerSocket.Listen(-1);

                clientSocket = listenerSocket.Accept();
                listViewCommand.Items.Add(new ListViewItem("New client connected"));

                while (clientSocket.Connected)
                {
                    string text = "";
                    do
                    {
                        bytesReceived = clientSocket.Receive(recv);
                        text += Encoding.ASCII.GetString(recv);
                    } while (text[text.Length - 1] != '\n');

                    listViewCommand.Items.Add(new ListViewItem(text.Trim()));

                    if (text.Trim().ToLower() == "exit")
                    {
                        listViewCommand.Items.Add(new ListViewItem("Client disconnected"));
                        clientSocket.Close();
                        break;
                    }
                }

                listenerSocket.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Server error: " + ex.Message);
            }
        }
    }
}
