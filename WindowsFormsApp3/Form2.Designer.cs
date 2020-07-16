namespace WindowsFormsApp3
{
    partial class Form2
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hometoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.studenttoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.eventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.completedEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.organizerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sponsorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventsponsorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.winnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sEAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hometoolStripMenuItem1,
            this.studenttoolStripMenuItem1,
            this.eventsToolStripMenuItem,
            this.organizerToolStripMenuItem,
            this.sponsorToolStripMenuItem,
            this.eventsponsorToolStripMenuItem,
            this.winnerToolStripMenuItem,
            this.sEAToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1747, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hometoolStripMenuItem1
            // 
            this.hometoolStripMenuItem1.Name = "hometoolStripMenuItem1";
            this.hometoolStripMenuItem1.Size = new System.Drawing.Size(65, 24);
            this.hometoolStripMenuItem1.Text = "HOME";
            // 
            // studenttoolStripMenuItem1
            // 
            this.studenttoolStripMenuItem1.Name = "studenttoolStripMenuItem1";
            this.studenttoolStripMenuItem1.Size = new System.Drawing.Size(87, 24);
            this.studenttoolStripMenuItem1.Text = "STUDENT";
            this.studenttoolStripMenuItem1.Click += new System.EventHandler(this.student);
            // 
            // eventsToolStripMenuItem
            // 
            this.eventsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.completedEventsToolStripMenuItem,
            this.eventsToolStripMenuItem1});
            this.eventsToolStripMenuItem.Name = "eventsToolStripMenuItem";
            this.eventsToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.eventsToolStripMenuItem.Text = "EVENTS";
            this.eventsToolStripMenuItem.Click += new System.EventHandler(this.events);
            // 
            // completedEventsToolStripMenuItem
            // 
            this.completedEventsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completedEventsToolStripMenuItem.Name = "completedEventsToolStripMenuItem";
            this.completedEventsToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.completedEventsToolStripMenuItem.Text = "COMPLETED EVENTS";
            this.completedEventsToolStripMenuItem.Click += new System.EventHandler(this.completedEventsToolStripMenuItem_Click);
            // 
            // eventsToolStripMenuItem1
            // 
            this.eventsToolStripMenuItem1.Name = "eventsToolStripMenuItem1";
            this.eventsToolStripMenuItem1.Size = new System.Drawing.Size(227, 26);
            this.eventsToolStripMenuItem1.Text = "EVENTS";
            this.eventsToolStripMenuItem1.Click += new System.EventHandler(this.eventsToolStripMenuItem1_Click);
            // 
            // organizerToolStripMenuItem
            // 
            this.organizerToolStripMenuItem.Name = "organizerToolStripMenuItem";
            this.organizerToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
            this.organizerToolStripMenuItem.Text = "ORGANIZER";
            this.organizerToolStripMenuItem.Click += new System.EventHandler(this.organizer);
            // 
            // sponsorToolStripMenuItem
            // 
            this.sponsorToolStripMenuItem.Name = "sponsorToolStripMenuItem";
            this.sponsorToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.sponsorToolStripMenuItem.Text = "SPONSOR";
            this.sponsorToolStripMenuItem.Click += new System.EventHandler(this.sponsor);
            // 
            // eventsponsorToolStripMenuItem
            // 
            this.eventsponsorToolStripMenuItem.Name = "eventsponsorToolStripMenuItem";
            this.eventsponsorToolStripMenuItem.Size = new System.Drawing.Size(130, 24);
            this.eventsponsorToolStripMenuItem.Text = "SPONSORED BY";
            this.eventsponsorToolStripMenuItem.Click += new System.EventHandler(this.event_sponsor);
            // 
            // winnerToolStripMenuItem
            // 
            this.winnerToolStripMenuItem.Name = "winnerToolStripMenuItem";
            this.winnerToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.winnerToolStripMenuItem.Text = "WINNER";
            this.winnerToolStripMenuItem.Click += new System.EventHandler(this.winner);
            // 
            // sEAToolStripMenuItem
            // 
            this.sEAToolStripMenuItem.Name = "sEAToolStripMenuItem";
            this.sEAToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.sEAToolStripMenuItem.Text = "SEARCH";
            this.sEAToolStripMenuItem.Click += new System.EventHandler(this.sEAToolStripMenuItem_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::WindowsFormsApp3.Properties.Resources._539231d375e163d90e2476c5bee3e515;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1747, 741);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Location = new System.Drawing.Point(0, 200);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSE FORUM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hometoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem studenttoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem eventsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem organizerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sponsorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventsponsorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem winnerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sEAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem completedEventsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventsToolStripMenuItem1;
    }
}