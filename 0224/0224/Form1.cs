using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _0224
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double num1 = 0;
            double num2 = 0;
            double result = 0;

            bool num1ok = double.TryParse(textBox1.Text, out num1);
            bool num2ok = double.TryParse(textBox2.Text, out num2);

            if (num1ok && num2ok)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        result = num1 + num2;
                        break;
                    case 1:
                        result = num1 - num2;
                        break;
                    case 2:
                        result = num1 * num2;
                        break;
                    case 3:
                        result = num1 / num2;
                        break;
                    case 4:
                        result = num1 % num2;
                        break;
                    default:
                        break;
                }

                label1.Text = result.ToString();
            }
            else
            {
                MessageBox.Show("輸入錯誤");
            }
        }

        private bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }
            for(int i = 2; i <= Math.Sqrt(number); i++)
            {
                if(number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int num = 0;
            if(!int.TryParse(textBox3.Text, out num) || num < 1)
            {
                MessageBox.Show("Fail");
            }
            else
            {
                for(int i = 2; i <= num; i++)
                {
                    if(IsPrime(i))
                    {
                        listBox1.Items.Add(i);
                    }
                }
            }
        }

        List<int> numlist = new List<int>();
        private void button3_Click(object sender, EventArgs e)
        {
            numlist.Add(int.Parse(textBox4.Text));
            listBox2.Items.Add(textBox4.Text);
            textBox4.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            numlist.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(numlist.Average().ToString());
        }
    }

}
