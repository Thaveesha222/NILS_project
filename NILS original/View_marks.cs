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
    public partial class View_marks : MetroFramework.Forms.MetroForm
    {
        public View_marks()
        {
            InitializeComponent();
        }

        private void View_marks_Load(object sender, EventArgs e)
        {
            Database d = new Database();
            metroGrid1.DataSource= d.show("select * from Dip_stud_marks where stud_no='" + Student_profiles.no + "'");

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
