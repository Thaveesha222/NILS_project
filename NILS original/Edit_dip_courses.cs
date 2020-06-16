using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NILS_original
{
    public partial class Edit_dip_courses : MetroFramework.Forms.MetroForm
    {
        public Edit_dip_courses()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Credentials.connection);

        private void Edit_dip_courses_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Module_name,compulsory FROM Dip_module_details_2 WHERE Course_no='" + lbl_cno.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                checkedListBox1.Items.Add(dr.GetValue(0).ToString());
                if (dr.GetBoolean(1)==true)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
                else
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
                i++;
            }
            con.Close();
        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            
            Edit_course_fee e1 = new Edit_course_fee();
            Edit_course_fee.cno = lbl_cno.Text;
            //e1.Owner = this;
            e1.Show();
        }

        private void metroLink2_Click(object sender, EventArgs e)
        {
            Edit_reg_fee r = new Edit_reg_fee();
            Edit_reg_fee.cno = lbl_cno.Text;
            //r.Owner = this;
            r.Show();
        }
        Database d = new Database();

        private void metroLink3_Click(object sender, EventArgs e)
        {
            try
            {
                if (metroCheckBox1.Checked == true)
                {
                    d.update("UPDATE Course_details_master SET English='1' WHERE course_no='" + lbl_cno.Text + "'");
                }
                else
                {
                    d.update("UPDATE Course_details_master SET English='0' WHERE course_no='" + lbl_cno.Text + "'");
                }
                if (metroCheckBox2.Checked == true)
                {
                    d.update("UPDATE Course_details_master SET Sinhala='1' WHERE course_no='" + lbl_cno.Text + "'");
                }
                else
                {
                    d.update("UPDATE Course_details_master SET Sinhala='0' WHERE course_no='" + lbl_cno.Text + "'");
                }
                if (metroCheckBox3.Checked == true)
                {
                    d.update("UPDATE Course_details_master SET Tamil='1' WHERE course_no='" + lbl_cno.Text + "'");
                }
                else
                {
                    d.update("UPDATE Course_details_master SET Tamil='0' WHERE course_no='" + lbl_cno.Text + "'");
                }
                MessageBox.Show(this, "Successfully updates mediums", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Error");

            }
        }

        private void metroLink4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                CheckState st = checkedListBox1.GetItemCheckState(i);
                if (st == CheckState.Checked)
                {
                    d.update("UPDATE Dip_module_details_2 SET compulsory=1 WHERE Module_id='" + General_methods.get_module_no_from_module_name(checkedListBox1.Items[i].ToString(), lbl_cno.Text) + "'");
                }
                else if (st == CheckState.Unchecked)
                {
                    d.update("UPDATE Dip_module_details_2 SET compulsory=0 WHERE Module_id='" + General_methods.get_module_no_from_module_name(checkedListBox1.Items[i].ToString(), lbl_cno.Text) + "'");
                }
            }
            MessageBox.Show(this, "Successfully updates compulsory courses", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
