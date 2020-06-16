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
    public partial class Module_selection : MetroFramework.Forms.MetroForm
    {
        public Module_selection()
        {
            InitializeComponent();
            checkedListBox1.CheckOnClick = true;
        }
        SqlConnection con = new SqlConnection(Credentials.connection);
        Database d = new Database();
        List<int> a=new List<int>();
        public static bool state=false;
        private void Module_selection_Load(object sender, EventArgs e)
        {
            if (state == false)
            {
                
                lbl_course_name.Text = General_methods.get_course_name_from_course_no(lbl_course_no.Text);
                lbl_min_mods.Text = d.singleString("SELECT No_of_modules_to_be_selected FROM Course_details_master WHERE course_no='" + lbl_course_no.Text + "'");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Module_name,compulsory FROM Dip_module_details_2 WHERE Course_no='" + lbl_course_no.Text + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    checkedListBox1.Items.Add(dr.GetValue(0).ToString());
                    if (dr.GetBoolean(1) == true)
                    {
                        checkedListBox1.SetItemChecked(i, true);
                        a.Add(i);
                    }
                    else
                    {
                        checkedListBox1.SetItemChecked(i, false);
                    }
                    i++;
                }
                con.Close();
            }
            else
            {

                lbl_course_name.Text = General_methods.get_course_name_from_course_no(lbl_course_no.Text);
                lbl_min_mods.Text = d.singleString("SELECT No_of_modules_to_be_selected FROM Course_details_master WHERE course_no='" + lbl_course_no.Text + "'");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Module_name,compulsory FROM Dip_module_details_2 WHERE Course_no='" + lbl_course_no.Text + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    checkedListBox1.Items.Add(dr.GetValue(0).ToString());
                    if (dr.GetBoolean(1) == true)
                    {
                        checkedListBox1.SetItemChecked(i, true);
                        a.Add(i);
                    }
                   
                 
                    if (d.singleInt("SELECT COUNT(*) FROM Dip_stud_modules WHERE stud_no='" + lbl_stud_no.Text + "' AND module_no='" + General_methods.get_module_no_from_module_name(dr.GetValue(0).ToString(), lbl_course_no.Text) + "'") != 0)
                    {
                        checkedListBox1.SetItemChecked(i, true);
                    }
                    else
                    {
                        checkedListBox1.SetItemChecked(i, false);
                    }
                    i++;
                }
                con.Close();
            }
        }
        public void set()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT module_no FROM Dip_stud_modules WHERE stud_no='"+lbl_stud_no.Text+"'");
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

            }
        }
        private void lbl_stud_no_Click(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (metroTile1.Text == "Confirm and Add")
            {
                int count = 0;
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    CheckState st = checkedListBox1.GetItemCheckState(i);
                    if (st == CheckState.Checked)
                    {
                        count++;
                    }
                }
                if (count != Convert.ToInt32(lbl_min_mods.Text))
                {
                    MessageBox.Show(this, "Please select " + lbl_min_mods.Text + " modules", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        CheckState st = checkedListBox1.GetItemCheckState(i);
                        if (st == CheckState.Checked)
                        {
                            d.insert("INSERT INTO Dip_stud_modules (stud_no,module_no) VALUES ('" + lbl_stud_no.Text + "','" + General_methods.get_module_no_from_module_name(checkedListBox1.Items[i].ToString(), lbl_course_no.Text) + "')");
                        }

                    }
                    MessageBox.Show(this, "Successfully added modules of student", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                int count = 0;
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    CheckState st = checkedListBox1.GetItemCheckState(i);
                    if (st == CheckState.Checked)
                    {
                        count++;
                    }
                }
                if (count != Convert.ToInt32(lbl_min_mods.Text))
                {
                    MessageBox.Show(this, "Please select " + lbl_min_mods.Text + " modules", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    d.delete("DELETE FROM Dip_stud_modules WHERE stud_no='" + lbl_stud_no.Text + "'");
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        CheckState st = checkedListBox1.GetItemCheckState(i);
                        if (st == CheckState.Checked)
                        {
                            d.insert("INSERT INTO Dip_stud_modules (stud_no,module_no) VALUES ('" + lbl_stud_no.Text + "','" + General_methods.get_module_no_from_module_name(checkedListBox1.Items[i].ToString(), lbl_course_no.Text) + "')");
                        }

                    }
                    MessageBox.Show(this, "Successfully added modules of student", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void checkedListBox1_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            if (a.Contains(e.Index)) e.NewValue = e.CurrentValue;
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
