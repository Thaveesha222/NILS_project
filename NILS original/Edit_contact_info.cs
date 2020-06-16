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
    public partial class Edit_contact_info : MetroFramework.Forms.MetroForm
    {
        public Edit_contact_info()
        {
            InitializeComponent();
        }

        private void Edit_contact_info_Load(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (txt_homeno.Text == "")
            {
                MessageBox.Show(this, "Please Home no", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_add.Text == "")
            {
                MessageBox.Show(this, "Please residence address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_tel_r.Text.Any(char.IsLetter) || txt_tel_r.MaskFull == false)
            {
                MessageBox.Show(this, "Please enter valid Residence Telephone number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_mobile.MaskFull == false || txt_mobile.Text.Any(char.IsLetter))
            {
                MessageBox.Show(this, "Please enter valid mobile number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txt_email.Text))
            {
                MessageBox.Show(this, "Please enter the personal email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_c_p_1_name.Text == "" || txt_c_p_1_name.Text.Any(char.IsDigit))
            {
                MessageBox.Show(this, "Please enter valid name for contact person 1 ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_c_p_1_no.MaskFull == false || txt_c_p_1_no.Text.Any(char.IsLetter))
            {
                MessageBox.Show(this, "Please enter valid contact number for contact person-1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((txt_c_p_2_name.Text == "" || txt_c_p_2_name.Text.Any(char.IsDigit)) && metroCheckBox1.Checked == true)
            {
                MessageBox.Show(this, "Please enter valid name for contact person 2 ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((txt_c_p_2_no.MaskFull == false || txt_c_p_2_no.Text.Any(char.IsLetter)) && metroCheckBox1.Checked == true)
            {
                MessageBox.Show(this, "Please enter valid contact number for contact person-2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult d1 = MessageBox.Show(this, "Edit contact details?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d1 == DialogResult.Yes)
                {
                    Database d = new Database();
                    if (metroCheckBox1.Checked == true)
                    {
                        d.update("UPDATE Stud_details SET home_no='" + txt_homeno.Text + "',address_R='" + txt_add.Text + "',mobile='" + txt_mobile.Text + "',email_R='" + txt_email.Text + "',Contact_person_1_name='" + txt_c_p_1_name.Text + "',Contact_person_1_no='" + txt_c_p_1_no.Text + "',Contact_person_2_name='" + txt_c_p_2_name.Text + "',Contact_person_2_no='" + txt_c_p_2_no.Text + "',tel_R_1='" + txt_tel_r.Text + "' WHERE stud_no='" + txt_stud_no.Text + "'");
                    }
                    else
                    {
                        d.update("UPDATE Stud_details SET home_no='" + txt_homeno.Text + "',address_R='" + txt_add.Text + "',mobile='" + txt_mobile.Text + "',email_R='" + txt_email.Text + "',Contact_person_1_name='" + txt_c_p_1_name.Text + "',Contact_person_1_no='" + txt_c_p_1_no.Text + "',Contact_person_2_name='None',Contact_person_2_no='None',tel_R_1='" + txt_tel_r.Text + "' WHERE stud_no='" + txt_stud_no.Text + "'");
                    }
                    MessageBox.Show(this, "Successfully updated record", "done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Close();
                }

            }
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked == true)
            {
                txt_c_p_2_name.Enabled = true;
                txt_c_p_2_no.Enabled = true;
            }
            else
            {
                txt_c_p_2_name.Enabled = false;
                txt_c_p_2_no.Enabled = false;
                txt_c_p_2_no.Clear();
                txt_c_p_2_name.Clear();
            }
        }
    }
}
