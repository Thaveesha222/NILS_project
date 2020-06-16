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
using System.Globalization;
using System.Threading;

namespace NILS_original
{
    public partial class UC_payments : UserControl
    {
        public static string studno;
        Database d = new Database();
        public UC_payments()
        {
            InitializeComponent();
            txt_mod_wise_discount.Text = "00";
            txt_amount_paying_module_wise.Text = "0";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            DataGridViewTextBoxColumn module = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn amount = new DataGridViewTextBoxColumn();
            module.HeaderText = "Module Name";
            amount.HeaderText = "Amount";
            module.ReadOnly = true;
            metroGrid1.Columns.Add(module);
            metroGrid1.Columns.Add(amount);
            if ((d.singleInt("SELECT COUNT(*) FROM Dip_stud_modules WHERE stud_no='"+studno+"' AND payement_no=(SELECT TOP 1 payement_no FROM Dip_stud_modules WHERE stud_no='" + studno + "' AND payement_no!='NULL')") == d.singleInt("SELECT COUNT(*) FROM Dip_stud_modules WHERE stud_no='"+studno+"'")) && d.singleInt("SELECT COUNT(*) FROM Dip_stud_modules WHERE stud_no='" + studno + "'")!=0)
            {
                groupBox3.Enabled = false;
                metroRadioButton1.Checked = true;
                metroRadioButton2.Enabled = false;
                groupBox2.Enabled = false;
                groupBox2.Text = "Full payement already done";
            }
            else
            {
                metroRadioButton2.Checked = true;
                if (d.singleInt("SELECT COUNT(*) FROM Dip_stud_modules WHERE stud_no='"+studno+"' AND  payement_no IS NULL") != d.singleInt("SELECT COUNT(*) FROM Dip_stud_modules WHERE stud_no='"+studno+"' "))
                {
                    metroRadioButton1.Enabled = false;
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT module_no,payement_no FROM Dip_stud_modules WHERE stud_no='" + studno + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    checkedListBox1.Items.Add(General_methods.get_module_name_from_module_no(dr.GetValue(0).ToString()).ToString());
                    if (dr.IsDBNull(1))
                    {

                    }
                    else
                    {
                        checkedListBox1.SetItemChecked(i, true);
                        a.Add(i);
                    }
                    i++;
                }
                con.Close();
                dr.Close();
                checkedListBox1.CheckOnClick = true;
                
            }
            con.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT reg_fee FROM Stud_details WHERE stud_no='"+studno+"'", con);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            dr2.Read();
            if (!dr2.IsDBNull(0))
            {
                groupBox4.Enabled = false;
                groupBox4.Text = "Registration fee  payed";
            }
            else
            {

            }
            dr2.Close();
            con.Close();
            con.Open();
            metroGrid2.BorderStyle = BorderStyle.FixedSingle;
            SqlDataAdapter da=new SqlDataAdapter("SELECT Payment_No,Gross_amount,Discount_percent,Net_amount,Date,Time,Remark FROM PaymentDetails WHERE stud_no_org_no='"+studno+"'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns.Add("Modules included in payment");
            con.Close();
            SqlConnection con2=new SqlConnection(Credentials.connection);
            con2.Open();
            foreach (DataRow dr in dt.Rows) // search whole table
            {
                string modulename=null;
                SqlCommand cmd5 = new SqlCommand("SELECT module_no FROM Dip_stud_modules WHERE payement_no='" + dr["Payment_No"].ToString() + "'",con2);
                SqlDataReader dra = cmd5.ExecuteReader();
                while (dra.Read())
                {
                    modulename = modulename + General_methods.get_module_name_from_module_no( dra.GetValue(0).ToString()) +" , ";
                }
                dr["Modules included in payment"] = modulename;
                dra.Close();
            }
            metroGrid2.DataSource = dt;
            DataGridViewButtonColumn bt = new DataGridViewButtonColumn();
            bt.Text = "Terminate Payment";
            bt.FlatStyle = FlatStyle.Flat;
            bt.UseColumnTextForButtonValue = true;
            bt.Width = 150;
            metroGrid2.Columns.Add(bt);
            DataGridViewButtonColumn bt2 = new DataGridViewButtonColumn();
            bt2.Text = "Generate Recipt";
            bt2.FlatStyle = FlatStyle.Flat;
            bt2.UseColumnTextForButtonValue = true;
            bt2.Width = 150;
            metroGrid2.Columns.Add(bt2);
            metroGrid2.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            metroGrid2.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            metroGrid2.AllowUserToAddRows = false;
            con2.Close();
            metroGrid2.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";

        }


        SqlConnection con = new SqlConnection(Credentials.connection);
        List<int> a = new List<int>();
        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
       

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (a.Contains(e.Index)) e.NewValue = e.CurrentValue;
            else
            {
                
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

          
        }
        public void enable()
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.CheckedItems.Contains(checkedListBox1.Items[i]) == true && a.Contains(i) == false)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
                else
                {

                }
            }
            metroTile8.Enabled = false;
            metroGrid1.Rows.Clear();
            metroTile7.Text = "Ok";
            checkedListBox1.Enabled = true;
            txt_amount_paying_module_wise.Text = "";
            txt_mosule_wise_amount_after_discount.Text = "";
            txt_mod_wise_discount.Text = "00";
            txt_final_amount_mod_wise.Text = "";
        }
        private void metroTile7_Click(object sender, EventArgs e)
        {
           // txt_amount_paying_module_wise.Text = "";
            if (metroTile7.Text == "Ok")
            {
                metroTile8.Enabled = true;
                metroTile7.Text = "Change";
                checkedListBox1.Enabled = false;
                metroGrid1.Rows.Clear();
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    //CheckState st = checkedListBox1.GetItemCheckState(i);

                    if (checkedListBox1.CheckedItems.Contains(checkedListBox1.Items[i]) == true && a.Contains(i) == false)
                    {
                        metroGrid1.Rows.Add(checkedListBox1.Items[i].ToString(), "0");
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                enable();
               
            }

        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void metroGrid1_Click(object sender, EventArgs e)
        {
            if (metroTile7.Text == "Ok")
            {
                MessageBox.Show("Modules are not confirmed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

            }
        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
            bool status=true;
            double tot=0;
            for (int c = 0; c < metroGrid1.Rows.Count-1; c++)
            {
                if (metroGrid1.Rows[c].Cells[1].Value.ToString() == "" || metroGrid1.Rows[c].Cells[1].Value.ToString().Any(char.IsLetter) == true)
                {
                    MessageBox.Show("Please enter valid amount for the module " + metroGrid1.Rows[c].Cells[0].Value.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    status = false;
                    break;
                }
                else
                {
                    tot = tot + Convert.ToDouble(metroGrid1.Rows[c].Cells[1].Value);
                }
            }
            if (tot > Convert.ToDouble(txt_amount_payable.Text.Remove(txt_amount_payable.Text.Length-2,2)) && status == true)
            {
                MessageBox.Show("The paying amount exceeds current remaining fee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (status == true)
                {
                    txt_amount_paying_module_wise.Text = tot.ToString() + "/=";
                }
            }
        }

        private void txt_amount_paying_module_wise_TextChanged(object sender, EventArgs e)
        {


        }

        private void txt_mod_wise_discount_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            if (txt_mod_wise_discount.Text.Any(char.IsLetter) == true || txt_mod_wise_discount.Text == "" || Convert.ToDouble(txt_mod_wise_discount.Text) > 100)
            {
                MessageBox.Show("Please enter valid discount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txt_mosule_wise_amount_after_discount.Text = (Convert.ToDouble(txt_amount_paying_module_wise.Text.Remove(txt_amount_paying_module_wise.Text.Length - 2, 2)) * Convert.ToDouble(100 - Convert.ToDouble(txt_mod_wise_discount.Text)) / 100).ToString("R") + "/=";
                txt_final_amount_mod_wise.Text = General_methods.calc_amount_payable(txt_studno.Text, Convert.ToDouble(txt_amount_paying_module_wise.Text.Remove(txt_amount_paying_module_wise.Text.Length - 2, 2)),"Diploma").ToString("R") + "/=";
            }
        }
        
        private void metroTile4_Click(object sender, EventArgs e)
        {

            if (txt_mosule_wise_amount_after_discount.Text == "")
            {
                MessageBox.Show("Please calculate the final amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_amount_paying_module_wise.Text == "")
            {
                MessageBox.Show("Paying amounts for modules have not been confirmed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    d.insert("INSERT INTO PaymentDetails(Gross_amount,Discount_percent,Net_amount,Date,Time,stud_no_org_no,program_no,Remark,Payment_mode) VALUES ('" + txt_amount_paying_module_wise.Text.Remove(txt_amount_paying_module_wise.Text.Length - 2, 2).ToString() + "','" + txt_mod_wise_discount.Text + "','" + txt_mosule_wise_amount_after_discount.Text.Remove(txt_mosule_wise_amount_after_discount.Text.Length - 2, 2).ToString() + "','" + General_methods.get_current_date() + "','" + General_methods.get_current_time() + "','" + txt_studno.Text + "','None','Module wise Payement for Diploma course','"+cmb_payment_mode.Text+"')");
                    int id = d.singleInt("SELECT MAX(Payment_No) FROM PaymentDetails");
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        if (checkedListBox1.CheckedItems.Contains(checkedListBox1.Items[i]) == true && a.Contains(i) == false)
                        {
                            d.update("UPDATE Dip_stud_modules SET payement_no='" + id + "' WHERE stud_no='" + txt_studno.Text + "' AND module_no='" + General_methods.get_module_no_from_module_name(checkedListBox1.Items[i].ToString(), General_methods.get_course_no_from_course_name(txt_course_name.Text)) + "'");
                        }
                        else
                        {

                        }
                    }
                    if (cmb_payment_mode.SelectedIndex == 2)
                    {
                        d.insert("INSERT INTO Cheque_payments (Payment_no,Cheque_no) VALUES ('"+d.singleInt("SELECT MAX(Payment_No) FROM PaymentDetails") +"','"+txt_chequeno.Text+"')");
                    }
                    MessageBox.Show("Details Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult a1 = MessageBox.Show("Generate Recipt?", "Notofication", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this label is used for event firing
                    label1.Text = General_methods.Generate_RandomNumber(1, 678767).ToString();
                    //////////////
                    if (a1 == DialogResult.Yes)
                    {

                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            

        }

        private void metroTile10_Click(object sender, EventArgs e)
        {
            if (txt_discout_for_full_payment.Text.Any(char.IsLetter) == true || txt_discout_for_full_payment.Text == "" || Convert.ToDouble(txt_discout_for_full_payment.Text) > 100)
            {
                MessageBox.Show("Please enter valid discount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txt_amount_full_pay.Text = (Convert.ToDouble(txt_course_fee_for_full_payament.Text.Remove(txt_course_fee_for_full_payament.Text.Length - 2, 2)) * Convert.ToDouble(100 - Convert.ToDouble(txt_discout_for_full_payment.Text)) / 100).ToString("R") + "/=";
            }
        }

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton1.Checked == true)
            {
                groupBox2.Enabled = true;
                groupBox3.Enabled = false;
                enable();
            }
        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton2.Checked == true)
            {
                groupBox2.Enabled = false;
                groupBox3.Enabled = true;
            }
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (txt_amount_full_pay.Text == "")
            {
                MessageBox.Show("Please confirm amount paying", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dr = MessageBox.Show("You are about to save a payment. Press yes to confirm", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    d.insert("INSERT INTO PaymentDetails (Gross_amount,Discount_percent,Net_amount,Date,Time,stud_no_org_no,program_no,Remark) VALUES('" + txt_course_fee_for_full_payament.Text.Remove(txt_course_fee_for_full_payament.Text.Length-2,2) + "','" + txt_discout_for_full_payment.Text + "','" + txt_amount_full_pay.Text.Remove(txt_amount_full_pay.Text.Length-2,2) + "','" + DateTime.Today.ToShortDateString() + "','" + DateTime.Now.ToLongTimeString()+ "','" + studno + "','None','Full payement for diploma course')");
                    d.update("UPDATE Dip_stud_modules SET payement_no='" + d.singleInt("SELECT MAX(Payment_No) FROM PaymentDetails") + "' WHERE stud_no='" + studno + "' ");
                    MessageBox.Show("Details Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult a1 = MessageBox.Show("Generate Recipt?", "Notofication", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this label is used for event firing
                    label1.Text = General_methods.Generate_RandomNumber(0,72653).ToString();
                    if (a1 == DialogResult.Yes)
                    {

                    }
                    else
                    {

                    }
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void metroTile11_Click(object sender, EventArgs e)
        {

        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            
            if (txt_reg_fee_paying.Text.Any(char.IsLetter) == true || txt_reg_fee_paying.Text == "" || Convert.ToDouble(txt_reg_fee_of_course.Text.Remove(txt_reg_fee_of_course.Text.Length - 2, 2)) < Convert.ToDouble(txt_reg_fee_paying.Text))
            {
                MessageBox.Show("Please enter valid registration fee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dr = MessageBox.Show("You are about to save a payment. Press yes to confirm", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    d.insert("INSERT INTO PaymentDetails (Gross_amount,Discount_percent,Net_amount,Date,Time,stud_no_org_no,program_no,Remark) VALUES('" + txt_reg_fee_of_course.Text.Remove(txt_reg_fee_of_course.Text.Length - 2, 2) + "','0','" + txt_reg_fee_paying.Text + "','" + General_methods.get_current_date() + "','" + General_methods.get_current_time().ToString() + "','" + txt_studno.Text + "','None','Registration fee for diploma course')");
                    d.update("UPDATE Stud_details SET reg_fee='" + d.singleInt("SELECT MAX(Payment_No) FROM PaymentDetails").ToString() + "' WHERE stud_no='" + txt_studno.Text + "'");
                    MessageBox.Show("Details Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult a1 = MessageBox.Show("Generate Recipt?", "Notofication", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this label is used for event firing
                    label1.Text = General_methods.Generate_RandomNumber(0,2837872).ToString();
                    if (a1 == DialogResult.Yes)
                    {

                    }
                    else
                    {

                    }
                }
            }
        }

        private void metroLabel7_Click(object sender, EventArgs e)
        {

        }
      

        private void metroGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex==8 && e.RowIndex >= 0 )
            {
                DialogResult dc = MessageBox.Show("Are you sure you want to terminate payment?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dc == DialogResult.Yes)
                {
                    if (metroGrid2.Rows[e.RowIndex].Cells[6].Value.ToString() == "Full payement for diploma course")
                    {
                        d.update("UPDATE Dip_stud_modules SET payement_no=NULL WHERE stud_no='" + txt_studno.Text + "' AND payement_no='" + metroGrid2.Rows[e.RowIndex].Cells[0].Value.ToString() + "'");
                        d.delete("DELETE FROM PaymentDetails WHERE Payment_No='" + metroGrid2.Rows[e.RowIndex].Cells[0].Value.ToString() + "'");

                    }
                    else if (metroGrid2.Rows[e.RowIndex].Cells[6].Value.ToString() == "Module wise Payement for Diploma course")
                    {
                        d.update("UPDATE Dip_stud_modules SET payement_no=NULL WHERE stud_no='" + txt_studno.Text + "' AND payement_no='" + metroGrid2.Rows[e.RowIndex].Cells[0].Value.ToString() + "'");
                        d.delete("DELETE FROM PaymentDetails WHERE Payment_No='" + metroGrid2.Rows[e.RowIndex].Cells[0].Value.ToString() + "'");

                    }
                    else if(metroGrid2.Rows[e.RowIndex].Cells[6].Value.ToString() == "Registration fee for diploma course")
                    {
                        d.update("UPDATE Stud_details SET reg_fee=NULL WHERE stud_no='"+txt_studno.Text+"'");
                        d.delete("DELETE FROM PaymentDetails WHERE Payment_No='" + metroGrid2.Rows[e.RowIndex].Cells[0].Value.ToString() + "'");
                    }
                    MessageBox.Show("Succefully terminated payment", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label1.Text = General_methods.Generate_RandomNumber(0,99999).ToString();
                }
                else
                {

                }
            }
            else if (e.ColumnIndex == 9 && e.RowIndex >= 0)
            {
                MessageBox.Show("b");
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

        private void metroLabel19_Click(object sender, EventArgs e)
        {

        }

        private void txt_chequeno_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel8_Click(object sender, EventArgs e)
        {

        }
    }
}
