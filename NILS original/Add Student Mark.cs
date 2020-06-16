using System;
using NILS_original;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Threading;
using MetroFramework;

namespace NILS_original
{
     
    public partial class Add_Student_Mark : MetroFramework.Forms.MetroForm
    {
        public Add_Student_Mark()
        {
            InitializeComponent();
           
        }
        
        Database db= new Database();
        SqlConnection con = new SqlConnection(Credentials.connection);
        string[] names = new string[30];
        public string[] no;
        int count;
        private void Add_Student_Mark_Load(object sender, EventArgs e)
        {
            /*con.Open();
            SqlCommand cmd = new SqlCommand("Select course_name from Dip_course_details ", con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                names[count] = rd.GetValue(0).ToString();
               // names[1,count] = rd.GetValue(1).ToString(); //course name
                count++;
            }
           // cmd_cname.DataSource = names;
            rd.Close();
            con.Close();*/

        }
        public string cname;
        private void btn_clear_Click(object sender, EventArgs e)
        {
            // string path = "Provider = SQLOLEDB; Data Source = " + textBox1.Text + "; Initial Catalog = MyDB; Integrated Security = SSPI";
          if(string.IsNullOrEmpty(txt_choosefile.Text))
            {
                MetroMessageBox.Show(this, "Please Choose your Correct file location. .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else if ( string.IsNullOrEmpty(txt_Load.Text) )
            {
                MetroMessageBox.Show(this, "Please enter required sheet name .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string path = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txt_choosefile.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
                OleDbConnection con = new OleDbConnection(path);
                OleDbDataAdapter Oda = new OleDbDataAdapter("select * from [" + txt_Load.Text + "$]", con);
                DataTable dt = new DataTable();
                Oda.Fill(dt);
                dataGridView1.DataSource = dt;

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Update_mark f1 = new Update_mark();
            f1.Show();

             

            f1.txt_studnoo.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            f1.txt_modle1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            f1.txt_modle2.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            f1.txt_modle3.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            f1.txt_modle4.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            f1.txt_modle5.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            f1.txt_modle6.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            f1.txt_modle7.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            f1.txt_modle8.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
            f1.txt_actn_learn.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
            f1.txt_acmarks.Text = this.dataGridView1.CurrentRow.Cells[10].Value.ToString();


        }

        private void btn_cal_Click(object sender, EventArgs e)//update
        {           
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.txt_choosefile.Text = ofd.FileName;
                }
            
        }
        Database dr2 = new Database();
        public string num;
        private void cmd_cname_SelectedIndexChanged(object sender, EventArgs e)
        { 

        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void txtBtnUpload_Click(object sender, EventArgs e)//btnUpload
        {

             int i = 0;
            if (dataGridView1.Rows.Count > 1)
            {
                for (int c = 0; c < (dataGridView1.Rows.Count - 1); c++)
                {              
                    db.insert("update Dip_stud_marks set mod1='" + dataGridView1.Rows[c].Cells[1].Value.ToString() + "',  mod2='" + dataGridView1.Rows[c].Cells[2].Value.ToString() + "',  mod3='" + dataGridView1.Rows[c].Cells[3].Value.ToString() + "',  mod4='" + dataGridView1.Rows[c].Cells[4].Value.ToString() + "',  mod5='" + dataGridView1.Rows[c].Cells[5].Value.ToString() + "',  mod6='" + dataGridView1.Rows[c].Cells[6].Value.ToString() + "',  mod7='" + dataGridView1.Rows[c].Cells[7].Value.ToString() + "',  mod8='" + dataGridView1.Rows[c].Cells[8].Value.ToString() + "',Action_learning='" + dataGridView1.Rows[c].Cells[9].Value.ToString() + "',AL_marks='" + dataGridView1.Rows[c].Cells[10].Value.ToString() + "' where stud_no='" + dataGridView1.Rows[c].Cells[0].Value.ToString() + "'");
                   i = 1;
                }
               
            }
            else
                MetroMessageBox.Show(this, "Please Select Required data field..");

            if (i == 1)
                MetroMessageBox.Show(this, "Data Inserted Successfully..");
        
        }

        private void metroButton1_Click(object sender, EventArgs e)//refresh
        {
            dataGridView1.DataSource = db.show("SELECT * FROM Dip_stud_details");
        }

        private void txt_choosefile_TextChanged(object sender, EventArgs e)
        {

        }
    }




    }

