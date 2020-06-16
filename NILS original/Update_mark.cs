using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NILS_original
{
    public partial class Update_mark : MetroFramework.Forms.MetroForm
    {
        private object dataGridView1;

        public Update_mark()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {    
            txt_studnoo.Clear();
            txt_modle1.Clear(); 
            txt_modle2.Clear();
            txt_modle3.Clear();
            txt_modle4.Clear();
            txt_modle5.Clear();
            txt_modle6.Clear();
            txt_modle7.Clear();
            txt_modle8.Clear();
            txt_actn_learn.Clear();
            txt_acmarks.Clear();
        }
        Database db = new Database();
        private void btn_update_Click(object sender, EventArgs e)
        {
            // string mainconn = ConfigurationManager.ConnectionString["MyConnection"].ConnetionString;
            //    Sql
            int i = 0;

            if (string.IsNullOrEmpty(txt_studnoo.Text))
            {
                MessageBox.Show("Please enter Student Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                db.insert("update Dip_stud_marks set mod1='" + txt_modle1.Text + "',  mod2='" + txt_modle2.Text + "',  mod3='" + txt_modle3.Text + "',  mod4='" + txt_modle4.Text + "',  mod5='" + txt_modle5.Text + "',  mod6='" + txt_modle6.Text + "',  mod7='" + txt_modle7.Text + "',  mod8='" + txt_modle8.Text + "',Action_learning='" + txt_actn_learn.Text + "',AL_marks='" + txt_acmarks.Text + "' where stud_no='" + txt_studnoo.Text + "'");
                i = 1;    
            }/* else if (string.IsNullOrEmpty(txt_lname.Text) || txt_lname.Text.Any(char.IsDigit))
             {
                 MessageBox.Show("Please enter correct Last name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }*/

            if(i==1)
            {
                MetroMessageBox.Show(this,"Data updated Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmd_ccname_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string course = cmd_ccname.Text;
          //  SqlCommand cmd2 = new SqlCommand("SELECT * FROM Dip_course_details WHERE course_name='" + cmd_ccname.Text + "'");

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            if(metroToggle1.Checked==true)
            {
                txt_studnoo.Enabled=true;
                txt_modle1.Enabled = true;
                txt_modle2.Enabled = true;
                txt_modle3.Enabled = true;
                txt_modle4.Enabled = true;
                txt_modle5.Enabled = true;
                txt_modle6.Enabled = true;
                txt_modle7.Enabled = true;
                txt_modle8.Enabled = true;
                txt_actn_learn.Enabled = true;
                txt_acmarks.Enabled = true;
            }
            else
            {
                txt_studnoo.Enabled = false;
                txt_modle1.Enabled = false;
                txt_modle2.Enabled = false;
                txt_modle3.Enabled = false;
                txt_modle4.Enabled = false;
                txt_modle5.Enabled = false;
                txt_modle6.Enabled = false;
                txt_modle7.Enabled = false;
                txt_modle8.Enabled = false;
                txt_actn_learn.Enabled = false;
                txt_acmarks.Enabled = false;
            }
        }
    }
}