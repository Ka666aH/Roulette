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

namespace Roulette
{
    public partial class Form3 : Form
    {
        int laginterval;
        int lagplace;
        string balance= string.Empty;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            Form1 main = this.Owner as Form1;
            if (main != null && Convert.ToInt32(main.textBox1.Text) >= Convert.ToInt32(maskedTextBox5.Text) && (Convert.ToInt32(main.textBox1.Text) - Convert.ToInt32(maskedTextBox5.Text))>=int.MinValue)
            {
                label1.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                maskedTextBox1.Visible = false;
                maskedTextBox2.Visible = false;
                maskedTextBox5.Visible = false;
                button1.Visible = false;
                timer1.Enabled = true;
                label2.Visible = true;
                progressBar1.Visible = true;
                var rand = new Random();
                laginterval = rand.Next(1000, 5000);
                lagplace = rand.Next(10, 80);
                if (Convert.ToInt32(maskedTextBox2.Text) > 0)
                {
                    main.textBox1.Text = (Convert.ToInt32(main.textBox1.Text) - Convert.ToInt32(maskedTextBox5.Text)).ToString();
                }
                else
                {
                    main.textBox1.Text = (Convert.ToInt32(main.textBox1.Text) - Convert.ToInt32(maskedTextBox5.Text) + Convert.ToInt32(maskedTextBox2.Text)).ToString();
                }
            }
            else
            {
                MessageBox.Show("Недостаточно средств на балансе!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var rand2 = new Random();
            int randinterval = rand2.Next(50, 200);
            timer1.Interval = randinterval;
            if (progressBar1.Value == lagplace)
            {
                timer1.Interval = laginterval;
                progressBar1.Value += 1;
            }
            else
            {
                if (progressBar1.Value < 90)
                {
                    progressBar1.Value += 1;

                }
                else
                {
                    progressBar1.Value = 0;
                    progressBar1.Visible = false;
                    label2.Text = "Ошибка платёжной системы. Повторите попытку позже.";
                    label2.Font = new Font("Microsoft Sans Serif", 7);
                    label2.Location = new Point(0, 75);
                    //Платёж обрабатывается...
                    button2.Visible = true;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void maskedTextBox5_TextChanged(object sender, EventArgs e)
        {
            //if(maskedTextBox5.Text != "")
            //{
            //    maskedTextBox2.Text = (Convert.ToInt32(Convert.ToInt32(maskedTextBox5.Text) * 0.95 - 50)).ToString();
            //}
            //else
            //{
            //    maskedTextBox2.Text = "";
            //}
            balance = string.Empty;
            if (!string.IsNullOrEmpty(maskedTextBox5.Text))
            {
                foreach (char c in maskedTextBox5.Text)
                {
                    bool input = int.TryParse(c.ToString(), out int result);
                    if (input)
                    {
                        //MessageBox.Show(maskedTextBox5.Text.Last().ToString());
                        balance += result.ToString();
                    }
                }
                maskedTextBox5.Text = balance;

                if (!string.IsNullOrEmpty(balance))
                {
                    //MessageBox.Show((Convert.ToInt32(balance) * 0.95).ToString());
                    //MessageBox.Show((Convert.ToInt32(Convert.ToInt32(balance) * 0.95 - 50)).ToString());
                    maskedTextBox2.Text = (Convert.ToInt32(Convert.ToInt32(balance) * 0.95 - 50)).ToString();
                    button1.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                }

            }
            else
            {
                maskedTextBox2.Text = string.Empty;
                button1.Enabled = false;
            }
        }
        private void textBox1_Enter(Object sender, System.EventArgs e)
        {
            maskedTextBox5.SelectionStart = 0;
        }
    }
}
