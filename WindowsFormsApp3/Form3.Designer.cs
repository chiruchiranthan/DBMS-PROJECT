namespace WindowsFormsApp3
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hometoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.studenttoolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.eventstoolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.cOMPLETEDEVENTSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eVENTSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.organizertoolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.sponsortoolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.eventsponsortoolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.winnertoolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.sEARCHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Lavender;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hometoolStripMenuItem1,
            this.studenttoolStripMenuItem2,
            this.eventstoolStripMenuItem3,
            this.organizertoolStripMenuItem4,
            this.sponsortoolStripMenuItem5,
            this.eventsponsortoolStripMenuItem6,
            this.winnertoolStripMenuItem7,
            this.sEARCHToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1582, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hometoolStripMenuItem1
            // 
            this.hometoolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hometoolStripMenuItem1.Name = "hometoolStripMenuItem1";
            this.hometoolStripMenuItem1.Size = new System.Drawing.Size(65, 24);
            this.hometoolStripMenuItem1.Text = "HOME";
            this.hometoolStripMenuItem1.Click += new System.EventHandler(this.home);
            // 
            // studenttoolStripMenuItem2
            // 
            this.studenttoolStripMenuItem2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studenttoolStripMenuItem2.Name = "studenttoolStripMenuItem2";
            this.studenttoolStripMenuItem2.Size = new System.Drawing.Size(87, 24);
            this.studenttoolStripMenuItem2.Text = "STUDENT";
            // 
            // eventstoolStripMenuItem3
            // 
            this.eventstoolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cOMPLETEDEVENTSToolStripMenuItem,
            this.eVENTSToolStripMenuItem});
            this.eventstoolStripMenuItem3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventstoolStripMenuItem3.Name = "eventstoolStripMenuItem3";
            this.eventstoolStripMenuItem3.Size = new System.Drawing.Size(75, 24);
            this.eventstoolStripMenuItem3.Text = "EVENTS";
            this.eventstoolStripMenuItem3.Click += new System.EventHandler(this.events);
            // 
            // cOMPLETEDEVENTSToolStripMenuItem
            // 
            this.cOMPLETEDEVENTSToolStripMenuItem.Name = "cOMPLETEDEVENTSToolStripMenuItem";
            this.cOMPLETEDEVENTSToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.cOMPLETEDEVENTSToolStripMenuItem.Text = "COMPLETED EVENTS";
            this.cOMPLETEDEVENTSToolStripMenuItem.Click += new System.EventHandler(this.cOMPLETEDEVENTSToolStripMenuItem_Click);
            // 
            // eVENTSToolStripMenuItem
            // 
            this.eVENTSToolStripMenuItem.Name = "eVENTSToolStripMenuItem";
            this.eVENTSToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.eVENTSToolStripMenuItem.Text = "EVENTS";
            this.eVENTSToolStripMenuItem.Click += new System.EventHandler(this.eVENTSToolStripMenuItem_Click);
            // 
            // organizertoolStripMenuItem4
            // 
            this.organizertoolStripMenuItem4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.organizertoolStripMenuItem4.Name = "organizertoolStripMenuItem4";
            this.organizertoolStripMenuItem4.Size = new System.Drawing.Size(103, 24);
            this.organizertoolStripMenuItem4.Text = "ORGANIZER";
            this.organizertoolStripMenuItem4.Click += new System.EventHandler(this.organizer);
            // 
            // sponsortoolStripMenuItem5
            // 
            this.sponsortoolStripMenuItem5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sponsortoolStripMenuItem5.Name = "sponsortoolStripMenuItem5";
            this.sponsortoolStripMenuItem5.Size = new System.Drawing.Size(89, 24);
            this.sponsortoolStripMenuItem5.Text = "SPONSOR";
            this.sponsortoolStripMenuItem5.Click += new System.EventHandler(this.sponsor);
            // 
            // eventsponsortoolStripMenuItem6
            // 
            this.eventsponsortoolStripMenuItem6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventsponsortoolStripMenuItem6.ForeColor = System.Drawing.Color.Black;
            this.eventsponsortoolStripMenuItem6.Name = "eventsponsortoolStripMenuItem6";
            this.eventsponsortoolStripMenuItem6.Size = new System.Drawing.Size(130, 24);
            this.eventsponsortoolStripMenuItem6.Text = "SPONSORED BY";
            this.eventsponsortoolStripMenuItem6.Click += new System.EventHandler(this.event_sponsor);
            // 
            // winnertoolStripMenuItem7
            // 
            this.winnertoolStripMenuItem7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winnertoolStripMenuItem7.Name = "winnertoolStripMenuItem7";
            this.winnertoolStripMenuItem7.Size = new System.Drawing.Size(80, 24);
            this.winnertoolStripMenuItem7.Text = "WINNER";
            this.winnertoolStripMenuItem7.Click += new System.EventHandler(this.winner);
            // 
            // sEARCHToolStripMenuItem
            // 
            this.sEARCHToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sEARCHToolStripMenuItem.Name = "sEARCHToolStripMenuItem";
            this.sEARCHToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.sEARCHToolStripMenuItem.Text = "SEARCH";
            this.sEARCHToolStripMenuItem.Click += new System.EventHandler(this.sEARCHToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(29, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "STUDENT ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(29, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "NAME";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(29, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "SEMESTER";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(29, 311);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "SECTION";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(29, 369);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 23);
            this.label5.TabIndex = 5;
            this.label5.Text = "PHONE NO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(29, 443);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "EMAIL";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(201, 102);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(129, 22);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(201, 172);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(199, 22);
            this.textBox2.TabIndex = 8;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(201, 369);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(129, 22);
            this.textBox5.TabIndex = 11;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(201, 443);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(316, 22);
            this.textBox6.TabIndex = 12;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            " 3",
            " 4",
            " 5",
            " 6",
            " 7",
            " 8"});
            this.comboBox1.Location = new System.Drawing.Point(201, 239);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(73, 24);
            this.comboBox1.TabIndex = 13;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            " A",
            " B"});
            this.comboBox2.Location = new System.Drawing.Point(201, 306);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(73, 24);
            this.comboBox2.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button1.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Firebrick;
            this.button1.Location = new System.Drawing.Point(412, 506);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 37);
            this.button1.TabIndex = 15;
            this.button1.Text = "ADD";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button2.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Firebrick;
            this.button2.Location = new System.Drawing.Point(186, 505);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 38);
            this.button2.TabIndex = 16;
            this.button2.Text = "RESET";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(555, 175);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(762, 312);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(982, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(178, 21);
            this.label7.TabIndex = 18;
            this.label7.Text = "List of students in database";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Palatino Linotype", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.Firebrick;
            this.checkBox1.Location = new System.Drawing.Point(555, 502);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(100, 21);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "SELECT ALL";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.checkbox1_click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Lavender;
            this.button3.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(736, 502);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(167, 32);
            this.button3.TabIndex = 20;
            this.button3.Text = "DELETE SELECTED";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Lavender;
            this.button4.Font = new System.Drawing.Font("Palatino Linotype", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Firebrick;
            this.button4.Location = new System.Drawing.Point(1139, 506);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(178, 41);
            this.button4.TabIndex = 21;
            this.button4.Text = "INACTIVE STUDENTS";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Sitka Banner", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(589, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(521, 87);
            this.label8.TabIndex = 22;
            this.label8.Text = "STUDENT DETAILS";
            // 
            // Form3
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1582, 654);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Location = new System.Drawing.Point(0, 100);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form3";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSE FORUM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.form3_load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hometoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem studenttoolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem eventstoolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem organizertoolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem sponsortoolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem eventsponsortoolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem winnertoolStripMenuItem7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem sEARCHToolStripMenuItem;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem cOMPLETEDEVENTSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eVENTSToolStripMenuItem;
    }
}