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
    public partial class view_payements_certif : MetroFramework.Forms.MetroForm
    {
        public view_payements_certif()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Credentials.connection);
        private void view_payements_certif_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Certif_payement_details WHERE stud_no='" + Student_profiles.no + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.GetValue(1).Equals(false))
            {
                metroLabel10.Text = "Payement Due";
                metroPanel1.BackColor = Color.Red;
            }
            else
            {
                metroLabel10.Text = "Payement done";
                metroPanel1.BackColor = Color.Green;
            }
            if (dr.GetValue(2).Equals(false))
            {
                metroLabel2.Text = "Payement Due";
                metroPanel2.BackColor = Color.Red;
            }
            else
            {
                metroLabel2.Text = "Payement done";
                metroPanel2.BackColor = Color.Green;
            }

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
