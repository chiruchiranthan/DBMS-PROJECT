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
    public partial class Form20 : Form
    {
        OracleConnection conn;
        public Form20()
        {
            //conn.Close();
            InitializeComponent();
            string uid = "CSEFORUM"; //Oracle DB Username
            string password = "123456"; //Password
            string oradb = "Data Source=localhost;user Id=" + uid + ";password=" + password + ";";
            conn = new OracleConnection(oradb);
            conn.Open();
            string sql = " select * from admin"; // C#
            OracleCommand ncmd = new OracleCommand(sql, conn);
            using (OracleDataReader reader = ncmd.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = " select * from admin where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'"; // C#
            OracleCommand ncmd = new OracleCommand(sql, conn);
            OracleDataReader reader = ncmd.ExecuteReader();
            if (reader.Read())
            {
                // MessageBox.Show("connected");
                // Form3 f=new Form3(); //-- Wild life
                // Form4 f = new Form4();  // this is for forest data entry
                // Form5 f = new Form5(); //TREES data
                // Form7 f = new Form7();
                // Form8 f = new Form8();
                //Form9 f = new Form9();
                //Form11 f = new Form11();
                // Form12 f = new Form12();
                // Form13 f = new Form13();
                Form2 f = new Form2();
                f.Show();
                this.Hide();
                return;
            }
            MessageBox.Show("Wrong credentials");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Close();
            var form21 = new Form21();
            form21.Closed += (s, args) => this.Close();
            form21.Show();
            this.Hide();
        }

        private void Form20_Load(object sender, EventArgs e)
        {

        }
    }
}
