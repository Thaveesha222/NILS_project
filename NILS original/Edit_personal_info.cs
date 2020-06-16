using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NILS_original
{
    public partial class Edit_personal_info : MetroFramework.Forms.MetroForm
    {
        public Edit_personal_info()
        {
            InitializeComponent();
        }
        public string batch;
        public string prev_nic;
        private void Edit_personal_info_Load(object sender, EventArgs e)
        {
            
        }

        private void cmb_course_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lbl_ccode.Text = General_methods.get_course_no_from_course_name(cmb_course.Text);
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_fname.Text) || txt_fname.Text.Any(char.IsDigit))
            {
                MessageBox.Show(this, "Please enter correct First name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txt_mname.Text) || txt_mname.Text.Any(char.IsDigit))
            {
                MessageBox.Show(this, "Please enter correct Middle name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txt_lname.Text) || txt_lname.Text.Any(char.IsDigit))
            {
                MessageBox.Show(this, "Please enter correct Last name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (General_methods.NIC_validation(txt_nic.Text, metroDateTime1.Value, gen) == "invalid")
            {
                MessageBox.Show(this, "Some Details do not match the NIC number entered. Please check NIC, birthdate and gender selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_nic.Text != prev_nic && General_methods.check_if_id_exists(txt_nic.Text, batch) == "false" )
            {
                MessageBox.Show(this, "A student with the same NIC already exists in this batch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (metroRadioButton1.Checked == false && metroRadioButton2.Checked == false)
            {
                MessageBox.Show(this, "Please select gender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_desig.Text == "")
            {
                MetroMessageBox.Show(this, "Please enter designation", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                DialogResult d1 = MessageBox.Show(this, "Edit Details?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d1 == DialogResult.Yes)
                {
                    Database d = new Database();
                    d.update("UPDATE Stud_details SET f_name='" + txt_fname.Text + "', m_name='" + txt_mname.Text + "',l_name='" + txt_lname.Text + "',NIC='" + txt_nic.Text + "',Birthday='" + metroDateTime1.Value.ToString() + "',gender='" + gen + "',designation='" + txt_desig.Text + "' WHERE stud_no='" + txt_studno.Text + "'");
                    MessageBox.Show(this, "Successfully updated record", "done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Close();
                }
                else
                {

                }

            }
        }


        string gen;
        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton1.Checked == true)
            {
                gen = "male";
            }

        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton2.Checked == true)
            {
                gen = "female";
            }
        }
        
    }
}
