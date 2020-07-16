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
    public partial class Form4 : Form
    {
        String event_id;
        String event_name;
        String type;
        String description;
        String event_date;
        String event_time;
        String category;
        OracleConnection conn;
        public Form4()
        {
            InitializeComponent();
        }

        private void winner(object sender, EventArgs e)
        {
            conn.Close();
            var form8 = new Form8();
            form8.Closed += (s, args) => this.Close();
            form8.Show();
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

        private void sponsor(object sender, EventArgs e)
        {
            conn.Close();
            var form6 = new Form6();
            form6.Closed += (s, args) => this.Close();
            form6.Show();
            this.Hide();
        }

        private void organizer(object sender, EventArgs e)
        {
            conn.Close();
            var form5 = new Form5();
            form5.Closed += (s, args) => this.Close();
            form5.Show();
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

        private void home(object sender, EventArgs e)
        {
            conn.Close();
            var form2 = new Form2();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
            this.Hide();
        }
        public void update_events()
        {
            try
            {
                string query = "UPDATE EVENT SET EVENT_NAME =:ID2, TYPE =:ID3, DESCRIPTION =:ID4, EVENT_DATE =:ID5, EVENT_TIME =:ID7, CATEGORY =:ID8 WHERE EVENT_ID =:ID6";
                 try
                 {
                     using (OracleCommand cmd = new OracleCommand(query, conn))
                     {

                         cmd.Parameters.Add("ID2", event_name);
                         cmd.Parameters.Add("ID3", type);
                         cmd.Parameters.Add("ID4", description);
                         cmd.Parameters.Add("ID5", event_date);
                         cmd.Parameters.Add("ID7", event_time);
                         cmd.Parameters.Add("ID8", category);
                         cmd.Parameters.Add("ID6", event_id);
                       // MessageBox.Show(category);
                         cmd.ExecuteNonQuery();
                        //MessageBox.Show(category);
                     }
                     //MessageBox.Show(category);
                 }
                 /*
                string query = "UPDATE EVENT SET EVENT_NAME =:ID1 WHERE EVENT_ID =:ID2";
                try
                {
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {

                        cmd.Parameters.Add("ID1", event_name);
                        cmd.Parameters.Add("ID2", event_id);
                        cmd.ExecuteNonQuery();
                    }
                }*/
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
            fetch_events();

            //RESET
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            dateTimePicker1.ResetText();
            comboBox1.ResetText();
            comboBox2.ResetText();
            button1.Text = "ADD";  //change button name to add
            textBox1.Enabled = true;
        }
        public void insert_events()
        {
            try
            {
                string query = "INSERT INTO EVENT (EVENT_ID, EVENT_NAME,TYPE,DESCRIPTION,EVENT_DATE,EVENT_TIME,CATEGORY) VALUES('" + event_id + "','" + event_name + "','" + type + "','" + description + "','" + event_date + "','" + event_time + "','" + category + "')";
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

            MessageBox.Show("Record Added");
            fetch_events();

            //RESET
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            dateTimePicker1.ResetText();
            comboBox1.ResetText();
            comboBox2.ResetText();
        }
        public int delete_events(String dusn)
        {
            string cmdText = "DELETE from EVENT WHERE event_id = :ID";  //parameter
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
        public void fetch_events()
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
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = true;
                chk.Value = false;
            }

        }

        private void button1_click(object sender, EventArgs e)
        {
            event_id = textBox1.Text;
            event_name = textBox2.Text;
            type = (string)comboBox1.SelectedItem;
            category = (string)comboBox2.SelectedItem;
            description = textBox3.Text;
            event_time = textBox4.Text;
            int day = dateTimePicker1.Value.Day;
            int mon = dateTimePicker1.Value.Month;
            int year = dateTimePicker1.Value.Year;
            String month = "";
            switch (mon)
            {
                case 1: month = "JAN"; break;
                case 2: month = "FEB"; break;
                case 3: month = "MAR"; break;
                case 4: month = "APR"; break;
                case 5: month = "MAY"; break;
                case 6: month = "JUN"; break;
                case 7: month = "JUL"; break;
                case 8: month = "AUG"; break;
                case 9: month = "SEP"; break;
                case 10: month = "OCT"; break;
                case 11: month = "NOV"; break;
                case 12: month = "DEC"; break;
            }
            event_date = day + "-" + month + "-" + year;



            if (button1.Text == "ADD")
                insert_events();
            if (button1.Text == "Update")
                update_events();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string uid = "CSEFORUM"; //Oracle DB Username
            string password = "123456"; //Password
            string oradb = "Data Source=localhost;user Id=" + uid + ";password=" + password + ";";
            conn = new OracleConnection(oradb);
            conn.Open();
            fetch_events();
        }

        private void datagrid1_cellcontent_click(object sender, DataGridViewCellEventArgs e)
        {
            string headerText = dataGridView1.Columns[e.ColumnIndex].HeaderText;
            //MessageBox.Show(headerText);
            if (headerText == "Select" && e.RowIndex >= 0)
            {                
                int selindex = dataGridView1.Columns["Select"].Index;
                Boolean bb = true; //MessageBox.Show("here" + e.RowIndex + "c" + selindex);
                DataGridViewCheckBoxCell ckb = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells[0];
                
                if ((bool)ckb.Value)
                    ckb.Value = false;
                else { ckb.Value = true; }
            }
            if (headerText == "Delete" && e.RowIndex >= 0)
            {
                int usnindex = dataGridView1.Columns["EVENT_ID"].Index;
                String dusn = dataGridView1.Rows[e.RowIndex].Cells[usnindex].Value.ToString();
                //MessageBox.Show(dusn);
                if (MessageBox.Show("Do you want to Delete " + dusn + "?", "DELETE", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int retval = delete_events(dusn);
                    if (retval == 1)
                    {
                        MessageBox.Show("Deleted Successfully");
                        fetch_events();
                    }
                }
            }

            if (headerText == "Update" && e.RowIndex >= 0)
            {
                int eve_idindex = dataGridView1.Columns["EVENT_ID"].Index;
                int eve_nameindex = dataGridView1.Columns["EVENT_NAME"].Index;
                int typeindex = dataGridView1.Columns["TYPE"].Index;
                int descindex = dataGridView1.Columns["DESCRIPTION"].Index;
                int eve_dateindex = dataGridView1.Columns["EVENT_DATE"].Index;
                int eve_timeindex = dataGridView1.Columns["EVENT_TIME"].Index;
                int cateindex = dataGridView1.Columns["CATEGORY"].Index;

                String uusn = dataGridView1.Rows[e.RowIndex].Cells[eve_idindex].Value.ToString();

                if (MessageBox.Show("Do you want to update " + uusn + "?", "UPDATE", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {


                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[eve_idindex].Value.ToString();
                    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[eve_nameindex].Value.ToString();

                    string type = dataGridView1.Rows[e.RowIndex].Cells[typeindex].Value.ToString();
                    comboBox1.SelectedItem = type;
                    string cate = dataGridView1.Rows[e.RowIndex].Cells[cateindex].Value.ToString();
                    comboBox2.SelectedItem = cate;
                    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[descindex].Value.ToString();
                    textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[eve_timeindex].Value.ToString();
                    string dob = dataGridView1.Rows[e.RowIndex].Cells[eve_dateindex].Value.ToString();
                    string[] dobparms = dob.Split('-');
                    int day = int.Parse(dobparms[0]);
                    int mon = int.Parse(dobparms[1]);
                    string[] yearparms = dobparms[2].Split(' ');
                    int year = int.Parse(yearparms[0]);
                    dateTimePicker1.Value = new DateTime(year, mon, day);


                    button1.Text = "Update"; //chenge button Add to Update  
                    textBox1.Enabled = false;
                }
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
                        int eve_idindex = dataGridView1.Columns["event_id"].Index;
                        String dusn = row.Cells[eve_idindex].Value.ToString();
                        int retval = delete_events(dusn);
                        if (retval == -1)
                            MessageBox.Show("Deletion of " + dusn + " Failed");
                    }
                }
                MessageBox.Show("Records Deleted Successfully");
                fetch_events();
            }
        }

        private void button2_click(object sender, EventArgs e)
        {
            //RESET
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            dateTimePicker1.ResetText();
            comboBox1.ResetText();
            comboBox2.ResetText();
            button1.Text = "ADD";
            textBox1.Enabled = true;
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

        private void sEARCHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conn.Close();
            var form9 = new Form9();
            form9.Closed += (s, args) => this.Close();
            form9.Show();
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

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
