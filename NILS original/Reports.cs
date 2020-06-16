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
using System.Reflection;

namespace NILS_original
{
    public partial class Reports : MetroFramework.Forms.MetroForm
    {
        SqlConnection con = new SqlConnection(Credentials.connection);
        public Reports()
        {
            InitializeComponent();
            metroDateTime1.Format = DateTimePickerFormat.Custom;
            metroDateTime1.CustomFormat = "yyyy-MM-dd";
            metroDateTime2.Format = DateTimePickerFormat.Custom;
            metroDateTime2.CustomFormat = "yyyy-MM-dd";
            metroDateTime3.Format = DateTimePickerFormat.Custom;
            metroDateTime3.CustomFormat = "yyyy-MM-dd";
            metroDateTime4.Format = DateTimePickerFormat.Custom;
            metroDateTime4.CustomFormat = "yyyy-MM-dd";
            metroDateTime5.Format = DateTimePickerFormat.Custom;
            metroDateTime5.CustomFormat = "yyyy-MM-dd";
            metroDateTime6.Format = DateTimePickerFormat.Custom;
            metroDateTime6.CustomFormat = "yyyy-MM-dd";
            metroRadioButton1.Checked = true;
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            metroComboBox1.SelectedIndex = 0;
            cmb_destricts.DataSource = General_methods.fill_districts_combobox();
            cmb_locations.DataSource = General_methods.fill_districts_combobox();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        public void overall_participants_report(string batchno = null, string ctype = null,DateTime? dat1=null,DateTime? dat2=null)
        {
            //MessageBox.Show(General_methods.get_batch_no_from_batch_name(cmb_batch.Text));
            if (batchno != null)
            {
                con.Open();
                SqlDataAdapter da1 = new SqlDataAdapter("SELECT s.stud_no,CONCAT(s.f_name,' ',s.m_name,' ',s.l_name) AS Name_of_Student,s.name_with_initials,s.NIC,s.gender,s.home_no,p.Address_string AS Address,s.Birthday,c.Organization_name,s.designation,s.mobile,s.tel_R_1 AS Residence_telephone_number FROM Stud_details s INNER JOIN Company_details c ON s.organization_id=c.Organization_id INNER JOIN Place_Details p ON s.address_R=p.place_id WHERE s.batch_no='" + batchno+ "'", con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT s.stud_no,CONCAT(s.f_name,' ',s.m_name,' ',s.l_name) AS Name_of_Student,s.name_with_initials,s.NIC,s.gender,s.home_no,p.Address_string AS Address,s.Birthday,s.designation,s.mobile,s.tel_R_1 FROM Stud_details s INNER JOIN Place_Details p ON s.address_R=p.place_id  WHERE organization_id='No company' AND batch_no='" + batchno + "' ", con);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                Program_participation_general_report p = new Program_participation_general_report();
                p.WriteDataTableToExcel(dt1, dt2, "Worksheet1", @"C:\\ParticipationreportDiploma.xsl", "Participation Report for " + General_methods.get_batch_no_from_batch_name(cmb_batch.Text) + "-" + "(" + cmb_batch.Text + ")", "", "");
                con.Close();
            }
            else
            {
                if (dat1 != null && dat2 != null)
                {
                    con.Open();
                    SqlDataAdapter da1 = new SqlDataAdapter("SELECT s.stud_no,b.Batch_no,m.course_name,CONCAT(s.f_name,' ',s.m_name,' ',s.l_name) AS Name_of_Student,s.name_with_initials,s.NIC,s.gender,s.home_no,p.Address_string AS Address,s.Birthday,c.Organization_name,s.designation,s.mobile,s.tel_R_1 AS Residence_telephone_number FROM Stud_details s INNER JOIN Company_details c ON s.organization_id=c.Organization_id INNER JOIN Batches b ON s.batch_no=b.Batch_no INNER JOIN Course_details_master m ON m.course_no=s.course_no INNER JOIN Place_Details p ON s.address_R=p.place_id WHERE (CAST(b.start_date AS date) >='" + dat1+"' AND CAST(b.start_date AS date)<'"+dat2+"') AND m.course_type='"+ctype+"' ORDER BY m.course_name", con);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    SqlDataAdapter da2 = new SqlDataAdapter("SELECT s.stud_no,b.Batch_no,m.course_name,CONCAT(s.f_name,' ',s.m_name,' ',s.l_name) AS Name_of_Student,s.name_with_initials,s.NIC,s.gender,s.home_no,p.Address_stringAS Address,s.Birthday,s.designation,s.mobile,s.tel_R_1 FROM Stud_details s INNER JOIN Batches b ON s.batch_no=b.Batch_no INNER JOIN Course_details_master m ON s.course_no=m.course_no INNER JOIN Place_Details p ON s.address_R=p.place_id WHERE organization_id='No company' AND CAST(b.start_date AS date) >='" + dat1+"' AND CAST(b.start_date AS date)<'"+dat2+ "' AND m.course_type='" + ctype + "' ORDER BY m.course_name ", con);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    Program_participation_general_report p = new Program_participation_general_report();
                    p.WriteDataTableToExcel(dt1, dt2, "Worksheet1", @"C:\\ParticipationreportDiploma.xsl", "Participation Report for all batches started from "+dat1+"to-"+dat2 , "", "");
                    con.Close();
                }
                else
                {
                    con.Open();
                    SqlDataAdapter da1 = new SqlDataAdapter("SELECT s.stud_no,s.batch_no,m.course_name,CONCAT(s.f_name,' ',s.m_name,' ',s.l_name) AS Name_of_Student,s.name_with_initials,s.NIC,s.gender,s.home_no,p.Address_string AS Address,s.Birthday,c.Organization_name,s.designation,s.mobile,s.tel_R_1 AS Residence_telephone_number FROM Stud_details s INNER JOIN Company_details c ON s.organization_id=c.Organization_id INNER JOIN Course_details_master m ON s.course_no=m.course_no INNER JOIN Place_Details p ON s.address_R=p.place_id  WHERE m.course_type='" + ctype+"'", con);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    SqlDataAdapter da2 = new SqlDataAdapter("SELECT s.stud_no,s.batch_no,c.course_name,CONCAT(s.f_name,' ',s.m_name,' ',s.l_name) AS Name_of_Student,s.name_with_initials,s.NIC,s.gender,s.home_no,p.Address_string AS Address,s.Birthday,s.designation,s.mobile,s.tel_R_1 FROM Stud_details s INNER JOIN Course_details_master c ON s.course_no=s.course_no INNER JOIN Place_Details p ON s.address_R=p.place_id WHERE s.organization_id='No company' AND c.course_type='" + ctype+"'", con);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    Program_participation_general_report p = new Program_participation_general_report();
                    p.WriteDataTableToExcel(dt1, dt2, "Worksheet1", @"C:\\ParticipationreportDiploma.xsl", "Participation Report for all Batches", "", "");
                    con.Close();
                }
            }
        }
        private void metroTile2_Click(object sender, EventArgs e)
        {
            //Optional Paramaters used
            if (metroCheckBox2.Checked == false)
            {
                overall_participants_report(General_methods.get_batch_no_from_batch_name(cmb_batch.Text));
            }

            else if (metroCheckBox2.Checked == true && metroCheckBox4.Checked == false)
            {
                overall_participants_report(ctype: metroComboBox1.Text, dat1: metroDateTime3.Value, dat2: metroDateTime4.Value);
            }
            else if (metroCheckBox2.Checked == true && metroCheckBox4.Checked == true)
            {
                overall_participants_report(ctype: metroComboBox1.Text);

            }


        }

        private void cmb_batch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_batch.Text != "")
            {
                lbl_batchno.Text = General_methods.get_batch_no_from_batch_name(cmb_batch.Text);
            }
        }
        private void participation_by_organization(string batchno=null, string ctype = null, DateTime? dat1 = null, DateTime? dat2 = null)
        {
            if (batchno != null)
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT c.Organization_name,COUNT(*) AS Number_of_participants FROM Stud_details s INNER JOIN Company_details c ON s.Organization_id=c.Organization_id WHERE s.batch_no='" + batchno + "' GROUP BY c.Organization_name ", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Program_company_participation_report c = new Program_company_participation_report();
                c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Participation_report_by_organization_batch.xsl", "Participation by Organization for " + batchno + " - " + "(" + cmb_batch.Text + ")", "", "", 0, "diploma", General_methods.get_course_no_of_batch_from_batch_no(batchno));
                con.Close();
            }
            else
            {
                if (dat1 != null && dat2 != null)
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT c.Organization_name,COUNT(*) AS Number_of_participants FROM Stud_details s INNER JOIN Company_details c ON s.Organization_id=c.Organization_id INNER JOIN Batches b ON s.batch_no=b.Batch_no INNER JOIN Course_details_master m ON s.course_no=m.course_no WHERE m.course_type='"+ctype+"' AND  CAST(b.start_date AS date) >='"+dat1+"' AND CAST(b.start_date AS date)<'"+dat2+ "' GROUP BY c.Organization_name", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Program_company_participation_report c = new Program_company_participation_report();
                    c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Participation_report_by_organization_batch.xsl", "Participation by Organization for all Batches from -"+dat1.Value.ToShortDateString()+"to- "+dat2.Value.ToShortDateString() , "","",d.singleInt("SELECT COUNT(*) FROM Stud_details WHERE organization_id='Individual participant'"),"diploma-all batches");
                    con.Close();
                }
                else
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT c.Organization_name,COUNT(*) AS Number_of_participants FROM Stud_details s INNER JOIN Company_details c ON s.Organization_id=c.Organization_id INNER JOIN Batches b ON s.batch_no=b.Batch_no INNER JOIN Course_details_master m ON s.course_no=m.course_no WHERE m.course_type='"+ctype+ "' GROUP BY c.Organization_name", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Program_company_participation_report c = new Program_company_participation_report();
                    c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Participation_report_by_organization_batch.xsl", "Participation by Organization for " + batchno + " - " + "(" + cmb_batch.Text + ")", "", "", d.singleInt("SELECT COUNT(*) FROM Stud_details WHERE organization_id='Individual participant'"), "diploma-all batches");
                    con.Close();
                }
            }
        }
        Database d = new Database();
        private void metroTile3_Click(object sender, EventArgs e)
        {
            if (metroCheckBox2.Checked == false)
            {
                participation_by_organization(General_methods.get_batch_no_from_batch_name(cmb_batch.Text));
            }

            else if (metroCheckBox2.Checked == true && metroCheckBox4.Checked == false)
            {
                participation_by_organization(ctype:metroComboBox1.Text,dat1: metroDateTime3.Value,dat2:metroDateTime4.Value);
            }
            else if (metroCheckBox2.Checked == true && metroCheckBox4.Checked == true)
            {
                participation_by_organization(ctype:metroComboBox1.Text);

            }
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            if (metroCheckBox2.Checked == false)
            {
                if (metroCheckBox3.Checked == true)
                {
                    get_geometry(batchno: General_methods.get_batch_no_from_batch_name(cmb_batch.Text));
                }
                else
                {
                    get_geometry(batchno: General_methods.get_batch_no_from_batch_name(cmb_batch.Text), islandwide: false, destrict: cmb_destricts.Text);

                }
            }

            else if (metroCheckBox2.Checked == true && metroCheckBox4.Checked == false)
            {
                if (metroCheckBox3.Checked == true)
                {
                    get_geometry(from: metroDateTime3.Value, to: metroDateTime4.Value);
                }
                else
                {
                    get_geometry(from: metroDateTime3.Value, to: metroDateTime4.Value,islandwide:false, destrict: cmb_destricts.Text);

                }
            }
            else if (metroCheckBox2.Checked == true && metroCheckBox4.Checked == true)
            {
                if (metroCheckBox3.Checked == true)
                {
                    get_geometry();
                }
                else
                {
                    get_geometry(islandwide:false, destrict: cmb_destricts.Text);

                }
            }

        }
        //https://maps.googleapis.com/maps/api/staticmap?center=Srilanka&zoom=8&size=1500x800&markers=color:red%7Clabel:S%7C6.927079,79.861244&markers=size:tiny%7Ccolor:green%7CNIBM+Colombo&markers=size:mid%7Ccolor:0xFFFF00%7Clabel:C%7CTok,AK%22&key=AIzaSyBK7FISIQh5FRHjbh4XOyAJ1otcBy_6ors
        //markers=color:red%7Clabel:S%7C6.927079,79.861244
        public void get_geometry(string destrict=null,bool islandwide=true,string batchno=null,DateTime? from=null,DateTime? to=null)
        {
            if (batchno != null)
            {
                if (islandwide == true)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT address_R FROM Stud_details WHERE batch_no='" + batchno + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<string> latitudes = new List<string>();
                    List<string> longitudes = new List<string>();
                    //int count = 0;
                    while (dr.Read())
                    {
                        //string[] x = G_maps.get_place_details_from_place_id(G_maps.get_place_id_from_place_name_2(dr.GetValue(0).ToString()));
                        latitudes.Add(d.singleString("SELECT Latitude FROM Place_Details WHERE place_id='"+dr.GetValue(0).ToString()+"'"));
                        longitudes.Add(d.singleString("SELECT Longitude FROM Place_Details WHERE place_id='" + dr.GetValue(0).ToString() + "'"));

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
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT address_R FROM Stud_details WHERE batch_no='" + batchno + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<string> latitudes = new List<string>();
                    List<string> longitudes = new List<string>();
                    int count = 0;
                    while (dr.Read())
                    {
                        latitudes.Add(d.singleString("SELECT Latitude FROM Place_Details WHERE place_id='" + dr.GetValue(0).ToString() + "'"));
                        longitudes.Add(d.singleString("SELECT Longitude FROM Place_Details WHERE place_id='" + dr.GetValue(0).ToString() + "'"));

                    }

                    string[] lats = latitudes.ToArray();
                    string[] longs = longitudes.ToArray();
                    string a = null;
                    for (int c = 0; c < lats.Length; c++)
                    {
                        a = a + "markers=colour:blue%7Clabel:S%7C" + lats[c] + "," + longs[c] + "&";
                    }
                    //MessageBox.Show(a);
                    string url = "https://maps.googleapis.com/maps/api/staticmap?center=" + destrict + "&zoom=11&size=1500x800&maptype=roadmap&" + a + "key=AIzaSyBK7FISIQh5FRHjbh4XOyAJ1otcBy_6ors";
                    Process.Start("chrome.exe", url);
                    //center=Colombo&zoom=10&
                    con.Close();
                }
            }
            else if (from != null && batchno==null)
            {
                if (islandwide == true)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT s.address_R FROM Stud_details s INNER JOIN Course_details_master c ON s.course_no=c.course_no INNER JOIN Batches b ON s.batch_no=b.Batch_no WHERE c.course_type='" + metroComboBox1.Text + "' AND  CAST(b.start_date AS DATE) BETWEEN '" + metroDateTime3.Value + "' AND '" + metroDateTime4.Value + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<string> latitudes = new List<string>();
                    List<string> longitudes = new List<string>();
                    int count = 0;
                    while (dr.Read())
                    {
                        latitudes.Add(d.singleString("SELECT Latitude FROM Place_Details WHERE place_id='" + dr.GetValue(0).ToString() + "'"));
                        longitudes.Add(d.singleString("SELECT Longitude FROM Place_Details WHERE place_id='" + dr.GetValue(0).ToString() + "'"));

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
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT s.address_R FROM Stud_details s INNER JOIN Course_details_master c ON s.course_no=c.course_no INNER JOIN Batches b ON s.batch_no=b.Batch_no WHERE c.course_type='" + metroComboBox1.Text + "' AND  CAST(b.start_date AS DATE) BETWEEN '" + metroDateTime3.Value + "' AND '" + metroDateTime4.Value + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<string> latitudes = new List<string>();
                    List<string> longitudes = new List<string>();
                    int count = 0;
                    while (dr.Read())
                    {
                        latitudes.Add(d.singleString("SELECT Latitude FROM Place_Details WHERE place_id='" + dr.GetValue(0).ToString() + "'"));
                        longitudes.Add(d.singleString("SELECT Longitude FROM Place_Details WHERE place_id='" + dr.GetValue(0).ToString() + "'"));

                    }

                    string[] lats = latitudes.ToArray();
                    string[] longs = longitudes.ToArray();
                    string a = null;
                    for (int c = 0; c < lats.Length; c++)
                    {
                        a = a + "markers=colour:blue%7Clabel:S%7C" + lats[c] + "," + longs[c] + "&";
                    }
                    //MessageBox.Show(a);
                    string url = "https://maps.googleapis.com/maps/api/staticmap?center=" + destrict + "&zoom=11&size=1500x800&maptype=roadmap&" + a + "key=AIzaSyBK7FISIQh5FRHjbh4XOyAJ1otcBy_6ors";
                    Process.Start("chrome.exe", url);
                    //center=Colombo&zoom=10&
                    con.Close();
                }
            }
            else
            {

                if (islandwide == true)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT s.address_R FROM Stud_details s INNER JOIN Course_details_master c ON s.course_no=c.course_no WHERE c.course_type='"+metroComboBox1.Text+"' ", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<string> latitudes = new List<string>();
                    List<string> longitudes = new List<string>();
                    int count = 0;
                    while (dr.Read())
                    {
                        latitudes.Add(d.singleString("SELECT Latitude FROM Place_Details WHERE place_id='" + dr.GetValue(0).ToString() + "'"));
                        longitudes.Add(d.singleString("SELECT Longitude FROM Place_Details WHERE place_id='" + dr.GetValue(0).ToString() + "'"));

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
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT s.address_R FROM Stud_details s INNER JOIN Course_details_master c ON s.course_no=c.course_no WHERE c.course_type='" + metroComboBox1.Text + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<string> latitudes = new List<string>();
                    List<string> longitudes = new List<string>();
                    int count = 0;
                    while (dr.Read())
                    {
                        latitudes.Add(d.singleString("SELECT Latitude FROM Place_Details WHERE place_id='" + dr.GetValue(0).ToString() + "'"));
                        longitudes.Add(d.singleString("SELECT Longitude FROM Place_Details WHERE place_id='" + dr.GetValue(0).ToString() + "'"));

                    }

                    string[] lats = latitudes.ToArray();
                    string[] longs = longitudes.ToArray();
                    string a = null;
                    for (int c = 0; c < lats.Length; c++)
                    {
                        a = a + "markers=colour:blue%7Clabel:S%7C" + lats[c] + "," + longs[c] + "&";
                    }
                    //MessageBox.Show(a);
                    string url = "https://maps.googleapis.com/maps/api/staticmap?center=" + destrict + "&zoom=11&size=1500x800&maptype=roadmap&" + a + "key=AIzaSyBK7FISIQh5FRHjbh4XOyAJ1otcBy_6ors";
                    Process.Start("chrome.exe", url);
                    //center=Colombo&zoom=10&
                    con.Close();
                }
            }
        }
        private void participation_by_designation(string batchno = null, string ctype = null, DateTime? dat1 = null, DateTime? dat2 = null)
        {
            
            if (batchno != null)
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT designation,COUNT(*) AS Number_of_participants FROM Stud_details  WHERE batch_no='" + batchno + "' GROUP BY designation", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Program_company_participation_report c = new Program_company_participation_report();
                c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Participation_report_by_organization_batch.xsl", "Participation by Designation for " + General_methods.get_batch_no_from_batch_name(cmb_batch.Text) + " - " + "(" + cmb_batch.Text + ")", "", "", 0, "diploma", General_methods.get_course_no_of_batch_from_batch_no(batchno));
                con.Close();
            }
            else
            {
                if (dat1 != null && dat2 != null)
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT s.designation,COUNT(*) AS Number_of_participants FROM Stud_details s INNER JOIN Batches b ON s.batch_no=b.Batch_no INNER JOIN Course_details_master c ON s.course_no=c.course_no  WHERE (CAST(b.start_date AS DATE) BETWEEN '"+dat1+"' AND '"+dat2+"') AND c.course_type='"+metroComboBox1.Text+"' GROUP BY designation", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Program_company_participation_report c = new Program_company_participation_report();
                    c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Participation_report_by_organization_batch.xsl", "Participation by Designation for All batches started from -" + dat1.Value.ToShortDateString() + " To- " + dat2.Value.ToShortDateString(), "", "",d.singleInt("SELECT COUNT(*) FROM Stud_details WHERE organization_id = 'Individual Participant'"), "diploma-all batches");
                    con.Close();
                }
                else
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT s.designation,COUNT(*) AS Number_of_participants FROM Stud_details s INNER JOIN Batches b ON s.batch_no=b.Batch_no INNER JOIN Course_details_master c ON s.course_no=c.course_no  WHERE  c.course_type='" + metroComboBox1.Text + "' GROUP BY designation", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Program_company_participation_report c = new Program_company_participation_report();
                    c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Participation_report_by_organization_batch.xsl", "Participation by Designation for All batches started " ,"", "", d.singleInt("SELECT COUNT(*) FROM Stud_details WHERE organization_id = 'Individual Participant'"), "diploma-all batches");
                    con.Close();
                }
            }
        }
        private void metroTile6_Click(object sender, EventArgs e)
        {

            if (metroCheckBox2.Checked == false)
            {
                participation_by_designation(General_methods.get_batch_no_from_batch_name(cmb_batch.Text));
            }

            else if (metroCheckBox2.Checked == true && metroCheckBox4.Checked == false)
            {
                participation_by_designation(ctype:metroComboBox1.Text,dat1:metroDateTime3.Value,dat2:metroDateTime4.Value);
            }
            else if (metroCheckBox2.Checked == true && metroCheckBox4.Checked == true)
            {
                participation_by_designation(ctype:metroComboBox1.Text);

            }
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("EXEC Student_module_selection_for_batch @batchno='"+General_methods.get_batch_no_from_batch_name(cmb_batch.Text)+"'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Participation_by_destrict_report c = new Participation_by_destrict_report();
            c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Module_selection_report.xsl", "Students module selection report for " + General_methods.get_batch_no_from_batch_name(cmb_batch.Text) + " - " + "(" + cmb_batch.Text + ")"," ", " ",0,"diploma",General_methods.get_course_no_of_batch_from_batch_no(General_methods.get_batch_no_from_batch_name(cmb_batch.Text)));
            con.Close();
        }
        private void participation_by_age(string batchno=null,string ctype = null, DateTime? dat1 = null, DateTime? dat2 = null)
        {
           
            if (batchno != null)
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("EXEC Age_report_of_batch @batchno='" + batchno + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Participation_by_destrict_report c = new Participation_by_destrict_report();
                c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Participation_by_age_report_batch.xsl", "Participation by age for " + batchno + " - " + "(" + cmb_batch.Text + ")", "", "", 0, "diploma", General_methods.get_course_no_of_batch_from_batch_no(batchno));
                con.Close();
            }
            else
            {
                if (dat1 != null && dat2 != null)
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("EXEC Age_report_of_batch  @type='"+metroComboBox1.Text+"' ,@fromdate='"+metroDateTime3.Value+"', @todate='"+metroDateTime4.Value+"'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Participation_by_destrict_report c = new Participation_by_destrict_report();
                    c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Participation_by_age_report_batch.xsl", "Participation by age for all batches from -" + dat1.Value.ToShortDateString() + " From " +dat2.Value.ToShortDateString() , "", "", 0, "all", "");
                    con.Close();
                }
                else
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("EXEC Age_report_of_batch  @type='"+metroComboBox1.Text+"' ", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Participation_by_destrict_report c = new Participation_by_destrict_report();
                    c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Participation_by_age_report_batch.xsl", "Participation by age for all batches ", "", "", 0, "all", "");
                    con.Close();
                }
            }
        }
        private void metroTile4_Click(object sender, EventArgs e)
        {
            if (metroCheckBox2.Checked == false)
            {
                participation_by_age(General_methods.get_batch_no_from_batch_name(cmb_batch.Text));
            }

            else if (metroCheckBox2.Checked == true && metroCheckBox4.Checked == false)
            {
                participation_by_age(ctype:metroComboBox1.Text,dat1:metroDateTime3.Value,dat2:metroDateTime4.Value);
            }
            else if (metroCheckBox2.Checked == true && metroCheckBox4.Checked == true)
            {
                participation_by_age(ctype:metroComboBox1.Text);

            }
        }

        private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox3.Checked == true)
            {
                cmb_destricts.DataSource = null;
                cmb_destricts.Text = "";
                cmb_destricts.Enabled = false;
            }
            else
            {
                cmb_destricts.DataSource = General_methods.fill_districts_combobox();
                cmb_destricts.Items.Remove("");
                cmb_destricts.Enabled = true;
            }
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroCheckBox2.Checked == true)
            {

            }
            else
            {
                if (metroComboBox1.SelectedIndex == 0)
                {
                    cmb_batch.DataSource = General_methods.fill_batches_combobox("Diploma");
                    metroTile7.Enabled = true;
                }
                else
                {
                    cmb_batch.DataSource = General_methods.fill_batches_combobox("Certificate");
                    metroTile7.Enabled = false;

                }
            }
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox2.Checked == true)
            {
                metroTile12.Enabled = true;
                metroPanel3.Enabled = true;
                lbl_batchno.Text = "All batches";
                cmb_batch.DataSource = null;
                cmb_batch.Text = "";
                cmb_batch.Enabled = false;
                metroTile10.Enabled = false;
                metroTile11.Enabled = false;
                metroTile7.Enabled = false;
                tile2.Enabled = true;
                metroTile23.Enabled = false;
                metroTile14.Enabled = true;
                metroTile13.Enabled = false;
            }
            else
            {
                metroTile12.Enabled = false;
                metroPanel3.Enabled = false;
                lbl_batchno.Text = "";
                cmb_batch.DataSource = General_methods.fill_batches_combobox(metroComboBox1.Text);
                cmb_batch.Enabled = true;
                metroCheckBox4.Checked = false;
                metroTile10.Enabled = true;
                metroTile11.Enabled = true;
                metroTile7.Enabled = true;
                tile2.Enabled = false;
                metroTile23.Enabled = true;
                metroTile14.Enabled = false;
                metroTile13.Enabled = true;

            }
        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void metroCheckBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroCheckBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroCheckBox4_CheckedChanged_1(object sender, EventArgs e)
        {
            if (metroCheckBox4.Checked == true)
            {
                metroDateTime3.Enabled = false;
                metroDateTime4.Enabled = false;
            }
            else
            {
                metroDateTime3.Enabled = true;
                metroDateTime4.Enabled = true;
            }
        }

        private void metroTile10_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("EXEC Income_report_of_dip_batch @batchno='" + General_methods.get_batch_no_from_batch_name(cmb_batch.Text) + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Program_budget_report obj = new Program_budget_report();
            obj.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\BudgetreportDipBatch.xsl", "Income Report for " + General_methods.get_batch_no_from_batch_name(cmb_batch.Text)+"("+cmb_batch.Text+")","","");
            con.Close();
        }

        private void metroTile11_Click(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked == false)
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT p.Payment_No,p.Gross_amount,p.Discount_percent,p.Net_amount,p.Date,p.Time,p.stud_no_org_no AS Student_no,s.name_with_initials AS student_name,p.Remark FROM PaymentDetails p INNER JOIN Stud_details s ON p.stud_no_org_no=s.stud_no WHERE s.batch_no='" + General_methods.get_batch_no_from_batch_name(cmb_batch.Text) + "' AND (p.Date BETWEEN '"+metroDateTime1.Value+"' AND '"+metroDateTime2.Value+"')  ORDER BY p.Date", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Participation_by_destrict_report c = new Participation_by_destrict_report();
                c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Payement_report_dip_batch.xsl", "Payment Report For " + General_methods.get_batch_no_from_batch_name(cmb_batch.Text) + " - " + "(" + cmb_batch.Text + ")", " ", " ", 0, "diploma", General_methods.get_course_no_of_batch_from_batch_no(General_methods.get_batch_no_from_batch_name(cmb_batch.Text)), true);
                con.Close();
            }
            else
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT p.Payment_No,p.Gross_amount,p.Discount_percent,p.Net_amount,p.Date,p.Time,p.stud_no_org_no AS Student_no,s.name_with_initials AS student_name,p.Remark FROM PaymentDetails p INNER JOIN Stud_details s ON p.stud_no_org_no=s.stud_no WHERE s.batch_no='" + General_methods.get_batch_no_from_batch_name(cmb_batch.Text) + "' ORDER BY p.Date", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Participation_by_destrict_report c = new Participation_by_destrict_report();
                c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Payement_report_dip_batch.xsl", "Payment Report For " + General_methods.get_batch_no_from_batch_name(cmb_batch.Text) + " - " + "(" + cmb_batch.Text + ")", " ", " ", 0, "diploma", General_methods.get_course_no_of_batch_from_batch_no(General_methods.get_batch_no_from_batch_name(cmb_batch.Text)), true);
                con.Close();
            }
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked == true)
            {
                metroDateTime1.Enabled = false;
                metroDateTime2.Enabled = false;
            }
            else
            {
                metroDateTime1.Enabled = true;
                metroDateTime2.Enabled = true;
            }
        }

        private void metroTile12_Click(object sender, EventArgs e)
        {
            if (metroCheckBox4.Checked == true)
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("Income_report_for_all_batches @type='" + metroComboBox1.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Program_budget_report obj = new Program_budget_report();
                obj.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\BudgetreportDipBatch.xsl", "Income Report for All batches", "", "");
                con.Close();
            }
            else
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("Income_report_for_all_batches @type='" + metroComboBox1.Text + "',@fromdate='"+metroDateTime3.Value+"',@todate='"+metroDateTime4.Value+"'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Program_budget_report obj = new Program_budget_report();
                obj.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\BudgetreportDipBatch.xsl", "Income Report for All batches", "", "");
                con.Close();
            }
        }

        private void tile2_Click(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked == false)
            {
                if (metroCheckBox4.Checked == true)
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT p.Payment_No,p.Gross_amount,p.Discount_percent,p.Net_amount,p.Date,p.Time,p.stud_no_org_no AS Student_no,s.name_with_initials AS student_name,p.Remark FROM PaymentDetails p INNER JOIN Stud_details s ON p.stud_no_org_no=s.stud_no INNER JOIN Course_details_master c ON s.course_no=c.course_no WHERE c.course_type='"+metroComboBox1.Text+"' AND (p.Date BETWEEN '" + metroDateTime1.Value + "' AND '" + metroDateTime2.Value + "')  ORDER BY p.Date", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Participation_by_destrict_report c = new Participation_by_destrict_report();
                    c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Payement_report_dip_batch.xsl", "Payment Report For All batches- payments from- "+metroDateTime1.Value.ToShortDateString()+"-To-"+metroDateTime2.Value.ToShortDateString(), " ", " ", 0, "all", "", true);
                    con.Close();
                }
                else
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT p.Payment_No,p.Gross_amount,p.Discount_percent,p.Net_amount,p.Date,p.Time,p.stud_no_org_no AS Student_no,s.name_with_initials AS student_name,p.Remark FROM PaymentDetails p INNER JOIN Stud_details s ON p.stud_no_org_no=s.stud_no INNER JOIN Batches b ON b.Batch_no=s.batch_no INNER JOIN Course_details_master c ON s.course_no=c.course_no WHERE (CAST(b.start_date AS DATE) BETWEEN '"+metroDateTime3.Value+"' AND '"+metroDateTime4.Value+"') AND(c.course_type='"+metroComboBox1.Text+"') AND (p.Date BETWEEN '" + metroDateTime1.Value + "' AND '" + metroDateTime2.Value + "')  ORDER BY p.Date", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Participation_by_destrict_report c = new Participation_by_destrict_report();
                    c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Payement_report_dip_batch.xsl", "Payment Report For All batches for payements from "+metroDateTime1.Value.ToShortDateString()+"To"+metroDateTime2.Value.ToShortDateString()+"-Batches started From-"+metroDateTime3.Value.ToShortDateString()+" To-"+metroDateTime4.Value.ToShortDateString(), " ", " ", 0, "all","", true);
                    con.Close();
                }
            }
            else
            {
                if (metroCheckBox4.Checked == false)
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT p.Payment_No,p.Gross_amount,p.Discount_percent,p.Net_amount,p.Date,p.Time,p.stud_no_org_no AS Student_no,s.name_with_initials AS student_name,p.Remark FROM PaymentDetails p INNER JOIN Stud_details s ON p.stud_no_org_no=s.stud_no INNER JOIN Batches b ON s.batch_no=b.Batch_no INNER JOIN Course_details_master c ON s.course_no=c.course_no WHERE ( CAST(b.start_date AS DATE) BETWEEN '" + metroDateTime3.Value + "' AND '" + metroDateTime4.Value + "') AND c.course_type='" + metroComboBox1.Text + "' ORDER BY p.Date", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Participation_by_destrict_report c = new Participation_by_destrict_report();
                    c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Payement_report_dip_batch.xsl", "Payment Report For batches started from-"+metroDateTime3.Value.ToShortDateString()+"-To-"+metroDateTime4.Value.ToShortDateString()+"(Payements from start of batch)" , " ", " ", 0, "all","" ,true);
                    con.Close();
                }
                else
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT p.Payment_No,p.Gross_amount,p.Discount_percent,p.Net_amount,p.Date,p.Time,p.stud_no_org_no AS Student_no,s.name_with_initials AS student_name,p.Remark FROM PaymentDetails p INNER JOIN Stud_details s ON p.stud_no_org_no=s.stud_no  INNER JOIN Course_details_master c ON s.course_no=c.course_no WHERE c.course_type='" + metroComboBox1.Text + "' ORDER BY p.Date", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Participation_by_destrict_report c = new Participation_by_destrict_report();
                    c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Payement_report_dip_batch.xsl", "Payment Report For all batches From start of batch ", " ", " ", 0, "all", "", true);
                    con.Close();
                }
            }
        }

        private void metroTile15_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Budget_report_of_all_programs  @from='"+metroDateTime5.Value+"',@to='"+metroDateTime6.Value+"',@progtype='"+type_of_program()+"' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Program_budget_report obj = new Program_budget_report();
            obj.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Budgetreport.xsl", "Budget Report for all " + type_of_program() + " programs" + " from- " + metroDateTime5.Value.ToShortDateString()+" to- "+metroDateTime6.Value.ToShortDateString(), type_of_program(), "");
            con.Close();
        }

        private void metroTile20_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT p.ref_no,p.program_code,p.NIC,a.Program_title,o.Organization_name,p.Name,p.designation,p.phone_no,p.Email,p.address  FROM Short_program_participation p INNER JOIN Session_details s ON p.program_code=s.program_no INNER JOIN Short_program_details a ON a.Code=s.program_no INNER JOIN Company_details o ON o.Organization_id=p.Organization_id WHERE s.course_type='"+type_of_program()+"' AND (s.scheduled_date BETWEEN '" + metroDateTime5.Value+"' AND '"+metroDateTime6.Value+"')  ORDER BY p.program_code,o.Organization_name,p.designation ", con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT p.ref_no,p.program_code,p.NIC,a.Program_title,p.Name,p.designation,p.phone_no,p.Email,p.address  FROM Short_program_participation p INNER JOIN Session_details s ON p.program_code=s.program_no INNER JOIN Short_program_details a ON a.Code=s.program_no WHERE(s.scheduled_date BETWEEN '"+metroDateTime5.Value+"' AND '"+metroDateTime6.Value+"') AND p.Organization_id='Individual' ORDER BY p.program_code,p.designation ", con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            Program_participation_general_report p = new Program_participation_general_report();
            p.WriteDataTableToExcel(dt1, dt2, "Worksheet1", @"C:\\ParticipationreportDiploma.xsl", "Participation Report for all "+ type_of_program()+" programs" + " from -" +metroDateTime5.Value.ToShortDateString()+" to-"+metroDateTime6.Value.ToShortDateString() , type_of_program(), "");
            con.Close();
            MessageBox.Show(type_of_program());
        }

        private void metroTile19_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT c.Organization_name,COUNT(*) AS No_of_participants FROM Short_program_participation p INNER JOIN Company_details c ON p.Organization_id=c.Organization_id INNER JOIN Session_details s ON s.program_no=p.program_code WHERE s.course_type='"+type_of_program()+"' AND s.scheduled_date BETWEEN '" + metroDateTime5.Value+"' AND '"+metroDateTime6.Value+"' GROUP BY c.Organization_name ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Program_company_participation_report c = new Program_company_participation_report();
            c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Participation_report_by_organization_batch.xsl", "Participation by Organization for all " + type_of_program() + " programs" + " programs from -" + metroDateTime5.Value.ToShortDateString()+" to-"+metroDateTime6.Value.ToShortDateString(), type_of_program(), "",d.singleInt("SELECT COUNT(*) FROM Short_program_participation p INNER JOIN Session_details s ON s.program_no=p.program_code WHERE p.Organization_id='Individual' AND s.scheduled_date BETWEEN '"+metroDateTime5.Value+"' AND '"+metroDateTime6.Value+"'"));
            con.Close();
        }

        private void metroTile18_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("EXEC Age_report_for_all_Program @from='"+metroDateTime5.Value+"' ,@to ='"+metroDateTime6.Value+ "', @progtype='"+type_of_program()+"'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Participation_by_destrict_report c = new Participation_by_destrict_report();
            c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Participation_by_age_report_batch.xsl", "Participation by age for all " + type_of_program() + " programs" + " from- " + metroDateTime5.Value.ToShortDateString()+ "To- "+metroDateTime6.Value.ToShortDateString() , type_of_program(), "", 0);
            con.Close();
        }

        private void metroTile17_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT p.designation,COUNT(*) AS No_of_participants FROM Short_program_participation p INNER JOIN Session_details s ON p.program_code=s.program_no WHERE s.course_type='" + type_of_program() + "' AND (s.scheduled_date BETWEEN '" + metroDateTime5.Value+"' AND '"+metroDateTime6.Value+"') GROUP BY p.designation", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Program_company_participation_report c = new Program_company_participation_report();
            c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Participation_report_by_organization_batch.xsl", "Participation by Designation for all " + type_of_program() + " programs" + " from-" + metroDateTime5.Value.ToShortDateString()+" To-"+metroDateTime6.Value.ToShortDateString(), "", type_of_program(), 0,type2:"designation");
            con.Close();
        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
            if (metroCheckBox5.Checked==true)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Google_place_id FROM Session_details WHERE course_type='"+type_of_program()+"' AND scheduled_date BETWEEN '"+metroDateTime5.Value+"' AND '"+metroDateTime6.Value+"'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                List<string> latitudes = new List<string>();
                List<string> longitudes = new List<string>();
                //int count = 0;
                while (dr.Read())
                {                   
                     latitudes.Add(d.singleString("SELECT Latitude FROM Place_Details WHERE place_id='"+dr.GetValue(0)+"' "));
                     longitudes.Add(d.singleString("SELECT Longitude FROM Place_Details WHERE place_id='" + dr.GetValue(0) + "' "));  
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
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Google_place_id FROM Session_details WHERE course_type='" + type_of_program() + "' AND scheduled_date BETWEEN '" + metroDateTime5.Value + "' AND '" + metroDateTime6.Value + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                List<string> latitudes = new List<string>();
                List<string> longitudes = new List<string>();
                //int count = 0;
                while (dr.Read())
                {
                    //string[] x = G_maps.get_place_details_from_place_id(G_maps.get_place_id_from_place_name_2("National Institute of Labour Studies, Battaramulla - Pannipitiya Road, Colombo, Sri Lanka"));
                    latitudes.Add(d.singleString("SELECT Latitude FROM Place_Details WHERE place_id='" + dr.GetValue(0) + "' "));
                    longitudes.Add(d.singleString("SELECT Longitude FROM Place_Details WHERE place_id='" + dr.GetValue(0) + "' "));
                }

                string[] lats = latitudes.ToArray();
                string[] longs = longitudes.ToArray();
                string a = null;
                for (int c = 0; c < lats.Length; c++)
                {
                    a = a + "markers=colour:blue%7Clabel:S%7C" + lats[c] + "," + longs[c] + "&";
                }
                //MessageBox.Show(a);
                string url = "https://maps.googleapis.com/maps/api/staticmap?center=" + cmb_locations.Text + "&zoom=11&size=1500x800&maptype=roadmap&" + a + "key=AIzaSyBK7FISIQh5FRHjbh4XOyAJ1otcBy_6ors";
                Process.Start("chrome.exe", url);
                //center=Colombo&zoom=10&
                con.Close();
            }
        }
        private string type_of_program()
        {
            string h="";
            foreach (Control c in groupBox10.Controls)
            {
                if (c is MetroFramework.Controls.MetroRadioButton)
                {
                    RadioButton rbn = (RadioButton)c;
                    if (rbn.Checked == true)
                    {
                        h= rbn.Text;
                    }
                }
            }
            return h;
        }
        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (metroCheckBox5.Checked == true)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT address FROM Short_program_participation p INNER JOIN Session_details s ON p.program_code=s.program_no WHERE s.course_type='" + type_of_program() + "' AND s.scheduled_date BETWEEN '" + metroDateTime5.Value+"' AND '"+metroDateTime6.Value+"'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                List<string> latitudes = new List<string>();
                List<string> longitudes = new List<string>();
                List<string> exists = new List<string>();
                //int count = 0;
                while (dr.Read())
                {

                    if (exists.Contains(dr.GetValue(0).ToString()))
                    {

                    }
                    else
                    {
                        string[] x = G_maps.get_place_details_from_place_id(G_maps.get_place_id_from_place_name_2(dr.GetValue(0).ToString() + ", Sri Lanka"));
                        latitudes.Add(x[3]);
                        longitudes.Add(x[4]);
                        exists.Add(dr.GetValue(0).ToString());
                    }

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
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT address FROM Short_program_participation p INNER JOIN Session_details s ON p.program_code=s.program_no WHERE s.scheduled_date BETWEEN '" + metroDateTime5.Value + "' AND '" + metroDateTime6.Value + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                List<string> latitudes = new List<string>();
                List<string> longitudes = new List<string>();
                List<string> exists = new List<string>();

                //int count = 0;
                while (dr.Read())
                {
                    if (exists.Contains(dr.GetValue(0).ToString()))
                    {

                    }
                    else
                    {
                        string[] x = G_maps.get_place_details_from_place_id(G_maps.get_place_id_from_place_name_2(dr.GetValue(0).ToString() + ", Sri Lanka"));
                        latitudes.Add(x[3]);
                        longitudes.Add(x[4]);
                    }
                }

                string[] lats = latitudes.ToArray();
                string[] longs = longitudes.ToArray();
                string a = null;
                for (int c = 0; c < lats.Length; c++)
                {
                    a = a + "markers=colour:blue%7Clabel:S%7C" + lats[c] + "," + longs[c] + "&";
                }
                //MessageBox.Show(a);
                string url = "https://maps.googleapis.com/maps/api/staticmap?center=" + cmb_locations.Text + "&zoom=11&size=1500x800&maptype=roadmap&" + a + "key=AIzaSyBK7FISIQh5FRHjbh4XOyAJ1otcBy_6ors";
                Process.Start("chrome.exe", url);
                //center=Colombo&zoom=10&
                con.Close();
            }
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void metroCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox5.Checked == true)
            {
                cmb_locations.Enabled = false;
                cmb_locations.Text = "";
            }
            else
            {
                cmb_locations.Enabled = true;
                cmb_locations.Text = "";
            }
        }

        private void metroTile22_Click(object sender, EventArgs e)
        {
            con.Open();
            DataTable dt3 = new DataTable();
            dt3 = d.show("SELECT p.Payment_No,c.Organization_name,p.Gross_amount,p.Discount_percent,p.Net_amount,p.Date,p.Time FROM PaymentDetails p INNER JOIN Company_details c ON p.stud_no_org_no=c.Organization_id INNER JOIN Session_details s ON p.program_no=s.program_no WHERE s.course_type='"+ type_of_program() + "' AND s.scheduled_date BETWEEN '" + metroDateTime5.Value + "' AND '" + metroDateTime6.Value + "'  ORDER BY c.Organization_name");
            DataTable dt4 = new DataTable();
            dt4 = d.show("SELECT p.Payment_No,s.Name,p.Gross_amount,p.Discount_percent,p.Net_amount,p.Date,p.Time FROM PaymentDetails p INNER JOIN Short_program_participation s ON s.ref_no=p.stud_no_org_no INNER JOIN Session_details d ON d.program_no=p.program_no WHERE d.course_type='"+ type_of_program() + "' AND  d.scheduled_date BETWEEN '" + metroDateTime5.Value + "' AND '" + metroDateTime6.Value + "' ORDER BY s.Name");
            Program_payments_report p = new Program_payments_report();
            p.WriteDataTableToExcel(dt3, dt4, "Worksheet1", @"C:\\Payment_report_for_program.xsl", "Payements Report for all " + type_of_program() + " programs" + " from- " + metroDateTime5.Value + " To-" + metroDateTime6.Value, type_of_program(), "", "");
            con.Close();
        }

        private void metroTile16_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("EXEC Income_report_of_all_program @from='"+metroDateTime5.Value+"', @to='"+metroDateTime6.Value+"', @progtype='"+ type_of_program()+ "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt3 = new DataTable();
            dt3 = ds.Tables[0];
            DataTable dt4 = new DataTable();
            dt4 = ds.Tables[1];
            Program_payments_report p = new Program_payments_report();
            p.WriteDataTableToExcel(dt3, dt4, "Worksheet1", @"C:\\Payment_report_for_program.xsl", "Income Report for all " + type_of_program() + " programs" + " from-" + metroDateTime5.Value.ToShortDateString()+" To-"+metroDateTime6.Value.ToShortDateString(), type_of_program(), "", "");
            con.Close();
        }

        private void metroTile23_Click(object sender, EventArgs e)
        {      
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("EXEC Session_Details_report @batchno='" + General_methods.get_batch_no_from_batch_name(cmb_batch.Text) + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Program_company_participation_report c = new Program_company_participation_report();
            c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Participation_report_by_organization_batch.xsl", "Session details report for -" + General_methods.get_batch_no_from_batch_name(cmb_batch.Text) + " - " + "(" + cmb_batch.Text + ")", "", "", 0, "diploma", General_methods.get_course_no_of_batch_from_batch_no(General_methods.get_batch_no_from_batch_name(cmb_batch.Text)),type2:"wef");
            con.Close();
        }

        private void metroTile13_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("EXEC Lecturer_usage_for_batch @batchno='" + General_methods.get_batch_no_from_batch_name(cmb_batch.Text) + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Program_company_participation_report c = new Program_company_participation_report();
            c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Participation_report_by_organization_batch.xsl", "Resource person usage report for -" + General_methods.get_batch_no_from_batch_name(cmb_batch.Text) + " - " + "(" + cmb_batch.Text + ")", "", "", 0, "diploma", General_methods.get_course_no_of_batch_from_batch_no(General_methods.get_batch_no_from_batch_name(cmb_batch.Text)), type2: "wef");
            con.Close();
        }

        private void metroTile14_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("EXEC Lecturer_usage_for_all_batches ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Program_company_participation_report c = new Program_company_participation_report();
            c.WriteDataTableToExcel(dt, "Worksheet1", @"C:\\Participation_report_by_organization_batch.xsl", "Resource person usage report for all Batches " , "", "", 0, "diploma-all batches", "", type2: "wef");
            con.Close();
        }

        private void metroPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroTile21_Click(object sender, EventArgs e)
        {

        }
    }
}
