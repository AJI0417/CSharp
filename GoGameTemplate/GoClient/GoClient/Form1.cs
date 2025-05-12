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
using Microsoft.VisualBasic.PowerPacks;

namespace GoClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Socket T;
        Thread Th;
        string User;
        ShapeContainer Cvs;
        byte[,] S;

        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap bg = new Bitmap(570, 570);
            Graphics  g = Graphics.FromImage(bg);
            g.Clear(Color.White);
            //畫19條垂直線
            for (int i = 15; i <= 555; i += 30)
            {
                g.DrawLine(Pens.Black, i, 15, i, 555);
            }
            //畫19條水平線
            for (int j = 15; j <= 555; j += 30)
            {
                g.DrawLine(Pens.Black, 15, j, 555, j);
            }
            panel1.BackgroundImage = bg;
            Cvs = new ShapeContainer();
            panel1.Controls.Add(Cvs);
            S = new byte[19,19];
        }

        private bool chk5(int i,int j,byte tg)
        {
            int n = 0;
            int ii = 0;
            int jj = 0;

            //水平
            for (int k = -4; k <= 4; k++)
            {
                ii = i + k;
                if(ii >= 0 && ii <= 19)
                {
                    if (S[ii,j] == tg) {

                        n += 1;

                        if(n == 5)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        n = 0;
                    }
                }
            }
            //垂直
            n = 0;
            for (int k = -4; k <= 4; k++)
            {
                jj = j + k;
                if (jj >= 0 && jj <= 19)
                {
                    if (S[i, jj] == tg)
                    {

                        n += 1;

                        if (n == 5)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        n = 0;
                    }
                }
            }
            //左上到右下
            n = 0;
            for (int k = -4; k <= 4; k++)
            {
                ii = i + k;
                jj = j + k;
                if (ii >= 0 && ii <= 19 && jj >= 0 && jj <= 19)
                {
                    if (S[ii, jj] == tg)
                    {

                        n += 1;

                        if (n == 5)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        n = 0;
                    }
                }
            }
            //右上到左下
            n = 0;
            for (int k = -4; k <= 4; k++)
            {
                ii = i - k;
                jj = j + k;
                if (ii >= 0 && ii <= 19 && jj >= 0 && jj <= 19)
                {
                    if (S[ii, jj] == tg)
                    {

                        n += 1;

                        if (n == 5)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        n = 0;
                    }
                }
            }
            return false;
        }

        private void Chess(int i,int j, Color BW)
        {
            OvalShape C = new OvalShape();
            C.Width = 26;
            C.Height = 26;
            C.Left = i * 30 + 2;
            C.Top = j * 30 + 2;
            C.FillStyle = FillStyle.Solid;
            C.FillColor = BW;
            C.Parent = Cvs;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            int i = e.X / 30;
            int j = e.Y / 30;

            if (S[i,j] == 0)
            {
                Chess(i,j,Color.Black);
                S[i,j] = 1;
                if (listBox1.SelectedIndex >= 0)
                {
                    //todo:傳棋格狀態
                }
                if (chk5(i, j, 1))
                {
                    MessageBox.Show("You Win!!!");
                }
            }
        }
    }
}
