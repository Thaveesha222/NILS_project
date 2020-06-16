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
    public partial class UC_short_payment : UserControl
    {
        SqlConnection con = new SqlConnection(Credentials.connection);
        public static string progno;
        public UC_short_payment()
        {
            InitializeComponent();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT Organization_id FROM Short_program_participation WHERE program_code='" + progno + "' AND Organization_id!='Individual'"+ "SELECT ref_no,Name,phone_no FROM Short_program_participation WHERE Organization_id='Individual' AND program_code='" + progno + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmb_companies.Items.Add(General_methods.find_organization_name_from_organization_no(dr.GetValue(0).ToString()));
            }
            dr.NextResult();
            while (dr.Read())
            {
                cmb_individual_participants.Items.Add(dr.GetValue(0).ToString() + " - " + dr.GetValue(1).ToString() + " - " + dr.GetValue(2).ToString());
            }
            con.Close();
            groupBox2.Enabled = false;
            checkedListBox1.CheckOnClick = true;
            txt_discount.Text = "00";
            txt_discount_individual.Text = "00";
            
        }
        Database d = new Database();
        public double calc_amount_payable(string orgname,double amount_paying)
        {
            con.Open();
            double tot = d.singleInt("SELECT COUNT(*) FROM Short_program_participation WHERE Organization_id='" + General_methods.find_organization_no_from_organization_name(orgname) + "' AND program_code='"+progno+"'") * Convert.ToDouble(txt_priceperhead.Text.Remove(txt_priceperhead.Text.Length-2,2));
            SqlCommand cmd = new SqlCommand("SELECT Gross_amount FROM PaymentDetails WHERE stud_no_org_no='"+ General_methods.find_organization_no_from_organization_name(orgname) + "' AND program_no='"+progno+"'",con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (d.singleInt("SELECT COUNT(*) FROM PaymentDetails WHERE stud_no_org_no='" + General_methods.find_organization_no_from_organization_name(orgname) + "' AND program_no='" + progno + "'") != 0)
            {
                while (dr.Read())
                {
                    tot = tot - Convert.ToDouble(dr.GetValue(0).ToString());
                }
            }
            con.Close();
            return tot-amount_paying;
        }
        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked == true)
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
                cmb_companies.Items.Add("");
                cmb_companies.Text = "";
                cmb_companies.Enabled = false;
                checkedListBox1.Items.Clear();
                txt_tot_amount_payable.Text = "";
                enable();
            }
            else
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                cmb_companies.Enabled = true;
                cmb_companies.Items.Remove("");
            }
        }
        List<int> a = new List<int>();
        private void cmb_companies_SelectedIndexChanged(object sender, EventArgs e)
        {
            metroGrid1.DataSource = null;
            metroGrid1.Update();
            metroGrid1.Columns.Clear();
            a.Clear();
            if (cmb_companies.Text != "")
            {
                checkedListBox1.Items.Clear();
                txt_tot_amount_payable.Text = calc_amount_payable(cmb_companies.Text,0).ToString()+"/=";
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Name,payment_no,ref_no  FROM Short_program_participation WHERE program_code='" + progno + "' AND Organization_id='" + General_methods.find_organization_no_from_organization_name(cmb_companies.Text) + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                int c = 0;
                while (dr.Read())
                {
                    
                    checkedListBox1.Items.Add(dr.GetValue(0).ToString()+"-"+ dr.GetValue(2).ToString());
                    if (!dr.IsDBNull(1))
                    {
                        checkedListBox1.SetItemChecked(c, true);
                        a.Add(c);
                    }
                    c++;
                }
                con.Close();
                metroGrid1.DataSource= d.show("SELECT Payment_No,Gross_amount,Discount_percent,Net_amount,Date,Time,Remark FROM PaymentDetails WHERE program_no='" + progno + "' AND stud_no_org_no='"+General_methods.find_organization_no_from_organization_name(cmb_companies.Text)+"'");
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
                DataGridViewButtonColumn bt3 = new DataGridViewButtonColumn();
                bt3.Text = "View Payed Students";
                bt3.FlatStyle = FlatStyle.Flat;
                bt3.UseColumnTextForButtonValue = true;
                bt3.Width = 150;
                metroGrid1.Columns.Add(bt3);
                metroGrid1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                metroGrid1.AllowUserToAddRows = false;

            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (a.Contains(e.Index)) e.NewValue = e.CurrentValue;
            else
            {

            }
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
            //metroTile8.Enabled = false;
            //metroGrid1.Rows.Clear();
            metroTile5.Text = "Ok";
            checkedListBox1.Enabled = true;
            txt_amount.Text = "";
            txt_discount.Text = "00";
            txt_netamount.Text = "";
            txt_new_amount_payable.Text = "";
            txt_remark.Text = "";
            
            
        }
        private void metroTile5_Click(object sender, EventArgs e)
        {
            double cost=0;
            if (metroTile5.Text == "Ok")
            {
                //metroTile8.Enabled = true;
                metroTile5.Text = "Change";
                checkedListBox1.Enabled = false;
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    //CheckState st = checkedListBox1.GetItemCheckState(i);

                    if (checkedListBox1.CheckedItems.Contains(checkedListBox1.Items[i]) == true && a.Contains(i) == false)
                    {
                        cost = cost + Convert.ToDouble(txt_priceperhead.Text.Remove(txt_priceperhead.Text.Length - 2, 2));
                        
                    }
                    else
                    {

                    }
                }
                txt_amount.Text = cost.ToString()+"/=";
            }
            else
            {
                enable();
            }
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            if (txt_discount.Text.Any(char.IsLetter) == true || txt_discount.Text == "" || Convert.ToDouble(txt_discount.Text) > 100)
            {
                MessageBox.Show("Please enter valid discount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txt_netamount.Text = (Convert.ToDouble(txt_amount.Text.Remove(txt_amount.Text.Length - 2, 2)) * Convert.ToDouble(100 - Convert.ToDouble(txt_discount.Text)) / 100).ToString("R") + "/=";
                txt_new_amount_payable.Text = calc_amount_payable(cmb_companies.Text,Convert.ToDouble(txt_amount.Text.Remove(txt_amount.Text.Length - 2, 2))).ToString()+"/=";
            }
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            string remark = "Payament for short programs / workshops (Company) -" + txt_remark.Text;
            if (txt_netamount.Text == "")
            {
                MessageBox.Show("Please calculate the final amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_amount.Text == "")
            {
                MessageBox.Show("Participants have not been selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    d.insert("INSERT INTO PaymentDetails(Gross_amount,Discount_percent,Net_amount,Date,Time,stud_no_org_no,program_no,Remark,Payment_mode) VALUES ('" + txt_amount.Text.Remove(txt_amount.Text.Length - 2, 2).ToString() + "','" + txt_discount.Text + "','" + txt_netamount.Text.Remove(txt_netamount.Text.Length - 2, 2).ToString() + "','" + General_methods.get_current_date() + "','" + General_methods.get_current_time() + "','" + General_methods.find_organization_no_from_organization_name(cmb_companies.Text)+ "','"+txt_progno.Text+"','"+remark+ "','" + cmb_payment_mode.Text + "')");
                    int id = d.singleInt("SELECT MAX(Payment_No) FROM PaymentDetails");
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        if (checkedListBox1.CheckedItems.Contains(checkedListBox1.Items[i]) == true && a.Contains(i) == false)
                        {
                            d.update("UPDATE Short_program_participation SET payment_no='"+id+"' WHERE ref_no='"+checkedListBox1.Items[i].ToString().Split('-').GetValue(1)+"'");
                        }
                        else
                        {

                        }
                    }
                    if (cmb_payment_mode.SelectedIndex == 2)
                    {
                        d.insert("INSERT INTO Cheque_payments (Payment_no,Cheque_no) VALUES ('" + d.singleInt("SELECT MAX(Payment_No) FROM PaymentDetails") + "','" + txt_chequeno.Text + "')");
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

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex == 7 && e.RowIndex >= 0)
            {
                DialogResult dc = MessageBox.Show("Are you sure you want to terminate payment?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dc == DialogResult.Yes)
                {
                    
                    d.update("UPDATE Short_program_participation SET payment_no=Null WHERE payment_no='"+metroGrid1.Rows[e.RowIndex].Cells[0].Value.ToString()+"'");
                    d.delete("DELETE FROM PaymentDetails WHERE Payment_No='" + metroGrid1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'");
                    MessageBox.Show("Succefully terminated payment", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label1.Text = General_methods.Generate_RandomNumber(0, 99999).ToString();
                }
                else
                {

                }
            }
            else if (e.ColumnIndex == 9 && e.RowIndex >= 0)
            {
                show_studs.pay_no = metroGrid1.Rows[e.RowIndex].Cells[0].Value.ToString();
                show_studs s = new show_studs();
                s.Show();
            }
        }

        private void cmb_individual_participants_SelectedIndexChanged(object sender, EventArgs e)
        {
            metroGrid2.Columns.Clear();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Gross_amount FROM PaymentDetails WHERE stud_no_org_no='" + cmb_individual_participants.Text.Split('-').GetValue(0).ToString() + "'",con);
            SqlDataReader dr = cmd.ExecuteReader();
            double tot=Convert.ToDouble(txt_priceperhead.Text.Remove(txt_priceperhead.Text.Length-2,2));         
            while (dr.Read())
            {
                tot = tot - Convert.ToDouble(dr.GetValue(0));
            }
            txt_amount_payable_individual.Text = tot.ToString()+"/=";
            con.Close();
            metroGrid2.DataSource = d.show("SELECT Payment_No,Gross_amount,Discount_percent,Net_amount,Date,Time,Remark FROM PaymentDetails WHERE program_no='" + progno + "' AND stud_no_org_no='" + cmb_individual_participants.Text.Split('-').GetValue(0) + "'");
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
            metroGrid2.AllowUserToAddRows = false;
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            if (txt_discount_individual.Text.Any(char.IsLetter) == true || txt_discount_individual.Text == "" || Convert.ToDouble(txt_discount_individual.Text) > 100)
            {
                MessageBox.Show("Please enter valid discount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_amount_paying_individual.Text.Any(char.IsLetter) == true || txt_amount_paying_individual.Text == "" || Convert.ToDouble(txt_amount_paying_individual.Text) > Convert.ToDouble(txt_amount_payable_individual.Text.Remove(txt_amount_payable_individual.Text.Length-2,2)))
            {
                MessageBox.Show("Please enter valid amount paying", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                txt_netamount_individual.Text = (Convert.ToDouble(txt_amount_paying_individual.Text) * Convert.ToDouble(100 - Convert.ToDouble(txt_discount_individual.Text)) / 100).ToString("R") + "/=";
            }
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            string remark = "Payament for short programs / workshops (Individual) -" + txt_remark_individual.Text;
            if (txt_amount_payable_individual.Text == "")
            {
                MessageBox.Show("Please select participant", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_amount_paying_individual.Text == "")
            {
                MessageBox.Show("Please enter amount paying", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_discount_individual.Text == "")
            {
                MessageBox.Show("Please enter discount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_netamount_individual.Text == "")
            {
                MessageBox.Show("Final amount not calculated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmb_payment_mode2.Text == "")
            {
                MessageBox.Show("Please select payment method", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmb_payment_mode2.SelectedIndex == 2 && txt_cheque_no2.Text == "")
            {
                MessageBox.Show("Please enter the cheque number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dr = MessageBox.Show("You are about to save a payment. Press yes to confirm", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {

                    d.insert("INSERT INTO PaymentDetails(Gross_amount,Discount_percent,Net_amount,Date,Time,stud_no_org_no,program_no,Remark) VALUES ('" + txt_amount_paying_individual.Text.ToString() + "','" + txt_discount.Text + "','" + txt_netamount_individual.Text.Remove(txt_netamount_individual.Text.Length - 2, 2).ToString() + "','" + General_methods.get_current_date() + "','" + General_methods.get_current_time() + "','" +cmb_individual_participants.Text.Split('-').GetValue(0).ToString() + "','" + txt_progno.Text + "','" + remark + "')");
                    int id = d.singleInt("SELECT MAX(Payment_No) FROM PaymentDetails");
                    d.update("UPDATE Short_program_participation SET payment_no='" + id + "' WHERE ref_no='" + cmb_individual_participants.Text.Split('-').GetValue(0).ToString() + "'");
                    if (cmb_payment_mode2.SelectedIndex == 2)
                    {
                        d.insert("INSERT INTO Cheque_payments (Payment_no,Cheque_no) VALUES ('" + d.singleInt("SELECT MAX(Payment_No) FROM PaymentDetails") + "','" + txt_cheque_no2.Text + "')");
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

        private void metroGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex == 7 && e.RowIndex >= 0)
            {
                DialogResult dc = MessageBox.Show("Are you sure you want to terminate payment?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dc == DialogResult.Yes)
                {

                    d.update("UPDATE Short_program_participation SET payment_no=Null WHERE payment_no='" + metroGrid2.Rows[e.RowIndex].Cells[0].Value.ToString() + "'");
                    d.delete("DELETE FROM PaymentDetails WHERE Payment_No='" + metroGrid2.Rows[e.RowIndex].Cells[0].Value.ToString() + "'");
                    MessageBox.Show("Succefully terminated payment", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label1.Text = General_methods.Generate_RandomNumber(0, 99999).ToString();
                }
                else
                {

                }
            }
            
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void cmb_payment_mode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_payment_mode2.SelectedIndex == 2)
            {
                txt_cheque_no2.Enabled = true;
            }
            else
            {
                txt_cheque_no2.Enabled = false;

            }
        }
    }
}
