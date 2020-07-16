using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace WindowsFormsApp3
{
    public partial class Form25 : Form
    {
        OracleConnection conn;
        public Form25()
        {
            InitializeComponent();
        }

        private void Form25_Load(object sender, EventArgs e)
        {
            string uid = "CSEFORUM"; //Oracle DB Username
            string password = "123456"; //Password
            string oradb = "Data Source=localhost;user Id=" + uid + ";password=" + password + ";";
            conn = new OracleConnection(oradb);
            conn.Open();
            dataGridView1.RowHeadersVisible = false;
            OracleCommand objCmd = new OracleCommand();
            objCmd.Connection = conn;
            objCmd.CommandText = "event_winner.get_finished_events";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.Add("cur_events", OracleType.Cursor).Direction = ParameterDirection.Output;

            try
            {
                OracleDataReader objReader = objCmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(objReader);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Close();
            var form4 = new Form4();
            form4.Closed += (s, args) => this.Close();
            form4.Show();
            this.Hide();
        }
    }
}
