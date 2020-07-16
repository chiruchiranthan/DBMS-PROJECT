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

    public partial class Form5 : Form
    {
        string stud_id;
        string event_id;
        OracleConnection conn;
        public Form5()
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

        private void sponsor(object sender, EventArgs e)
        {
            conn.Close();
            var form6 = new Form6();
            form6.Closed += (s, args) => this.Close();
            form6.Show();
            this.Hide();
        }

        private void event_sponsor(object sender, EventArgs e)
        {
            conn.Close();
            var form7 = new Form7();
            form7.Closed += (s, args) => this.Close();
            form7.Show();
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

        private void Form5_Load(object sender, EventArgs e)
        {
            string uid = "CSEFORUM"; //Oracle DB Username
            string password = "123456"; //Password
            string oradb = "Data Source=localhost;user Id=" + uid + ";password=" + password + ";";
            conn = new OracleConnection(oradb);
            conn.Open();
            fetch_organizer();
            fetch_Stud_id();
            fetch_event_id();
        }

        public void fetch_Stud_id()
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

        public void fetch_event_id()
        {
            comboBox2.Items.Clear(); //clear combobox

            string sql = " select EVENT_ID from EVENT"; // C#
            OracleCommand ncmd = new OracleCommand(sql, conn);
            OracleDataReader reader = ncmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    String usn = reader["EVENT_ID"].ToString();
                    comboBox2.Items.Add(usn);
                }
            }

        }
        public void update_organizer()
        {
            try
            {
                string query = "UPDATE ORGANIZER SET STUD_ID=:ID2, EVENT_ID =:ID3 WHERE STUD_ID =:ID4";
                try
                {
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {

                        cmd.Parameters.Add("ID2", stud_id);
                        cmd.Parameters.Add("ID3", event_id);
                        cmd.Parameters.Add("ID4", stud_id);
                        


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
            fetch_organizer();

            //RESET
            comboBox1.ResetText();
            comboBox2.ResetText();
            button1.Text = "ADD";  //change button name to add
            comboBox1.Enabled = true;
            
        }
        public void insert_organizer()
        {
            try
            {
                string query = "INSERT INTO ORGANIZER (STUD_ID, EVENT_ID) VALUES ('" + stud_id + "','" + event_id + "')";

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
            fetch_organizer();

            //RESET
            comboBox1.ResetText();
            comboBox2.ResetText();

        }
        public int delete_organizer(String dusn)
        {
            string cmdText = "DELETE from ORGANIZER WHERE stud_id = :ID";  //parameter
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
        public void fetch_organizer()
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

            string sql = "select * from organizer"; // C#
            OracleCommand ncmd = new OracleCommand(sql, conn);
            using (OracleDataReader reader = ncmd.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridView1.DataSource = dataTable;
            }

            dataGridView1.Columns["STUD_ID"].Frozen = true; //makes data grid uneditable
            dataGridView1.Columns["EVENT_ID"].Frozen = true;


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

            if (!dataGridView1.Columns.Contains("update"))
            {

                DataGridViewButtonColumn ucol = new DataGridViewButtonColumn(); //add update button to all columns
                ucol.HeaderText = "Update";
                ucol.Text = "update";
                ucol.Name = "update";
                ucol.Width = 50;
                ucol.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(ucol);
            }
        }

        private void button1_click(object sender, EventArgs e)
        {
            stud_id = (String)comboBox1.SelectedItem;
            event_id = (String)comboBox2.SelectedItem;


            if (button1.Text == "ADD")
                insert_organizer();
            if (button1.Text == "Update")
                update_organizer();

        }

        private void button2_click(object sender, EventArgs e)
        {
            //RESET
            comboBox1.ResetText();
            comboBox2.ResetText();
        }

        private void button3_click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Delete ?", "DELETE", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //multiple delete
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    if (chk.Value != null && (bool)chk.Value)
                    {
                        int sidindex = dataGridView1.Columns["stud_id"].Index;
                        String dusn = row.Cells[sidindex].Value.ToString();
                        int retval = delete_organizer(dusn);
                        if (retval == -1)
                            MessageBox.Show("Deletion of " + dusn + " Failed");
                    }
                }
                MessageBox.Show("Records Deleted Successfully");
                fetch_organizer();
            }
        }

        private void checkbox1_click(object sender, EventArgs e)
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

        private void datagridview1_cellcontentclick(object sender, DataGridViewCellEventArgs e)
        {
            string headerText = dataGridView1.Columns[e.ColumnIndex].HeaderText;
            //MessageBox.Show(headerText);
            if (headerText == "Delete" && e.RowIndex >= 0)
            {
                int usnindex = dataGridView1.Columns["STUD_ID"].Index;
                String dusn = dataGridView1.Rows[e.RowIndex].Cells[usnindex].Value.ToString();
                //MessageBox.Show(dusn);
                if (MessageBox.Show("Do you want to Delete " + dusn + "?", "DELETE", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int retval = delete_organizer(dusn);
                    if (retval == 1)
                    {
                        MessageBox.Show("Deleted Successfully");
                        fetch_organizer();
                    }
                }
            }

            if (headerText == "Update" && e.RowIndex >= 0)
            {
                int sidindex = dataGridView1.Columns["STUD_ID"].Index;
                int eveindex = dataGridView1.Columns["EVENT_ID"].Index;
                

                String uusn = dataGridView1.Rows[e.RowIndex].Cells[sidindex].Value.ToString();

                if (MessageBox.Show("Do you want to update " + uusn + "?", "UPDATE", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {


                    string sem = dataGridView1.Rows[e.RowIndex].Cells[sidindex].Value.ToString();
                    comboBox1.SelectedItem = sem;
                    string sec = dataGridView1.Rows[e.RowIndex].Cells[eveindex].Value.ToString();
                    comboBox2.SelectedItem = sec;
                    button1.Text = "Update"; //chenge button Add to Update  
                    comboBox1.Enabled= false;
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
