using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class Form11 : Form
    {
        static OracleConnection conn;
        public Form11()
        {
           
            InitializeComponent();
            string uid = "system"; //Oracle DB Username
            string password = "arpitha123"; //Password
            string oradb = "Data Source=localhost;user Id=" + uid + ";password=" + password + ";";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            string sql = @" SELECT F.F_NAME
FROM FOREST F,FOREST_WILD_LIFE W, TREES T
 WHERE F.F_NAME = W.F_NAME
AND F.F_NAME = T.F_NAME
AND F.LOCATION = W.LOCATION AND W_NAME ='"+ textBox1.Text+"'"+"AND LEAF_COLOUR = '"+textBox2.Text+"'";
            OracleCommand ncmd = new OracleCommand(sql, conn);
            using (OracleDataReader reader = ncmd.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridView1.DataSource = dataTable;

            }
        }
    }
    }

