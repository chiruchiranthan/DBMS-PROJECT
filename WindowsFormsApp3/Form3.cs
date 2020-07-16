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
    public partial class Form3 : Form
    {
        string name;
        string stud_id;
        string sem;
        string sec;
        string ph_no;
        string email;
        OracleConnection conn;

        public Form3()
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

        private void button2_click(object sender, EventArgs e)
        {
            //RESET
            textBox1.Text = "";
            textBox2.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            comboBox1.ResetText();
            comboBox2.ResetText();
            button1.Text = "ADD";
            textBox1.Enabled = true;
        }

        private void button1_click(object sender, EventArgs e)
        {
            stud_id = textBox1.Text;
            name = textBox2.Text;
            sem = (string)comboBox1.SelectedItem;
            sec = (string)comboBox2.SelectedItem;
            ph_no = textBox5.Text;
            email = textBox6.Text;


            if (button1.Text == "ADD")
                insert_student();
            if (button1.Text == "Update")
                update_student();


        }
        public void update_student()
        {
            try
            {
                string query = "UPDATE STUDENT SET  NAME =:ID2, SEM =:ID3, SEC =:ID4, PH_NO =:ID5, EMAIL =:ID7 WHERE STUD_ID =:ID6";
                try
                {
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                       
                        cmd.Parameters.Add("ID2", name);
                        cmd.Parameters.Add("ID3", sem);
                        cmd.Parameters.Add("ID4", sec);
                        cmd.Parameters.Add("ID5", ph_no);
                        cmd.Parameters.Add("ID7", email);
                        cmd.Parameters.Add("ID6", stud_id);

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
            fetch_students();

            //RESET
            textBox1.Text = "";
            textBox2.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            comboBox1.ResetText();
            comboBox2.ResetText();
            button1.Text = "ADD";  //change button name to add
            textBox1.Enabled = true;
        }
        public void insert_student()
        {
            try
            {
                string query = "INSERT INTO STUDENT (STUD_ID, NAME,SEM,SEC,PH_NO,EMAIL) VALUES('" +stud_id+ "','" + name + "','" + sem + "','" + sec + "','" + ph_no + "','" + email + "')";

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
            fetch_students();

            //RESET
            textBox1.Text = "";
            textBox2.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            comboBox1.ResetText();
            comboBox2.ResetText();
        }
        public int delete_student(String dusn)
        {
            string cmdText = "DELETE from STUDENT WHERE stud_id = :ID";  //parameter
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
        public void fetch_students()
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

            string sql = "select * from student"; // C#
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
                        int stud_idindex = dataGridView1.Columns["stud_id"].Index;
                        String dusn = row.Cells[stud_idindex].Value.ToString();
                        int retval = delete_student(dusn);
                        if (retval == -1)
                            MessageBox.Show("Deletion of " + dusn + " Failed");
                    }
                }
                MessageBox.Show("Records Deleted Successfully");
                fetch_students();
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

        private void form3_load(object sender, EventArgs e)
        {
            //conn.Close();
            string uid = "CSEFORUM"; //Oracle DB Username
            string password = "123456"; //Password
            string oradb = "Data Source=localhost;user Id=" + uid + ";password=" + password + ";";
            conn = new OracleConnection(oradb);
            conn.Open();
            fetch_students();


        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
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
                    int retval = delete_student(dusn);
                    if (retval == 1)
                    {
                        MessageBox.Show("Deleted Successfully");
                        fetch_students();
                    }
                }
            }

            if (headerText == "Update" && e.RowIndex >= 0)
            {
                int sidindex = dataGridView1.Columns["STUD_ID"].Index;
                int nameindex = dataGridView1.Columns["NAME"].Index;
                int semindex = dataGridView1.Columns["SEM"].Index;
                int secindex = dataGridView1.Columns["SEC"].Index;
                int phoneindex = dataGridView1.Columns["PH_NO"].Index;
                int emailindex = dataGridView1.Columns["EMAIL"].Index;

                String uusn = dataGridView1.Rows[e.RowIndex].Cells[sidindex].Value.ToString();

                if (MessageBox.Show("Do you want to update " + uusn + "?", "UPDATE", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {


                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[sidindex].Value.ToString();
                    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[nameindex].Value.ToString();

                    string sem = dataGridView1.Rows[e.RowIndex].Cells[semindex].Value.ToString();
                    comboBox1.SelectedItem = sem;
                    string sec = dataGridView1.Rows[e.RowIndex].Cells[secindex].Value.ToString();
                    comboBox2.SelectedItem = sec;
                    textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[emailindex].Value.ToString();
                    textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[phoneindex].Value.ToString();

                    button1.Text = "Update"; //chenge button Add to Update  
                    textBox1.Enabled = false;
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

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Close();
            var form24 = new Form24();
            form24.Closed += (s, args) => this.Close();
            form24.Show();
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
