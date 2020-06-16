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
    public partial class Edit_lec_details : MetroFramework.Forms.MetroForm
    {
        public string no;
        public Edit_lec_details()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Credentials.connection);
        private void Edit_lec_details_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT NIC,F_name,L_name,mobile_no_1,tel_no,email,address,Name_with_initals,Birthdate,Gender,language,contact FROM Lecture_details WHERE Lecturer_no='"+no+"'",con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            txt_lecno.Text = no;
            txt_nic.Text = dr.GetValue(0).ToString();
            txt_fname.Text = dr.GetValue(1).ToString();
            txt_lname.Text = dr.GetValue(2).ToString();
            txt_mobno2.Text = dr.GetValue(3).ToString();
            txt_telno.Text = dr.GetValue(4).ToString();
            txt_email.Text = dr.GetValue(5).ToString();
            txt_address.Text = dr.GetValue(6).ToString();
            txt_namewithintilals.Text = dr.GetValue(7).ToString();
            txt_bday.Value = dr.GetDateTime(8);
            txt_gender.Text = dr.GetValue(9).ToString();
            txt_lang.Text= dr.GetValue(10).ToString();
            txt_contact.Text = dr.GetValue(11).ToString();
            

            List<string> v= d.selectStringArray("SELECT specific_area FROM Rp_selected_specific_areas WHERE Lec_no = '" + no + "'").ToList() ;
            
            string[] a =d.selectStringArray("SELECT area FROM Lec_specific_areas");
            int c = 0;
            while (c < a.Length)
            {
                checkedListBox1.Items.Add(a[c], false);
                c++;
            }
            c = 0;          
            while (c < a.Length)
            {
                if (v.Contains(a[c]))
                {
                    checkedListBox1.SetItemChecked(c, true);
                }
                c++;
            }




        }
        Database d = new Database();
        public void setcmblang(String a,MetroFramework.Controls.MetroComboBox comboBox)
        {
            
                
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
