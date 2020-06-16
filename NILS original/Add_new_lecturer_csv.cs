using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NILS_original
{
    public partial class Add_new_lecturer_csv : MetroFramework.Forms.MetroForm
    {
        public Add_new_lecturer_csv()
        {
            InitializeComponent();
        }

        private void Add_new_lecturer_csv_Load(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.Filter = "All Files (*.*)|*.*";
                choofdlog.FilterIndex = 1;
                // choofdlog.Multiselect ;
                if (choofdlog.ShowDialog() == DialogResult.OK)
                {
                    string sFileName = choofdlog.FileName;
                    metroLabel1.Text = choofdlog.FileName; //used when Multiselect = true           
                }


                System.Data.OleDb.OleDbConnection MyConnection;
                System.Data.DataSet DtSet;
                System.Data.OleDb.OleDbDataAdapter MyCommand;
                MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + metroLabel1.Text + "';Extended Properties=Excel 8.0;");
                MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Form Responses 1$]", MyConnection);
                MyCommand.TableMappings.Add("Table", "Net-informations.com");
                DtSet = new System.Data.DataSet();
                MyCommand.Fill(DtSet);
                metroGrid1.DataSource = DtSet.Tables[0];
                MyConnection.Close();


                DataGridViewButtonColumn b = new DataGridViewButtonColumn();
                b.HeaderText = "Add Lecturer to System";
                b.Text = "Add Lecturer to System";
                b.UseColumnTextForButtonValue = true;
                b.Width = 200;
                metroGrid1.Columns.Add(b);
                metroGrid1.AllowUserToAddRows = false;
               

            }
            catch (System.Data.OleDb.OleDbException)
            {
                metroGrid1.Columns.Clear();
                metroLabel1.Text = "";
                metroGrid1.DataSource = null;
                MessageBox.Show("Wrong format of excel document.Please save document in .xls format","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }




  
        }
        SqlConnection con = new SqlConnection(Credentials.connection);
        public string AutoID()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Lecturer_no FROM Lecture_details", con);
            SqlDataReader dr = cmd.ExecuteReader();
            List<int> s = new List<int>();

            while (dr.Read())
            {
                s.Add(Convert.ToInt32(dr.GetValue(0).ToString().Split('_').GetValue(2)));
            }
            if (s.Count != 0)
            {
                con.Close();
                return "NILS_RP_" + (1 + s.Max()).ToString();
            }
            else
            {
                con.Close();
                return "NILS_RP_" + 1.ToString();
            }
        }
        Database d = new Database();
        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 16)
            {
                if (d.singleInt("SELECT COUNT(*) FROM Lecture_details WHERE NIC='" + metroGrid1.Rows[e.RowIndex].Cells[4].Value.ToString() + "'") == 1)
                {
                    MessageBox.Show("Lecturer already present", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string no = AutoID();
                    d.insert("INSERT INTO Lecture_details (Lecturer_no,NIC,F_name,L_name,mobile_no_1,tel_no,email,address,Name_with_initals,Birthdate,Gender,language,contact,path) VALUES ('" + no + "','" + metroGrid1.Rows[e.RowIndex].Cells[4].Value.ToString() + "','" + metroGrid1.Rows[e.RowIndex].Cells[1].Value.ToString() + "','" + metroGrid1.Rows[e.RowIndex].Cells[2].Value.ToString() + "','" + metroGrid1.Rows[e.RowIndex].Cells[9].Value.ToString() + "','" + metroGrid1.Rows[e.RowIndex].Cells[10].Value.ToString() + "','" + metroGrid1.Rows[e.RowIndex].Cells[8].Value.ToString() + "','" + metroGrid1.Rows[e.RowIndex].Cells[6].Value.ToString() + "','" + metroGrid1.Rows[e.RowIndex].Cells[3].Value.ToString() + "','" + metroGrid1.Rows[e.RowIndex].Cells[7].Value.ToString() + "','" + metroGrid1.Rows[e.RowIndex].Cells[5].Value.ToString() + "','" + metroGrid1.Rows[e.RowIndex].Cells[13].Value.ToString() + "','" + metroGrid1.Rows[e.RowIndex].Cells[15].Value.ToString() + "','" + metroGrid1.Rows[e.RowIndex].Cells[11].Value.ToString() + "')");
                    string[] a = metroGrid1.Rows[e.RowIndex].Cells[14].Value.ToString().Split(',');
                    for (int i = 0; i < a.Length; i++)
                    {
                        d.insert("INSERT INTO Rp_area_preffered (Lec_no,Area_preffered_teaching) VALUES ('" + no + "','" + a[i] + "')");
                    }
                    string[] b = metroGrid1.Rows[e.RowIndex].Cells[12].Value.ToString().Split(',');
                    for (int i = 0; i < b.Length; i++)
                    {
                        d.insert("INSERT INTO Rp_selected_specific_areas (Lec_no,specific_area) VALUES ('" + no + "','" + b[i] + "')");
                    }
                    MessageBox.Show("Successfully added Lecturer", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
    }   
}
