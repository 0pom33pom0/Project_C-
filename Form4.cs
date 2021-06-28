using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Project_job
{
    public partial class Form4 : Form
    {
        private readonly Random random = new Random();
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"D:\w2\c#\Project_job\Project_job\Resources\ซาว3.wav");
        public Form4()
        {
            InitializeComponent();
        }
        int i, j, num_1, num_2, answer, chek=0, cx = 0, cy = 0, time=40,ch=0;
        int[] num = { 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] ch_button = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private void Form4_Load(object sender, EventArgs e)
        {
            BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\background\" + Program.tool + ".jpg");
            Program.score = 0;
            player.Play();
            string a = $"{Program.tool}.png";
            guna2PictureBox2.Image = Image.FromFile(@"D:\w2\c#\Project_job\tool\" + a);

            if (Program.tool <= 2)
            {
                for ( i = 1; i <= 8; i++)
                {
                    Control control = Controls["number" + i];
                    num[i - 1] = random.Next(20);
                    control.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[i - 1] + ".png");
                }
            }
            else if (Program.tool == 3)
            {
                for (i = 1; i <= 8; i++)
                {
                    Control control = Controls["number" + i];
                    num[i - 1] = random.Next(12);
                    control.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[i - 1] + ".png");
                }
            }
            else
            {
                j = 1;
                while (j <= 8)
                {
                    num[j - 1] = random.Next(1,30);
                    if (num[j - 1] % 2 == 0 || num[j - 1]==1)
                    {
                        Control control = Controls["number" + j];
                        control.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[j - 1] + ".png");
                        j += 1;
                    }
                }
            }

            answer_f();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(dispatTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            timer.Start();
            DispatcherTimer music = new DispatcherTimer();
            music.Tick += new EventHandler(music_p);
            music.Interval = new TimeSpan(0, 0, 2, 26, 0);
            music.Start();
        }
        private void answer_f()//กำหนดค่าของคำตอบ
        {
            j = 0;
            while (j < 1)
            {
                int n1 = random.Next(7);
                int n2 = random.Next(7);
                if (n1 != n2)
                {
                    switch (Program.tool)
                    {
                        case 1:
                            answer = num[n1] + num[n2];
                            j = 10;
                            break;
                        case 2:
                            if (num[n1] >= num[n2])
                            {
                                answer = num[n1] - num[n2];
                                j = 10;
                            }
                            break;
                        case 3:
                            answer = num[n1] * num[n2];
                            j = 10;
                            break;
                        case 4:
                            if(num[n1] >= num[n2])
                            {
                                if(num[n1] % num[n2] == 0)
                                {
                                    answer = num[n1] / num[n2];
                                    j = 10;
                                }
                            }
                            break;
                    }
                    if (j == 10)
                    {
                        answerButton.Text = $"{answer}";
                    }
                }
            }
        }
        private void chekanswer()//ตรวจคำตอบและเป็นตัวเลขที่เลือก
        {
            Program.score += 1;
            score_l.Text = $"{Program.score}";
            answerButton.FillColor = Color.LimeGreen;
            DispatcherTimer timer_2 = new DispatcherTimer();
            timer_2.Tick += new EventHandler(color_m);
            timer_2.Interval = new TimeSpan(0, 0, 0, 0, 600);
            timer_2.Start();
            
            time = time + 5;
            num[cx - 1] = random.Next(20);
            Control control = Controls["number" + cx];
            control.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[cx - 1] + ".png");
            num[cy - 1] = random.Next(20);
            Control control_2 = Controls["number" + cy];
            control_2.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[cy - 1] + ".png");

            answer_f();

            for (i = 1; i <= 8; i++)
            {
                ch_button[i] = 0;
            }
            num1.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_le\num_l.png");
            num2.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_le\num_l.png");
            guna2PictureBox4.Image = null;
            guna2PictureBox5.Image = null;
            chek = 0;
            cx = 0;
            cy = 0;
            num_1=200;
            num_2=200;
        }
        private void num1_Click_1(object sender, EventArgs e)
        {
            chek = 1;
            guna2PictureBox4.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\basee.png");
            guna2PictureBox5.Image = null;
        }
        private void num2_Click(object sender, EventArgs e)
        {
            chek = 2;
            guna2PictureBox5.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\basee.png");
            guna2PictureBox4.Image = null;
        }
        private void music_p(object sender, EventArgs e)//เล่นดนตรีประกอบ
        {
            player.Play();
        }
        private void color_m(object sender, EventArgs e)//สีปุ่มคำตอบ
        {
            answerButton.FillColor = Color.MediumTurquoise;
        }
        int x = 1;
        private void dispatTick(object sender, EventArgs e)//นับเวลาและภาพตัวละคร
        {
            if (x < 3)
            {
                guna2PictureBox1.Image = Image.FromFile(@"D:\w2\c#\Project_job\Game characters\pg1.png");
                x += 1;
            }
            else
            {
                guna2PictureBox1.Image = Image.FromFile(@"D:\w2\c#\Project_job\Game characters\pg2.png");
                x = 1;
            }
            if (ch == 0)
            {
                time -= 1;
                if (time == -1)
                {
                    this.Hide();
                    player.Stop();
                    Form5 f5 = new Form5();
                    f5.ShowDialog();
                }
                if (time <= 10)
                {
                    label1.BackColor = Color.Red;
                }
                else
                {
                    label1.BackColor = Color.Chartreuse;
                }
                label1.Text = $"{time}";
            }
        }
        private void number1_Click_1(object sender, EventArgs e)
        {
            if (ch_button[1] == 0)
            {
                if (chek == 1)
                {
                    for (i = 1; i <= 8; i++)
                    {
                        if (i != cy)
                        {
                            ch_button[i] = 0;
                            Control control = Controls["number" + i];
                            control.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[i-1] + ".png");
                        }
                    }
                    ch_button[1] = 1;
                    number1.BackgroundImage= Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_god\" + num[0] + ".png");
                    num1.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_le\" + num[0] + ".png");
                    num_1 = num[0];
                    cx = 1;
                }
                else if (chek == 2)
                {
                    for (i = 1; i <= 8; i++)
                    {
                        if (i != cx)
                        {
                            ch_button[i] = 0;
                            Control control = Controls["number" + i];
                            control.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[i - 1] + ".png");
                        }
                    }
                    ch_button[1] = 1;
                    number1.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_god\" + num[0] + ".png");
                    num2.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_le\" + num[0] + ".png");
                    num_2 = num[0];
                    cy = 1;
                }
                else
                {
                    MessageBox.Show("กรุณาเลือกต่ำแหน่งที่คุณต้องการก่อน");
                }
            }
        }
        private void number2_Click_1(object sender, EventArgs e)
        {
            if (ch_button[2] == 0)
            {
                if (chek == 1)
                {
                    for (i = 1; i <= 8; i++)
                    {
                        if (i != cy)
                        {
                            ch_button[i] = 0;
                            Control control = Controls["number" + i];
                            control.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[i - 1] + ".png");
                        }
                    }
                    ch_button[2] = 1;
                    number2.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_god\" + num[1] + ".png");
                    num1.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_le\" + num[1] + ".png");
                    num_1 = num[1];
                    cx = 2;
                }
                else if (chek == 2)
                {
                    for (i = 1; i <= 8; i++)
                    {
                        if (i != cx)
                        {
                            ch_button[i] = 0;
                            Control control = Controls["number" + i];
                            control.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[i - 1] + ".png");
                        }
                    }
                    ch_button[2] = 1;
                    number2.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_god\" + num[1] + ".png");
                    num2.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_le\" + num[1] + ".png");
                    num_2 = num[1];
                    cy = 2;
                }
                else
                {
                    MessageBox.Show("กรุณาเลือกต่ำแหน่งที่คุณต้องการก่อน");
                }
            }
        }
        private void number3_Click_1(object sender, EventArgs e)
        {
            if (ch_button[3] == 0)
            {
                if (chek == 1)
                {
                    for (i = 1; i <= 8; i++)
                    {
                        if (i != cy)
                        {
                            ch_button[i] = 0;
                            Control control = Controls["number" + i];
                            control.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[i - 1] + ".png");
                        }
                    }
                    ch_button[3] = 1;
                    number3.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_god\" + num[2] + ".png");
                    num1.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_le\" + num[2] + ".png");
                    num_1 = num[2];
                    cx = 3;
                }
                else if (chek == 2)
                {
                    for (i = 1; i <= 8; i++)
                    {
                        if (i != cx)
                        {
                            ch_button[i] = 0;
                            Control control = Controls["number" + i];
                            control.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[i - 1] + ".png");
                        }
                    }
                    ch_button[3] = 1;
                    number3.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_god\" + num[2] + ".png");
                    num2.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_le\" + num[2] + ".png");
                    num_2 = num[2];
                    cy = 3;
                }
                else
                {
                    MessageBox.Show("กรุณาเลือกต่ำแหน่งที่คุณต้องการก่อน");
                }
            }
        }
        private void number4_Click_1(object sender, EventArgs e)
        {
            if (ch_button[4] == 0)
            {
                if (chek == 1)
                {
                    for (i = 1; i <= 8; i++)
                    {
                        if (i != cy)
                        {
                            ch_button[i] = 0;
                            Control control = Controls["number" + i];
                            control.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[i - 1] + ".png");
                        }
                    }
                    ch_button[4] = 1;
                    number4.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_god\" + num[3] + ".png");
                    num1.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_le\" + num[3] + ".png");
                    num_1 = num[3];
                    cx = 4;
                }
                else if (chek == 2)
                {
                    for (i = 1; i <= 8; i++)
                    {
                        if (i != cx)
                        {
                            ch_button[i] = 0;
                            Control control = Controls["number" + i];
                            control.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[i - 1] + ".png");
                        }
                    }
                    ch_button[4] = 1;
                    number4.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_god\" + num[3] + ".png");
                    num2.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_le\" + num[3] + ".png");
                    num_2 = num[3];
                    cy = 4;
                }
                else
                {
                    MessageBox.Show("กรุณาเลือกต่ำแหน่งที่คุณต้องการก่อน");
                }
            }
        }
        private void number5_Click_1(object sender, EventArgs e)
        {
            if (ch_button[5] == 0)
            {
                if (chek == 1)
                {
                    for (i = 1; i <= 8; i++)
                    {
                        if (i != cy)
                        {
                            ch_button[i] = 0;
                            Control control = Controls["number" + i];
                            control.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[i - 1] + ".png");
                        }
                    }
                    ch_button[5] = 1;
                    number5.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_god\" + num[4] + ".png");
                    num1.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_le\" + num[4] + ".png");
                    num_1 = num[4];
                    cx = 5;
                }
                else if (chek == 2)
                {
                    for (i = 1; i <= 8; i++)
                    {
                        if (i != cx)
                        {
                            ch_button[i] = 0;
                            Control control = Controls["number" + i];
                            control.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[i - 1] + ".png");
                        }
                    }
                    ch_button[5] = 1;
                    number5.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_god\" + num[4] + ".png");
                    num2.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_le\" + num[4] + ".png");
                    num_2 = num[4];
                    cy = 5;
                }
                else
                {
                    MessageBox.Show("กรุณาเลือกต่ำแหน่งที่คุณต้องการก่อน");
                }
            }
        }
        private void number6_Click_1(object sender, EventArgs e)
        {
            if (ch_button[6] == 0)
            {
                if (chek == 1)
                {
                    for (i = 1; i <= 8; i++)
                    {
                        if (i != cy)
                        {
                            ch_button[i] = 0;
                            Control control = Controls["number" + i];
                            control.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[i - 1] + ".png");
                        }
                    }
                    ch_button[6] = 1;
                    number6.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_god\" + num[5] + ".png");
                    num1.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_le\" + num[5] + ".png");
                    num_1 = num[5];
                    cx = 6;
                }
                else if (chek == 2)
                {
                    for (i = 1; i <= 8; i++)
                    {
                        if (i != cx)
                        {
                            ch_button[i] = 0;
                            Control control = Controls["number" + i];
                            control.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[i - 1] + ".png");
                        }
                    }
                    ch_button[6] = 1;
                    number6.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_god\" + num[5] + ".png");
                    num2.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_le\" + num[5] + ".png");
                    num_2 = num[5];
                    cy = 6;
                }
                else
                {
                    MessageBox.Show("กรุณาเลือกต่ำแหน่งที่คุณต้องการก่อน");
                }
            }
        }
        private void number7_Click_1(object sender, EventArgs e)
        {
            if (ch_button[7] == 0)
            {
                if (chek == 1)
                {
                    for (i = 1; i <= 8; i++)
                    {
                        if (i != cy)
                        {
                            ch_button[i] = 0;
                            Control control = Controls["number" + i];
                            control.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[i - 1] + ".png");
                        }
                    }
                    ch_button[7] = 1;
                    number7.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_god\" + num[6] + ".png");
                    num1.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_le\" + num[6] + ".png");
                    num_1 = num[6];
                    cx = 7;
                }
                else if (chek == 2)
                {
                    for (i = 1; i <= 8; i++)
                    {
                        if (i != cx)
                        {
                            ch_button[i] = 0;
                            Control control = Controls["number" + i];
                            control.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[i - 1] + ".png");
                        }
                    }
                    ch_button[7] = 1;
                    number7.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_god\" + num[6] + ".png");
                    num2.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_le\" + num[6] + ".png");
                    num_2 = num[6];
                    cy = 7;
                }
                else
                {
                    MessageBox.Show("กรุณาเลือกต่ำแหน่งที่คุณต้องการก่อน");
                }
            }
        }
        private void number8_Click_1(object sender, EventArgs e)
        {
            if (ch_button[8] == 0)
            {
                if (chek == 1)
                {
                    for (i = 1; i <= 8; i++)
                    {
                        if (i != cy)
                        {
                            ch_button[i] = 0;
                            Control control = Controls["number" + i];
                            control.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[i - 1] + ".png");
                        }
                    }
                    ch_button[8] = 1;
                    number8.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_god\" + num[7] + ".png");
                    num1.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_le\" + num[7] + ".png");
                    num_1 = num[7];
                    cx = 8;
                }
                else if (chek == 2)
                {
                    for (i = 1; i <= 8; i++)
                    {
                        if (i != cx)
                        {
                            ch_button[i] = 0;
                            Control control = Controls["number" + i];
                            control.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[i - 1] + ".png");
                        }
                    }
                    ch_button[8] = 1;
                    number8.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_god\" + num[7] + ".png");
                    num2.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_le\" + num[7] + ".png");
                    num_2 = num[7];
                    cy = 8;
                }
                else
                {
                    MessageBox.Show("กรุณาเลือกต่ำแหน่งที่คุณต้องการก่อน");
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)//ยืนยันคำตอบ
        {
            switch (Program.tool)
            {
                case 1:
                    if (num_1 + num_2 == answer)
                    {
                        chekanswer();
                    }
                    else
                    {
                        answerButton.FillColor = Color.Crimson;
                        DispatcherTimer timer_1 = new DispatcherTimer();
                        timer_1.Tick += new EventHandler(color_m);
                        timer_1.Interval = new TimeSpan(0, 0, 0, 0, 900);
                        timer_1.Start();
                    }
                    break;
                case 2:
                    if(num_1 - num_2 == answer)
                    {
                        chekanswer();
                    }
                    else
                    {
                        answerButton.FillColor = Color.Crimson;
                        DispatcherTimer timer_1 = new DispatcherTimer();
                        timer_1.Tick += new EventHandler(color_m);
                        timer_1.Interval = new TimeSpan(0, 0, 0, 0, 900);
                        timer_1.Start();
                    }
                    break;
                case 3:
                    if (num_1 * num_2 == answer)
                    {
                        Program.score += 1;
                        score_l.Text = $"{Program.score}";
                        answerButton.FillColor = Color.LimeGreen;
                        DispatcherTimer timer_2 = new DispatcherTimer();
                        timer_2.Tick += new EventHandler(color_m);
                        timer_2.Interval = new TimeSpan(0, 0, 0, 0, 600);
                        timer_2.Start();

                        time = time + 6;
                        num[cx - 1] = random.Next(12);
                        Control control = Controls["number" + cx];
                        control.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[cx - 1] + ".png");
                        num[cy - 1] = random.Next(12);
                        Control control_2 = Controls["number" + cy];
                        control_2.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[cy - 1] + ".png");

                        answer_f();
                        for (i = 1; i <= 8; i++)
                        {
                            ch_button[i] = 0;
                        }
                        num1.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_le\num_l.png");
                        num2.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_le\num_l.png");
                        guna2PictureBox4.Image = null;
                        guna2PictureBox5.Image = null;
                        chek = 0;
                        cx = 0;
                        cy = 0;
                        num_1 = 200;
                        num_2 = 200;
                    }
                    else
                    {
                        answerButton.FillColor = Color.Crimson;
                        DispatcherTimer timer_1 = new DispatcherTimer();
                        timer_1.Tick += new EventHandler(color_m);
                        timer_1.Interval = new TimeSpan(0, 0, 0, 0, 900);
                        timer_1.Start();
                    }
                    break;
                case 4:
                    if (num_1 / num_2 == answer)
                    {
                        Program.score += 1;
                        score_l.Text = $"{Program.score}";
                        time = time + 5;
                        answerButton.FillColor = Color.LimeGreen;
                        DispatcherTimer timer_2 = new DispatcherTimer();
                        timer_2.Tick += new EventHandler(color_m);
                        timer_2.Interval = new TimeSpan(0, 0, 0, 0, 600);
                        timer_2.Start();

                        j = 0;
                        while (j < 1)
                        {
                            num[cx - 1] = random.Next(1, 30);
                            if (num[cx - 1] % 2 == 0||num[cx - 1] == 1)
                            {
                                Control control = Controls["number" + cx];
                                control.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[cx - 1] + ".png");
                                j = 10;
                            }
                        }
                        while (j == 10)
                        {
                            num[cy - 1] = random.Next(1, 30);
                            if(num[cy - 1] % 2 == 0||num[cy - 1] == 1)
                            {
                                Control control_2 = Controls["number" + cy];
                                control_2.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[cy - 1] + ".png");
                                j = 3;
                            }
                        }

                        answer_f();

                        for (i = 1; i <= 8; i++)
                        {
                            ch_button[i] = 0;
                        }
                        num1.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_le\num_l.png");
                        num2.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_le\num_l.png");
                        guna2PictureBox4.Image = null;
                        guna2PictureBox5.Image = null;
                        chek = 0;
                        cx = 0;
                        cy = 0;
                        num_1 = 5000;
                        num_2 = 1;
                    }
                    else
                    {
                        answerButton.FillColor = Color.Crimson;
                        DispatcherTimer timer_1 = new DispatcherTimer();
                        timer_1.Tick += new EventHandler(color_m);
                        timer_1.Interval = new TimeSpan(0, 0, 0, 0, 900);
                        timer_1.Start();
                    }
                    break;
            }
        }
        private void ออกToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ch = 1;
            string message = "คะแนนของคุณจะหายไป คุณต้องการออกเกมใช่หรือไม่";
            string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                ch = 0;
            }
        }
        private void ผจดทำToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("คนที่หล่อๆครับเป็นผู้จัดทำ");
        }
        private void เกมอนๆToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://th.y8.com/");
        }
        private void number1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ch_button[1] == 0)
            {
                number1.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_ok\" + num[0] + ".png");
            }
        }
        private void number1_MouseLeave(object sender, EventArgs e)
        {
            if (ch_button[1] == 0)
            {
                number1.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[0] + ".png");
            }
        }
        private void number2_MouseMove(object sender, MouseEventArgs e)
        {
            if (ch_button[2] == 0)
            {
                number2.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_ok\" + num[1] + ".png");
            }
        }
        private void number2_MouseLeave(object sender, EventArgs e)
        {
            if (ch_button[2] == 0)
            {
                number2.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[1] + ".png");
            }
        }
        private void number3_MouseMove(object sender, MouseEventArgs e)
        {
            if (ch_button[3] == 0)
            {
                number3.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_ok\" + num[2] + ".png");
            }
        }
        private void number3_MouseLeave(object sender, EventArgs e)
        {
            if (ch_button[3] == 0)
            {
                number3.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[2] + ".png");
            }
        }
        private void number4_MouseMove(object sender, MouseEventArgs e)
        {
            if (ch_button[4] == 0)
            {
                number4.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_ok\" + num[3] + ".png");
            }
        }
        private void number4_MouseLeave(object sender, EventArgs e)
        {
            if (ch_button[4] == 0)
            {
                number4.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[3] + ".png");
            }
        }
        private void number5_MouseMove(object sender, MouseEventArgs e)
        {
            if (ch_button[5] == 0)
            {
                number5.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_ok\" + num[4] + ".png");
            }
        }
        private void number5_MouseLeave(object sender, EventArgs e)
        {
            if (ch_button[5] == 0)
            {
                number5.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[4] + ".png");
            }
        }
        private void number6_MouseMove(object sender, MouseEventArgs e)
        {
            if (ch_button[6] == 0)
            {
                number6.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_ok\" + num[5] + ".png");
            }
        }
        private void number6_MouseLeave(object sender, EventArgs e)
        {
            if (ch_button[6] == 0)
            {
                number6.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[5] + ".png");
            }
        }
        private void number7_MouseMove(object sender, MouseEventArgs e)
        {
            if (ch_button[7] == 0)
            {
                number7.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_ok\" + num[6] + ".png");
            }
        }
        private void number7_MouseLeave(object sender, EventArgs e)
        {
            if (ch_button[7] == 0)
            {
                number7.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[6] + ".png");
            }
        }
        private void number8_MouseMove(object sender, MouseEventArgs e)
        {
            if (ch_button[8] == 0)
            {
                number8.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_ok\" + num[7] + ".png");
            }
        }
        private void number8_MouseLeave(object sender, EventArgs e)
        {
            if (ch_button[8] == 0)
            {
                number8.BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\แก้\num_no\" + num[7] + ".png");
            }
        }
    }
}