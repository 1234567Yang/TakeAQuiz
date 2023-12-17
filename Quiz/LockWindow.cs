using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Quiz
{
    public partial class LockWindow : Form
    {
        public string password = "";
        public LockWindow()
        {
            InitializeComponent();
        }
        public void MakeCloseLockWindow(bool canClose) 
        {
            if (canClose) {
                this.FormClosing -= LockWindow_FormClosing;
            }
            else
            {
                this.FormClosing += LockWindow_FormClosing;
            }
        }

        private void LockWindow_Load(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\ProgramData\Yang\TakeAQuiz\password.txt"))
            {
                try
                {
                    password = File.ReadAllText(@"C:\ProgramData\Yang\TakeAQuiz\password.txt");
                }catch(Exception ex)
                {
                    MessageBox.Show("An error occur while reading the password, the program will exit: " + ex.Message,"Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                }
            }
            else
            {
                Random rd = new Random();
                password = rd.Next(1000, 100000).ToString();
            }

            this.Left = 0;
            this.Top = 0;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;

            //this.MdiChildActivate += (s_, e_) => { this.Close(); };
            //Thread thread = new Thread(() => {
            //    if(this.MdiChildActivate)
            //    Thread.Sleep(1000);
            //});
            QuizingWindow quizingWindow = new QuizingWindow() { MdiParent = this};
            quizingWindow.ControlBox = false;
            quizingWindow.MaximizeBox = false;
            quizingWindow.MinimizeBox = false;
            quizingWindow.Show();
            quizingWindow.finishClosingAct = new Action(() => { this.Close(); });
        }

        private void LockWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == password)
            {
                try
                {
                    File.Delete(@"C:\ProgramData\Yang\TakeAQuiz\quiz_mod.txt");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"Can not delete auto-quizing file, please delete it by yourself, position: C:\ProgramData\Yang\TakeAQuiz\quiz_mod.txt: " + ex.Message, "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Environment.Exit(0);
            }
            else
            {
                this.textBox1.Text = "Incorrect!";
            }
        }
    }
}
