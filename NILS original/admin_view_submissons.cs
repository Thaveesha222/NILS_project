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
    public partial class admin_view_submissons : MetroFramework.Forms.MetroForm
    {
        public static string no;
        public admin_view_submissons()
        {
            InitializeComponent();
        }

        private void admin_view_submissons_Load(object sender, EventArgs e)
        {
            Database d = new Database();
            metroGrid1.DataSource = d.show("SELECT stud_no,assign_name,submit_date_time,submission_status FROM Submissions_log WHERE FolderId='" + no + "'");
        }
    }
}
