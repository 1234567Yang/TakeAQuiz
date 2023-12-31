﻿using System;
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
    public partial class StartWindow : Form
    {
        private static string file = "";
        public static string quizFile
        {
            get
            {
                return file;
            }
            set
            {
                file = value;
            }
        }

        public static void checkAccess(string file)
        {
            Console.WriteLine($"First:{file}");
            string textFile = file + ".acc";
            Console.WriteLine($"Last:{textFile}");
            try
            {


                File.WriteAllText(textFile, $"Access check passed - UTC: {DateTime.UtcNow}");
            }
            catch
            {
                Message.dialog.showError("The program has no access to your file, please run as administrator");
                Environment.Exit(1);
            }
        }
        public static int checkInput() // 0 - empty; 1 - file existed; 2 - directory existed;
                                       // 3 - directory / file not existed
                                       // 4 - 胡编乱造（不存在的目录）
                                       // If no access to the file, the program will close;
        {
            if (quizFile == "")
            {
                Message.dialog.showHit("Please input a file.");
                return 0;
            }
            else
            {
                if (File.Exists(quizFile))
                {
                    checkAccess(quizFile);
                    return 1;
                }
                else if (Directory.Exists(quizFile))
                {
                    checkAccess(quizFile);
                    return 2;
                }
                else if (quizFile.IndexOf(".") != -1)
                {
                    return 3;
                }
                else
                {
                    return 4;
                }
            }
        }
        private void CreateForm<TForm>() where TForm : Form//定义一个泛型，然后呢，把它限定在必须继承自Form这个interface
        {
            TForm form = Activator.CreateInstance<TForm>(); //Activator来创建一个实例

            form.FormClosed += (sender_, e_) =>
            {
                this.Show();
            };
            form.Icon = Properties.Resources.LOGO;
            form.Show();
            this.Hide();
        }

        private void WriteFile()
        {
            //List<string> SoundFile = Directory.GetFiles("C:\\ProgramData\\TakeAQuiz\\","*.wav").ToList();
            try
            {
                if (!Directory.Exists("C:\\ProgramData\\TakeAQuiz\\")) Directory.CreateDirectory("C:\\ProgramData\\TakeAQuiz\\");

                if (!File.Exists("C:\\ProgramData\\TakeAQuiz\\Music1.wav"))
                {
                    FileStream fileStream = new FileStream("C:\\ProgramData\\TakeAQuiz\\Music1.wav", FileMode.Create);
                    byte[] buffer = new byte[Properties.Resources.Music1.Length];
                    Properties.Resources.Music1.Read(buffer, 0, (int)Properties.Resources.Music1.Length);
                    fileStream.Write(buffer, 0, buffer.Length);
                    fileStream.Flush();
                    Properties.Resources.Music1.Close();
                    fileStream.Close();
                }
                if (!File.Exists("C:\\ProgramData\\TakeAQuiz\\Music2.wav"))
                {
                    FileStream fileStream = new FileStream("C:\\ProgramData\\TakeAQuiz\\Music2.wav", FileMode.Create);
                    byte[] buffer = new byte[Properties.Resources.Music2.Length];
                    Properties.Resources.Music2.Read(buffer, 0, (int)Properties.Resources.Music2.Length);
                    fileStream.Write(buffer, 0, buffer.Length);
                    fileStream.Flush();
                    Properties.Resources.Music2.Close();
                    fileStream.Close();
                }

                //File.WriteAllBytes("C:\\ProgramData\\TakeAQuiz\\Music1.wav", Properties.Resources.Music1);


            }
            catch (Exception ex)
            {
                Message.dialog.showError("Can not create and write to the floder:C:\\ProgramData\\TakeAQuiz\\");
                Message.dialog.showError(ex);
                Environment.Exit(3);
            }
        }
        public StartWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkInput() == 0)
            {
                return;
            }
            else if (checkInput() != 1)
            {
                Message.dialog.showHit("File does not exist.");
                //MessageBox.Show("File does not exist!", "Hit:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //CreateForm(Form2);
            CreateForm<QuizingWindow>(); //奇怪的泛型...
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            quizFile = textBox1.Text;

            WriteFile();

            Message.ICO.ChangeICO(this);


            //this.Icon = Properties.Resources.LOGO; form1删掉了
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            quizFile = textBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkInput() == 0)
            {
                return;
            }
            else if (checkInput() != 1)
            {
                //MessageBox.Show("File does not exist!", "Hit:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Message.dialog.showHit("File does not exist!");
                return;
            }
            CreateForm<DataWindow>();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (checkInput() == 0)
            {
                return;
            }
            else if (checkInput() == 4)
            {
                Message.dialog.showError("Your file name is wrong!");
            }
            else if (checkInput() == 2 || checkInput() == 3)
            {
                if (checkInput() == 3)
                {
                    //Console.WriteLine(textBox1.Text.Substring(0, textBox1.Text.IndexOf(".")));

                }
                if (MessageBox.Show("File does not exist, do you want to create it and continue?", "Question:", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        Directory.CreateDirectory(textBox1.Text.Substring(0, textBox1.Text.LastIndexOf("\\")));
                    }
                    catch
                    {
                        Message.dialog.showError("The program has no access to your file, please run as administrator");
                        Environment.Exit(1);
                    }

                    try
                    {
                        File.WriteAllText(textBox1.Text, "");
                    }
                    catch
                    {
                        Message.dialog.showError("The program has no access to your file, please run as administrator");
                        Environment.Exit(1);
                    }

                }
                else
                {
                    return;
                }

            }


            CreateForm<MakingQuizWindow>();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void StartWindow_Shown(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\ProgramData\Yang\TakeAQuiz\quiz_mod.txt"))
            {
                this.Hide();
                TimingWindow timingWindow = new TimingWindow();
                timingWindow.ShowDialog();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                File.Create(@"C:\ProgramData\Yang\TakeAQuiz\quiz_mod.txt");
            }catch(Exception ex)
            {
                Message.dialog.showError(ex);
            }
            Message.dialog.showHit("Mode opened! Please restart it again. If you want to stop it, please enter your password in exams.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CreateForm<SettingWindow>();
        }
    }



    namespace Message
    {
        class dialog
        {
            public static void Damaged()
            {
                MessageBox.Show("This file is not an quiz file or it is damaged!", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            public static void showError(Exception ex)
            {
                MessageBox.Show($"An error occured:\n{ex.Message}\n{ex.Data}", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            public static void showError(string text)
            {
                MessageBox.Show($"An error occured:\n{text}", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            public static void showHit(string text)
            {
                MessageBox.Show(text, "Hit:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        static class ICO
        {
            public static void ChangeICO(Form form)
            {
                form.Icon = Properties.Resources.LOGO;
            }
        }
    }
}