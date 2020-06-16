using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

namespace NILS_original
{
    public partial class ManageWSprogss : UserControl
    {
        public bool status;
        SqlConnection con = new SqlConnection(Credentials.connection);
        public ManageWSprogss()
        {
            InitializeComponent();              
            cmb_company.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmb_company.AutoCompleteSource = AutoCompleteSource.ListItems;
            txt_designation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_designation.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmb_company.Text = "";
            //cmb_address.Enabled = false;            
            txt_designation.DataSource = General_methods.fill_designations_combobox();
            /*string[] districts = { "Ampara", "Anuradhapura", "Badulla", "Batiicaloa", "Colombo", "Galle", "Gampaha", "Hambantota", "Jaffna", "Kalutara", "Kandy", "Kegalle", "Kilinochchi", "Kurunegala", "Mannar", "Matale", "Matara", "Monaragala", "Mullaitivu", "Nuwara Eliya", "Polonnaruwa", "Puttalam", "Ratnapura", "Trincomalee", "Vavuniya" };
            cmb_address.Items.AddRange(districts);*/
            cmb_address.DataSource = General_methods.fill_districts_combobox();
        }
        
        private void metroTile1_Click(object sender, EventArgs e)
        {

        }
        Database d = new Database();

        private void tile_price_Click(object sender, EventArgs e)
        {
            if (txt_price.Enabled == false)
            {
                txt_price.Enabled = true;
                tile_price.Text = "Confirm price per head";
            }
            else
            {
                d.update("UPDATE Short_program_details SET per_head_price='"+txt_price.Text+"' WHERE Code='"+lbl_code.Text+"'");
                txt_price.Enabled = false;
                tile_price.Text = "Edit price per head";
            }
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            if (txt_particpantName.Text == "")
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
            else if (txt_designation.Text == "" || txt_designation.Text== "Occupations")
            {
                MessageBox.Show(this, "Please select correct designation", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (General_methods.Quick_NIC_Validation(txt_nic.Text) == "Invalid")
            {
                MessageBox.Show(this, "Please enter valid NIC", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (metroCheckBox1.Checked == false && cmb_company.Text == "")
            {
                MessageBox.Show(this, "Please select Organization of participant", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (cmb_address.Text == "")
            {
                MessageBox.Show(this, "Please select Address of participant", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                // string ref_no=lbl_code.Text+"/"+ (d.singleInt("SELECT COUNT(*) FROM Short_program_participation WHERE program_code='" + lbl_code.Text + "'")+1).ToString();
                string ref_no = gereate_ref_no();
                if (metroCheckBox1.Checked == false)
                {
                    string com_name = d.singleString("SELECT Organization_id FROM Company_details WHERE Organization_name=N'" + cmb_company.Text + "'");
                    d.insert("INSERT INTO Short_program_participation (ref_no,program_code,Organization_id,Name,designation,phone_no,Email,address,NIC,pre_registered) VALUES ('" + ref_no + "','" + lbl_code.Text + "','" + com_name + "','" + txt_particpantName.Text + "','" + txt_designation.Text + "','" + txt_phoneno.Text + "','" + txt_email.Text + "','" + cmb_address.Text + "','"+txt_nic.Text+"','"+status+"')");
                    MessageBox.Show(this, "Successfully added new participant", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();

                }
                else
                {
                    d.insert("INSERT INTO Short_program_participation (ref_no,program_code,Organization_id,Name,designation,phone_no,Email,address,NIC,pre_registered) VALUES ('" + ref_no + "','" + lbl_code.Text + "','Individual','" + txt_particpantName.Text + "','"+txt_designation.Text+"','" + txt_phoneno.Text + "','" + txt_email.Text + "','" + cmb_address.Text + "','"+txt_nic.Text+"','"+status+"')");
                    MessageBox.Show(this, "Successfully added new participant", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                }

            }

        }
        public string gereate_ref_no()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT ref_no FROM Short_program_participation WHERE program_code='" + lbl_code.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            List<int> progarm_nos = new List<int>();
            while (dr.Read())
            {
                progarm_nos.Add(Convert.ToInt32(dr.GetValue(0).ToString().Split('/').GetValue(5)));

            }
            if (!progarm_nos.Any())
            {
                progarm_nos.Add(0);
            }
            else
            {

            }
            con.Close();
            return lbl_code.Text + "/" + (progarm_nos.Max() + 1).ToString();
        }
        public void clear()
        {
            txt_phoneno.Text = "";
            txt_particpantName.Text = "";
            txt_email.Text = "";
            txt_designation.Text = "";
            cmb_company.Text = "";
            cmb_address.Text = "";
            txt_nic.Text = "";
        }
        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked == true)
            {
                cmb_company.Enabled = false;
                cmb_company.Text = "";
                //cmb_address.Enabled = true; 
            }
            else
            {
                cmb_company.Enabled = true;
                //cmb_address.Enabled = false;
                //cmb_address.Text = "";

            }
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void metroLink1_Click_1(object sender, EventArgs e)
        {
            New_company n = new New_company();
            n.Show();
            
            //n.Parent=this;
            
        }

        private void cmb_company_DropDown(object sender, EventArgs e)
        {
            cmb_company.DataSource = General_methods.fill_companys_combobx();

        }

        private void cmb_company_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void cmb_address_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (cmb_address.SelectedIndex > -1)
            {

            }
            else
            {
                G_maps.autocomplete_place_combobox(cmb_address);
            }*/
        }

        private void tile_admincharges_Click(object sender, EventArgs e)
        {
            if (txt_admincharges.Enabled == false)
            {
                txt_admincharges.Enabled = true;
                tile_admincharges.Text = "Confirm";
            }
            else
            {
                d.update("UPDATE Short_program_details SET Admin_charges='"+txt_admincharges.Text+"' WHERE Code='"+lbl_code.Text+"'");
                txt_admincharges.Enabled = false;
                tile_admincharges.Text = "Change";
            }
        }

        private void tile_lecfees_Click(object sender, EventArgs e)
        {
            if (txt_lecfees.Enabled == false)
            {
                txt_lecfees.Enabled = true;
                tile_lecfees.Text = "Confirm";
            }
            else
            {
                if (txt_lecfees.Text == "")
                {

                }
                {
                    d.update("UPDATE Short_program_details SET Lecturer_fees='" + txt_lecfees.Text + "' WHERE Code='" + lbl_code.Text + "'");
                    txt_lecfees.Enabled = false;
                    tile_lecfees.Text = "Change";
                }
            }
        }

        private void tile_stationaryfees_Click(object sender, EventArgs e)
        {
            if (txt_stationaryfees.Enabled == false)
            {
                txt_stationaryfees.Enabled = true;
                tile_stationaryfees.Text = "Confirm";
            }
            else
            {
                if (txt_stationaryfees.Text == "")
                {

                }
                {
                    d.update("UPDATE Short_program_details SET Stationary_fees='" + txt_stationaryfees.Text + "' WHERE Code='" + lbl_code.Text + "'");
                    txt_stationaryfees.Enabled = false;
                    tile_stationaryfees.Text = "Change";
                }
            }
        }

        private void tile_photocopyfees_Click(object sender, EventArgs e)
        {
            if (txt_photocopyfees.Enabled == false)
            {
                txt_photocopyfees.Enabled = true;
                tile_photocopyfees.Text = "Confirm";
            }
            else
            {
                if (txt_photocopyfees.Text == "")
                {

                }
                {
                    d.update("UPDATE Short_program_details SET Photocopy_fees='" + txt_photocopyfees.Text + "' WHERE Code='" + lbl_code.Text + "'");
                    txt_photocopyfees.Enabled = false;
                    tile_photocopyfees.Text = "Change";
                }
            }
        }

        private void tile_LandR_Click(object sender, EventArgs e)
        {
            if (txt_LandR.Enabled == false)
            {
                txt_LandR.Enabled = true;
                tile_LandR.Text = "Confirm";
            }
            else
            {
                if (txt_LandR.Text == "")
                {

                }
                {
                    d.update("UPDATE Short_program_details SET Lunch_Refreshments='" + txt_LandR.Text + "' WHERE Code='" + lbl_code.Text + "'");
                    txt_LandR.Enabled = false;
                    tile_LandR.Text = "Change";
                }
            }
        }

        private void tile_waterbottles_Click(object sender, EventArgs e)
        {
            if (txt_waterbottles.Enabled == false)
            {
                txt_waterbottles.Enabled = true;
                tile_waterbottles.Text = "Confirm";
            }
            else
            {
                if (txt_waterbottles.Text == "")
                {

                }
                {
                    d.update("UPDATE Short_program_details SET water='" + txt_waterbottles.Text + "' WHERE Code='" + lbl_code.Text + "'");
                    txt_waterbottles.Enabled = false;
                    tile_waterbottles.Text = "Change";
                }
            }
        }

        private void tile_hallcharges_Click(object sender, EventArgs e)
        {
            if (txt_hallcharges.Enabled == false)
            {
                txt_hallcharges.Enabled = true;
                tile_hallcharges.Text = "Confirm";
            }
            else
            {
                if (txt_hallcharges.Text == "")
                {

                }
                {
                    d.update("UPDATE Short_program_details SET Hall_charges='" + txt_hallcharges.Text + "' WHERE Code='" + lbl_code.Text + "'");
                    txt_hallcharges.Enabled = false;
                    tile_hallcharges.Text = "Change";
                }
            }
        }

        private void txt_designation_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
        public static string type;
        private void metroTile6_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("EXEC Program_budget_report @progno='"+lbl_code.Text+"'",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Program_budget_report obj = new Program_budget_report();
            obj.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Budgetreport.xsl", "Budget Report for "+ d.singleString("SELECT course_type FROM Session_details WHERE program_no='" + lbl_code.Text + "'")+" - "+lbl_code.Text + " - " + lbl_title.Text, d.singleString("SELECT course_type FROM Session_details WHERE program_no='"+lbl_code.Text+"'"),"");
            con.Close();

        }

        private void metroTile1_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("EXEC Students_Participation_report_of_program @progno='"+lbl_code.Text+"'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt1 = new DataTable();
            dt1 = ds.Tables[0];
            DataTable dt2 = new DataTable();
            dt2 = ds.Tables[1];
            Program_participation_general_report p = new Program_participation_general_report();
            p.WriteDataTableToExcel(dt1, dt2, "Worksheet1", @"C:\\Participationreport.xsl", "Participation Report for " + d.singleString("SELECT course_type FROM Session_details WHERE program_no='" + lbl_code.Text + "'") + " - " + lbl_code.Text+"-"+lbl_title.Text, d.singleString("SELECT course_type FROM Session_details WHERE program_no='" + lbl_code.Text + "'"), "");
            con.Close();
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT c.Organization_name,COUNT(*) AS Number_of_participants FROM Short_program_participation s INNER JOIN Company_details c ON s.Organization_id=c.Organization_id WHERE s.program_code='"+lbl_code.Text+"' GROUP BY c.Organization_name  ",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Program_company_participation_report c = new Program_company_participation_report();
            c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Participation_report.xsl", "Participation by Organization for " + d.singleString("SELECT course_type FROM Session_details WHERE program_no='" + lbl_code.Text + "'") + " - " + lbl_code.Text+" - "+lbl_title.Text, d.singleString("SELECT course_type FROM Session_details WHERE program_no='" + lbl_code.Text + "'"), "",d.singleInt("SELECT COUNT(*) FROM Short_program_participation WHERE Organization_id='Individual' AND program_code='"+lbl_code.Text+"'"));
            con.Close();
        }

        private void metroTile13_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT address AS Destrict, COUNT(*) AS No_of_participants FROM Short_program_participation WHERE program_code='"+lbl_code.Text+"' GROUP BY (address)", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Participation_by_destrict_report c = new Participation_by_destrict_report();
            c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Participation_by_destrict_report.xsl", "Participation by Destrict for " + d.singleString("SELECT course_type FROM Session_details WHERE program_no='" + lbl_code.Text + "'") + " - " + lbl_code.Text + " - " + lbl_title.Text, d.singleString("SELECT course_type FROM Session_details WHERE program_no='" + lbl_code.Text + "'"), "", d.singleInt("SELECT COUNT(*) FROM Short_program_participation WHERE Organization_id='Individual' AND program_code='" + lbl_code.Text + "'"));
            con.Close();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT designation AS Designation, COUNT(*) AS No_of_participants FROM Short_program_participation WHERE program_code='"+lbl_code.Text+"' GROUP BY (designation)", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Participation_by_destrict_report c = new Participation_by_destrict_report();
            c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Participation_by_designation_report.xsl", "Participation by Designation for " + d.singleString("SELECT course_type FROM Session_details WHERE program_no='" + lbl_code.Text + "'") + " - " + lbl_code.Text + " - " + lbl_title.Text, d.singleString("SELECT course_type FROM Session_details WHERE program_no='" + lbl_code.Text + "'"), "", d.singleInt("SELECT COUNT(*) FROM Short_program_participation WHERE Organization_id='Individual' AND program_code='" + lbl_code.Text + "'"));
            con.Close();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("EXEC Income_report_of_program @progno='"+lbl_code.Text+"'",con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt1 = new DataTable();
            dt1 = ds.Tables[0];
            DataTable dt2 = new DataTable();
            dt2 = ds.Tables[1];
            Income_report_for_program p = new Income_report_for_program();
            p.WriteDataTableToExcel(dt1,dt2, "Worksheet1", @"C:\\Payment_report_for_program.xsl", "Income Report for " + d.singleString("SELECT course_type FROM Session_details WHERE program_no='" + lbl_code.Text + "'") + " - " + lbl_code.Text + " - " + lbl_title.Text, d.singleString("SELECT course_type FROM Session_details WHERE program_no='" + lbl_code.Text + "'"),"");
            con.Close();
        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("EXEC Income_report_of_program @progno='" + lbl_code.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt3 = new DataTable();
            dt3 = ds.Tables[2];
            DataTable dt4 = new DataTable();
            dt4 = ds.Tables[3];
            Program_payments_report p = new Program_payments_report();
            p.WriteDataTableToExcel(dt3, dt4, "Worksheet1", @"C:\\Payment_report_for_program.xsl", "Payement Report for " + d.singleString("SELECT course_type FROM Session_details WHERE program_no='" + lbl_code.Text + "'") + " - " + lbl_code.Text + " - " + lbl_title.Text, d.singleString("SELECT course_type FROM Session_details WHERE program_no='" + lbl_code.Text + "'"), "",lbl_title.Text);
            con.Close();
        }

       /* private void btn_attendance_Click(object sender, EventArgs e)
        {
            con.Open();
            Attendance_for_programs a = new Attendance_for_programs();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT c.Organization_name FROM Short_program_participation s INNER JOIN Company_details c ON s.Organization_id=c.Organization_id WHERE s.program_code='"+lbl_code.Text+"'",con);
            SqlDataReader dr = cmd.ExecuteReader();
            a.lbl_tot_participants.Text = d.singleInt("SELECT COUNT(*) FROM Short_program_participation WHERE program_code='" + lbl_code.Text + "' AND pre_registered=1").ToString();
            a.lbl_tot_attendees.Text = d.singleInt("SELECT COUNT(*) FROM Short_program_participation WHERE program_code='"+lbl_code.Text+ "' AND participation_status=1 AND pre_registered=1").ToString();
            a.code = lbl_code.Text;
            a.Show();
            a.metroTile1.Click += Handler;
            con.Close();
        }
        public void Handler(object sender, EventArgs e)
        {
            
            con.Open();
            Attendance_for_programs a = new Attendance_for_programs();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT c.Organization_name FROM Short_program_participation s INNER JOIN Company_details c ON s.Organization_id=c.Organization_id WHERE s.program_code='" + lbl_code.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            a.lbl_tot_participants.Text = d.singleInt("SELECT COUNT(*) FROM Short_program_participation WHERE program_code='" + lbl_code.Text + "' AND pre_registered=1").ToString();
            a.lbl_tot_attendees.Text = d.singleInt("SELECT COUNT(*) FROM Short_program_participation WHERE program_code='" + lbl_code.Text + "' AND participation_status=1 AND pre_registered=1").ToString();
            a.code = lbl_code.Text;
            a.Show();
            a.metroTile1.Click += Handler;
            con.Close();
        }*/


        private void metroTile10_Click(object sender, EventArgs e)
        {

            con.Open();
            Attendance_for_programs a = new Attendance_for_programs();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT c.Organization_name FROM Short_program_participation s INNER JOIN Company_details c ON s.Organization_id=c.Organization_id WHERE s.program_code='" + lbl_code.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            a.lbl_tot_participants.Text = d.singleInt("SELECT COUNT(*) FROM Short_program_participation WHERE program_code='" + lbl_code.Text + "' AND pre_registered=1").ToString();
            a.lbl_tot_attendees.Text = d.singleInt("SELECT COUNT(*) FROM Short_program_participation WHERE program_code='" + lbl_code.Text + "'").ToString();
            a.code = lbl_code.Text;
            a.Show();
            con.Close();
            a.label1.TextChanged += Handler;
        }
        public void Handler(object sender, EventArgs e)
        {

            con.Open();
            Attendance_for_programs a = new Attendance_for_programs();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT c.Organization_name FROM Short_program_participation s INNER JOIN Company_details c ON s.Organization_id=c.Organization_id WHERE s.program_code='" + lbl_code.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            a.lbl_tot_participants.Text = d.singleInt("SELECT COUNT(*) FROM Short_program_participation WHERE program_code='" + lbl_code.Text + "' AND pre_registered=1").ToString();
            a.lbl_tot_attendees.Text = d.singleInt("SELECT COUNT(*) FROM Short_program_participation WHERE program_code='" + lbl_code.Text + "'").ToString();
            a.code = lbl_code.Text;
            a.Show();
            con.Close();
        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("EXEC Age_report_for_Program @progno='"+lbl_code.Text+"'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Participation_by_destrict_report c = new Participation_by_destrict_report();
            c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Participation_by_age_report.xsl", "Participation by age for " + d.singleString("SELECT course_type FROM Session_details WHERE program_no='" + lbl_code.Text + "'") + " - " + lbl_code.Text + " - " + lbl_title.Text, d.singleString("SELECT course_type FROM Session_details WHERE program_no='" + lbl_code.Text + "'"), "", d.singleInt("SELECT COUNT(*) FROM Short_program_participation WHERE Organization_id='Individual' AND program_code='" + lbl_code.Text + "'"));
            con.Close();
        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT address FROM Short_program_participation p INNER JOIN Session_details s ON p.program_code=s.program_no WHERE p.program_code='"+lbl_code.Text+"'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> latitudes = new List<string>();
            List<string> longitudes = new List<string>();
            //int count = 0;
            while (dr.Read())
            {

                string[] x = G_maps.get_place_details_from_place_id(G_maps.get_place_id_from_place_name_2(dr.GetValue(0).ToString() + ", Sri Lanka"));
                latitudes.Add(x[3]);
                longitudes.Add(x[4]);

            }

            string[] lats = latitudes.ToArray();
            string[] longs = longitudes.ToArray();
            string a = null;
            for (int c = 0; c < lats.Length; c++)
            {
                a = a + "markers=colour:blue%7Clabel:S%7C" + lats[c] + "," + longs[c] + "&";
            }
            //MessageBox.Show(a);
            string url = "https://maps.googleapis.com/maps/api/staticmap?center=SriLanka&zoom=8&size=1500x800&maptype=roadmap&" + a + "key=AIzaSyBK7FISIQh5FRHjbh4XOyAJ1otcBy_6ors";
            Process.Start("chrome.exe", url);
            //center=Colombo&zoom=10&
            con.Close();
            
        }
    }
}
