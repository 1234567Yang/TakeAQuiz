
namespace Quiz
{
    partial class Form4
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_add = new System.Windows.Forms.Button();
            this.richTextBox_a = new System.Windows.Forms.RichTextBox();
            this.richTextBox_q = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_add);
            this.groupBox1.Controls.Add(this.richTextBox_a);
            this.groupBox1.Controls.Add(this.richTextBox_q);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 146);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add";
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(356, 113);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 23);
            this.button_add.TabIndex = 4;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            this.button_add.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Next);
            // 
            // richTextBox_a
            // 
            this.richTextBox_a.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_a.Location = new System.Drawing.Point(437, 21);
            this.richTextBox_a.Name = "richTextBox_a";
            this.richTextBox_a.Size = new System.Drawing.Size(332, 86);
            this.richTextBox_a.TabIndex = 3;
            this.richTextBox_a.Text = "";
            this.richTextBox_a.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Next);
            // 
            // richTextBox_q
            // 
            this.richTextBox_q.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_q.Location = new System.Drawing.Point(52, 21);
            this.richTextBox_q.Name = "richTextBox_q";
            this.richTextBox_q.Size = new System.Drawing.Size(332, 86);
            this.richTextBox_q.TabIndex = 2;
            this.richTextBox_q.Text = "";
            this.richTextBox_q.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Next);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(390, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "answer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "question";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(9, 164);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(780, 278);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listView1_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Question";
            this.columnHeader1.Width = 380;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Answer";
            this.columnHeader2.Width = 380;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 448);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 52);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hot key:\r\n1:Switch to next box and add to list (Ctrl + Entert)\r\n2:Remove from lis" +
    "t (Backgspace)\r\n3:Save (Ctrl + S)";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 509);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Take a quiz - Make a quiz";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form4_FormClosing);
            this.Load += new System.EventHandler(this.Form4_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button button_add;
        public System.Windows.Forms.RichTextBox richTextBox_a;
        public System.Windows.Forms.RichTextBox richTextBox_q;
        public System.Windows.Forms.ListView listView1;
    }
}