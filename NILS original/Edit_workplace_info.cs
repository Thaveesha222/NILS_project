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
    public partial class Edit_workplace_info : MetroFramework.Forms.MetroForm
    {
        public Edit_workplace_info()
        {
            InitializeComponent();
        }

        private void Edit_workplace_info_Load(object sender, EventArgs e)
        {
            txt_org.DataSource = General_methods.fill_companys_combobx();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (txt_org.Text == "")
            {
                MessageBox.Show(this, "Please select company", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                DialogResult d1 = MessageBox.Show("Change organization details of Student?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d1 == DialogResult.Yes)
                {
                    Database d = new Database();
                    d.update("UPDATE Stud_details SET organization_id='"+General_methods.find_organization_no_from_organization_name(txt_org.Text)+"' WHERE stud_no='"+txt_stud_no.Text+"'");
                    MessageBox.Show("Record Updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {

                }
            }
        }

        private void txt_org_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] d = General_methods.get_organization_details_from_org_name(txt_org.Text);
            txt_add.Text = d[0];
            txt_tel_r.Text = d[1];
            txt_email.Text = d[2];
            txt_fax.Text = d[3];
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            New_company n = new New_company();
            n.Show();
        }
    }
}
