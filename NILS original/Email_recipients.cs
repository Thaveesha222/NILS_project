using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NILS_original
{
    public partial class Email_recipients : MetroFramework.Forms.MetroForm
    {
        public string batchname;
        public string type;
        public string module;
        public string date;
        public string time;
        public string lecturer1;
        public string lecturer2;
        public string lecturer3;
        public string venue;
        public string prg_type;
        public Email_recipients()
        {
            InitializeComponent();
            this.ControlBox = false;

        }
        SqlConnection con = new SqlConnection(Credentials.connection);
        private void Email_recipients_Load(object sender, EventArgs e)
        {

            if (type == "dip_studs")
            {
                metroTextBox1.Text = "Lecturer Reminder- ("+batchname+")";
                richTextBox1.AppendText("Lecture Reminder");
                richTextBox1.AppendText(Environment.NewLine + "batch - " + batchname);
                richTextBox1.AppendText(Environment.NewLine + "module - " + module);
                richTextBox1.AppendText(Environment.NewLine + "date - " + date);
                richTextBox1.AppendText(Environment.NewLine + "time - " + time);
                richTextBox1.AppendText(Environment.NewLine + "Conducted by - " + lecturer1 + "," + lecturer2 + "," + lecturer3);
                richTextBox1.AppendText(Environment.NewLine + "Venue - " + venue);
                richTextBox1.AppendText(Environment.NewLine + "Please be present");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT stud_no,name_with_initials,email_R FROM Stud_details WHERE batch_no='" + General_methods.get_batch_no_from_batch_name(batchname) + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                int c = 0;
                while (dr.Read())
                {
                    checkedListBox1.Items.Add(dr.GetValue(0) + " - " + dr.GetValue(1) + " - " + dr.GetValue(2));
                    checkedListBox1.SetItemChecked(c, true);
                    c++;
                }
                con.Close();
            }
            if (type == "lec")
            {
                con.Open();
                this.ControlBox = false;
                metroTextBox1.Text = "Lecturer Reminder- (" + batchname + ")";
                richTextBox1.AppendText("Lecture Reminder");
                richTextBox1.AppendText(Environment.NewLine + "batch - " + batchname);
                richTextBox1.AppendText(Environment.NewLine + "module - " + module);
                richTextBox1.AppendText(Environment.NewLine + "date - " + date);
                richTextBox1.AppendText(Environment.NewLine + "time - " + time);
                richTextBox1.AppendText(Environment.NewLine + "Venue - " + venue);
                SqlCommand cmd = new SqlCommand("SELECT Lecturer_no,F_name,L_name,email FROM Lecture_details WHERE Lecturer_no='" + General_methods.get_lec_no_from_lec_name(lecturer1) + "' OR Lecturer_no='" + General_methods.get_lec_no_from_lec_name(lecturer2) + "' OR Lecturer_no='" + General_methods.get_lec_no_from_lec_name(lecturer3) + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                int c = 0;
                while (dr.Read())
                {
                    checkedListBox1.Items.Add(dr.GetValue(0) + " - " + dr.GetValue(1) + " " + dr.GetValue(2) + " - " + dr.GetValue(3));
                    checkedListBox1.SetItemChecked(c, true);
                    c++;
                }


            }
            if (type == "short")
            {
                con.Open();
                this.ControlBox = false;
                metroTextBox1.Text = "Lecturer Reminder- (" + batchname + ")";
                richTextBox1.AppendText("Lecture Reminder");
                richTextBox1.AppendText(Environment.NewLine + "Topic - " + batchname);
                //richTextBox1.AppendText(Environment.NewLine + "module - " + module);
                richTextBox1.AppendText(Environment.NewLine + "date - " + date);
                richTextBox1.AppendText(Environment.NewLine + "time - " + time);
                richTextBox1.AppendText(Environment.NewLine + "Venue - " + venue);
                SqlCommand cmd = new SqlCommand("SELECT Lecturer_no,F_name,L_name,email FROM Lecture_details WHERE Lecturer_no='" + General_methods.get_lec_no_from_lec_name(lecturer1) + "' OR Lecturer_no='" + General_methods.get_lec_no_from_lec_name(lecturer2) + "' OR Lecturer_no='" + General_methods.get_lec_no_from_lec_name(lecturer3) + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                int c = 0;
                while (dr.Read())
                {
                    checkedListBox1.Items.Add(dr.GetValue(0) + " - " + dr.GetValue(1) + " " + dr.GetValue(2) + " - " + dr.GetValue(3));
                    checkedListBox1.SetItemChecked(c, true);
                    c++;
                }


            }
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
