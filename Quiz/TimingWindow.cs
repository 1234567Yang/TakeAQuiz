using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class TimingWindow : Form
    {
        public bool quizing = false;
        public int totalTime = -1;
        public int nowTime = 0;
        public TimingWindow()
        {
            InitializeComponent();
        }

        private void KeepLiveWindow_Load(object sender, EventArgs e)
        {
            try
            {
                totalTime = int.Parse(File.ReadAllText(@"C:\ProgramData\Yang\TakeAQuiz\minute.txt"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not read the minute information, the program will exit: " + ex.Message, "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            Thread thread = new Thread(TimingThread);
            thread.Start();
        }
        public void TimingThread()
        {
            while (true)
            {
                nowTime++;
                ChangeUI(() => { this.label_time_left.Text = (totalTime - nowTime + 1).ToString(); });
                if (totalTime - nowTime < 2)
                {
                    ChangeUI(() => { this.label_time_left.BackColor = Color.Orange; });
                }
                else
                {
                    ChangeUI(() => { this.label_time_left.BackColor = Color.White; });
                }
                for (int i = 0; i < 60; i++)
                {
                    #if (DEBUG)
                        Thread.Sleep(1);
                    #else
                        Thread.Sleep(1000);
                    #endif

                }
                if (nowTime >= totalTime)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        ChangeUI(() => { this.label_time_left.BackColor = Color.Red; });
                        ChangeUI(() => { this.label_time_left.Text = (10 - i) + "s"; });
                        Thread.Sleep(1000);
                    }
                    ChangeUI(new Action(() => { StartQuiz(); }));
                    nowTime = 0;
                }
            }



        }
        public void ChangeUI(Action a)
        {
            this.Invoke(a);
        }
        public void StartQuiz()
        {
            if (quizing)
            {
                return;
            }
            quizing = true;
            //Thread thread = new Thread(() =>
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        ChangeUI(() => { this.label_time_left.BackColor = Color.Red; });
            //        ChangeUI(() => { this.label_time_left.Text = (10 - i) + "s"; });
            //        Thread.Sleep(1000);
            //    }
            //});
            //thread.Start();
            //await Task.Delay(11000);
            string dir = "";
            try
            {
                dir = File.ReadAllText(@"C:\ProgramData\Yang\TakeAQuiz\quiz_file.txt");
                Console.WriteLine("Dir:" + dir);
                if (dir == "") throw new Exception("The file is empty!");
                StartWindow.quizFile = dir;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not read quiz_file information, the program will exit: " + ex.Message, "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            this.Hide();


            nowTime = 0;
            LockWindow lw = new LockWindow();
            lw.ShowDialog();
            nowTime = 0;


            this.Show();
            quizing = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartQuiz();
        }

    }
}
