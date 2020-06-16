using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NILS_original
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            log_type.Text = type;
        }
        Database db = new Database();
        SqlConnection con = new SqlConnection(Credentials.connection);

        public static string name;
        public static string id;
        public static string username;
        public static string email;
        public static string time;
        public static string pwd;
        public static string usertype;
        public static int no,a;
        public static string ref_no;


        private void uC_StudentDetail1_Load(object sender, EventArgs e)
        {

        }
        /*public void login()
            {
           try
            {
                DateTime now = DateTime.Now;
                db.insert("INSERT INTO UsersLogDetails(LogID,UserId,LogDate,LogTime,Action1) VALUES('" + a + "','" + id + "','" + now.ToShortDateString() + "','" + now.ToShortTimeString() + "','Logged In')");
                this.Hide();
                if (no == 0)
                {
                    ChangePasswordSetting chngstng = new ChangePasswordSetting();

                }
                else if (no == 1)
                {
                    ChangePasswordSetting chngstng = new ChangePasswordSetting();
                    chngstng.Show();
                }
            }
            catch
            {
                MetroMessageBox.Show(this, "Database not Connected please try again ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/
        private void lbl_close_Click(object sender, EventArgs e)
        {
            this.Close();
            MainInterface mif = new MainInterface();
            mif.Show();
        }

        private void link_forgetPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel2.Controls.Clear();
            //panel2.Controls.Add(new UC_ForgetPassword());
        }
        public static string type;
        private void btn_login_Click(object sender, EventArgs e)
        {
            //try
            {
                con.Open();
                Database d = new Database();
                DataTable unames=null ;
                DataTable pwords=null;

                if(type=="Student")
                {
                     unames = d.show("SELECT Username FROM UserAccountDetails WHERE UserType='student'");
                     pwords = d.show("SELECT Password FROM UserAccountDetails WHERE UserType='student'");
                }
                else if(type== "Lecturer")
                {
                     unames = d.show("SELECT Username FROM UserAccountDetails WHERE UserType='Lecturer'");
                     pwords = d.show("SELECT Password FROM UserAccountDetails WHERE UserType='Lecturer'");
                }
                else if(type=="admin")
                {
                     unames = d.show("SELECT Username FROM UserAccountDetails WHERE UserType!='Lecturer' AND UserType!='student'");
                     pwords = d.show("SELECT Password FROM UserAccountDetails WHERE UserType!='Lecturer' AND UserType!='student'");
                }
                bool contains = unames.AsEnumerable().Any(row => txt_Username.Text == row.Field<String>("Username"));
                bool contains2 = pwords.AsEnumerable().Any(row => txt_pwd.Text == row.Field<String>("Password"));
                if (contains == false && contains2 == false)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Username or Password Incorrect", "Error");
                }
                else if (contains == true && contains2 == false)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Username or Password Incorrect", "Error");
                }
                else if (contains == false && contains2 == true)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Username or Password Incorrect", "Error");
                }
                else
                {
                    string check = d.singleString("SELECT Enable_disable FROM UserAccountDetails WHERE Username='" + txt_Username.Text + "' AND Password='" + txt_pwd.Text + "'");
                    if (check == "True")
                    {
                        SqlCommand cmd = new SqlCommand("SELECT UserId,ref_no,UserType,Username,Password,ChangePassword FROM UserAccountDetails WHERE Username='" + txt_Username.Text + "' AND Password='" + txt_pwd.Text + "'", con);
                        SqlDataReader r = cmd.ExecuteReader();
                        r.Read();
                        Lec_class.Lecno= ref_no = Convert.ToString(r.GetValue(1));
                        id = Convert.ToString(r.GetValue(0));
                        usertype = Convert.ToString(r.GetValue(2));
                        username = Convert.ToString(r.GetValue(3));
                        pwd = Convert.ToString(r.GetValue(4));
                        no = Convert.ToInt32(r.GetValue(5));
                        r.Close();
                        proPicLoad();
                        a = db.singleInt("SELECT TOP 1 * FROM UsersLogDetails ORDER BY LogID DESC");
                        a ++;
                        //no = db.singleInt("SELECT ChangePassword FROM UserAccountDetails WHERE Name='" + name + "' ");
                        if (username == txt_Username.Text && pwd == txt_pwd.Text)
                        {
                            if (usertype == "student")
                            {
                                try
                                {
                                    DateTime now = DateTime.Now;
                                    /*LMS.userid = id;
                                    LMS.time = now.ToShortTimeString();*/
                                    this.Hide();
                                    if (no == 0)
                                    {
                                        db.insert("INSERT INTO UsersLogDetails(LogID,UserId,LogDate,LogTime,Action1) VALUES('" + a + "','" + id + "','" + now.ToShortDateString() + "','" + now.ToShortTimeString() + "','Logged In')");

                                        Class_student.studno = ref_no;
                                        /*LMS l = new LMS();
                                        l.Show();*/


                                    }
                                    else if (no == 1)
                                    {
                                        ChangePasswordSetting chngstng = new ChangePasswordSetting();
                                        chngstng.Show();
                                    }
                                }
                                catch
                                {
                                    MetroMessageBox.Show(this, "Database not Connected please try again ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }



                            }
                            else if (usertype == "Lecturer")
                            {
                                try
                                {
                                    DateTime now = DateTime.Now;
                                    //Lec_home.userid = id;
                                    //Lec_home.time = now.ToShortTimeString();
                                    this.Hide();
                                    if (no == 0)
                                    {
                                        db.insert("INSERT INTO UsersLogDetails(LogID,UserId,LogDate,LogTime,Action1) VALUES('" + a + "','" + id + "','" + now.ToShortDateString() + "','" + now.ToShortTimeString() + "','Logged In')");

                                        /*Lec_class.Lecno = ref_no;
                                        Lec_home l = new Lec_home();
                                        l.Show();*/

                                    }
                                    else if (no == 1)
                                    {
                                        ChangePasswordSetting chngstng = new ChangePasswordSetting();
                                        chngstng.Show();
                                    }
                                }
                                catch
                                {
                                    MetroMessageBox.Show(this, "Database not Connected please try again ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                            else
                            {
                                try
                                {
                                    DateTime now = DateTime.Now;
                                    MainForm.userid = id;
                                    MainForm.time = now.ToShortTimeString();
                                    this.Hide();
                                    if (no == 0)
                                    {
                                        db.insert("INSERT INTO UsersLogDetails(LogID,UserId,LogDate,LogTime,Action1) VALUES('" + a + "','" + id + "','" + now.ToShortDateString() + "','" + now.ToShortTimeString() + "','Logged In')");

                                        openMainform.show();
                                        
                                    }
                                    else if (no == 1)
                                    {
                                        ChangePasswordSetting chngstng = new ChangePasswordSetting();
                                        chngstng.Show();
                                    }
                                }
                                catch
                                {
                                    MetroMessageBox.Show(this, "Database not Connected please try again ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                            //con.Close();

                        }
                        else
                        {
                            MessageBox.Show("Account is disabled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                   
                   
                    
                    else
                    {
                        MetroMessageBox.Show(this, "Your password or username incorrect ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                        //dr.Close();
                    //con.Close();
                }
                con.Close();
            }
            /*catch(System.Data.SqlClient.SqlException p)
            {
                MessageBox.Show(p.Message);
                con.Close();
            }*/
        }

        public static Image pic;
        public void proPicLoad()
        {
            db.con.Open();
            string query = "SELECT Image FROM UserAccountDetails WHERE UserId='" + id + "' ";
            db.cmd = new SqlCommand(query, db.con);
            SqlDataReader dataRead = db.cmd.ExecuteReader();
            dataRead.Read();
            if (dataRead.HasRows)
            {

                if (dataRead[0] != DBNull.Value)
                {
                    byte[] images = (byte[])dataRead[0];
                    MemoryStream mstream = new MemoryStream(images);
                  //  picBxUser.Image = Image.FromStream(mstream);
                    pic = Image.FromStream(mstream);
                }
                else
                {
                    //  picBxUser.Image = null;
                    pic = null;
                }


                dataRead.Close();
            }
            else
            {
                MetroMessageBox.Show(this, "Profile picture not available ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            db.con.Close();
        }
        private void txt_Username_Click(object sender, EventArgs e)
        {
            if(txt_Username.Text=="Username")
            {
                txt_Username.Text = "";
            }
            else if(txt_Username.Text == "")
            {
                txt_Username.Text = "Username";
            }
        }

        private void txt_Username_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_Username.Text)==true||txt_Username.Text=="Username")
            {
                txt_Username.Focus();
                errorPUser.SetError(this.txt_Username, "Please Enter your Username ");
            }
            else
            {
                errorPUser.Clear();
            }
        }

        private void txt_pwd_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txt_pwd.Text) == true||txt_pwd.Text=="Password")
            {
                txt_pwd.Focus();
                errorPPass.SetError(this.txt_pwd, "Please Enter your Password.");
            }
            else
            {
                errorPPass.Clear();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_pwd_Click(object sender, EventArgs e)
        {
            if (txt_pwd.Text == "Password")
            {
                txt_pwd.Text = "";
                txt_pwd.UseSystemPasswordChar = true;
                
            }
            else if(txt_pwd.Text == "")
            {
                txt_pwd.Text = "Password";
                txt_pwd.UseSystemPasswordChar = false;
            }
        }

 
    }
}
