using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NILS_original
{
    static class openMainform
    {
        static MainForm m = new MainForm();
        public static  void openform()
        {           
            m.Show();
        }
        public static void hide()
        {
            m.WindowState= FormWindowState.Minimized;
        }
        public static void show()
        {
            m.Show();
        }
        public static void open(Admin_Dip_add_stud f)
        {
            f = new Admin_Dip_add_stud();
            f.Show();
        }
    }
}
