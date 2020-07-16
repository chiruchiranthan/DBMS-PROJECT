using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void student(object sender, EventArgs e)
        {
            
            var form3 = new Form3();
            form3.Closed += (s, args) => this.Close();
            form3.Show();
            this.Hide();
        }

        private void events(object sender, EventArgs e)
        {
            
        }

        private void organizer(object sender, EventArgs e)
        {
            var form5 = new Form5();
            form5.Closed += (s, args) => this.Close();
            form5.Show();
            this.Hide();
        }

        private void sponsor(object sender, EventArgs e)
        {
            var form6 = new Form6();
            form6.Closed += (s, args) => this.Close();
            form6.Show();
            this.Hide();
        }

        private void winner(object sender, EventArgs e)
        {
            var form8 = new Form8();
            form8.Closed += (s, args) => this.Close();
            form8.Show();
            this.Hide();
        }

        private void event_sponsor(object sender, EventArgs e)
        {
            var form7 = new Form7();
            form7.Closed += (s, args) => this.Close();
            form7.Show();
            this.Hide();
        }

        private void sEAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form9 = new Form9();
            form9.Closed += (s, args) => this.Close();
            form9.Show();
            this.Hide();
        }

        private void completedEventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            var form25 = new Form25();
            form25.Closed += (s, args) => this.Close();
            form25.Show();
            this.Hide();
        }

        private void eventsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form4 = new Form4();
            form4.Closed += (s, args) => this.Close();
            form4.Show();
            this.Hide();
        }
    }
}
