using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0303
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num;
            string textboxVal = textBox1.Text;
            num = Int32.Parse(textboxVal);

            for (int i = 0; i <= num; i++)
            {
                if (i % 2 == 0)
                {
                    listBox1.Items.Add(i);
                }
            }


            for (int i = 0; i <= num; i++)
            {
                if (i % 2 != 0)
                {
                    listBox2.Items.Add(i);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string tmp = "11227058謝祥立\n" + DateTime.Now.ToString();
            label2.Text = this.Text = tmp;
        }

        // 當 ListBox1 中的項目選擇發生變化時
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateSum();
        }

        // 當 ListBox2 中的項目選擇發生變化時
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateSum();
        }

        // 計算選中項目的和
        private void CalculateSum()
        {
            // 檢查 ListBox1 和 ListBox2 都有選中項目
            if (listBox1.SelectedItem != null && listBox2.SelectedItem != null)
            {
                // 取得選中的數字
                int value1 = Convert.ToInt32(listBox1.SelectedItem);
                int value2 = Convert.ToInt32(listBox2.SelectedItem);

                // 計算兩個數字的和
                int sum = value1 + value2;

                // 顯示結果
                label1.Text = sum.ToString();
            }
        }
    }
}
