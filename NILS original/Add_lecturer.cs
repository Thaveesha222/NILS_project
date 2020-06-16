using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using NILS_original;
using MetroFramework;
using System.IO;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;

namespace NILS_original
{
    public partial class Add_lecturer : MetroFramework.Forms.MetroForm
    {
        public Add_lecturer()
        {
     
            InitializeComponent();
            AutoID();
            Database db = new Database();
            //metroGrid2.DataSource = db.show("SELECT Lecturer_no,NIC,F_name,L_name,mobile_no_1,tel_no,email,address, FROM Lecture_details ORDER BY Lecturer_no");
            view_8.SelectedTab = metroTabPage1;
            metroDateTime1.Format = DateTimePickerFormat.Custom;
            metroDateTime1.CustomFormat = "dd-MM-yyyy";

        }
        Database db = new Database();

        SqlConnection con = new SqlConnection(Credentials.connection);
        public SqlCommand cmd;
        public SqlDataReader dr;
        public SqlDataAdapter sda;
        string[] sa = new string[25];
        private void Add_lecturer_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            SqlConnection con = new SqlConnection(Credentials.connection);

            con.Open();
            /*SqlCommand cmd1 = new SqlCommand(("SELECT Module_name FROM Dip_module_details_2 GROUP BY Module_name"), con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            int count = 0;
            string[] name = new string[100];
            while (dr1.Read())
            {
                name[count] = Convert.ToString(dr1.GetValue(0));
                count++;
            }*/
            //cmb_lec_specific_area.DataSource = name;
            cmb_sa_1.DataSource = General_methods.Fill_lec_specific_areas_combobox();
            sa = General_methods.Fill_lec_specific_areas_combobox().ToArray();
            //dr1.Close();
            con.Close();
            
        }
        
        private void metroLabel7_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel9_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel8_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox8_Click(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)//add button
        {

        }

        

       
        private void btn_refresh_Click(object sender, EventArgs e)
        {

        }

        private void txt_lec_no_Click(object sender, EventArgs e)
        {

        }

        
        
        

        

       

        private void cmb_lec_specific_area_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void metroGrid2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            /*txt_lec_no.Text = this.metroGrid2.CurrentRow.Cells[0].Value.ToString();
            txt_nic.Text = this.metroGrid2.CurrentRow.Cells[1].Value.ToString();
            txt_fname.Text = this.metroGrid2.CurrentRow.Cells[2].Value.ToString();
            txt_lname.Text = this.metroGrid2.CurrentRow.Cells[3].Value.ToString();
            txt_mobile_no1.Text = this.metroGrid2.CurrentRow.Cells[4].Value.ToString();
            txt_mobile_no2.Text = this.metroGrid2.CurrentRow.Cells[5].Value.ToString();
            txt_tel_no.Text = this.metroGrid2.CurrentRow.Cells[6].Value.ToString();
            txt_email.Text = this.metroGrid2.CurrentRow.Cells[7].Value.ToString();
            txt_address.Text = this.metroGrid2.CurrentRow.Cells[8].Value.ToString();*/
            //cmb_lec_specific_area.Text = this.metroGrid2.CurrentRow.Cells[9].Value.ToString();
        }
        private void ToViewFile(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }
        
        string samplePath = Application.StartupPath + Path.DirectorySeparatorChar + "Lecturer_application_template.docx";
        //result docs paths
        string docxPath;
        string pdfPath;
        Dictionary<string, string> GetReplaceDictionary1()
        {
            Dictionary<string, string> replaceDict = new Dictionary<string, string>();
            replaceDict.Add("#lecno#", txt_lec_no.Text.Trim());
            replaceDict.Add("#fname#", txt_fname.Text.Trim());
            //replaceDict.Add("#fname#", txt_mname.Text.Trim());
            replaceDict.Add("#lname#", txt_lname.Text.Trim());
            replaceDict.Add("#iname#", txt_iname.Text.Trim());
            replaceDict.Add("#nic#", txt_nic.Text.Trim());
            replaceDict.Add("#address#", txt_address.Text.Trim());
            replaceDict.Add("#email#", txt_email.Text.Trim());
            replaceDict.Add("#tel#", txt_tel_no.Text.Trim());
            replaceDict.Add("#mobile#", txt_mobile_no1.Text.Trim());
            if(chk_mail.Checked==true)
            {
                replaceDict.Add("#yn_email#", "yes");
            }
            else
            {
                replaceDict.Add("#yn_email#", "no");
            }
            if (chk_mobile.Checked == true)
            {
                replaceDict.Add("#yn_mobile#", "yes");
            }
            else
            {
                replaceDict.Add("#yn_mobile#", "no");
            }
            if (chk_tel.Checked == true)
            {
                replaceDict.Add("#yn_tel#", "yes");
            }
            else
            {
                replaceDict.Add("#yn_tel#", "no");
            }
            if (chk_viber.Checked == true)
            {
                replaceDict.Add("#yn_viber#", "yes");
            }
            else
            {
                replaceDict.Add("#yn_viber#", "no");
            }
            if (chk_whatspp.Checked == true)
            {
                replaceDict.Add("#yn_whatsapp#", "yes");
            }
            else
            {
                replaceDict.Add("#yn_whatsapp#", "no");
            }
            return replaceDict;
        }
        Document document = new Document();
        string h;
        private void btn_add_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txt_lec_no.Text))
            {
                MessageBox.Show(this, "Please Enter Lecturer No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txt_nic.Text))
            {
                MessageBox.Show(this, "Please Enter NIC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (General_methods.NIC_validation(txt_nic.Text, metroDateTime1.Value, cmb_gender.Text) == "invalid")
            {
                MessageBox.Show(this, "Details of NIC do not match with birthdate and geneder. Please check nic,birthdate and gender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txt_fname.Text) || txt_fname.Text.Any(char.IsDigit))
            {
                MessageBox.Show(this, "Please Enter First Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txt_lname.Text) || txt_lname.Text.Any(char.IsDigit))
            {
                MessageBox.Show(this, "Please Enter Last Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txt_iname.Text) || txt_iname.Text.Any(char.IsDigit))
            {
                MessageBox.Show(this, "Please Enter Name with Initials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmb_gender.Text == "")
            {
                MessageBox.Show(this, "Please Select gender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_mobile_no1.MaskCompleted == false || txt_mobile_no1.Text.Any(char.IsLetter))
            {
                MessageBox.Show(this, "Please Enter Mobile Number 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /*else if (txt_mobile_no2.MaskCompleted==false || txt_mobile_no2.Text.Any(char.IsLetter))
            {
                MessageBox.Show(this, "Please Enter Mobile Number 2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            else if (txt_tel_no.MaskCompleted == false || txt_tel_no.Text.Any(char.IsLetter))
            {
                MessageBox.Show(this, "Please Enter Tel Number ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txt_email.Text))
            {
                MessageBox.Show(this, "Please Enter Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txt_hno.Text))
            {
                MessageBox.Show(this, "Please Home no", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txt_address.Text))
            {
                MessageBox.Show(this, "Please Enter Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (chk_mail.Checked == false && chk_mobile.Checked == false && chk_tel.Checked == false && chk_viber.Checked == false && chk_whatspp.Checked == false)
            {
                MessageBox.Show(this, "No preference of contact selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (location.Text == "location")
            {
                MessageBox.Show(this, "Please select location for creation of lecturer profile", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                i = 1;
                int g = db.singleInt("SELECT COUNT(*) FROM Lecture_details WHERE Lecturer_no='" + h + "'");
                if (g == 1)
                {
                    MessageBox.Show(this, "Lecturer already exists", "Record exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (pictureBox1.Image == null)
                    {
                        DialogResult dg = MessageBox.Show("Add lecturer without image?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dg == DialogResult.Yes)
                        {
                            h = txt_lec_no.Text;
                            db.insert("INSERT INTO Lecture_details(Lecturer_no,NIC,F_name,L_name,mobile_no_1,tel_no,email,address,home_no,Name_with_initals,Birthdate,Gender)  VALUES('" + txt_lec_no.Text + "','" + txt_nic.Text + "','" + txt_fname.Text + "','" + txt_lname.Text + "','" + txt_mobile_no1.Text + "','" + txt_tel_no.Text + "','" + txt_email.Text + "','" + txt_address.Text + "','" + txt_hno.Text + "','" + txt_iname.Text + "','" + metroDateTime1.Value + "','" + cmb_gender.Text + "')");
                            MessageBox.Show("Database updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //db.insert("insert into Lecturer_stats(lecturer_no,dip,certif,short,rating) values('" + txt_lec_no.Text + "','0','0','0','0') ");
                            i = 0;
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        h = txt_lec_no.Text;
                        db.insert("INSERT INTO Lecture_details(Lecturer_no,NIC,F_name,L_name,mobile_no_1,tel_no,email,address,home_no,Name_with_initals,Birthdate,Gender)  VALUES('" + txt_lec_no.Text + "','" + txt_nic.Text + "','" + txt_fname.Text + "','" + txt_lname.Text + "','" + txt_mobile_no1.Text + "','" + txt_tel_no.Text + "','" + txt_email.Text + "','" + txt_address.Text + "','" + txt_hno.Text + "','" + txt_iname.Text + "','" + metroDateTime1.Value + "','" + cmb_gender.Text + "')");
                        MessageBox.Show("Database updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE Lecture_details SET img=(@imgdata) WHERE Lecturer_no='" + txt_lec_no.Text + "'", con);
                        cmd.Parameters.AddWithValue("@imgdata", SqlDbType.Image).Value = bimage;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        i = 0;
                    }

                    if (i == 0)
                    {
                        /*DialogResult dialogResult = MessageBox.Show("Create User Account now?", "NILS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Account_creation.islec = "yes";
                            Account_creation a = new Account_creation();
                            a.Show();
                            a.txt_uname.Text = txt_lec_no.Text;
                            a.lbl_no.Text = txt_lec_no.Text;
                            a.lbl_name.Text = txt_fname.Text + " " + txt_lname.Text;
                            a.lbl_email.Text = txt_email.Text;


                        }*/
                        //docxPath = "C:\\Users\\94762\\Desktop\\lecs\\" + txt_lec_no.Text + "_" + txt_fname.Text + "_" + txt_lname.Text + "_" + ".docx";
                        //pdfPath = "C:\\Users\\94762\\Desktop\\lecs\\" + txt_lec_no.Text + "_" + txt_fname.Text + "_" + txt_lname.Text + "_" + ".pdf";
                        docxPath = save_file_to+ "\\" + txt_lec_no.Text + "_" + txt_fname.Text + "_" + txt_lname.Text + "_" + ".docx";
                        pdfPath = save_file_to+"\\" + txt_lec_no.Text + "_" + txt_fname.Text + "_" + txt_lname.Text + "_" + ".pdf";
                        document.LoadFromFile(samplePath);
                        //get strings to replace  
                        Dictionary<string, string> dictReplace = GetReplaceDictionary1();
                        //Replace text  
                        foreach (KeyValuePair<string, string> kvp in dictReplace)
                        {
                            document.Replace(kvp.Key, kvp.Value, true, true);
                        }
                        //Save doc file.  
                        document.SaveToFile(@docxPath, FileFormat.Docx);
                        //Convert to PDF  
                        //document.SaveToFile(pdfPath, FileFormat.PDF);
                        MessageBox.Show("Details added to word document", "doc processing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        document.Close();
                        //ToViewFile(docxPath);
                        // ToViewFile(pdfPath);
                        //samplePath = "C:\\Users\\94762\\Desktop\\lecs\\" + txt_lec_no.Text + "_" + txt_fname.Text + "_" + txt_lname.Text + "_" + ".docx";
                        samplePath = save_file_to +"\\"+ txt_lec_no.Text + "_" + txt_fname.Text + "_" + txt_lname.Text + "_" + ".docx";

                        //clear();
                        /*if (i == 1)
                            MessageBox.Show(this, "Data Inserted Successfully to database");
                        else if (i == 0)
                            MessageBox.Show(this, "Data not Inserted .");*/
                        AutoID();
                    }

                }
            }

            

        }
        
        public int i = 0;
        public  void clear()
        {
            txt_lec_no.Clear();
            txt_nic.Clear();
            txt_fname.Clear();
            txt_lname.Clear();
            txt_mobile_no1.Clear();
            //txt_mobile_no2.Clear();
            txt_tel_no.Clear();
            txt_email.Clear();
            //txt_address.Clear();
        }
        private void btn_clear_Click_2(object sender, EventArgs e)
        {
            clear();  
        }

        private void btn_back_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        char[] phrase = new char[11];
        public void AutoID()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Lecturer_no FROM Lecture_details",con);
            SqlDataReader dr = cmd.ExecuteReader();
            List<int> s = new List<int>();
            
            while (dr.Read())
            {
                s.Add(Convert.ToInt32(dr.GetValue(0).ToString().Split('_').GetValue(2)));
            }
            if (s.Count != 0)
            {
                txt_lec_no.Text = "NILS_RP_" + (1 + s.Max()).ToString();
            }
            else
            {
                txt_lec_no.Text = "NILS_RP_" + 1.ToString();
            }
            con.Close();
        }

        private void btn_refresh_Click_2(object sender, EventArgs e)
        {
            Database db = new Database();
            metroGrid2.DataSource = db.show("SELECT Lecturer_no,NIC,F_name,L_name,mobile_no_1,mobile_no_2,tel_no,email,address,lecturer_specific_area_1,medium_1,lecturer_specific_area_2,medium_2,lecturer_specific_area_3,medium_3 FROM Lecture_details ORDER BY Lecturer_no");
        }

        private void Add_lecturer_Click(object sender, EventArgs e)
        {
            AutoID();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        string imgLocation = "";
        Dictionary<string, string> GetReplaceDictionary2()
        {
            Dictionary<string, string> replaceDict = new Dictionary<string, string>();
            replaceDict.Add("#eduqualify_sub1#", txt_subnam1.Text.Trim());
            replaceDict.Add("#eduqualify_sub2#", txt_subnam2.Text.Trim());
            replaceDict.Add("#eduqualify_sub3#", txt_subnam3.Text.Trim());
            replaceDict.Add("#eduqualify_sub4#", txt_subnam4.Text.Trim());
            replaceDict.Add("#eduqualify_grd1#", txt_grd1.Text.Trim());
            replaceDict.Add("#eduqualify_grd2#", txt_grd2.Text.Trim());
            replaceDict.Add("#eduqualify_grd3#", txt_grd3.Text.Trim());
            replaceDict.Add("#eduqualify_grd4#", txt_grd4.Text.Trim());
            replaceDict.Add("#eduqualify_y1#", txt_y1.Text.Trim());
            replaceDict.Add("#eduqualify_y2#", txt_y2.Text.Trim());
            replaceDict.Add("#eduqualify_y3#", txt_y3.Text.Trim());
            replaceDict.Add("#eduqualify_y4#", txt_y4.Text.Trim());
            return replaceDict;
        }
        byte[] bimage;
        private void metroLink1_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
            }
            try
            {
                Bitmap bmp = new Bitmap(imgLocation);
                FileStream fs = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                bimage = new byte[fs.Length];
                fs.Read(bimage, 0, Convert.ToInt32(fs.Length));
                fs.Close();
            }
            catch(System.ArgumentException f)
            {
                
            }
            
        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {
         
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click_1(object sender, EventArgs e)
        {
            try
            {
                document.LoadFromFile(samplePath);
                //get strings to replace  
                Dictionary<string, string> dictReplace = GetReplaceDictionary2();
                //Replace text  
                foreach (KeyValuePair<string, string> kvp in dictReplace)
                {
                    document.Replace(kvp.Key, kvp.Value, true, true);
                }
                //Save doc file.  
                document.SaveToFile(docxPath, FileFormat.Docx);
                //Convert to PDF  
                document.SaveToFile(pdfPath, FileFormat.PDF);
                MessageBox.Show("Details added to word document", "doc processing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                document.Close();
                //ToViewFile(docxPath);
                //ToViewFile(pdfPath);
            }
            catch(System.ArgumentException)
            {
                MessageBox.Show(this, "Word document not created","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(System.IO.IOException)
            {
                MessageBox.Show(this, "Please close word document before adding data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        Dictionary<string, string> GetReplaceDictionary3()
        {
            Dictionary<string, string> replaceDict = new Dictionary<string, string>();
            replaceDict.Add("#acadqualify_inst1#", txt_ins1_nam.Text.Trim());
            replaceDict.Add("#acadqualify_inst2#", txt_ins2_nam.Text.Trim());
            replaceDict.Add("#acadqualify_inst3#", txt_ins3_nam.Text.Trim());
            replaceDict.Add("#acadqualify_inst4#", txt_ins4_nam.Text.Trim());
            replaceDict.Add("#acadqualify_inst5#", txt_ins5_nam.Text.Trim());
            replaceDict.Add("#acadqualify_ins1_certif1#", txt_ins1_det1.Text.Trim());
            replaceDict.Add("#acadqualify_ins1_certif2#", txt_ins1_det2.Text.Trim());
            replaceDict.Add("#acadqualify_ins1_certif3#", txt_ins1_det3.Text.Trim());
            replaceDict.Add("#acadqualify_ins1_certif4#", txt_ins1_det4.Text.Trim());
            replaceDict.Add("#acadqualify_ins1_certif5#", txt_ins1_det5.Text.Trim());
            replaceDict.Add("#acadqualify_ins2_certif1#", txt_ins2_det1.Text.Trim());
            replaceDict.Add("#acadqualify_ins2_certif2#", txt_ins2_det2.Text.Trim());
            replaceDict.Add("#acadqualify_ins2_certif3#", txt_ins2_det3.Text.Trim());
            replaceDict.Add("#acadqualify_ins2_certif4#", txt_ins2_det4.Text.Trim());
            replaceDict.Add("#acadqualify_ins2_certif5#", txt_ins2_det5.Text.Trim());
            replaceDict.Add("#acadqualify_ins3_certif1#", txt_ins3_det1.Text.Trim());
            replaceDict.Add("#acadqualify_ins3_certif2#", txt_ins3_det2.Text.Trim());
            replaceDict.Add("#acadqualify_ins3_certif3#", txt_ins3_det3.Text.Trim());
            replaceDict.Add("#acadqualify_ins3_certif4#", txt_ins3_det4.Text.Trim());
            replaceDict.Add("#acadqualify_ins3_certif5#", txt_ins3_det5.Text.Trim());
            replaceDict.Add("#acadqualify_ins4_certif1#", txt_ins4_det1.Text.Trim());
            replaceDict.Add("#acadqualify_ins4_certif2#", txt_ins4_det2.Text.Trim());
            replaceDict.Add("#acadqualify_ins4_certif3#", txt_ins4_det3.Text.Trim());
            replaceDict.Add("#acadqualify_ins4_certif4#", txt_ins4_det4.Text.Trim());
            replaceDict.Add("#acadqualify_ins4_certif5#", txt_ins4_det5.Text.Trim());
            replaceDict.Add("#acadqualify_ins5_certif1#", txt_ins5_det1.Text.Trim());
            replaceDict.Add("#acadqualify_ins5_certif2#", txt_ins5_det2.Text.Trim());
            replaceDict.Add("#acadqualify_ins5_certif3#", txt_ins5_det3.Text.Trim());
            replaceDict.Add("#acadqualify_ins5_certif4#", txt_ins5_det4.Text.Trim());
            replaceDict.Add("#acadqualify_ins5_certif5#", txt_ins5_det5.Text.Trim());
            replaceDict.Add("#academicaward1#", txt_acadaward_1.Text.Trim());
            replaceDict.Add("#academicaward2#", txt_acadaward_2.Text.Trim());
            replaceDict.Add("#academicaward3#", txt_acadaward_3.Text.Trim());
            return replaceDict;
        }
        private void btn_add2_Click(object sender, EventArgs e)
        {
            try
            {
                document.LoadFromFile(samplePath);
                //get strings to replace  
                Dictionary<string, string> dictReplace = GetReplaceDictionary3();
                //Replace text  
                foreach (KeyValuePair<string, string> kvp in dictReplace)
                {
                    document.Replace(kvp.Key, kvp.Value, true, true);
                }
                //Save doc file.  
                document.SaveToFile(docxPath, FileFormat.Docx);
                //Convert to PDF  
                document.SaveToFile(pdfPath, FileFormat.PDF);
                MessageBox.Show("Details added to word document", "doc processing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                document.Close();
                //ToViewFile(docxPath);
                //ToViewFile(pdfPath);
            }
            catch (System.ArgumentException)
            {
                MessageBox.Show(this, "Word document not created", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show(this, "Please close word document before adding data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        Dictionary<string, string> GetReplaceDictionary4()
        {
            Dictionary<string, string> replaceDict = new Dictionary<string, string>();
            replaceDict.Add("#prof_mem_ins1#", txt_mem_ins1.Text.Trim());
            replaceDict.Add("#prof_mem_ins2#", txt_mem_ins2.Text.Trim());
            replaceDict.Add("#prof_mem_ins3#", txt_mem_ins3.Text.Trim());
            replaceDict.Add("#prof_mem_ins4#", txt_mem_ins4.Text.Trim());
            replaceDict.Add("#prof_mem_ins5#", txt_mem_ins5.Text.Trim());
            replaceDict.Add("#prof_mem_mem1#", txt_mem_mem1.Text.Trim());
            replaceDict.Add("#prof_mem_mem2#", txt_mem_mem2.Text.Trim());
            replaceDict.Add("#prof_mem_mem3#", txt_mem_mem3.Text.Trim());
            replaceDict.Add("#prof_mem_mem4#", txt_mem_mem4.Text.Trim());
            replaceDict.Add("#prof_mem_mem5#", txt_mem_mem5.Text.Trim());
            replaceDict.Add("#prof_mem_y1#", txt_mem_y1.Text.Trim());
            replaceDict.Add("#prof_mem_y2#", txt_mem_y2.Text.Trim());
            replaceDict.Add("#prof_mem_y3#", txt_mem_y3.Text.Trim());
            replaceDict.Add("#prof_mem_y4#", txt_mem_y4.Text.Trim());
            replaceDict.Add("#prof_mem_y5#", txt_mem_y5.Text.Trim());
            return replaceDict;
        }
        private void btn_add3_Click(object sender, EventArgs e)
        {
            try
            {
                document.LoadFromFile(samplePath);
                //get strings to replace  
                Dictionary<string, string> dictReplace = GetReplaceDictionary4();
                //Replace text  
                foreach (KeyValuePair<string, string> kvp in dictReplace)
                {
                    document.Replace(kvp.Key, kvp.Value, true, true);
                }
                //Save doc file.  
                document.SaveToFile(docxPath, FileFormat.Docx);
                //Convert to PDF  
                document.SaveToFile(pdfPath, FileFormat.PDF);
                MessageBox.Show("Details added to word document", "doc processing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                document.Close();
                //ToViewFile(docxPath);
                //ToViewFile(pdfPath);
            }
            catch (System.ArgumentException)
            {
                MessageBox.Show(this, "Word document not created", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show(this, "Please close word document before adding data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        Dictionary<string, string> GetReplaceDictionary5()
        {
            Dictionary<string, string> replaceDict = new Dictionary<string, string>();
            replaceDict.Add("#prof_train_y1#", txt_proftrain_y1.Text.Trim());
            replaceDict.Add("#prof_train_y2#", txt_proftrain_y2.Text.Trim());
            replaceDict.Add("#prof_train_y3#", txt_proftrain_y3.Text.Trim());
            replaceDict.Add("#prof_train_y4#", txt_proftrain_y4.Text.Trim());
            replaceDict.Add("#prof_train_y5#", txt_proftrain_y5.Text.Trim());
            replaceDict.Add("#prof_train_ins1#", txt_proftrain_ins1.Text.Trim());
            replaceDict.Add("#prof_train_ins2#", txt_proftrain_ins2.Text.Trim());
            replaceDict.Add("#prof_train_ins3#", txt_proftrain_ins3.Text.Trim());
            replaceDict.Add("#prof_train_ins4#", txt_proftrain_ins4.Text.Trim());
            replaceDict.Add("#prof_train_ins5#", txt_proftrain_ins5.Text.Trim());
            replaceDict.Add("#prof_train_sub1#", txt_proftrain_sub1.Text.Trim());
            replaceDict.Add("#prof_train_sub2#", txt_proftrain_sub2.Text.Trim());
            replaceDict.Add("#prof_train_sub3#", txt_proftrain_sub3.Text.Trim());
            replaceDict.Add("#prof_train_sub4#", txt_proftrain_sub4.Text.Trim());
            replaceDict.Add("#prof_train_sub5#", txt_proftrain_sub5.Text.Trim());
            replaceDict.Add("#prof_train_prd1#", txt_proftrain_prd1.Text.Trim());
            replaceDict.Add("#prof_train_prd2#", txt_proftrain_prd2.Text.Trim());
            replaceDict.Add("#prof_train_prd3#", txt_proftrain_prd3.Text.Trim());
            replaceDict.Add("#prof_train_prd4#", txt_proftrain_prd4.Text.Trim());
            replaceDict.Add("#prof_train_prd5#", txt_proftrain_prd5.Text.Trim());
            return replaceDict;
        }
        private void metroTile1_Click_2(object sender, EventArgs e)
        {
            try
            {
                document.LoadFromFile(samplePath);
                //get strings to replace  
                Dictionary<string, string> dictReplace = GetReplaceDictionary5();
                //Replace text  
                foreach (KeyValuePair<string, string> kvp in dictReplace)
                {
                    document.Replace(kvp.Key, kvp.Value, true, true);
                }
                //Save doc file.  
                document.SaveToFile(docxPath, FileFormat.Docx);
                //Convert to PDF  
                document.SaveToFile(pdfPath, FileFormat.PDF);
                MessageBox.Show("Details added to word document", "doc processing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                document.Close();
                //ToViewFile(docxPath);
                //ToViewFile(pdfPath);
            }
            catch (System.ArgumentException)
            {
                MessageBox.Show(this, "Word document not created", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show(this, "Please close word document before adding data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        Dictionary<string, string> GetReplaceDictionary6()
        {
            Dictionary<string, string> replaceDict = new Dictionary<string, string>();
            replaceDict.Add("#tech_exp_ins1#", txt_te_ins1.Text.Trim());
            replaceDict.Add("#tech_exp_ins2#", txt_te_ins2.Text.Trim());
            replaceDict.Add("#tech_exp_ins3#", txt_te_ins3.Text.Trim());
            replaceDict.Add("#tech_exp_ins4#", txt_te_ins4.Text.Trim());
            replaceDict.Add("#tech_exp_ins5#", txt_te_ins5.Text.Trim());
            if(rbn_te_f_ins1.Checked==true)
            {
                replaceDict.Add("#tech_exp_fp1#", "Full time");

            }
            else if(rbn_te_p_ins1.Checked==true)
            {
                replaceDict.Add("#tech_exp_fp1#", "Part time");
            }
            else
            {
                replaceDict.Add("#tech_exp_fp1#", " ");

            }

            if (rbn_te_f_ins2.Checked == true)
            {
                replaceDict.Add("#tech_exp_fp2#", "Full time");

            }
            else if (rbn_te_p_ins2.Checked == true)
            {
                replaceDict.Add("#tech_exp_fp2#", "Part time");
            }
            else
            {
                replaceDict.Add("#tech_exp_fp2#", " ");

            }

            if (rbn_te_f_ins3.Checked == true)
            {
                replaceDict.Add("#tech_exp_fp3#", "Full time");

            }
            else if (rbn_te_p_ins3.Checked == true)
            {
                replaceDict.Add("#tech_exp_fp3#", "Part time");
            }
            else
            {
                replaceDict.Add("#tech_exp_fp3#", " ");

            }

            if (rbn_te_f_ins4.Checked == true)
            {
                replaceDict.Add("#tech_exp_fp4#", "Full time");

            }
            else if (rbn_te_p_ins4.Checked == true)
            {
                replaceDict.Add("#tech_exp_fp4#", "Part time");
            }
            else
            {
                replaceDict.Add("#tech_exp_fp4#", " ");

            }

            if (rbn_te_f_ins5.Checked == true)
            {
                replaceDict.Add("#tech_exp_fp5#", "Full time");

            }
            else if (rbn_te_p_ins5.Checked == true)
            {
                replaceDict.Add("#tech_exp_fp5#", "Part time");
            }
            else
            {
                replaceDict.Add("#tech_exp_fp5#", " ");

            }

            //////
            if(y1.Text=="")
            {
                replaceDict.Add("#tech_exp_frm1#", "");
                replaceDict.Add("#tech_exp_to1#", "");
                replaceDict.Add("#tech_exp_y1#", "");
            }
            else
            {
                replaceDict.Add("#tech_exp_frm1#",cldr_te_f1.Value.Date.ToString());
                replaceDict.Add("#tech_exp_to1#", cldr_te_t1.Value.Date.ToString());
                replaceDict.Add("#tech_exp_y1#", y1.Text.ToString());

            }

            if (y2.Text == "")
            {
                replaceDict.Add("#tech_exp_frm2#", "");
                replaceDict.Add("#tech_exp_to2#", "");
                replaceDict.Add("#tech_exp_y2#", "");
            }
            else
            {
                replaceDict.Add("#tech_exp_frm2#", cldr_te_f2.Value.Date.ToString());
                replaceDict.Add("#tech_exp_to2#", cldr_te_t2.Value.Date.ToString());
                replaceDict.Add("#tech_exp_y2#", y2.Text.ToString());

            }

            if (y3.Text == "")
            {
                replaceDict.Add("#tech_exp_frm3#", "");
                replaceDict.Add("#tech_exp_to3#", "");
                replaceDict.Add("#tech_exp_y3#", "");
            }
            else
            {
                replaceDict.Add("#tech_exp_frm3#", cldr_te_f3.Value.Date.ToString());
                replaceDict.Add("#tech_exp_to3#", cldr_te_t3.Value.Date.ToString());
                replaceDict.Add("#tech_exp_y3#", y3.Text.ToString());

            }

            if (y4.Text == "")
            {
                replaceDict.Add("#tech_exp_frm4#", "");
                replaceDict.Add("#tech_exp_to4#", "");
                replaceDict.Add("#tech_exp_y4#", "");
            }
            else
            {
                replaceDict.Add("#tech_exp_frm4#", cldr_te_f4.Value.Date.ToString());
                replaceDict.Add("#tech_exp_to4#", cldr_te_t4.Value.Date.ToString());
                replaceDict.Add("#tech_exp_y4#", y4.Text.ToString());

            }

            if (y5.Text == "")
            {
                replaceDict.Add("#tech_exp_frm5#", "");
                replaceDict.Add("#tech_exp_to5#", "");
                replaceDict.Add("#tech_exp_y5#", "");
            }
            else
            {
                replaceDict.Add("#tech_exp_frm5#", cldr_te_f5.Value.Date.ToString());
                replaceDict.Add("#tech_exp_to5#", cldr_te_t5.Value.Date.ToString());
                replaceDict.Add("#tech_exp_y5#", y5.Text.ToString());

            }
            replaceDict.Add("#tech_exp_sub1#", txt_te_sub_1.Text.Trim());
            replaceDict.Add("#tech_exp_sub2#", txt_te_sub_2.Text.Trim());
            replaceDict.Add("#tech_exp_sub3#", txt_te_sub_3.Text.Trim());
            replaceDict.Add("#tech_exp_sub4#", txt_te_sub_4.Text.Trim());
            replaceDict.Add("#tech_exp_sub5#", txt_te_sub_5.Text.Trim());
            return replaceDict;
        }
        private void metroTile2_Click(object sender, EventArgs e)
        {
            try
            {
                document.LoadFromFile(samplePath);
                //get strings to replace  
                Dictionary<string, string> dictReplace = GetReplaceDictionary6();
                //Replace text  
                foreach (KeyValuePair<string, string> kvp in dictReplace)
                {
                    document.Replace(kvp.Key, kvp.Value, true, true);
                }
                //Save doc file.  
                document.SaveToFile(docxPath, FileFormat.Docx);
                //Convert to PDF  
                document.SaveToFile(pdfPath, FileFormat.PDF);
                MessageBox.Show("Details added to word document", "doc processing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                document.Close();
                //ToViewFile(docxPath);
                //ToViewFile(pdfPath);
            }
            catch (System.ArgumentException)
            {
                MessageBox.Show(this, "Word document not created", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show(this, "Please close word document before adding data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cldr_te_t1_ValueChanged(object sender, EventArgs e)
        {
            if (cldr_te_t1.Value < cldr_te_f1.Value)
            {
                MessageBox.Show(this, "'From' date is greater than 'To' date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                y1.Text = "";
            }
            else
            {
                if (cldr_te_f1.Value != cldr_te_t1.Value)
                {
                    y1.Text = Convert.ToString(cldr_te_t1.Value.Year - cldr_te_f1.Value.Year);
                }
                else
                {
                    y1.Text = "";
                }
            }
        }
        private void cldr_te_f1_ValueChanged(object sender, EventArgs e)
        {
            if (cldr_te_t1.Value < cldr_te_f1.Value)
            {
                MessageBox.Show(this, "'From' date is greater than 'To' date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                y1.Text = "";
            }
            else
            {
                if (cldr_te_f1.Value != cldr_te_t1.Value)
                {
                    y1.Text = Convert.ToString(cldr_te_t1.Value.Year - cldr_te_f1.Value.Year);
                }
                else
                {
                    y1.Text = "";
                }
            }
        }

        private void cldr_te_f2_ValueChanged(object sender, EventArgs e)
        {
            if (cldr_te_t2.Value < cldr_te_f2.Value)
            {
                MessageBox.Show(this, "'From' date is greater than 'To' date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                y2.Text = "";
            }
            else
            {
                if (cldr_te_f2.Value != cldr_te_t2.Value)
                {
                    y2.Text = Convert.ToString(cldr_te_t2.Value.Year - cldr_te_f2.Value.Year);
                }
                else
                {
                    y2.Text = "";
                }
            }
        }

        private void cldr_te_t2_ValueChanged(object sender, EventArgs e)
        {
            if (cldr_te_t2.Value < cldr_te_f2.Value)
            {
                MessageBox.Show(this, "'From' date is greater than 'To' date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                y2.Text = "";
            }
            else
            {
                if (cldr_te_f2.Value != cldr_te_t2.Value)
                {
                    y2.Text = Convert.ToString(cldr_te_t2.Value.Year - cldr_te_f2.Value.Year);
                }
                else
                {
                    y2.Text = "";
                }
            }
        }

        private void cldr_te_f3_ValueChanged(object sender, EventArgs e)
        {
            if (cldr_te_t3.Value < cldr_te_f3.Value)
            {
                MessageBox.Show(this, "'From' date is greater than 'To' date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                y3.Text = "";
            }
            else
            {
                if (cldr_te_f3.Value != cldr_te_t3.Value)
                {
                    y3.Text = Convert.ToString(cldr_te_t3.Value.Year - cldr_te_f3.Value.Year);
                }
                else
                {
                    y3.Text = "";
                }
            }
        }

        private void cldr_te_t3_ValueChanged(object sender, EventArgs e)
        {
            if (cldr_te_t3.Value < cldr_te_f3.Value)
            {
                MessageBox.Show(this, "'From' date is greater than 'To' date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                y3.Text = "";
            }
            else
            {
                if (cldr_te_f3.Value != cldr_te_t3.Value)
                {
                    y3.Text = Convert.ToString(cldr_te_t3.Value.Year - cldr_te_f3.Value.Year);
                }
                else
                {
                    y3.Text = "";
                }
            }
        }

        private void cldr_te_f4_ValueChanged(object sender, EventArgs e)
        {
            if (cldr_te_t4.Value < cldr_te_f4.Value)
            {
                MessageBox.Show(this, "'From' date is greater than 'To' date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                y4.Text = "";
            }
            else
            {
                if (cldr_te_f4.Value != cldr_te_t4.Value)
                {
                    y4.Text = Convert.ToString(cldr_te_t4.Value.Year - cldr_te_f4.Value.Year);
                }
                else
                {
                    y4.Text = "";
                }
            }
        }

        private void cldr_te_t4_ValueChanged(object sender, EventArgs e)
        {
            if (cldr_te_t4.Value < cldr_te_f4.Value)
            {
                MessageBox.Show(this, "'From' date is greater than 'To' date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                y4.Text = "";
            }
            else
            {
                if (cldr_te_f4.Value != cldr_te_t4.Value)
                {
                    y4.Text = Convert.ToString(cldr_te_t4.Value.Year - cldr_te_f4.Value.Year);
                }
                else
                {
                    y4.Text = "";
                }
            }
        }

        private void cldr_te_f5_ValueChanged(object sender, EventArgs e)
        {
            if (cldr_te_t5.Value < cldr_te_f5.Value)
            {
                MessageBox.Show(this, "'From' date is greater than 'To' date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                y5.Text = "";
            }
            else
            {
                if (cldr_te_f5.Value != cldr_te_t5.Value)
                {
                    y5.Text = Convert.ToString(cldr_te_t5.Value.Year - cldr_te_f5.Value.Year);
                }
                else
                {
                    y5.Text = "";
                }
            }
        }

        private void groupBox13_Enter(object sender, EventArgs e)
        {

        }

        private void cldr_te_t5_ValueChanged(object sender, EventArgs e)
        {
            if (cldr_te_t5.Value < cldr_te_f5.Value)
            {
                MessageBox.Show(this, "'From' date is greater than 'To' date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                y5.Text = "";
            }
            else
            {
                if (cldr_te_f5.Value != cldr_te_t5.Value)
                {
                    y5.Text = Convert.ToString(cldr_te_t5.Value.Year - cldr_te_f5.Value.Year);
                }
                else
                {
                    y5.Text = "";
                }
            }
        }
        Dictionary<string, string> GetReplaceDictionary7()
        {
            Dictionary<string, string> replaceDict = new Dictionary<string, string>();
            replaceDict.Add("#work_exp_desi1#", txt_we_desi1.Text.Trim());
            replaceDict.Add("#work_exp_desi2#", txt_we_desi2.Text.Trim());
            replaceDict.Add("#work_exp_desi3#", txt_we_desi3.Text.Trim());
            replaceDict.Add("#work_exp_desi4#", txt_we_desi4.Text.Trim());
            replaceDict.Add("#work_exp_desi5#", txt_we_desi5.Text.Trim());
            if (rbn_we_ft1.Checked == true)
            {
                replaceDict.Add("#work_exp_fp1#", "Full time");

            }
            else if (rbn_we_pt1.Checked == true)
            {
                replaceDict.Add("#work_exp_fp1#", "Part time");
            }
            else
            {
                replaceDict.Add("#work_exp_fp1#", " ");
            }

            if (rbn_we_ft2.Checked == true)
            {
                replaceDict.Add("#work_exp_fp2#", "Full time");

            }
            else if (rbn_we_pt2.Checked == true)
            {
                replaceDict.Add("#work_exp_fp2#", "Part time");
            }
            else
            {
                replaceDict.Add("#work_exp_fp2#", " ");
            }

            if (rbn_we_ft3.Checked == true)
            {
                replaceDict.Add("#work_exp_fp3#", "Full time");

            }
            else if (rbn_we_pt3.Checked == true)
            {
                replaceDict.Add("#work_exp_fp3#", "Part time");
            }
            else
            {
                replaceDict.Add("#work_exp_fp3#", " ");
            }

            if (rbn_we_ft4.Checked == true)
            {
                replaceDict.Add("#work_exp_fp4#", "Full time");

            }
            else if (rbn_we_pt4.Checked == true)
            {
                replaceDict.Add("#work_exp_fp4#", "Part time");
            }
            else
            {
                replaceDict.Add("#work_exp_fp4#", " ");
            }

            if (rbn_we_ft5.Checked == true)
            {
                replaceDict.Add("#work_exp_fp5#", "Full time");

            }
            else if (rbn_we_pt5.Checked == true)
            {
                replaceDict.Add("#work_exp_fp5#", "Part time");
            }
            else
            {
                replaceDict.Add("#work_exp_fp5#", " ");
            }

            //////
            if (we_y_1.Text == "")
            {
                replaceDict.Add("#work_exp_frm1#", "");
                replaceDict.Add("#work_exp_to1#", "");
                replaceDict.Add("#work_exp_y1#", "");
            }
            else
            {
                replaceDict.Add("#work_exp_frm1#", cldr_we_from1.Value.ToString());
                replaceDict.Add("#work_exp_to1#", cldr_we_To1.Value.Date.ToString());
                replaceDict.Add("#work_exp_y1#", we_y_1.Text.ToString());
            }

            if (we_y_2.Text == "")
            {
                replaceDict.Add("#work_exp_frm2#", "");
                replaceDict.Add("#work_exp_to2#", "");
                replaceDict.Add("#work_exp_y2#", "");
            }
            else
            {
                replaceDict.Add("#work_exp_frm2#", cldr_we_from2.Value.Date.ToString());
                replaceDict.Add("#work_exp_to2#", cldr_we_To2.Value.Date.ToString());
                replaceDict.Add("#work_exp_y2#", we_y_2.Text.ToString());
            }

            if (we_y_3.Text == "")
            {
                replaceDict.Add("#work_exp_frm3#", "");
                replaceDict.Add("#work_exp_to3#", "");
                replaceDict.Add("#work_exp_y3#", "");
            }
            else
            {
                replaceDict.Add("#work_exp_frm3#", cldr_we_from3.Value.Date.ToString());
                replaceDict.Add("#work_exp_to3#", cldr_we_To3.Value.Date.ToString());
                replaceDict.Add("#work_exp_y3#", we_y_3.Text.ToString());
            }

            if (we_y_4.Text == "")
            {
                replaceDict.Add("#work_exp_frm4#", "");
                replaceDict.Add("#work_exp_to4#", "");
                replaceDict.Add("#work_exp_y4#", "");
            }
            else
            {
                replaceDict.Add("#work_exp_frm4#", cldr_we_from4.Value.Date.ToString());
                replaceDict.Add("#work_exp_to4#", cldr_we_To4.Value.Date.ToString());
                replaceDict.Add("#work_exp_y4#", we_y_4.Text.ToString());
            }

            if (we_y_5.Text == "")
            {
                replaceDict.Add("#work_exp_frm5#", "");
                replaceDict.Add("#work_exp_to5#", "");
                replaceDict.Add("#work_exp_y5#", "");
            }
            else
            {
                replaceDict.Add("#work_exp_frm5#", cldr_we_from5.Value.Date.ToString());
                replaceDict.Add("#work_exp_to5#", cldr_we_To5.Value.Date.ToString());
                replaceDict.Add("#work_exp_y5#", we_y_5.Text.ToString());
            }
            replaceDict.Add("#work_exp_org1#", txt_we_org1.Text.Trim());
            replaceDict.Add("#work_exp_org2#", txt_we_org2.Text.Trim());
            replaceDict.Add("#work_exp_org3#", txt_we_org3.Text.Trim());
            replaceDict.Add("#work_exp_org4#", txt_we_org4.Text.Trim());
            replaceDict.Add("#work_exp_org5#", txt_we_org5.Text.Trim());
            return replaceDict;
        }
        private void metroTile3_Click(object sender, EventArgs e)
        {
            try
            {
                document.LoadFromFile(samplePath);
                //get strings to replace  
                Dictionary<string, string> dictReplace = GetReplaceDictionary7();
                //Replace text  
                foreach (KeyValuePair<string, string> kvp in dictReplace)
                {
                    document.Replace(kvp.Key, kvp.Value, true, true);
                }
                //Save doc file.  
                document.SaveToFile(docxPath, FileFormat.Docx);
                //Convert to PDF  
                document.SaveToFile(pdfPath, FileFormat.PDF);
                MessageBox.Show("Details added to word document", "doc processing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                document.Close();
               // ToViewFile(docxPath);
                //ToViewFile(pdfPath);
            }
            catch (System.ArgumentException)
            {
                MessageBox.Show(this, "Word document not created", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show(this, "Please close word document before adding data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cldr_we_from1_ValueChanged(object sender, EventArgs e)
        {
            if (cldr_we_To1.Value < cldr_we_from1.Value)
            {
                MessageBox.Show(this, "'From' date is greater than 'To' date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                we_y_1.Text = "";
            }
            else
            {
                if (cldr_we_from1.Value != cldr_we_To1.Value)
                {
                    we_y_1.Text = Convert.ToString(cldr_we_To1.Value.Year - cldr_we_from1.Value.Year);
                }
                else
                {
                    we_y_1.Text = "";
                }
            }
        }

        private void cldr_we_To1_ValueChanged(object sender, EventArgs e)
        {
            if (cldr_we_To1.Value < cldr_we_from1.Value)
            {
                MessageBox.Show(this, "'From' date is greater than 'To' date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                we_y_1.Text = "";
            }
            else
            {
                if (cldr_we_from1.Value != cldr_we_To1.Value)
                {
                    we_y_1.Text = Convert.ToString(cldr_we_To1.Value.Year - cldr_we_from1.Value.Year);
                }
                else
                {
                    we_y_1.Text = "";
                }
            }
        }

        private void cldr_we_from2_ValueChanged(object sender, EventArgs e)
        {
            if (cldr_we_To2.Value < cldr_we_from2.Value)
            {
                MessageBox.Show(this, "'From' date is greater than 'To' date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                we_y_2.Text = "";
            }
            else
            {
                if (cldr_we_from2.Value != cldr_we_To2.Value)
                {
                    we_y_2.Text = Convert.ToString(cldr_we_To2.Value.Year - cldr_we_from2.Value.Year);
                }
                else
                {
                    we_y_2.Text = "";
                }
            }
        }

        private void cldr_we_To2_ValueChanged(object sender, EventArgs e)
        {
            if (cldr_we_To2.Value < cldr_we_from2.Value)
            {
                MessageBox.Show(this, "'From' date is greater than 'To' date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                we_y_2.Text = "";
            }
            else
            {
                if (cldr_we_from2.Value != cldr_we_To2.Value)
                {
                    we_y_2.Text = Convert.ToString(cldr_we_To2.Value.Year - cldr_we_from2.Value.Year);
                }
                else
                {
                    we_y_2.Text = "";
                }
            }
        }

        private void cldr_we_from3_ValueChanged(object sender, EventArgs e)
        {
            if (cldr_we_To3.Value < cldr_we_from3.Value)
            {
                MessageBox.Show(this, "'From' date is greater than 'To' date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                we_y_3.Text = "";
            }
            else
            {
                if (cldr_we_from3.Value != cldr_we_To3.Value)
                {
                    we_y_3.Text = Convert.ToString(cldr_we_To3.Value.Year - cldr_we_from3.Value.Year);
                }
                else
                {
                    we_y_3.Text = "";
                }
            }
        }

        private void cldr_we_To3_ValueChanged(object sender, EventArgs e)
        {
            if (cldr_we_To3.Value < cldr_we_from3.Value)
            {
                MessageBox.Show(this, "'From' date is greater than 'To' date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                we_y_3.Text = "";
            }
            else
            {
                if (cldr_we_from3.Value != cldr_we_To3.Value)
                {
                    we_y_3.Text = Convert.ToString(cldr_we_To3.Value.Year - cldr_we_from3.Value.Year);
                }
                else
                {
                    we_y_3.Text = "";
                }
            }
        }

        private void cldr_we_from4_ValueChanged(object sender, EventArgs e)
        {
            if (cldr_we_To4.Value < cldr_we_from4.Value)
            {
                MessageBox.Show(this, "'From' date is greater than 'To' date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                we_y_4.Text = "";
            }
            else
            {
                if (cldr_we_from4.Value != cldr_we_To4.Value)
                {
                    we_y_4.Text = Convert.ToString(cldr_we_To4.Value.Year - cldr_we_from4.Value.Year);
                }
                else
                {
                    we_y_4.Text = "";
                }
            }
        }

        private void cldr_we_To4_ValueChanged(object sender, EventArgs e)
        {
            if (cldr_we_To4.Value < cldr_we_from4.Value)
            {
                MessageBox.Show(this, "'From' date is greater than 'To' date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                we_y_4.Text = "";
            }
            else
            {
                if (cldr_we_from4.Value != cldr_we_To4.Value)
                {
                    we_y_4.Text = Convert.ToString(cldr_we_To4.Value.Year - cldr_we_from4.Value.Year);
                }
                else
                {
                    we_y_4.Text = "";
                }
            }
        }

        private void cldr_we_from5_ValueChanged(object sender, EventArgs e)
        {
            if (cldr_we_To5.Value < cldr_we_from5.Value)
            {
                MessageBox.Show(this, "'From' date is greater than 'To' date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                we_y_5.Text = "";
            }
            else
            {
                if (cldr_we_from5.Value != cldr_we_To5.Value)
                {
                    we_y_5.Text = Convert.ToString(cldr_we_To5.Value.Year - cldr_we_from5.Value.Year);
                }
                else
                {
                    we_y_5.Text = "";
                }
            }
        }

        private void cldr_we_To5_ValueChanged(object sender, EventArgs e)
        {
            if (cldr_we_To5.Value < cldr_we_from5.Value)
            {
                MessageBox.Show(this, "'From' date is greater than 'To' date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                we_y_5.Text = "";
            }
            else
            {
                if (cldr_we_from5.Value != cldr_we_To5.Value)
                {
                    we_y_5.Text = Convert.ToString(cldr_we_To5.Value.Year - cldr_we_from5.Value.Year);
                }
                else
                {
                    we_y_5.Text = "";
                }
            }
        }
        Dictionary<string, string> GetReplaceDictionary8()
        {
            Dictionary<string, string> replaceDict = new Dictionary<string, string>();
            replaceDict.Add("#subs_ar_sub1#", cmb_sa_1.Text.Trim());
            replaceDict.Add("#subs_ar_sub2#", cmb_sa_2.Text.Trim());
            replaceDict.Add("#subs_ar_sub3#", cmb_sa_3.Text.Trim());
            replaceDict.Add("#subs_ar_sub4#", cmb_sa_4.Text.Trim());
            replaceDict.Add("#subs_ar_sub5#", cmb_sa_5.Text.Trim());
            replaceDict.Add("#subs_ar_med1#", med_1.Text.Trim());
            replaceDict.Add("#subs_ar_med2#", med_2.Text.Trim());
            replaceDict.Add("#subs_ar_med3#", med_3.Text.Trim());
            replaceDict.Add("#subs_ar_med4#", med_4.Text.Trim());
            replaceDict.Add("#subs_ar_med5#", med_5.Text.Trim());
            if(rbn_ar_1.Checked==true)
            {
                replaceDict.Add("#area1#", "Colombo");
            }
            else
            {
                replaceDict.Add("#area1#", "");

            }
            if (rbn_ar_2.Checked == true)
            {
                replaceDict.Add("#area2#", "Kandy");
            }
            else
            {
                replaceDict.Add("#area2#", "");

            }
            if (rbn_ar_3.Checked == true)
            {
                replaceDict.Add("#area3#", "Kurunegala");
            }
            else
            {
                replaceDict.Add("#area3#", "");

            }
            if (rbn_ar_4.Checked == true)
            {
                replaceDict.Add("#area4#", "Badulla");
            }
            else
            {
                replaceDict.Add("#area4#", "");

            }
            if (rbn_ar_5.Checked == true)
            {
                replaceDict.Add("#area5#", "Kilinochchi");
            }
            else
            {
                replaceDict.Add("#area5#", "");

            }
            return replaceDict;
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            try
            {
                int g = db.singleInt("SELECT COUNT(*) FROM Lecture_details WHERE Lecturer_no='" + h + "'");
                if (g == 1)
                {
                    if (cmb_sa_1.Text == "" || cmb_sa_2.Text == "" || cmb_sa_3.Text == "")
                    {
                        MessageBox.Show(this, "Please select at least 3 specific areas", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (cmb_sa_1.Text != "" && med_1.Text == "")
                    {
                        MessageBox.Show(this, "Please select medium for specific area -1", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (cmb_sa_2.Text != "" && med_2.Text == "")
                    {
                        MessageBox.Show(this, "Please select medium for specific area -2", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (cmb_sa_3.Text != "" && med_3.Text == "")
                    {
                        MessageBox.Show(this, "Please select medium for specific area -3", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        db.update("UPDATE Lecture_details SET lecturer_specific_area_1='" + cmb_sa_1.Text + "',medium_1='" + med_1.Text + "',lecturer_specific_area_2='" + cmb_sa_2.Text + "',medium_2='" + med_2.Text + "',lecturer_specific_area_3='" + cmb_sa_3.Text + "',medium_3='" + med_3.Text + "' WHERE Lecturer_no='" + h + "'");
                        MessageBox.Show(this, "Successfuly updated record", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        document.LoadFromFile(samplePath);
                        //get strings to replace  
                        Dictionary<string, string> dictReplace = GetReplaceDictionary8();
                        //Replace text  
                        foreach (KeyValuePair<string, string> kvp in dictReplace)
                        {
                            document.Replace(kvp.Key, kvp.Value, true, true);
                        }
                        //Save doc file.  
                        document.SaveToFile(docxPath, FileFormat.Docx);
                        //Convert to PDF  
                        //document.SaveToFile(pdfPath, FileFormat.PDF);
                        MessageBox.Show("Details added to word document", "doc processing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        document.Close();
                        //ToViewFile(docxPath);
                        //ToViewFile(pdfPath);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Please add lecturers personal details");
                }
            }
            catch (System.ArgumentException)
            {
                MessageBox.Show(this, "Word document not created", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show(this, "Please close word document before adding data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Credentials.connection);
            con.Open();
            string[] name1 = new string[100];
            Array.Clear(name1, 0, 100);
            SqlCommand cmd1 = new SqlCommand("SELECT area FROM Lec_specific_areas WHERE area !='" + cmb_sa_1.Text + "' AND area !='"+cmb_sa_2.Text+"'", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            int count = 0;
            while (dr1.Read())
            {
                name1[count] = Convert.ToString(dr1.GetValue(0));
                count++;
            }
            cmb_sa_3.DataSource = name1;
            dr1.Close();
            con.Close();

        }

        private void cmb_sa_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Credentials.connection);
            con.Open();
            string[] name1 = new string[100];
            Array.Clear(name1, 0, 100);
            SqlCommand cmd1 = new SqlCommand("SELECT area FROM Lec_specific_areas WHERE area !='"+cmb_sa_1.Text+"'", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            int count = 0;
            while (dr1.Read())
            {
                name1[count] = Convert.ToString(dr1.GetValue(0));
                count++;
            }
            cmb_sa_2.DataSource = name1;
            dr1.Close();
            con.Close();
        }

        private void cmb_sa_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Credentials.connection);
            con.Open();
            string[] name1 = new string[100];
            Array.Clear(name1, 0, 100);
            SqlCommand cmd1 = new SqlCommand("SELECT area FROM Lec_specific_areas WHERE area !='" + cmb_sa_1.Text + "' AND area !='" + cmb_sa_2.Text + "' AND area !='" + cmb_sa_3.Text + "'", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            int count = 0;
            while (dr1.Read())
            {
                name1[count] = Convert.ToString(dr1.GetValue(0));
                count++;
            }
            cmb_sa_4.DataSource = name1;
            dr1.Close();
            con.Close();
        }

        private void cmb_sa_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Credentials.connection);
            con.Open();
            string[] name1 = new string[100];
            Array.Clear(name1, 0, 100);
            SqlCommand cmd1 = new SqlCommand("SELECT area FROM Lec_specific_areas WHERE area !='" + cmb_sa_1.Text + "' AND area !='" + cmb_sa_2.Text + "' AND area !='" + cmb_sa_3.Text + "' AND area !='" + cmb_sa_4.Text + "'", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            int count = 0;
            while (dr1.Read())
            {
                name1[count] = Convert.ToString(dr1.GetValue(0));
                count++;
            }
            cmb_sa_5.DataSource = name1;
            dr1.Close();
            con.Close();
        }

        private void metroTabPage5_Click(object sender, EventArgs e)
        {

        }

        private void metroGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox26_Enter(object sender, EventArgs e)
        {

        }

        private void view_1_Click(object sender, EventArgs e)
        {
            if (location.Text == "location")
            {
                MessageBox.Show("Please select location to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ToViewFile(docxPath);
                //ToViewFile(pdfPath);
            }
        }

        private void view_2_Click(object sender, EventArgs e)
        {
            if (location.Text == "location")
            {
                MessageBox.Show("Please select location to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ToViewFile(docxPath);
            }
            //ToViewFile(pdfPath);
        }

        private void view_3_Click(object sender, EventArgs e)
        {
            if (location.Text == "location")
            {
                MessageBox.Show("Please select location to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ToViewFile(docxPath);
                //ToViewFile(pdfPath);
            }
        }

        private void view_4_Click(object sender, EventArgs e)
        {
            if (location.Text == "location")
            {
                MessageBox.Show("Please select location to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ToViewFile(docxPath);
                //ToViewFile(pdfPath);
            }
        }

        private void view_5_Click(object sender, EventArgs e)
        {
            if (location.Text == "location")
            {
                MessageBox.Show("Please select location to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ToViewFile(docxPath);
                //ToViewFile(pdfPath);
            }
        }

        private void view_6_Click(object sender, EventArgs e)
        {
            if (location.Text == "location")
            {
                MessageBox.Show("Please select location to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ToViewFile(docxPath);
                //ToViewFile(pdfPath);
            }
        }

        private void view_7_Click(object sender, EventArgs e)
        {
            if (location.Text == "location")
            {
                MessageBox.Show("Please select location to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ToViewFile(docxPath);
                //ToViewFile(pdfPath);
            }
        }

        private void metroTile11_Click(object sender, EventArgs e)
        {
            if (location.Text == "location")
            {
                MessageBox.Show("Please select location to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ToViewFile(docxPath);
                //ToViewFile(pdfPath);
            }
        }

        private void pdf_view_Click(object sender, EventArgs e)
        {
            try
            {
                if (samplePath == Application.StartupPath + Path.DirectorySeparatorChar + "Lecturer_application_template.docx")
                {
                    MessageBox.Show(this, "Word document not created", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    document.LoadFromFile(samplePath);
                    document.SaveToFile(pdfPath, FileFormat.PDF);
                    MessageBox.Show(this, "Succefully created word document", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    document.Close();
                    ToViewFile(pdfPath);
                }
            }
            catch (System.ArgumentException)
            {
                MessageBox.Show(this, "Word document not created", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show(this, "Please close word document before adding data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void chk_mail_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txt_address_TextChanged(object sender, EventArgs e)
        {
            if (txt_address.Text == ""  || txt_address.SelectedIndex > -1)
            {

            }
            else
            {
                G_maps.autocomplete_place_combobox(txt_address);
            }
        }
        string save_file_to;
        private void metroButton1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Custom Description";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                save_file_to = fbd.SelectedPath;
            }
            location.Text = @save_file_to;
            //MessageBox.Show(save_file_to);
        }
    }
}
