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

namespace NILS_original
{
    public partial class SMS_recipents : MetroFramework.Forms.MetroForm
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



        public SMS_recipents()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Credentials.connection);
        private void SMS_recipents_Load(object sender, EventArgs e)
        {
            if (type == "student")
            {
                con.Open();
                this.ControlBox = false;
                richTextBox1.AppendText("Lecture Reminder");
                richTextBox1.AppendText(Environment.NewLine + "batch - " + batchname);
                richTextBox1.AppendText(Environment.NewLine + "module - " + module);
                richTextBox1.AppendText(Environment.NewLine + "date - " + date);
                richTextBox1.AppendText(Environment.NewLine + "time - " + time);
                richTextBox1.AppendText(Environment.NewLine + "Conducted by - " + lecturer1 + "," + lecturer2 + "," + lecturer3);
                richTextBox1.AppendText(Environment.NewLine + "Venue - " + venue);
                SqlCommand cmd = new SqlCommand("SELECT stud_no,name_with_initials,mobile FROM Stud_details WHERE batch_no='" + General_methods.get_batch_no_from_batch_name(batchname) + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                int c = 0;
                while (dr.Read())
                {
                    checkedListBox1.Items.Add(dr.GetValue(0) + " - " + dr.GetValue(1) + " - " + dr.GetValue(2));
                    checkedListBox1.SetItemChecked(c, true);
                    c++;
                }
            }
            if (type == "lec")
            {
                con.Open();
                this.ControlBox = false;
                richTextBox1.AppendText("Lecture Reminder");
                richTextBox1.AppendText(Environment.NewLine + "batch - " + batchname);
                richTextBox1.AppendText(Environment.NewLine + "module - " + module);
                richTextBox1.AppendText(Environment.NewLine + "date - " + date);
                richTextBox1.AppendText(Environment.NewLine + "time - " + time);
                richTextBox1.AppendText(Environment.NewLine + "Venue - " + venue);
                SqlCommand cmd = new SqlCommand("SELECT Lecturer_no,F_name,L_name,mobile_no_1 FROM Lecture_details WHERE Lecturer_no='"+General_methods.get_lec_no_from_lec_name(lecturer1)+"' OR Lecturer_no='"+General_methods.get_lec_no_from_lec_name(lecturer2)+"' OR Lecturer_no='"+General_methods.get_lec_no_from_lec_name(lecturer3)+"'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                int c = 0;
                while (dr.Read())
                {
                    checkedListBox1.Items.Add(dr.GetValue(0) + " - " + dr.GetValue(1) + " " + dr.GetValue(2)+" - "+dr.GetValue(3));
                    checkedListBox1.SetItemChecked(c, true);
                    c++;
                }


            }
            if (type == "short_lec")
            {
                con.Open();
                this.ControlBox = false;
                richTextBox1.AppendText("Reminder for "+prg_type+" at NILS");
                richTextBox1.AppendText(Environment.NewLine + "Title - " + batchname);
                richTextBox1.AppendText(Environment.NewLine + "date - " + date);
                richTextBox1.AppendText(Environment.NewLine + "time - " + time);
                richTextBox1.AppendText(Environment.NewLine + "Conducted by - " + lecturer1 + "," + lecturer2 + "," + lecturer3);
                richTextBox1.AppendText(Environment.NewLine + "Venue - " + venue);
                SqlCommand cmd = new SqlCommand("SELECT Lecturer_no,F_name,L_name,mobile_no_1 FROM Lecture_details WHERE Lecturer_no='" + General_methods.get_lec_no_from_lec_name(lecturer1) + "' OR Lecturer_no='" + General_methods.get_lec_no_from_lec_name(lecturer2) + "' OR Lecturer_no='" + General_methods.get_lec_no_from_lec_name(lecturer3) + "'", con);
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
