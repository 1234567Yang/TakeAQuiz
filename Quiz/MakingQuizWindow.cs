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
namespace Quiz
{
    public partial class Form4 : Form
    {
        private bool saved = true;
        private List<(ListViewItem, int)> Ctrl_Z = new List<(ListViewItem, int)>();//有一点元组
        private void RecordToChar()
        {
            string Text_ = File.ReadAllText(Form1.quizFile);
            if (Text_ == "")
            {
                return; //如果是新建的文件
            }
            while (Text_ != Text_.Replace("\n\n", "\n"))
            {
                Text_ = Text_.Replace("\n\n", "\n");
            }

            //Console.WriteLine($"=={Text}==");
            //H   a   o   y   a   n   g       L   i
            string[] SplitList = Text_.Split('\n', (char)StringSplitOptions.RemoveEmptyEntries);
            string[] SplitQA = new string[] { "Question", "Answer" };

            int i = 0;
            foreach (var text in SplitList)
            {
                SplitQA = text.Split('|');

                ListViewItem item = new ListViewItem();

                if(SplitQA.Length == 2)
                {
                    item.Text = SplitQA[0];
                    item.SubItems.Add(SplitQA[1]);
                }


                listView1.Items.Add(item);
                i++;
            }

        }

        private void DisableAdd(bool not_disable)
        {
            richTextBox_a.Enabled = not_disable;
            richTextBox_q.Enabled = not_disable;
            button_add.Enabled = not_disable;
        }

        private void Next_Error()
        {
            Message.dialog.showError($"Unknown. Place:{this}");
        }
        private void Next_CleanRichTextBox()
        {
            richTextBox_a.Text = "";
            richTextBox_q.Text = "";
        }
        private void Next(object sender, KeyPressEventArgs e)
       {
            var button = new Button();
            var rtb = new RichTextBox();

            //Console.WriteLine((int)e.KeyChar);
            if ((int)e.KeyChar == 10) //Ctrl + Enter
            {

                //直接删掉，因为在RichTextBox2那里再按一次直接记录就行了

                //if (sender is Button)
                //{
                //    button = sender as Button;
                //    if (button == button_add) //如果是addButton的话
                //    {
                //        button_add_Click(button_add, new EventArgs()); //先记录再切换
                //        richTextBox_q.Focus();
                //    }
                //    else
                //    {
                //        Next_Error();
                //    }
                //}
                if (sender is RichTextBox) //如果是RichTextBox的话
                {
                    rtb = sender as RichTextBox;

                    rtb.Text = rtb.Text.Substring(0, rtb.Text.Length - 1); //去掉最后一个回车

                    if (rtb == richTextBox_q)
                    {
                        richTextBox_a.Focus();
                    }
                    else if (rtb == richTextBox_a)
                    {
                        //button_add.Focus();

                        DisableAdd(false);

                        button_add_Click(button_add, new EventArgs()); //直接记录
                        Next_CleanRichTextBox();

                        DisableAdd(true);

                    }
                    else
                    {
                        Next_Error();
                    }
                }
                else
                {
                    Next_Error();
                }
            }

        }

        public bool Save()
        {
            List<string> QAList = new List<string>();
            string QAFile = "";

            foreach (ListViewItem item in listView1.Items)
            {
                string q = item.SubItems[0].Text; //NM真奇怪
                string a = item.SubItems[1].Text;

                Console.WriteLine($"q:{q};a:{a};");
                //item.Text = richTextBox_q.Text;
                //item.SubItems.Add(richTextBox_a.Text);

                QAList.Add(q + "|" + a);
            }

            foreach (string SingleQA in QAList)
            {
                if(QAFile == "")
                {
                    QAFile = SingleQA;
                }
                else
                {
                    QAFile += "\n" + SingleQA;
                }
                
            }

            try
            {
                File.WriteAllText(Form1.quizFile, QAFile);
            }
            catch(Exception ex)
            {
                Message.dialog.showError("Could not write to the file!");
                Message.dialog.showError(ex);
                return false;
            }
            saved = true;
            Message.dialog.showHit("File saved!");
            return true;
            
        }
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            RecordToChar();
            //Save();

            Message.ICO.ChangeICO(this);
        }

        private void listView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 8) //delete
            {
                //Console.WriteLine("1345");
                if (listView1.SelectedItems.Count > 0)
                {
                    //----------不能多项选择---------多项选择需要重新写代码！！！

                    Ctrl_Z.Add((listView1.SelectedItems[0], listView1.SelectedIndices[0]));

                    listView1.Items.RemoveAt(listView1.SelectedIndices[0]); //selectedIndices - 数值, selectedItem - 对象


                    listView1.SelectedItems.Clear(); // 防止异常
                    saved = false;
                    //----------不能多项选择---------多项选择需要重新写代码！！！
                }

            }
            if ((int)e.KeyChar == 26) //Ctrl + Z
            {
                if (Ctrl_Z.Count > 0)
                {
                    // listView1.Items.Add(Ctrl_Z[0].Item1);
                    listView1.Items.Insert(Ctrl_Z[Ctrl_Z.Count - 1].Item2, Ctrl_Z[Ctrl_Z.Count - 1].Item1);
                    //∵引索从0开始，count从1开始，
                    //∴ - 1

                    Ctrl_Z.RemoveAt(Ctrl_Z.Count - 1);

                    listView1.SelectedItems.Clear(); // 防止异常，经过测试恢复后仍然会被选中

                }
            }

            if ((int)e.KeyChar == 19)
            {
                Save();
            }

            Console.WriteLine((int)e.KeyChar);
        }
        public void button_add_Click(object sender, EventArgs e)
        {
            saved = false;
            DisableAdd(false); //在这里加的原因是为了防止用户没用热键操作

            ListViewItem item = new ListViewItem();
            
            string question = richTextBox_q.Text;
            string answer = richTextBox_a.Text;
            if (question == "" || answer == "")
            {
                Message.dialog.showHit("The question or the answer could not be empty!");
            }
                //while(question.Substring(question.Length-1, 1) == "\n")
                //{
                //    question = question.Substring(0, question.Length - 1);
                //}

                //while (answer.Substring(answer.Length - 1, 1) == "\n")
                //{
                //    answer = answer.Substring(0, answer.Length - 1);
                //}

                question = question.Replace("\n", "【***[**NenLine**]***】");
            answer = answer.Replace("\n", "【***[**NenLine**]***】");

            question = question.Replace("|", "\\");
            answer = answer.Replace("|", "\\");

            Console.WriteLine(question);

            item.Text = question;
            item.SubItems.Add(answer);
            listView1.Items.Add(item);
            Next_CleanRichTextBox();

            DisableAdd(true);


            richTextBox_q.Focus();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = DialogResult.Cancel;
            if (!saved)
            {
                dialogResult = MessageBox.Show("Do you want to save the quiz?", "Ask:", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        if (!Save()) e.Cancel = true;
                        break;

                    case DialogResult.No:
                        //直接退出
                        break;

                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }

        }
    }
}
