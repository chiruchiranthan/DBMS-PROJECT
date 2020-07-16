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

    public partial class Form22 : Form
    {
        OracleConnection conn;
        String stud_id;
        String event_id;

        public Form22()
        {
            InitializeComponent();
        }

        private void Form22_Load(object sender, EventArgs e)
        {
            //conn.Close();
            string uid = "CSEFORUM"; //Oracle DB Username
            string password = "123456"; //Password
            string oradb = "Data Source=localhost;user Id=" + uid + ";password=" + password + ";";
            conn = new OracleConnection(oradb);
            conn.Open();
            fetch_events();
            fetch_event_id();
        }

        public void fetch_event_id()
        {
            comboBox1.Items.Clear(); //clear combobox

            string sql = " select EVENT_ID from EVENT"; // C#
            OracleCommand ncmd = new OracleCommand(sql, conn);
            OracleDataReader reader = ncmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    String usn = reader["EVENT_ID"].ToString();
                    comboBox1.Items.Add(usn);
                }
            }
        }
        public void fetch_events()
        {
            dataGridView1.RowHeadersVisible = false;

            string sql = "select * from event"; // C#
            OracleCommand ncmd = new OracleCommand(sql, conn);
            using (OracleDataReader reader = ncmd.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridView1.DataSource = dataTable;
            }

            dataGridView1.Columns["EVENT_ID"].Frozen = true; //makes data grid uneditable
            dataGridView1.Columns["EVENT_NAME"].Frozen = true;
            dataGridView1.Columns["TYPE"].Frozen = true;
            dataGridView1.Columns["DESCRIPTION"].Frozen = true;
            dataGridView1.Columns["EVENT_DATE"].Frozen = true;
            dataGridView1.Columns["EVENT_TIME"].Frozen = true;
            dataGridView1.Columns["CATEGORY"].Frozen = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            stud_id = textBox1.Text;
            event_id = (String)comboBox1.SelectedItem;
           

            if (button1.Text == "REGISTER")
               register_student();
        }
        public void register_student()
        {
            try
            {
                string query = "INSERT INTO PARTICIPATE (STUD_ID, EVENT_ID) VALUES('" + stud_id + "','" + event_id + "')";
                //MessageBox.Show(query);
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

            MessageBox.Show("student registered");

            //RESET
            textBox1.Text = "";
            comboBox1.ResetText();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Close();
            var form21= new Form21();
            form21.Closed += (s, args) => this.Close();
            form21.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Close();
            var form26 = new Form26();
            form26.Closed += (s, args) => this.Close();
            form26.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
