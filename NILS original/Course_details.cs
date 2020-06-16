using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Threading;
using System.IO;
using MetroFramework;

namespace NILS_original
{
    public partial class Course_details : MetroFramework.Forms.MetroForm
    {
        public Course_details()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Credentials.connection);
        private void Course_details_Load(object sender, EventArgs e)
        {
            Database d2 = new Database();
            metroGrid1.DataSource = d2.show("SELECT * FROM Course_details_Master where course_type='Diploma'");
            //metroGrid3.DataSource = d2.show("SELECT * FROM Course_details_Master where course_type='Short'");
            metroGrid2.DataSource = d2.show("SELECT course_no,course_name,course_fee,reg_fee FROM Course_details_Master WHERE course_type='Certificate'");

        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Edit_dip_courses w = new Edit_dip_courses();
            int row = e.RowIndex;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT course_name,course_no,course_fee,reg_fee,English,Sinhala,Tamil FROM Course_details_master WHERE course_no= '" + metroGrid1.Rows[row].Cells[0].Value.ToString() + "' ",con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            w.lbl_cname.Text = dr.GetValue(0).ToString();
            w.lbl_cno.Text = dr.GetValue(1).ToString();
            w.metroLabel18.Text = dr.GetValue(2).ToString();
            w.lbl_regfee.Text = dr.GetValue(3).ToString();
            if (dr.GetBoolean(4) == true)
            {
                w.metroCheckBox1.Checked = true;
            }
            else
            {
                w.metroCheckBox1.Checked = false;
            }
            if (dr.GetBoolean(5) == true)
            {
                w.metroCheckBox2.Checked = true;
            }
            else
            {
                w.metroCheckBox2.Checked = false;
            }
            if (dr.GetBoolean(6) == true)
            {
                w.metroCheckBox3.Checked = true;
            }
            else
            {
                w.metroCheckBox3.Checked = false;
            }
            w.Show();
            //w.Parent = this;
            w.Owner=this;
            con.Close();
        }

        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        string[] modname = new string[25];
        string[] modno = new string[25];
        int count = 0;
        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }
        string mainfolder;
        string assignements;
        string pastpapers;
        string lesson_materials;
        public void CreateFolder(string folderName, DriveService service)
        {
            
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = folderName,
                MimeType = "application/vnd.google-apps.folder",
                
            };
            var request = service.Files.Create(fileMetadata);
            request.Fields = "id";
            var file = request.Execute();

            mainfolder = file.Id;


        }
        public string CreateSubFolder(string folderName, DriveService service,string parent)
        {

            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = folderName,
                MimeType = "application/vnd.google-apps.folder",
                Parents = new List<string> {parent}
            };
            var request = service.Files.Create(fileMetadata);
            request.Fields = "id";
            var file = request.Execute();
            return file.Id;
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            if (txt_cname.Text == "" || txt_cname.Text.Any(char.IsDigit))
            {
                MetroMessageBox.Show(this, "Please enter correct course name");
            }
            else if (txt_cfee.Text == "" || txt_cfee.Text.Any(char.IsLetter))
            {
                MetroMessageBox.Show(this, "Please enter correct course fee");
            }
            else if (txt_regfee.Text == "" || txt_regfee.Text.Any(char.IsLetter))
            {
                MetroMessageBox.Show(this, "Please enter correct course registration fee");
            }
            else if (metroCheckBox1.Checked == false && metroCheckBox2.Checked == false && metroCheckBox3.Checked == false)
            {
                MetroMessageBox.Show(this, "Please select language for course");
            }
            else if (chk_mod1.Checked == true && txt_mod1.Text == "")
            {
                MetroMessageBox.Show(this, "Please enter module 1 name");
            }
            else if (chk_mod2.Checked == true && txt_mod2.Text == "")
            {
                MetroMessageBox.Show(this, "Please enter module 2 name");
            }
            else if (chk_mod3.Checked == true && txt_mod3.Text == "")
            {
                MetroMessageBox.Show(this, "Please enter module 3 name");
            }
            else if (chk_mod4.Checked == true && txt_mod4.Text == "")
            {
                MetroMessageBox.Show(this, "Please enter module 4 name");
            }
            else if (chk_mod5.Checked == true && txt_mod5.Text == "")
            {
                MetroMessageBox.Show(this, "Please enter module 5 name");
            }
            else if (chk_mod6.Checked == true && txt_mod6.Text == "")
            {
                MetroMessageBox.Show(this, "Please enter module 6 name");
            }
            else if (chk_mod7.Checked == true && txt_mod7.Text == "")
            {
                MetroMessageBox.Show(this, "Please enter module 7 name");
            }
            else if (chk_mod8.Checked == true && txt_mod8.Text == "")
            {
                MetroMessageBox.Show(this, "Please enter module 8 name");
            }
            else if (chk_mod9.Checked == true && txt_mod9.Text == "")
            {
                MetroMessageBox.Show(this, "Please enter module 9 name");
            }
            else if (chk_mod10.Checked == true && txt_mod10.Text == "")
            {
                MetroMessageBox.Show(this, "Please enter module 10 name");
            }
            else if (chk_mod11.Checked == true && txt_mod11.Text == "")
            {
                MetroMessageBox.Show(this, "Please enter module 11 name");
            }
            else if (chk_mod12.Checked == true && txt_mod12.Text == "")
            {
                MetroMessageBox.Show(this, "Please enter module 12 name");
            }
            else if (chk_mod13.Checked == true && txt_mod13.Text == "")
            {
                MetroMessageBox.Show(this, "Please enter module 13 name");
            }
            else if (chk_mod14.Checked == true && txt_mod14.Text == "")
            {
                MetroMessageBox.Show(this, "Please enter module 14 name");
            }
            else if (chk_mod15.Checked == true && txt_mod15.Text == "")
            {
                MetroMessageBox.Show(this, "Please enter module 15 name");
            }
            else if (txt_initials.Text.Length != 1)
            {
                MetroMessageBox.Show(this, "Please enter course initials");
            }
            else
            {



                /*loading l = new loading();
                l.Show();
                l.circularProgressBar1.Value = 15;

                //backgroundWorker1.ReportProgress(0);
                string[] Scopes = { DriveService.Scope.Drive };
                //This section is used for credential verification.The credentials are used to for security pourposes(Line 37 to Line 52)
                UserCredential credential;

                using (var stream =
                    new FileStream("client_secret_526728548470-grrbjaujju8j6b654odrvjl3jtk06u4p.apps.googleusercontent.com.json", FileMode.Open, FileAccess.Read))
                {
                    // The file token.json stores the user's access and refresh tokens, and is created
                    // automatically when the authorization flow completes for the first time.
                    string credPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                    // MetroMessageBox.Show(this, "Credential file saved to: " + credPath);
                }
                l.circularProgressBar1.Value = 25;


                DriveService service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "TheAppName"
                });
                /*l.circularProgressBar1.Value = 30;
                CreateFolder(txt_cname.Text, service);
                l.circularProgressBar1.Value = 35;
                assignements = CreateSubFolder("Assignments", service, mainfolder);
                l.circularProgressBar1.Value = 40;
                lesson_materials = CreateSubFolder("Lesson Materials", service, mainfolder);
                l.circularProgressBar1.Value = 45;
                pastpapers = CreateSubFolder("Past Papers", service, mainfolder);
                l.circularProgressBar1.Value = 50;
                //logic to create folders not done*/

                mainfolder = "None";
                assignements = "None";
                lesson_materials = "None";
                pastpapers = "None";
                Database d = new Database();
                string a;
                string b;
                d.insert("INSERT INTO Course_details_master (course_no,course_name,course_type,course_fee,reg_fee,course_initials) VALUES ('" + txt_cno.Text + "','" + txt_cname.Text + "','Diploma','" + txt_cfee.Text + "','" + txt_regfee.Text + "','" + txt_initials.Text + "') ");
                if (metroCheckBox1.Checked == true)
                {
                    d.update("UPDATE Course_details_master SET Sinhala='1' WHERE course_no='" + txt_cno.Text + "'");
                }
                else
                {
                    d.update("UPDATE Course_details_master SET Sinhala='0' WHERE course_no='" + txt_cno.Text + "'");
                }
                if (metroCheckBox2.Checked == true)
                {
                    d.update("UPDATE Course_details_master SET English='1' WHERE course_no='" + txt_cno.Text + "'");
                }
                else
                {
                    d.update("UPDATE Course_details_master SET English='0' WHERE course_no='" + txt_cno.Text + "'");
                }
                if (metroCheckBox3.Checked == true)
                {
                    d.update("UPDATE Course_details_master SET Tamil='1' WHERE course_no='" + txt_cno.Text + "'");
                }
                else
                {
                    d.update("UPDATE Course_details_master SET Tamil='0' WHERE course_no='" + txt_cno.Text + "'");
                }
                //l.circularProgressBar1.Value = 60;
                //d.insert("INSERT INTO Folder_ids (course_no,course_name,main_folder_id,notes_folder_id,assignment_folder_id,papers_folder_id) VALUES ('" + txt_cno.Text + "','" + txt_cname.Text + "','" + mainfolder + "','" + lesson_materials + "','" + assignements + "','" + pastpapers + "')");
                //l.circularProgressBar1.Value = 70;
                if (chk_mod1.Checked == true)
                {
                    a = "None"; //CreateSubFolder(txt_mod1.Text, service, assignements);
                    b = "None"; //CreateSubFolder(txt_mod1.Text, service, lesson_materials);
                    d.insert("INSERT INTO Dip_module_details_2 (Module_id,Module_name,Course_no) VALUES ('" + txt_modno1.Text + "','" + txt_mod1.Text + "','" + txt_cno.Text + "') ");

                }
                if (chk_mod2.Checked == true)
                {
                    a = "None"; //CreateSubFolder(txt_mod1.Text, service, assignements);
                    b = "None"; //CreateSubFolder(txt_mod1.Text, service, lesson_materials);
                    d.insert("INSERT INTO Dip_module_details_2 (Module_id,Module_name,Course_no) VALUES ('" + txt_modno2.Text + "','" + txt_mod2.Text + "','" + txt_cno.Text + "') ");

                }
                if (chk_mod3.Checked == true)
                {
                    a = "None"; //CreateSubFolder(txt_mod1.Text, service, assignements);
                    b = "None"; //CreateSubFolder(txt_mod1.Text, service, lesson_materials);
                    d.insert("INSERT INTO Dip_module_details_2 (Module_id,Module_name,Course_no) VALUES ('" + txt_modno3.Text + "','" + txt_mod3.Text + "','" + txt_cno.Text + "') ");

                }
                if (chk_mod4.Checked == true)
                {
                    a = "None"; //CreateSubFolder(txt_mod1.Text, service, assignements);
                    b = "None"; //CreateSubFolder(txt_mod1.Text, service, lesson_materials);
                    d.insert("INSERT INTO Dip_module_details_2 (Module_id,Module_name,Course_no) VALUES ('" + txt_modno4.Text + "','" + txt_mod4.Text + "','" + txt_cno.Text + "') ");

                }
                if (chk_mod5.Checked == true)
                {
                    a = "None"; //CreateSubFolder(txt_mod1.Text, service, assignements);
                    b = "None"; //CreateSubFolder(txt_mod1.Text, service, lesson_materials);
                    d.insert("INSERT INTO Dip_module_details_2 (Module_id,Module_name,Course_no) VALUES ('" + txt_modno5.Text + "','" + txt_mod5.Text + "','" + txt_cno.Text + "') ");
                }
                if (chk_mod6.Checked == true)
                {
                    a = "None"; //CreateSubFolder(txt_mod1.Text, service, assignements);
                    b = "None"; //CreateSubFolder(txt_mod1.Text, service, lesson_materials);
                    d.insert("INSERT INTO Dip_module_details_2 (Module_id,Module_name,Course_no) VALUES ('" + txt_modno6.Text + "','" + txt_mod6.Text + "','" + txt_cno.Text + "') ");

                }
                if (chk_mod7.Checked == true)
                {
                    a = "None"; //CreateSubFolder(txt_mod1.Text, service, assignements);
                    b = "None"; //CreateSubFolder(txt_mod1.Text, service, lesson_materials);
                    d.insert("INSERT INTO Dip_module_details_2 (Module_id,Module_name,Course_no) VALUES ('" + txt_modno7.Text + "','" + txt_mod7.Text + "','" + txt_cno.Text + "') ");

                }
                if (chk_mod8.Checked == true)
                {
                    a = "None"; //CreateSubFolder(txt_mod1.Text, service, assignements);
                    b = "None"; //CreateSubFolder(txt_mod1.Text, service, lesson_materials);
                    d.insert("INSERT INTO Dip_module_details_2 (Module_id,Module_name,Course_no) VALUES ('" + txt_modno8.Text + "','" + txt_mod8.Text + "','" + txt_cno.Text + "') ");

                }
                if (chk_mod9.Checked == true)
                {
                    a = "None"; //CreateSubFolder(txt_mod1.Text, service, assignements);
                    b = "None"; //CreateSubFolder(txt_mod1.Text, service, lesson_materials);
                    d.insert("INSERT INTO Dip_module_details_2 (Module_id,Module_name,Course_no) VALUES ('" + txt_modno9.Text + "','" + txt_mod9.Text + "','" + txt_cno.Text + "') ");

                }
                if (chk_mod10.Checked == true)
                {
                    a = "None"; //CreateSubFolder(txt_mod1.Text, service, assignements);
                    b = "None"; //CreateSubFolder(txt_mod1.Text, service, lesson_materials);
                    d.insert("INSERT INTO Dip_module_details_2 (Module_id,Module_name,Course_no) VALUES ('" + txt_modno10.Text + "','" + txt_mod10.Text + "','" + txt_cno.Text + "') ");

                }
                if (chk_mod11.Checked == true)
                {
                    a = "None"; //CreateSubFolder(txt_mod1.Text, service, assignements);
                    b = "None"; //CreateSubFolder(txt_mod1.Text, service, lesson_materials);
                    d.insert("INSERT INTO Dip_module_details_2 (Module_id,Module_name,Course_no) VALUES ('" + txt_modno11.Text + "','" + txt_mod11.Text + "','" + txt_cno.Text + "') ");

                }
                if (chk_mod12.Checked == true)
                {
                    a = "None"; //CreateSubFolder(txt_mod1.Text, service, assignements);
                    b = "None"; //CreateSubFolder(txt_mod1.Text, service, lesson_materials);
                    d.insert("INSERT INTO Dip_module_details_2 (Module_id,Module_name,Course_no) VALUES ('" + txt_modno12.Text + "','" + txt_mod12.Text + "','" + txt_cno.Text + "') ");

                }
                if (chk_mod13.Checked == true)
                {
                    a = "None"; //CreateSubFolder(txt_mod1.Text, service, assignements);
                    b = "None"; //CreateSubFolder(txt_mod1.Text, service, lesson_materials);
                    d.insert("INSERT INTO Dip_module_details_2 (Module_id,Module_name,Course_no) VALUES ('" + txt_modno13.Text + "','" + txt_mod13.Text + "','" + txt_cno.Text + "') ");

                }
                if (chk_mod14.Checked == true)
                {
                    a = "None"; //CreateSubFolder(txt_mod1.Text, service, assignements);
                    b = "None"; //CreateSubFolder(txt_mod1.Text, service, lesson_materials);
                    d.insert("INSERT INTO Dip_module_details_2 (Module_id,Module_name,Course_no) VALUES ('" + txt_modno14.Text + "','" + txt_mod14.Text + "','" + txt_cno.Text + "') ");

                }
                if (chk_mod15.Checked == true)
                {
                    a = "None"; //CreateSubFolder(txt_mod1.Text, service, assignements);
                    b = "None"; //CreateSubFolder(txt_mod1.Text, service, lesson_materials);
                    d.insert("INSERT INTO Dip_module_details_2 (Module_id,Module_name,Course_no) VALUES ('" + txt_modno15.Text + "','" + txt_mod15.Text + "','" + txt_cno.Text + "') ");

                }
                /*l.circularProgressBar1.Value = 100;
                l.metroLabel1.Text = "Done!";
                l.Dispose();*/
                MetroMessageBox.Show(this, "Successfully added new course", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Select_Compulsory_Modules.course_no = txt_cno.Text;
                Select_Compulsory_Modules s = new Select_Compulsory_Modules();
                s.Show();
            }


        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            Database d2 = new Database();
            metroGrid1.DataSource = d2.show("SELECT * FROM Course_details_Master where course_type='Diploma'");
        }

        private void metroTabPage2_Click(object sender, EventArgs e)
        {

        }

      
        private void metroTile10_Click_2(object sender, EventArgs e)
        {
            clear();
            Database d2 = new Database();
            metroGrid2.DataSource = d2.show("SELECT course_no,course_name,course_fee,reg_fee FROM Course_details_Master WHERE course_type='Certificate'");

        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {

           // Database d2 = new Database();
            //metroGrid2.DataSource = d2.show("SELECT course_no,course_name,course_fee,reg_fee FROM Course_details_Master WHERE course_type='Certificate' AND course_name LIKE '%" + txtFind.Text + "%' ");
           

        }

        private void btnFind_Click(object sender, EventArgs e)
        {

        }
        public void clear()
        {
            txtCNam.Text = "";
            msktxtCNO.Text = "";
            txtCFee.Text = "";
            txtReFee.Text = "";
            //txtFind.Text = "";
        }
        private void metroGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Edit_short i = new Edit_short();
            int row = e.RowIndex;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT course_name,course_no,course_fee,reg_fee FROM Course_details_master WHERE course_no= '" + metroGrid2.Rows[row].Cells[0].Value.ToString() + "' ", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            i.lbl_cname.Text = dr.GetValue(0).ToString();
            i.lbl_cno.Text = dr.GetValue(1).ToString();
            i.metroLabel18.Text = dr.GetValue(2).ToString();
            i.lbl_regfee.Text = dr.GetValue(3).ToString();
            i.Show();
            con.Close();

            /* txtCNam.Text=this.metroGrid2.CurrentRow.Cells[1].Value.ToString();
             msktxtCNO.Text= this.metroGrid2.CurrentRow.Cells[0].Value.ToString();
             txtCFee.Text=this.metroGrid2.CurrentRow.Cells[2].Value.ToString();
             txtReFee.Text=this.metroGrid2.CurrentRow.Cells[3].Value.ToString();*/

        }
        Database db = new Database();
        private void metroTile6_Click(object sender, EventArgs e)
        {
            if (txtCNam.Text == "")
            {
                MessageBox.Show(this, "Please enter correct course name");

            }
            
            else if (txtCFee.Text == "" || txtCFee.Text.Any(char.IsLetter))
            {
                MessageBox.Show(this, "Please enter correct course fee");

            }
            else if (txtReFee.Text == "" || txtReFee.Text.Any(char.IsLetter))
            {
                MessageBox.Show(this, "Please enter correct registration fee");

            }
            else if (txt_initials_2.Text == "")
            {
                MessageBox.Show(this, "Please enter correct course initials");
            }
            if (metroCheckBox6.Checked == false && metroCheckBox7.Checked == false)
            {
                MessageBox.Show(this, "Please confirm course no and course initials");
            }
            else
            {
                try
                {
                    db.insert("insert into Course_details_Master(course_no,course_name,course_type,course_fee,reg_fee,course_initials) values('" + msktxtCNO.Text + "','" + txtCNam.Text + "','Certificate','" + txtCFee.Text + "','" + txtReFee.Text + "','" + txt_initials_2.Text + "')");
                    i = 1;
                    Database d2 = new Database();
                    if (metroCheckBox10.Checked == true)
                    {
                        d2.update("UPDATE Course_details_master SET English = '1' WHERE course_no = '" + msktxtCNO.Text + "'");
                    }
                    else
                    {
                        d2.update("UPDATE Course_details_master SET English = '0' WHERE course_no = '" + msktxtCNO.Text + "'");
                    }
                    if (metroCheckBox9.Checked == true)
                    {
                        d2.update("UPDATE Course_details_master SET Sinhala = '1' WHERE course_no = '" + msktxtCNO.Text + "'");
                    }
                    else
                    {
                        d2.update("UPDATE Course_details_master SET Sinhala = '0' WHERE course_no = '" + msktxtCNO.Text + "'");
                    }
                    if (metroCheckBox8.Checked == true)
                    {
                        d2.update("UPDATE Course_details_master SET Tamil = '1' WHERE course_no = '" + msktxtCNO.Text + "'");
                    }
                    else
                    {
                        d2.update("UPDATE Course_details_master SET Tamil = '0' WHERE course_no = '" + msktxtCNO.Text + "'");
                    }
                    metroGrid2.DataSource = d2.show("SELECT course_no,course_name,course_fee,reg_fee FROM Course_details_Master WHERE course_type='Certificate'");
                    clear();
                }
                catch (Exception) { }
                if (i == 1)
                    MetroMessageBox.Show(this, "One Course Add Successfully .", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        int i = 0;
        private void metroTile7_Click(object sender, EventArgs e)
        {
            if (msktxtCNO.Text != null)
            {
                DialogResult dialgReslt = MetroMessageBox.Show(this, "Are you sure delete this Course ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialgReslt.ToString() == "Yes")
                {
                    i = 1;
                        db.insert("DELETE FROM Course_details_Master WHERE course_no='" + msktxtCNO.Text + "' ");
                    clear();
                    Database d2 = new Database();
                    metroGrid2.DataSource = d2.show("SELECT course_no,course_name,course_fee,reg_fee FROM Course_details_Master WHERE course_type='Certificate'");

                }

            }

            else
            {
                MetroMessageBox.Show(this, "Please select Delete Course First.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (i == 1)
                MetroMessageBox.Show(this, "Selected Course Delete Successfully .", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void metroTile10_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            metroGrid2.DataSource = null;
            metroGrid2.DataSource = db.show("SELECT course_no,course_name,course_fee,reg_fee FROM Course_details_Master WHERE course_type='Certificate'");
            metroGrid2.Refresh();
        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel37_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox10_Click(object sender, EventArgs e)
        {

        }

        private void metroCheckBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_mod14.Checked == true)
            {
                count++;
                string newstring = txt_cno.Text + "/mod14";
                txt_modno14.Text = newstring;
                txt_mod14.Enabled = true;
            }
            else
            {
                txt_mod14.Enabled = false;
                count--;
                txt_modno14.Text = "";
                txt_modno14.Enabled = false;
            }
        }

        private void metroTextBox9_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel36_Click(object sender, EventArgs e)
        {

        }

        private void chk_mod1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_mod1.Checked == true)
            {
                count++;
                string newstring = txt_cno.Text + "/mod1";
                txt_modno1.Text = newstring;
                txt_mod1.Enabled = true;
               
            }
            else
            {
                txt_mod1.Enabled = false;
                count--;
                txt_modno1.Text = "";
                txt_modno1.Enabled = false;
            }
        }

        private void chk_mod2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_mod2.Checked == true)
            {
                count++;
                string newstring = txt_cno.Text + "/mod2";
                txt_modno2.Text = newstring;
                txt_mod2.Enabled = true;
            }
            else
            {
                txt_mod2.Enabled = false;
                count--;
                txt_modno2.Text = "";
                txt_modno2.Enabled = false;
            }
        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chk_mod3_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_mod3.Checked == true)
            {
                count++;
                string newstring = txt_cno.Text + "/mod3";
                txt_modno3.Text = newstring;
                txt_mod3.Enabled = true;
            }
            else
            {
                txt_mod3.Enabled = false;
                count--;
                txt_modno3.Text = "";
                txt_modno3.Enabled = false;
            }
        }

        private void chk_mod4_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_mod4.Checked == true)
            {
                count++;
                string newstring = txt_cno.Text + "/mod4";
                txt_modno4.Text = newstring;
                txt_mod4.Enabled = true;
            }
            else
            {
                txt_mod4.Enabled = false;
                count--;
                txt_modno4.Text = "";
                txt_modno4.Enabled = false;
            }
        }

        private void chk_mod5_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_mod5.Checked == true)
            {
                count++;
                string newstring = txt_cno.Text + "/mod5";
                txt_modno5.Text = newstring;
                txt_mod5.Enabled = true;
            }
            else
            {
                txt_mod5.Enabled = false;
                count--;
                txt_modno5.Text = "";
                txt_modno5.Enabled = false;
            }
        }

        private void chk_mod6_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_mod6.Checked == true)
            {
                count++;
                string newstring = txt_cno.Text + "/mod6";
                txt_modno6.Text = newstring;
                txt_mod6.Enabled = true;
            }
            else
            {
                txt_mod6.Enabled = false;
                count--;
                txt_modno6.Text = "";
                txt_modno6.Enabled = false;
            }
        }

        private void chk_mod7_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_mod7.Checked == true)
            {
                count++;
                string newstring = txt_cno.Text + "/mod7";
                txt_modno7.Text = newstring;
                txt_mod7.Enabled = true;
            }
            else
            {
                txt_mod7.Enabled = false;
                count--;
                txt_modno7.Text = "";
                txt_modno7.Enabled = false;
            }
        }

        private void chk_mod10_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_mod10.Checked == true)
            {
                count++;
                string newstring = txt_cno.Text + "/mod10";
                txt_modno10.Text = newstring;
                txt_mod10.Enabled = true;
            }
            else
            {
                txt_mod10.Enabled = false;
                count--;
                txt_modno10.Text = "";
                txt_modno10.Enabled = false;
            }
        }

        private void chk_mod9_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_mod9.Checked == true)
            {
                count++;
                string newstring = txt_cno.Text + "/mod9";
                txt_modno9.Text = newstring;
                txt_mod9.Enabled = true;
            }
            else
            {
                txt_mod9.Enabled = false;
                count--;
                txt_modno9.Text = "";
                txt_modno9.Enabled = false;
            }
        }

        private void chk_mod11_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_mod11.Checked == true)
            {
                count++;
                string newstring = txt_cno.Text + "/mod11";
                txt_modno11.Text = newstring;
                txt_mod11.Enabled = true;
            }
            else
            {
                txt_mod11.Enabled = false;
                count--;
                txt_modno11.Text = "";
                txt_modno11.Enabled = false;
            }
        }

        private void chk_mod12_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_mod12.Checked == true)
            {
                count++;
                string newstring = txt_cno.Text + "/mod12";
                txt_modno12.Text = newstring;
                txt_mod12.Enabled = true;
            }
            else
            {
                txt_mod12.Enabled = false;
                count--;
                txt_modno12.Text = "";
                txt_modno12.Enabled = false;
            }
        }

        private void chk_mod13_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_mod13.Checked == true)
            {
                count++;
                string newstring = txt_cno.Text + "/mod13";
                txt_modno13.Text = newstring;
                txt_mod13.Enabled = true;
            }
            else
            {
                txt_mod13.Enabled = false;
                count--;
                txt_modno13.Text = "";
                txt_modno13.Enabled = false;
            }
        }

        private void chk_mod15_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_mod15.Checked == true)
            {
                count++;
                string newstring = txt_cno.Text + "/mod15";
                txt_modno15.Text = newstring;
                txt_mod15.Enabled = true;
            }
            else
            {
                txt_mod15.Enabled = false;
                count--;
                txt_modno15.Text = "";
                txt_modno15.Enabled = false;
            }
        }

        private void chk_mod8_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_mod8.Checked == true)
            {
                count++;
                string newstring = txt_cno.Text + "/mod8";
                txt_modno8.Text = newstring;
                txt_mod8.Enabled = true;
            }
            else
            {
                txt_mod8.Enabled = false;
                count--;
                txt_modno8.Text = "";
                txt_modno8.Enabled = false;
            }
        }

        private void metroGrid1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroTile1_Click_1(object sender, EventArgs e)
        {
            /*if(metroComboBox1.Text=="")
            {
                MessageBox.Show(this, "Please select course type");
            }
            else if(txt_sregfee.Text==""||txt_sregfee.Text.Any(char.IsLetter))
            {
                MessageBox.Show(this, "Please enter correct registration fee");

            }
            else if(txt_scfee.Text==""||txt_scfee.Text.Any(char.IsLetter))
            {
                MessageBox.Show(this, "Please enter correct course fee");
            }
           else if(txt_sname.Text=="")
            {
                MessageBox.Show(this, "Please enter correct course name");

            }
            else
            {
                Database d = new Database();
                d.insert("INSERT INTO Course_details_master (course_no,course_name,course_type,course_fee,reg_fee,course_initials,English,Sinhala,Tamil) VALUES ('" + maskedTextBox1.Text + "','" +txt_sname.Text + "','Short','" + txt_scfee.Text + "','" + txt_sregfee.Text + "','None','None','None','None') ");
                d.insert("INSERT INTO Short_course_details(course_no,short_course_type) VALUES ('" + maskedTextBox1.Text + "','" + type + "')");
                MessageBox.Show(this, "New course entered succesfully","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }*/
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        string type;
        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           /*if(metroComboBox1.SelectedIndex==0)
            {
                maskedTextBox1.Mask = "1D->?-00";
                type = "1day";
            }
            else if (metroComboBox1.SelectedIndex == 1)
            {
                maskedTextBox1.Mask = "2D->?-00";
                type = "2day";
            }
            else if (metroComboBox1.SelectedIndex == 2)
            {
                maskedTextBox1.Mask = "3D->?-00";
                type = "3day";
            }*/

        }

       /* private void metroTile11_Click(object sender, EventArgs e)
        {
            Database d2 = new Database();
            metroGrid3.DataSource = d2.show("SELECT * FROM Course_details_Master where course_type='Short'");
        }

        private void metroGrid3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            Edit_scourse f = new Edit_scourse();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT course_name,course_no,course_fee,reg_fee FROM Course_details_master WHERE course_no= '" + metroGrid3.Rows[row].Cells[0].Value.ToString() + "' ", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            f.lbl_cname_1.Text = dr.GetValue(0).ToString();
            f.lbl_cno_1.Text = dr.GetValue(1).ToString();
            f.lbl_sfee1.Text = dr.GetValue(2).ToString();
            f.lbl_regfee_1.Text = dr.GetValue(3).ToString();
            f.Show();
            dr.Close();
            SqlCommand cmd2 = new SqlCommand("SELECT short_course_type FROM Short_course_details WHERE course_no='" + metroGrid3.Rows[row].Cells[0].Value.ToString() + "'", con);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            dr2.Read();
            f.lbl_ctype.Text = dr2.GetValue(0).ToString();
            con.Close();
        }*/

        private void metroCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox4.Checked == true)
            {
                if (db.singleInt("SELECT COUNT(*) FROM Course_details_master WHERE course_no='" + txt_cno.Text + "'") > 0)
                {
                    MessageBox.Show(this, "Course no is already taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    metroCheckBox4.Checked = false;
                    txt_cno.Clear();
                }
                else if (txt_cno.MaskCompleted == false)
                {
                    MessageBox.Show(this, "Course no not entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    metroCheckBox4.Checked = false;
                }
                else
                {
                    txt_cno.Enabled = false;
                    metroCheckBox4.Enabled = false;
                    if (metroCheckBox5.Checked == true)
                    {
                        metroPanel2.Enabled = true;
                    }
                }
            }
        }

        private void metroCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox5.Checked == true)
            {
                if (db.singleInt("SELECT COUNT(*) FROM Course_details_master WHERE course_initials='" + txt_initials.Text + "'") > 0)
                {
                    MessageBox.Show(this, "Course initials already taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    metroCheckBox5.Checked = false;
                    txt_initials.Clear();
                }
                else if (txt_initials.Text.Length!=1)
                {
                    MessageBox.Show(this, "Course initials not entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    metroCheckBox5.Checked = false;
                }
                else
                {
                    txt_initials.Enabled = false;
                    metroCheckBox5.Enabled = false;
                    if (metroCheckBox4.Checked == true)
                    {
                        metroPanel2.Enabled = true;
                    }
                }
            }
        }

        private void metroCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox6.Checked == true)
            {
                if (db.singleInt("SELECT COUNT(*) FROM Course_details_master WHERE course_no='" + msktxtCNO.Text + "'") > 0)
                {
                    MessageBox.Show(this, "Course no is already taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    metroCheckBox6.Checked = false;
                    msktxtCNO.Clear();
                }
                else if (msktxtCNO.MaskCompleted == false)
                {
                    MessageBox.Show(this, "Course number not entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    metroCheckBox6.Checked = false;
                }
                else
                {
                    msktxtCNO.Enabled = false;
                    metroCheckBox6.Enabled = false;
                  
                }
            }
        }

        private void metroCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox7.Checked == true)
            {
                if (db.singleInt("SELECT COUNT(*) FROM Course_details_master WHERE course_initials='" + txt_initials_2.Text + "'") > 0)
                {
                    MessageBox.Show(this, "Course initials already taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    metroCheckBox7.Checked = false;
                    txt_initials_2.Clear();
                }
                else if (txt_initials_2.Text.Length != 1)
                {
                    MessageBox.Show(this, "Course initials not entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    metroCheckBox7.Checked = false;
                }
                else
                {
                    txt_initials_2.Enabled = false;
                    metroCheckBox7.Enabled = false;
       
                }
            }
        }

        private void metroTile10_Click_1(object sender, EventArgs e)
        {

        }

        /*private void metroCheckBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox11.Checked == true)
            {
                if (db.singleInt("SELECT COUNT(*) FROM Course_details_master WHERE course_no='" + maskedTextBox1.Text + "'") > 0)
                {
                    MessageBox.Show(this, "Course no is already taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    metroCheckBox11.Checked = false;
                    maskedTextBox1.Clear();
                }
                else if (maskedTextBox1.MaskCompleted == false)
                {
                    MessageBox.Show(this, "Course number not entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    metroCheckBox11.Checked = false;
                }
                else
                {
                    maskedTextBox1.Enabled = false;
                    metroCheckBox11.Enabled = false;

                }
            }
        }*/
    }
}
