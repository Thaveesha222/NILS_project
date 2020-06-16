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
    public partial class show_studs : MetroFramework.Forms.MetroForm
    {
        public show_studs()
        {
            InitializeComponent();
        }
        public static string pay_no;
        private void show_studs_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Credentials.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Name,ref_no  FROM Short_program_participation WHERE payment_no ='" + pay_no+"'",con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                listView1.Items.Add(dr.GetValue(0).ToString()+" - "+dr.GetValue(1).ToString());
            }
            con.Close();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
