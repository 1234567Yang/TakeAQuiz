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
using System.Media;

namespace Quiz
{
    public partial class Form2 : Form
    {
        private List<Button> ABCDButton = new List<Button>();
        private int RightAnswer = 0;
        private int RightChoice_Button = 0;

        private Random random = new Random();


        private List<string> Questions = new List<string>(); //忘记改用structure或者元组了，不想改。

        private List<string> Answers = new List<string>(); // when finsh one question, the answer will be deleted with the question.

        private List<string> AnswersWithoutDeleting = new List<string>();

        private List<(string, string)> RecordingWrongAnswer = new List<(string, string)>();

        public Form2()
        {
            InitializeComponent();
        }

        //private void RemoveReapted<T>(ref T List_) where T : ICollection<T>{
        //    ICollection<T> returnList = new typeof(List_);
        //    foreach (var item in List_)
        //    {

        //    }

        //}
        //private void RemoveRepeated<T>(ref ICollection<T> list_)
        //{
        //    ICollection<T> returnList = new List<T>();
        //    bool Included = false;
        //    foreach (var item in list_)
        //    {
        //        foreach (var returnItem in returnList)
        //        {
        //            if (item.Equals(returnItem))
        //            {
        //                Included = true;
        //            }
        //        }
        //        if (!Included)
        //        {
        //            returnList.Add(item);
        //        }
        //        else
        //        {
        //            Included = false;
        //        }
        //    }

        //    list_ = returnList;
        //}
        private void RemoveRepeated<T>(ref List<T> list_)
        {
            List<T> returnList = new List<T>();
            bool Included = false;
            foreach (var item in list_)
            {
                foreach (var returnItem in returnList)
                {
                    if (item.Equals(returnItem))
                    {
                        Included = true;
                    }
                }
                if (!Included)
                {
                    returnList.Add(item);
                }
                else
                {
                    Included = false;
                }
            }

            list_ = returnList;
        }
        private void InitializeQuiz()
        {

            try
            {
                File.ReadAllText(StartWindow.quizFile); //先尝试读入一遍，没有问题再继续
            }
            catch (Exception ex)
            {
                Message.dialog.showError(ex);
                this.Close();
                return;
            }

            string quizAllContent = File.ReadAllText(StartWindow.quizFile);

            while (quizAllContent != quizAllContent.Replace("\n\n", "\n"))
            {
                quizAllContent = quizAllContent.Replace("\n\n", "\n");
            }

            string[] quizSplitedContent = quizAllContent.Split('\n', (char)StringSplitOptions.RemoveEmptyEntries);

            if (quizSplitedContent.Length == 0)
            {
                MessageBox.Show("Could not read any information, please check if the file is wrong or the program has access to it.", "Warning:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            string[] tempSplit = new string[] { "Question", "Answer" };
            try
            {
                foreach (var text in quizSplitedContent)
                {
                    tempSplit = text.Split('|');
                    if (tempSplit.Length == 2)
                    {
                        tempSplit[0] = tempSplit[0].Replace("【***[**NenLine**]***】", "\n");
                        tempSplit[1] = tempSplit[1].Replace("【***[**NenLine**]***】", "\n");

                        Questions.Add(tempSplit[0]);
                        Answers.Add(tempSplit[1]);

                        AnswersWithoutDeleting.Add(tempSplit[1]);
                        //answersWithoutDeleting = answers; 出现问题，会跟着减少
                    }

                }

            }
            catch
            {
                Message.dialog.Damaged();
                this.Close();
            }

            //foreach(var e in questions)
            //{
            //    Console.WriteLine($"Question:{e}");
            //}

            //foreach (var e2 in answers)
            //{
            //    Console.WriteLine($"Answer:{e2}");
            //}
            //Console.WriteLine(answers.Count);

            recording_start();
            InitializeQuiz_FormInfo();
        }

        private void InitializeQuiz_FormInfo()
        {
            label_tnum.Text = Questions.Count.ToString();
            label_time_used.Text = "0";
            label_incorrect.Text = "0";
        }

        private void WriteWrongQuestionToFile()
        {

            if (RecordingWrongAnswer.Count == 0)
            {
                return;
            }

            RemoveRepeated<(string, string)>(ref RecordingWrongAnswer);
            string TempQuizFile = "";
            //foreach ((string, string) oneQA in RecordingWrongAnswer)
            //{
            //    if(AllText == "")
            //    {
            //        AllText = oneQA.Item1 + "|" + oneQA.Item2;
            //    }
            //    else
            //    {
            //        AllText = AllText + "\n" + oneQA.Item1 + "|" + oneQA.Item2;
            //    }
            //}
            //try
            //{
            //    Console.WriteLine(Form1.quizFile + $".{DateTime.UtcNow.Ticks.ToString()}.WrongQuesions.txt");
            //    File.WriteAllText(Form1.quizFile + $".{DateTime.UtcNow.Ticks.ToString()}.WrongQuesions.txt", AllText);

            //}
            //catch(Exception ex)
            //{
            //    Message.dialog.showError(ex);
            //}
            TempQuizFile = StartWindow.quizFile; //***************************--***************************
            StartWindow.quizFile = StartWindow.quizFile + $".{DateTime.UtcNow.Ticks.ToString()}.WrongQuesions.txt";
            Form4 form4 = new Form4();
            form4.Visible = false;
            foreach ((string, string) oneQA in RecordingWrongAnswer)
            {
                form4.richTextBox_q.Text = oneQA.Item1;
                form4.richTextBox_a.Text = oneQA.Item2;
                form4.button_add_Click(form4.button_add, new EventArgs());
            }
            form4.Save();

            StartWindow.quizFile = TempQuizFile; //***************************--***************************

        }
        private bool FinishedQuiz() //里面有个找不出来的bug，直接放弃
        {
            recording_end();
            WriteWrongQuestionToFile();
            Message.dialog.showHit("Congratulation! You finished all of the question!");
            return false;

        }
        private void recording_start()
        {
            if (!File.Exists(StartWindow.quizFile + ".utco"))
            {
                File.WriteAllText(StartWindow.quizFile + ".utco", DateTime.UtcNow.ToString());
            }
            else
            {
                File.WriteAllText(StartWindow.quizFile + ".utco", File.ReadAllText(StartWindow.quizFile + ".utco") + "\n" + DateTime.UtcNow); //utco - UTC opened
            }

        }
        private void recording_end()
        {
            if (!File.Exists(StartWindow.quizFile + ".time"))
            {
                File.WriteAllText(StartWindow.quizFile + ".time", label_time_used.Text);
            }
            else
            {
                File.WriteAllText(StartWindow.quizFile + ".time", File.ReadAllText(StartWindow.quizFile + ".time") + "\n" + label_time_used.Text);
            }

            if (!File.Exists(StartWindow.quizFile + ".wrong"))
            {
                File.WriteAllText(StartWindow.quizFile + ".wrong", label_incorrect.Text);
            }
            else
            {
                File.WriteAllText(StartWindow.quizFile + ".wrong", File.ReadAllText(StartWindow.quizFile + ".wrong") + "\n" + label_incorrect.Text);
            }

            //File.WriteAllText(Form1.quizFile + ".time", File.ReadAllText(Form1.quizFile + ".time") + "\n" + label_time_used.Text);
            //File.WriteAllText(Form1.quizFile + ".wrong", File.ReadAllText(Form1.quizFile + ".wrong") + "\n" + label_incorrect.Text);
        }
        private void setOneQuestion()
        {
            //----------判断是否完成----------
            if (Questions.Count == 0)
            {
                if (FinishedQuiz() == false)
                {
                    this.Close();
                    return;
                }
                else
                {
                    InitializeQuiz();
                }
            }

            //----------判断是否完成----------

            //----------生成正确答案并添加到form----------
            int SelectedQuestionIndex = random.Next(0, Questions.Count);

            //Console.WriteLine($"SelectedQuestionIndex:{SelectedQuestionIndex};question:{questions[SelectedQuestionIndex]};answer:{answers[SelectedQuestionIndex]}");

            label_question_name.Text = Questions[SelectedQuestionIndex];


            RightChoice_Button = random.Next(0, 4); //0,1,2,3,随机选取一个作为正确答案

            //Console.WriteLine($"RightButton:{RightChoice_Button.ToString()}");

            ABCDButton[RightChoice_Button].Text = Answers[SelectedQuestionIndex];

            Console.WriteLine($"RightChoice_Button:{RightChoice_Button};Q:{Questions[SelectedQuestionIndex]};A:{Answers[SelectedQuestionIndex]}");

            RightAnswer = SelectedQuestionIndex;

            //----------生成正确答案并添加到form----------

            //----------生成错误答案----------
            int randnum = 0;
            int times = 0;

            foreach (var singleButton in ABCDButton)
            {
                //Console.WriteLine(singleButton.Name);
                randnum = random.Next(0, AnswersWithoutDeleting.Count);

                while (AnswersWithoutDeleting[randnum] == Answers[SelectedQuestionIndex]) //防止出现同样的答案
                {
                    times++;
                    randnum = random.Next(0, AnswersWithoutDeleting.Count);
                    if (times > 9999) //尝试次数太多
                    {
                        break;
                    }
                }

                if (singleButton != ABCDButton[RightChoice_Button])
                {
                    singleButton.Text = AnswersWithoutDeleting[randnum]; //21个count,从0开始，所以不加1
                }


            }
            //----------生成错误答案----------


            //----------其它form操作----------
            label_rnum.Text = Questions.Count.ToString();
            //----------其它form操作----------
        }

        private void afterAnswered(bool correct)
        {
            if (correct == false)
            {
                string RightText = ABCDButton[RightChoice_Button].Text;

                label_info.BackColor = Color.Red;
                label_info.ForeColor = Color.White;
                label_info.Text = $"You are wrong, the answer is: \n {RightText} \n Please try again!";

                RecordingWrongAnswer.Add((label_question_name.Text, RightText));

                label_incorrect.Text = (int.Parse(label_incorrect.Text) + 1).ToString();
            }
            else
            {
                label_info.BackColor = Color.White;
                label_info.ForeColor = Color.Black;
                label_info.Text = $"Congratulation! You are correct! Time: {DateTime.Now}; Random number: {random.Next(0, int.MaxValue)}"; //UTC Time:{DateTime.UtcNow}


                Action playMusicAct = new Action(playMusic);
                playMusicAct.BeginInvoke(null, null);


                Console.WriteLine($"Right Answer:{RightAnswer}");
                Answers.RemoveAt(RightAnswer);
                Questions.RemoveAt(RightAnswer);

                RightAnswer = 0;

                setOneQuestion();
            }


        }

        private void playMusic()
        {
            Random random_ms = new Random();
            SoundPlayer soundPlayer = new SoundPlayer();
            string MusicList = random_ms.Next(1, 2 + 1).ToString(); //包前不包后
            string MusicDic = $"C:\\ProgramData\\TakeAQuiz\\Music{MusicList}.wav";
            if (checkBox_bgm.Checked)
            {
                soundPlayer.SoundLocation = MusicDic;
                soundPlayer.Play();
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {


            //#if DEBUG
            //            timer1.Enabled = false;
            //#endif


            ABCDButton.Add(button_A);
            ABCDButton.Add(button_B);
            ABCDButton.Add(button_C);
            ABCDButton.Add(button_D);

            //foreach(var d in ABCDButton)
            //{
            //    Console.WriteLine(d.Name);
            //}

            //Console.WriteLine(ABCDButton.Count);


            InitializeQuiz();
            //for (int i = 0; i < 99; i++)
            //{
            //    Console.WriteLine(random.Next(0, answersWithoutDeleting.Count));
            //}
            setOneQuestion();

            Message.ICO.ChangeICO(this);
        }

        private void AnswerSelected_ButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == ABCDButton[RightChoice_Button])
            {
                afterAnswered(true);
            }
            else
            {
                afterAnswered(false);
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            label_time_used.Text = (int.Parse(label_time_used.Text) + 1).ToString();
        }
    }
}
