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
    public partial class Form6 : Form
    {
        string spon_id;
        string spon_name;
        string spon_phno;
        string spon_email;
        OracleConnection conn;
        public Form6()
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

        private void Form6_Load(object sender, EventArgs e)
        {
            string uid = "CSEFORUM"; //Oracle DB Username
            string password = "123456"; //Password
            string oradb = "Data Source=localhost;user Id=" + uid + ";password=" + password + ";";
            conn = new OracleConnection(oradb);
            conn.Open();
            fetch_sponsor();
        }
        public void update_sponsor()
        {
            try
            {
                string query = "UPDATE SPONSOR SET SPONSOR_NAME=:ID2, SPON_PH_NO =:ID3 , SPON_EMAIL=:ID5 WHERE SPONSOR_ID =:ID4";
                try
                {
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {

                        cmd.Parameters.Add("ID2", spon_name);
                        cmd.Parameters.Add("ID3", spon_phno);
                        cmd.Parameters.Add("ID5", spon_email);
                        cmd.Parameters.Add("ID4", spon_id);


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
            fetch_sponsor();

            //RESET
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            button1.Text = "ADD";  //change button name to add
            textBox1.Enabled = true;
        }
        public void insert_sponsor()
        {
            try
            {
                string query = "INSERT INTO SPONSOR ( SPONSOR_ID,SPONSOR_NAME,SPON_PH_NO,SPON_EMAIL) VALUES ('" + spon_id + "','" + spon_name + "','" + spon_phno + "','" + spon_email + "')";

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
            fetch_sponsor();

            //RESET
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }
        public int delete_sponsor(String dusn)
        {
            string cmdText = "DELETE from SPONSOR WHERE sponsor_id = :ID";  //parameter
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
        public void fetch_sponsor()
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

            string sql = "select * from sponsor"; // C#
            OracleCommand ncmd = new OracleCommand(sql, conn);
            using (OracleDataReader reader = ncmd.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridView1.DataSource = dataTable;
            }

            dataGridView1.Columns["SPONSOR_ID"].Frozen = true; //makes data grid uneditable
            dataGridView1.Columns["SPONSOR_NAME"].Frozen = true;
            dataGridView1.Columns["SPON_PH_NO"].Frozen = true;
            dataGridView1.Columns["SPON_EMAIL"].Frozen = true;


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

        private void button1_Click(object sender, EventArgs e)
        {
            spon_name = textBox2.Text;
            spon_id = textBox1.Text;
            spon_phno = textBox3.Text;
            spon_email = textBox4.Text;


            if (button1.Text == "ADD")
                insert_sponsor();
            if (button1.Text == "Update")
                update_sponsor();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string headerText = dataGridView1.Columns[e.ColumnIndex].HeaderText;
            //MessageBox.Show(headerText);
            if (headerText == "Delete" && e.RowIndex >= 0)
            {
                int usnindex = dataGridView1.Columns["SPONSOR_ID"].Index;
                String dusn = dataGridView1.Rows[e.RowIndex].Cells[usnindex].Value.ToString();
                //MessageBox.Show(dusn);
                if (MessageBox.Show("Do you want to Delete " + dusn + "?", "DELETE", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int retval = delete_sponsor(dusn);
                    if (retval == 1)
                    {
                        MessageBox.Show("Deleted Successfully");
                        fetch_sponsor();
                    }
                }
            }

            if (headerText == "Update" && e.RowIndex >= 0)
            {
                int spon_idindex = dataGridView1.Columns["SPONSOR_ID"].Index;
                int spon_nameindex = dataGridView1.Columns["SPONSOR_NAME"].Index;
                int ph_noindex = dataGridView1.Columns["SPON_PH_NO"].Index;
                int spon_emailindex = dataGridView1.Columns["SPON_EMAIL"].Index;


                String uusn = dataGridView1.Rows[e.RowIndex].Cells[spon_idindex].Value.ToString();

                if (MessageBox.Show("Do you want to update " + uusn + "?", "UPDATE", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {


                    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[spon_nameindex].Value.ToString();
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[spon_idindex].Value.ToString();
                    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[ph_noindex].Value.ToString();
                    textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[spon_emailindex].Value.ToString();
                    button1.Text = "Update"; //chenge button Add to Update  
                    textBox1.Enabled = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
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
                        int eventindex = dataGridView1.Columns["SPONSOR_ID"].Index;
                        String dusn = row.Cells[eventindex].Value.ToString();
                        int retval = delete_sponsor(dusn);
                        if (retval == -1)
                            MessageBox.Show("Deletion of " + dusn + " Failed");
                    }
                }
                MessageBox.Show("Records Deleted Successfully");
                fetch_sponsor();
            }
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
