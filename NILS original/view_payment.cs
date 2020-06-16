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
    public partial class view_payment : MetroFramework.Forms.MetroForm
    {
        public view_payment()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Credentials.connection);
        private void view_payment_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Dip_payement_details WHERE stud_no='" + Student_profiles.no + "'",con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if(dr.GetValue(1).Equals(false))
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
                metroLabel11.Text = "Payement Due";
                metroPanel2.BackColor = Color.Red;
            }
            else
            {
                metroLabel11.Text = "Payement done";
                metroPanel2.BackColor = Color.Green;
            }
            if (dr.GetValue(3).Equals(false))
            {
                metroLabel12.Text = "Payement Due";
                metroPanel3.BackColor = Color.Red;
            }
            else
            {
                metroLabel12.Text = "Payement done";
                metroPanel3.BackColor = Color.Green;
            }
            if (dr.GetValue(4).Equals(false))
            {
                metroLabel13.Text = "Payement Due";
                metroPanel4.BackColor = Color.Red;
            }
            else
            {
                metroLabel13.Text = "Payement done";
                metroPanel4.BackColor = Color.Green;
            }
            if (dr.GetValue(5).Equals(false))
            {
                metroLabel14.Text = "Payement Due";
                metroPanel5.BackColor = Color.Red;
            }
            else
            {
                metroLabel14.Text = "Payement done";
                metroPanel5.BackColor = Color.Green;
            }
            if (dr.GetValue(6).Equals(false))
            {
                metroLabel15.Text = "Payement Due";
                metroPanel6.BackColor = Color.Red;
            }
            else
            {
                metroLabel15.Text = "Payement done";
                metroPanel6.BackColor = Color.Green;
            }
            if (dr.GetValue(7).Equals(false))
            {
                metroLabel16.Text = "Payement Due";
                panel1.BackColor = Color.Red;
            }
            else
            {
                metroLabel16.Text = "Payement done";
                panel1.BackColor = Color.Green;
            }
            if (dr.GetValue(8).Equals(false))
            {
                metroLabel17.Text = "Payement Due";
                panel2.BackColor = Color.Red;
            }
            else
            {
                metroLabel17.Text = "Payement done";
                panel2.BackColor = Color.Green;
            }
            if (dr.GetValue(9).Equals(false))
            {
                metroLabel18.Text = "Payement Due";
                panel3.BackColor = Color.Red;
            }
            else
            {
                metroLabel18.Text = "Payement done";
                panel3.BackColor = Color.Green;
            }
            con.Close();
        }

        private void metroLabel13_Click(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
