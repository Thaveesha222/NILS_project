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
    public partial class Edit_reg_fee : MetroFramework.Forms.MetroForm
    {
        public Edit_reg_fee()
        {
            InitializeComponent();
        }

        private void Edit_reg_fee_Load(object sender, EventArgs e)
        {

        }
        public static string cno;
        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "" || metroTextBox1.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Please enter correct course fee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Database d = new Database();
                d.update("UPDATE Course_details_master SET reg_fee='" + metroTextBox1.Text + "' WHERE course_no='" + cno + "'");
                MessageBox.Show("Registration fee updated successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Dispose();
            }
        }
    }
}
