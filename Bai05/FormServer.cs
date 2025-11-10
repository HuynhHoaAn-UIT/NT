using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Bai05
{
    public partial class FormServer : Form
    {
        TcpListener server;
        List<TcpClient> clients = new List<TcpClient>();
        Thread listenThread;
        string dbPath = "Data Source=monan.db";

        public FormServer()
        {
            InitializeComponent();
            TaoCSDL();
        }

        void TaoCSDL()
        {
            using (var conn = new SQLiteConnection(dbPath))
            {
                conn.Open();
                var cmd = new SQLiteCommand(conn);
                cmd.CommandText = @"CREATE TABLE IF NOT EXISTS MonAn(
                                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                        TenMon TEXT,
                                        IDNguoiDung TEXT
                                    );";
                cmd.ExecuteNonQuery();
            }
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            server = new TcpListener(IPAddress.Any, 8085);
            server.Start();
            listenThread = new Thread(ListenClients) { IsBackground = true };
            listenThread.Start();
            rtbLog.AppendText("Server đang chạy...\n");
        }
        void ListenClients()
        {
            while (true)
            {
                var client = server.AcceptTcpClient();
                clients.Add(client);
                Thread t = new Thread(() => HandleClient(client)) { IsBackground = true };
                t.Start();
            }
        }

        void HandleClient(TcpClient client)
        {
            NetworkStream ns = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytes;

            while ((bytes = ns.Read(buffer, 0, buffer.Length)) > 0)
            {
                string msg = Encoding.UTF8.GetString(buffer, 0, bytes).Trim();
                this.Invoke((MethodInvoker)(() => rtbLog.AppendText($"Nhận: {msg}\n")));

                if (msg.StartsWith("ADD:"))
                {
                    string[] parts = msg.Split(':');
                    if (parts.Length >= 3)
                    {
                        string tenMon = parts[1];
                        string user = parts[2];
                        LuuMonAn(tenMon, user);
                        Broadcast($"NEW:{tenMon}:{user}");
                    }
                }
                else if (msg.StartsWith("RANDOM:"))
                {
                    string[] parts = msg.Split(':');
                    string resp = "";

                    if (msg.Contains("ALL"))
                        resp = LayNgauNhienToanBo();
                    else if (msg.Contains("SELF"))
                        resp = LayNgauNhienNguoi(parts[2]);

                    Gui(client, "RESULT:" + resp);
                }
            }
        }

        void LuuMonAn(string ten, string user)
        {
            using (var conn = new SQLiteConnection(dbPath))
            {
                conn.Open();
                var cmd = new SQLiteCommand("INSERT INTO MonAn(TenMon, IDNguoiDung) VALUES(@ten, @user)", conn);
                cmd.Parameters.AddWithValue("@ten", ten);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.ExecuteNonQuery();
            }
        }

        string LayNgauNhienToanBo()
        {
            using (var conn = new SQLiteConnection(dbPath))
            {
                conn.Open();
                var cmd = new SQLiteCommand("SELECT TenMon FROM MonAn ORDER BY RANDOM() LIMIT 1;", conn);
                var result = cmd.ExecuteScalar();
                return result == null ? "Không có món nào" : result.ToString();
            }
        }

        string LayNgauNhienNguoi(string user)
        {
            using (var conn = new SQLiteConnection(dbPath))
            {
                conn.Open();
                var cmd = new SQLiteCommand("SELECT TenMon FROM MonAn WHERE IDNguoiDung=@u ORDER BY RANDOM() LIMIT 1;", conn);
                cmd.Parameters.AddWithValue("@u", user);
                var result = cmd.ExecuteScalar();
                return result == null ? "Không có món của bạn" : result.ToString();
            }
        }

        void Broadcast(string msg)
        {
            byte[] data = Encoding.UTF8.GetBytes(msg + "\n");
            foreach (var c in clients)
            {
                try { if (c.Connected) c.GetStream().Write(data, 0, data.Length); } catch { }
            }
        }

        void Gui(TcpClient c, string msg)
        {
            byte[] data = Encoding.UTF8.GetBytes(msg + "\n");
            try { c.GetStream().Write(data, 0, data.Length); } catch { }
        }
    }
}
