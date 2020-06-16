using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NILS_original
{
    public partial class Student_payement : MetroFramework.Forms.MetroForm
    {
        public Student_payement()
        {
            InitializeComponent();
            metroTabControl.SelectedTab = metroTabPage1;
        }
        Database d = new Database();
        SqlConnection con = new SqlConnection(Credentials.connection);
        private void Student_payement_Load(object sender, EventArgs e)
        {
            set_items_to_items_list("Diploma",items_dip);
            set_items_to_items_list("Certificate", items_certif);
            set_items_to_items_list("other", items_programs_and_workshope);
        }
        List<string> items_dip = new List<string>();
        List<string> items_certif = new List<string>();
        List<string> items_programs_and_workshope = new List<string>();
        public void set_items_to_items_list(string type,List<string> k)
        {
            if (type == "other")
            {
                k.Clear();
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT s.program_no,s.scheduled_date,c.Program_title,s.course_type,s.course_no FROM Session_details s INNER JOIN Short_program_details c ON s.program_no=c.Code WHERE s.course_type='Workshop' OR s.course_type='One-day' OR s.course_type='Two-day'OR s.course_type='Three-day' ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.GetValue(2).ToString() == "None")
                    {
                        k.Add(dr.GetValue(0).ToString() + " - " + dr.GetDateTime(1).ToString("dd/MM/yyy") + " - " + General_methods.get_course_name_from_course_no(dr.GetValue(4).ToString()) + " - " + dr.GetValue(3).ToString());

                    }
                    else
                    {
                        k.Add(dr.GetValue(0).ToString() + " - " + dr.GetDateTime(1).ToString("dd/MM/yyy") + " - " + dr.GetValue(2).ToString() + " - " + dr.GetValue(3).ToString());
                    }
                }
                con.Close();
            }
            else
            {
                k.Clear();
                txt_enter_name.Items.Clear();
                txt_enter_name.Text = "";
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT stud_no,f_name,m_name,l_name,NIC,ref,course_no FROM Stud_details", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (General_methods.get_course_type_from_course_no(dr.GetValue(6).ToString()) == type)
                    {
                        if (dr.IsDBNull(5))
                        {
                            k.Add(dr.GetValue(0).ToString() + " - " + dr.GetValue(1).ToString() + " " + dr.GetValue(2).ToString() + " " + dr.GetValue(3).ToString() + " - " + dr.GetValue(4).ToString());
                        }
                        else
                        {
                            SqlConnection con2 = new SqlConnection(Credentials.connection);
                            SqlCommand cmd2 = new SqlCommand("SELECT f_name,m_name,l_name,NIC,course_no FROM Stud_details WHERE stud_no='" + dr.GetValue(5).ToString() + "'", con2);
                            con2.Open();
                            SqlDataReader dr2 = cmd2.ExecuteReader();
                            dr2.Read();
                            k.Add(dr.GetValue(0).ToString() + " - " + dr2.GetValue(0).ToString() + " " + dr2.GetValue(1).ToString() + " " + dr2.GetValue(2).ToString() + " - " + dr2.GetValue(3).ToString());
                            dr2.Close();
                            con2.Close();
                        }
                    }


                }
                con.Close();
            }
        }

        private void txt_enter_name_TextChanged(object sender, EventArgs e)
        {
            text_change_event_of_combobox(txt_enter_name, items_dip);
        }
        private void txt_enter_name_SelectedIndexChanged(object sender, EventArgs e)
        {

            UC_payments.studno = txt_enter_name.Text.Split('-').GetValue(0).ToString();
            UC_payments u = new UC_payments();
            metroPanel1.Controls.Clear();
            con.Open();
            SqlCommand cmd = new SqlCommand("EXECUTE stud_details_for_payments '"+ txt_enter_name.Text.Split('-').GetValue(0).ToString() + "'",con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            u.txt_studno.Text = dr.GetValue(0).ToString();
            u.txt_studname.Text= dr.GetValue(1).ToString();
            u.txt_course_name.Text= General_methods.get_course_name_from_course_no(dr.GetValue(2).ToString());
            u.txt_batch_no.Text = dr.GetValue(3).ToString();
            u.txt_course_fee_for_full_payament.Text = u.txt_cfee.Text =u.txt_module_pay_course_fee.Text= dr.GetValue(4).ToString()+"/=";
            u.txt_nic.Text = dr.GetValue(5).ToString();
            u.txt_batch_name.Text = General_methods.get_batch_name_from_batch_ne(dr.GetValue(3).ToString());
            General_methods.get_stud_pic(u.pictureBox1, dr.GetValue(0).ToString());
            u.txt_amount_payable.Text = General_methods.calc_amount_payable(txt_enter_name.Text.Split('-').GetValue(0).ToString().ToString(),0,"Diploma").ToString()+"/=";
            u.txt_reg_fee_of_course.Text = dr.GetValue(6).ToString()+"/="; 
            metroPanel1.Controls.Add(u);
            dr.Close();
            con.Close();
            u.label1.TextChanged += handler;

        }

        public void handler(object sender, EventArgs e)
        {
            metroPanel1.Controls.Clear();
            con.Open();
            UC_payments.studno = txt_enter_name.Text.Split('-').GetValue(0).ToString();
            SqlCommand cmd = new SqlCommand("EXECUTE stud_details_for_payments '" + txt_enter_name.Text.Split('-').GetValue(0).ToString() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            UC_payments u = new UC_payments();
            u.txt_studno.Text = dr.GetValue(0).ToString();
            u.txt_studname.Text = dr.GetValue(1).ToString();
            u.txt_course_name.Text = General_methods.get_course_name_from_course_no(dr.GetValue(2).ToString());
            u.txt_batch_no.Text = dr.GetValue(3).ToString();
            u.txt_course_fee_for_full_payament.Text = u.txt_cfee.Text = u.txt_module_pay_course_fee.Text = dr.GetValue(4).ToString() + "/=";
            u.txt_nic.Text = dr.GetValue(5).ToString();
            u.txt_batch_name.Text = General_methods.get_batch_name_from_batch_ne(dr.GetValue(3).ToString());
            General_methods.get_stud_pic(u.pictureBox1, dr.GetValue(0).ToString());
            u.txt_amount_payable.Text = General_methods.calc_amount_payable(txt_enter_name.Text.Split('-').GetValue(0).ToString().ToString(), 0,"Diploma").ToString() + "/=";
            u.txt_reg_fee_of_course.Text = dr.GetValue(6).ToString()+"/=";
            metroPanel1.Controls.Add(u);
            dr.Close();
            con.Close();
            u.label1.TextChanged += handler;

        }

        private void txt_certif_enter_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            UC_payements_certif.studno = txt_certif_enter_name.Text.Split('-').GetValue(0).ToString();
            UC_payements_certif u = new UC_payements_certif();
            metroPanel2.Controls.Clear();
            con.Open();
            SqlCommand cmd = new SqlCommand("EXECUTE stud_details_for_payments '" + txt_certif_enter_name.Text.Split('-').GetValue(0).ToString() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            u.txt_studno.Text = dr.GetValue(0).ToString();
            u.txt_studname.Text = dr.GetValue(1).ToString();
            u.txt_course_name.Text = General_methods.get_course_name_from_course_no(dr.GetValue(2).ToString());
            u.txt_batch_no.Text = dr.GetValue(3).ToString();
            u.txt_reg_fee.Text = u.txt_cfee.Text = u.txt_course_fee.Text = dr.GetValue(4).ToString() + "/=";
            u.txt_nic.Text = dr.GetValue(5).ToString();
            u.txt_batch_name.Text = General_methods.get_batch_name_from_batch_ne(dr.GetValue(3).ToString());
            General_methods.get_stud_pic(u.pictureBox1, dr.GetValue(0).ToString());
            u.txt_amount_payabme.Text = General_methods.calc_amount_payable(txt_certif_enter_name.Text.Split('-').GetValue(0).ToString().ToString(), 0,"Certificate").ToString() + "/=";
            u.txt_reg_fee.Text = dr.GetValue(6).ToString() + "/=";
            metroPanel2.Controls.Add(u);
            dr.Close();
            con.Close();
            u.label1.TextChanged += handler2;

        }
        public void handler2(object sender, EventArgs e)
        {

            UC_payements_certif.studno = txt_certif_enter_name.Text.Split('-').GetValue(0).ToString();
            UC_payements_certif u = new UC_payements_certif();
            metroPanel2.Controls.Clear();
            con.Open();
            SqlCommand cmd = new SqlCommand("EXECUTE stud_details_for_payments '" + txt_certif_enter_name.Text.Split('-').GetValue(0).ToString() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            u.txt_studno.Text = dr.GetValue(0).ToString();
            u.txt_studname.Text = dr.GetValue(1).ToString();
            u.txt_course_name.Text = General_methods.get_course_name_from_course_no(dr.GetValue(2).ToString());
            u.txt_batch_no.Text = dr.GetValue(3).ToString();
            u.txt_reg_fee.Text = u.txt_cfee.Text = u.txt_course_fee.Text = dr.GetValue(4).ToString() + "/=";
            u.txt_nic.Text = dr.GetValue(5).ToString();
            u.txt_batch_name.Text = General_methods.get_batch_name_from_batch_ne(dr.GetValue(3).ToString());
            General_methods.get_stud_pic(u.pictureBox1, dr.GetValue(0).ToString());
            u.txt_amount_payabme.Text = General_methods.calc_amount_payable(txt_certif_enter_name.Text.Split('-').GetValue(0).ToString().ToString(), 0,"Certificate").ToString() + "/=";
            u.txt_reg_fee.Text = dr.GetValue(6).ToString() + "/=";
            metroPanel2.Controls.Add(u);
            dr.Close();
            con.Close();
            u.label1.TextChanged += handler2;

        }

        private void txt_certif_enter_name_TextChanged(object sender, EventArgs e)
        {
            text_change_event_of_combobox(txt_certif_enter_name, items_certif);
        }
        public void text_change_event_of_combobox(ComboBox c,List<string> list)
        {
            int h = c.SelectionStart;
            if (c.SelectedIndex > -1)
            {

            }
            else
            {
                c.Items.Clear();
                foreach (string p in list)
                {
                    if (p.Contains(c.Text))
                    {
                        c.Items.Add(p);
                    }
                    else
                    {

                    }
                }
                c.Update();
                c.SelectionStart = h;
            }
        }
        private void cmb_select_workshops_and_shortprogs_TextChanged(object sender, EventArgs e)
        {
            text_change_event_of_combobox(cmb_select_workshops_and_shortprogs, items_programs_and_workshope);
        }

        private void cmb_select_workshops_and_shortprogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            metroPanel3.Controls.Clear();
            UC_short_payment.progno= cmb_select_workshops_and_shortprogs.Text.Split('-').GetValue(0).ToString();
            UC_short_payment s = new UC_short_payment();
            s.txt_progno.Text = cmb_select_workshops_and_shortprogs.Text.Split('-').GetValue(0).ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT s.program_no,s.scheduled_date,s.course_type,s.venue,c.per_head_price,c.Program_title,s.course_no FROM Session_details s INNER JOIN Short_program_details c ON s.program_no=c.Code WHERE s.program_no= '" + cmb_select_workshops_and_shortprogs.Text.Split('-').GetValue(0).ToString() + "'",con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            s.txt_progno.Text = dr.GetValue(0).ToString();
            s.txt_datw.Text = dr.GetValue(1).ToString();
            s.txt_progtype.Text= dr.GetValue(2).ToString();
            s.txt_venue.Text = dr.GetValue(3).ToString();
            if (dr.GetValue(5).ToString() == "None")
            {
                s.txt_progtitle.Text = General_methods.get_course_name_from_course_no(dr.GetValue(6).ToString());
            }
            else
            {
                s.txt_progtitle.Text = dr.GetValue(5).ToString();
            }
            if (!dr.IsDBNull(4) )
            {
                s.txt_priceperhead.Text = dr.GetValue(4).ToString()+"/=";
            }
            else
            {
                s.txt_priceperhead.Text = "Not yet assigned. To assign price per head, go to manage workshops";
                s.metroPanel2.Enabled = false;
            }
            metroPanel3.Controls.Add(s);
            con.Close();
            s.label1.TextChanged += handler3;

        }
        public void handler3(object sender, EventArgs e)
        {

            metroPanel3.Controls.Clear();
            UC_short_payment.progno = cmb_select_workshops_and_shortprogs.Text.Split('-').GetValue(0).ToString();
            UC_short_payment s = new UC_short_payment();
            s.txt_progno.Text = cmb_select_workshops_and_shortprogs.Text.Split('-').GetValue(0).ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT s.program_no,s.scheduled_date,s.course_type,s.venue,c.per_head_price,c.Program_title,s.course_no FROM Session_details s INNER JOIN Short_program_details c ON s.program_no=c.Code WHERE s.program_no= '" + cmb_select_workshops_and_shortprogs.Text.Split('-').GetValue(0).ToString() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            s.txt_progno.Text = dr.GetValue(0).ToString();
            s.txt_datw.Text = dr.GetValue(1).ToString();
            s.txt_progtype.Text = dr.GetValue(2).ToString();
            s.txt_venue.Text = dr.GetValue(3).ToString();
            if (dr.GetValue(5).ToString() == "None")
            {
                s.txt_progtitle.Text = General_methods.get_course_name_from_course_no(dr.GetValue(6).ToString());
            }
            else
            {
                s.txt_progtitle.Text = dr.GetValue(5).ToString();
            }
            if (!dr.IsDBNull(4))
            {
                s.txt_priceperhead.Text = dr.GetValue(4).ToString() + "/=";
            }
            else
            {
                s.txt_priceperhead.Text = "Not yet assigned. To assign price per head, go to manage workshops";
            }

            metroPanel3.Controls.Add(s);
            con.Close();
            s.label1.TextChanged += handler3;

        }
    }
}
// SqlCommand cmd = new SqlCommand("SELECT s.stud_no,s.name_with_initials,s.course_no,s.batch_no,b.course_fee_for_batch,s.NIC,b.reg_fee_for_batch FROM Stud_details s INNER JOIN Batches b ON s.batch_no=b.Batch_no WHERE s.stud_no='" + txt_enter_name.Text.Split('-').GetValue(0).ToString() + "'", con);
