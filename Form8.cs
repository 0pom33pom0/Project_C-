using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using MySql.Data.MySqlClient;

namespace Project_job
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        int ch_u = 0, ch_pass = 0, ch_meil = 0, ch_pass2 = 0;
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=project_jo;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void Form8_Load(object sender, EventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(dispatTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Start();
        }
        int k = 1;
        private void dispatTick(object sender, EventArgs e)
        {
            if (k == 1)
            {
                guna2PictureBox2.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\si_h2.png");
                k = 2;
            }
            else
            {
                guna2PictureBox2.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\si_h1.png");
                k = 1;
            }
        }
        private void guna2PictureBox11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }
        private void guna2PictureBox11_MouseMove(object sender, MouseEventArgs e)
        {
            guna2PictureBox11.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\back.png");
        }
        private void guna2PictureBox11_MouseLeave(object sender, EventArgs e)
        {
            guna2PictureBox11.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\back1.png");
        }
        private void guna2PictureBox12_MouseMove(object sender, MouseEventArgs e)
        {
            guna2PictureBox12.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\ok.png");
        }
        private void guna2PictureBox12_MouseLeave(object sender, EventArgs e)
        {
            guna2PictureBox12.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\ok1.png");
        }
        private void guna2PictureBox12_Click(object sender, EventArgs e)
        {
            if (ch_u + ch_pass2 + ch_pass + ch_meil == 4)
            {
                MySqlConnection conn = databaseConnection();
                MySqlCommand cmd;
                string sql1 = "INSERT INTO user(username, password, name, email) VALUES('" + guna2TextBox4.Text + "','" + guna2TextBox3.Text + "','','" + guna2TextBox2.Text + "')";
                conn.Open();
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                cmd1.ExecuteReader();
                conn.Close();
                MessageBox.Show("สมัครเสร็จเรียบร้อย!");
                this.Hide();
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ถูกต้อง!");
            }
        }
        private void guna2TextBox4_Validated(object sender, EventArgs e)
        {
            int countCharacter = this.guna2TextBox4.TextLength;
            if (countCharacter < 20 && countCharacter > 5)
            {
                MySqlConnection conn = databaseConnection();
                conn.Open();
                MySqlCommand cmd;
                cmd = conn.CreateCommand();
                cmd.CommandText = $"SELECT * FROM user WHERE username=\"{guna2TextBox4.Text}\"";
                MySqlDataReader row = cmd.ExecuteReader();
                if (row.HasRows)
                {
                    guna2PictureBox7.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\x.png");
                }
                else
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(guna2TextBox4.Text, "[^0-9||A-Z||a-z]"))
                    {
                        guna2PictureBox7.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\x.png");
                        ch_u = 0;
                    }
                    else if (guna2TextBox4.Text != "")
                    {
                        guna2PictureBox7.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\col.png");
                        ch_u = 1;
                    }
                    else
                    {
                        guna2PictureBox7.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\x.png");
                        ch_u = 0;
                    }
                }
                conn.Close();
            }
            else
            {
                guna2PictureBox7.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\x.png");
                ch_u = 0;
            }
        }
        private void guna2TextBox3_Validated(object sender, EventArgs e)
        {
            int countCharacter = this.guna2TextBox3.TextLength;
            if (System.Text.RegularExpressions.Regex.IsMatch(guna2TextBox3.Text, "[^0-9||A-Z||a-z]"))
            {
                guna2PictureBox8.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\x.png");
                ch_pass = 0;
            }
            else if (guna2TextBox3.Text != "" && (countCharacter <= 10 && countCharacter >= 6))
            {
                guna2PictureBox8.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\col.png");
                ch_pass = 1;
            }
            else
            {
                guna2PictureBox8.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\x.png");
                ch_pass = 0;
            }
            if (ch_pass2 == 1)
            {
                if (guna2TextBox1.Text == guna2TextBox3.Text)
                {
                    guna2PictureBox9.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\col.png");
                    ch_pass2 = 1;
                }
                else
                {
                    guna2PictureBox9.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\x.png");
                    ch_pass2 = 0;
                }
            }
        }
        private void guna2TextBox1_Validated(object sender, EventArgs e)
        {
            if(guna2TextBox1.Text == guna2TextBox3.Text)
            {
                guna2PictureBox9.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\col.png");
                ch_pass2 = 1;
            }
            else
            {
                guna2PictureBox9.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\x.png");
                ch_pass2 = 0;
            }
        }
        private void guna2TextBox2_Validated(object sender, EventArgs e)
        {

            MySqlConnection conn = databaseConnection();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM user WHERE email=\"{guna2TextBox2.Text}\"";
            MySqlDataReader row = cmd.ExecuteReader();
            if (row.HasRows)
            {
                guna2PictureBox10.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\x.png");
                ch_meil = 0;
            }
            else
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(guna2TextBox2.Text, "[^0-9&&A-z&&@&&.&&_]"))
                {
                    guna2PictureBox10.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\x.png");
                    ch_meil = 0;
                }
                else
                {
                    Regex reg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*.co\w+([m]\w+)*");
                    if (!reg.IsMatch(guna2TextBox2.Text))
                    {
                        guna2PictureBox10.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\x.png");
                        ch_meil = 0;
                    }
                    else
                    {
                        guna2PictureBox10.Image = Image.FromFile(@"D:\w2\c#\Project_job\แก้\col.png");
                        ch_meil = 1;
                    }
                }
            }  
        }
    }
}
