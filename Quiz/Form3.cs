using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Forms.DataVisualization.Charting;
using System.IO;


namespace Quiz
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public Dictionary<string,Series> SeriesName = new Dictionary<string,Series>();

        private void setChart(string fileSuffix_withDot, string name, int divide = 1)
        {
            Series series = new Series(name);
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 5;
            string Text_ = File.ReadAllText(Form1.quizFile + fileSuffix_withDot);
            
            while (Text_ != Text_.Replace("\n\n", "\n"))
            {
                Text_ = Text_.Replace("\n\n", "\n");
            }

            //Console.WriteLine($"=={Text}==");
            string[] SplitWrongTime = Text_.Split('\n', (char)StringSplitOptions.RemoveEmptyEntries);

            int i = 0;
            series.Points.AddXY(0,0);
            try
            {
                foreach (var WrongTime in SplitWrongTime)
                {
                    i++; //次数从1开始
                    Console.WriteLine(WrongTime);
                    series.Points.AddXY(i, int.Parse(WrongTime) / divide);
                    
                }
            }
            catch
            {
                Message.dialog.Damaged();
                this.Close();
            }

            try 
            {
                chart1.Series.Add(series);
                SeriesName.Add(name, series);
            }
            catch(Exception ex)
            {
                Message.dialog.showError(ex);
            }
            

        }

        private void recordUTCOpenTime()
        {
            string Text_ = File.ReadAllText(Form1.quizFile + ".utco");
            
            while (Text_ != Text_.Replace("\n\n", "\n"))
            {
                Text_ = Text_.Replace("\n\n", "\n");
            }

            //Console.WriteLine($"-----{Text}");

            //Console.WriteLine($"=={Text}==");
            string[] SplitWrongTime = Text_.Split('\n', (char)StringSplitOptions.RemoveEmptyEntries);

            int i = 0;
            try
            {
                foreach (var WrongTime in SplitWrongTime)
                {
                    
                    //Console.WriteLine(WrongTime);
                    ListViewItem item = new ListViewItem(SplitWrongTime[i]);
                    listView1.Items.Add(item);
                    i++;
                }
            }
            catch
            {
                Message.dialog.Damaged();
                this.Close();
            }
        }
        private void createAllChart()
        {
            setChart(wrong, wrong_des);
            setChart(time, time_des + "(s)");
            setChart(time, time_des + "(m)", 60);
            setChart(time, time_des + "(h)", 3600);
        }
        public const string wrong = ".wrong";
        public const string time = ".time";

        public const string wrong_des = "Number of errors";
        public const string time_des = "Times used to answer";
        private void Form3_Load(object sender, EventArgs e)
        {

            createAllChart();

            Change_Time(radioButton1, new EventArgs());


            recordUTCOpenTime();

            foreach(var area in chart1.ChartAreas)
            {
                area.AxisX.Minimum = 0;
            }

            Message.ICO.ChangeICO(this);

        }

        private void Change_Time(object sender, EventArgs e)
        {
            SeriesName[time_des + "(s)"].Enabled = false;
            SeriesName[time_des + "(m)"].Enabled = false;
            SeriesName[time_des + "(h)"].Enabled = false;

            if (radioButton1.Checked)
            {
                SeriesName[time_des + "(s)"].Enabled = true;
            }else if (radioButton2.Checked)
            {
                SeriesName[time_des + "(m)"].Enabled = true;
            }
            else if (radioButton3.Checked)
            {
                SeriesName[time_des + "(h)"].Enabled = true;
            }
            else
            {
                MessageBox.Show("Something wrong, please restart the progrma.", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox_time_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Checked)
            {
                Change_Time(radioButton1,new EventArgs());
            }
            else
            {
                SeriesName[time_des + "(s)"].Enabled = false;
                SeriesName[time_des + "(m)"].Enabled = false;
                SeriesName[time_des + "(h)"].Enabled = false;
            }
            
            
        }

        private void checkBox_error_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Checked)
            {
                SeriesName[wrong_des].Enabled = true;
            }
            else
            {
                SeriesName[wrong_des].Enabled = false;
            }
                
        }

        //private void chart1_showHit(object sender, EventArgs e)
        //{
        //    MouseEventArgs e_ = e as MouseEventArgs;
        //    HitTestResult result = chart1.HitTest(e_.X, e_.Y);

        //    if (result.ChartElementType == ChartElementType.DataPoint)
        //    {
        //        int pointIndex = result.PointIndex;
        //        DataPoint point = result.Series.Points[pointIndex];


        //        //HitTestResult hitTestResult = chart1.HitTest(e_.X, e_.Y);


        //        toolTip1.Show($"Position = {point.XValue}; Value = {point.YValues[0]};", chart1, e_.Location);
        //    }
        //    else
        //    {
        //        toolTip1.Hide(chart1);
        //    }
        //}


    }
}
