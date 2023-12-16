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
    public partial class LockWindow : Form
    {
        public string password = "";
        public LockWindow()
        {
            InitializeComponent();
        }

        private void LockWindow_Load(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\ProgramData\Yang\TakeAQuiz"))
            {
                try
                {
                    password = File.ReadAllText(@"C:\ProgramData\Yang\TakeAQuiz");
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
        }

        private void LockWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(this.textBox1.Text ==password)
            {
                Environment.Exit(0);
            }
        }
    }
}
