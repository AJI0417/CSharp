using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0421
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        TcpListener Server = null;
        Socket Client = null;

        Thread Th_Svr = null;
        Thread Th_Clt = null;
        Hashtable HT = new Hashtable();


        private void ServerMethod()
        {
            IPEndPoint EP = new IPEndPoint(IPAddress.Parse(textBox1.Text), int.Parse(textBox2.Text));
            Server = new TcpListener(EP);
            Server.Start(100);
            while (true)
            {
                Client = Server.AcceptSocket();
                Th_Clt = new Thread(Listen);
                Th_Clt.Name = "t" + DateTime.Now.ToString();
                Th_Clt .Start();
            }
        }

        private void Listen()
        {
            Socket Sck = Client;
            Thread Th = Th_Clt;
            while (true)
            {
                try
                {
                    byte[] B = new byte[512];
                    int len = Sck.Receive(B);
                    string Msg = Encoding.Default.GetString(B, 0, len);
                    string Cmd = Msg.Substring(0, 1);
                    string Str = Msg.Substring(1);

                    switch (Cmd)
                    {
                        case "0":   //login
                            HT.Add(Str, Sck);
                            listBox1.Items.Add(Str);
                            break;
                        case "9":
                            HT.Remove(Str);
                            listBox1.Items.Remove(Str);
                            Th.Abort();
                            break;
                        default:
                            break;
                    }
                }catch{}
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Th_Svr = new Thread(ServerMethod);
            Th_Svr.IsBackground = true;
            Th_Svr.Start();
        }
    }
}
