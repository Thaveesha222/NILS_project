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
using System.IO;
using System.Net.Http;
using System.Text;
using Google.Apis.Http;
using System.Net;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace NILS_original
{
    public partial class New_company : MetroFramework.Forms.MetroForm
    {
        public New_company()
        {
            InitializeComponent();
            /*cmb_place.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_place.AutoCompleteSource = AutoCompleteSource.ListItems*/;
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
          
           
        }
        
        public void cmb_place_TextChanged(object sender, EventArgs e)
        {
            if (cmb_place.SelectedIndex > -1)
            {

            }
            else
            {
                G_maps.autocomplete_place_combobox(cmb_place);
            }
        }

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton1.Checked == true)
            {
                cmb_place.Enabled = true;
            }
            else
            {
                cmb_place.Enabled = false;
                id = "None";
                cmb_place.Text = "";
                txt_name.Text = "";
                txt_phoneno1.Text = "";
                txt_email.Text ="";
                txt_address.Text = "";
            }
        }
        string id;
        private void cmb_place_SelectedIndexChanged(object sender, EventArgs e)
        {
            id = G_maps.get_place_id_from_place_name(cmb_place.Text);
            string[] stats=  G_maps.get_place_details_from_place_id(id);
            txt_name.Text = stats[0].ToString();
            txt_address.Text = stats[1].ToString();
            txt_phoneno1.Text = stats[2].ToString();
            //txt_phoneno2.Text = stats[3].ToString();

        }
        
        private void metroTile1_Click_1(object sender, EventArgs e)
        {

            if (txt_name.Text == "")
            {
                MessageBox.Show(this, "Please enter company name","Missing Field",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else if (txt_email.Text == "")
            {
                MessageBox.Show(this, "Please enter company email", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txt_phoneno1.Text == "")
            {
                MessageBox.Show(this, "Please enter phone number", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txt_address.Text == "")
            {
                MessageBox.Show(this, "Please enter company address", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (metroCheckBox1.Checked == false && txt_fax.Text == "")
            {
                MessageBox.Show(this, "Please enter company fax", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                Database d = new Database();
                int company_id = d.singleInt("SELECT COUNT(*) FROM Company_details") + 1;
                if(metroCheckBox1.Checked==true)
                {
                    d.insert("INSERT INTO Company_details (Organization_id,Google_place_id,Organization_name,email,Address,tel_no,fax) VALUES ('" + company_id + "','" + id + "',N'" + txt_name.Text + "','" + txt_email.Text + "',N'" + txt_address.Text + "','" + txt_phoneno1.Text + "','Not available')");
                }
                else
                {
                    d.insert("INSERT INTO Company_details (Organization_id,Google_place_id,Organization_name,email,Address,tel_no,fax) VALUES ('" + company_id + "','" + id + "',N'" + txt_name.Text + "','" + txt_email.Text + "',N'" + txt_address.Text + "','" + txt_phoneno1.Text + "','" + txt_fax.Text + "')");
                }
                MessageBox.Show(this, "Successfully added company details", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
          
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked == true)
            {
                txt_fax.Text = "";
                txt_fax.Enabled = false;
            }
            else
            {
                txt_fax.Enabled = true;
            }
        }
    }
       
}

