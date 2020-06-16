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
    public partial class Add_new_batch : MetroFramework.Forms.MetroForm
    {
        public Add_new_batch()
        {
            InitializeComponent();
            metroGrid1.DataSource= d.show("SELECT * FROM Batches");
        }
        Database d = new Database();
        private void Add_new_batch_Load(object sender, EventArgs e)
        {
            int year = DateTime.Now.Year;
            cmb_year.Items.Add(year);
            for (int c = 0; c < 10; c++)
            {
                year++;
                cmb_year.Items.Add(year);
            }
            cmb_year.SelectedIndex = 0;
        }
        public void edit_batch_no_and_name()
        {
            if (cmb_type.Text=="Diploma")
            {
                txt_batch_no.Text = "NILS/Dip/" + General_methods.get_course_no_from_course_name(cmb_name.Text) + "/" +cmb_medium.Text+"/"+ cmb_year.Text + "/" + dat_startdate.Value.ToString("MMMM")+"/"+txt_batch_for_year.Text;
                txt_batch_name.Text = cmb_name.Text + "-"+cmb_medium.Text+"-"+ cmb_year.Text + "-" + dat_startdate.Value.ToString("MMMM")+"-"+txt_batch_for_year.Text;

            }
            else if (cmb_type.Text == "Certificate")
            {
                txt_batch_no.Text = "NILS/Certif/" + General_methods.get_course_no_from_course_name(cmb_name.Text) + "/" + cmb_medium.Text + "/" + cmb_year.Text + "/" + dat_startdate.Value.ToString("MMMM") + "/" + txt_batch_for_year.Text;
                txt_batch_name.Text = cmb_name.Text + "-" + cmb_medium.Text + "-" + cmb_year.Text + "-" + dat_startdate.Value.ToString("MMMM") + "-" + txt_batch_for_year.Text;
            }
        }
        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (cmb_year.Text == "")
            {
                MessageBox.Show(this, "Please select year of batch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmb_type.Text == "")
            {
                MessageBox.Show(this, "Please select type of course", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmb_name.Text == "")
            {
                MessageBox.Show(this, "Please select course", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmb_medium.Text == "")
            {
                MessageBox.Show(this, "Please select medium", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_fee.Text == "" || txt_fee.Text.Any(char.IsLetter))
            {
                MessageBox.Show(this, "Please enter valid course fee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_registration_fee_txt.Text == "" || txt_registration_fee_txt.Text.Any(char.IsLetter))
            {
                MessageBox.Show(this, "Please enter valid registration fee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                d.insert("INSERT INTO Batches (Batch_no,Batch_name,Course_no,Medium,Year,start_date,completed_state,course_fee_for_batch,reg_fee_for_batch) VALUES ('" + txt_batch_no.Text + "','" + txt_batch_name.Text + "','" + General_methods.get_course_no_from_course_name(cmb_name.Text) + "','" + cmb_medium.Text + "','" + cmb_year.Text + "','" + dat_startdate.Value.ToString("MM/dd/yyyy") + "',0,'"+txt_fee.Text+"','"+txt_registration_fee_txt.Text+"')");
                MessageBox.Show(this, "Successfully added new Batch", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                metroGrid1.DataSource = d.show("SELECT * FROM Batches");

            }
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_type.SelectedIndex == 0)
            {
                cmb_name.DataSource= General_methods.fill_course_combobox("Diploma");
            }
            else if(cmb_type.SelectedIndex == 1)
            {
                cmb_name.DataSource= General_methods.fill_course_combobox("Certificate");
            }
            cmb_name.SelectedIndex = 0;
            

        }
        private void cmb_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_fee.Text= d.singleString("SELECT course_fee FROM Course_details_master WHERE course_no='"+General_methods.get_course_no_from_course_name(cmb_name.Text)+"'");
            txt_registration_fee_txt.Text = d.singleString("SELECT reg_fee FROM Course_details_master WHERE course_no='" + General_methods.get_course_no_from_course_name(cmb_name.Text) + "'");
            cmb_medium.DataSource = General_methods.fill_course_mediums_combobox(General_methods.get_course_no_from_course_name(cmb_name.Text));
            cmb_medium.SelectedIndex =0;           
        }

        private void cmb_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_medium.Text == "")
            {

            }
            else
            {
                edit_batch_no_and_name();
            }
        }

        private void dat_startdate_ValueChanged(object sender, EventArgs e)
        {
            if (cmb_medium.Text == "")
            {
            }
            else
            {
                edit_batch_no_and_name();
            }
        }

        private void cmb_medium_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_batch_for_year.Text = (d.singleInt("SELECT COUNT(*) FROM Batches WHERE Course_no='" + General_methods.get_course_no_from_course_name(cmb_name.Text) + "' AND Year='" + cmb_year.Text + "' AND Medium='"+cmb_medium.Text+"'") + 1).ToString();
            edit_batch_no_and_name();
        }
    }
}
