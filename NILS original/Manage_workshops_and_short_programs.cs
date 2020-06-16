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
using System.IO;
using System.Globalization;

namespace NILS_original
{
    public partial class Manage_workshops_and_short_programs : MetroFramework.Forms.MetroForm
    {
        public Manage_workshops_and_short_programs()
        {
            InitializeComponent();
            metroTabControl1.SelectedTab = metroTabPage1;
        }
        SqlConnection con = new SqlConnection(Credentials.connection);
        private void Manage_workshops_and_short_programs_Load(object sender, EventArgs e)
        {
            
        }
        Database d = new Database();
        private void cmb_selectWorkshop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_selectWorkshop.Text == "")
            {

            }
            else
            {
                ManageWSprogss w = new ManageWSprogss();
                metroPanel1.Controls.Clear();
                con.Open();
                //MessageBox.Show(cmb_selectWorkshop.Text.Split('-').GetValue(0).ToString());
                SqlCommand cmd = new SqlCommand("SELECT s.program_no,s.scheduled_date,s.course_type,s.course_no,s.module,s.Resource_person_1,s.Resource_person_2,s.Resource_person_3,s.venue,s.Batch_no,p.Program_title,p.per_head_price,p.Admin_charges,p.Hall_charges,p.Lecturer_fees,p.Lunch_Refreshments,p.Stationary_fees,p.Photocopy_fees,p.water FROM Session_details s INNER JOIN Short_program_details p ON s.program_no=p.Code WHERE program_no='" + cmb_selectWorkshop.Text.Split('-').GetValue(0).ToString() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                w.lbl_code.Text = dr.GetValue(0).ToString();
                w.lbl_date.Text = dr.GetDateTime(1).ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                w.lbl_title.Text = dr.GetValue(10).ToString();
                w.lbl_venue.Text = dr.GetValue(8).ToString();
                w.lbl_rperson1.Text = General_methods.get_lec_name_from_lec_no(dr.GetValue(5).ToString());
                if (dr.GetValue(6).ToString() != "None")
                {
                    w.lbl_rperson2.Text = General_methods.get_lec_name_from_lec_no(dr.GetValue(6).ToString());
                }
                else
                {
                    w.lbl_rperson2.Text = "None";
                }
                if (dr.GetValue(7).ToString() != "None")
                {
                    w.lbl_rperson3.Text = General_methods.get_lec_name_from_lec_no(dr.GetValue(7).ToString());
                }
                else
                {
                    w.lbl_rperson3.Text = "None";
                }
                if (!dr.IsDBNull(11))
                {
                    w.txt_price.Enabled = false;
                    w.tile_price.Text = "Edit price per head";
                    w.txt_price.Text = dr.GetValue(11).ToString();
                }
                else
                {

                    w.tile_price.Text = "Add Price per head";
                    w.txt_price.Enabled = true;
                }
                if (!dr.IsDBNull(12))
                {
                    w.txt_admincharges.Enabled = false;
                    w.tile_admincharges.Text = "Change";
                    w.txt_admincharges.Text = dr.GetValue(12).ToString();
                }
                else
                {

                    //w.tile_price.Text = "Confirm Expenses";
                    w.txt_admincharges.Enabled = true;
                }
                if (!dr.IsDBNull(13))
                {
                    w.txt_hallcharges.Enabled = false;
                    w.tile_hallcharges.Text = "Change";
                    w.txt_hallcharges.Text = dr.GetValue(13).ToString();
                }
                else
                {

                   // w.txt_hallcharges.Text = "Confirm Expenses";
                    w.txt_hallcharges.Enabled = true;
                }
                if (!dr.IsDBNull(14))
                {
                    w.txt_lecfees.Enabled = false;
                    w.tile_lecfees.Text = "Change";
                    w.txt_lecfees.Text = dr.GetValue(14).ToString();
                }
                else
                {

                    //w.txt_lecfees.Text = "Confirm Expenses";
                    w.txt_lecfees.Enabled = true;
                }
                if (!dr.IsDBNull(15))
                {
                    w.txt_LandR.Enabled = false;
                    w.tile_LandR.Text = "Change";
                    w.txt_LandR.Text = dr.GetValue(15).ToString();
                }
                else
                {

                    //w.txt_LandR.Text = "Confirm Expenses";
                    w.txt_LandR.Enabled = true;
                }
                if (!dr.IsDBNull(16))
                {
                    w.txt_stationaryfees.Enabled = false;
                    w.tile_stationaryfees.Text = "Change";
                    w.txt_stationaryfees.Text = dr.GetValue(16).ToString();
                }
                else
                {

                    //w.txt_stationaryfees.Text = "Confirm Expenses";
                    w.txt_stationaryfees.Enabled = true;
                }
                if (!dr.IsDBNull(17))
                {
                    w.txt_photocopyfees.Enabled = false;
                    w.tile_photocopyfees.Text = "Change";
                    w.txt_photocopyfees.Text = dr.GetValue(17).ToString();
                }
                else
                {

                    //w.txt_photocopyfees.Text = "Confirm Expenses";
                    w.txt_photocopyfees.Enabled = true;
                }
                if (!dr.IsDBNull(18))
                {
                    w.txt_waterbottles.Enabled = false;
                    w.tile_waterbottles.Text = "Change";
                    w.txt_waterbottles.Text = dr.GetValue(18).ToString();
                }
                else
                {

                    //w.txt_waterbottles.Text = "Confirm Expenses";
                    w.txt_waterbottles.Enabled = true;
                }

                if (Convert.ToDateTime(d.singleString("SELECT scheduled_date FROM Session_details WHERE program_no='" +w.lbl_code.Text + "'")) < DateTime.Today.Date)
                {
                    //w/btn_attendance.Enabled = true;
                    w.status = true;
                }
                else
                {
                    //w.btn_attendance.Enabled = false;
                    w.status = false;
                    w.groupBox1.Text = "Pre Register Participants";
                }
                
                metroPanel1.Controls.Add(w);
               
                
                con.Close();
            }
        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cmb_selectWorkshop.Text = "";
            cmb_selectWorkshop.DataSource = null;
            int count = 0;
            string[] names = new string[100];
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT s.program_no,s.scheduled_date,c.Program_title FROM Session_details s INNER JOIN Short_program_details c ON s.program_no=c.Code WHERE s.course_type='Workshop' AND  s.scheduled_date >GETDATE()", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                names[count] = dr.GetValue(0).ToString() + " - " + dr.GetDateTime(1).ToString("dd/M/yyyy", CultureInfo.InvariantCulture) + " - " + dr.GetValue(2).ToString();
                count++;
            }
            cmb_selectWorkshop.DataSource = names;
            con.Close();
        }

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cmb_selectWorkshop.Text = "";
            cmb_selectWorkshop.DataSource = null;
            int count = 0;
            string[] names = new string[100];
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT s.program_no,s.scheduled_date,c.Program_title FROM Session_details s INNER JOIN Short_program_details c ON s.program_no=c.Code WHERE s.course_type='Workshop' AND s.scheduled_date <GETDATE()", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                names[count] = dr.GetValue(0).ToString() + " - " + (dr.GetDateTime(1).ToString("dd/M/yyyy", CultureInfo.InvariantCulture)) + " - " + dr.GetValue(2).ToString();
                count++;
            }
            cmb_selectWorkshop.DataSource = names;
            con.Close();
        }

        private void cmb_selectWorkshop_Click(object sender, EventArgs e)
        {
            if (metroRadioButton1.Checked == false && metroRadioButton2.Checked == false)
            {
                MetroFramework.MetroMessageBox.Show(this, "Please select whether the workshop is completed or is to be held in the future", "NILS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {

            }
        }

        private void cmb_programs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_programs.Text == "")
            {

            }
            else
            {
                ManageWSprogss w1 = new ManageWSprogss();
                w1.metroLabel1.Text = "Program Code";
                w1.metroLabel3.Text = "Program Name";
                w1.metroLabel12.Text = "Date of Program";
                w1.groupBox2.Text = "Add Expenses for Program";
                metroPanel2.Controls.Clear();
                con.Open();
                //MessageBox.Show(cmb_selectWorkshop.Text.Split('-').GetValue(0).ToString());
                SqlCommand cmd = new SqlCommand("SELECT s.program_no,s.scheduled_date,s.course_type,p.Program_title,s.module,s.Resource_person_1,s.Resource_person_2,s.Resource_person_3,s.venue,s.Batch_no,p.Program_title,p.per_head_price,p.Admin_charges,p.Hall_charges,p.Lecturer_fees,p.Lunch_Refreshments,p.Stationary_fees,p.Photocopy_fees,p.water FROM Session_details s INNER JOIN Short_program_details p ON s.program_no=p.Code WHERE program_no='" + cmb_programs.Text.Split('-').GetValue(0).ToString() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                w1.lbl_code.Text = dr.GetValue(0).ToString();
                w1.lbl_date.Text = dr.GetDateTime(1).ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                w1.lbl_title.Text =dr.GetValue(3).ToString();
                w1.lbl_venue.Text = dr.GetValue(8).ToString();
                w1.lbl_rperson1.Text = General_methods.get_lec_name_from_lec_no(dr.GetValue(5).ToString());
                if (dr.GetValue(6).ToString() != "None")
                {
                    w1.lbl_rperson2.Text = General_methods.get_lec_name_from_lec_no(dr.GetValue(6).ToString());
                }
                else
                {
                    w1.lbl_rperson2.Text = "None";
                }
                if (dr.GetValue(7).ToString() != "None")
                {
                    w1.lbl_rperson3.Text = General_methods.get_lec_name_from_lec_no(dr.GetValue(7).ToString());
                }
                else
                {
                    w1.lbl_rperson3.Text = "None";
                }
                if (!dr.IsDBNull(11))
                {
                    w1.txt_price.Enabled = false;
                    w1.tile_price.Text = "Edit price per head";
                    w1.txt_price.Text = dr.GetValue(11).ToString();
                }
                else
                {

                    w1.tile_price.Text = "Add Price per head";
                    w1.txt_price.Enabled = true;
                }
                if (!dr.IsDBNull(12))
                {
                    w1.txt_admincharges.Enabled = false;
                    w1.tile_admincharges.Text = "Change";
                    w1.txt_admincharges.Text = dr.GetValue(12).ToString();
                }
                else
                {

                    //w.tile_price.Text = "Confirm Expenses";
                    w1.txt_admincharges.Enabled = true;
                }
                if (!dr.IsDBNull(13))
                {
                    w1.txt_hallcharges.Enabled = false;
                    w1.tile_hallcharges.Text = "Change";
                    w1.txt_hallcharges.Text = dr.GetValue(13).ToString();
                }
                else
                {

                    // w1.txt_hallcharges.Text = "Confirm Expenses";
                    w1.txt_hallcharges.Enabled = true;
                }
                if (!dr.IsDBNull(14))
                {
                    w1.txt_lecfees.Enabled = false;
                    w1.tile_lecfees.Text = "Change";
                    w1.txt_lecfees.Text = dr.GetValue(14).ToString();
                }
                else
                {

                    //w1.txt_lecfees.Text = "Confirm Expenses";
                    w1.txt_lecfees.Enabled = true;
                }
                if (!dr.IsDBNull(15))
                {
                    w1.txt_LandR.Enabled = false;
                    w1.tile_LandR.Text = "Change";
                    w1.txt_LandR.Text = dr.GetValue(15).ToString();
                }
                else
                {

                    //w1.txt_LandR.Text = "Confirm Expenses";
                    w1.txt_LandR.Enabled = true;
                }
                if (!dr.IsDBNull(16))
                {
                    w1.txt_stationaryfees.Enabled = false;
                    w1.tile_stationaryfees.Text = "Change";
                    w1.txt_stationaryfees.Text = dr.GetValue(16).ToString();
                }
                else
                {

                    //w1.txt_stationaryfees.Text = "Confirm Expenses";
                    w1.txt_stationaryfees.Enabled = true;
                }
                if (!dr.IsDBNull(17))
                {
                    w1.txt_photocopyfees.Enabled = false;
                    w1.tile_photocopyfees.Text = "Change";
                    w1.txt_photocopyfees.Text = dr.GetValue(17).ToString();
                }
                else
                {

                    //w1.txt_photocopyfees.Text = "Confirm Expenses";
                    w1.txt_photocopyfees.Enabled = true;
                }
                if (!dr.IsDBNull(18))
                {
                    w1.txt_waterbottles.Enabled = false;
                    w1.tile_waterbottles.Text = "Change";
                    w1.txt_waterbottles.Text = dr.GetValue(18).ToString();
                }
                else
                {

                    //w1.txt_waterbottles.Text = "Confirm Expenses";
                    w1.txt_waterbottles.Enabled = true;
                }
                if (Convert.ToDateTime(d.singleString("SELECT scheduled_date FROM Session_details WHERE program_no='" + w1.lbl_code.Text + "'")) < DateTime.Today.Date)
                {
                    //w1.btn_attendance.Enabled = true;
                }
                else
                {
                    //w1.btn_attendance.Enabled = false;

                }
                if (Convert.ToDateTime(d.singleString("SELECT scheduled_date FROM Session_details WHERE program_no='" + w1.lbl_code.Text + "'")) < DateTime.Today.Date)
                {
                   /* w1.btn_attendance.Enabled = true;
                    w1.status = true;*/

                }
                else
                {
                    /*w1.btn_attendance.Enabled = false;
                    w1.status = false;
                    w1.groupBox1.Text = "Pre Register Participants";*/

                }
                metroPanel2.Controls.Add(w1);


                con.Close();
            }
        }

        private void metroRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            cmb_programs.Text = "";
            cmb_programs.DataSource = null;
            int count = 0;
            string[] names = new string[100];
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT s.program_no,s.scheduled_date,c.Program_title FROM Session_details s INNER JOIN Short_program_details c ON s.program_no=c.Code WHERE (s.course_type='One-day' OR s.course_type='Two-day' OR s.course_type='Three-day')  AND  s.scheduled_date <GETDATE()", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                names[count] = dr.GetValue(0).ToString() + " - " + dr.GetDateTime(1).ToString("dd/M/yyyy", CultureInfo.InvariantCulture) + " - " + dr.GetValue(2).ToString();
                count++;
            }
            cmb_programs.DataSource = names;
            con.Close();
        }

        private void cmb_programs_Click(object sender, EventArgs e)
        {
            if (metroRadioButton3.Checked == false && metroRadioButton4.Checked == false)
            {
                MetroFramework.MetroMessageBox.Show(this, "Please select whether the program is completed or is to be held in the future", "NILS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {

            }
        }

        private void metroRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            cmb_programs.Text = "";
            cmb_programs.DataSource = null;
            int count = 0;
            string[] names = new string[100];
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT s.program_no,s.scheduled_date,c.Program_title FROM Session_details s INNER JOIN Short_program_details c ON s.program_no=c.Code WHERE (s.course_type='One-day' OR s.course_type='Two-day' OR s.course_type='Three-day')  AND  s.scheduled_date >GETDATE()", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                names[count] = dr.GetValue(0).ToString() + " - " + dr.GetDateTime(1).ToString("dd/M/yyyy", CultureInfo.InvariantCulture) + " - " + dr.GetValue(2).ToString();
                count++;
            }
            cmb_programs.DataSource = names;
            con.Close();
        }
    }
}
