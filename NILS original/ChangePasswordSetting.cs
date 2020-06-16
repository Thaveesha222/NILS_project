using MetroFramework;
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
    public partial class ChangePasswordSetting : Form
    {
        public ChangePasswordSetting()
        {
            InitializeComponent();
            txtNewPwd.UseSystemPasswordChar = true;
            txtConPwd.UseSystemPasswordChar = true;
            if(nm==0)
            {
                panelExpired.Visible = false;
            }
        
        }
        Database db = new Database();
        string name = Login.name;
        string pwd = Login.pwd;
        int nm=Login.no;
       
        private void btnShow1_Click(object sender, EventArgs e)
        {
            txtNewPwd.UseSystemPasswordChar = false;
        }

        private void btnShow2_Click(object sender, EventArgs e)
        {
            txtConPwd.UseSystemPasswordChar = false;
        }

        private void btnShow1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void lblSkip_Click(object sender, EventArgs e)
        {
            DialogResult dialgReslt = MetroMessageBox.Show(this, "Do you want to Skip Now ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialgReslt.ToString() == "Yes")
            {
                this.Close();
                MainForm mf = new MainForm();
                mf.Show();
                
            } 

        }

        private void btnChngPwd_Click(object sender, EventArgs e)
        {
            if(nm==0)
            {
                MetroMessageBox.Show(this, "You^ve reached the max confirmation attempts.\n Try again later. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (txtCurrentPwd.Text == pwd)
            {
                if (txtNewPwd.Text == txtConPwd.Text)
                {
                    db.insert("UPDATE UserAccountDetails SET Password='" + txtNewPwd.Text + "',ChangePassword ='0' WHERE UserId='" + Login.id + "' ");
                    MetroMessageBox.Show(this, "Your password has been changed ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    /*if(Login.usertype=="student")
                    {
                        Class_student.studno = Login.ref_no;
                        LMS l = new LMS();
                        l.Show();
                    }
                    else if(Login.usertype=="Lecturer")
                    {
                        Lec_class.Lecno = Login.ref_no;
                        Lec_home l = new Lec_home();
                        l.Show();
                    }
                    else
                    {
                        MainForm f = new MainForm();
                        MainForm.time = DateTime.Now.ToShortTimeString().ToString();
                        MainForm.userid = Login.id;
                    }*/
                    this.Dispose();
                    Login l = new Login();
                    l.Show();
                }
                else
                {
                    MetroMessageBox.Show(this, "Your New password mismatch with your entered password. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Your current password mismatch with your entered password. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCurrentPwd_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPwd.Text) == true)
            {
                txtCurrentPwd.Focus();
                errorProvider1.SetError(this.txtCurrentPwd, "Please Enter your current Password. ");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtNewPwd_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPwd.Text) == true)
            {
                txtNewPwd.Focus();
                errorProvider2.SetError(this.txtNewPwd, "Please Enter your new Password. ");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void txtConPwd_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtConPwd.Text) == true)
            {
                txtConPwd.Focus();
                errorProvider3.SetError(this.txtConPwd, "Please Enter your confirm Password. ");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
