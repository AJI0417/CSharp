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

namespace _0421C
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        Socket T = null;
        string user = string.Empty;

        private void Send(string Str)
        {
            byte[] B = Encoding.Default.GetBytes(Str);
            T.Send(B,0,B.Length,SocketFlags.None);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPEndPoint EP = new IPEndPoint(IPAddress.Parse(textBox2.Text),int.Parse(textBox3.Text));
            T = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
            user = textBox1.Text;
            try
            {
                T.Connect(EP);
                Send("0" + user);
            }
            catch
            {
                MessageBox.Show("Server Error!!!");
                return;
            }

            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Send("9"+user);
            T.Close();
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(button2.Enabled == true)
            {
                Send("9"+user);
                T.Close();
            }
        }
    }
}
