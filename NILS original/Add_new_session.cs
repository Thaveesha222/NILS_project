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
    public partial class Add_new_session : MetroFramework.Forms.MetroForm
    {
        List<string> names;
        public Add_new_session()
        {
            names = General_methods.fill_Resource_persons_combobox();
            InitializeComponent();
            cmb_date.Format = DateTimePickerFormat.Custom;
            metroDateTime1.Format = DateTimePickerFormat.Custom;
            cmb_date.CustomFormat = "dd-MM-yyyy";
            metroDateTime1.CustomFormat = "dd-MM-yyyy";
            cmb_rp2.Items.Add("None");
            cmb_rp2.Text = "None";
            cmb_rp3.Items.Add("None");
            cmb_rp3.Text = "None";
            cmb_rp_2.Items.Add("None");
            cmb_rp_2.Text = "None";
            cmb_rp_3.Items.Add("None");
            cmb_rp_3.Text = "None";

        }
        SqlConnection con = new SqlConnection(Credentials.connection);
        private void Add_new_session_Load(object sender, EventArgs e)
        {
   
            time_picker.Format = DateTimePickerFormat.Time;
            time_picker.ShowUpDown = true;
            TimePicker1.Format = DateTimePickerFormat.Time;
            TimePicker1.ShowUpDown = true;
            chk_inhouse.Checked = true;
            chk_inhouse_1.Checked = true;
            cmb_batch.DataSource = General_methods.fill_batches_combobox("All");
            //cmb_rp1.DataSource = General_methods.fill_lecturer_names_combobox();
            //cmb_rp_1.DataSource = General_methods.fill_lecturer_names_combobox();
            set_date();
            set_date_2();
        }
        DateTime[] dates2;
        DateTime[] dates3;

        private void set_date()
        {
            
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT scheduled_date FROM Session_details WHERE Batch_no !='None'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            List<DateTime> dates = new List<DateTime>();
            while (dr.Read())
            {
                dates.Add(dr.GetDateTime(0));
            }
            monthCalendar1.BoldedDates = dates.ToArray();
            dates2 = dates.ToArray();
            con.Close();
            metroGrid1.DataSource = null;
            metroGrid1.Columns.Clear();
        }
        private void set_date_2()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT scheduled_date FROM Session_details WHERE Batch_no ='None'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            List<DateTime> dates = new List<DateTime>();
            while (dr.Read())
            {
                dates.Add(dr.GetDateTime(0));
            }
            monthCalendar2.BoldedDates = dates.ToArray();
            dates3 = dates.ToArray();
            con.Close();
            metroGrid2.DataSource = null;
            metroGrid2.Columns.Clear();
        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void chk_inhouse_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_inhouse.Checked == true)
            {
                cmb_venue.DataSource = null;
                cmb_venue.Enabled = false;
                cmb_venue.Items.Add("NILS");
                cmb_venue.Text = "NILS";
            }
            else
            {
                cmb_venue.Enabled = true;
                cmb_venue.Items.Remove( "NILS");

            }
        }
        Database d = new Database();
        private void cmb_batch_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_corseno.Text=General_methods.get_course_no_of_batch_from_batch_no(General_methods.get_batch_no_from_batch_name(cmb_batch.Text));
            lbl_course_name.Text = General_methods.get_course_name_from_course_no(lbl_corseno.Text);
            lbl_no_studsinbatch.Text=d.singleString("SELECT COUNT(*) FROM Stud_details WHERE batch_no = '"+ General_methods.get_batch_no_from_batch_name(cmb_batch.Text) +"'");
            if (General_methods.get_course_type_from_course_no(General_methods.get_course_no_of_batch_from_batch_no(General_methods.get_batch_no_from_batch_name(cmb_batch.Text))) == "Diploma")
            {
                cmb_module.Items.Remove("no modules");
                cmb_module.Enabled = true;
                cmb_module.DataSource = General_methods.fill_module_combobox(lbl_corseno.Text);
            }
            else
            {
                cmb_module.DataSource = null;
                cmb_module.Enabled = false;
                cmb_module.Items.Add("no modules");
                cmb_module.Text = "no modules";
            }
        }

        private void cmb_venue_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmb_venue_TextChanged(object sender, EventArgs e)
        {
            if (cmb_venue.Text == "" || cmb_venue.Text == "NILS"||cmb_venue.SelectedIndex>-1)
            {

            }
            else
            {
                G_maps.autocomplete_place_combobox(cmb_venue);
            }
        }

        private void cmb_venue_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cmb_rp1.Text == "" && metroCheckBox1.Checked==true)
            {
                MessageBox.Show("Please select Resource Person-1", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                metroCheckBox1.Checked = false;
            }
            else
            {
                if (metroCheckBox1.Checked == true)
                {
                    cmb_rp2.Items.Remove("None");
                    cmb_rp2.Enabled = true;
                   
                }
                else
                {
                    metroCheckBox2.Checked = false;
                    cmb_rp2.Enabled = false;
                    cmb_rp2.Items.Add("None");
                    cmb_rp2.Text = "None";
                }
            }
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (cmb_rp1.Text == "" && metroCheckBox2.Checked == true)
            {
                MessageBox.Show("Please select Resource Person-1", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                metroCheckBox2.Checked = false;

            }
            else if (metroCheckBox1.Checked == false && metroCheckBox2.Checked==true)
            {
                MessageBox.Show("Please select Resource Person-2", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                metroCheckBox2.Checked = false;
            }
            else
            {
                if (metroCheckBox2.Checked == true)
                {
                    cmb_rp3.Items.Remove("None");
                    cmb_rp3.Enabled = true;
                   
                }
                else
                {
                    cmb_rp3.Enabled = false;
                    cmb_rp3.Text = "";
                    cmb_rp3.Items.Add("None");
                    cmb_rp3.Text = "None";
                }
            }
        }

      
        ///
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (dates2.Contains(e.Start) == true)
            {
                metroGrid1.Columns.Clear();
                metroGrid1.DataSource = null;
                metroGrid1.DataSource = d.show("EXEC Session_Details_for_dridview @date='" + e.Start + "'");
                metroGrid1.AllowUserToAddRows = false;
                DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
                delete.Text = "Delete this session";
                delete.HeaderText = "Delete this session";
                delete.UseColumnTextForButtonValue = true;
                delete.Width = 150;
                metroGrid1.Columns.Add(delete);
                /*DataGridViewButtonColumn SendEmail = new DataGridViewButtonColumn();
                SendEmail.Text = "Send Email Reminder";
                SendEmail.HeaderText = "Send Email Reminder";
                SendEmail.UseColumnTextForButtonValue = true;
                SendEmail.Width = 150;
                metroGrid1.Columns.Add(SendEmail);
                DataGridViewButtonColumn Sendsms = new DataGridViewButtonColumn();
                Sendsms.Text = "Send SMS Reminder";
                Sendsms.HeaderText = "Send SMS Reminder";
                Sendsms.UseColumnTextForButtonValue = true;
                Sendsms.Width = 150;
                metroGrid1.Columns.Add(Sendsms);*/
                /*DataGridViewButtonColumn update = new DataGridViewButtonColumn();
                update.Text = "Edit this session";
                update.HeaderText = "Edit this session";
                update.UseColumnTextForButtonValue = true;
                update.Width = 150;
                metroGrid1.Columns.Add(update);*/

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to delete program?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    d.delete("DELETE FROM Session_details WHERE program_no='"+metroGrid1.Rows[e.RowIndex].Cells[0].Value.ToString()+"'");
                    MessageBox.Show("Session Deleted Succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    set_date();
                }
            }
        }
        private void add_to_places_table(string place_name,string no)
        {
            
            if (place_name == "NILS")
            {
                if (d.singleInt("SELECT COUNT(*) FROM Session_details WHERE venue='"+place_name+"'") == 1)
                {
                    string id = G_maps.get_place_id_from_place_name_2("National Institute of Labour Studies, Battaramulla - Pannipitiya Road, Colombo, Sri Lanka");
                    string[] stats = G_maps.get_place_details_from_place_id(id);
                    d.update("UPDATE Session_details SET Google_place_id='" + id + "' WHERE program_no='" + no + "'");
                    d.insert("INSERT INTO Place_Details (place_id,Address_string,Latitude,Longitude) VALUES ('" + id + "','" + stats[1] + "','" + stats[3] + "','" + stats[4] + "')");
                }
                else
                {
                    d.update("UPDATE Session_details SET Google_place_id='" + d.singleString("SELECT DISTINCT Google_place_id FROM Session_details WHERE venue='NILS' AND Google_place_id IS NOT NULL") + "' WHERE program_no='" + no + "'");
                }
            }
            else
            {
                if (d.singleInt("SELECT COUNT(*) FROM Session_details WHERE venue='" + place_name + "'") == 1)
                {
                    string id = G_maps.get_place_id_from_place_name_2(place_name);
                    string[] stats = G_maps.get_place_details_from_place_id(id);
                    d.update("UPDATE Session_details SET Google_place_id='" + id + "' WHERE program_no='" + no + "'");
                    d.insert("INSERT INTO Place_Details (place_id,Address_string,Latitude,Longitude) VALUES ('" + id + "','" + stats[1] + "','" + stats[3] + "','" + stats[4] + "')");
                }
                else
                {
                    string id= d.singleString("SELECT DISTINCT Google_place_id FROM Session_details WHERE venue='" + place_name + "' AND Google_place_id IS NOT NULL");
                    d.update("UPDATE Session_details SET Google_place_id='" + id + "' WHERE program_no='" + no + "'");
                }
            }
        }
        private void metroTile1_Click(object sender, EventArgs e)
        {
            DialogResult dresult1 = MessageBox.Show("Schedule new session?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (dresult1 == DialogResult.Yes)
            {
                string no = generate_program_no(General_methods.get_course_type_from_course_no(General_methods.get_course_no_of_batch_from_batch_no(General_methods.get_batch_no_from_batch_name(cmb_batch.Text))));
                d.insert("INSERT INTO Session_details (program_no,scheduled_date,course_type,course_no,module,Resource_person_1,Resource_person_2,Resource_person_3,venue,Batch_no,time) VALUES ('" + generate_program_no(General_methods.get_course_type_from_course_no(General_methods.get_course_no_of_batch_from_batch_no(General_methods.get_batch_no_from_batch_name(cmb_batch.Text)))) + "','" + cmb_date.Value + "','" + General_methods.get_course_type_from_course_no(General_methods.get_course_no_of_batch_from_batch_no(General_methods.get_batch_no_from_batch_name(cmb_batch.Text))) + "','" + lbl_corseno.Text + "','" + General_methods.get_module_no_from_module_name(cmb_module.Text, lbl_corseno.Text) + "','" + General_methods.get_lec_no_from_lec_name_from_combobox(cmb_rp1.Text) + "','" + General_methods.get_lec_no_from_lec_name_from_combobox(cmb_rp2.Text) + "','" + General_methods.get_lec_no_from_lec_name_from_combobox(cmb_rp3.Text) + "','" + cmb_venue.Text + "','" + General_methods.get_batch_no_from_batch_name(cmb_batch.Text) + "','" + time_picker.Value + "')");
                add_to_places_table(cmb_venue.Text, no);
                MessageBox.Show("Successfully scheduled new session", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (chk_reminder_stud.Checked == true)
                {
                    DialogResult dresult2 = MessageBox.Show("Send sms reminder to students?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dresult2 == DialogResult.Yes)
                    {
                        var charsToRemove = new string[] { "(", ")", "-", " " };

                        List<string> numbers = new List<string>();

                        for (int i = 0; i < s.checkedListBox1.Items.Count; i++)
                        {
                            if (s.checkedListBox1.CheckedItems.Contains(s.checkedListBox1.Items[i]) == true)
                            {
                                string k;
                                k = d.singleString("SELECT mobile FROM Stud_details WHERE stud_no='" + s.checkedListBox1.Items[i].ToString().Split('-').GetValue(0) + "'");
                                foreach (var c in charsToRemove)
                                {
                                    k = k.Replace(c, string.Empty);
                                }
                                numbers.Add("94" + k.Remove(0, 1));
                            }
                            else
                            {

                            }
                        }
                        SMS_class.string_sms(numbers, s.richTextBox1.Text);
                        d.update("UPDATE Session_details SET sms_studs = 1 WHERE program_no = '" + no + "'");
                        MessageBox.Show("SMS Reminder to students sent successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (metroCheckBox4.Checked == true)
                {
                    DialogResult dresult3 = MessageBox.Show("Send sms reminder to resource persons?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dresult3 == DialogResult.Yes)
                    {
                        var charsToRemove = new string[] { "(", ")", "-", " " };

                        List<string> numbers = new List<string>();

                        for (int i = 0; i < l.checkedListBox1.Items.Count; i++)
                        {
                            if (l.checkedListBox1.CheckedItems.Contains(l.checkedListBox1.Items[i]) == true)
                            {
                                string k;
                                k = d.singleString("SELECT mobile_no_1 FROM Lecture_details WHERE Lecturer_no='" + l.checkedListBox1.Items[i].ToString().Split('-').GetValue(0) + "'");
                                foreach (var c in charsToRemove)
                                {
                                    k = k.Replace(c, string.Empty);
                                }
                                numbers.Add("94" + k.Remove(0, 1));
                            }
                            else
                            {

                            }
                        }
                        SMS_class.string_sms(numbers, l.richTextBox1.Text);
                        d.update("UPDATE Session_details SET sms_rp=1 WHERE program_no='" + no + "'");
                        MessageBox.Show("SMS Reminder to Resource Persons sent successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (metroCheckBox3.Checked == true)
                {
                    DialogResult dresult2 = MessageBox.Show("Send email reminder to students?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dresult2 == DialogResult.Yes)
                    {

                        List<string> emails = new List<string>();

                        for (int i = 0; i < w.checkedListBox1.Items.Count; i++)
                        {
                            if (w.checkedListBox1.CheckedItems.Contains(w.checkedListBox1.Items[i]) == true)
                            {
                                string k;
                                k = d.singleString("SELECT email_R FROM Stud_details WHERE stud_no='" + w.checkedListBox1.Items[i].ToString().Split('-').GetValue(0) + "'");

                                emails.Add(k);
                            }
                            else
                            {

                            }
                        }
                        //MessageBox.Show(emails.ToArray().GetValue(0).ToString());
                        E_mail.send("thaveesha222@gmail.com", w.richTextBox1.Text, w.metroTextBox1.Text, emails);
                        d.update("UPDATE Session_details SET email_studs = 1 WHERE program_no = '" + no + "'");
                        MessageBox.Show("Email Reminder to students sent successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (chk_reminder_rp.Checked == true)
                {
                    DialogResult dresult2 = MessageBox.Show("Send email reminder to Resource Persons?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dresult2 == DialogResult.Yes)
                    {

                        List<string> emails = new List<string>();

                        for (int i = 0; i < g.checkedListBox1.Items.Count; i++)
                        {
                            if (g.checkedListBox1.CheckedItems.Contains(g.checkedListBox1.Items[i]) == true)
                            {
                                string k;
                                k = d.singleString("SELECT email FROM Lecture_details WHERE Lecturer_no='" + g.checkedListBox1.Items[i].ToString().Split('-').GetValue(0) + "'");

                                emails.Add(k);
                            }
                            else
                            {

                            }
                        }
                        //MessageBox.Show(emails.ToArray().GetValue(0).ToString());
                        E_mail.send("thaveesha222@gmail.com", g.richTextBox1.Text, g.metroTextBox1.Text, emails);
                        d.update("UPDATE Session_details SET email_rp = 1 WHERE program_no = '" + no + "'");
                        MessageBox.Show("Email Reminder to Resource Persons sent successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                
                set_date();
            }


        }
        public string generate_program_no(string type)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT program_no FROM Session_details WHERE course_type='" + type + "'", con);
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

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 12)
            {
                DialogResult d2= MessageBox.Show("Delete session?","Notification",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(d2==DialogResult.Yes)
                {
                    d.delete("DELETE FROM Session_details WHERE program_no='" + metroGrid1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'");
                    MessageBox.Show("Session deleted","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    set_date();
                    metroGrid1.DataSource = null;
                    metroGrid1.Columns.Clear();
                }
            }
        }
        SMS_recipents s;
        SMS_recipents l;

        private void chk_reminder_stud_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_reminder_stud.Checked == true)
            {
             
                metroLink1.Enabled = true;
                s = new SMS_recipents();
                s.type = "student";
                s.batchname = cmb_batch.Text;
                s.module = cmb_module.Text;
                s.venue = cmb_venue.Text;
                s.date = cmb_date.Value.ToShortDateString();
                s.time = time_picker.Value.ToShortTimeString();
                s.lecturer1 = General_methods.get_lec_name_from_lec_no(General_methods.get_lec_no_from_lec_name_from_combobox(cmb_rp1.Text));
                if (cmb_rp2.Text != "None")
                {
                    s.lecturer2 = General_methods.get_lec_name_from_lec_no(General_methods.get_lec_no_from_lec_name_from_combobox(cmb_rp2.Text));
                }
                else if (cmb_rp3.Text != "None")
                {
                    s.lecturer3 = General_methods.get_lec_name_from_lec_no(General_methods.get_lec_no_from_lec_name_from_combobox(cmb_rp3.Text));
                }
                s.Show();
                
            }
            else
            {
                metroLink1.Enabled = false;
                s.Dispose();
            }
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            s.Show();
        }

        private void metroLink2_Click(object sender, EventArgs e)
        {
            l.Show();
        }

        private void metroCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox4.Checked == true)
            {
                metroLink2.Enabled = true;
                l = new SMS_recipents();
                l.type = "lec";
                l.batchname = cmb_batch.Text;
                l.module = cmb_module.Text;
                l.venue = cmb_venue.Text;
                l.date = cmb_date.Value.ToShortDateString();
                l.time = time_picker.Value.ToShortTimeString();
                if (cmb_rp1.Text == "")
                {
                    l.lecturer1 = "None";
                }
                else
                {
                    l.lecturer1 = General_methods.get_lec_name_from_lec_no(General_methods.get_lec_no_from_lec_name_from_combobox( cmb_rp1.Text));
                }
                if (cmb_rp2.Text == "")
                {
                    l.lecturer2 = "None";
                }
                else
                {
                    l.lecturer2 = General_methods.get_lec_name_from_lec_no(General_methods.get_lec_no_from_lec_name_from_combobox(cmb_rp2.Text));
                }
                if (cmb_rp3.Text == "")
                {
                    l.lecturer3 = "None";
                }
                else
                {
                    l.lecturer3 = General_methods.get_lec_name_from_lec_no(General_methods.get_lec_no_from_lec_name_from_combobox(cmb_rp3.Text));
                }
                //l.lecturer2 = cmb_rp2.Text;
                // l.lecturer3 = cmb_rp3.Text;
                l.Show();
            }
            else
            {
                metroLink2.Enabled = false;
                l.Dispose();
            }
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            if (metroTile2.Text == "Confirm")
            {

                if (cmb_batch.Text == "")
                {
                    MessageBox.Show("Please select batch", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else if (cmb_module.Enabled == true && cmb_module.Text == "")
                {
                    MessageBox.Show("Please select module", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else if (chk_inhouse.Checked ==false &&  cmb_venue.Text == "")
                {
                    MessageBox.Show("Please select venue", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else if (cmb_rp1.Text == "")
                {
                    MessageBox.Show("Please select at least one resource person", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else if (metroCheckBox1.Checked == true && cmb_rp2.Text == "")
                {
                    MessageBox.Show("Please select Resource Person 2", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else if (metroCheckBox2.Checked == true && cmb_rp3.Text == "")
                {
                    MessageBox.Show("Please select Resource Person 3", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else if ((cmb_rp1.Text == cmb_rp2.Text) || (cmb_rp2.Text == cmb_rp3.Text || cmb_rp1.Text == cmb_rp3.Text)==true && cmb_rp2.Text!="None")
                {
                    MessageBox.Show("One lecturer cannot be selected twice", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (metroCheckBox1.Checked==true && metroCheckBox2.Checked==true && (d.singleInt("SELECT COUNT(*) FROM Lecture_details WHERE Lecturer_no='" + cmb_rp1.Text.Split('-').GetValue(0).ToString() + "' OR Lecturer_no='" + cmb_rp2.Text.Split('-').GetValue(0).ToString() + "' OR Lecturer_no='" + cmb_rp3.Text.Split('-').GetValue(0).ToString() + "'") != 3))
                {
                    MessageBox.Show("Select valid Lecturer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (metroCheckBox1.Checked == true && (d.singleInt("SELECT COUNT(*) FROM Lecture_details WHERE Lecturer_no='" + cmb_rp1.Text.Split('-').GetValue(0).ToString() + "' OR Lecturer_no='" + cmb_rp2.Text.Split('-').GetValue(0).ToString() + "'") != 2))
                {
                    MessageBox.Show("Select valid Lecturer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (metroCheckBox1.Checked == false && metroCheckBox2.Checked == false && (d.singleInt("SELECT COUNT(*) FROM Lecture_details WHERE Lecturer_no='" + cmb_rp1.Text.Split('-').GetValue(0).ToString() + "'") != 1))
                {
                    MessageBox.Show("Select valid Lecturer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {

                    metroPanel3.Enabled = false;
                    metroTile2.Text = "Change";
                    metroPanel2.Enabled = true;
                    metroTile1.Enabled = true;
                    /* d.insert("INSERT INTO Session_details (program_no,scheduled_date,course_type,course_no,module,Resource_person_1,Resource_person_2,Resource_person_3,venue,Batch_no,time) VALUES ('" + generate_program_no(General_methods.get_course_type_from_course_no(General_methods.get_course_no_of_batch_from_batch_no(General_methods.get_batch_no_from_batch_name(cmb_batch.Text)))) + "','" + cmb_date.Value + "','" + General_methods.get_course_type_from_course_no(General_methods.get_course_no_of_batch_from_batch_no(General_methods.get_batch_no_from_batch_name(cmb_batch.Text))) + "','" + lbl_corseno.Text + "','" + General_methods.get_module_no_from_module_name(cmb_module.Text, lbl_corseno.Text) + "','" + General_methods.get_lec_no_from_lec_name(cmb_rp1.Text) + "','" + General_methods.get_lec_no_from_lec_name(cmb_rp2.Text) + "','" + General_methods.get_lec_no_from_lec_name(cmb_rp3.Text) + "','" + cmb_venue.Text + "','" + General_methods.get_batch_no_from_batch_name(cmb_batch.Text) + "','" + time_picker.Value + "')");
                     MessageBox.Show("Successfully scheduled new session", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     set_date();*/
                }
               
            }
            else
            {
                metroPanel3.Enabled = true;
                metroTile2.Text = "Confirm";
                metroPanel2.Enabled = false;
                metroTile1.Enabled = false;

            }
        }
      
        private void metroPanel2_EnabledChanged(object sender, EventArgs e)
        {
            if (metroPanel2.Enabled == false)
            {
                foreach (Control c in metroPanel2.Controls)
                {
                    if (c is MetroFramework.Controls.MetroCheckBox)
                    {
                        CheckBox c2 = (CheckBox)c;
                        c2.Checked = false;
                    }
                }
                

            }
            else
            {
                if (lbl_no_studsinbatch.Text == "0")
                {
                    chk_reminder_stud.Enabled = false;
                    metroCheckBox3.Enabled = false;
                }
                else
                {
                    chk_reminder_stud.Enabled = true;
                    metroCheckBox3.Enabled = true;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            metroGrid2.Columns.Clear();
            metroGrid2.DataSource = null;
            metroGrid2.DataSource = d.show("Session_Details_for_dridview_for_short_programs @date='"+ e.Start + "'");
            metroGrid2.AllowUserToAddRows = false;
            DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
            delete.Text = "Delete this session";
            delete.HeaderText = "Delete this session";
            delete.UseColumnTextForButtonValue = true;
            delete.Width = 150;
            metroGrid2.Columns.Add(delete);
            /*DataGridViewButtonColumn SendEmail = new DataGridViewButtonColumn();
            SendEmail.Text = "Send Email Reminder";
            SendEmail.HeaderText = "Send Email Reminder";
            SendEmail.UseColumnTextForButtonValue = true;
            SendEmail.Width = 150;
            metroGrid1.Columns.Add(SendEmail);
            DataGridViewButtonColumn Sendsms = new DataGridViewButtonColumn();
            Sendsms.Text = "Send SMS Reminder";
            Sendsms.HeaderText = "Send SMS Reminder";
            Sendsms.UseColumnTextForButtonValue = true;
            Sendsms.Width = 150;
            metroGrid1.Columns.Add(Sendsms);*/
            /*DataGridViewButtonColumn update = new DataGridViewButtonColumn();
            update.Text = "Edit this session";
            update.HeaderText = "Edit this session";
            update.UseColumnTextForButtonValue = true;
            update.Width = 150;
            metroGrid1.Columns.Add(update);*/
        }

        private void chk_rp_CheckedChanged(object sender, EventArgs e)
        {
            if (cmb_rp_1.Text == "" && chk_rp.Checked == true)
            {
                MessageBox.Show("Please select Resource Person-1", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                chk_rp.Checked = false;
            }
            else
            {
                if (chk_rp.Checked == true)
                {
                    cmb_rp_2.Items.Remove("None");
                    cmb_rp_2.Enabled = true;
                    
                }
                else
                {
                    metroCheckBox5.Checked = false;
                    cmb_rp_2.Enabled = false;
                    cmb_rp_2.Text = "";
                    cmb_rp_2.Items.Add("None");
                    cmb_rp_2.Text = "None";
                }
            }
        }

        private void metroCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (cmb_rp_1.Text == "" && metroCheckBox5.Checked == true)
            {
                MessageBox.Show("Please select Resource Person-1", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                metroCheckBox5.Checked = false;

            }
            else if (chk_rp.Checked == false && metroCheckBox5.Checked == true)
            {
                MessageBox.Show("Please select Resource Person-2", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                metroCheckBox5.Checked = false;
            }
            else
            {
                if (metroCheckBox5.Checked == true)
                {
                    cmb_rp_3.Items.Remove("None");
                    cmb_rp_3.Enabled = true;
                  
                }
                else
                {
                    cmb_rp_3.Enabled = false;
                    cmb_rp_3.Text = "";
                    cmb_rp_3.Items.Add("None");
                    cmb_rp_3.Text = "None";
                }
            }
        }

        private void chk_rp_sms_CheckedChanged(object sender, EventArgs e)
        {

            if (chk_rp_sms.Checked == true)
            {

                metroLink6.Enabled = true;
                a = new SMS_recipents();
                a.type = "short_lec";
                a.prg_type = cmb_type.Text;
                a.batchname = txt_title.Text;
                //s.module = cmb_module.Text;
                a.venue = cmb_venue_1.Text;
                a.date = metroDateTime1.Value.ToShortDateString();
                a.time = TimePicker1.Value.ToShortTimeString();
                a.lecturer1 = General_methods.get_lec_name_from_lec_no(General_methods.get_lec_no_from_lec_name_from_combobox(cmb_rp_1.Text));
                if (cmb_rp_2.Text != "None")
                {
                    a.lecturer2 = General_methods.get_lec_name_from_lec_no(General_methods.get_lec_no_from_lec_name_from_combobox(cmb_rp_2.Text));
                }
                else if (cmb_rp_3.Text != "None")
                {
                    a.lecturer3 = General_methods.get_lec_name_from_lec_no(General_methods.get_lec_no_from_lec_name_from_combobox(cmb_rp_3.Text));
                }
                a.Show();

            }
            else
            {
                metroLink6.Enabled = false;
                a.Dispose();
            }

        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            DialogResult dresult = MessageBox.Show("Schedule new session ?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dresult == DialogResult.Yes)
            {
                string no = generate_program_no(cmb_type.Text);
                d.insert("INSERT INTO Session_details (program_no,scheduled_date,course_type,course_no,module,Resource_person_1,Resource_person_2,Resource_person_3,venue,Batch_no,time) VALUES ('" + generate_program_no(cmb_type.Text) + "','" + metroDateTime1.Value + "','" + cmb_type.Text + "','None','no modules','" + General_methods.get_lec_no_from_lec_name_from_combobox(cmb_rp_1.Text) + "','" + General_methods.get_lec_no_from_lec_name_from_combobox(cmb_rp_2.Text) + "','" + General_methods.get_lec_no_from_lec_name_from_combobox(cmb_rp_3.Text) + "','" + cmb_venue_1.Text + "','None','" + TimePicker1.Value + "')");
                add_to_places_table(cmb_venue_1.Text, no);
                d.insert("INSERT INTO Short_program_details (Code,Program_title) VALUES ('" + no + "','" + txt_title.Text + "')");
                MessageBox.Show("Successfully scheduled new session", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (chk_rp_sms.Checked == true)
                {
                    DialogResult dresult2 = MessageBox.Show("Send sms reminder to Resource Persons?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dresult2 == DialogResult.Yes)
                    {
                        var charsToRemove = new string[] { "(", ")", "-", " " };

                        List<string> numbers = new List<string>();

                        for (int i = 0; i < a.checkedListBox1.Items.Count; i++)
                        {
                            if (a.checkedListBox1.CheckedItems.Contains(a.checkedListBox1.Items[i]) == true)
                            {
                                string k;
                                k = d.singleString("SELECT mobile_no_1 FROM Lecture_details WHERE Lecturer_no='" + a.checkedListBox1.Items[i].ToString().Split('-').GetValue(0) + "'");
                                foreach (var c in charsToRemove)
                                {
                                    k = k.Replace(c, string.Empty);
                                }
                                numbers.Add("94" + k.Remove(0, 1));
                            }
                            else
                            {

                            }
                        }
                        SMS_class.string_sms(numbers, a.richTextBox1.Text);
                        d.update("UPDATE Session_details SET sms_rp=1 WHERE program_no='" + no + "'");
                        MessageBox.Show("SMS Reminder to Resource Persons sent successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        set_date_2();
                    }
                }
                if (ckh_rp_email.Checked == true)
                {
                    DialogResult dresult2 = MessageBox.Show("Send email reminder to Resource Persons?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dresult2 == DialogResult.Yes)
                    {

                        List<string> emails = new List<string>();

                        for (int i = 0; i < k.checkedListBox1.Items.Count; i++)
                        {
                            if (k.checkedListBox1.CheckedItems.Contains(k.checkedListBox1.Items[i]) == true)
                            {
                                string l;
                                l = d.singleString("SELECT email FROM Lecture_details WHERE Lecturer_no='" + k.checkedListBox1.Items[i].ToString().Split('-').GetValue(0) + "'");

                                emails.Add(l);
                            }
                            else
                            {

                            }
                        }
                        //MessageBox.Show(emails.ToArray().GetValue(0).ToString());
                        E_mail.send("thaveesha222@gmail.com", k.richTextBox1.Text, k.metroTextBox1.Text, emails);
                        d.update("UPDATE Session_details SET email_rp = 1 WHERE program_no = '" + no + "'");
                        MessageBox.Show("Email Reminder to Resource Persons sent successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }


            }
        }

        private void metroCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_inhouse_1.Checked == true)
            {
                cmb_venue_1.DataSource = null;
                cmb_venue_1.Enabled = false;
                cmb_venue_1.Items.Add("NILS");
                cmb_venue_1.Text = "NILS";
            }
            else
            {
                cmb_venue_1.Enabled = true;
                cmb_venue_1.Items.Remove("NILS");

            }
        }

        private void cmb_venue_1_TextChanged(object sender, EventArgs e)
        {
            if (cmb_venue_1.Text == "" || cmb_venue_1.Text == "NILS" || cmb_venue_1.SelectedIndex > -1)
            {

            }
            else
            {
                G_maps.autocomplete_place_combobox(cmb_venue_1);
            }
        }
        SMS_recipents a;
        private void metroLink6_Click(object sender, EventArgs e)
        {
            a.Show();
        }
        Email_recipients k;
        private void ckh_rp_email_CheckedChanged(object sender, EventArgs e)
        {
            if (ckh_rp_email.Checked == true)
            {
                metroLink5.Enabled = true;
                k = new Email_recipients();
                k.type = "short";
                k.batchname = txt_title.Text;
                //k.module = cmb_module.Text;
                k.venue = cmb_venue.Text;
                k.date = metroDateTime1.Value.ToShortDateString();
                k.time = time_picker.Value.ToShortTimeString();
                k.lecturer1 = General_methods.get_lec_name_from_lec_no(General_methods.get_lec_no_from_lec_name_from_combobox(cmb_rp_1.Text));
                if (cmb_rp_2.Text != "None")
                {
                    k.lecturer2 = General_methods.get_lec_name_from_lec_no(General_methods.get_lec_no_from_lec_name_from_combobox(cmb_rp_2.Text));
                }
                else if (cmb_rp_3.Text != "None")
                {
                    k.lecturer3 = General_methods.get_lec_name_from_lec_no(General_methods.get_lec_no_from_lec_name_from_combobox(cmb_rp_3.Text));
                }
                k.Show();
            }
            else
            {
                metroLink5.Enabled = false;
                k.Dispose();
            }
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            if (metroTile4.Text == "Confirm")
            {
                if (cmb_type.Text == "")
                {
                    MessageBox.Show("Please select type of program", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (txt_title.Text == "")
                {
                    MessageBox.Show("Please enter title of program", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (cmb_rp_1.Text == "")
                {
                    MessageBox.Show("Please select at least one resource person", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (chk_inhouse_1.Checked == false && cmb_venue_1.Text == "NILS")
                {
                    MessageBox.Show("Please select venue", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if ((cmb_rp_1.Text == cmb_rp_2.Text) || (cmb_rp_2.Text == cmb_rp_3.Text || cmb_rp_1.Text == cmb_rp_3.Text) == true && cmb_rp_2.Text != "None")
                {
                    MessageBox.Show("One lecturer cannot be selected twice", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (chk_rp.Checked == true && metroCheckBox5.Checked == true && (d.singleInt("SELECT COUNT(*) FROM Lecture_details WHERE Lecturer_no='" + cmb_rp_1.Text.Split('-').GetValue(0).ToString() + "' OR Lecturer_no='" + cmb_rp_2.Text.Split('-').GetValue(0).ToString() + "' OR Lecturer_no='" + cmb_rp_3.Text.Split('-').GetValue(0).ToString() + "'") != 3))
                {
                    MessageBox.Show("Select valid Lecturer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (chk_rp.Checked == true && (d.singleInt("SELECT COUNT(*) FROM Lecture_details WHERE Lecturer_no='" + cmb_rp_1.Text.Split('-').GetValue(0).ToString() + "' OR Lecturer_no='" + cmb_rp_2.Text.Split('-').GetValue(0).ToString() + "'") != 2))
                {
                    MessageBox.Show("Select valid Lecturer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (chk_rp.Checked == false && metroCheckBox5.Checked == false && (d.singleInt("SELECT COUNT(*) FROM Lecture_details WHERE Lecturer_no='" + cmb_rp_1.Text.Split('-').GetValue(0).ToString() + "'") != 1))
                {
                    MessageBox.Show("Select valid Lecturer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    metroPanel5.Enabled = true;
                    metroTile3.Enabled = true;
                    metroTile4.Text = "Change";
                    metroPanel4.Enabled = false;

                }
            }
            else
            {
                metroPanel5.Enabled = false;
                metroTile3.Enabled = false;
                metroTile4.Text = "Confirm";
                metroPanel4.Enabled = true;
                chk_rp_sms.Checked = false;
                ckh_rp_email.Checked = false;
            }
        }

        private void cmb_rp1_TextChanged(object sender, EventArgs e)
        {
           
            General_methods.combobox_autocomplete(cmb_rp1, names);

        }

        private void cmb_rp2_TextChanged(object sender, EventArgs e)
        {
            General_methods.combobox_autocomplete(cmb_rp2, names);

        }

        private void cmb_rp3_TextChanged(object sender, EventArgs e)
        {
            General_methods.combobox_autocomplete(cmb_rp3, names);
        }

        private void cmb_rp_1_TextChanged(object sender, EventArgs e)
        {
            General_methods.combobox_autocomplete(cmb_rp_1, names);
        }

        private void cmb_rp_2_TextChanged(object sender, EventArgs e)
        {
            General_methods.combobox_autocomplete(cmb_rp_2, names);
        }

        private void cmb_rp_3_TextChanged(object sender, EventArgs e)
        {
            General_methods.combobox_autocomplete(cmb_rp_3, names);
        }

        private void cmb_rp1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_rp1.SelectedIndex == 0)
            {

            }
        }

        private void metroPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroLink8_Click(object sender, EventArgs e)
        {
            View_lec_doc v = new View_lec_doc();
            v.Show();
        }

        private void metroLink7_Click(object sender, EventArgs e)
        {
            View_lec_doc v = new View_lec_doc();
            v.Show();
        }

        private void metroLink6_Click_1(object sender, EventArgs e)
        {
            a.Show();
        }
        Email_recipients w;
        private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if(metroCheckBox3.Checked==true)
            { 
                metroLink3.Enabled = true;
                w = new Email_recipients();
                w.type = "dip_studs";
                w.batchname = cmb_batch.Text;
                w.module = cmb_module.Text;
                w.venue = cmb_venue.Text;
                w.date = cmb_date.Value.ToShortDateString();
                w.time = time_picker.Value.ToShortTimeString();
                w.lecturer1 = General_methods.get_lec_name_from_lec_no(General_methods.get_lec_no_from_lec_name_from_combobox(cmb_rp1.Text));
                if (cmb_rp2.Text != "None")
                {
                    w.lecturer2 = General_methods.get_lec_name_from_lec_no(General_methods.get_lec_no_from_lec_name_from_combobox(cmb_rp2.Text));
                }
                else if (cmb_rp3.Text != "None")
                {
                    w.lecturer3 = General_methods.get_lec_name_from_lec_no(General_methods.get_lec_no_from_lec_name_from_combobox(cmb_rp3.Text));
                }
                w.Show();
            }
            else
            {
                metroLink3.Enabled = false;
                w.Dispose();
            }
        }

        private void metroLink3_Click(object sender, EventArgs e)
        {
            w.Show();
        }
        Email_recipients g;
        private void chk_reminder_rp_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_reminder_rp.Checked == true)
            {
                metroLink4.Enabled = true;
                g = new Email_recipients();
                g.type = "lec";
                g.batchname = cmb_batch.Text;
                g.module = cmb_module.Text;
                g.venue = cmb_venue.Text;
                g.date = cmb_date.Value.ToShortDateString();
                g.time = time_picker.Value.ToShortTimeString();
                g.lecturer1 = General_methods.get_lec_name_from_lec_no(General_methods.get_lec_no_from_lec_name_from_combobox(cmb_rp1.Text));
                if (cmb_rp2.Text != "None")
                {
                    g.lecturer2 = General_methods.get_lec_name_from_lec_no(General_methods.get_lec_no_from_lec_name_from_combobox(cmb_rp2.Text));
                }
                else if (cmb_rp3.Text != "None")
                {
                    g.lecturer3 = General_methods.get_lec_name_from_lec_no(General_methods.get_lec_no_from_lec_name_from_combobox(cmb_rp3.Text));
                }
                g.Show();
            }
            else
            {
                metroLink4.Enabled = false;
                g.Dispose();
            }
        }

        private void metroLink4_Click(object sender, EventArgs e)
        {
            g.Show();
        }

        private void metroLink5_Click(object sender, EventArgs e)
        {
            k.Show();
        }
    }
}
