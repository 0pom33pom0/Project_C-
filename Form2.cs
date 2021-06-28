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
using MySql.Data.MySqlClient;

namespace Project_job
{
    public partial class Form2 : Form
    {
        string user;
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"D:\w2\c#\Project_job\Project_job\Resources\ซาว2.wav");
        public Form2()
        {
            InitializeComponent();
        }
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=project_jo;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            player.Play();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(dispatTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 40);
            timer.Start();
            DispatcherTimer gg = new DispatcherTimer();
            gg.Tick += new EventHandler(name);
            gg.Interval = new TimeSpan(0, 0, 0, 0, 650);
            gg.Start();
            guna2TextBox1.Hide();
            label1.Hide();
            label2.Hide();
            guna2ImageButton1.Hide();
            guna2ImageButton2.Hide();
            guna2ImageButton3.Hide();
            guna2ImageButton4.Hide();
            guna2PictureBox9.Hide();
            if (Program.tool != 0)
            {
                MySqlConnection conn = databaseConnection();
                conn.Open();
                MySqlCommand cmd;
                cmd = conn.CreateCommand();
                cmd.CommandText = $"SELECT * FROM user WHERE name=\"{Program.u}\"";
                MySqlDataReader row = cmd.ExecuteReader();
                if (row.HasRows)
                {
                    while (row.Read())
                    {
                        user = guna2TextBox3.Text;
                        guna2PictureBox3.Hide();
                        guna2PictureBox4.Hide();
                        guna2PictureBox5.Hide();
                        guna2PictureBox6.Hide();
                        guna2PictureBox7.Hide();
                        guna2PictureBox8.Hide();
                        guna2TextBox2.Hide();
                        guna2TextBox3.Hide();
                        label1.Show();
                        guna2ImageButton1.Show();
                        guna2ImageButton2.Show();
                        guna2ImageButton3.Show();
                        guna2ImageButton4.Show();
                        guna2PictureBox9.Show();
                        guna2PictureBox1.Hide();
                        label2.Show();
                        label2.Text = $"{row.GetString(2)}";
                        Program.u = $"{row.GetString(2)}";
                        Program.chek_f = 3;
                    }
                }
            }
        }
        int k=1;
        private void name(object sender, EventArgs e)//ชุดใหญไฟกระพริบ
        {
            if (Program.chek_f == 0)
            {
                if (k == 1)
                {
                    guna2PictureBox4.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\login_f.png");
                    k = 2;
                }
                else
                {
                    guna2PictureBox4.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\login_f2.png");
                    k = 1;
                }
            }
            else if(Program.chek_f == 2)
            {
                if (k == 1)
                {
                    guna2PictureBox1.Image = Image.FromFile(@"D:\w2\c#\Project_job\ชื่อ2.png");
                    k = 2;
                }
                else
                {
                    guna2PictureBox1.Image = Image.FromFile(@"D:\w2\c#\Project_job\ชื่อ.png");
                    k = 1;
                }
            }
            else
            {
                if (k == 1)
                {
                    guna2PictureBox9.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\name1.png");
                    k = 2;
                }
                else
                {
                    guna2PictureBox9.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\name2.png");
                    k = 1;
                }
            }
        }
        int x = 1;
        int characters = 2;
        private void dispatTick(object sender, EventArgs e)//ตัวละครและพื้นหลัง
        {
            for(int j = 2; j <= 9; j++)
            {
                if (j == characters)
                {
                    string b = $"{ characters + 1}.png";
                    guna2PictureBox2.Image = Image.FromFile(@"D:\w2\c#\Project_job\Game characters\"+b);//ตัวละครวิ่ง
                }
            }
            for (int i = 1; i <= 208; i++)
            {
                if (i == x)
                {
                    string a = $"{x + 1}.png";
                    BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\ls\" + a);//พื้นหลังขยับ
                }
            }
            if (x == 209)//พื้นหลังขยับ
            {
                x = 1;
            }
            if (characters == 10)//ตัวละครวิ่ง
            {
                characters = 2;
            }
            x += 1;
            characters += 1;
        }
        private void ออกToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void guna2ImageButton1_Click(object sender, EventArgs e)//บวก
        {
            if (Program.chek_f == 2)
            {
                MySqlConnection conn = databaseConnection();
                conn.Open();
                MySqlCommand cmd;
                cmd = conn.CreateCommand();
                cmd.CommandText = $"SELECT * FROM user WHERE name=\"{guna2TextBox1.Text}\"";
                MySqlDataReader row = cmd.ExecuteReader();
                if (row.HasRows)
                {
                    MessageBox.Show("ชื่อนี้มีผู้ใช้แล้ว");
                }
                else
                {
                    int countCharacter = this.guna2TextBox1.TextLength;
                    if (guna2TextBox1.Text != "" && guna2TextBox1.Text != " " && (countCharacter < 15))
                    {
                        Program.u = guna2TextBox1.Text;
                        conn = databaseConnection();
                        string sql1 = "UPDATE user SET  name ='" + Program.u + "' WHERE username='" + user + "'";
                        conn.Open();
                        cmd = new MySqlCommand(sql1, conn);
                        cmd.ExecuteReader();
                        conn.Close();
                        this.Hide();
                        player.Stop();
                        Program.tool = 1;
                        Form3 f3 = new Form3();
                        f3.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("กรุณากรอกชื่อก่อนเริ่มเกม และกรอบได้จำนวน15ตัวอักษรเท่านั้น");
                    }
                }
            }
            else
            {
                this.Hide();
                player.Stop();
                Program.tool = 1;
                Form3 f3 = new Form3();
                f3.ShowDialog();
            }
        }
        private void guna2ImageButton2_Click(object sender, EventArgs e)//ลบ
        {
            if (Program.chek_f == 2)
            {
                MySqlConnection conn = databaseConnection();
                conn.Open();
                MySqlCommand cmd;
                cmd = conn.CreateCommand();
                cmd.CommandText = $"SELECT * FROM user WHERE name=\"{guna2TextBox1.Text}\"";
                MySqlDataReader row = cmd.ExecuteReader();
                if (row.HasRows)
                {
                    MessageBox.Show("ชื่อนี้มีผู้ใช้แล้ว");
                }
                else
                {
                    int countCharacter = this.guna2TextBox1.TextLength;
                    if (guna2TextBox1.Text != "" && guna2TextBox1.Text != " " && (countCharacter < 15))
                    {
                        Program.u = guna2TextBox1.Text;
                        conn = databaseConnection();
                        string sql1 = "UPDATE user SET  name ='" + Program.u + "' WHERE username='" + user + "'";
                        conn.Open();
                        cmd = new MySqlCommand(sql1, conn);
                        cmd.ExecuteReader();
                        conn.Close();
                        this.Hide();
                        player.Stop();
                        Program.tool = 2;
                        Form3 f3 = new Form3();
                        f3.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("กรุณากรอกชื่อก่อนเริ่มเกม และกรอบได้จำนวน20ตัวอักษรเท่านั้น");
                    }
                }
            }
            else
            {
                this.Hide();
                player.Stop();
                Program.tool = 2;
                Form3 f3 = new Form3();
                f3.ShowDialog();
            }
        }
        private void guna2ImageButton3_Click(object sender, EventArgs e)//คูณ
        {
            if (Program.chek_f == 2)
            {
                MySqlConnection conn = databaseConnection();
                conn.Open();
                MySqlCommand cmd;
                cmd = conn.CreateCommand();
                cmd.CommandText = $"SELECT * FROM user WHERE name=\"{guna2TextBox1.Text}\"";
                MySqlDataReader row = cmd.ExecuteReader();
                if (row.HasRows)
                {
                    MessageBox.Show("ชื่อนี้มีผู้ใช้แล้ว");
                }
                else
                {
                    int countCharacter = this.guna2TextBox1.TextLength;
                    if (guna2TextBox1.Text != "" && guna2TextBox1.Text != " " && (countCharacter < 15))
                    {
                        Program.u = guna2TextBox1.Text;
                        conn = databaseConnection();
                        string sql1 = "UPDATE user SET  name ='" + Program.u + "' WHERE username='" + user + "'";
                        conn.Open();
                        cmd = new MySqlCommand(sql1, conn);
                        cmd.ExecuteReader();
                        conn.Close();
                        this.Hide();
                        player.Stop();
                        Program.tool = 3;
                        Form3 f3 = new Form3();
                        f3.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("กรุณากรอกชื่อก่อนเริ่มเกม และกรอบได้จำนวน20ตัวอักษรเท่านั้น");
                    }
                }
            }
            else
            {
                this.Hide();
                player.Stop();
                Program.tool = 3;
                Form3 f3 = new Form3();
                f3.ShowDialog();
            }
        }
        private void guna2ImageButton4_Click(object sender, EventArgs e)//หาร
        {
            if (Program.chek_f == 2)
            {
                MySqlConnection conn = databaseConnection();
                conn.Open();
                MySqlCommand cmd;
                cmd = conn.CreateCommand();
                cmd.CommandText = $"SELECT * FROM user WHERE name=\"{guna2TextBox1.Text}\"";
                MySqlDataReader row = cmd.ExecuteReader();
                if (row.HasRows)
                {
                    MessageBox.Show("ชื่อนี้มีผู้ใช้แล้ว");
                }
                else
                {
                    int countCharacter = this.guna2TextBox1.TextLength;
                    if (guna2TextBox1.Text != "" && guna2TextBox1.Text != " " && (countCharacter < 15))
                    {
                        Program.u = guna2TextBox1.Text;
                        conn = databaseConnection();
                        string sql1 = "UPDATE user SET  name ='" + Program.u + "' WHERE username='" + user + "'";
                        conn.Open();
                        cmd = new MySqlCommand(sql1, conn);
                        cmd.ExecuteReader();
                        conn.Close();
                        this.Hide();
                        player.Stop();
                        Program.tool = 4;
                        Form3 f3 = new Form3();
                        f3.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("กรุณากรอกชื่อก่อนเริ่มเกม และกรอบได้จำนวน20ตัวอักษรเท่านั้น");
                    }
                }
            }
            else
            {
                this.Hide();
                player.Stop();
                Program.tool = 4;
                Form3 f3 = new Form3();
                f3.ShowDialog();
            }
        }
        private void ผจดทำToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("คนที่หล่อๆครับเป็นผู้จัดทำ");
        }
        private void กตกาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            player.Stop();
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }
        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void เกมอนๆToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://th.y8.com/");
        }
        private void guna2PictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            guna2PictureBox5.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\log2.png");
        }
        private void guna2PictureBox5_MouseLeave(object sender, EventArgs e)
        {
            guna2PictureBox5.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\log1.png");
        }
        private void guna2PictureBox6_MouseLeave(object sender, EventArgs e)
        {
            guna2PictureBox6.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\si1.png");
        }
        private void guna2PictureBox6_MouseMove(object sender, MouseEventArgs e)
        {
            guna2PictureBox6.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\si2.png");
        }
        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(guna2TextBox3.Text, "[^0-9&&A-z]"))
            {
                MessageBox.Show("พิมได้แค่ตัวเลขและตัวอักษรภาษาอังกฤษ");
                guna2TextBox3.Text = "";
                guna2TextBox2.Text = "";
            }
            else
            {
                MySqlConnection conn = databaseConnection();
                conn.Open();
                MySqlCommand cmd;
                cmd = conn.CreateCommand();
                cmd.CommandText = $"SELECT * FROM user WHERE username=\"{guna2TextBox3.Text}\"";
                MySqlDataReader row = cmd.ExecuteReader();
                if (row.HasRows)
                {
                    while (row.Read())
                    {
                        user = guna2TextBox3.Text;
                        if (guna2TextBox2.Text == row.GetString(1))
                        {
                            guna2PictureBox3.Hide();
                            guna2PictureBox4.Hide();
                            guna2PictureBox5.Hide();
                            guna2PictureBox6.Hide();
                            guna2PictureBox7.Hide();
                            guna2PictureBox8.Hide();
                            guna2TextBox2.Hide();
                            guna2TextBox3.Hide();
                            label1.Show();
                            guna2ImageButton1.Show();
                            guna2ImageButton2.Show();
                            guna2ImageButton3.Show();
                            guna2ImageButton4.Show();
                            if (row.GetString(2) == "")
                            {
                                guna2TextBox1.Show();
                                Program.chek_f = 2;
                            }
                            else
                            {
                                guna2PictureBox9.Show();
                                guna2PictureBox1.Hide();
                                label2.Show();
                                label2.Text = $"{row.GetString(2)}";
                                Program.u= $"{row.GetString(2)}";
                                Program.chek_f = 3;
                            }
                        }
                        else
                        {
                            MessageBox.Show("รหัสผ่านไม่ถูกต้อง");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("ไม่พบชื่อผู้ใช้นี้");
                }
                conn.Close();
            } 
        }
        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            player.Stop();
            Form8 f8 = new Form8();
            f8.ShowDialog();
        }
    }
}