using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using MetroFramework;

namespace NILS_original
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
          
            InitializeComponent();
            panel_loader.Visible = false;
            //  onlineUser = db.selectStringArray("SELECT UserAccountDetails.Name FROM UsersLogDetails INNER JOIN UserAccountDetails ON UsersLogDetails.UserId=UserAccountDetails.UserId WHERE UsersLogDetails.Action2 NOT IN('Logged out')");
            picBxUser.Image = Login.pic;
            if(utype=="admin" || utype == "Admin")
            {

            }
            if(utype== "Course Director")
            {
                button19.Enabled = false;
            }
            if (utype == "Director")
            {
                button19.Enabled = false;
            }
        }
        //StudentDetailsForm stdD = new StudentDetailsForm();
        ChangePasswordSetting chngpwd = new ChangePasswordSetting();
        Login lg = new Login();
        Database db = new Database();
        Login LG = new Login();
        public string stud_id =Login.id ;
        public static string time ;
        public string utype = Login.usertype;
        int i;
        ToolTip t1 = new ToolTip();
        public void circularMethod()
        {
            panel_loader.Visible = true;
            panel5.Visible = false;
          //  stdD.Controls.Clear();
            //chngpwd.Controls.Clear();
            panel4.Controls.Clear();
            panel4.Controls.Add(panel_loader);
            for (i = 1; i <= 100; i++)
            {

                Thread.Sleep(5);
                circularProgressBar1.Value = i;
                circularProgressBar1.Update();
                circularProgressBar1.Text = Convert.ToString(i);

            }

        }
      

        private void Form1_Load(object sender, EventArgs e)
        {
            lblName.Text = Login.name;
            lblemail.Text = Login.email;
            panel_loader.Visible = false;
            //  for (int x = 0; x > 100; x++)
            
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
       
        private void btnStud_Click(object sender, EventArgs e)//create Account
        {
            //panelSelect.Height = btnStud.Height;
            //panelSelect.Top = btnStud.Top;
            circularMethod();
            if (circularProgressBar1.Value == 100)
            {
                panel_loader.Controls.Clear();
               // panel_loader.Controls.Add(new UC_selectStudentcs());
            }
           // panel4.Controls.Clear();
           // panel_loader.Visible = true;
        }

       /* private void btnStudDetail_Click(object sender, EventArgs e)
        {
           panelSelect.Height = btnStudDetail.Height;
            panelSelect.Top = btnStudDetail.Top;
            circularMethod();
            if (circularProgressBar1.Value == 100)
            {
                panel_loader.Controls.Clear();
                panel_loader.Controls.Add(new UC_StudentDetail());
            }
        }*
     
       /* private void btnNotifi_Click(object sender, EventArgs e)
        {
            panelSelect.Height = btnNotifi.Height;
            panelSelect.Top = btnNotifi.Top;
            circularMethod();
            if (circularProgressBar1.Value == 100)
            {
                panel_loader.Controls.Clear();
                panel_loader.Controls.Add(new UC_Notification());
            }
        }*/

        private void btnPaymnt_Click(object sender, EventArgs e)
        {
           
        }

        private void btnResource_Click(object sender, EventArgs e)
        {
        }

        /*private void btnReport_Click(object sender, EventArgs e)
        {
            panelSelect.Height = btnReport.Height;
            panelSelect.Top = btnReport.Top;
            circularMethod();
            if (circularProgressBar1.Value == 100)
            {
                panel_loader.Controls.Clear();
                panel_loader.Controls.Add(new UC_Report());
            }
        }*/

        private void panelSelect_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //panel3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //panel3.Visible = true;
        }


        public static string userid;
        private void button9_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string current1 = now.ToShortDateString();
            string time1 = now.ToShortTimeString();
            DateTime dt = Convert.ToDateTime(current1);
            DateTime tm = Convert.ToDateTime(time1);

            try
            {
                DialogResult dialgReslt = MessageBox.Show(this, "Do you want to loggout Now ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialgReslt.ToString() == "Yes")
                {

                    db.insert("UPDATE UsersLogDetails SET LogoutDate='" + dt + "',LogoutTime='" + tm + "',Action2='Logged Out' WHERE UserId='" + userid + "' and LogTime='" + time + "' ");
                    circularMethod();
                    this.Close();
                    LG.Show();

                }
            }
            catch (SqlException)
            {
                MessageBox.Show(this, "Database not connected ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Not error with query ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            

        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            //t1.Show("Send Notification about Student payment ", button5);
        }

       /* private void button8_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Student Details Report\n Lecturer Details Report\n Payment Report\n Monthly Program Details Report ", btnReport);
        }*/

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            circularMethod();
            if (circularProgressBar1.Value == 100)
            {
                panel_loader.Controls.Clear();
              //  panel_loader.Controls.Add(new UC_LogHistory());
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            circularMethod();
            if (circularProgressBar1.Value == 100)
            {
                panel_loader.Controls.Clear();
                panel_loader.BackColor = Color.WhiteSmoke;
                //panel_loader.Controls.Add(new UC_ChangePassword());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Student_payement sp = new Student_payement();
            sp.Show();
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
        }

        private void picBxUser_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*PermissionLetter pmL = new PermissionLetter();
            pmL.Show();*/
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

            openMainform.open(new Admin_Dip_add_stud());
                      
        }
        
        private void button14_Click(object sender, EventArgs e)
        {
            /*Admin_Update_Program a = new Admin_Update_Program();
            a.Show();*/
            Add_new_session a = new Add_new_session();
            a.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Add_new_lecturer_csv c = new Add_new_lecturer_csv();
            c.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //Session_details_report s = new Session_details_report();
            //s.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //Form3 f = new Form3();
            //f.Show();
        }

        private void btnRprt_Click(object sender, EventArgs e)
        {
            /*Course_participation_report c = new Course_participation_report();
            c.Show();*/
            //Reports r = new Reports();
            // r.Show();
            Reports r = new Reports();
            r.Show();
          
        }

        private void button12_Click(object sender, EventArgs e)
        {
            /*Form2 f = new Form2();
            f.Show();*/
        }

        private void button15_Click(object sender, EventArgs e)
        {
            View_lec_doc v = new View_lec_doc();
            v.Show();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*Accounts_manage a = new Accounts_manage();
            a.Show();*/
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Student_profiles c = new Student_profiles();
            c.Show();
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //Short_Programs_participation_report s = new Short_Programs_participation_report();
            //s.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Short_program_participation_report_2 s = new Short_program_participation_report_2();
            //s.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Add_lecturer a = new Add_lecturer();
            a.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Course_details c = new Course_details();
            c.Show();
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Search_criteria s = new Search_criteria();
            s.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Manage_workshops_and_short_programs m = new Manage_workshops_and_short_programs();
            m.Show();
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
