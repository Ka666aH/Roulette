using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Roulette
{
    public partial class Form2 : Form
    {
        int laginterval;
        int lagplace;
        string balance;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            var rand = new Random();
            laginterval = rand.Next(500, 1000);
            lagplace = rand.Next(10, 80);
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
            maskedTextBox1.Visible = false;
            maskedTextBox2.Visible = false;
            maskedTextBox3.Visible = false;
            maskedTextBox4.Visible = false;
            maskedTextBox5.Visible = false;
            button1.Visible = false;
            label6.Visible = true;
            progressBar1.Visible = true;
        }
        //public string Data
        //{
        //    get
        //    {
        //        return maskedTextBox5.Text;
        //    }
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            var rand2 = new Random();
            int randinterval = rand2.Next(50, 200);
            timer1.Interval = randinterval;
            if (progressBar1.Value == lagplace)
            {
                timer1.Interval = laginterval;
                progressBar1.Value += 5;
            }
            else
            {
                if (progressBar1.Value == 100)
                {
                    timer1.Enabled = false;
                    progressBar1.Value = 0;

                    Form1 main = this.Owner as Form1;
                    if (main != null && (Convert.ToInt32(main.textBox1.Text) + Convert.ToInt32(Convert.ToInt32(balance) * 0.95))<=int.MaxValue)
                    {
                        main.textBox1.Text = (Convert.ToInt32(main.textBox1.Text) + Convert.ToInt32(Convert.ToInt32(balance) * 0.95)).ToString();
                    }
                    Close();
                }
                else
                {
                    progressBar1.Value += 5;
                }
            }
        }

        private void maskedTextBox5_TextChanged(object sender, EventArgs e)
        {

            balance = string.Empty;
            if(!string.IsNullOrEmpty(maskedTextBox5.Text))
            {
                //input = int.TryParse(maskedTextBox5.Text.Last().ToString(),out int result);
                //if (input)
                //{
                //    balance += result.ToString();
                //}
                //else
                //{
                //    maskedTextBox5.Text = balance;
                //}
                foreach(char c in maskedTextBox5.Text)
                {                    
                    bool input = int.TryParse(c.ToString(),out int result);
                    if (input)
                    {
                        //MessageBox.Show(maskedTextBox5.Text.Last().ToString());
                        balance += result.ToString();
                    }
                }
                maskedTextBox5.Text = balance;
                if (!string.IsNullOrEmpty(balance))
                {
                    button1.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                }
            }
            else
            {
                button1.Enabled = false;
            }
        }
        private void textBox1_Enter(Object sender, System.EventArgs e)
        {
            maskedTextBox5.SelectionStart = 0;
        }
    }
}
