namespace Quiz
{
    partial class SettingWindow
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_setting = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_lock_rest_time = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_lock_quiz_file = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.tabPage_verify = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage_setting.SuspendLayout();
            this.tabPage_verify.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_setting);
            this.tabControl1.Controls.Add(this.tabPage_verify);
            this.tabControl1.ItemSize = new System.Drawing.Size(96, 1);
            this.tabControl1.Location = new System.Drawing.Point(3, -5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(357, 179);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_setting
            // 
            this.tabPage_setting.Controls.Add(this.button1);
            this.tabPage_setting.Controls.Add(this.label3);
            this.tabPage_setting.Controls.Add(this.textBox_lock_rest_time);
            this.tabPage_setting.Controls.Add(this.label2);
            this.tabPage_setting.Controls.Add(this.textBox_lock_quiz_file);
            this.tabPage_setting.Controls.Add(this.label1);
            this.tabPage_setting.Controls.Add(this.textBox_password);
            this.tabPage_setting.Location = new System.Drawing.Point(4, 5);
            this.tabPage_setting.Name = "tabPage_setting";
            this.tabPage_setting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_setting.Size = new System.Drawing.Size(349, 170);
            this.tabPage_setting.TabIndex = 0;
            this.tabPage_setting.Text = "setting";
            this.tabPage_setting.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(157, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 26);
            this.label3.TabIndex = 12;
            this.label3.Text = "lock quiz rest time \r\n(minute):";
            // 
            // textBox_lock_rest_time
            // 
            this.textBox_lock_rest_time.Location = new System.Drawing.Point(157, 79);
            this.textBox_lock_rest_time.Name = "textBox_lock_rest_time";
            this.textBox_lock_rest_time.Size = new System.Drawing.Size(143, 20);
            this.textBox_lock_rest_time.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "lock quiz file:";
            // 
            // textBox_lock_quiz_file
            // 
            this.textBox_lock_quiz_file.Location = new System.Drawing.Point(157, 48);
            this.textBox_lock_quiz_file.Name = "textBox_lock_quiz_file";
            this.textBox_lock_quiz_file.Size = new System.Drawing.Size(143, 20);
            this.textBox_lock_quiz_file.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "password:";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(157, 18);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(143, 20);
            this.textBox_password.TabIndex = 7;
            // 
            // tabPage_verify
            // 
            this.tabPage_verify.Controls.Add(this.button2);
            this.tabPage_verify.Controls.Add(this.label4);
            this.tabPage_verify.Controls.Add(this.textBox1);
            this.tabPage_verify.Location = new System.Drawing.Point(4, 5);
            this.tabPage_verify.Name = "tabPage_verify";
            this.tabPage_verify.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_verify.Size = new System.Drawing.Size(349, 170);
            this.tabPage_verify.TabIndex = 1;
            this.tabPage_verify.Text = "verify";
            this.tabPage_verify.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(130, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "verify";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "password: ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(186, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // SettingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 176);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingWindow";
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.SettingWindow_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_setting.ResumeLayout(false);
            this.tabPage_setting.PerformLayout();
            this.tabPage_verify.ResumeLayout(false);
            this.tabPage_verify.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_setting;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_lock_rest_time;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_lock_quiz_file;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.TabPage tabPage_verify;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
    }
}