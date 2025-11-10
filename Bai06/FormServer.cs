using System;
using System.Collections.Generic;
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
        Dictionary<string, TcpClient> clientUsers = new Dictionary<string, TcpClient>();

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
            byte[] buffer = new byte[4096];
            string userName = "";

            try
            {
                while (true)
                {
                    int byteCount = ns.Read(buffer, 0, buffer.Length);
                    if (byteCount == 0) break;

                    string msg = Encoding.UTF8.GetString(buffer, 0, byteCount);
                    if (msg.StartsWith("NAME|"))
                    {
                        userName = msg.Substring(5);
                        clientUsers[userName] = client;
                        Broadcast($"[Server] {userName} đã tham gia phòng chat.", client);
                        Invoke(new Action(() => rtbLog.AppendText($"{userName} đã kết nối\n")));
                        continue;
                    }
                    if (msg.StartsWith("PRIVATE|"))
                    {
                        string[] parts = msg.Split('|');
                        if (parts.Length < 3) continue;
                        string toUser = parts[1];
                        string content = parts[2];

                        if (clientUsers.ContainsKey(toUser))
                        {
                            byte[] data = Encoding.UTF8.GetBytes($"(Riêng) {userName}: {content}");
                            try { clientUsers[toUser].GetStream().Write(data, 0, data.Length); } catch { }
                        }
                        continue;
                    }

                    // Gửi file
                    if (msg.StartsWith("FILE|"))
                    {
                        string[] parts = msg.Split('|');
                        if (parts.Length < 3) continue;
                        string fileName = parts[1];
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
            catch { }
            finally
            {
                if (userName != "" && clientUsers.ContainsKey(userName))
                    clientUsers.Remove(userName);

                client.Close();
            }
        }

        void Broadcast(string msg, TcpClient sender)
        {
            byte[] data = Encoding.UTF8.GetBytes(msg);
            foreach (var c in clientUsers.Values)
            {
                if (c != sender)
                {
                    try { c.GetStream().Write(data, 0, data.Length); } catch { }
                }
            }
        }
    }
}

