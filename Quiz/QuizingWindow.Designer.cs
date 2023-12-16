
namespace Quiz
{
    partial class QuizingWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label_tnum = new System.Windows.Forms.Label();
            this.label_rnum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_bgm = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_info = new System.Windows.Forms.Label();
            this.button_D = new System.Windows.Forms.Button();
            this.button_C = new System.Windows.Forms.Button();
            this.button_B = new System.Windows.Forms.Button();
            this.button_A = new System.Windows.Forms.Button();
            this.label_question_name = new System.Windows.Forms.Label();
            this.label_incorrect = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label_time_used = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "total question : ";
            // 
            // label_tnum
            // 
            this.label_tnum.AutoSize = true;
            this.label_tnum.Location = new System.Drawing.Point(92, 9);
            this.label_tnum.Name = "label_tnum";
            this.label_tnum.Size = new System.Drawing.Size(13, 13);
            this.label_tnum.TabIndex = 1;
            this.label_tnum.Text = "0";
            // 
            // label_rnum
            // 
            this.label_rnum.AutoSize = true;
            this.label_rnum.Location = new System.Drawing.Point(123, 32);
            this.label_rnum.Name = "label_rnum";
            this.label_rnum.Size = new System.Drawing.Size(13, 13);
            this.label_rnum.TabIndex = 3;
            this.label_rnum.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "rested question : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_bgm);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label_info);
            this.groupBox1.Controls.Add(this.button_D);
            this.groupBox1.Controls.Add(this.button_C);
            this.groupBox1.Controls.Add(this.button_B);
            this.groupBox1.Controls.Add(this.button_A);
            this.groupBox1.Controls.Add(this.label_question_name);
            this.groupBox1.Location = new System.Drawing.Point(15, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 436);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "question detail";
            // 
            // checkBox_bgm
            // 
            this.checkBox_bgm.AutoSize = true;
            this.checkBox_bgm.Location = new System.Drawing.Point(563, 376);
            this.checkBox_bgm.Name = "checkBox_bgm";
            this.checkBox_bgm.Size = new System.Drawing.Size(114, 17);
            this.checkBox_bgm.TabIndex = 7;
            this.checkBox_bgm.Text = "Background music";
            this.checkBox_bgm.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(560, 407);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "the wrong questions will be automaticly\r\n saved under the same directory";
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.BackColor = System.Drawing.Color.White;
            this.label_info.Location = new System.Drawing.Point(11, 376);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(59, 13);
            this.label_info.TabIndex = 5;
            this.label_info.Text = "Information";
            // 
            // button_D
            // 
            this.button_D.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_D.Location = new System.Drawing.Point(381, 269);
            this.button_D.Name = "button_D";
            this.button_D.Size = new System.Drawing.Size(369, 94);
            this.button_D.TabIndex = 4;
            this.button_D.Text = "D";
            this.button_D.UseVisualStyleBackColor = true;
            this.button_D.Click += new System.EventHandler(this.AnswerSelected_ButtonClick);
            // 
            // button_C
            // 
            this.button_C.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_C.Location = new System.Drawing.Point(6, 269);
            this.button_C.Name = "button_C";
            this.button_C.Size = new System.Drawing.Size(369, 94);
            this.button_C.TabIndex = 3;
            this.button_C.Text = "C";
            this.button_C.UseVisualStyleBackColor = true;
            this.button_C.Click += new System.EventHandler(this.AnswerSelected_ButtonClick);
            // 
            // button_B
            // 
            this.button_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_B.Location = new System.Drawing.Point(381, 169);
            this.button_B.Name = "button_B";
            this.button_B.Size = new System.Drawing.Size(369, 94);
            this.button_B.TabIndex = 2;
            this.button_B.Text = "B";
            this.button_B.UseVisualStyleBackColor = true;
            this.button_B.Click += new System.EventHandler(this.AnswerSelected_ButtonClick);
            // 
            // button_A
            // 
            this.button_A.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_A.Location = new System.Drawing.Point(6, 169);
            this.button_A.Name = "button_A";
            this.button_A.Size = new System.Drawing.Size(369, 94);
            this.button_A.TabIndex = 1;
            this.button_A.Text = "A";
            this.button_A.UseVisualStyleBackColor = true;
            this.button_A.Click += new System.EventHandler(this.AnswerSelected_ButtonClick);
            // 
            // label_question_name
            // 
            this.label_question_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_question_name.Location = new System.Drawing.Point(9, 27);
            this.label_question_name.Name = "label_question_name";
            this.label_question_name.Size = new System.Drawing.Size(741, 139);
            this.label_question_name.TabIndex = 0;
            this.label_question_name.Text = "The question";
            this.label_question_name.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_incorrect
            // 
            this.label_incorrect.AutoSize = true;
            this.label_incorrect.ForeColor = System.Drawing.Color.Red;
            this.label_incorrect.Location = new System.Drawing.Point(172, 57);
            this.label_incorrect.Name = "label_incorrect";
            this.label_incorrect.Size = new System.Drawing.Size(13, 13);
            this.label_incorrect.TabIndex = 6;
            this.label_incorrect.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "times you answered incorrectly:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label_time_used
            // 
            this.label_time_used.AutoSize = true;
            this.label_time_used.Location = new System.Drawing.Point(497, 9);
            this.label_time_used.Name = "label_time_used";
            this.label_time_used.Size = new System.Drawing.Size(13, 13);
            this.label_time_used.TabIndex = 8;
            this.label_time_used.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(393, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "total time used (s) : ";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 543);
            this.Controls.Add(this.label_time_used);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_incorrect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_rnum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_tnum);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Take a quiz - quizzing";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_tnum;
        private System.Windows.Forms.Label label_rnum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_D;
        private System.Windows.Forms.Button button_C;
        private System.Windows.Forms.Button button_B;
        private System.Windows.Forms.Button button_A;
        private System.Windows.Forms.Label label_question_name;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Label label_incorrect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label_time_used;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_bgm;
    }
}