using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Bai06
{
    public partial class FormServer : Form
    {
        TcpListener listener;
        Thread thread;
        ConcurrentDictionary<string, TcpClient> clientUsers = new ConcurrentDictionary<string, TcpClient>();

        public FormServer()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int port = 8085;
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            rtbLog.AppendText("Server started on port " + port + "\n");

            thread = new Thread(ListenForClients) { IsBackground = true };
            thread.Start();
        }

        void ListenForClients()
        {
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Thread t = new Thread(HandleClient) { IsBackground = true };
                t.Start(client);
            }
        }

        void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream ns = client.GetStream();
            using var reader = new StreamReader(ns, Encoding.UTF8);
            string userName = "";

            try
            {
                while (reader.ReadLine() is string msg)
                {
                    if (msg.StartsWith("NAME|"))
                    {
                        string requestedName = msg.Substring(5).Trim();
                        if (userName.Length != 0)
                            continue;
                        if (requestedName.Length == 0 || !clientUsers.TryAdd(requestedName, client))
                        {
                            SendLine(client, "[Server] Tên trống hoặc đã được sử dụng.");
                            break;
                        }
                        userName = requestedName;
                        Broadcast($"[Server] {userName} đã tham gia phòng chat.", client);
                        Invoke(new Action(() => rtbLog.AppendText($"{userName} đã kết nối\n")));
                        continue;
                    }
                    if (userName.Length == 0)
                        break;
                    if (msg.StartsWith("PRIVATE|"))
                    {
                        string[] parts = msg.Split('|', 3);
                        if (parts.Length < 3) continue;
                        string toUser = parts[1];
                        string content = parts[2];

                        if (clientUsers.TryGetValue(toUser, out TcpClient? recipient))
                            SendLine(recipient, $"(Riêng) {userName}: {content}");
                        continue;
                    }

                    // Gửi file
                    if (msg.StartsWith("FILE|"))
                    {
                        string[] parts = msg.Split('|', 3);
                        if (parts.Length < 3) continue;
                        string fileName = Path.GetFileName(parts[1]);
                        if (string.IsNullOrWhiteSpace(fileName)) continue;
                        byte[] fileData = Convert.FromBase64String(parts[2]);

                        string folder = Application.StartupPath + "\\ReceivedFiles";
                        System.IO.Directory.CreateDirectory(folder);
                        string savePath = System.IO.Path.Combine(folder, fileName);
                        System.IO.File.WriteAllBytes(savePath, fileData);

                        Broadcast($"[Server] {userName} đã gửi file: {fileName}", client);
                        Invoke(new Action(() => rtbLog.AppendText($"Đã lưu file: {savePath}\n")));
                        continue;
                    }
                    Broadcast($"{userName}: {msg}", client);
                    Invoke(new Action(() => rtbLog.AppendText($"{userName}: {msg}\n")));
                }
            }
            catch (Exception ex) when (ex is IOException or FormatException or InvalidOperationException) { }
            finally
            {
                if (userName.Length != 0)
                    clientUsers.TryRemove(userName, out _);

                client.Close();
            }
        }

        void Broadcast(string msg, TcpClient sender)
        {
            foreach (var client in clientUsers.Values)
            {
                if (client != sender)
                    SendLine(client, msg);
            }
        }

        private static void SendLine(TcpClient client, string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message + "\n");
            try
            {
                lock (client)
                    client.GetStream().Write(data, 0, data.Length);
            }
            catch (Exception ex) when (ex is IOException or InvalidOperationException or SocketException) { }
        }
    }
}
