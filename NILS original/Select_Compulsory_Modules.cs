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
    public partial class Select_Compulsory_Modules : MetroFramework.Forms.MetroForm
    {
        public Select_Compulsory_Modules()
        {
            InitializeComponent();
        }
        public static string course_no="DL-01";
        SqlConnection con = new SqlConnection(Credentials.connection);
        int a;
        private void Select_Compulsory_Modules_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Module_name FROM Dip_module_details_2 WHERE Course_no='" + course_no + "'",con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                checkedListBox1.Items.Add(dr.GetValue(0).ToString());
                a++;
            }
            con.Close();
        }
        Database d = new Database();
        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "" || metroTextBox1.Text.Any(char.IsLetter)||Convert.ToInt32(metroTextBox1.Text)>a)
            {
                MessageBox.Show(this, "Please enter correct amount of minimum modules to be selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    CheckState st = checkedListBox1.GetItemCheckState(i);
                    if (st == CheckState.Checked)
                    {
                        d.update("UPDATE Dip_module_details_2 SET compulsory=1 WHERE Module_id='" + General_methods.get_module_no_from_module_name(checkedListBox1.Items[i].ToString(), course_no) + "'");
                    }
                    else if (st == CheckState.Unchecked)
                    {
                        d.update("UPDATE Dip_module_details_2 SET compulsory=0 WHERE Module_id='" + General_methods.get_module_no_from_module_name(checkedListBox1.Items[i].ToString(), course_no) + "'");
                    }
                }
                d.update("UPDATE Course_details_master SET No_of_modules_to_be_selected='" + metroTextBox1.Text + "'WHERE course_no='" + course_no + "'");
                MessageBox.Show(this, "Successfully created compulsory courses", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
