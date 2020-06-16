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
    public partial class Edit_details_of_program_student : MetroFramework.Forms.MetroForm
    {
        public Edit_details_of_program_student()
        {
            InitializeComponent();
        }

        private void Edit_details_of_program_student_Load(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == "")
            {
                MessageBox.Show(this, "Please enter participants name", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txt_email.Text == "")
            {
                MessageBox.Show(this, "Please enter participants email", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txt_phoneno.MaskCompleted == false)
            {
                MessageBox.Show(this, "Please enter participants phone no", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (cmb_desigs.Text == "")
            {
                MessageBox.Show(this, "Please enter participants phone no", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (General_methods.Quick_NIC_Validation(txt_NIC.Text) == "Invalid")
            {
                MessageBox.Show(this, "Please enter valid NIC", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (cmb_org.Text == "")
            {
                MessageBox.Show(this, "Please select Organization of participant", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txt_destrict.Text == "")
            {
                MessageBox.Show(this, "Please select Address of participant", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DialogResult d2 = MessageBox.Show("Update details?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d2 == DialogResult.Yes)
                {
                    Database d = new Database();
                    d.update("UPDATE Short_program_participation SET address='" + txt_destrict.Text + "',designation='" + cmb_desigs.Text + "',Email='" + txt_email.Text + "',Name='" + txt_name.Text + "',NIC='" + txt_NIC.Text + "',Organization_id='" + General_methods.find_organization_no_from_organization_name(cmb_org.Text) + "',phone_no='" + txt_phoneno.Text + "' WHERE ref_no='" + lbl_no.Text + "'");
                    MessageBox.Show("Details Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label1.Text = General_methods.Generate_RandomNumber(3,678).ToString();
                    Close();
                }
            }
        }
    }
}
