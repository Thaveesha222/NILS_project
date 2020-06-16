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
    public partial class Certifs_view : MetroFramework.Forms.MetroForm
    {
        public Certifs_view()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Credentials.connection);
        private void Certifs_view_Load(object sender, EventArgs e)
        {

            Database d1 = new Database();
            int count = d1.singleInt("SELECT COUNT(*)  FROM Dip_module_details_2 WHERE Course_no='" + Student_profiles.cno + "'");
            con.Open();
            if (count > 7)
            { 
            SqlCommand cmd = new SqlCommand("SELECT mod1,mod2,mod3,mod4,mod5,mod6,mod7,mod8 FROM Dip_stud_modules WHERE stud_no='" + Student_profiles.no + "' ",con);
            SqlDataReader r = cmd.ExecuteReader();
            r.Read();
            mod1_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(0).ToString());
            mod2_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(1).ToString());
            mod3_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(2).ToString());
            mod4_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(3).ToString());
            mod5_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(4).ToString());
            mod6_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(5).ToString());
            mod7_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(6).ToString());
            mod8_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(7).ToString());
                r.Close();
            }
            else if(count>6)
            {
                SqlCommand cmd = new SqlCommand("SELECT mod1,mod2,mod3,mod4,mod5,mod6,mod7 FROM Dip_stud_modules WHERE stud_no='" + Student_profiles.no + "' ",con);
                SqlDataReader r = cmd.ExecuteReader();
                r.Read();
                mod1_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(0).ToString());
                mod2_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(1).ToString());
                mod3_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(2).ToString());
                mod4_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(3).ToString());
                mod5_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(4).ToString());
                mod6_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(5).ToString());
                mod7_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(6).ToString());
                mod8_nam.Text = "";
                r.Close();
            }
            else if (count > 5)
            {
                SqlCommand cmd = new SqlCommand("SELECT mod1,mod2,mod3,mod4,mod5,mod6 FROM Dip_stud_modules WHERE stud_no='" + Student_profiles.no + "' ",con);
                SqlDataReader r = cmd.ExecuteReader();
                r.Read();
                mod1_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(0).ToString());
                mod2_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(1).ToString());
                mod3_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(2).ToString());
                mod4_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(3).ToString());
                mod5_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(4).ToString());
                mod6_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(5).ToString());
                mod7_nam.Text = "";
                mod8_nam.Text = "";
                r.Close();
            }
            else if (count > 4)
            {
                SqlCommand cmd = new SqlCommand("SELECT mod1,mod2,mod3,mod4,mod5 FROM Dip_stud_modules WHERE stud_no='" + Student_profiles.no + "' ",con);
                SqlDataReader r = cmd.ExecuteReader();
                r.Read();
                mod1_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(0).ToString());
                mod2_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(1).ToString());
                mod3_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(2).ToString());
                mod4_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(3).ToString());
                mod5_nam.Text = General_methods.get_module_name_from_module_no(r.GetValue(4).ToString());
                mod6_nam.Text = "";
                mod7_nam.Text = "";
                mod8_nam.Text = "";
                r.Close();
            }
            
            SqlCommand cmd1 = new SqlCommand("SELECT mod1,mod2,mod3,mod4,mod5,mod6,mod7,mod8 FROM Dip_stud_certifs WHERE stud_no='" + Student_profiles.no + "'",con);
            SqlDataReader dr = cmd1.ExecuteReader();
            dr.Read();
           // MessageBox.Show(dr.GetValue(0).ToString());
            if (count > 7)
            {
                mod1_stat.Text = set(dr.GetValue(0).ToString());
                mod2_stat.Text = set(dr.GetValue(1).ToString());
                mod3_stat.Text = set(dr.GetValue(2).ToString());
                mod4_stat.Text = set(dr.GetValue(3).ToString());
                mod5_stat.Text = set(dr.GetValue(4).ToString());
                mod6_stat.Text = set(dr.GetValue(5).ToString());
                mod7_stat.Text = set(dr.GetValue(6).ToString());
                mod8_stat.Text = set(dr.GetValue(7).ToString());
            }
            else if (count > 6)
            {
                mod1_stat.Text = set(dr.GetValue(0).ToString());
                mod2_stat.Text = set(dr.GetValue(1).ToString());
                mod3_stat.Text = set(dr.GetValue(2).ToString());
                mod4_stat.Text = set(dr.GetValue(3).ToString());
                mod5_stat.Text = set(dr.GetValue(4).ToString());
                mod6_stat.Text = set(dr.GetValue(5).ToString());
                mod7_stat.Text = set(dr.GetValue(6).ToString());
                mod8_stat.Text = "";
            }
            else if (count > 5)
            {
                mod1_stat.Text = set(dr.GetValue(0).ToString());
                mod2_stat.Text = set(dr.GetValue(1).ToString());
                mod3_stat.Text = set(dr.GetValue(2).ToString());
                mod4_stat.Text = set(dr.GetValue(3).ToString());
                mod5_stat.Text = set(dr.GetValue(4).ToString());
                mod6_stat.Text = set(dr.GetValue(5).ToString());
                mod7_stat.Text = "";
                mod8_stat.Text = "";
            }
            else if (count > 4)
            {
                mod1_stat.Text = set(dr.GetValue(0).ToString());
                mod2_stat.Text = set(dr.GetValue(1).ToString());
                mod3_stat.Text = set(dr.GetValue(2).ToString());
                mod4_stat.Text = set(dr.GetValue(3).ToString());
                mod5_stat.Text = set(dr.GetValue(4).ToString());
                mod6_stat.Text = "";
                mod7_stat.Text = "";
                mod8_stat.Text = "";
            }
        }
        public string set(string g)
        {
            if(g=="False")
            {
                return "Certificate not issued";
            }
            else
            {
                return "Certificate issued";
            }
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
