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
using System.Data.OleDb;

namespace NILS_original
{
    public partial class edit : MetroFramework.Forms.MetroForm
    {
        public edit()
        {
            InitializeComponent();
            
        }
       SqlConnection con = new SqlConnection(Credentials.connection);

        // DataTable dt = new DataTable();
        string[] name1 = new string[100];
        private void Form2_Load(object sender, EventArgs e)
        {

            /*cmb_rp_1.DataSource = General_methods.fill_lecturer_names_combobox();
            cmb_rp_2.DataSource = General_methods.fill_lecturer_names_combobox();*/
            flag = 1;
        }
        int flag = 0;
        private void tile_clear_Click(object sender, EventArgs e)
        {
            Database d = new Database();
            DialogResult result = MessageBox.Show("Are you sure you want to remove program ?", "NILS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (cmb_type_2.SelectedIndex != 5|| cmb_type_2.SelectedIndex != 4|| cmb_type_2.SelectedIndex != 3|| cmb_type_2.SelectedIndex != 2)
                {
                    con.Open();
                    d.delete("DELETE FROM Session_details WHERE program_no= '" + txt_progno.Text + "' ");
                    MessageBox.Show("Program removed Succefully", "NILS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    con.Close();
                }
                else
                {
                    con.Open();
                    d.delete("DELETE FROM Session_details WHERE program_no= '" + txt_progno.Text + "' ");
                    d.delete("DELETE FROM Short_program_details WHERE Code='" + txt_progno.Text + "'");
                    MessageBox.Show("Program removed Succefully", "NILS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    con.Close();
                }
            }


        }

        private void rbn_out_CheckedChanged(object sender, EventArgs e)
        {
            //txt_venue.ReadOnly = false;
            txt_venue.Text = "";
        }

        private void rbn_in_CheckedChanged(object sender, EventArgs e)
        {
            //txt_venue.ReadOnly = true;
            txt_venue.Text = "NILS";
        }

        private void tile_back_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        
        private void tile_update_Click(object sender, EventArgs e)
        {
            try
            {
                Database d = new Database();
                DialogResult result = MessageBox.Show("Are you sure you want to edit program details?", "NILS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string resourceP2;
                    string resourceP3;
                    if (metroCheckBox1.Checked == true)
                    {
                        resourceP2 = General_methods.get_lec_no_from_lec_name(cmb_rp_2.Text);
                    }
                    else
                    {
                        resourceP2 = "None";
                    }
                    if (metroCheckBox2.Checked == true)
                    {
                        resourceP3 = General_methods.get_lec_no_from_lec_name(cmb_rp_3.Text);
                    }
                    else
                    {
                        resourceP3 = "None";
                    }
                    if (cmb_type_2.SelectedIndex != 5)
                    {
                        con.Open();
                        d.update("UPDATE Session_details SET scheduled_date='" + txt_date.Value.ToString("MM/dd/yyyy") + "',course_type='" + ctype + "',course_no='" + course_no.Text + "',Resource_person_1='" + General_methods.get_lec_no_from_lec_name(cmb_rp_1.Text) + "',Resource_person_2='" + resourceP2 + "',Resource_person_3='" + resourceP3 + "',venue=N'" + txt_venue.Text + "' WHERE (program_no='" + txt_progno.Text + "')");
                        MessageBox.Show("Details edited Succefully", "NILS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        con.Close();
                    }
                    else
                    {
                        con.Open();
                        d.update("UPDATE Session_details SET scheduled_date='" + txt_date.Value.ToString("MM/dd/yyyy") + "',course_type='Workshop', course_no='None', Resource_person_1='" + General_methods.get_lec_no_from_lec_name(cmb_rp_1.Text) + "',Resource_person_2='" + resourceP2 + "', Resource_person_3='" + resourceP3 + "',venue=N'" + txt_venue.Text + "' WHERE (program_no='" + txt_progno.Text + "')");
                        d.update("UPDATE Short_program_details SET Program_title='" + txt_progtitle.Text + "' WHERE Code='" + txt_progno.Text + "'");
                        MessageBox.Show("Details edited Succefully", "NILS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        con.Close();
                    }
                }
                else
                {

                }
            }
            catch (Exception V)
            {
                MessageBox.Show(V.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void cmb_name1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_type_2.SelectedIndex == 0)
            {
                cmb_module_2.DataSource = General_methods.fill_module_combobox(General_methods.get_course_no_from_course_name(cmb_name1.Text));

            }
            else
            {
                cmb_module_2.Enabled = false;
            }
        }
        string ctype;
        public static string cname;
        private void cmb_type_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_type_2.SelectedIndex == 0)
            {
                /*cmb_module_2.Enabled = true;
                con.Open();
                SqlCommand cmd1 = new SqlCommand(("SELECT course_name FROM Dip_course_details"), con);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                int count = 0;
                string[] name = new string[100];
                while (dr1.Read())
                {
                    name[count] = Convert.ToString(dr1.GetValue(0));
                    count++;
                }
                cmb_name1.DataSource = name;
                dr1.Close();
                con.Close();*/
                ctype = "Diploma";
                cmb_module_2.Enabled =true;
                cmb_name1.DataSource= General_methods.fill_course_combobox("Diploma");
                txt_venue.Enabled = false;

            }
            else if (cmb_type_2.SelectedIndex == 1)
            {
                /*con.Open();
                SqlCommand cmd1 = new SqlCommand(("SELECT course_name FROM certif_course_details"), con);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                int count = 0;
                string[] name = new string[100];
                while (dr1.Read())
                {
                    name[count] = Convert.ToString(dr1.GetValue(0));
                    count++;
                }
                cmb_name1.DataSource = name;
                dr1.Close();
                con.Close();*/
                ctype = "Certificate";
                cmb_module_2.DataSource = null;
                cmb_module_2.Enabled = false;
                cmb_name1.DataSource = General_methods.fill_course_combobox("Certificate");
                txt_venue.Enabled = false;

            }
            else if (cmb_type_2.SelectedIndex == 2)
            {
                /*con.Open();
                SqlCommand cmd1 = new SqlCommand(("SELECT course_name FROM Short_course_details"), con);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                int count = 0;
                string[] name = new string[100];
                while (dr1.Read())
                {
                    name[count] = Convert.ToString(dr1.GetValue(0));
                    count++;
                }
                cmb_name1.DataSource = name;
                dr1.Close();
                con.Close();*/
                ctype = "One-day";
                cmb_module_2.DataSource = null;
                cmb_module_2.Enabled = false;
                cmb_name1.DataSource = General_methods.fill_course_combobox("Short");
                txt_venue.Enabled = true;

            }
            else if (cmb_type_2.SelectedIndex == 3)
            {
                /*con.Open();
                SqlCommand cmd1 = new SqlCommand(("SELECT course_name FROM Short_course_details"), con);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                int count = 0;
                string[] name = new string[100];
                while (dr1.Read())
                {
                    name[count] = Convert.ToString(dr1.GetValue(0));
                    count++;
                }
                cmb_name1.DataSource = name;
                dr1.Close();
                con.Close();*/
                ctype = "Two-day";
                cmb_module_2.DataSource = null;
                cmb_module_2.Enabled = false;
                cmb_name1.DataSource = General_methods.fill_course_combobox("Short");
                txt_venue.Enabled = true;

            }
            else if (cmb_type_2.SelectedIndex == 4)
            {
                /*con.Open();
                SqlCommand cmd1 = new SqlCommand(("SELECT course_name FROM Short_course_details"), con);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                int count = 0;
                string[] name = new string[100];
                while (dr1.Read())
                {
                    name[count] = Convert.ToString(dr1.GetValue(0));
                    count++;
                }
                cmb_name1.DataSource = name;
                dr1.Close();
                con.Close();*/
                ctype = "Three-day";
                cmb_module_2.DataSource = null;
                cmb_module_2.Enabled = false;
                cmb_name1.DataSource = General_methods.fill_course_combobox("Short");
                txt_venue.Enabled = true;

            }
            else if (cmb_type_2.SelectedIndex == 5)
            {
                /*con.Open();
                SqlCommand cmd1 = new SqlCommand(("SELECT course_name FROM Short_course_details"), con);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                int count = 0;
                string[] name = new string[100];
                while (dr1.Read())
                {
                    name[count] = Convert.ToString(dr1.GetValue(0));
                    count++;
                }
                cmb_name1.DataSource = name;
                dr1.Close();
                con.Close();*/
                ctype = "Workshop";
                cmb_module_2.DataSource = null;
                cmb_module_2.Enabled = false;
                //cmb_name1.DataSource = General_methods.fill_course_combobox("Short");
                txt_venue.Enabled = true;

            }
        }
        string mornlecno;
        string noonlecno;
        private void cmb_module_2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_rp_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //mornlecno = General_methods.get_lec_no_from_lec_name(cmb_rp_1.Text);
           
        }

        private void cmb_rp_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //noonlecno = General_methods.get_lec_no_from_lec_name(cmb_rp_2.Text);
        
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked == true)
            {
                cmb_rp_2.Enabled = true;
                cmb_rp_2.DataSource = General_methods.fill_lecturer_names_combobox();
            }
            else
            {
                cmb_rp_2.DataSource = null;
                cmb_rp_2.Enabled = false;
                cmb_rp_2.Items.Add("None");
                cmb_rp_2.SelectedItem = "None";
            }
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox2.Checked == true)
            {
                cmb_rp_3.Enabled = true;
                cmb_rp_3.DataSource = General_methods.fill_lecturer_names_combobox();
            }
            else
            {
                cmb_rp_3.DataSource = null;
                cmb_rp_3.Enabled = false;
                cmb_rp_3.Items.Add("None");
                cmb_rp_3.SelectedItem = "None";
            }
        }

        private void txt_venue_TextChanged(object sender, EventArgs e)
        {

            if (txt_venue.SelectedIndex > -1||flag==0||metroCheckBox3.Checked==false)
            {
                 
            }
            else
            {
                G_maps.autocomplete_place_combobox(txt_venue);
            }
        }

        private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
