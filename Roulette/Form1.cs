using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Roulette
{
    public partial class Form1 : Form
    {
        List<Stake> stakes = new List<Stake>();
        List<Button> stakebuttons = new List<Button>();
        List<OtherStake> otherstakes = new List<OtherStake>();
        List<Button> otherbuttons = new List<Button>();
        //Stake stake1 = new Stake();
        
        public Form1()
        {
            InitializeComponent();
        }
        public static class Globals
        {
            public static double ticktime1;
            public static int num;
            public static char name;
            public static int laststake = 0;
            public static int gameresult = 0;
            public static int time = 10;
            public static bool game;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(timer1.Interval>=1000)
            {
                timer1.Enabled = false;
                FinalCell();
            }
            else
            {
                GenerateCell();
                timer1.Interval = Convert.ToInt32(timer1.Interval * Globals.ticktime1);
            }
        }

        private void FinalCell()
        {
            int fnum = Convert.ToInt32(button1.Text);
            Color fcolor = button1.BackColor;
            button2.Enabled = true;
            //MessageBox.Show(fnum.ToString());
            foreach (var stake in stakes)
            {
                //MessageBox.Show(stake.number.ToString());
                //MessageBox.Show(stake.color.ToString());
                //MessageBox.Show(stake.stake.ToString());

                if (stake.number == fnum)
                {
                    //MessageBox.Show(stake.number.ToString());
                    textBox1.Text = (Convert.ToInt32(textBox1.Text) + (stake.stake * 35)).ToString();
                    Globals.gameresult += stake.stake * 35;


                }
            }
            foreach(var stake in otherstakes)
            {
                switch(stake.name)
                {
                    case '1':
                        if (fnum%3 == 0 && fnum !=0)
                        {
                            textBox1.Text = (Convert.ToInt32(textBox1.Text) + stake.stake * 3).ToString();
                            Globals.gameresult += stake.stake * 3;
                        }
                        break;
                    case '2':
                        if ((fnum % 3) - 2 == 0 && fnum != 0)
                        {
                            //MessageBox.Show(textBox1.Text);
                            //MessageBox.Show(stake.stake.ToString());
                            //MessageBox.Show((stake.stake * 3).ToString());
                            //MessageBox.Show((Convert.ToInt32(textBox1.Text) + stake.stake * 3).ToString());
                            textBox1.Text = (Convert.ToInt32(textBox1.Text) + stake.stake * 3).ToString();
                            Globals.gameresult += stake.stake * 3;
                        }
                        break;
                    case '3':
                        if ((fnum % 3) - 1 == 0 && fnum != 0)
                        {
                            textBox1.Text = (Convert.ToInt32(textBox1.Text) + stake.stake * 3).ToString();
                            Globals.gameresult += stake.stake * 3;
                        }
                        break;
                    case '4':
                        if (fnum>=1 && fnum <=12)
                        {
                            textBox1.Text = (Convert.ToInt32(textBox1.Text) + stake.stake * 3).ToString();
                            Globals.gameresult += stake.stake * 3;
                        }
                        break;
                    case '5':
                        if (fnum >= 13 && fnum <= 24)
                        {
                            textBox1.Text = (Convert.ToInt32(textBox1.Text) + stake.stake * 3).ToString();
                            Globals.gameresult += stake.stake * 3;
                        }
                        break;
                    case '6':
                        if (fnum >= 25 && fnum <= 36)
                        {
                            textBox1.Text = (Convert.ToInt32(textBox1.Text) + stake.stake * 3).ToString();
                            Globals.gameresult += stake.stake * 3;
                        }
                        break;
                    case '7':
                        if (fnum >= 1 && fnum <= 18)
                        {
                            textBox1.Text = (Convert.ToInt32(textBox1.Text) + stake.stake * 2).ToString();
                            Globals.gameresult += stake.stake * 2;
                        }
                        break;
                    case 'C':
                        if (fnum >= 19 && fnum <= 36)
                        {
                            textBox1.Text = (Convert.ToInt32(textBox1.Text) + stake.stake * 2).ToString();
                            Globals.gameresult += stake.stake * 2;
                        }
                        break;
                    case '8':
                        if (fnum !=0 && fnum % 2==0)
                        {
                            textBox1.Text = (Convert.ToInt32(textBox1.Text) + stake.stake * 2).ToString();
                            Globals.gameresult += stake.stake * 2;
                        }
                        break;
                    case 'B':
                        if (fnum != 0 && fnum % 2 != 0)
                        {
                            textBox1.Text = (Convert.ToInt32(textBox1.Text) + stake.stake * 2).ToString();
                            Globals.gameresult += stake.stake * 2;
                        }
                        break;
                    case '9':
                        if (fcolor == otherbuttons9.BackColor)
                        {
                            textBox1.Text = (Convert.ToInt32(textBox1.Text) + stake.stake * 2).ToString();
                            Globals.gameresult += stake.stake * 2;
                        }
                        break;
                    case 'A':
                        if (fcolor == otherbuttonsA.BackColor)
                        {
                            //MessageBox.Show(textBox1.Text);
                            //MessageBox.Show(stake.stake.ToString());
                            //MessageBox.Show((stake.stake*2).ToString());
                            //MessageBox.Show((Convert.ToInt32(textBox1.Text) + stake.stake * 2).ToString());
                            textBox1.Text = (Convert.ToInt32(textBox1.Text) + stake.stake * 2).ToString();
                            Globals.gameresult += stake.stake * 2;
                        }
                        break;
                    default:MessageBox.Show("Error01");break;
                }
            }

            foreach (var button in otherbuttons)
            {
                OtherStake stake4 = new OtherStake();
                stake4 = otherstakes.Find(x => x.name == Convert.ToChar(button.Name.Remove(0, 12)));
                if(stake4 !=null)
                {
                    button.Text = stake4.text;
                    button.ForeColor = Color.White;
                }
            }
            otherbuttons.Clear();

            foreach (var button in stakebuttons)
            {
                string textnum = button.Name.Remove(0,7);
                button.Text = textnum;
                button.ForeColor = Color.White;
            }
            stakebuttons.Clear();

            otherstakes.Clear();
            stakes.Clear();

            numericUpDown1.Enabled = true;
            groupBox2.Visible = true;

            lastbuttons5.BackColor = lastbuttons4.BackColor;
            lastbuttons5.Text = lastbuttons4.Text;
            if (lastbuttons4.Text != "")
            {
                lastbuttons5.Visible = true;
            }

            lastbuttons4.BackColor = lastbuttons3.BackColor;
            lastbuttons4.Text = lastbuttons3.Text;
            if (lastbuttons4.Text != "")
            {
                lastbuttons4.Visible = true;
            }

            lastbuttons3.BackColor = lastbuttons2.BackColor;
            lastbuttons3.Text = lastbuttons2.Text;
            if (lastbuttons3.Text != "")
            {
                lastbuttons3.Visible = true;
            }


            lastbuttons2.BackColor = lastbuttons1.BackColor;
            lastbuttons2.Text = lastbuttons1.Text;
            if(lastbuttons2.Text !="")
            { 
                lastbuttons2.Visible = true;
            }

            lastbuttons1.BackColor = fcolor;
            lastbuttons1.Text = fnum.ToString();
            lastbuttons1.Visible = true;

            //Результаты

            resultbuttons5.BackColor = resultbuttons4.BackColor;
            resultbuttons5.Text = resultbuttons4.Text;
            if (resultbuttons5.Text != "")
            {
                resultbuttons4.Visible = true;
            }

            resultbuttons4.BackColor = resultbuttons3.BackColor;
            resultbuttons4.Text = resultbuttons3.Text;
            if (resultbuttons4.Text != "")
            {
                resultbuttons4.Visible = true;
            }

            resultbuttons3.BackColor = resultbuttons2.BackColor;
            resultbuttons3.Text = resultbuttons2.Text;
            if (resultbuttons3.Text != "")
            {
                resultbuttons3.Visible = true;
            }


            resultbuttons2.BackColor = resultbuttons1.BackColor;
            resultbuttons2.Text = resultbuttons1.Text;
            if (resultbuttons2.Text != "")
            {
                resultbuttons2.Visible = true;
            }

            if(Globals.gameresult>0)
            {
                resultbuttons1.BackColor = Color.Green;
                resultbuttons1.Text = "В";
            }
            else
            {
                if(Globals.gameresult<0)
                {
                    resultbuttons1.BackColor = Color.Red;
                    resultbuttons1.Text = "П";
                }
                else
                {
                    resultbuttons1.BackColor = Color.Yellow;
                    resultbuttons1.Text = "——";
                }
            }
            lastbuttons1.Visible = true;


            Globals.gameresult = 0;


            if(автоиграToolStripMenuItem1.Checked)
            {
                label3.Text = $"Секунд до начала игры: {Globals.time}";
                label3.Font = new Font("", 12);
                label3.Location = new System.Drawing.Point(Convert.ToInt32((groupBox2.Location.X + groupBox3.Location.X + groupBox3.Size.Width) / 2 - Convert.ToInt32(button2.Size.Width / 2)), groupBox2.Location.Y + Size.Height * 15 / 720);
                progressBar1.Visible = true;
                timer2.Enabled = true;
            }

            Globals.game = false;
        }

        private void GenerateCell()
        {

            numericUpDown1.Enabled = false;
            var rand = new Random();
            Globals.num = rand.Next(0, 36);
            button1.Text = Globals.num.ToString();
            List<int> reds = new List<int> {1,3,5,7,9,12,14,16,18,19,21,23,25,27,30,32,34,36};
            List<int> blacks = new List<int> {2,4,6,8,10,11,13,15,17,20,22,24,26,28,29,31,33,35};
            
            if(Globals.num == 0)
            {
                button1.BackColor = buttons0.BackColor;
            }
            else
            {
                if (reds.Contains(Globals.num))
                {
                    button1.BackColor = otherbuttons9.BackColor;
                }
                else
                {
                    if (blacks.Contains(Globals.num))
                    {
                        button1.BackColor = otherbuttonsA.BackColor;
                    }
                    else
                    {
                        MessageBox.Show("Error00");
                    }
                }
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            Buttron2PerformClick();
        }

        private void пополнениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Owner = this;
            form2.ShowDialog();
            //this.textBox1.Text = form2.Data.Trim();

        }

        private void выводToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Owner = this;
            form3.ShowDialog();
        }

        private void buttons_Click(object sender, EventArgs e)
        {
                var button = new Button();
                button = sender as Button;
            if ((numericUpDown1.Enabled == true)&&((numericUpDown1.Value > 0) && (Convert.ToInt32(textBox1.Text)-numericUpDown1.Value >= 0)) || (button.Text == "●"))
            {
                if (button.Text != "●")
                {
                    Globals.gameresult -= Convert.ToInt32(numericUpDown1.Value);

                    textBox1.Text = (Convert.ToInt32(textBox1.Text) - Convert.ToInt32(numericUpDown1.Value)).ToString();
                    int number = Convert.ToInt32(button.Text);
                    //MessageBox.Show(button.Text);
                    button.Text = "●";
                    button.ForeColor = Color.Yellow;
                    //button.Enabled = false;

                    Stake stake1 = new Stake();
                    stake1.number = number;
                    stake1.color = button.BackColor;
                    stake1.stake = Convert.ToInt32(numericUpDown1.Value);
                    stakes.Add(stake1);
                    stakebuttons.Add(button);

                    //foreach (var stake in stakes)
                    //{
                    //    MessageBox.Show(stake.number.ToString());
                    //    MessageBox.Show(stake.color.ToString());
                    //    MessageBox.Show(stake.stake.ToString());
                    //}


                }
                else
                {
                    Stake stake2 = new Stake();
                    stake2 = stakes.Find(x=>x.number == Convert.ToInt32(button.Name.Remove(0,7)));
                    button.BackColor = stake2.color;
                    button.ForeColor = Color.White;
                    button.Text = stake2.number.ToString();
                    stakes.Remove(stake2);
                    textBox1.Text = (Convert.ToInt32(textBox1.Text) + Convert.ToInt32(stake2.stake)).ToString();
                    Globals.gameresult += Convert.ToInt32(stake2.stake);
                }
            }
            else
            {
                if(numericUpDown1.Value ==0)
                {
                    MessageBox.Show("Ставка не выбрана");
                }
                else 
                {
                    if(numericUpDown1.Enabled == false)
                    {
                        MessageBox.Show("Разыгровка уже началась, ставки запрещены.");
                    }
                    else
                    {
                        MessageBox.Show("Недостаточно средств!");
                    }
                }
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
        }

        private void otherbuttons_Click(object sender, EventArgs e)
        {
                var button = new Button();
                button = sender as Button;
            if ((numericUpDown1.Enabled == true) && ((numericUpDown1.Value > 0) && (Convert.ToInt32(textBox1.Text) - numericUpDown1.Value >= 0)) || (button.Text == "●"))
            {

                if (button.Text != "●")
                {
                    Globals.gameresult -= Convert.ToInt32(numericUpDown1.Value);

                    textBox1.Text = (Convert.ToInt32(textBox1.Text) - Convert.ToInt32(numericUpDown1.Value)).ToString();

                    Globals.name = Convert.ToChar(button.Name.Remove(0, 12));

                    OtherStake otherstake = new OtherStake();
                    otherstake.text = button.Text;
                    otherstake.name = Globals.name;
                    otherstake.stake = Convert.ToInt32(numericUpDown1.Value);
                    otherstakes.Add(otherstake);
                    otherbuttons.Add(button);

                    button.Text = "●";
                    button.ForeColor = Color.Yellow;
                }
                else
                {
                    OtherStake stake3 = new OtherStake();
                    stake3 = otherstakes.Find(x => x.name == Convert.ToChar(button.Name.Remove(0, 12)));
                    button.ForeColor = Color.White;
                    button.Text = stake3.text;
                    otherstakes.Remove(stake3);
                    textBox1.Text = (Convert.ToInt32(textBox1.Text) + Convert.ToInt32(stake3.stake)).ToString();
                    Globals.gameresult += Convert.ToInt32(stake3.stake);
                }
            }
            else 
            {
                if (numericUpDown1.Value == 0)
                {
                    MessageBox.Show("Ставка не выбрана");
                }
                else
                {
                    if (numericUpDown1.Enabled == false)
                    {
                        MessageBox.Show("Разыгровка уже началась, ставки запрещены.");
                    }
                    else
                    {
                        MessageBox.Show("Недостаточно средств!");
                    }
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(textBox1.Text.ToString());
            if(!string.IsNullOrEmpty(textBox1.Text))
            {
                if(Convert.ToInt32(textBox1.Text)>61356675)
                {
                    groupBox1.Enabled = false;
                    пополнениеToolStripMenuItem.Enabled = false;
                }
                if (Convert.ToInt32(textBox1.Text) > 0)
                {
                    выводToolStripMenuItem.Enabled = true;
                }
                else
                {
                    выводToolStripMenuItem.Enabled = false;
                }
            }

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            AutoLocation();
        }
        public void AutoLocation()
        {
            button1.Location = new System.Drawing.Point(Size.Width * 50/1280,  Size.Height *120/720);
            groupBox1.Location = new System.Drawing.Point(Size.Width - (Size.Width*900/1280), Size.Height * 115 / 720);
            textBox1.Location = new System.Drawing.Point(Size.Width - (Size.Width*30/1280)-100,30);
            label1.Location = new System.Drawing.Point(textBox1.Location.X - Size.Width*120/1280,30);
            numericUpDown1.Location = new System.Drawing.Point(Size.Width - (Size.Width * 30 / 1280) - 100, groupBox2.Location.Y  - Size.Height * 100/720);
            label2.Location = new System.Drawing.Point(numericUpDown1.Location.X - Size.Width*120/1280,  groupBox2.Location.Y - Size.Height * 100/ 720 );
            stakemulbutton1.Location = new System.Drawing.Point(label2.Location.X,label2.Location.Y + 30);
            stakemulbutton2.Location = new System.Drawing.Point(stakemulbutton1.Location.X+ stakemulbutton1.Size.Width  + Convert.ToInt32((numericUpDown1.Location.X + numericUpDown1.Size.Width - label2.Location.X-4*stakemulbutton1.Size.Width) / 3), stakemulbutton1.Location.Y);
            stakemulbutton3.Location = new System.Drawing.Point(stakemulbutton2.Location.X + stakemulbutton2.Size.Width + Convert.ToInt32((numericUpDown1.Location.X + numericUpDown1.Size.Width - label2.Location.X - 4 * stakemulbutton1.Size.Width) / 3), stakemulbutton1.Location.Y);
            stakemulbutton4.Location = new System.Drawing.Point(stakemulbutton3.Location.X + stakemulbutton3.Size.Width + Convert.ToInt32((numericUpDown1.Location.X + numericUpDown1.Size.Width - label2.Location.X - 4 * stakemulbutton1.Size.Width) / 3), stakemulbutton1.Location.Y);
            //stakemulbutton4.Location = new System.Drawing.Point(stakemulbutton3.Location.X + 51, stakemulbutton3.Location.Y);
            button2.Location = new System.Drawing.Point(Convert.ToInt32((groupBox2.Location.X+groupBox3.Location.X+groupBox3.Size.Width)/2-Convert.ToInt32(button2.Size.Width/2)), groupBox2.Location.Y);
            groupBox2.Location = new System.Drawing.Point(Size.Width - (Size.Width * 30 / 1280) - 323,  Size.Height * 550 / 720);
            groupBox3.Location = new System.Drawing.Point(Size.Width * 30 / 1280, Size.Height * 550 / 720);
            label3.Location = new System.Drawing.Point(Convert.ToInt32((groupBox2.Location.X + groupBox3.Location.X + groupBox3.Size.Width) / 2 - Convert.ToInt32(button2.Size.Width / 2)), groupBox2.Location.Y + Size.Height * 15/720);
            progressBar1.Location = new System.Drawing.Point(Convert.ToInt32((groupBox2.Location.X + groupBox3.Location.X + groupBox3.Size.Width) / 2 - Convert.ToInt32(button2.Size.Width / 2)), groupBox2.Location.Y + Size.Height * 50 / 720);
            //foreach (Control control in groupBox1.Controls)
            //{

            //}
            //button1.Size = new System.Drawing.Size(Size.Width*250/1280, Size.Height*250/720);
            //groupBox1.Size = new System.Drawing.Size(Size.Width * 700 / 1280, Size.Height * 250 / 720);
            //label1.Size = 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = Convert.ToInt32(numericUpDown1.Value / 3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = Convert.ToInt32(numericUpDown1.Value / 2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(numericUpDown1.Value<=50000)
            {
                numericUpDown1.Value = Convert.ToInt32(numericUpDown1.Value * 2);
            }
            else 
            {
                MessageBox.Show("Максимальная ставка 100000");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value <=33333) 
            {
                numericUpDown1.Value = Convert.ToInt32(numericUpDown1.Value * 3);
            }
            else
            {
                MessageBox.Show("Максимальная ставка 100000");
            }
        }

        private void режимToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            режимToolStripMenuItem.ForeColor = режимToolStripMenuItem.BackColor;
        }

        private void режимToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            режимToolStripMenuItem.ForeColor = Color.White;
        }

        private void ручнойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ручнойToolStripMenuItem.Checked = true;
            автоиграToolStripMenuItem1.Checked = false;
            button2.Visible = true;
            label3.Visible = false;
            progressBar1.Visible = false;
            timer2.Enabled = false;
            progressBar1.Value = 100;

        }

        private void автоиграToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Globals.game)
            {
                label3.Text = "Розыгрыш начался!";
                label3.Font = new Font("",16);
                label3.Location = new System.Drawing.Point(Convert.ToInt32((groupBox2.Location.X + groupBox3.Location.X + groupBox3.Size.Width) / 2 - Convert.ToInt32(button2.Size.Width / 2)), groupBox3.Location.Y + groupBox3.Size.Height / 2 - label3.Size.Height / 2);
                progressBar1.Visible = false;
            }
            else 
            {
                if(!автоиграToolStripMenuItem1.Checked)
                { 
                Globals.time = 10;
                    label3.Font = new Font("", 12);
                    label3.Text = $"Секунд до начала игры: {Globals.time}";
                    label3.Location = new System.Drawing.Point(Convert.ToInt32((groupBox2.Location.X + groupBox3.Location.X + groupBox3.Size.Width) / 2 - Convert.ToInt32(button2.Size.Width / 2)), groupBox2.Location.Y + Size.Height * 15 / 720);
                    progressBar1.Value = 100;
                progressBar1.Visible = true;
                }
            }

            label3.Visible = true;
            ручнойToolStripMenuItem.Checked = false;
            автоиграToolStripMenuItem1.Checked = true;
            button2.Visible = false;
            if(!timer1.Enabled)
            {
                timer2.Enabled = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value%10==0)
            {
                label3.Text = $"Секунд до начала игры: {Globals.time}"; //Секунд до начала игры: 10 
                Globals.time--;
            }
            if(progressBar1.Value>0)
            {
                progressBar1.Value -= 1;
            }
            else
            {
                Buttron2PerformClick();
                progressBar1.Visible=false;
                label3.Text = "Розыгрыш начался!"; //Розыгрыш начался!
                label3.Font = new Font("", 16);
                label3.Location = new System.Drawing.Point(Convert.ToInt32((groupBox2.Location.X + groupBox3.Location.X + groupBox3.Size.Width) / 2 - Convert.ToInt32(button2.Size.Width / 2)),groupBox3.Location.Y+groupBox3.Size.Height/2-label3.Size.Height/2);
                progressBar1.Value = 100;
            }
        }
        public void Buttron2PerformClick()
        {
            Globals.game = true;
            timer2.Enabled = false;
            Globals.time = 10;
            int fnum = 0;
            if (button1.Text != "")
            {
                fnum = Convert.ToInt32(button1.Text);
                Color fcolor = button1.BackColor;
            }

            button2.Enabled = false;
            //textBox1.Text = (Convert.ToInt32(textBox1.Text) - Convert.ToInt32(numericUpDown1.Value)).ToString();
            var rand2 = new Random();
            int startinterval = rand2.Next(10, 20);
            timer1.Interval = startinterval;
            Globals.ticktime1 = 1 + ((rand2.Next(5, 20)) * 0.010);
            timer1.Enabled = true;
            //MessageBox.Show(Globals.ticktime1.ToString());
            //MessageBox.Show(startinterval.ToString());
        }

        public string ReadBalance()
        {
            string balance = "0";
            string balancepath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\Roulette";
            string balancefilepath = balancepath + "\\Balance.txt";
            if(File.Exists(balancefilepath))
            {
                if(!string.IsNullOrEmpty(File.ReadAllText(balancefilepath)))
                {
                    balance = File.ReadAllText(balancefilepath);
                }
                
                //StreamReader reader = new StreamReader(balancefilepath);
                //if (!string.IsNullOrEmpty(reader.ReadToEnd()))
                //{
                //    balance = reader.ToString();
                //}
                //reader.Close();
            }
            else
            {
                if(!Directory.Exists(balancepath))
                { 
                    Directory.CreateDirectory(balancepath);
                }
                using (File.Create(balancefilepath));

            }
            return balance;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string balancepath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Roulette";
            string balancefilepath = balancepath + "\\Balance.txt";

            File.WriteAllText(balancefilepath, textBox1.Text);
            //StreamWriter writer = new StreamWriter(balancefilepath,false);
            //writer.Write(textBox1.Text);
            //writer.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AutoLocation();
            textBox1.Text = ReadBalance();
        }
    }

    public class Stake
    {
        public int number;
        public Color color;
        public int stake;
    }
    public class OtherStake
    {
        public char name;
        public int stake;
        public string text;
    }
}