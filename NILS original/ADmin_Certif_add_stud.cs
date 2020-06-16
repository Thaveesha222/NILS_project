using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace NILS_original
{
    public partial class ADmin_Certif_add_stud : MetroFramework.Forms.MetroForm
    {
        public ADmin_Certif_add_stud()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server=tcp:nibm.database.windows.net,1433;Initial Catalog=NILS(cloud);Persist Security Info=False;User ID=mohan;Password=9775KGCXxTo#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            SqlCommand cmd1 = new SqlCommand(("SELECT course_name FROM certif_course_details"), con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            int count = 0;
            string[] name = new string[100];
            while (dr1.Read())
            {
                name[count] = Convert.ToString(dr1.GetValue(0));
                count++;
            }
            cmb_course_1.DataSource = name;
            dr1.Close();
        }

        private void til_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_firstname.Text) || txt_firstname.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Please enter correct First name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txt_lname.Text) || txt_lname.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Please enter correct Last name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txt_desig.Text) || txt_desig.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Please enter valid Designation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txt_mobile.Text) || txt_desig.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Please enter valid mobile number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_office_tel_1.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Please enter valid Telephone number(1)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_office_tel_2.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Please enter valid Telephone number(2)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_residence_tel.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Please enter valid Residence Telephone number(1)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Database d1 = new Database();
                dataGridView1.DataSource = d1.show("SELECT * FROM Dip_stud_details");
            }
        }
    }
}
