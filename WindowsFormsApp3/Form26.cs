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
    public partial class Form26 : Form
    {
        OracleConnection conn;
        public Form26()
        {
            InitializeComponent();
        }

        private void Form26_Load(object sender, EventArgs e)
        {
            string uid = "CSEFORUM"; //Oracle DB Username
            string password = "123456"; //Password
            string oradb = "Data Source=localhost;user Id=" + uid + ";password=" + password + ";";
            conn = new OracleConnection(oradb);
            conn.Open();
            fetch_winner();
        }

        public void fetch_winner()
        {
            dataGridView1.RowHeadersVisible = false;
            string sql = "select * from winner"; // C#
            OracleCommand ncmd = new OracleCommand(sql, conn);
            using (OracleDataReader reader = ncmd.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridView1.DataSource = dataTable;
            }

            dataGridView1.Columns["EVENT_ID"].Frozen = true; //makes data grid uneditable
            dataGridView1.Columns["STUD_ID"].Frozen = true;
            dataGridView1.Columns["PRIZE"].Frozen = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Close();
            var form22 = new Form22();
            form22.Closed += (s, args) => this.Close();
            form22.Show();
            this.Hide();
        }
    }
}
