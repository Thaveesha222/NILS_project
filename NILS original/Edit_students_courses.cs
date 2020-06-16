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
    public partial class Edit_students_courses : MetroFramework.Forms.MetroForm
    {
        public Edit_students_courses()
        {
            InitializeComponent();
        }
        public static string batchno;
        public static string stud_no;
        public static string c_no;

        private void Edit_students_courses_Load(object sender, EventArgs e)
        {

        }

        private void cmb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_batch.DataSource = General_methods.fill_batches_combobox(cmb_type.Text);
            if (cmb_type.SelectedIndex == 0)
            {
                state = false;
            }
            else
            {
                state = true;
            }
        }

        private void cmb_batch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_batch_no.Text = General_methods.get_batch_no_from_batch_name(cmb_batch.Text);
            txt_course_namer.Text = General_methods.get_course_name_from_course_no(General_methods.get_course_no_of_batch_from_batch_no(txt_batch_no.Text));
            cmb_medium.Text = General_methods.get_medium_from_batch_no(txt_batch_no.Text);
            stud_no_change();
        }

        private void stud_no_change()
        {

            Database d3 = new Database();
            SqlConnection con = new SqlConnection(Credentials.connection);
            if (cmb_medium.Text != "")
            {
                if (batchno == txt_batch_no.Text)
                {
                    txt_studno_1.Text = stud_no;
                }
                else
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
                        SqlCommand cmd = new SqlCommand("SELECT stud_no FROM Stud_details WHERE course_no='" + General_methods.get_course_no_from_course_name(txt_course_namer.Text) + "'", con);
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
                        if (General_methods.get_course_no_from_course_name(txt_course_namer.Text) == c_no)
                        {
                            string studno = "D/" + DateTime.Today.Year.ToString().Remove(0, 2) + "/" + d3.singleString("SELECT course_initials FROM Course_details_master WHERE course_no='" + General_methods.get_course_no_from_course_name(txt_course_namer.Text) + "'") + a + "/" + (stud_nos.Max()).ToString();
                            txt_studno_1.Text = studno;
                        }
                        else
                        {
                            string studno = "D/" + DateTime.Today.Year.ToString().Remove(0, 2) + "/" + d3.singleString("SELECT course_initials FROM Course_details_master WHERE course_no='" + General_methods.get_course_no_from_course_name(txt_course_namer.Text) + "'") + a + "/" + (stud_nos.Max()+1).ToString();
                            txt_studno_1.Text = studno;
                        }
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
                        SqlCommand cmd = new SqlCommand("SELECT stud_no FROM Stud_details WHERE course_no='" + General_methods.get_course_no_from_course_name(txt_course_namer.Text) + "'", con);
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
                        if (General_methods.get_course_no_from_course_name(txt_course_namer.Text) == c_no)
                        {
                            string studno = "C/" + DateTime.Today.Year.ToString().Remove(0, 2) + "/" + d3.singleString("SELECT course_initials FROM Course_details_master WHERE course_no='" + General_methods.get_course_no_from_course_name(txt_course_namer.Text) + "'") + a + "/" + (stud_nos.Max()).ToString();
                            txt_studno_1.Text = studno;
                        }
                        else
                        {
                            string studno = "C/" + DateTime.Today.Year.ToString().Remove(0, 2) + "/" + d3.singleString("SELECT course_initials FROM Course_details_master WHERE course_no='" + General_methods.get_course_no_from_course_name(txt_course_namer.Text) + "'") + a + "/" + (stud_nos.Max() + 1).ToString();
                            txt_studno_1.Text = studno;
                        }
                       
                    }
                }
                if (txt_batch_no.Text == batchno && stud_no == txt_studno_1.Text)
                {
                    metroTile5.Enabled = false;
                }
                else
                {
                    metroTile5.Enabled = true;
                }
            }
            else
            {

            }
        }
        public static bool state;
        private void metroTile5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Edit students course details?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Database d = new Database();
                d.update("UPDATE Stud_details SET stud_no='" + txt_studno_1.Text + "',course_no='" + General_methods.get_course_no_from_course_name(txt_course_namer.Text) + "',batch_no='" + txt_batch_no.Text + "',medium='" + cmb_medium.Text + "' WHERE stud_no='" + stud_no + "' ");
                if (d.singleInt("SELECT COUNT(*) FROM Dip_stud_modules WHERE stud_no='" + stud_no + "'") == 1)
                {
                    d.delete("DELETE FROM Dip_stud_modules WHERE stud_no='" + stud_no + "'");
                }
                MessageBox.Show("Successfully Updates Record", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (cmb_type.SelectedIndex == 0)
                {
                    
                    /*Select_modules s = new Select_modules();
                    s.lb_stud_no.Text = txt_studno_1.Text;
                    s.lb_course_no.Text = General_methods.get_course_no_from_course_name(txt_course_namer.Text);
                    s.lb_course_name.Text = txt_course_namer.Text;
                    s.metroTile1.Text = "Add";
                    s.Show();
                    s.metroTile1.Click += handler;*/


                }
                else
                {
                    label1.Text = "";
                    
                }

            }
            else
            {

            }
        }
        private void handler(object sender, EventArgs e)
        {
            label1.Text = "";
            Close();
        }

        private void metroLink2_Click(object sender, EventArgs e)
        {
            Add_new_batch a = new Add_new_batch();
            a.Show();
        }
    }
}
