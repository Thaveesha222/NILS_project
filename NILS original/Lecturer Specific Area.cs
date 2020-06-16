using NILS_original;
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
    public partial class Lecturer_Specific_Area : MetroFramework.Forms.MetroForm
    {
        public Lecturer_Specific_Area()
        {
            InitializeComponent();
            db.con.Open();
            db.cmd = new SqlCommand("SELECT lecturer_specific_area FROM Lecture_details ORDER BY lecturer_specific_area ", db.con);
            SqlDataReader sdr = db.cmd.ExecuteReader();
            while (sdr.Read())
            {
                if ((Array.Exists(programs, element => element == sdr.GetValue(0).ToString()) == false))
                {
                    programs[c] = sdr.GetValue(0).ToString();
                    c++;
                }
                else
                {

                }
            }
            cmb_lec_specific_area.DataSource = programs;
            sdr.Close();
            db.con.Close();
        }
        public string[] programs=new string[60];
        public int c;
        Database db = new Database();
        private void Lecturer_Specific_Area_Load(object sender, EventArgs e)
        {

        }
    
        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            metroGrid1.DataSource = db.show("SELECT * FROM Lecture_details WHERE lecturer_specific_area='"+cmb_lec_specific_area.Text+"'");
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {if (metroToggle1.Checked == true)
            {
                /*Form2 f1 = new Form2();
                f1.Show();
                f1.txt_lec_no.Text = this.metroGrid1.CurrentRow.Cells[0].Value.ToString();
                f1.txt_lec_name.Text += this.metroGrid1.CurrentRow.Cells[2].Value.ToString()+" ";
                f1.txt_lec_name.Text +=this.metroGrid1.CurrentRow.Cells[3].Value.ToString();
                db.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT dip,certif,short,rating FROM Lecturer_stats WHERE lecturer_no = '" + this.metroGrid1.CurrentRow.Cells[0].Value.ToString() + "'", db.con);
                SqlDataReader r = cmd.ExecuteReader();
                r.Read();
                f1.txt_diploma.Text = Convert.ToString(r.GetValue(0));
                f1.txt_certificate.Text = Convert.ToString(r.GetValue(1));
                f1.txt_short_programs.Text = Convert.ToString(r.GetValue(2));
                f1.txt_lec_rate.Text = Convert.ToString(r.GetValue(3));*/

                //r.Close();
                db.con.Close();
                /* f1.txt_oneday.Text = this.metroGrid1.CurrentRow.Cells[2].Value.ToString();
                 f1.txt_twoday.Text = this.metroGrid1.CurrentRow.Cells[3].Value.ToString();
                 f1.txt_threeday.Text = this.metroGrid1.CurrentRow.Cells[4].Value.ToString();
                 f1.txt_workshops.Text = this.metroGrid1.CurrentRow.Cells[5].Value.ToString();
                 f1.txt_diploma.Text = this.metroGrid1.CurrentRow.Cells[6].Value.ToString();
                 f1.txt_certificate.Text = this.metroGrid1.CurrentRow.Cells[7].Value.ToString();
                 f1.txt_outstation.Text = this.metroGrid1.CurrentRow.Cells[8].Value.ToString();*/
                //f1.txt_actn_learn.Text = this.metroGrid1.CurrentRow.Cells[9].Value.ToString();
                //f1.txt_acmarks.Text = this.metroGrid1.CurrentRow.Cells[10].Value.ToString();
            }
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
