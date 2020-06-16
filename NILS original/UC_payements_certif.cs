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

namespace NILS_original
{
    public partial class UC_payements_certif : UserControl
    {
        public static string studno;
        SqlConnection con = new SqlConnection(Credentials.connection);
        public UC_payements_certif()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            if (General_methods.calc_amount_payable(studno,0,"Certificate")==0)
            {
                groupBox3.Enabled = false;
                groupBox3.Text = "Course fee fully Payed";
            }
            metroGrid1.DataSource = d.show("SELECT Payment_No,Gross_amount,Discount_percent,Net_amount,Date,Time,Remark FROM PaymentDetails WHERE stud_no_org_no='"+studno+"'");
            metroGrid1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            metroGrid1.AllowUserToAddRows = false;
            DataGridViewButtonColumn bt = new DataGridViewButtonColumn();
            bt.Text = "Terminate Payment";
            bt.FlatStyle = FlatStyle.Flat;
            bt.UseColumnTextForButtonValue = true;
            bt.Width = 150;
            metroGrid1.Columns.Add(bt);
            DataGridViewButtonColumn bt2 = new DataGridViewButtonColumn();
            bt2.Text = "Generate Recipt";
            bt2.FlatStyle = FlatStyle.Flat;
            bt2.UseColumnTextForButtonValue = true;
            bt2.Width = 150;
            metroGrid1.Columns.Add(bt2);
            con.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT reg_fee FROM Stud_details WHERE stud_no='" + studno + "'", con);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            dr2.Read();
            if (!dr2.IsDBNull(0))
            {
                groupBox2.Enabled = false;
                groupBox2.Text = "Registration fee  payed";
            }
            else
            {

            }
            con.Close();
        }
        Database d = new Database();
        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (txt_reg_fee_paying.Text.Any(char.IsLetter) == true || txt_reg_fee_paying.Text == "" || Convert.ToDouble(txt_reg_fee.Text.Remove(txt_reg_fee.Text.Length - 2, 2)) < Convert.ToDouble(txt_reg_fee_paying.Text))
            {
                MessageBox.Show("Please enter valid registration fee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dr = MessageBox.Show("You are about to save a payment. Press yes to confirm", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    d.insert("INSERT INTO PaymentDetails (Gross_amount,Discount_percent,Net_amount,Date,Time,stud_no_org_no,program_no,Remark) VALUES('" + txt_reg_fee.Text.Remove(txt_reg_fee.Text.Length - 2, 2) + "','0','" + txt_reg_fee_paying.Text + "','" + General_methods.get_current_date() + "','" + General_methods.get_current_time().ToString() + "','" + txt_studno.Text + "','None','Registration fee for Certificate course')");
                    d.update("UPDATE Stud_details SET reg_fee='" + d.singleInt("SELECT MAX(Payment_No) FROM PaymentDetails").ToString() + "' WHERE stud_no='" + txt_studno.Text + "'");
                    MessageBox.Show("Details Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult a1 = MessageBox.Show("Generate Recipt?", "Notofication", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this label is used for event firing
                    label1.Text = General_methods.Generate_RandomNumber(0, 2837872).ToString();
                    if (a1 == DialogResult.Yes)
                    {

                    }
                    else
                    {

                    }
                }
            }
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            if (txt_amount_paying.Text == "")
            {
                MessageBox.Show("Please confirm amount paying", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (cmb_payment_mode.Text == "")
            {
                MessageBox.Show("Please select payment method", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmb_payment_mode.SelectedIndex == 2 && txt_chequeno.Text == "")
            {
                MessageBox.Show("Please enter the cheque number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dr = MessageBox.Show("You are about to save a payment. Press yes to confirm", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    d.insert("INSERT INTO PaymentDetails (Gross_amount,Discount_percent,Net_amount,Date,Time,stud_no_org_no,program_no,Remark) VALUES('" + txt_amount_paying.Text + "','" + txt_discount.Text + "','" + txt_final_amount.Text.Remove(txt_final_amount.Text.Length - 2, 2) + "','" + DateTime.Today.ToShortDateString() + "','" + DateTime.Now.ToLongTimeString() + "','" + studno + "','None','Course fee for Certificate course')");
                    if (cmb_payment_mode.SelectedIndex == 2)
                    {
                        d.insert("INSERT INTO Cheque_payments (Payment_no,Cheque_no) VALUES ('" + d.singleInt("SELECT MAX(Payment_No) FROM PaymentDetails") + "','" + txt_chequeno.Text + "')");
                    }
                    MessageBox.Show("Details Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult a1 = MessageBox.Show("Generate Recipt?", "Notofication", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this label is used for event firing
                    label1.Text = General_methods.Generate_RandomNumber(0, 72653).ToString();
                    if (a1 == DialogResult.Yes)
                    {

                    }
                    else
                    {

                    }
                }
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
           
        }

        private void metroTile10_Click(object sender, EventArgs e)
        {
            if (txt_amount_paying.Text.Any(char.IsLetter) == true || txt_amount_paying.Text == "" || Convert.ToDouble(txt_amount_paying.Text) >Convert.ToDouble(txt_amount_payabme.Text.Remove(txt_amount_payabme.Text.Length-2,2)))
            {
                MessageBox.Show("Please enter correct amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txt_discount.Text.Any(char.IsLetter) == true || txt_discount.Text == "" || Convert.ToDouble(txt_discount.Text) > 100)
            {
                MessageBox.Show("Please enter valid discount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            else
            {
                txt_final_amount.Text = (Convert.ToDouble(txt_amount_paying.Text) * Convert.ToDouble(100 - Convert.ToDouble(txt_discount.Text)) / 100).ToString("R") + "/=";
                txt_amount_payable_2.Text = General_methods.calc_amount_payable(txt_studno.Text, Convert.ToDouble(txt_amount_paying.Text), "Certificate").ToString();
            }
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex == 7 && e.RowIndex >= 0)
            {
                DialogResult dc = MessageBox.Show("Are you sure you want to terminate payment?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dc == DialogResult.Yes)
                {
                    if (metroGrid1.Rows[e.RowIndex].Cells[6].Value.ToString() == "Course fee for Certificate course")
                    {
                        d.delete("DELETE FROM PaymentDetails WHERE Payment_No='"+ Convert.ToInt32(metroGrid1.Rows[e.RowIndex].Cells[0].Value) + "'");
                    }
                    else if (metroGrid1.Rows[e.RowIndex].Cells[6].Value.ToString() == "Registration fee for Certificate course")
                    {
                        d.update("UPDATE Stud_details SET reg_fee=NULL WHERE stud_no='" + txt_studno.Text + "'");
                        d.delete("DELETE FROM PaymentDetails WHERE Payment_No='" + Convert.ToInt32(metroGrid1.Rows[e.RowIndex].Cells[0].Value) + "'");

                    }
                    MessageBox.Show("Succefully terminated payment", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label1.Text = General_methods.Generate_RandomNumber(0, 99999).ToString();
                }
                else
                {

                }
            }
            
        }

        private void cmb_payment_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_payment_mode.SelectedIndex == 2)
            {
                txt_chequeno.Enabled = true;
            }
            else
            {
                txt_chequeno.Enabled = false;
            }
        }
    }
}
