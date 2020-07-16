using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp3
{
    public partial class Form9 : Form
    {
        OracleConnection conn;
        public Form9()
        {
            InitializeComponent();
        }

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conn.Close();
            var form2 = new Form2();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
            this.Hide();
        }

        private void sTUDENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conn.Close();
            var form3 = new Form3();
            form3.Closed += (s, args) => this.Close();
            form3.Show();
            this.Hide();
        }

        private void eVENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void oRGANIZERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conn.Close();
            var form5 = new Form5();
            form5.Closed += (s, args) => this.Close();
            form5.Show();
            this.Hide();
        }

        private void sPONSORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conn.Close();
            var form6 = new Form6();
            form6.Closed += (s, args) => this.Close();
            form6.Show();
            this.Hide();
        }

        private void eVENTSPONSORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conn.Close();
            var form7 = new Form7();
            form7.Closed += (s, args) => this.Close();
            form7.Show();
            this.Hide();
        }

        private void wINNERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conn.Close();
            var form8 = new Form8();
            form8.Closed += (s, args) => this.Close();
            form8.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = false;
           
            string sql = "select EVENT_NAME,DESCRIPTION,EVENT_DATE,EVENT_TIME,CATEGORY from event"; // C#
            OracleCommand ncmd = new OracleCommand(sql, conn);
            using (OracleDataReader reader = ncmd.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = false;
            /*DataGridViewCheckBoxColumn dcol = new DataGridViewCheckBoxColumn(); //add select checkbox to all columns
            dcol.HeaderText = "Select";
            dcol.Name = "select";
            dcol.Width = 50;
            dcol.Frozen = false;
            dataGridView1.Columns.Add(dcol);*/
            string sql = "select TYPE,COUNT(*) FROM EVENT GROUP BY TYPE"; // C#
            OracleCommand ncmd = new OracleCommand(sql, conn);
            using (OracleDataReader reader = ncmd.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "select NAME,EVENT_NAME FROM STUDENT S,WINNER W,EVENT E WHERE S.STUD_ID=W.STUD_ID AND W.EVENT_ID=E.EVENT_ID AND W.STUD_ID=:ID1";
            // C#

            OracleCommand ncmd = new OracleCommand(sql, conn);
            ncmd.Parameters.Add("ID1", comboBox1.SelectedItem);
            using (OracleDataReader reader = ncmd.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridView1.DataSource = dataTable;
            }

            //makes data grid uneditable
            dataGridView1.Columns["NAME"].Frozen = true;
            dataGridView1.Columns["EVENT_NAME"].Frozen = true;

        }
        public void fetch_Stud_id()
        {
            comboBox2.Items.Clear(); //clear combobox

            string sql = " select STUD_ID from student"; // C#
            OracleCommand ncmd = new OracleCommand(sql, conn);
            OracleDataReader reader = ncmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    String usn = reader["STUD_ID"].ToString();
                    comboBox2.Items.Add(usn);
                }
            }
        }

        public void fetch_usn()
        {
            comboBox1.Items.Clear(); //clear combobox

            string sql = " select STUD_ID from student"; // C#
            OracleCommand ncmd = new OracleCommand(sql, conn);
            OracleDataReader reader = ncmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    String usn = reader["STUD_ID"].ToString();
                    comboBox1.Items.Add(usn);
                }
            }
        }


        private void Form9_Load(object sender, EventArgs e)
        {
            string uid = "CSEFORUM"; //Oracle DB Username
            string password = "123456"; //Password
            string oradb = "Data Source=localhost;user Id=" + uid + ";password=" + password + ";";
            conn = new OracleConnection(oradb);
            conn.Open();
            fetch_usn();
            fetch_Stud_id();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = false;
            /*DataGridViewCheckBoxColumn dcol = new DataGridViewCheckBoxColumn(); //add select checkbox to all columns
            dcol.HeaderText = "Select";
            dcol.Name = "select";
            dcol.Width = 50;
            dcol.Frozen = false;
            dataGridView1.Columns.Add(dcol);*/
            string sql = "SELECT STUD_ID,COUNT(*) FROM PARTICIPATE GROUP BY STUD_ID HAVING COUNT(*) > 2"; // C#
            OracleCommand ncmd = new OracleCommand(sql, conn);
            using (OracleDataReader reader = ncmd.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridView1.DataSource = dataTable;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = false;
            string sql = "SELECT EVENT_NAME FROM PARTICIPATE P, EVENT E WHERE E.EVENT_ID=P.EVENT_ID AND P.STUD_ID='" + comboBox2.SelectedItem+ "' "; // C#
            OracleCommand ncmd = new OracleCommand(sql, conn);
            using (OracleDataReader reader = ncmd.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridView1.DataSource = dataTable;
            }

            //makes data grid uneditable
            dataGridView1.Columns["EVENT_NAME"].Frozen = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void eVENTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conn.Close();
            var form4 = new Form4();
            form4.Closed += (s, args) => this.Close();
            form4.Show();
            this.Hide();
        }

        private void cOMPLETEDEVENTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conn.Close();
            var form25 = new Form25();
            form25.Closed += (s, args) => this.Close();
            form25.Show();
            this.Hide();
        }
    }
}
