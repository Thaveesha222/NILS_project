using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MetroFramework;

namespace NILS_original
{
    public partial class MainInterface : Form
    {
        public MainInterface()
        {
            InitializeComponent();
        
        }
        
        public string defaultvalue;
        private void metroButtonEmp_Click(object sender, EventArgs e)
        {
            Login.type = "admin";
            Login lg = new Login();
            defaultvalue = Interaction.InputBox("Access to Employee Login ", "Please enter the passcode ?", defaultvalue);
            try {
                if (Convert.ToInt32(defaultvalue) ==1596)
                { this.Hide();
                    lg.Show();
                  
                }
                else if (defaultvalue == "")
                {
                    MetroMessageBox.Show(this, "Please enter Your passcode ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MetroMessageBox.Show(this, "Please enter correct format ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception)
            {
                MetroMessageBox.Show(this, "Please enter correct format ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
          
        }

        private void metroButtonStud_Click(object sender, EventArgs e)
        {
            Login.type = "Student";
            Login lg = new Login();
            this.Hide();
            lg.Show();
            lg.link_forgetPwd.Hide();
           
        }

        private void lbl_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButtonLect_Click(object sender, EventArgs e)
        {
            Login.type = "Lecturer";
            Login lg = new Login();
            this.Hide();
            lg.Show();
            lg.link_forgetPwd.Hide();
            
        }
    }
}
