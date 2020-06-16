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
    public partial class Admin_Update_Program : MetroFramework.Forms.MetroForm
    {
        public Admin_Update_Program()
        {
            InitializeComponent();
            txt_venue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_venue.AutoCompleteSource = AutoCompleteSource.ListItems;
            txt_venue.Text = "";
            //.Format = DateTimePickerFormat.Custom;
            metroDateTime1.CustomFormat = "dd-MM-yyyy";

        }
        SqlConnection con = new SqlConnection(Credentials.connection);

        private void Form1_Load(object sender, EventArgs e)
        {
            cmb_rperson2.Items.Add("None");
            cmb_rperson2.Text = "None";
            cmb_rperson3.Items.Add("None");
            cmb_rperson3.Text = "None";
            //txt_venue.Text = "NILS";
            cmb_rperson1.DataSource = General_methods.fill_lecturer_names_combobox();
        }
        public static string inital_mornlec;
        public static string inital_noonlec;
        public static string initial_course_type;
        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            con.Open();
            edit f2 = new edit();
            f2.Show();
            f2.txt_progno.Text = this.metroGrid1.CurrentRow.Cells[0].Value.ToString();
            f2.txt_date.Text = this.metroGrid1.CurrentRow.Cells[1].Value.ToString();
            f2.cmb_rp_1.DataSource = General_methods.fill_lecturer_names_combobox();
            //f2.cmb_rp_2.DataSource = General_methods.fill_lecturer_names_combobox();
            //f2.cmb_rp_3.DataSource = General_methods.fill_lecturer_names_combobox();
            if (metroGrid1.CurrentRow.Cells[5].Value.ToString() != "None")
            {

                f2.cmb_rp_1.Text = General_methods.get_lec_name_from_lec_no(metroGrid1.CurrentRow.Cells[5].Value.ToString());

            }
            if (metroGrid1.CurrentRow.Cells[6].Value.ToString() != "None")
            {
                f2.metroCheckBox1.Checked = true;
                f2.cmb_rp_2.DataSource = General_methods.fill_lecturer_names_combobox();
                f2.cmb_rp_2.Text = General_methods.get_lec_name_from_lec_no(metroGrid1.CurrentRow.Cells[6].Value.ToString());

            }
            else
            {
                f2.metroCheckBox1.Checked = false;
            }
            if (metroGrid1.CurrentRow.Cells[7].Value.ToString() != "None")
            {
                f2.metroCheckBox2.Checked = true;
                f2.cmb_rp_3.DataSource = General_methods.fill_lecturer_names_combobox();
                f2.cmb_rp_3.Text = General_methods.get_lec_name_from_lec_no(metroGrid1.CurrentRow.Cells[7].Value.ToString());

            }
            else
            {
                f2.metroCheckBox2.Checked = false;
                //f2.cmb_rp_3.Enabled = false;

            }
            if (this.metroGrid1.CurrentRow.Cells[2].Value.ToString() == "Diploma")
            {
                f2.cmb_type_2.SelectedIndex = 0;
                Array.Clear(name1, 0, 100);
                f2.cmb_name1.Text = General_methods.get_course_name_from_course_no(this.metroGrid1.CurrentRow.Cells[3].Value.ToString());
                f2.course_no.Text = this.metroGrid1.CurrentRow.Cells[3].Value.ToString();
                f2.cmb_module_2.Text = this.metroGrid1.CurrentRow.Cells[4].Value.ToString();
                f2.txt_progtitle.Enabled = false;
            }
            else if (this.metroGrid1.CurrentRow.Cells[2].Value.ToString() == "Certificate")
            {
                f2.cmb_type_2.SelectedIndex = 1;
                f2.cmb_name1.Text = General_methods.get_course_name_from_course_no(this.metroGrid1.CurrentRow.Cells[3].Value.ToString());
                f2.txt_progtitle.Enabled = false;

            }
            else if (this.metroGrid1.CurrentRow.Cells[2].Value.ToString() == "One-day")
            {

                f2.cmb_type_2.SelectedIndex = 2;
                f2.cmb_name1.Text = General_methods.get_course_name_from_course_no(this.metroGrid1.CurrentRow.Cells[3].Value.ToString());
                txt_progtitle.Enabled = false;

            }
            else if (this.metroGrid1.CurrentRow.Cells[2].Value.ToString() == "Two-day")
            {

                f2.cmb_type_2.SelectedIndex = 3;
                f2.cmb_name1.Text = General_methods.get_course_name_from_course_no(this.metroGrid1.CurrentRow.Cells[3].Value.ToString());
                f2.txt_progtitle.Enabled = false;

            }

            else if (this.metroGrid1.CurrentRow.Cells[2].Value.ToString() == "Three-day")
            {

                f2.cmb_type_2.SelectedIndex = 4;
                f2.cmb_name1.Text = General_methods.get_course_name_from_course_no(this.metroGrid1.CurrentRow.Cells[3].Value.ToString());
                f2.txt_progtitle.Enabled = false;

            }
            else if (metroGrid1.CurrentRow.Cells[2].Value.ToString() == "Workshop")
            {

                f2.cmb_type_2.SelectedIndex = 5;
                f2.cmb_name1.Enabled = false;
                //2.cmb_name1.Text = General_methods.get_course_name_from_course_no(this.metroGrid1.CurrentRow.Cells[3].Value.ToString());
                f2.txt_progtitle.Enabled = true;
                f2.cmb_type_2.Enabled = false;
                Database d = new Database();
                f2.txt_progtitle.Text=d.singleString("SELECT Program_title FROM Short_program_details WHERE Code='" + metroGrid1.CurrentRow.Cells[0].Value.ToString() + "'");
            }



            f2.txt_venue.Text = this.metroGrid1.CurrentRow.Cells[7].Value.ToString();
            if (metroGrid1.CurrentRow.Cells[8].Value.ToString() == "NILS")
            {
                f2.rbn_in.Checked = true;

            }
            else
            {
                f2.rbn_out.Checked = true;
                f2.txt_venue.Text = metroGrid1.CurrentRow.Cells[8].Value.ToString();
            }
            con.Close();
        }
        
        private void tile_clear_Click(object sender, EventArgs e)
        {
            txt_no.Clear();
            cmb_rperson1.Text = "";
            cmb_rperson2.Text = "";
            txt_venue.Text = "";
            cmb_module.Text="";
            cmb_name.Text = "";
            cmb_rperson1.Text = "";
            cmb_rperson2.Text = "";
            /*cmb_name.DataSource = null;
            cmb_module.DataSource = null;*/

        }
        //string cname;
        string module;
        string ctype;
        string[] name1 = new string[100];
        private void cmb_name_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT course_no FROM Course_details_master WHERE course_name='"+cmb_name.Text+"'",con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                txt_no.Text = dr.GetValue(0).ToString();
            }
            else
            {
               /* dr.NextResult();
                dr.Read();
                if (dr.HasRows)
                {
                    txt_no.Text = dr.GetValue(0).ToString();
                }
                else
                {
                    dr.NextResult();
                    dr.Read();
                    txt_no.Text = dr.GetValue(0).ToString();
                }*/

            }
            if ((cmb_type.SelectedIndex == 0 || cmb_type.SelectedIndex == 1)==false)
            {
                txt_progtitle.Text = cmb_name.Text;
            }
            dr.Close();
            
            if (cmb_type.SelectedIndex == 0)
            {
                cmb_module.DataSource = null;
                cmb_module.DataSource = General_methods.fill_module_combobox(General_methods.get_course_no_from_course_name(cmb_name.Text));
            }
            con.Close();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            
        }

        private void rbn_in_CheckedChanged(object sender, EventArgs e)
        {
            //txt_venue.ReadOnly = true;
            txt_venue.Text = "NILS";
            txt_venue.Enabled = false;
        }

        private void rbn_out_CheckedChanged(object sender, EventArgs e)
        {
            //txt_venue.ReadOnly = false;
            txt_venue.Text = "";
            txt_venue.Enabled = true;

        }

        private void tile_enter_Click(object sender, EventArgs e)
        {
            if (cmb_type.Text == "")
            {
                MessageBox.Show(this, "Please select course type");
            }
            else if (cmb_type.SelectedIndex == 5 && txt_progtitle.Text == "")
            {
                MessageBox.Show(this, "Please enter title for workshop");
            }
            else if (cmb_name.Enabled == true && cmb_name.Text == "")
            {
                MessageBox.Show(this, "Please select the course name");

            }
            else if (cmb_module.Enabled == true && cmb_module.Text == "")
            {
                MessageBox.Show(this, "Please select the module name");
            }
            else if (cmb_rperson1.Text == "")
            {
                MessageBox.Show(this, "Please select at least one resource person");
            }
            else if (cmb_rperson2.Enabled == true && cmb_rperson2.Text == "")
            {
                MessageBox.Show(this, "Please select second resource person");
            }
            else if (cmb_rperson3.Enabled == true && cmb_rperson3.Text == "")
            {
                MessageBox.Show(this, "Please select third resource person");
            }
            else if (groupBox1.Enabled == true && rbn_in.Checked == false && rbn_out.Checked == false)
            {
                MessageBox.Show(this, "Please select venue");
            }
            else if (groupBox1.Enabled = true && rbn_out.Checked == true && (txt_venue.Text == "" || txt_venue.Text == "NILS"))
            {
                MessageBox.Show(this, "Please enter a valid outstation venue");
            }
            else if (cmb_batch.Enabled == true && cmb_batch.Text == "")
            {
                MessageBox.Show("Please select the batch");
            }
            else
            {

                resourceP1 = General_methods.get_lec_no_from_lec_name(cmb_rperson1.Text);

                if (metroCheckBox1.Checked == true)
                {
                    resourceP2 = General_methods.get_lec_no_from_lec_name(cmb_rperson2.Text);
                }
                else
                {
                    resourceP2 = "None";
                }
                if (metroCheckBox2.Checked == true)
                {
                    resourceP3 = General_methods.get_lec_no_from_lec_name(cmb_rperson3.Text);
                }
                else
                {
                    resourceP3 = "None";
                }
                Database d = new Database();
                string code;
                code = generate_program_no(ctype);
                if (cmb_type.SelectedIndex == 0)
                {
                    d.insert("INSERT INTO Session_details (program_no,scheduled_date,course_type,course_no,module,Resource_person_1,Resource_person_2,Resource_person_3,venue,overall_morn_rating,overall_noon_rating,Batch_no) VALUES('" + code + "','" + metroDateTime1.Value + "','" + ctype + "','" + txt_no.Text + "', '" + cmb_module.Text + "' ,'" + resourceP1 + "','" + resourceP2 + "','" + resourceP3 + "',N'" + txt_venue.Text + "','0','0','"+General_methods.get_batch_no_from_batch_name(cmb_batch.Text)+"')");
                }
                if (cmb_type.SelectedIndex == 1)
                {
                    d.insert("INSERT INTO Session_details (program_no,scheduled_date,course_type,course_no,module,Resource_person_1,Resource_person_2,Resource_person_3,venue,overall_morn_rating,overall_noon_rating,Batch_no) VALUES('" + code + "','" + metroDateTime1.Value + "','" + ctype + "','" + txt_no.Text + "', '" + cmb_module.Text + "' ,'" + resourceP1 + "','" + resourceP2 + "','" + resourceP3 + "',N'" + txt_venue.Text + "','0','0','" + General_methods.get_batch_no_from_batch_name(cmb_batch.Text) + "')");
                }
                if (cmb_type.SelectedIndex == 2)
                {
                    d.insert("INSERT INTO Session_details (program_no,scheduled_date,course_type,course_no,module,Resource_person_1,Resource_person_2,Resource_person_3,venue,overall_morn_rating,overall_noon_rating) VALUES('" + code + "','" + metroDateTime1.Value + "','" + ctype + "','" + txt_no.Text + "', 'no modules' ,'" + resourceP1 + "','" + resourceP2 + "','" + resourceP3 + "',N'" + txt_venue.Text + "','0','0')");
                    d.insert("INSERT INTO Short_program_details (Code,Program_title) VALUES ('" + code + "','" + txt_progtitle.Text + "')");

                }
                if (cmb_type.SelectedIndex == 3)
                {
                    d.insert("INSERT INTO Session_details (program_no,scheduled_date,course_type,course_no,module,Resource_person_1,Resource_person_2,Resource_person_3,venue,overall_morn_rating,overall_noon_rating) VALUES('" + code + "','" + metroDateTime1.Value + "','" + ctype + "','" + txt_no.Text + "', 'no modules' ,'" + resourceP1 + "','" + resourceP2 + "','" + resourceP3 + "',N'" + txt_venue.Text + "','0','0')");
                    d.insert("INSERT INTO Short_program_details (Code,Program_title) VALUES ('" + code + "','" + txt_progtitle.Text + "')");

                }
                if (cmb_type.SelectedIndex == 4)
                {
                    d.insert("INSERT INTO Session_details (program_no,scheduled_date,course_type,course_no,module,Resource_person_1,Resource_person_2,Resource_person_3,venue,overall_morn_rating,overall_noon_rating) VALUES('" + code + "','" + metroDateTime1.Value + "','" + ctype + "','" + txt_no.Text + "', 'no modules' ,'" + resourceP1 + "','" + resourceP2 + "','" + resourceP3 + "',N'" + txt_venue.Text + "','0','0')");
                    d.insert("INSERT INTO Short_program_details (Code,Program_title) VALUES ('" + code + "','" + txt_progtitle.Text + "')");

                }
                if (cmb_type.SelectedIndex == 5)
                {
                    d.insert("INSERT INTO Session_details (program_no,scheduled_date,course_type,course_no,module,Resource_person_1,Resource_person_2,Resource_person_3,venue,overall_morn_rating,overall_noon_rating) VALUES('" + code + "','" + metroDateTime1.Value + "','" + ctype + "','None', 'no modules' ,'" + resourceP1 + "','" + resourceP2 + "','" + resourceP3 + "',N'" + txt_venue.Text + "','0','0')");
                    d.insert("INSERT INTO Short_program_details (Code,Program_title) VALUES ('" + code + "','" + txt_progtitle.Text + "')");

                }
                MessageBox.Show("Successfully Scheduled New Program", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


            }
        }
        public string generate_program_no(string type)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT program_no FROM Session_details WHERE course_type='"+type+"'",con);
            SqlDataReader dr = cmd.ExecuteReader();
            List<int> progarm_nos = new List<int>();
            while (dr.Read())
            {
                progarm_nos.Add(Convert.ToInt32(dr.GetValue(0).ToString().Split('/').GetValue(4)));

            }
            if (!progarm_nos.Any())
            {
                progarm_nos.Add(0);
            }
            else
            {

            }
            con.Close();
            if (type == "Diploma")
            {
                return "NILS/" + DateTime.Today.Year.ToString().Remove(0, 2) + "/" + DateTime.Today.Month + "/Dip/" + (progarm_nos.Max() + 1).ToString();
            }
            else if (type == "Certificate")
            {
                return "NILS/" + DateTime.Today.Year.ToString().Remove(0, 2) + "/" + DateTime.Today.Month + "/Certif/" + (progarm_nos.Max() + 1).ToString();
            }
            else if (type == "One-day")
            {
                return "NILS/" + DateTime.Today.Year.ToString().Remove(0, 2) + "/" + DateTime.Today.Month + "/1D/" + (progarm_nos.Max() + 1).ToString();
            }
            else if (type == "Two-day")
            {
                return "NILS/" + DateTime.Today.Year.ToString().Remove(0, 2) + "/" + DateTime.Today.Month + "/2D/" + (progarm_nos.Max() + 1).ToString();
            }
            else if (type == "Three-day")
            {
                return "NILS/" + DateTime.Today.Year.ToString().Remove(0, 2) + "/" + DateTime.Today.Month + "/3D/" + (progarm_nos.Max() + 1).ToString();
            }
            else if (type == "Workshop")
            {
                return "NILS/" + DateTime.Today.Year.ToString().Remove(0, 2) + "/" + DateTime.Today.Month + "/WS/" + (progarm_nos.Max() + 1).ToString();
            }
            else
            {
                return "";
            }
        }
        private void cmb_rperson2_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void tile_refresh_Click(object sender, EventArgs e)
        {
            Database d2 = new Database();
            metroGrid1.DataSource = d2.show("SELECT * FROM Session_details");
            metroGrid1.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";

        }

        private void cmb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_module.DataSource = null;
            cmb_module.Text = "";
            txt_no.Text = "";
            if (cmb_type.SelectedIndex == 0)
            {
                cmb_batch.Enabled = true;
                cmb_name.DataSource = General_methods.fill_course_combobox("Diploma");
                ctype = "Diploma";
                cmb_module.Enabled = true;
                txt_venue.Text = "NILS";
                groupBox1.Enabled = false;
                txt_venue.Enabled = false;
                txt_progtitle.Enabled = false;
                txt_progtitle.Text = "None";
                cmb_name.Enabled = true;
                rbn_in.Checked = true;
                rbn_out.Checked = false;
                cmb_batch.DataSource = General_methods.fill_batches_combobox("Diploma");
                cmb_name.Enabled = false;
            }
            if (cmb_type.SelectedIndex == 1)
            {
                cmb_batch.Enabled = true;
                cmb_name.DataSource = General_methods.fill_course_combobox("Certificate");
                ctype = "Certificate";
                cmb_module.Enabled = false;
                groupBox1.Enabled = false;
                txt_venue.Text = "NILS";
                txt_venue.Enabled = false;
                txt_progtitle.Enabled = false;
                txt_progtitle.Text = "None";
                cmb_name.Enabled = true;
                rbn_in.Checked = true;
                rbn_out.Checked = false;
                cmb_batch.DataSource = General_methods.fill_batches_combobox("Certificate");
                cmb_name.Enabled = false;

            }
            if (cmb_type.SelectedIndex == 2)
            {
                cmb_name.Enabled = true;
                cmb_name.DataSource = General_methods.fill_course_combobox("Short");
                ctype = "One-day";
                cmb_module.Enabled = false;
                groupBox1.Enabled = true;
                txt_venue.Enabled = true;
                txt_progtitle.Enabled = false;
                txt_progtitle.Text = "None";
                cmb_name.Enabled = true;
                txt_venue.Text = "";
                cmb_batch.Enabled = false;
            }
            if (cmb_type.SelectedIndex == 3)
            {
                cmb_name.Enabled = true;
                cmb_name.DataSource = General_methods.fill_course_combobox("Short");
                ctype = "Two-day";
                cmb_module.Enabled = false;
                groupBox1.Enabled = true;
                txt_venue.Enabled = true;
                txt_progtitle.Enabled = false;
                txt_progtitle.Text = "None";
                cmb_name.Enabled = true;
                txt_venue.Text = "";
                cmb_batch.Enabled = false;

            }
            if (cmb_type.SelectedIndex == 4)
            {
                cmb_name.Enabled = true;
                cmb_name.DataSource = General_methods.fill_course_combobox("Short");
                ctype = "Three-day";
                cmb_module.Enabled = false;
                groupBox1.Enabled = true;
                txt_venue.Enabled = true;
                txt_progtitle.Enabled = false;
                txt_progtitle.Text = "None";
                cmb_name.Enabled = true;
                txt_venue.Text = "";
                cmb_batch.Enabled = false;

            }
            if (cmb_type.SelectedIndex == 5)
            {
                cmb_name.Enabled = true;
                ctype = "Workshop";
                groupBox1.Enabled = true;
                txt_venue.Enabled = true;
                ctype = "Workshop";
                txt_progtitle.Enabled = true;
                txt_progtitle.Text = "";
                cmb_name.Enabled = false;
                cmb_module.Enabled = false;
                cmb_module.Text = "";
                cmb_name.Text = "";
                cmb_name.DataSource = null;
                txt_venue.Text = "";
                //txt_venue.ReadOnly = false;
                cmb_batch.Enabled = false;

            }


        }

        private void cmb_module_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            module = cmb_module.Text;
        }
        string resourceP1;
        string resourceP2;
        string resourceP3;
        private void cmb_rperson1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
            /*string[] array = cmb_rperson1.Text.Split(new char[] { ' ' }, 2);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Lecturer_no FROM Lecture_details WHERE F_name='" + array[0] + "' AND L_name='" + array[1] + "'",con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            resourceP1 = dr.GetValue(0).ToString();
            dr.Close();
            con.Close();*/
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void cmb_type_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked == true)
            {
                cmb_rperson2.DataSource = General_methods.fill_lecturer_names_combobox();
                cmb_rperson2.Enabled = true;
                cmb_rperson2.Items.Remove("None");
            }
            else
            {
                cmb_rperson2.DataSource = null;
                cmb_rperson2.Items.Add("None");
                cmb_rperson2.Text = "None";
                cmb_rperson2.Enabled = false;
            }
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox2.Checked == true)
            {
                cmb_rperson3.DataSource = General_methods.fill_lecturer_names_combobox();
                cmb_rperson3.Enabled = true;
                cmb_rperson3.Items.Remove("None");
            }
            else
            {
                cmb_rperson3.DataSource = null;
                cmb_rperson3.Items.Add("None");
                cmb_rperson3.Text = "None";
                cmb_rperson3.Enabled = false;
            }
        }

        private void cmb_rperson3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txt_venue_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = G_maps.get_place_id_from_place_name(txt_venue.Text);
            //txt_phoneno2.Text = stats[3].ToString();
        }

        private void txt_venue_TextChanged(object sender, EventArgs e)
        {
            if (txt_venue.SelectedIndex > -1)
            {

            }
            else
            {
                G_maps.autocomplete_place_combobox(txt_venue);
            }
        }

        private void cmb_batch_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_name.Text = General_methods.get_course_name_from_course_no(General_methods.get_course_no_of_batch_from_batch_no(General_methods.get_batch_no_from_batch_name(cmb_batch.Text)));
        }
    }
}
