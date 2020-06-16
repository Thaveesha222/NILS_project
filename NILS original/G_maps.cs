using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NILS_original
{
    static class G_maps
    {
        static JObject places;
        public static void autocomplete_place_combobox(System.Windows.Forms.ComboBox combobox)
        {
            
            try
            {
                if (combobox.Text == "")
                {

                }
                else
                {
                    int h = combobox.SelectionStart;
                    string[] splitted = combobox.Text.Split(' ');
                    int count = splitted.Length;
                    string finalparam = null;

                    for (int i = 0; i < count; i++)
                    {
                        finalparam = finalparam + "+" + splitted[i];
                    }

                    Uri target = new Uri("https://maps.googleapis.com/maps/api/place/autocomplete/json?input=" + finalparam.Remove(0, 1) + "&components=country:LK&key=AIzaSyA5adm56fjZXi9IDLbhWw9U7ZYhCif137c&sessiontoken=1234567890");
                    WebRequest request = WebRequest.Create(target);
                    request.Method = "GET";
                    request.ContentType = "application/x-www-form-urlencoded";
                    StreamReader responseReader = new StreamReader(request.GetResponse().GetResponseStream());
                    string response = responseReader.ReadToEnd();
                    JObject o = JObject.Parse(response);
                    places = o;
                    //MessageBox.Show(o.ToString());
                    string[] suggestions = new string[10];
                    int j = 0;
                    while (j < 10)
                    {
                        try
                        {

                            suggestions[j] = o["predictions"][j]["description"].ToString();
                            j++;
                        }
                        catch (System.ArgumentOutOfRangeException x)
                        {
                            break;
                        }

                    }
                    combobox.DataSource = suggestions;
                    combobox.Update();
                    combobox.SelectionStart = h;

                    //MessageBox.Show(o["predictions"][0]["description"].ToString());
                }
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("Network Failure (Make sure you are connected to the internet)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static string get_place_id_from_place_name_2(string name)
        {
            try
            {
                string finalparam = null;
                int count = name.Split(' ').Length;
                for (int i = 0; i < count; i++)
                {
                    finalparam = finalparam + "+" + name.Split(' ').GetValue(i);
                }
                Uri target = new Uri("https://maps.googleapis.com/maps/api/place/autocomplete/json?input=" + finalparam.Remove(0, 1) + "&components=country:LK&key=AIzaSyA5adm56fjZXi9IDLbhWw9U7ZYhCif137c&sessiontoken=1234567890");
                WebRequest request = WebRequest.Create(target);
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded";
                StreamReader responseReader = new StreamReader(request.GetResponse().GetResponseStream());
                string response = responseReader.ReadToEnd();
                JObject o = JObject.Parse(response);
                places = o;
                return get_place_id_from_place_name(name).ToString();
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("Network Failure (Make sure you are connected to the internet)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "x";
            }
        }
        public static string get_place_id_from_place_name(string name)
        {
       
            {
               
                int j = 0;
                string id = "";
                
                while (j < 10)
                {
                    try
                    {
                        if (places["predictions"][j]["description"].ToString() == name)
                        {

                            id = places["predictions"][j]["place_id"].ToString();
                            break;
                        }
                        else
                        {
                            j++;
                            continue;
                        }
                    }
                    catch (NullReferenceException)
                    {
                        break;
                    }
                    catch (System.ArgumentOutOfRangeException d)
                    {
                        MessageBox.Show("place not found", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                }
                return id;
            }
            
        }

        public static string[] get_place_details_from_place_id(string id)
        {
            Uri target = new Uri("https://maps.googleapis.com/maps/api/place/details/json?place_id="+id+"&fields=name,international_phone_number,website,formatted_address,geometry&key=AIzaSyA5adm56fjZXi9IDLbhWw9U7ZYhCif137c");
            WebRequest request = WebRequest.Create(target);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            StreamReader responseReader = new StreamReader(request.GetResponse().GetResponseStream());
            string response = responseReader.ReadToEnd();
            JObject o = JObject.Parse(response);
            string name;
            string address;
            string tel2;
            string latitude;
            string longitude;
            try
            {
                name = o["result"]["name"].ToString();
            }
            catch (System.NullReferenceException)
            {
                name = "None";
            }
            try
            {
                address = o["result"]["formatted_address"].ToString();
            }
            catch (System.NullReferenceException)
            {
                address = "None";
            }
            try
            {
                tel2 = o["result"]["international_phone_number"].ToString();
            }
            catch (System.NullReferenceException)
            {
                tel2 = "None";
            }
            try
            {
                latitude = o["result"]["geometry"]["location"]["lat"].ToString();
            }
            catch (System.NullReferenceException)
            {
                latitude = "None";
            }
            try
            {
                longitude = o["result"]["geometry"]["location"]["lng"].ToString();
            }
            catch (System.NullReferenceException)
            {
                longitude = null;
            }
            string[] compnonents = {name ,address,tel2,latitude,longitude};
            return compnonents;
        }
        
    }
}
