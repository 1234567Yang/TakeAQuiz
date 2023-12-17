using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class SettingWindow : Form
    {
        string dir = @"C:\ProgramData\Yang\TakeAQuiz\";
        public SettingWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Time = 0;
            if (this.textBox_password.Text == "")
            {
                MessageBox.Show("Password can not be null!", "Warning:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.textBox_lock_quiz_file.Text == "")
            {
                MessageBox.Show("Quiz file can not be null!", "Warning:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.textBox_lock_rest_time.Text == "")
            {
                MessageBox.Show("rest time can not be null!", "Warning:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                Time = (int.Parse(this.textBox_lock_rest_time.Text) > 1) ? int.Parse(this.textBox_lock_rest_time.Text) : 0;
                if (Time < 0)
                {
                    MessageBox.Show("The rest time must greater than 1 (minute)!", "Warning:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("You must enter a correct number for the rest time in minute!", "Warning:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!File.Exists(this.textBox_lock_quiz_file.Text))
            {
                MessageBox.Show("You must enter a valid quiz file direction!", "Warning:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                File.WriteAllText(dir + "minute.txt", this.textBox_lock_rest_time.Text);
                File.WriteAllText(dir + "password.txt", this.textBox_password.Text);
                File.WriteAllText(dir + "quiz_file.txt", this.textBox_lock_quiz_file.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not write the configration: " + ex.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Saved!", "Hint:", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SettingWindow_Load(object sender, EventArgs e)
        {
            if (File.Exists(dir + "password.txt"))
            {
                this.tabControl1.SelectedTab = this.tabPage_verify;
            }
            try
            {

                if (File.Exists(dir + "minute.txt")) this.textBox_lock_rest_time.Text = File.ReadAllText(dir + "minute.txt");
                if (File.Exists(dir + "password.txt")) this.textBox_password.Text = File.ReadAllText(dir + "password.txt");
                if (File.Exists(dir + "quiz_file.txt")) this.textBox_lock_quiz_file.Text = File.ReadAllText(dir + "quiz_file.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not read the configration: " + ex.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string pass = File.ReadAllText(dir + "password.txt");
                if(this.textBox1.Text == pass)
                {
                    this.tabControl1.SelectedTab = this.tabPage_setting;
                }
                else
                {
                    MessageBox.Show("Password is incorrect!", "Warning: ",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }catch(Exception ex)
            {
                MessageBox.Show("Can not read the password configration: " + ex.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
