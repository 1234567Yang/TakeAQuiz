namespace Quiz
{
    partial class TimingWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.label_time_left = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "time left(m):";
            // 
            // label_time_left
            // 
            this.label_time_left.AutoSize = true;
            this.label_time_left.Location = new System.Drawing.Point(82, 9);
            this.label_time_left.Name = "label_time_left";
            this.label_time_left.Size = new System.Drawing.Size(10, 13);
            this.label_time_left.TabIndex = 1;
            this.label_time_left.Text = "-";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 15);
            this.button1.TabIndex = 2;
            this.button1.Text = "Take the quiz now";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TimingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(132, 43);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_time_left);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TimingWindow";
            this.Opacity = 0.5D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "KeepLiveWindow";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.KeepLiveWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_time_left;
        private System.Windows.Forms.Button button1;
    }
}