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

namespace BaiDatVe
{
    public partial class FormServer : Form
    {
        TcpListener server;
        List<TcpClient> clients = new List<TcpClient>();
        Dictionary<string, bool> seats = new Dictionary<string, bool>(); 
        Thread listenThread;

        public FormServer()
        {
            InitializeComponent();
            LoadSeats();
            UpdateSeatList();
        }

        void LoadSeats()
        {
            string[] movies = System.IO.File.ReadAllLines("movies.txt"); 
            foreach (var movie in movies)
            {
                for (int i = 1; i <= 5; i++) 
                    seats[$"{movie}|A{i}"] = false;
            }
        }

        void UpdateSeatList()
        {
            lstSeats.Items.Clear();
            foreach (var s in seats)
                lstSeats.Items.Add($"{s.Key} - {(s.Value ? "Đã đặt" : "Còn")}");
        }



        void StartServer()
        {
            server = new TcpListener(IPAddress.Any, 8088);
            server.Start();
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                clients.Add(client);
                Thread t = new Thread(() => HandleClient(client)) { IsBackground = true };
                t.Start();
            }
        }

        void HandleClient(TcpClient client)
        {
            NetworkStream ns = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;
            while ((bytesRead = ns.Read(buffer, 0, buffer.Length)) > 0)
            {
                string msg = Encoding.ASCII.GetString(buffer, 0, bytesRead).Trim();
                this.Invoke((MethodInvoker)(() => rtbLog.AppendText($"Nhận: {msg}\n")));

                if (msg.StartsWith("BOOK:"))
                {
                    string seatKey = msg.Substring(5);
                    string resp;
                    lock (seats)
                    {
                        if (seats.ContainsKey(seatKey) && !seats[seatKey])
                        {
                            seats[seatKey] = true;
                            resp = $"SUCCESS:{seatKey}";
                        }
                        else
                            resp = $"FAIL:{seatKey}";
                    }
                    Broadcast(resp);
                    this.Invoke((MethodInvoker)UpdateSeatList);
                }
            }
        }

        void Broadcast(string msg)
        {
            byte[] data = Encoding.ASCII.GetBytes(msg + "\n");
            foreach (var c in clients)
            {
                try { if (c.Connected) c.GetStream().Write(data, 0, data.Length); } catch { }
            }
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            listenThread = new Thread(StartServer) ;
            listenThread.Start();
            rtbLog.AppendText("Server đang lắng nghe...\n");
        }
    }
}
 

