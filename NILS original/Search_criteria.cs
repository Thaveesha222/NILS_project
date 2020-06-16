using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using WhatsAppApi;
using System.Net;
using System.IO;
using System.Data.SqlClient;
using MetroFramework.Controls;
using System.Data.SqlClient;

namespace NILS_original
{
    public partial class Search_criteria : MetroFramework.Forms.MetroForm
    {
        SqlConnection con = new SqlConnection(Credentials.connection);
        public Search_criteria()
        {
            InitializeComponent();
            metroDateTime1.Format = DateTimePickerFormat.Custom;
            metroDateTime1.CustomFormat = "dd-MM-yyyy";
            metroDateTime2.Format = DateTimePickerFormat.Custom;
            metroDateTime2.CustomFormat = "dd-MM-yyyy";
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Batch_name FROM Batches " + " SELECT Organization_id,Organization_name,email FROM Company_details ORDER BY Organization_name",con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                clb_batches.Items.Add(dr.GetValue(0).ToString());
                clb_dipbatches_emails.Items.Add(dr.GetValue(0).ToString());
            }
            dr.NextResult();
            while (dr.Read())
            {
                clb_companies.Items.Add(dr.GetValue(0).ToString() + " - " + dr.GetValue(1).ToString()+" - "+dr.GetValue(2).ToString());
            }
            con.Close();
            clb_batches.CheckOnClick = true;
            batch_recipients.CheckOnClick = true;
            clb_short_programs.CheckOnClick = true;
            short_prog_recipients.CheckOnClick = true;
            total_recipients.CheckOnClick = true;
            clb_batches.HorizontalScrollbar = true;
            batch_recipients.HorizontalScrollbar= true;
            clb_short_programs.HorizontalScrollbar = true;
            short_prog_recipients.HorizontalScrollbar = true;
            total_recipients.HorizontalScrollbar = true;

            clb_dipbatches_emails.CheckOnClick = true;
            clb_programs_email.CheckOnClick = true;
            bacth_recipients_email.CheckOnClick = true;
            prog_recipents_email.CheckOnClick = true;
            total_recipients_email.CheckOnClick = true;
            clb_dipbatches_emails.HorizontalScrollbar = true;
            clb_programs_email.HorizontalScrollbar = true;
            bacth_recipients_email.HorizontalScrollbar = true;
            prog_recipents_email.HorizontalScrollbar = true;
            total_recipients_email.HorizontalScrollbar = true;
            clb_companies.HorizontalScrollbar = true;
            clb_companies.CheckOnClick = true;


            

        }

        private void Search_criteria_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            batch_recipients.Items.Clear();
            for (int i = 0; i < clb_batches.Items.Count; i++)
            {
                //CheckState st = checkedListBox1.GetItemCheckState(i);

                if (clb_batches.CheckedItems.Contains(clb_batches.Items[i]) == true)
                {
                    int c = 0;
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT s.stud_no,s.name_with_initials,s.mobile,s.batch_no,c.Organization_name FROM Batches b INNER JOIN Stud_details s ON s.batch_no=b.Batch_no INNER JOIN Company_details c ON s.organization_id=c.Organization_id WHERE b.Batch_name='" + clb_batches.Items[i].ToString() + "' ORDER BY s.batch_no,c.Organization_name", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        batch_recipients.Items.Add(dr.GetValue(0).ToString() + " - " + dr.GetValue(1).ToString() + " - " + dr.GetValue(2).ToString()+" - "+dr.GetValue(3).ToString()+" - "+dr.GetValue(4).ToString());
                        batch_recipients.SetItemChecked(c, true);
                        c++;
                    }
                    con.Close();
                }
                else
                {

                }
            }
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            clb_short_programs.Items.Clear();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT s.program_no,a.Program_title FROM Session_details s INNER JOIN Short_program_details a ON s.program_no=a.Code WHERE s.scheduled_date BETWEEN '"+metroDateTime1.Value+"' AND '"+metroDateTime2.Value+"'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               clb_short_programs.Items.Add(dr.GetValue(0).ToString()+" - "+dr.GetValue(1).ToString());
            }
            clb_short_programs.CheckOnClick = true;
            con.Close();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            int c = 0;
            short_prog_recipients.Items.Clear();
            for (int i = 0; i < clb_short_programs.Items.Count; i++)
            {
                if (clb_short_programs.CheckedItems.Contains(clb_short_programs.Items[i]) == true)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT p.ref_no,p.Name,p.phone_no,c.Organization_name FROM Short_program_participation p INNER JOIN Company_details c ON p.Organization_id=c.Organization_id WHERE  p.program_code='" + clb_short_programs.Items[i].ToString().Split('-').GetValue(0) + "' ORDER BY p.program_code,c.Organization_name", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        short_prog_recipients.Items.Add(dr.GetValue(0).ToString() + " - " + dr.GetValue(1).ToString() + " - " + dr.GetValue(2).ToString()+" - "+dr.GetValue(3).ToString());
                        short_prog_recipients.SetItemChecked(c, true);
                        c++;
                    }
                    con.Close();
                }
                else
                {

                }

            }
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            if (metroTile4.Text == "Confirm")
            {
                metroTile4.Text = "Change";
                groupBox2.Enabled = true;
                groupBox1.Enabled = false;
                for (int i = 0; i < batch_recipients.Items.Count; i++)
                {
                    if (batch_recipients.CheckedItems.Contains(batch_recipients.Items[i]) == true)
                    {
                        total_recipients.Items.Add(batch_recipients.Items[i].ToString());
                    }
                    else
                    {

                    }
                }
                for (int i = 0; i < short_prog_recipients.Items.Count; i++)
                {
                    if (short_prog_recipients.CheckedItems.Contains(short_prog_recipients.Items[i]) == true)
                    {
                        total_recipients.Items.Add(short_prog_recipients.Items[i].ToString());
                    }
                    else
                    {

                    }
                }
                for (int i = 0; i < total_recipients.Items.Count; i++)
                {
                    total_recipients.SetItemChecked(i, true);
                }
            }
            else
            {
                metroTile4.Text = "Confirm";
                groupBox2.Enabled = false;
                groupBox1.Enabled = true;
                total_recipients.Items.Clear();
                //richTextBox1.Clear();
                metroTile5.Text = "Confirm";
            }
            enable_button();
        }
        private void enable_button()
        {
            if (metroTile5.Text == "Change" && metroTile4.Text == "Change")
            {
                metroTile6.Enabled = true;
            }
            else
            {
                metroTile6.Enabled = false;
            }
        }
        private void enable_button_2()
        {
            if (metroTile12.Text == "Change" && metroTile10.Text == "Change")
            {
                metroTile11.Enabled = true;
            }
            else
            {
                metroTile11.Enabled = false;
            }
        }
        private void metroTile5_Click(object sender, EventArgs e)
        {
            if (metroTile5.Text == "Confirm")
            {
                metroTile5.Text = "Change";
                groupBox2.Enabled = false;
                
            }
            else
            {
                metroTile5.Text = "Confirm";
                groupBox2.Enabled = true;
            }
            enable_button();
        }

        private void groupBox2_EnabledChanged(object sender, EventArgs e)
        {
            
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            DialogResult dresult2 = MessageBox.Show("Send sms reminder to recipients?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dresult2 == DialogResult.Yes)
            {
                var charsToRemove = new string[] { "(", ")", "-", " " };

                List<string> numbers = new List<string>();

                for (int i = 0; i < total_recipients.Items.Count; i++)
                {
                    if (total_recipients.CheckedItems.Contains(total_recipients.Items[i]) == true)
                    {
                        string k;
                        k = total_recipients.Items[i].ToString().Split('-').GetValue(2).ToString()+ total_recipients.Items[i].ToString().Split('-').GetValue(3).ToString();
                        foreach (var c in charsToRemove)
                        {
                            k = k.Replace(c, string.Empty);
                        }
                        MessageBox.Show(k);
                        numbers.Add("94" + k.Remove(0, 1));
                    }
                    else
                    {

                    }
                }
                
                SMS_class.string_sms(numbers, richTextBox1.Text);
                MessageBox.Show("SMS Reminder to students sent successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            bacth_recipients_email.Items.Clear();
            for (int i = 0; i < clb_dipbatches_emails.Items.Count; i++)
            {
                //CheckState st = checkedListBox1.GetItemCheckState(i);

                if (clb_dipbatches_emails.CheckedItems.Contains(clb_dipbatches_emails.Items[i]) == true)
                {
                    int c = 0;
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT s.stud_no,s.name_with_initials,s.email_R,s.batch_no,c.Organization_name FROM Batches b INNER JOIN Stud_details s ON s.batch_no=b.Batch_no INNER JOIN Company_details c ON s.organization_id=c.Organization_id WHERE b.Batch_name='" + clb_dipbatches_emails.Items[i].ToString() + "' ORDER BY s.batch_no,c.Organization_name", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bacth_recipients_email.Items.Add(dr.GetValue(0).ToString() + " - " + dr.GetValue(1).ToString() + " - " + dr.GetValue(2).ToString() + " - " + dr.GetValue(3).ToString() + " - " + dr.GetValue(4).ToString());
                        bacth_recipients_email.SetItemChecked(c, true);
                        c++;
                    }
                    con.Close();
                }
                else
                {

                }
            }
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            clb_programs_email.Items.Clear();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT s.program_no,a.Program_title FROM Session_details s INNER JOIN Short_program_details a ON s.program_no=a.Code WHERE s.scheduled_date BETWEEN '" + metroDateTime3.Value + "' AND '" + metroDateTime4.Value + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                clb_programs_email.Items.Add(dr.GetValue(0).ToString() + " - " + dr.GetValue(1).ToString());
            }
            clb_programs_email.CheckOnClick = true;
            con.Close();
        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
            int c = 0;
            prog_recipents_email.Items.Clear();
            for (int i = 0; i < clb_programs_email.Items.Count; i++)
            {
                if (clb_programs_email.CheckedItems.Contains(clb_programs_email.Items[i]) == true)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT p.ref_no,p.Name,p.Email,c.Organization_name FROM Short_program_participation p INNER JOIN Company_details c ON p.Organization_id=c.Organization_id WHERE  p.program_code='" + clb_programs_email.Items[i].ToString().Split('-').GetValue(0) + "' ORDER BY p.program_code,c.Organization_name", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        prog_recipents_email.Items.Add(dr.GetValue(0).ToString() + " - " + dr.GetValue(1).ToString() + " - " + dr.GetValue(2).ToString() + " - " + dr.GetValue(3).ToString());
                        prog_recipents_email.SetItemChecked(c, true);
                        c++;
                    }
                    con.Close();
                }
                else
                {

                }

            }
        }

        private void metroTile10_Click(object sender, EventArgs e)
        {
            if (metroTile10.Text == "Confirm")
            {
                metroTile10.Text = "Change";
                groupBox4.Enabled = true;
                groupBox3.Enabled = false;
                for (int i = 0; i < bacth_recipients_email.Items.Count; i++)
                {
                    if (bacth_recipients_email.CheckedItems.Contains(bacth_recipients_email.Items[i]) == true)
                    {
                        total_recipients_email.Items.Add(bacth_recipients_email.Items[i].ToString());
                    }
                    else
                    {

                    }
                }
                for (int i = 0; i < prog_recipents_email.Items.Count; i++)
                {
                    if (prog_recipents_email.CheckedItems.Contains(prog_recipents_email.Items[i]) == true)
                    {
                        total_recipients_email.Items.Add(prog_recipents_email.Items[i].ToString());
                    }
                    else
                    {

                    }
                }
                for (int i = 0; i < clb_companies.Items.Count; i++)
                {
                    if (clb_companies.CheckedItems.Contains(clb_companies.Items[i]) == true)
                    {
                        total_recipients_email.Items.Add(clb_companies.Items[i].ToString());
                    }
                    else
                    {

                    }
                }
                for (int i = 0; i < total_recipients_email.Items.Count; i++)
                {
                    total_recipients_email.SetItemChecked(i, true);
                }
            }
            else
            {
                groupBox4.Enabled = false;
                groupBox3.Enabled = true;
                total_recipients_email.Items.Clear();
                //richTextBox1.Clear();
                metroTile10.Text = "Confirm";
            }
            enable_button_2();
        }

        private void metroTile12_Click(object sender, EventArgs e)
        {
            if (metroTile12.Text == "Confirm")
            {
                metroTile12.Text = "Change";
                groupBox4.Enabled = false;

            }
            else
            {
                metroTile12.Text = "Confirm";
                groupBox4.Enabled = true;
            }
            enable_button_2();
        }
        int a = 0;
        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            //choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                Attachments.Items.Add(sFileName);
                Attachments.SetItemChecked(a, true);
                a++;
                //string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true           
            }
        }

        private void metroTabPage2_Click(object sender, EventArgs e)
        {

        }

        private void metroTile11_Click(object sender, EventArgs e)
        {
            DialogResult dresult2 = MessageBox.Show("Send email reminder to recipients?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dresult2 == DialogResult.Yes)
            {

                List<string> emails = new List<string>();

                for (int i = 0; i < total_recipients_email.Items.Count; i++)
                {
                    if (total_recipients_email.CheckedItems.Contains(total_recipients_email.Items[i]) == true)
                    {
                        string k;
                        k = total_recipients_email.Items[i].ToString().Split('-').GetValue(2).ToString();
                        emails.Add(k);
                    }
                    else
                    {

                    }
                }
                if (Attachments.Items.Count != 0)
                {
                    List<string> attchments = new List<string>();

                    for (int i = 0; i < Attachments.Items.Count; i++)
                    {
                        if (Attachments.CheckedItems.Contains(Attachments.Items[i]) == true)
                        {
                            attchments.Add(Attachments.Items[i].ToString());
                        }
                    }
                    Gmail.sendmail(richTextBox2.Text, emails, metroTextBox1.Text, attchments.ToArray());
                    //E_mail.send("thaveesha222@gmail.com", richTextBox2.Text, metroTextBox1.Text, emails, attchments);
                    MessageBox.Show("Email Reminder to Resource Persons sent successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    Gmail.sendmail(richTextBox2.Text, emails, metroTextBox1.Text);
                    //E_mail.send("thaveesha222@gmail.com", richTextBox2.Text, metroTextBox1.Text, emails);
                    MessageBox.Show("Email Sent to recipients Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void Attachments_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Attachments_DoubleClick(object sender, EventArgs e)
        {
            
        }
    }
}
