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
using System.Data.SqlClient;
using System.IO;

namespace NILS_original
{
    public partial class Student_profiles : MetroFramework.Forms.MetroForm
    {
        public Student_profiles()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            invisible();

        }
        public void invisible()
        {
            metroLink2.Visible = false;
            pictureBox1.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            //btn_marks_view.Visible = false;
            //btn_view_certif.Visible = false;
            //btn_view_payements.Visible = false;
            //btn_terminate_stud.Visible = false;
            pictureBox1.Image = null;
        }
        public void visible()
        {
            metroLink2.Visible = true;
            pictureBox1.Visible = true;
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            groupBox3.Visible = true;
            groupBox4.Visible = true;
            groupBox5.Visible = true;
            //btn_marks_view.Visible = true;
            //btn_view_certif.Visible = true;
            //btn_view_payements.Visible = true;
            //btn_terminate_stud.Visible = true;
        }
        SqlConnection con = new SqlConnection(Credentials.connection);
        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }
        string type;
        public static string no;
        public static string cno;
        private void metroButton1_Click(object sender, EventArgs e)
        {
            visible();
            /*if(txt_enter_name.Text=="")
            {
                MetroMessageBox.Show(this, "Please enter stud no", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    groupBox1.Visible = true;
                    groupBox2.Visible = true;
                    groupBox3.Visible = true;
                    pictureBox1.Visible = true;
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Stud_details WHERE stud_no='" + txt_enter_name.Text + "' ", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    txt_no.Text = dr.GetValue(0).ToString();
                    no= dr.GetValue(0).ToString();
                    txt_fname.Text = dr.GetValue(1).ToString();
                    //txt_lname.Text = dr.GetValue(2).ToString();
                    txt_gender.Text = dr.GetValue(3).ToString();
                    txt_nic.Text = dr.GetValue(4).ToString();
                    //txt_org.Text = dr.GetValue(5).ToString();
                    txt_desig.Text = dr.GetValue(6).ToString();
                    txt_address.Text = dr.GetValue(7).ToString();
                    txt_oaddress.Text = dr.GetValue(8).ToString();
                    txt_mobile.Text = dr.GetValue(9).ToString();
                    txt_otel.Text = dr.GetValue(10).ToString() + " / " + dr.GetValue(11).ToString();
                    txt_resi_tel.Text = dr.GetValue(12).ToString();
                    txt_resi_email.Text = dr.GetValue(14).ToString();
                    txt_oemail.Text = dr.GetValue(15).ToString();
                    txt_fax.Text = dr.GetValue(16).ToString();
                    txt_course_code.Text = dr.GetValue(17).ToString();
                    cno= dr.GetValue(17).ToString();
                    txt_typ.Text= dr.GetValue(18).ToString();
                    type = dr.GetValue(18).ToString();
                    txt_course_name.Text = General_methods.get_course_name_from_course_no(dr.GetValue(17).ToString());
                    con.Close();
                    dr.Close();
                    if(type=="Diploma")
                    {
                        Database d1 = new Database();
                        xx.Visible = true;
                        con.Open();
                        int count = d1.singleInt("SELECT COUNT(*)  FROM Dip_module_details_2 WHERE Course_no='" + txt_course_code.Text + "'");
                        SqlCommand cmd3 = new SqlCommand("SELECT * FROM Dip_stud_modules WHERE stud_no='" + txt_no.Text + "'",con);
                        SqlDataReader r = cmd3.ExecuteReader();
                        r.Read();
                        if(count>7)
                        {
                            mod1.Text = r.GetValue(1).ToString();
                            mod2.Text = r.GetValue(2).ToString();
                            mod3.Text = r.GetValue(3).ToString();
                            mod4.Text = r.GetValue(4).ToString();
                            mod5.Text = r.GetValue(5).ToString();
                            mod6.Text = r.GetValue(6).ToString();
                            mod7.Text = r.GetValue(7).ToString();
                            mod8.Text = r.GetValue(8).ToString();
                        }
                        else if (count > 6)
                        {
                            mod1.Text = r.GetValue(1).ToString();
                            mod2.Text = r.GetValue(2).ToString();
                            mod3.Text = r.GetValue(3).ToString();
                            mod4.Text = r.GetValue(4).ToString();
                            mod5.Text = r.GetValue(5).ToString();
                            mod6.Text = r.GetValue(6).ToString();
                            mod7.Text = r.GetValue(7).ToString();
                            mod8.Text = "";
                        }
                        else if (count > 5)
                        {
                            mod1.Text = r.GetValue(1).ToString();
                            mod2.Text = r.GetValue(2).ToString();
                            mod3.Text = r.GetValue(3).ToString();
                            mod4.Text = r.GetValue(4).ToString();
                            mod5.Text = r.GetValue(5).ToString();
                            mod6.Text = r.GetValue(6).ToString();
                            mod7.Text = "";
                            mod8.Text = "";
                        }
                        else if (count > 4)
                        {
                            mod1.Text = r.GetValue(1).ToString();
                            mod2.Text = r.GetValue(2).ToString();
                            mod3.Text = r.GetValue(3).ToString();
                            mod4.Text = r.GetValue(4).ToString();
                            mod5.Text = r.GetValue(5).ToString();
                            mod6.Text = "";
                            mod7.Text = "";
                            mod8.Text = "";
                        }
                        con.Close();
                        Database d = new Database();
                        DataTable dt= d.show("SELECT ref_no FROM UserAccountDetails");
                        bool contains = dt.AsEnumerable().Any(row => txt_enter_name.Text == row.Field<String>("ref_no"));
                        if(contains==false)
                        {
                            pictureBox1.Image = Properties.Resources.user_50px;
                        }
                        else if(contains==true)
                        {
                            con.Open();
                            string query = "SELECT Image FROM UserAccountDetails WHERE ref_no='" + txt_enter_name.Text + "' ";
                            cmd = new SqlCommand(query, con);
                            SqlDataReader dataRead = cmd.ExecuteReader();
                            dataRead.Read();
                            if (dataRead.HasRows)
                            {

                                if (dataRead[0] != DBNull.Value)
                                {
                                    byte[] images = (byte[])dataRead[0];
                                    MemoryStream mstream = new MemoryStream(images);
                                    //  picBxUser.Image = Image.FromStream(mstream);
                                    pictureBox1.Image= Image.FromStream(mstream);
                                }
                                else
                                {
                                    pictureBox1.Image = null;
                                    pictureBox1.Image = Image.FromFile(@"Icons & Images\user_50px.png");

                                }


                                dataRead.Close();
                            }
                            else
                            {
                                MetroMessageBox.Show(this, "Profile picture not available ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            con.Close();
                        }
                    }
                    
                }
                catch(InvalidOperationException i)
                {
                    groupBox1.Visible = false;
                    groupBox2.Visible = false;
                    groupBox3.Visible = false;
                    pictureBox1.Visible = false;
                    MetroMessageBox.Show(this, "Invalid student no" , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }*/

        }

        private void btn_view_payements_Click(object sender, EventArgs e)
        {
            if (type == "Diploma")
            {
                view_payment v = new view_payment();
                v.Show();
            }
            else if (type == "Certificate")
            {
                view_payements_certif c = new view_payements_certif();
                c.Show();
            }
        }

        private void btn_marks_view_Click(object sender, EventArgs e)
        {
            View_marks v = new View_marks();
            v.Show();
        }

        private void txt_course_code_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_view_certif_Click(object sender, EventArgs e)
        {
            Certifs_view c = new Certifs_view();
            c.Show();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {

        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            Edit_personal_info q = new Edit_personal_info();
            q.Show();
            q.txt_studno.Text = this.txt_no.Text;
            q.txt_fname.Text = txt_fname.Text.Split(' ').GetValue(0).ToString();
            q.txt_mname.Text = txt_fname.Text.Split(' ').GetValue(1).ToString();
            q.txt_lname.Text = txt_fname.Text.Split(' ').GetValue(2).ToString();
            q.metroDateTime1.Value = Convert.ToDateTime(txt_bday.Text);
            q.txt_nic.Text = txt_nic.Text;
            q.txt_desig.DataSource = General_methods.fill_designations_combobox();
            q.txt_desig.Text = txt_desig.Text;
            q.batch = txt_batchno.Text;
            q.prev_nic = txt_nic.Text;
            if (txt_gender.Text == "male")
            {
                q.metroRadioButton1.Checked = true;
            }
            else
            {
                q.metroRadioButton2.Checked = true;
            }
            q.metroTile1.Click += HandleCustomEvent1;


        }

    
        public void HandleCustomEvent1(object sender, EventArgs a)
        {
            redraw_controls(prev);
            txt_enter_name.Text = "";
            txt_enter_name.Items.Clear();
            if (metroRadioButton1.Checked == true)
            {
                set_items_to_items_list("Diploma");
            }
            else if (metroRadioButton2.Checked == true)
            {
                set_items_to_items_list("Certificate");
            }
        }
        public static void refresh()
        {

        }
        private void metroTile3_Click(object sender, EventArgs e)
        {
            Edit_contact_info w = new Edit_contact_info();
            w.Show();
            w.txt_stud_no.Text = txt_no.Text;
            w.txt_add.Text = txt_address.Text.Remove(0, txt_address.Text.Split(' ').GetValue(0).ToString().Length);
            w.txt_email.Text = txt_resi_email.Text;
            w.txt_mobile.Text = txt_mobile.Text;
            w.txt_tel_r.Text = txt_resi_tel.Text;
            w.txt_homeno.Text = txt_address.Text.Split(' ').GetValue(0).ToString();
            w.txt_c_p_1_name.Text = contact_p_1_name.Text;
            w.txt_c_p_1_no.Text = contact_p_1_no.Text;
            if (contact_p_2_name.Text != "None")
            {
                w.metroCheckBox1.Checked = true;
                w.txt_c_p_2_name.Text = contact_p_2_name.Text;
                w.txt_c_p_2_no.Text = contact_p_2_no.Text;
            }
            else
            {
                w.metroCheckBox1.Checked = true;
            }
            w.metroTile1.Click += HandleCustomEvent1;
        }

        
        private void metroTile4_Click(object sender, EventArgs e)
        {
            Edit_workplace_info f = new Edit_workplace_info();
            f.Show();
            f.txt_org.Text = txt_org_name.Text;
            f.txt_stud_no.Text = txt_no.Text;
            f.metroTile1.Click += HandleCustomEvent1;
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            /*Select_modules s = new Select_modules();
            s.metroTile3.Visible = true;
            s.Text = "Edit Student Modules";
            s.metroTile1.Visible = false;
            s.ControlBox = true;
            s.lb_stud_no.Text = txt_no.Text;
            s.lb_course_no.Text = txt_course_code.Text;
            s.lb_course_name.Text = General_methods.get_course_name_from_course_no(txt_course_code.Text);
            s.Show();
            s.metroTile1.Click += HandleCustomEvent1;*/

        }

        private void mod8_Enter(object sender, EventArgs e)
        {

        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        List<string> items = new List<string>();
        private void Student_profiles_Load(object sender, EventArgs e)
        {

            /*txt_enter_name.DataSource = items;
            txt_enter_name.Text = "";*/
        }

        private void txt_enter_name_KeyPress(object sender, KeyPressEventArgs e)
        {



        }
        Database d = new Database();
        public void redraw_controls(string data)
        {
            invisible();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Stud_details WHERE stud_no='" + data + "' ", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.IsDBNull(23))
            {
                txt_no.Text = dr.GetValue(0).ToString();
                no = dr.GetValue(0).ToString();
                txt_fname.Text = dr.GetValue(1).ToString() + " " + dr.GetValue(2).ToString() + " " + dr.GetValue(3).ToString();
                txt_gender.Text = dr.GetValue(4).ToString();
                txt_nic.Text = dr.GetValue(5).ToString();
                txt_desig.Text = dr.GetValue(7).ToString();
                txt_address.Text = dr.GetValue(22).ToString() + " " + d.singleString("SELECT Address_string FROM Place_Details WHERE place_id='"+dr.GetValue(8).ToString()+"'");
                txt_resi_tel.Text = dr.GetValue(10).ToString();
                txt_mobile.Text = dr.GetValue(9).ToString();
                txt_resi_email.Text = dr.GetValue(11).ToString();
                contact_p_1_name.Text = dr.GetValue(15).ToString();
                contact_p_1_no.Text = dr.GetValue(16).ToString();
                contact_p_2_name.Text = dr.GetValue(17).ToString();
                contact_p_2_no.Text = dr.GetValue(18).ToString();
                txt_batchno.Text = dr.GetValue(21).ToString();
                txt_stud_name_with_initials.Text = dr.GetValue(24).ToString();
                txt_batch_name.Text = General_methods.get_batch_name_from_batch_ne(dr.GetValue(21).ToString());
                txt_course_code.Text = dr.GetValue(12).ToString();
                txt_course_name.Text = General_methods.get_course_name_from_course_no(dr.GetValue(12).ToString());
                txt_typ.Text = General_methods.get_course_type_from_course_no(dr.GetValue(12).ToString());
                txt_medium.Text = dr.GetValue(13).ToString();
                txt_bday.Text = Convert.ToDateTime(dr.GetValue(14).ToString()).ToLongDateString();
                txt_age.Text = (DateTime.Today.Year - Convert.ToDateTime(txt_bday.Text).Year).ToString();
                txt_org_name.Text = General_methods.find_organization_name_from_organization_no(dr.GetValue(6).ToString());
                string[] a = General_methods.get_organization_details_from_org_name(txt_org_name.Text);
                txt_oaddress.Text = a[0];
                txt_otel.Text = a[1];
                txt_oemail.Text = a[2];
                txt_fax.Text = a[3];
                if (!dr.IsDBNull(20))
                {
                    General_methods.get_stud_pic(pictureBox1, dr.GetValue(0).ToString());
                }
                visible();
                con.Close();
                dr.Close();
                listBox1.Items.Clear();
                if (General_methods.get_course_type_from_course_no(txt_course_code.Text) == "Diploma")
                {
                    con.Open();
                    SqlCommand cmd3 = new SqlCommand("SELECT module_no FROM Dip_stud_modules WHERE stud_no='" + txt_no.Text + "'", con);
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    while (dr3.Read())
                    {
                        listBox1.Items.Add(General_methods.get_module_name_from_module_no(dr3.GetValue(0).ToString()));
                    }
                    dr3.Close();
                    con.Close();
                }
                else
                {
                    groupBox5.Visible = false;
                }
            }
            else
            {
                SqlConnection con2 = new SqlConnection(Credentials.connection);
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM Stud_details WHERE stud_no='" + dr.GetValue(23).ToString() + "' ", con2);
                con2.Open();
                SqlDataReader dr2 = cmd2.ExecuteReader();
                dr2.Read();
                txt_no.Text = dr2.GetValue(0).ToString();
                no = dr2.GetValue(0).ToString();
                txt_fname.Text = dr2.GetValue(1).ToString() + " " + dr2.GetValue(2).ToString() + " " + dr2.GetValue(3).ToString();
                txt_gender.Text = dr2.GetValue(4).ToString();
                txt_nic.Text = dr2.GetValue(5).ToString();
                txt_desig.Text = dr2.GetValue(7).ToString();
                txt_address.Text = dr2.GetValue(22).ToString() + " " + dr.GetValue(22).ToString() + " " + d.singleString("SELECT Address_string FROM Place_Details WHERE place_id='" + dr2.GetValue(8).ToString() + "'");
                txt_resi_tel.Text = dr2.GetValue(10).ToString();
                txt_mobile.Text = dr2.GetValue(9).ToString();
                txt_resi_email.Text = dr2.GetValue(11).ToString();
                contact_p_1_name.Text = dr2.GetValue(15).ToString();
                contact_p_1_no.Text = dr2.GetValue(16).ToString();
                contact_p_2_name.Text = dr2.GetValue(17).ToString();
                contact_p_2_no.Text = dr2.GetValue(18).ToString();
                txt_batchno.Text = dr.GetValue(21).ToString();
                txt_stud_name_with_initials.Text = dr2.GetValue(24).ToString();
                txt_batch_name.Text = General_methods.get_batch_name_from_batch_ne(dr.GetValue(21).ToString());
                txt_course_code.Text = dr.GetValue(12).ToString();
                txt_course_name.Text = General_methods.get_course_name_from_course_no(dr.GetValue(12).ToString());
                txt_typ.Text = General_methods.get_course_type_from_course_no(dr.GetValue(12).ToString());
                txt_medium.Text = dr.GetValue(13).ToString();
                txt_org_name.Text = General_methods.find_organization_name_from_organization_no(dr2.GetValue(6).ToString());
                string[] a = General_methods.get_organization_details_from_org_name(txt_org_name.Text);
                txt_oaddress.Text = a[0];
                txt_otel.Text = a[1];
                txt_oemail.Text = a[2];
                txt_fax.Text = a[3];
                visible();
                con.Close();
                con2.Close();
                dr.Close();
                dr2.Close();
                listBox1.Items.Clear();
                if (General_methods.get_course_type_from_course_no(txt_course_code.Text) == "Diploma")
                {
                    con.Open();
                    SqlCommand cmd3 = new SqlCommand("SELECT module_no FROM Dip_stud_modules WHERE stud_no='" + txt_no.Text + "'", con);
                    SqlDataReader dr3 = cmd3.ExecuteReader();                   
                    while (dr3.Read())
                    {
                        listBox1.Items.Add(General_methods.get_module_name_from_module_no(dr3.GetValue(0).ToString()));
                    }
                    dr3.Close();
                    con.Close();
                }
                else
                {
                    groupBox5.Visible = false;
                }
            }
        }
        string prev;
        private void txt_enter_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            redraw_controls(txt_enter_name.Text.Split('-').GetValue(0).ToString());
            prev = txt_enter_name.Text.Split('-').GetValue(0).ToString();
        }
        public string calc_age(DateTime k)
        {
            return (DateTime.Today.Year - k.Year).ToString();
        }
        private void txt_enter_name_Click(object sender, EventArgs e)
        {
            if (metroRadioButton1.Checked == false && metroRadioButton2.Checked == false)
            {
                MessageBox.Show(this, "Please select whether diploma student or Certificate Student", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
        public void set_items_to_items_list(string type)
        {
            txt_enter_name.Text = "";
            items.Clear();
            txt_enter_name.Items.Clear();            
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT s.stud_no,s.f_name,s.m_name,s.l_name,s.NIC,s.ref,s.course_no FROM Stud_details s INNER JOIN Course_details_master c ON s.course_no=c.course_no WHERE course_type='"+type+"'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                
                if (dr.IsDBNull(5))
                {
                    items.Add(dr.GetValue(0).ToString() + " - " + dr.GetValue(1).ToString() + " " + dr.GetValue(2).ToString() + " " + dr.GetValue(3).ToString() + " - " + dr.GetValue(4).ToString());
                }
                else
                {
                    SqlConnection con2 = new SqlConnection(Credentials.connection);
                    SqlCommand cmd2 = new SqlCommand("SELECT f_name,m_name,l_name,NIC,course_no FROM Stud_details WHERE stud_no='" + dr.GetValue(5).ToString() + "'", con2);
                    con2.Open();
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    dr2.Read();
                    items.Add(dr.GetValue(0).ToString() + " - " + dr2.GetValue(0).ToString() + " " + dr2.GetValue(1).ToString() + " " + dr2.GetValue(2).ToString() + " - " + dr2.GetValue(3).ToString());
                    dr2.Close();
                    con2.Close();
                }
                


            }
            con.Close();
        }
        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton1.Checked == true)
            {
                set_items_to_items_list("Diploma");
            }
        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton2.Checked == true)
            {
                set_items_to_items_list("Certificate");
            }
        }

        private void txt_enter_name_TextChanged(object sender, EventArgs e)
        {
            int h = txt_enter_name.SelectionStart;
            if (txt_enter_name.SelectedIndex > -1)
            {

            }
            else
            {
                txt_enter_name.Items.Clear();
                foreach (string p in items)
                {
                    if (p.Contains(txt_enter_name.Text))
                    {
                        txt_enter_name.Items.Add(p);
                    }
                    else
                    {

                    }
                }
                txt_enter_name.Update();
                txt_enter_name.SelectionStart = h;
            }
            
        }

        private void txt_enter_name_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txt_enter_name_Click_1(object sender, EventArgs e)
        {
            if (metroRadioButton1.Checked == false && metroRadioButton2.Checked == false)
            {
                MessageBox.Show(this, "Please select the course type of student (Diploma/Certificate)", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
           
            Module_selection.state = true;
            Module_selection m = new Module_selection();
            m.lbl_stud_no.Text = txt_no.Text;
            m.lbl_course_no.Text = txt_course_code.Text;
            m.Text = "Edit selected modules";
            m.metroTile1.Text = "Update";
            m.Show();
            m.metroTile1.Click += HandleCustomEvent1;
        }
        Edit_students_courses p;
        private void metroTile1_Click_1(object sender, EventArgs e)
        {
            Edit_students_courses.batchno = txt_batchno.Text;
            Edit_students_courses.stud_no = txt_no.Text;
            Edit_students_courses.c_no = txt_course_code.Text;
            p = new Edit_students_courses();
            p.cmb_type.Text = General_methods.get_course_type_from_course_no(txt_course_code.Text);
            //p.cmb_batch.DataSource = General_methods.fill_batches_combobox(p.cmb_type.Text);
           
            //p.txt_studno_1.Text = txt_no.Text;
            p.cmb_batch.Text = txt_batch_name.Text;
            //p.metroTile5.Enabled = false;
            /*p.txt_batch_no.Text = General_methods.get_batch_no_from_batch_name(txt_batch_name.Text);
            p.txt_course_namer.Text = General_methods.get_course_name_from_course_no(General_methods.get_course_no_of_batch_from_batch_no(p.txt_batch_no.Text));
            p.cmb_medium.Text = General_methods.get_medium_from_batch_no(p.txt_batch_no.Text);
            p.txt_studno_1.Text = txt_no.Text;*/
            p.Show();
            p.metroTile5.Click += HandleCustomEvent2;
            p.label1.TextChanged += HandleCustomEvent2;
        }
        public void HandleCustomEvent2(object sender, EventArgs a)
        {
            if (Edit_students_courses.state == true)
            {
                redraw_controls(p.txt_studno_1.Text);
                txt_enter_name.Text = "";
                txt_enter_name.Items.Clear();
                if (metroRadioButton1.Checked == true)
                {
                    set_items_to_items_list("Diploma");
                }
                else if (metroRadioButton2.Checked == true)
                {
                    set_items_to_items_list("Certificate");
                }
            }
            else
            {

            }
        }

        private void metroLink2_Click(object sender, EventArgs e)
        {
            
        }

        private void metrotile_Click(object sender, EventArgs e)
        {

        }
    }
}
