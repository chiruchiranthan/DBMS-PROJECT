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
    public partial class Form7 : Form
    {
        string event_id;
        string sponsor_id;
        OracleConnection conn;
        public Form7()
        {
            InitializeComponent();
        }

        private void home(object sender, EventArgs e)
        {
            conn.Close();
            var form2 = new Form2();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
            this.Hide();
        }

        private void student(object sender, EventArgs e)
        {
            conn.Close();
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
            conn.Close();
            var form5 = new Form5();
            form5.Closed += (s, args) => this.Close();
            form5.Show();
            this.Hide();
        }

        private void sponsor(object sender, EventArgs e)
        {
            conn.Close();
            var form6 = new Form6();
            form6.Closed += (s, args) => this.Close();
            form6.Show();
            this.Hide();
        }

        private void winner(object sender, EventArgs e)
        {
            conn.Close();
            var form8 = new Form8();
            form8.Closed += (s, args) => this.Close();
            form8.Show();
            this.Hide();
        }
        public void fetch_spon_id()
        {
            comboBox2.Items.Clear(); //clear combobox

            string sql = " select sponsor_ID from SPONSOR"; // C#
            OracleCommand ncmd = new OracleCommand(sql, conn);
            OracleDataReader reader = ncmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    String usn = reader["SPONSOR_ID"].ToString();
                    comboBox2.Items.Add(usn);
                }
            }
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
        public void update_eventsponsor()
        {
            try
            {
                string query = "UPDATE SPONSORED_BY SET SPONSOR_ID=:ID2, EVENT_ID =:ID3 WHERE SPONSOR_ID =:ID4";
                try
                {
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {

                        cmd.Parameters.Add("ID2", sponsor_id);
                        cmd.Parameters.Add("ID3", event_id);
                        cmd.Parameters.Add("ID4",sponsor_id);


                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show("Exception");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                button1.Text = "ADD";  //change button name to add
                return;
            }

            MessageBox.Show("Record Updated Sucessfully");
            fetch_eventsponsor();

            //RESET
            comboBox1.ResetText();
            comboBox2.ResetText();
            button1.Text = "ADD";  //change button name to add
            
        }
        public void insert_organizer()
        {
            try
            {
                string query = "INSERT INTO SPONSORED_BY ( EVENT_ID,SPONSOR_ID) VALUES ('" + event_id + "','" + sponsor_id + "')";

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

            MessageBox.Show("Record Added");
            fetch_eventsponsor();

            //RESET
            comboBox1.ResetText();
            comboBox2.ResetText();

        }
        public int delete_eventsponsor(String dusn)
        {
            string cmdText = "DELETE from SPONSORED_BY WHERE event_id = :ID";  //parameter
            try
            {
                using (OracleCommand cmd = new OracleCommand(cmdText, conn))
                {
                    cmd.Parameters.Add("ID", dusn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Exception");
                return -1; //error
            }
            return 1;
        }
        public void fetch_eventsponsor()
        {
            if (!dataGridView1.Columns.Contains("select"))
            {
                dataGridView1.RowHeadersVisible = false;
                DataGridViewCheckBoxColumn dcol = new DataGridViewCheckBoxColumn(); //add select checkbox to all columns
                dcol.HeaderText = "Select";
                dcol.Name = "select";
                dcol.Width = 50;
                dcol.Frozen = false;
                dataGridView1.Columns.Add(dcol);
            }

            string sql = "select * from sponsored_by"; // C#
            OracleCommand ncmd = new OracleCommand(sql, conn);
            using (OracleDataReader reader = ncmd.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridView1.DataSource = dataTable;
            }

            dataGridView1.Columns["EVENT_ID"].Frozen = true; //makes data grid uneditable
            dataGridView1.Columns["SPONSOR_ID"].Frozen = true;


            if (!dataGridView1.Columns.Contains("delete"))
            {
                dataGridView1.RowHeadersVisible = false;
                DataGridViewButtonColumn dcol = new DataGridViewButtonColumn(); //add delete button to all columns
                dcol.HeaderText = "Delete";
                dcol.Text = "delete";
                dcol.Name = "delete";
                dcol.Width = 50;

                dcol.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(dcol);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sponsor_id = (String)comboBox2.SelectedItem;
            event_id = (String)comboBox1.SelectedItem;


            if (button1.Text == "ADD")
                insert_organizer();
            if (button1.Text == "Update")
                update_eventsponsor();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //RESET
            comboBox1.ResetText();
            comboBox2.ResetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Delete ?", "DELETE", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //multiple delete
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    if (chk.Value != null && (bool)chk.Value)
                    {
                        int sponindex = dataGridView1.Columns["sponsor_id"].Index;
                        String dusn = row.Cells[sponindex].Value.ToString();
                        int retval = delete_eventsponsor(dusn);
                        if (retval == -1)
                            MessageBox.Show("Deletion of " + dusn + " Failed");
                    }
                }
                MessageBox.Show("Records Deleted Successfully");
                fetch_eventsponsor();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string headerText = dataGridView1.Columns[e.ColumnIndex].HeaderText;
            //MessageBox.Show(headerText);
            if (headerText == "Delete" && e.RowIndex >= 0)
            {
                int usnindex = dataGridView1.Columns["EVENT_ID"].Index;
                String dusn = dataGridView1.Rows[e.RowIndex].Cells[usnindex].Value.ToString();
                //MessageBox.Show(dusn);
                if (MessageBox.Show("Do you want to Delete " + dusn + "?", "DELETE", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int retval = delete_eventsponsor(dusn);
                    if (retval == 1)
                    {
                        MessageBox.Show("Deleted Successfully");
                        fetch_eventsponsor();
                    }
                }
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            string uid = "CSEFORUM"; //Oracle DB Username
            string password = "123456"; //Password
            string oradb = "Data Source=localhost;user Id=" + uid + ";password=" + password + ";";
            conn = new OracleConnection(oradb);
            conn.Open();
            fetch_eventsponsor();
            fetch_spon_id();
            fetch_event_id();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    chk.Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    chk.Value = false;
                }
            }
        }

        private void sEARCHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conn.Close();
            var form9 = new Form9();
            form9.Closed += (s, args) => this.Close();
            form9.Show();
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

        private void eVENTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conn.Close();
            var form4 = new Form4();
            form4.Closed += (s, args) => this.Close();
            form4.Show();
            this.Hide();
        }
    }
}
