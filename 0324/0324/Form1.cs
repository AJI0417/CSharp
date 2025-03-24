using Microsoft.VisualBasic.PowerPacks;
using System;
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

namespace _0324
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const int port = 2025;
        bool flag = false;
        Thread Th = null;
        UdpClient U = null;

        Point stP;
        string P_record = string.Empty;
        ShapeContainer Local = null;
        ShapeContainer Remote = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            Local = new ShapeContainer();
            Remote = new ShapeContainer();
            pictureBox1.Controls.Add(Local);
            pictureBox2.Controls.Add(Remote);

            CheckForIllegalCrossThreadCalls = false;
            Th = new Thread(Listen);
            Th.Start();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            stP = e.Location;
            P_record = stP.X.ToString() + "," + stP.Y.ToString();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                LineShape L = new LineShape();
                L.StartPoint = stP;
                L.EndPoint = e.Location;
                L.Parent = Local;
                stP = e.Location;
                P_record +="/" + stP.X.ToString() + "," + stP.Y.ToString();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            using(UdpClient S = new UdpClient(textBox1.Text, port))
            {
                byte[] B = Encoding.Default.GetBytes(P_record);
                S.Send(B,B.Length);
            }
        }

        private void Listen()
        {
            U = new UdpClient(port);
            IPEndPoint EP = new IPEndPoint(IPAddress.Loopback,port);
            flag = true;
            while (flag)
            {
                byte[] B = U.Receive(ref EP);
                string A = Encoding.Default.GetString(B);
                string[] Gvp = A.Split('/');
                Point[] Rec = new Point[Gvp.Length];

                for(int i = 0; i < Gvp.Length; i++)
                {
                    string[] tmp = Gvp[i].Split(',');
                    Rec[i].X = Convert.ToInt32(tmp[0]);
                    Rec[i].Y = Convert.ToInt32(tmp[1]);
                }

                for(int i = 0;i < Gvp.Length-1;i++)
                {
                    LineShape L = new LineShape();
                    L.StartPoint = Rec[i];
                    L.EndPoint = Rec[i + 1];
                    L.Parent = Remote;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            flag = false;
            Th.Abort();
            U.Close();
        }
    }
}
