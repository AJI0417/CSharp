using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;

namespace GoServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TcpListener Server;
        Socket Client;
        Thread Th_Svr;
        Thread Th_Clt;
        Dictionary <string,Socket> HT = new Dictionary <string,Socket> ();

        private string OnlineList()
        {
            string L = "L";
            for(int i = 0; i<listBox1.Items.Count; i++)
            {
                L += listBox1.Items[i];
                if(i < listBox1.Items.Count - 1)
                {
                    L += ",";
                }
            }
            return L;
        }

        private void SendTo(string Str,string User)
        {
            byte[] B = Encoding.Default.GetBytes (Str);
            Socket Sck = HT[User];
            Sck.Send (B,0,B.Length,SocketFlags.None);
        }

        private void SendAll(string Str)
        {
            byte[] B = Encoding .Default.GetBytes (Str);
            foreach(var item in HT.Values)
            {
                item.Send(B,0,B.Length,SocketFlags.None);
            }
        }

        private void Listen()
        {
            Socket Sck = Client;
            Thread Th = Th_Clt;
            while(true)
            {
                try
                {
                    byte[] B = new byte[1024];
                    int B_Length = Sck.Receive(B);
                    string Msg = Encoding.Default.GetString (B,0,B_Length);
                    string Cmd = Msg.Substring(0, 1);
                    string Str = Msg.Substring(1);
                    switch(Cmd)
                    {
                        case "0": //Add User
                            HT.Add(Str, Sck);
                            listBox1.Items.Add(Str);
                            SendAll(OnlineList());
                            break;
                        case "9": //Delate User
                            HT.Remove(Str);
                            listBox1.Items.Remove(Str);
                            Th.Abort();
                            break;
                        case "1": //User sends Msg to everyone
                            SendAll(Msg);
                            break;
                        default:  //User send secreat msg
                            string[] C = Str.Split('|');
                            SendTo(Cmd + C[0], C[1]);
                            break;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void ServerMethod()
        {
            IPEndPoint EP = new IPEndPoint(IPAddress.Parse(TxtBoxIP.Text),int.Parse(TxtBoxPort.Text));
            Server = new TcpListener(EP);
            Server.Start(100);
            while (true)
            {
                Client = Server.AcceptSocket();
                Th_Clt = new Thread(Listen);
                Th_Clt.IsBackground = true;
                Th_Clt.Start();
            }
        }

        private void BtnStartServer_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Th_Svr = new Thread(ServerMethod);
            Th_Svr.IsBackground = true;
            Th_Svr.Start();
            BtnStartServer.Enabled = false;
        }
    }
}
