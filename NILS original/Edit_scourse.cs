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
    public partial class Edit_scourse : MetroFramework.Forms.MetroForm
    {
        public Edit_scourse()
        {
            InitializeComponent();
        }

        private void Edit_scourse_Load(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            Edit_course_fee e1 = new Edit_course_fee();
            Edit_course_fee.cno = lbl_cno_1.Text;
            e1.Show();
        }

        private void metroLink2_Click(object sender, EventArgs e)
        {
            Edit_reg_fee r = new Edit_reg_fee();
            Edit_reg_fee.cno = lbl_cno_1.Text;
            r.Show();
        }
    }
}
