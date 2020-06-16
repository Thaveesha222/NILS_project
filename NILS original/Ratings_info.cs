using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NILS_original
{
    public partial class Ratings_info : MetroFramework.Forms.MetroForm
    {
        public Ratings_info()
        {
            InitializeComponent();
        }
     
        private void Ratings_info_Load(object sender, EventArgs e)
        {
            Database d = new Database();
            int x=d.singleInt("SELECT display_rating_box  FROM Rating_box_show WHERE Session_no='" + metroLabel2.Text + "' ");
            if(x==1)
            {
                metroCheckBox1.Checked = true;
            }
            else
            {
                metroCheckBox1.Checked = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            Database d = new Database();
            if (metroCheckBox1.Checked == false)
            {
                d.update("UPDATE Rating_box_show SET display_rating_box='False' WHERE Session_no='" + metroLabel2.Text + "'");
            }
            else
            {
                d.update("UPDATE Rating_box_show SET display_rating_box='True' WHERE Session_no='" + metroLabel2.Text + "'");

            }
            
            Close();
        }
    }
}
