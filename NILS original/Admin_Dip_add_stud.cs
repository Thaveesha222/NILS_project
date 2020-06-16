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
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;
using System.Threading;

namespace NILS_original
{
    public partial class Admin_Dip_add_stud : MetroFramework.Forms.MetroForm
    {
        public Admin_Dip_add_stud()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            txt_org.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_org.AutoCompleteSource = AutoCompleteSource.ListItems;
            txt_desig.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_desig.AutoCompleteSource = AutoCompleteSource.ListItems;
            
        }
        SqlConnection con = new SqlConnection(Credentials.connection);
        Database d3 = new Database();
        private void Form1_Load(object sender, EventArgs e)
        {
            txt_desig.DataSource = General_methods.fill_designations_combobox();
            txt_desig.Text = "";
        }


        private void metroScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void metroScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }
        public static string course_name;
        public static string shortcno;
        char[] phrase = new char[11];
        private void cmb_course_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            cmb_batch.Items.Clear();
            SqlCommand cmd = new SqlCommand("SELECT Batch_name FROM Batches WHERE Course_no='" + General_methods.get_course_no_from_course_name(cmb_course_1.Text) + "' AND completed_state='0'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmb_batch.Items.Add(dr.GetValue(0));
            }
            con.Close();

            cmb_medium.Text = "";
            txt_studno_1.Text = "";
        }
        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked == false)
            {
                txt_org.Text = "";
                txt_office_tel_1.Text = "";
                txt_oemail.Text = "";
                txt_Oadd.Text = "";
                txt_desig.Text = "";
                txt_fax.Text = "";
                txt_org.Enabled = false;
                txt_oemail.Enabled = false;
                txt_Oadd.Enabled = false;
                txt_desig.Enabled = false;
                txt_fax.Enabled = false;
                txt_office_tel_1.Enabled = false;
                metroTile4.Enabled = false;
                metroLink1.Enabled = false;
            }
            if (metroCheckBox1.Checked == true)
            {

                txt_org.Enabled = true;
                txt_oemail.Enabled = true;
                txt_Oadd.Enabled = true;
                txt_desig.Enabled = true;
                txt_fax.Enabled = true;
                txt_office_tel_1.Enabled = true;
                metroTile4.Enabled = true;
                metroLink1.Enabled = true;

            }
        }

        private void cmb_course_1_MouseHover(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        /*FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;*/
        string imgLocation = "";
        byte[] bimage;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
            }
            try
            {
                Bitmap bmp = new Bitmap(imgLocation);
                FileStream fs = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                bimage = new byte[fs.Length];
                fs.Read(bimage, 0, Convert.ToInt32(fs.Length));
                fs.Close();
            }
            catch (System.ArgumentException f)
            {

            }

        }

        private void txt_org_Click(object sender, EventArgs e)
        {
            txt_org.DataSource = General_methods.fill_companys_combobx();
            txt_org.Text = "";
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            New_company n = new New_company();
            n.Show();
            n.Owner = this;
        }

        private void metroCheckBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (metroCheckBox2.Checked == true)
            {
                pictureBox1.Image = null;
                linkLabel1.Enabled = false;
            }
            if (metroCheckBox2.Checked == false)
            {
                pictureBox1.Image = null;
                linkLabel1.Enabled = true;
            }
        }
        string type;
        private void cmb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_type.SelectedIndex == 0)
            {
                cmb_course_1.DataSource = General_methods.fill_course_combobox("Diploma");
                type = "Diploma";
            }
            if (cmb_type.SelectedIndex == 1)
            {
                cmb_course_1.DataSource = General_methods.fill_course_combobox("Certificate");
                type = "Certificate";
            }
            cmb_batch.Items.Clear();
            cmb_batch.Text = "";
            cmb_medium.Text = "";
            txt_studno_1.Text = "";
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        string mname;
        private void metroTile2_Click(object sender, EventArgs e)
        {

            if (metroTile2.Text == "Ok")
            {


                if (string.IsNullOrEmpty(txt_firstname.Text) || txt_firstname.Text.Any(char.IsDigit))
                {
                    MessageBox.Show(this, "Please enter correct First name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (metroCheckBox12.Checked==false && (string.IsNullOrEmpty(txt_middlename.Text) || txt_middlename.Text.Any(char.IsDigit)))
                {
                    MessageBox.Show(this, "Please enter correct middle name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (string.IsNullOrEmpty(txt_name_with_initials.Text) || txt_name_with_initials.Text.Any(char.IsDigit))
                {
                    MessageBox.Show(this, "Please enter name with initials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (string.IsNullOrEmpty(txt_lname.Text) || txt_lname.Text.Any(char.IsDigit))
                {
                    MessageBox.Show(this, "Please enter correct Last name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (metroRadioButton6.Checked == false && metroRadioButton5.Checked == false)
                {
                    MessageBox.Show(this, "Please select gender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (metroCheckBox2.Checked == false && pictureBox1.Image == null)
                {
                    MessageBox.Show(this, "Please upload image of student", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (General_methods.NIC_validation(txt_nic.Text, metroDateTime1.Value, gender) == "invalid")
                {
                    MessageBox.Show(this, "Some Details do not match the NIC number entered. Please check NIC, birthdate and gender selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (cmb_batch.Text != "" && General_methods.check_if_id_exists(txt_nic.Text, General_methods.get_batch_no_from_batch_name(cmb_batch.Text)) == "false")
                {                    
                   MessageBox.Show(this, "A student with the same NIC already exists in this batch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                   
                }
                else
                {

                    txt_firstname.Enabled = false;
                    txt_lname.Enabled = false;
                    txt_middlename.Enabled = false;
                    metroRadioButton5.Enabled = false;
                    metroRadioButton6.Enabled = false;
                    pictureBox1.Enabled = false;
                    metroCheckBox2.Enabled = false;
                    txt_nic.Enabled = false;
                    linkLabel1.Enabled = false;
                    metroTile2.Text = "Change";
                    metroTile2.AutoSize = true;
                    metroDateTime1.Enabled = false;
                    txt_name_with_initials.Enabled = false;
                                               
                }
            }
            else
            {
                //metroTile2.Text = "Change";
                txt_firstname.Enabled = true;
                txt_lname.Enabled = true;
                txt_middlename.Enabled = true;
                txt_nic.Enabled = true;
                metroRadioButton5.Enabled = true;
                metroRadioButton6.Enabled = true;
                pictureBox1.Enabled = true;
                metroCheckBox2.Enabled = true;
                linkLabel1.Enabled = true;
                metroTile2.Text = "Ok";
                metroDateTime1.Enabled = true;
                txt_name_with_initials.Enabled = true;

            }
        }
        string gender;
        private void metroRadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton6.Checked == true)
            {
                gender = "male";
            }
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            if (metroTile3.Text == "Ok")
            {
                if (txt_homeno.Text == "")
                {
                    MessageBox.Show(this, "Please Home no", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_Radd.Text == "")
                {
                    MessageBox.Show(this, "Please residence address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_residence_tel.Text.Any(char.IsLetter) || txt_residence_tel.MaskFull == false)
                {
                    MessageBox.Show(this, "Please enter valid Residence Telephone number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_mobile.MaskFull == false || txt_mobile.Text.Any(char.IsLetter))
                {
                    MessageBox.Show(this, "Please enter valid mobile number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (string.IsNullOrEmpty(txt_resi_email.Text))
                {
                    MessageBox.Show(this, "Please enter the personal email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_contact_person_1_name.Text == "" || txt_contact_person_1_name.Text.Any(char.IsDigit))
                {
                    MessageBox.Show(this, "Please enter valid name for contact person 1 ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_contacts_person_1_no.MaskFull == false || txt_contacts_person_1_no.Text.Any(char.IsLetter))
                {
                    MessageBox.Show(this, "Please enter valid contact number for contact person-1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if ((txt_contact_person_2_name.Text == "" || txt_contact_person_2_name.Text.Any(char.IsDigit)) && metroCheckBox10.Checked == false)
                {
                    MessageBox.Show(this, "Please enter valid name for contact person 2 ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if ((txt_contact_person_2_no.MaskFull == false || txt_contact_person_2_no.Text.Any(char.IsLetter)) && metroCheckBox10.Checked == false)
                {
                    MessageBox.Show(this, "Please enter valid contact number for contact person-2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    txt_homeno.Enabled = false;
                    txt_Radd.Enabled = false;
                    txt_residence_tel.Enabled = false;
                    txt_mobile.Enabled = false;
                    txt_resi_email.Enabled = false;
                    groupBox6.Enabled = false;
                    groupBox7.Enabled = false;
                    metroTile3.Text = "Change";
                }
            }
            else
            {
                txt_homeno.Enabled = true;
                txt_Radd.Enabled = true;
                txt_residence_tel.Enabled = true;
                txt_mobile.Enabled = true;
                txt_resi_email.Enabled = true;
                groupBox6.Enabled = true;
                groupBox7.Enabled = true;
                metroTile3.Text = "Ok";
            }

        }

        private void txt_Radd_KeyPress(object sender, KeyPressEventArgs e)
        {
            G_maps.autocomplete_place_combobox(txt_Radd);
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            if (metroTile4.Text == "Ok")
            {
                if (txt_org.Text == "")
                {
                    MessageBox.Show(this, "Please select company", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (txt_desig.Text == "" || txt_desig.Text.Any(char.IsDigit))
                {
                    MessageBox.Show(this, "Please enter valid designation", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    txt_org.Enabled = false;
                    txt_desig.Enabled = false;
                    metroTile4.Text = "Change";
                }
            }
            else
            {
                txt_org.Enabled = true;
                txt_desig.Enabled = true;
                metroTile4.Text = "Ok";
            }
        }
       
        private void txt_org_SelectedIndexChanged(object sender, EventArgs e)
        {

            string[] d = General_methods.get_organization_details_from_org_name(txt_org.Text);
            txt_Oadd.Text = d[0];
            txt_office_tel_1.Text = d[1];
            txt_oemail.Text = d[2];
            txt_fax.Text = d[3];
        }

        private void cmb_medium_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            if (metroTile5.Text == "Ok")
            {
                if (cmb_type.Text == "")
                {
                    MessageBox.Show(this, "Please select course type", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (cmb_course_1.Text == "")
                {
                    MessageBox.Show(this, "Please select course name", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (cmb_medium.Text == "")
                {
                    MessageBox.Show(this, "Please select medium", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (cmb_batch.Text == "")
                {
                    MessageBox.Show(this, "Please select students batch", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (txt_studno_1.Text == "")
                {
                    MessageBox.Show(this, "Student number not generated", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else
                {
                    cmb_type.Enabled = false;
                    cmb_course_1.Enabled = false;
                    cmb_medium.Enabled = false;
                    cmb_batch.Enabled = false;
                    txt_studno_1.Enabled = false;
                    metroTile5.Text = "Change";

                }
            }
            else
            {
                cmb_type.Enabled = true;
                cmb_course_1.Enabled = true;
                cmb_medium.Enabled = true;
                cmb_batch.Enabled = true;
                txt_studno_1.Enabled = true;
                metroTile5.Text = "Ok";
            }

        }

        private void tile_confirm_Click(object sender, EventArgs e)
        {

            if (metroTile5.Text != "Change")
            {
                MessageBox.Show(this, "Students course details are not confirmed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (metroTile2.Text != "Change")
            {
                MessageBox.Show(this, "Students personal details are not confirmed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (metroTile3.Text != "Change")
            {
                MessageBox.Show(this, "Students contact details are not confirmed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (metroTile4.Text != "Change")
            {
                MessageBox.Show(this, "Students Organization details are not confirmed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (metroTile3.Text != "Change")
            {
                MessageBox.Show(this, "Students contact information is not confirmed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (metroCheckBox3.Checked == false && metroCheckBox4.Checked == false && metroCheckBox5.Checked == false && metroCheckBox6.Checked == false && metroCheckBox7.Checked == false && metroCheckBox8.Checked == false && metroCheckBox9.Checked == false && metroCheckBox11.Checked == false)
            {
                MessageBox.Show(this, "Please select students advertisement mode", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (General_methods.check_if_id_exists(txt_nic.Text, General_methods.get_batch_no_from_batch_name(cmb_batch.Text)) == "false")
            {
                MessageBox.Show(this, "A student with the same NIC already exists in this batch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                DialogResult d = MessageBox.Show(this, "You are about to add a new student. Click on Yes to add student", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                string place_id = G_maps.get_place_id_from_place_name_2(txt_Radd.Text);
                string[] stats = G_maps.get_place_details_from_place_id(place_id);
                if (d3.singleInt("SELECT COUNT(*) FROM Place_Details WHERE place_id='" + place_id + "'") == 0)
                {
                    d3.insert("INSERT INTO Place_Details (place_id,Address_string,Latitude,Longitude) VALUES ('" + place_id + "','" + stats[1] + "','" + stats[3] + "','" + stats[4] + "')");
                }
                
                if (d == DialogResult.Yes)
                {
                    if (state == false)
                    {
                        if (metroCheckBox10.Checked == false)
                        {
                            if (metroCheckBox1.Checked == true)
                            {
                                if (metroCheckBox12.Checked == false)
                                {
                                    d3.insert("INSERT INTO Stud_details (stud_no,f_name,m_name,l_name,gender,NIC,organization_id,designation,address_R,mobile,tel_R_1,email_R,course_no,medium,Birthday,Contact_person_1_name,Contact_person_1_no,Contact_person_2_name,Contact_person_2_no,mode,batch_no,home_no,name_with_initials) VALUES ('" + txt_studno_1.Text + "','" + txt_firstname.Text + "','" + txt_middlename.Text + "','" + txt_lname.Text + "','" + gender + "','" + txt_nic.Text + "','" + General_methods.find_organization_no_from_organization_name(txt_org.Text) + "','" + txt_desig.Text + "','" + place_id + "','" + txt_mobile.Text + "','" + txt_residence_tel.Text + "','" + txt_resi_email.Text + "','" + General_methods.get_course_no_from_course_name(cmb_course_1.Text) + "','" + cmb_medium.Text + "','" + metroDateTime1.Value.GetDateTimeFormats().GetValue(5) + "','" + txt_contact_person_1_name.Text + "','" + txt_contacts_person_1_no.Text + "','" + txt_contact_person_2_name.Text + "','" + txt_contact_person_2_no.Text + "','" + mode + "','" + General_methods.get_batch_no_from_batch_name(cmb_batch.Text) + "','" + txt_homeno.Text + "','"+txt_name_with_initials.Text+"')");
                                }
                                else
                                {
                                    d3.insert("INSERT INTO Stud_details (stud_no,f_name,l_name,gender,NIC,organization_id,designation,address_R,mobile,tel_R_1,email_R,course_no,medium,Birthday,Contact_person_1_name,Contact_person_1_no,Contact_person_2_name,Contact_person_2_no,mode,batch_no,home_no,name_with_initials) VALUES ('" + txt_studno_1.Text + "','" + txt_firstname.Text + "','" + txt_lname.Text + "','" + gender + "','" + txt_nic.Text + "','" + General_methods.find_organization_no_from_organization_name(txt_org.Text) + "','" + txt_desig.Text + "','" + place_id + "','" + txt_mobile.Text + "','" + txt_residence_tel.Text + "','" + txt_resi_email.Text + "','" + General_methods.get_course_no_from_course_name(cmb_course_1.Text) + "','" + cmb_medium.Text + "','" + metroDateTime1.Value.GetDateTimeFormats().GetValue(5) + "','" + txt_contact_person_1_name.Text + "','" + txt_contacts_person_1_no.Text + "','" + txt_contact_person_2_name.Text + "','" + txt_contact_person_2_no.Text + "','" + mode + "','" + General_methods.get_batch_no_from_batch_name(cmb_batch.Text) + "','" + txt_homeno.Text + "','" + txt_name_with_initials.Text + "')");
                                }
                            }
                            else
                            {
                                if (metroCheckBox12.Checked == false)
                                {
                                    d3.insert("INSERT INTO Stud_details (stud_no,f_name,m_name,l_name,gender,NIC,organization_id,designation,address_R,mobile,tel_R_1,email_R,course_no,medium,Birthday,Contact_person_1_name,Contact_person_1_no,Contact_person_2_name,Contact_person_2_no,mode,batch_no,home_no,name_with_initials) VALUES ('" + txt_studno_1.Text + "','" + txt_firstname.Text + "','" + txt_middlename.Text + "','" + txt_lname.Text + "','" + gender + "','" + txt_nic.Text + "','No company','" + txt_desig.Text + "','" + place_id + "','" + txt_mobile.Text + "','" + txt_residence_tel.Text + "','" + txt_resi_email.Text + "','" + General_methods.get_course_no_from_course_name(cmb_course_1.Text) + "','" + cmb_medium.Text + "','" + metroDateTime1.Value.GetDateTimeFormats().GetValue(5) + "','" + txt_contact_person_1_name.Text + "','" + txt_contacts_person_1_no.Text + "','" + txt_contact_person_2_name.Text + "','" + txt_contact_person_2_no.Text + "','" + mode + "','" + General_methods.get_batch_no_from_batch_name(cmb_batch.Text) + "'),'" + txt_homeno.Text + "','" + txt_name_with_initials.Text + "')");
                                }
                                else
                                {
                                    d3.insert("INSERT INTO Stud_details (stud_no,f_name,l_name,gender,NIC,organization_id,designation,address_R,mobile,tel_R_1,email_R,course_no,medium,Birthday,Contact_person_1_name,Contact_person_1_no,Contact_person_2_name,Contact_person_2_no,mode,batch_no,home_no,name_with_initials) VALUES ('" + txt_studno_1.Text + "','" + txt_firstname.Text + "','" + txt_lname.Text + "','" + gender + "','" + txt_nic.Text + "','No company','" + txt_desig.Text + "','" + place_id + "','" + txt_mobile.Text + "','" + txt_residence_tel.Text + "','" + txt_resi_email.Text + "','" + General_methods.get_course_no_from_course_name(cmb_course_1.Text) + "','" + cmb_medium.Text + "','" + metroDateTime1.Value.GetDateTimeFormats().GetValue(5) + "','" + txt_contact_person_1_name.Text + "','" + txt_contacts_person_1_no.Text + "','" + txt_contact_person_2_name.Text + "','" + txt_contact_person_2_no.Text + "','" + mode + "','" + General_methods.get_batch_no_from_batch_name(cmb_batch.Text) + "'),'" + txt_homeno.Text + "','" + txt_name_with_initials.Text + "')");
                                }
                            }
                        }
                        else
                        {
                            if (metroCheckBox1.Checked == true)
                            {
                                if (metroCheckBox12.Checked == false)
                                {
                                    d3.insert("INSERT INTO Stud_details (stud_no,f_name,m_name,l_name,gender,NIC,organization_id,designation,address_R,mobile,tel_R_1,email_R,course_no,medium,Birthday,Contact_person_1_name,Contact_person_1_no,Contact_person_2_name,Contact_person_2_no,mode,batch_no,home_no,name_with_initials) VALUES ('" + txt_studno_1.Text + "','" + txt_firstname.Text + "','" + txt_middlename.Text + "','" + txt_lname.Text + "','" + gender + "','" + txt_nic.Text + "','" + General_methods.find_organization_no_from_organization_name(txt_org.Text) + "','" + txt_desig.Text + "','" + place_id + "','" + txt_mobile.Text + "','" + txt_residence_tel.Text + "','" + txt_resi_email.Text + "','" + General_methods.get_course_no_from_course_name(cmb_course_1.Text) + "','" + cmb_medium.Text + "','" + metroDateTime1.Value.GetDateTimeFormats().GetValue(5) + "','" + txt_contact_person_1_name.Text + "','" + txt_contacts_person_1_no.Text + "','None','None','" + mode + "','" + General_methods.get_batch_no_from_batch_name(cmb_batch.Text) + "','" + txt_homeno.Text + "','" + txt_name_with_initials.Text + "')");
                                }
                                else
                                {
                                    d3.insert("INSERT INTO Stud_details (stud_no,f_name,l_name,gender,NIC,organization_id,designation,address_R,mobile,tel_R_1,email_R,course_no,medium,Birthday,Contact_person_1_name,Contact_person_1_no,Contact_person_2_name,Contact_person_2_no,mode,batch_no,home_no,name_with_initials) VALUES ('" + txt_studno_1.Text + "','" + txt_firstname.Text + "','" + txt_lname.Text + "','" + gender + "','" + txt_nic.Text + "','" + General_methods.find_organization_no_from_organization_name(txt_org.Text) + "','" + txt_desig.Text + "','" + place_id + "','" + txt_mobile.Text + "','" + txt_residence_tel.Text + "','" + txt_resi_email.Text + "','" + General_methods.get_course_no_from_course_name(cmb_course_1.Text) + "','" + cmb_medium.Text + "','" + metroDateTime1.Value.GetDateTimeFormats().GetValue(5) + "','" + txt_contact_person_1_name.Text + "','" + txt_contacts_person_1_no.Text + "','None','None','" + mode + "','" + General_methods.get_batch_no_from_batch_name(cmb_batch.Text) + "','" + txt_homeno.Text + "','" + txt_name_with_initials.Text + "')");
                                }
                            }
                            else
                            {
                                if (metroCheckBox12.Checked == false)
                                {
                                    d3.insert("INSERT INTO Stud_details (stud_no,f_name,m_name,l_name,gender,NIC,organization_id,designation,address_R,mobile,tel_R_1,email_R,course_no,medium,Birthday,Contact_person_1_name,Contact_person_1_no,Contact_person_2_name,Contact_person_2_no,mode,batch_no,home_no,name_with_initials) VALUES ('" + txt_studno_1.Text + "','" + txt_firstname.Text + "','" + txt_middlename.Text + "','" + txt_lname.Text + "','" + gender + "','" + txt_nic.Text + "','No company','" + txt_desig.Text + "','" + place_id + "','" + txt_mobile.Text + "','" + txt_residence_tel.Text + "','" + txt_resi_email.Text + "','" + General_methods.get_course_no_from_course_name(cmb_course_1.Text) + "','" + cmb_medium.Text + "','" + metroDateTime1.Value.GetDateTimeFormats().GetValue(5) + "','" + txt_contact_person_1_name.Text + "','" + txt_contacts_person_1_no.Text + "','None','None','" + mode + "','" + General_methods.get_batch_no_from_batch_name(cmb_batch.Text) + "','" + txt_homeno.Text + "','" + txt_name_with_initials.Text + "')");
                                }
                                else
                                {
                                    d3.insert("INSERT INTO Stud_details (stud_no,f_name,l_name,gender,NIC,organization_id,designation,address_R,mobile,tel_R_1,email_R,course_no,medium,Birthday,Contact_person_1_name,Contact_person_1_no,Contact_person_2_name,Contact_person_2_no,mode,batch_no,home_no,name_with_initials) VALUES ('" + txt_studno_1.Text + "','" + txt_firstname.Text + "','" + txt_lname.Text + "','" + gender + "','" + txt_nic.Text + "','No company','" + txt_desig.Text + "','" + place_id + "','" + txt_mobile.Text + "','" + txt_residence_tel.Text + "','" + txt_resi_email.Text + "','" + General_methods.get_course_no_from_course_name(cmb_course_1.Text) + "','" + cmb_medium.Text + "','" + metroDateTime1.Value.GetDateTimeFormats().GetValue(5) + "','" + txt_contact_person_1_name.Text + "','" + txt_contacts_person_1_no.Text + "','None','None','" + mode + "','" + General_methods.get_batch_no_from_batch_name(cmb_batch.Text) + "','" + txt_homeno.Text + "','" + txt_name_with_initials.Text + "')");
                                }
                            }
                        }
                        if (metroCheckBox2.Checked == false)
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand("UPDATE Stud_details SET pic=(@imgdata) WHERE stud_no='" + txt_studno_1.Text + "'", con);
                            cmd.Parameters.AddWithValue("@imgdata", SqlDbType.Image).Value = bimage;
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else
                        {

                        }
                        

                        MessageBox.Show(this, "Successfully added new student", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        
                    }
                    else
                    {
                        d3.insert("INSERT INTO Stud_details (stud_no,course_no,medium,batch_no,ref) VALUES ('"+txt_studno_1.Text+"','"+General_methods.get_course_no_from_course_name(cmb_course_1.Text)+"','"+cmb_medium.Text+"','"+General_methods.get_batch_no_from_batch_name(cmb_batch.Text)+"','"+ref_stud_no+"')");
                       
                        state = false;

                        MessageBox.Show(this, "Successfully added new student", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (type == "Diploma")
                    {
                        Module_selection.state = false;
                        Module_selection m = new Module_selection();
                        m.lbl_stud_no.Text = txt_studno_1.Text;
                        m.lbl_course_no.Text= General_methods.get_course_no_from_course_name(cmb_course_1.Text);
                        m.Show();
                    }
                    clear();
                }
                else
                {

                }
            }
        }
        public void clear_control(Control c)
        {
            if (c is MetroFramework.Controls.MetroTextBox)
            {
                MetroFramework.Controls.MetroTextBox t = (MetroFramework.Controls.MetroTextBox)c;
                t.Text = "";
                t.Enabled = true;
            }
            else if (c is MaskedTextBox)
            {
                MaskedTextBox t = (MaskedTextBox)c;
                t.Text = "";
                t.Enabled = true;
            }
            else if (c is ComboBox)
            {
                ComboBox t = (ComboBox)c;
                t.Text = "";
                t.Enabled = true;
            }
        }
        public void clear()
        {
            groupBox6.Enabled = true;
            groupBox7.Enabled = true;
            foreach (Control c in metroPanel2.Controls)
            {
                clear_control(c);
            }
            foreach (Control c in groupBox6.Controls)
            {
                clear_control(c);
            }
            foreach (Control c in groupBox7.Controls)
            {
                clear_control(c);
            }
            foreach (Control c in groupBox4.Controls)
            {
                clear_control(c);
            }
            foreach (Control c in groupBox3.Controls)
            {
                clear_control(c);
            }
            foreach (Control c in groupBox2.Controls)
            {
                clear_control(c);
            }
            foreach (Control c in groupBox1.Controls)
            {
                clear_control(c);
            }

            foreach (Control c in groupBox5.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    cb.Checked = false;
                }
            }
            pictureBox1.Image = null;
            pictureBox1.Enabled = true;
            metroCheckBox2.Checked = false;
            metroCheckBox1.Checked = true;
            metroCheckBox10.Checked = false;
            metroTile2.Text = "Ok";
            metroTile3.Text = "Ok";
            metroTile4.Text = "Ok";
            metroTile5.Text = "Ok";
            metroRadioButton5.Checked = false;
            metroRadioButton6.Checked = false;
            metroDateTime1.Value = DateTime.Today;
            metroRadioButton5.Enabled = true;
            metroRadioButton6.Enabled = true;
            metroCheckBox2.Enabled = true;
            metroDateTime1.Enabled = true;
            linkLabel1.Enabled = true;
            metroCheckBox10.Enabled = true;
            metroLink1.Enabled = true;
            metroLink2.Enabled = true;

        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        private void metroRadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton5.Checked == true)
            {
                gender = "female";
            }
        }

        private void metroCheckBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox10.Checked == true)
            {
                txt_contact_person_2_name.Enabled = false;
                txt_contact_person_2_no.Enabled = false;
                txt_contact_person_2_name.Text = "";
                txt_contact_person_2_no.Clear();
            }
            else
            {
                txt_contact_person_2_name.Enabled = true;
                txt_contact_person_2_no.Enabled = true;

            }
        }
        string mode;
        private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            uncheck(metroCheckBox3);
            mode = metroCheckBox3.Text;
        }

        private void metroCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            uncheck(metroCheckBox4);
            mode = metroCheckBox4.Text;
        }
        public void uncheck(CheckBox x)
        {
            foreach (Control c in groupBox5.Controls)
            {
                if (c is CheckBox)
                {

                    CheckBox cb = (CheckBox)c;
                    if (cb == x)
                    {

                    }
                    else
                    {
                        cb.Checked = false;
                    }
                }
            }
        }

        private void metroCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            uncheck(metroCheckBox5);
            mode = metroCheckBox5.Text;
        }

        private void metroCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            uncheck(metroCheckBox6);
            mode = metroCheckBox6.Text;
        }

        private void metroCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            uncheck(metroCheckBox7);
            mode = metroCheckBox7.Text;
        }

        private void metroCheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            uncheck(metroCheckBox8);
            mode = metroCheckBox8.Text;
        }

        private void metroCheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            uncheck(metroCheckBox9);
            mode = metroCheckBox9.Text;
        }

        private void metroCheckBox11_CheckedChanged(object sender, EventArgs e)
        {
            uncheck(metroCheckBox11);
            mode = metroCheckBox11.Text;
        }

        private void Admin_Dip_add_stud_FormClosing(object sender, FormClosingEventArgs e)
        {
            //openMainform.show();

        }

        private void Admin_Dip_add_stud_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                openMainform.show();
            }
        }

        private void metroLink2_Click(object sender, EventArgs e)
        {
            Add_new_batch a = new Add_new_batch();
            a.Show();
        }

        private void cmb_batch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_batch.Text == "")
            {

            }
            else
            {
                cmb_medium.Text = d3.singleString("SELECT Medium FROM Batches WHERE Batch_name='" + cmb_batch.Text + "'");
            }
        }

        private void cmb_medium_TextChanged(object sender, EventArgs e)
        {
            if (cmb_medium.Text != "")
            {
                if (cmb_type.SelectedIndex == 0)
                {
                    char a = 'p';
                    if (cmb_medium.Text == "English")
                    {
                        a = 'E';
                    }
                    else if (cmb_medium.Text == "Sinhala")
                    {
                        a = 'S';
                    }
                    else if (cmb_medium.Text == "Tamil")
                    {
                        a = 'T';
                    }
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT stud_no FROM Stud_details WHERE course_no='" + General_methods.get_course_no_from_course_name(cmb_course_1.Text) + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<int> stud_nos = new List<int>();
                    while (dr.Read())
                    {
                        stud_nos.Add(Convert.ToInt32(dr.GetValue(0).ToString().Split('/').GetValue(3)));

                    }
                    if (!stud_nos.Any())
                    {
                        stud_nos.Add(0);
                    }
                    else
                    {

                    }
                    con.Close();
                    string studno = "D/" + DateTime.Today.Year.ToString().Remove(0, 2) + "/" + d3.singleString("SELECT course_initials FROM Course_details_master WHERE course_no='" + General_methods.get_course_no_from_course_name(cmb_course_1.Text) + "'") + a + "/" + (stud_nos.Max() + 1).ToString();
                    txt_studno_1.Text = studno;
                }
                else if (cmb_type.SelectedIndex == 1)
                {
                    char a = 'p';
                    if (cmb_medium.Text == "English")
                    {
                        a = 'E';
                    }
                    else if (cmb_medium.Text == "Sinhala")
                    {
                        a = 'S';
                    }
                    else if (cmb_medium.Text == "Tamil")
                    {
                        a = 'T';
                    }
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT stud_no FROM Stud_details WHERE course_no='" + General_methods.get_course_no_from_course_name(cmb_course_1.Text) + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<int> stud_nos = new List<int>();
                    while (dr.Read())
                    {
                        stud_nos.Add(Convert.ToInt32(dr.GetValue(0).ToString().Split('/').GetValue(3)));

                    }
                    if (!stud_nos.Any())
                    {
                        stud_nos.Add(0);
                    }
                    else
                    {

                    }
                    con.Close();
                    string studno = "C/" + DateTime.Today.Year.ToString().Remove(0, 2) + "/" + d3.singleString("SELECT course_initials FROM Course_details_master WHERE course_no='" + General_methods.get_course_no_from_course_name(cmb_course_1.Text) + "'") + a + "/" + (stud_nos.Max() + 1).ToString();
                    txt_studno_1.Text = studno;
                }
            }
            else
            {

            }

        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        string ref_stud_no;
        bool state;
        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (txt_nic_already_exists.Text=="")
            {
                MessageBox.Show(this, "Please enter NIC to search", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((txt_nic_already_exists.Text.Length == 12 || txt_nic_already_exists.Text.Length == 10) == false)
            {
                MessageBox.Show(this, "Invalid NIC entered. Please enter valid NIC number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_nic_already_exists.Text.Length == 12 && txt_nic_already_exists.Text.Any(char.IsLetter) == true)
            {
                MessageBox.Show(this, "Invalid NIC entered. Please enter valid NIC number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_nic_already_exists.Text.Length == 10 && (txt_nic_already_exists.Text.Last() != 'V' || txt_nic_already_exists.Text.Last() != 'X' || txt_nic_already_exists.Text.Last() != 'v' || txt_nic_already_exists.Text.Last() != 'x'))
            {
                MessageBox.Show(this, "Invalid NIC entered. Please enter valid NIC number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (d3.singleInt("SELECT COUNT(*) FROM Stud_details WHERE NIC ='" + txt_nic_already_exists.Text + "'")==0)
            {
                MessageBox.Show(this, "A student with this NIC is not recorded in the system", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                state = true;
                txt_org.DataSource = General_methods.fill_companys_combobx();
                DialogResult d = MessageBox.Show(this, "Student with NIC "+txt_nic_already_exists.Text+" Found in system. Load Details of student?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    SqlConnection con2 = new SqlConnection(Credentials.connection);
                    con2.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Stud_details WHERE NIC='" + txt_nic_already_exists.Text + "'", con2);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    ref_stud_no = dr.GetValue(0).ToString();
                    txt_firstname.Text = dr.GetValue(1).ToString();
                    txt_middlename.Text = dr.GetValue(2).ToString();
                    txt_lname.Text = dr.GetValue(3).ToString();
                    if (dr.GetValue(4).ToString() == "male")
                    {
                        metroRadioButton6.Checked = true;
                    }
                    else
                    {
                        metroRadioButton5.Checked = true;
                    }
                    txt_nic.Text = dr.GetValue(5).ToString();
                    txt_org.Text = General_methods.find_organization_name_from_organization_no(dr.GetValue(6).ToString());
                    txt_desig.Text = dr.GetValue(7).ToString();
                    txt_Radd.Text = dr.GetValue(8).ToString();
                    txt_mobile.Text = dr.GetValue(9).ToString();
                    txt_residence_tel.Text = dr.GetValue(10).ToString();
                    txt_resi_email.Text = dr.GetValue(11).ToString();
                    metroDateTime1.Value = Convert.ToDateTime(dr.GetValue(14));
                    txt_contact_person_1_name.Text = dr.GetValue(15).ToString();
                    txt_contacts_person_1_no.Text = dr.GetValue(16).ToString();
                    txt_contact_person_2_name.Text = dr.GetValue(17).ToString();
                    txt_contact_person_2_no.Text = dr.GetValue(18).ToString();
                    txt_homeno.Text = dr.GetValue(22).ToString();
                    General_methods.get_stud_pic(pictureBox1, dr.GetValue(0).ToString());
                    foreach (Control c in groupBox5.Controls)
                    {
                        if (c is CheckBox && c.Text == dr.GetValue(19).ToString())
                        {
                            CheckBox v = (CheckBox)c;
                            v.Checked = true;
                        }
                    }
                    dr.Close();
                    con2.Close();
                    
                }
                else
                {

                }
            }

        }

        private void groupBox3_Enter_1(object sender, EventArgs e)
        {

        }

        private void cmb_medium_Click(object sender, EventArgs e)
        {

        }
        bool h=true;
        private void txt_name_with_initials_Click(object sender, EventArgs e)
        {
            
        }

        private void metroCheckBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox12.Checked == true)
            {
                txt_middlename.Text = "";
                txt_middlename.Enabled = false;
            }
            else
            {
                txt_middlename.Enabled = true;
            }
        }
    }
}
