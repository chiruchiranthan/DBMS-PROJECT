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
    public partial class Form24 : Form
    {
        
        OracleConnection conn;
        
        public Form24()
        {
            InitializeComponent();
        }

        private void Form24_Load(object sender, EventArgs e)
        {
            string uid = "CSEFORUM"; //Oracle DB Username
            string password = "123456"; //Password
            string oradb = "Data Source=localhost;user Id=" + uid + ";password=" + password + ";";
            conn = new OracleConnection(oradb);
            conn.Open();
            fetch_inactive_students();
        }

        public void fetch_inactive_students()
        { 
            try
            {
                dataGridView1.RowHeadersVisible = false;
                string sql = "select * from inactive_students"; // C#
                OracleCommand ncmd = new OracleCommand(sql, conn);
                using (OracleDataReader reader = ncmd.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;
                }

                dataGridView1.Columns["STUD_ID"].Frozen = true; //makes data grid uneditable
                dataGridView1.Columns["NAME"].Frozen = true;
                dataGridView1.Columns["SEM"].Frozen = true;
                dataGridView1.Columns["SEC"].Frozen = true;
                dataGridView1.Columns["PH_NO"].Frozen = true;
                dataGridView1.Columns["EMAIL"].Frozen = true;
            }
            catch(Exception e)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form3 = new Form3();
            form3.Closed += (s, args) => this.Close();
            form3.Show();
            this.Hide();
        }
    }
}
