using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Bai02
{
    public partial class Form1 : Form
    {
        private Socket? listener;

        public Form1()
        {
            InitializeComponent();
            FormClosed += (_, _) => listener?.Dispose();
        }

        private async void btnListen_Click(object sender, EventArgs e)
        {
            btnListen.Enabled = false;
            using var server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener = server;
            try
            {
                server.Bind(new IPEndPoint(IPAddress.Any, 8080));
                server.Listen(10);
                listViewCommand.Items.Add("Telnet server đang lắng nghe tại cổng 8080");

                while (!IsDisposed)
                {
                    using var client = await server.AcceptAsync();
                    listViewCommand.Items.Add("Client đã kết nối");
                    using var stream = new NetworkStream(client);
                    using var reader = new StreamReader(stream, Encoding.ASCII);
                    while (await reader.ReadLineAsync() is string line && !IsDisposed)
                    {
                        if (line.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase))
                            break;
                        listViewCommand.Items.Add(line);
                    }
                    if (!IsDisposed)
                        listViewCommand.Items.Add("Client đã ngắt kết nối");
                }
            }
            catch (Exception ex) when (ex is SocketException or IOException or ObjectDisposedException)
            {
                if (!IsDisposed)
                    MessageBox.Show(ex.Message, "Lỗi Telnet");
            }
            finally
            {
                listener = null;
                if (!IsDisposed)
                    btnListen.Enabled = true;
            }
        }
    }
}
