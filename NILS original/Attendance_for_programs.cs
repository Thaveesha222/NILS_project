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
    public partial class Attendance_for_programs : MetroFramework.Forms.MetroForm
    {
        public string code;
        public Attendance_for_programs()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Credentials.connection);

        Database d = new Database();
        private void metroTile1_Click(object sender, EventArgs e)
        {

        }

        private void Attendance_for_programs_Load(object sender, EventArgs e)
        {
            metroGrid1.DataSource = d.show("SELECT s.ref_no,Name,c.Organization_name,s.Email,s.phone_no,s.NIC,s.address,s.designation FROM Short_program_participation s LEFT JOIN Company_details c ON s.Organization_id=c.Organization_id WHERE program_code='" + code + "'");
            DataGridViewButtonColumn b1 = new DataGridViewButtonColumn();
            b1.HeaderText = "Delete Participant";
            b1.Text = "Delete Participant";
            b1.FlatStyle = FlatStyle.Flat;
            b1.UseColumnTextForButtonValue = true;
            b1.Width = 150;
            metroGrid1.Columns.Add(b1);
            DataGridViewButtonColumn b2 = new DataGridViewButtonColumn();
            b2.HeaderText = "Edit Participant Details";
            b2.Text = "Edit Participant Details";
            b2.FlatStyle = FlatStyle.Flat;
            b2.UseColumnTextForButtonValue = true;
            b2.Width = 150;
            metroGrid1.Columns.Add(b2);
            metroGrid1.AllowUserToAddRows = false;

        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex == 8 && e.RowIndex >= 0)
            {
                if (d.singleString("SELECT payment_no FROM Short_program_participation WHERE ref_no='" + metroGrid1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'") != "")
                {
                    MessageBox.Show("Student cannot be deleted because already a payment has been made for the student", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    DialogResult d2 = MessageBox.Show("Delete Student Permanantly?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d2 == DialogResult.Yes)
                    {
                        d.delete("DELETE FROM Short_program_participation WHERE ref_no='" + metroGrid1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'");
                        MessageBox.Show("Successfully deleted student", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        label1.Text = General_methods.Generate_RandomNumber(0, 888).ToString();
                        Close();
                    }
                }
            }
            else if (e.ColumnIndex == 9 && e.RowIndex >= 0)
            {
                Edit_details_of_program_student p = new Edit_details_of_program_student();
                p.lbl_no.Text = metroGrid1.Rows[e.RowIndex].Cells[0].Value.ToString();
                p.txt_name.Text = metroGrid1.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (metroGrid1.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                {
                    p.cmb_org.Enabled = false;
                    p.cmb_org.Items.Add("Individual Participant");
                    p.cmb_org.Text = "Individual Participant";
                }
                else
                {
                    p.cmb_org.DataSource = General_methods.fill_companys_combobx();
                    p.cmb_org.Text = metroGrid1.Rows[e.RowIndex].Cells[2].Value.ToString();
                }
                p.txt_email.Text = metroGrid1.Rows[e.RowIndex].Cells[3].Value.ToString();
                p.txt_phoneno.Text = metroGrid1.Rows[e.RowIndex].Cells[4].Value.ToString();
                p.txt_NIC.Text = metroGrid1.Rows[e.RowIndex].Cells[5].Value.ToString();
                p.cmb_desigs.DataSource = General_methods.fill_designations_combobox();
                string[] districts = { "Ampara", "Anuradhapura", "Badulla", "Batiicaloa", "Colombo", "Galle", "Gampaha", "Hambantota", "Jaffna", "Kalutara", "Kandy", "Kegalle", "Kilinochchi", "Kurunegala", "Mannar", "Matale", "Matara", "Monaragala", "Mullaitivu", "Nuwara Eliya", "Polonnaruwa", "Puttalam", "Ratnapura", "Trincomalee", "Vavuniya" };
                p.txt_destrict.Items.AddRange(districts);
                p.txt_destrict.Text = metroGrid1.Rows[e.RowIndex].Cells[6].Value.ToString();
                p.cmb_desigs.Text = metroGrid1.Rows[e.RowIndex].Cells[7].Value.ToString();
                p.Show();
                p.label1.TextChanged += handler;

            }
        }
        public void handler(object sender, EventArgs e)
        {
            label1.Text = General_methods.Generate_RandomNumber(0,888).ToString();
            Close();
        }
    }
}
