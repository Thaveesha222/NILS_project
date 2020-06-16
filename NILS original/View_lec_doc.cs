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
using System.IO;
using Microsoft.Office.Interop.Word;
using System.Diagnostics;

namespace NILS_original
{
    public partial class View_lec_doc : MetroFramework.Forms.MetroForm
    {
        public View_lec_doc()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            metroDateTime1.Format = DateTimePickerFormat.Custom;
            metroDateTime1.CustomFormat = "dd-MM-yyyy";
            metroDateTime2.Format = DateTimePickerFormat.Custom;
            metroDateTime2.CustomFormat = "dd-MM-yyyy";
            
        }
        SqlConnection con = new SqlConnection(Credentials.connection);

        private void metroTile1_Click(object sender, EventArgs e)
        {

        }
        
        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex].HeaderText == "View Lecturer Profile")
                {
                    string no = metroGrid1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string name = metroGrid1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string[] allFiles = System.IO.Directory.GetFiles("C:\\Users\\94762\\Desktop\\lecs");
                    foreach (string file in allFiles)
                    {
                        string[] n = file.Split('_');
                        if (file.Contains(metroGrid1.Rows[e.RowIndex].Cells[0].Value.ToString()) && file.Contains("docx"))
                        {
                            Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();
                            Document document = ap.Documents.Open(file);
                        }

                    }
                }
                else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex].HeaderText == "Edit Lecturers details")
                {
                    //Edit_lec_details.no = metroGrid1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    Edit_lec_details p = new Edit_lec_details();
                    p.Show();
                }  

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("wef");
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                MessageBox.Show(this, "File not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void metroButton1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Folder for lecturer profiles";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string sSelectedPath = fbd.SelectedPath;
                //metroLabel2.Text = sSelectedPath;
            }
        }
        List<string> autocmplt = new List<string>();
        private void View_lec_doc_Load(object sender, EventArgs e)
        {
            
            autocmplt= General_methods.fill_Resource_persons_combobox();
            
        }

        private void txt_lec_TextChanged(object sender, EventArgs e)
        {
            General_methods.combobox_autocomplete(txt_lec,autocmplt);
        }

        private void txt_lec_SelectedIndexChanged(object sender, EventArgs e)
        {
            metroGrid1.DataSource = null;
            metroGrid2.DataSource = null;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Lecturer_no,CONCAT(F_name,' ',L_name),NIC,mobile_no_1,tel_no,email,address FROM Lecture_details WHERE Lecturer_no='" + txt_lec.Text.Split('-').GetValue(0).ToString() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            lbl_lec_no.Text = dr.GetValue(0).ToString();
            lbl_lec_name.Text = dr.GetValue(1).ToString();
            lbl_NIC.Text= dr.GetValue(2).ToString();
            lbl_mob_no.Text= dr.GetValue(3).ToString();
            lbl_tel_no.Text= dr.GetValue(4).ToString();
            lbl_email.Text = dr.GetValue(5).ToString();
            //lbl_home_no.Text = dr.GetValue(6).ToString();
            lbl_street.Text= dr.GetValue(6).ToString();
            dr.Close();
            /*DataGridViewTextBoxColumn t1 = new DataGridViewTextBoxColumn();
            t1.HeaderText = "Specific Area";
            t1.Name = "Specific Area";
            t1.Width = 250;
            metroGrid1.Columns.Add(t1);
            DataGridViewTextBoxColumn t2 = new DataGridViewTextBoxColumn();
            t2.HeaderText = "Medium";
            t2.Name = "Medium";
            t2.Width = 250;
            metroGrid1.Columns.Add(t2);*/
            metroPanel1.Visible = true;
            General_methods.get_lec_pic(pictureBox1, lbl_lec_no.Text);
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("Lecturer Specific area");
            dt.Columns.Add("medium");
            metroGrid1.DataSource = d.show("SELECT specific_area  FROM Rp_selected_specific_areas WHERE Lec_no='" + lbl_lec_no.Text+"'");
            //metroGrid1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            metroGrid3.DataSource = d.show("SELECT Area_preffered_teaching FROM Rp_area_preffered WHERE Lec_no='"+lbl_lec_no.Text+"'");

            con.Close();
        }
        Database d = new Database();
        private void metroTile1_Click_1(object sender, EventArgs e)
        {
            metroGrid2.DataSource = null;
            metroGrid2.DataSource = d.show("SELECT program_no,course_type,scheduled_date FROM Session_details WHERE (Resource_person_1='" + lbl_lec_no.Text + "' OR Resource_person_2='" + lbl_lec_no.Text + " ' OR Resource_person_3='" + lbl_lec_no.Text + "') AND scheduled_date BETWEEN '" + metroDateTime1.Value + "' AND '" + metroDateTime2.Value + "'");

        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            Process.Start("chrome.exe", d.singleString("SELECT path FROM Lecture_details WHERE Lecturer_no='"+lbl_lec_no.Text+"'"));
            /*if (metroLabel2.Text == "Add Folder")
            {
                MessageBox.Show("Please select the folder which contains the lecturers word and pdf profiles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    System.Diagnostics.Process.Start(metroLabel2.Text + '\\' + lbl_lec_no.Text + "_" + lbl_lec_name.Text.Split(' ').GetValue(0) + "_" + lbl_lec_name.Text.Split(' ').GetValue(1) + "_.docx");
                    //MessageBox.Show(metroLabel2.Text + '\\' +lbl_lec_no.Text+"_"+ lbl_lec_name.Text.Split(' ').GetValue(0) + "_" + lbl_lec_name.Text.Split(' ').GetValue(1) + "_.docx");
                }
                catch (System.ComponentModel.Win32Exception x)
                {
                    MessageBox.Show("File not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }*/
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            /*if (metroLabel2.Text == "Add Folder")
            {
                MessageBox.Show("Please select the folder which contains the lecturers word and pdf profiles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    System.Diagnostics.Process.Start(metroLabel2.Text + '\\' + lbl_lec_no.Text + "_" + lbl_lec_name.Text.Split(' ').GetValue(0) + "_" + lbl_lec_name.Text.Split(' ').GetValue(1) + "_.pdf");
                }
                catch (System.ComponentModel.Win32Exception x)
                {
                    MessageBox.Show("File not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }*/
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            Edit_lec_details b = new Edit_lec_details();
            b.no = lbl_lec_no.Text;
            b.Show();
        }
    }
}
