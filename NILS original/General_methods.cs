using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using System.Threading;

namespace NILS_original
{
    static class General_methods
    {
        public static string get_module_no_from_module_name(string mod_name, string course_no)
        {
            if (mod_name != "no modules")
            {
                SqlConnection con = new SqlConnection(Credentials.connection);
                con.Open();
                SqlCommand cmd1 = new SqlCommand(("SELECT Module_id FROM Dip_module_details_2 WHERE Module_name='" + mod_name + "' AND Course_no='" + course_no + "'"), con);
                SqlDataReader dr = cmd1.ExecuteReader();
                dr.Read();
                return dr.GetValue(0).ToString();
            }
            else
            {
                return "no modules";
            }
        }
        public static string[] fill_module_combobox(string no)
        {
            SqlConnection con = new SqlConnection(Credentials.connection);
            con.Open();
            /*SqlCommand cmd2 = new SqlCommand("SELECT course_no FROM Course_details_master WHERE course_name='" + name + "'", con);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            dr2.Read();
            string courseno = dr2.GetValue(0).ToString();
            dr2.Close();*/

            string[] name1 = new string[100];

            Array.Clear(name1, 0, 100);
            SqlCommand cmd1 = new SqlCommand(("SELECT * FROM Dip_module_details_2 WHERE Course_no='" + no + "'"), con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            int count = 0;
            while (dr1.Read())
            {
                name1[count] = Convert.ToString(dr1.GetValue(1));
                count++;
            }

            dr1.Close();

            con.Close();
            return name1;
        }
        public static int Generate_RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public static List<string> fill_designations_combobox()
        {
            List<string> listA = new List<string>();
            using (var reader = new StreamReader(@"C:\Users\94762\Desktop\Viva\NILS-2\NILS original\NILS original\occupations.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    listA.Add(line);
                }
            }
            return listA;
        }
        public static List<string> fill_course_mediums_combobox(string cno)
        {
            List<string> h = new List<string>();
            SqlConnection con = new SqlConnection(Credentials.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT English,Sinhala,Tamil FROM Course_details_master WHERE course_no='" + cno + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.GetBoolean(0) == true)
            {
                h.Add("English");
            }
            if (dr.GetBoolean(1) == true)
            {
                h.Add("Sinhala");
            }
            if (dr.GetBoolean(2) == true)
            {
                h.Add("Tamil");
            }
            return h;
        }
        public static string[] fill_course_combobox(string name)
        {
            string[] name2 = new string[100];
            SqlConnection con = new SqlConnection(Credentials.connection);
            if (name == "Diploma")
            {

                con.Open();
                SqlCommand cmd1 = new SqlCommand(("SELECT course_name FROM Course_details_master WHERE course_type='Diploma'"), con);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                int count = 0;

                while (dr1.Read())
                {
                    name2[count] = Convert.ToString(dr1.GetValue(0));
                    count++;
                }

                dr1.Close();
                con.Close();


            }
            if (name == "Certificate")
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand(("SELECT course_name FROM Course_details_master WHERE course_type='Certificate'"), con);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                int count = 0;
                while (dr1.Read())
                {
                    name2[count] = Convert.ToString(dr1.GetValue(0));
                    count++;
                }

                dr1.Close();
                con.Close();


            }
            if (name == "Short")
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand(("SELECT course_name FROM Course_details_master WHERE course_type='Short'  "), con);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                int count = 0;
                while (dr1.Read())
                {
                    name2[count] = Convert.ToString(dr1.GetValue(0));
                    count++;
                }
                dr1.Close();
                con.Close();

            }
            return name2;
        }





        public static string[] fill_lecturer_names_combobox()
        {
            SqlConnection con = new SqlConnection(Credentials.connection);
            con.Open();
            SqlCommand cmd2 = new SqlCommand(("SELECT F_name FROM Lecture_details"), con);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            string[] first = new string[200];
            string[] first1 = new string[200];
            int count2 = 0;
            while (dr2.Read())
            {
                first[count2] = Convert.ToString(dr2.GetValue(0));
                first1[count2] = Convert.ToString(dr2.GetValue(0));
                count2++;
            }
            dr2.Close();
            SqlCommand cmd3 = new SqlCommand(("SELECT L_name FROM Lecture_details"), con);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            int count3 = 0;
            string[] last = new string[200];
            string[] last1 = new string[200];
            for (count3 = 0; dr3.Read(); count3++)
            {
                last[count3] = Convert.ToString(dr3.GetValue(0));
                last1[count3] = Convert.ToString(dr3.GetValue(0));
            }
            int count4 = 0;
            string[] full = new string[200];
            string[] full1 = new string[200];
            while (count4 < count2)
            {
                full[count4] = "" + first[count4] + " " + last[count4];
                full1[count4] = "" + first[count4] + " " + last[count4];
                count4++;
            }


            //cmb_mornLec.DataSource = full;
            //cmb_noonLec.DataSource = full1;
            dr3.Close();
            con.Close();
            return full;

        }

        public static string get_lec_no_from_lec_name(string name)
        {
            if (name == "None")
            {
                return "";
            }
            else if (name == "")
            {
                return "";
            }
            else if (name == null)
            {
                return "";
            }
            else
            {
                string lecno;
                SqlConnection con = new SqlConnection(Credentials.connection);
                con.Open();
                string[] array = name.Split(new char[] { ' ' }, 2);
                SqlCommand cmd = new SqlCommand("SELECT Lecturer_no FROM Lecture_details WHERE F_name='" + array[0] + "' AND L_name='" + array[1] + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                lecno = dr.GetValue(0).ToString();
                dr.Close();
                con.Close();
                return lecno;
            }
        }
        public static string get_lec_name_from_lec_no(string no)
        {
            if (no == "None")
            {
                return "";
            }
            else
            {
                SqlConnection con = new SqlConnection(Credentials.connection);
                SqlCommand cmd2 = new SqlCommand(("SELECT F_name FROM Lecture_details WHERE Lecturer_no='" + no + "'" + "SELECT L_name FROM Lecture_details WHERE Lecturer_no='" + no + "'"), con);
                con.Open();
                SqlDataReader dr2 = cmd2.ExecuteReader();
                dr2.Read();
                string fname = dr2.GetValue(0).ToString();
                dr2.NextResult();
                dr2.Read();
                string lname = dr2.GetValue(0).ToString();
                string fullname = "" + fname + " " + lname;
                con.Close();
                return fullname;
            }
        }
        public static string get_course_no_from_course_name(string name)
        {
            SqlConnection con = new SqlConnection(Credentials.connection);
            SqlCommand cmd2 = new SqlCommand(("SELECT course_no  FROM Course_details_master WHERE course_name='" + name + "'"), con);
            con.Open();
            SqlDataReader dr2 = cmd2.ExecuteReader();
            dr2.Read();
            string x = dr2.GetValue(0).ToString();
            dr2.Close();
            return x;

        }
        public static List<string> fill_batches_combobox(string ctype)
        {
            if (ctype != "All")
            {
                SqlConnection con = new SqlConnection(Credentials.connection);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT b.Batch_name FROM Batches b INNER JOIN Course_details_master c ON b.Course_no=c.course_no WHERE c.course_type='" + ctype + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                List<string> f = new List<string>();
                while (dr.Read())
                {
                    f.Add(dr.GetValue(0).ToString());
                }
                con.Close();
                return f;
            }
            else
            {
                SqlConnection con = new SqlConnection(Credentials.connection);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT b.Batch_name FROM Batches b INNER JOIN Course_details_master c ON b.Course_no=c.course_no ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                List<string> f = new List<string>();
                while (dr.Read())
                {
                    f.Add(dr.GetValue(0).ToString());
                }
                con.Close();
                return f;
            }
        }
        public static string get_medium_from_batch_no(string no)
        {
            Database d = new Database();
            return d.singleString("SELECT Medium FROM Batches WHERE Batch_no='"+no+"'");
        }
        public static string get_course_no_of_batch_from_batch_no(string no)
        {
            Database d = new Database();
            return d.singleString("SELECT Course_no FROM Batches WHERE Batch_no='" + no + "'");
        }
        public static string get_course_no_of_student(string studno)
        {
            SqlConnection con = new SqlConnection(Credentials.connection);
            SqlCommand cmd2 = new SqlCommand(("SELECT course_no FROM Stud_details WHERE stud_no='" + studno + "'"), con);
            con.Open();
            SqlDataReader r = cmd2.ExecuteReader();
            r.Read();
            string x = r.GetValue(0).ToString();
            return x;
        }
        public static string get_module_name_from_module_no(string no)
        {
            if (no == "None")
            {
                return "None";
            }
            else
            {
                SqlConnection con = new SqlConnection(Credentials.connection);
                con.Open();
                SqlCommand cmd2 = new SqlCommand(("SELECT Module_name FROM Dip_module_details_2 WHERE Module_id='" + no + "'"), con);
                SqlDataReader r = cmd2.ExecuteReader();
                r.Read();
                string x = r.GetValue(0).ToString();
                con.Close();
                return x;
            }
        }
        public static string get_batch_no_of_student(string studno)
        {
            Database d = new Database();
            return d.singleString("SELECT b.Batch_no FROM Stud_details s INNER JOIN Batches b ON s.batch_no=b.Batch_no WHERE s.stud_no='" + studno + "'");
        }
        public static string get_course_type_from_course_no(string no)
        {
            Database d = new Database();
            return d.singleString("SELECT course_type FROM Course_details_master WHERE course_no='"+no+"'");
        }
        public static string[] get_organization_details_from_org_name(string no)
        {
            Database d = new Database();
            SqlConnection con = new SqlConnection(Credentials.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT tel_no,email,fax FROM Company_details WHERE Organization_name=N'" + no + "' " + "", con);
            SqlDataReader dr = cmd.ExecuteReader();
            string[] s = new string[4];
            dr.Read();
            //s[0] = dr.GetValue(0).ToString();
            s[0] = d.singleString("SELECT Address_string FROM Place_Details WHERE place_id='"+d.singleString("SELECT Google_place_id FROM Company_details WHERE Organization_name='"+no+"'")+"'");
            s[1] = dr.GetValue(0).ToString();
            s[2] = dr.GetValue(1).ToString();
            s[3] = dr.GetValue(2).ToString();
            con.Close();
            return s;
        }
        /* public static string[] fill_module_combobox(string name)
         {
             SqlConnection con = new SqlConnection(Credentials.connection);
             con.Open();
             SqlCommand cmd2 = new SqlCommand("SELECT course_no FROM Course_details_master WHERE course_name='" + name + "'", con);
             SqlDataReader dr2 = cmd2.ExecuteReader();
             dr2.Read();
             string courseno = dr2.GetValue(0).ToString();
             dr2.Close();

             string[] name1 = new string[100];

             Array.Clear(name1, 0, 100);
             SqlCommand cmd1 = new SqlCommand(("SELECT * FROM Dip_module_details_2 WHERE Course_no='" + courseno + "'"), con);
             SqlDataReader dr1 = cmd1.ExecuteReader();
             int count = 0;
             while (dr1.Read())
             {
                 name1[count] = Convert.ToString(dr1.GetValue(1));
                 count++;
             }

             dr1.Close();

             con.Close();
             return name1;
         }




         public static string[] fill_course_combobox(string name)
         {
             string[] name2 = new string[100];
             SqlConnection con = new SqlConnection(Credentials.connection);
             if (name == "Diploma")
             {

                 con.Open();
                 SqlCommand cmd1 = new SqlCommand(("SELECT course_name FROM "), con);
                 SqlDataReader dr1 = cmd1.ExecuteReader();
                 int count = 0;

                 while (dr1.Read())
                 {
                     name2[count] = Convert.ToString(dr1.GetValue(0));
                     count++;
                 }

                 dr1.Close();
                 con.Close();


             }
             if (name == "Certificate")
             {
                 con.Open();
                 SqlCommand cmd1 = new SqlCommand(("SELECT course_name FROM certif_course_details"), con);
                 SqlDataReader dr1 = cmd1.ExecuteReader();
                 int count = 0;
                 while (dr1.Read())
                 {
                     name2[count] = Convert.ToString(dr1.GetValue(0));
                     count++;
                 }

                 dr1.Close();
                 con.Close();


             }
             if (name == "Short")
             {
                 con.Open();
                 SqlCommand cmd1 = new SqlCommand(("SELECT course_name FROM Short_course_details"), con);
                 SqlDataReader dr1 = cmd1.ExecuteReader();
                 int count = 0;
                 while (dr1.Read())
                 {
                     name2[count] = Convert.ToString(dr1.GetValue(0));
                     count++;
                 }
                 dr1.Close();
                 con.Close();

             }
             return name2;
         }





         public static string[] fill_lecturer_names_combobox()
         {
             SqlConnection con = new SqlConnection(Credentials.connection);
             con.Open();
             SqlCommand cmd2 = new SqlCommand(("SELECT F_name FROM Lecture_details"), con);
             SqlDataReader dr2 = cmd2.ExecuteReader();
             string[] first = new string[200];
             string[] first1 = new string[200];
             int count2 = 0;
             while (dr2.Read())
             {
                 first[count2] = Convert.ToString(dr2.GetValue(0));
                 first1[count2] = Convert.ToString(dr2.GetValue(0));
                 count2++;
             }
             dr2.Close();
             SqlCommand cmd3 = new SqlCommand(("SELECT L_name FROM Lecture_details"), con);
             SqlDataReader dr3 = cmd3.ExecuteReader();
             int count3 = 0;
             string[] last = new string[200];
             string[] last1 = new string[200];
             for (count3 = 0; dr3.Read(); count3++)
             {
                 last[count3] = Convert.ToString(dr3.GetValue(0));
                 last1[count3] = Convert.ToString(dr3.GetValue(0));
             }
             int count4 = 0;
             string[] full = new string[200];
             string[] full1 = new string[200];
             while (count4 < count2)
             {
                 full[count4] = "" + first[count4] + " " + last[count4];
                 full1[count4] = "" + first[count4] + " " + last[count4];
                 count4++;
             }


             //cmb_mornLec.DataSource = full;
             //cmb_noonLec.DataSource = full1;
             dr3.Close();
             con.Close();
             return full;

         }

         public static string get_lec_no_from_lec_name(string name)
         {
             string lecno;
             SqlConnection con = new SqlConnection(Credentials.connection);
             con.Open();
             string[] array = name.Split(new char[] { ' ' }, 2);
             SqlCommand cmd = new SqlCommand("SELECT Lecturer_no FROM Lecture_details WHERE F_name='" + array[0] + "' AND L_name='" + array[1] + "'", con);
             SqlDataReader dr = cmd.ExecuteReader();
             dr.Read();
             lecno = dr.GetValue(0).ToString();
             dr.Close();
             con.Close();
             return lecno;
         }
         public static string get_lec_name_from_lec_no(string no)
         {
             SqlConnection con = new SqlConnection(Credentials.connection);
             SqlCommand cmd2 = new SqlCommand(("SELECT F_name FROM Lecture_details WHERE Lecturer_no='" + no + "'" + "SELECT L_name FROM Lecture_details WHERE Lecturer_no='" + no + "'"), con);
             con.Open();
             SqlDataReader dr2 = cmd2.ExecuteReader();
             dr2.Read();
             string fname = dr2.GetValue(0).ToString();
             dr2.NextResult();
             dr2.Read();
             string lname = dr2.GetValue(0).ToString();
             string fullname = "" + fname + " " + lname;
             con.Close();
             return fullname;
         }
         public static string get_course_no_from_course_name(string name)
         {
             SqlConnection con = new SqlConnection(Credentials.connection);
             SqlCommand cmd2 = new SqlCommand(("SELECT course_no  FROM Course_details_master WHERE course_name='" + name + "'" ), con);
             con.Open();
             SqlDataReader dr2 = cmd2.ExecuteReader();
             if (dr2.HasRows == true)
             {
                 dr2.Read();

             }
             else
             {

             }

             return dr2.GetValue(0).ToString();

         }*/
        public static List<string> fill_Resource_persons_combobox()
        {
            SqlConnection con = new SqlConnection(Credentials.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Lecturer_no,Name_with_initals,NIC FROM Lecture_details",con);
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> v = new List<string>();
            while (dr.Read())
            {
                v.Add(dr.GetValue(0) + " - " + dr.GetValue(1) + " - " + dr.GetValue(2));
            }
            con.Close();
            return v;
        }
        public static void combobox_autocomplete(ComboBox c,List<string>items)
        {
            int h = c.SelectionStart;
            if (c.SelectedIndex > -1)
            {

            }
            else
            {
                int a = 0;
                c.Items.Clear();
                foreach (string p in items)
                {
                    if (p.Contains(c.Text))
                    {
                        c.Items.Add(p);
                        a = 1;
                    }
                    else
                    {
                        
                    }
                }
                if (a == 0)
                {
                    c.Items.Add("No matches");
                }
                c.Update();
                c.SelectionStart = h;
            }
        }
        public static string get_lec_no_from_lec_name_from_combobox(string selectedtext)
        {
            if (selectedtext == "None")
            {
                return "None";
            }
            else
            {
                
                return selectedtext.Split('-').GetValue(0).ToString();
            }
        }
        public static string get_course_name_from_course_no(string no)
        {
            SqlConnection con = new SqlConnection(Credentials.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT course_name FROM Course_details_master WHERE course_no='" + no + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            return dr.GetValue(0).ToString();
        }
        public static List<string> fill_companys_combobx()
        {
            SqlConnection con = new SqlConnection(Credentials.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Organization_name FROM Company_details", con);
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> names = new List<string>();
            while (dr.Read())
            {
                names.Add(dr.GetValue(0).ToString());
            }
            con.Close();
            return names;
        }
        public static string[] Fill_lec_specific_areas_combobox()
        {
            SqlConnection con = new SqlConnection(Credentials.connection);
            con.Open();
            string[] name1 = new string[100];
            Array.Clear(name1, 0, 100);
            SqlCommand cmd1 = new SqlCommand("SELECT area FROM Lec_specific_areas", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            int count = 0;
            while (dr1.Read())
            {
                name1[count] = Convert.ToString(dr1.GetValue(0));
                count++;
            }

            dr1.Close();
            con.Close();
            return name1;
        }
        public static string Quick_NIC_Validation(string nic)
        {
            if ((nic.Length == 12 || nic.Length == 10) == false)
            {
                return "Invalid";
            }
            else if (nic.Length == 12 && (nic.All(char.IsDigit) == false))
            {
                return "Invalid";
            }
            else if (nic.Length == 10 &&(nic.ToCharArray()[9] != 'V' && nic.ToCharArray()[9] != 'X' && nic.ToCharArray()[9] != 'v' && nic.ToCharArray()[9] != 'x'))
            {
                return "Invalid";
            }
            else
            {
                return "Valid";
            }

        }
        public static string NIC_validation (string nic,DateTime birthdate,string gender)
        {

            if (nic.Length == 12 || nic.Length == 10)
            {
                
                if (nic.Length == 12)
                {
                    if (nic.All(char.IsDigit) == false)
                    {
                        return "invalid";
                    }
                    else if (gender == "male" && Convert.ToInt32(nic.Substring(4, 3)) > 500)
                    {
                        return "invalid";
                    }
                    else if (gender == "female" && Convert.ToInt32(nic.Substring(4, 3)) < 500)
                    {
                        return "invalid";
                    }
                    else if (birthdate.Year.ToString() != nic.Substring(0, 4))
                    {
                        return "invalid";
                    }

                    else if (Convert.ToInt32(nic.Substring(4, 3)) != get_days(birthdate) && gender == "male")
                    {
                        return "invalid";
                    }
                    else if (Convert.ToInt32(nic.Substring(4, 3))  != get_days(birthdate)+500 && gender == "female")
                    {
                        return "invalid";
                    }
                    else
                    {
                        return "valid";
                    }


                }
                else
                {
                    
                    char[] a = nic.ToCharArray();
                    if (a[9] != 'V' && a[9] != 'X' && a[9] != 'v' && a[9] != 'x')
                    {
                        return "invalid";
                    }
                    else if (gender == "male" && Convert.ToInt32(nic.Substring(2, 3)) > 500)
                    {
                       
                        return "invalid";
                    }
                    else if (gender == "female" && Convert.ToInt32(nic.Substring(2, 3)) < 500)
                    {
                        
                        return "invalid";
                    }
                    else if (birthdate.Year.ToString().Remove(0, 2) != nic.Substring(0, 2))
                    {
                        
                        return "invalid";
                    }

                    else if (Convert.ToInt32(nic.Substring(2, 3)) != get_days(birthdate) && gender == "male")
                    {
                        
                        return "invalid";
                    }
                    else if (Convert.ToInt32(nic.Substring(2, 3)) != get_days(birthdate)+500 && gender == "female")
                    {
                        return "invalid";
                    }
                    else
                    {
                        return "valid";
                    }

                }

            }
            else
            {
                return "invalid";
            }
            
        }
        public static int get_days(DateTime date)
        {
            if (date.Month == 1)
            {
                return date.Day;
            }
            else if (date.Month == 2)
            {
                return date.Day + 31;
            }
            else if (date.Month == 3)
            {
                return date.Day + 60;
            }
            else if (date.Month == 4)
            {
                return date.Day + 91;
            }
            else if (date.Month == 5)
            {
                return date.Day + 121;
            }
            else if (date.Month == 6)
            {
                return date.Day + 152;
            }
            else if (date.Month == 7)
            {
                return date.Day + 182;
            }
            else if (date.Month == 8)
            {
                return date.Day + 213;
            }
            else if (date.Month == 9)
            {
                return date.Day + 244;
            }
            else if (date.Month == 10)
            {
                return date.Day + 274;
            }
            else if (date.Month == 11)
            {
                return date.Day + 305;
            }
            else if (date.Month == 12)
            {
                return date.Day + 335;
            }
            else
            {
                return 0;
            }

        }
        public static string find_organization_no_from_organization_name(string orgname)
        {
            Database d = new Database();            
            return d.singleString("SELECT Organization_id FROM Company_details WHERE Organization_name  = N'" + orgname + "'");
        }
        public static string find_organization_name_from_organization_no(string orgno)
        {
            Database d = new Database();
            return d.singleString("SELECT Organization_name FROM Company_details WHERE Organization_id  = '" + orgno + "'");
        }
        public static string check_if_id_exists(string nic,string batchno)
        {
            int a = 0;
            Database d = new Database();
            a = d.singleInt("SELECT COUNT(*) FROM Stud_details WHERE NIC='"+nic+"' AND batch_no='"+batchno+"'");
            if (a == 0)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }
        public static string get_batch_no_from_batch_name(string name)
        {
            Database d = new Database();
            return d.singleString("SELECT Batch_no FROM Batches WHERE Batch_name='"+name+"'");
        }
        public static string get_batch_name_from_batch_ne(string no)
        {
            Database d = new Database();
            return d.singleString("SELECT Batch_name FROM Batches WHERE Batch_no='" + no + "'");
        }
        public static void get_stud_pic(PictureBox c,string studno)
        {

            SqlConnection con = new SqlConnection(Credentials.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT pic,ref FROM Stud_details WHERE stud_no='"+studno+"'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.IsDBNull(1))
            {
                if (!dr.IsDBNull(0))
                {
                    byte[] img = new byte[0];
                    img = (byte[])dr.GetValue(0);
                    MemoryStream mem = new MemoryStream(img);
                    c.Image = Image.FromStream(mem);
                    con.Close();
                }
            }
            else
            {
                SqlCommand cmd2 = new SqlCommand("SELECT pic FROM Stud_details WHERE stud_no='" + dr.GetValue(1).ToString() + "'",con);
                dr.Close();
                SqlDataReader dr2 = cmd2.ExecuteReader();
                dr2.Read();
                if (!dr2.IsDBNull(0))
                {
                    byte[] img = new byte[0];
                    img = (byte[])dr2.GetValue(0);
                    MemoryStream mem = new MemoryStream(img);
                    c.Image = Image.FromStream(mem);
                    con.Close();
                }
            }

            
        }
        public static void get_lec_pic(PictureBox c, string lec)
        {

            SqlConnection con = new SqlConnection(Credentials.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT img FROM Lecture_details WHERE Lecturer_no='" + lec + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (!dr.IsDBNull(0))
            {
                byte[] img = new byte[0];
                img = (byte[])dr.GetValue(0);
                MemoryStream mem = new MemoryStream(img);
                c.Image = Image.FromStream(mem);
                con.Close();
            }
            else
            {
                c.Image = Properties.Resources.user_50px;
            }
                       
        }
        public static double calc_amount_payable(string stud_no, double amount_paying,string type)
        {
            Database d = new Database();
            double tot_payed = 0;
            SqlConnection con2 = new SqlConnection(Credentials.connection);
            if (type == "Diploma")
            {
                
                con2.Open();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT payement_no FROM Dip_stud_modules WHERE stud_no='" + stud_no + "'", con2);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        tot_payed = tot_payed + Convert.ToDouble(d.singleString("SELECT Gross_amount FROM PaymentDetails WHERE Payment_No='" + dr.GetValue(0).ToString() + "'"));
                    }
                    else
                    {

                    }
                }
                tot_payed = tot_payed + amount_paying;
                con2.Close();
                return Convert.ToDouble(d.singleString("SELECT course_fee_for_batch FROM Batches WHERE Batch_no='" + General_methods.get_batch_no_of_student(stud_no) + "'")) - tot_payed;
            }
            else
            {
                con2.Open();
                SqlCommand cmd = new SqlCommand("SELECT Gross_amount FROM PaymentDetails WHERE stud_no_org_no='"+stud_no+"'AND Remark='Course fee for Certificate course'", con2);
                SqlDataReader dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    
                    tot_payed = tot_payed + Convert.ToDouble(dr.GetValue(0));
                }
                con2.Close();
                tot_payed = tot_payed + amount_paying;
                return Convert.ToDouble(d.singleString("SELECT course_fee_for_batch FROM Batches WHERE Batch_no='" + General_methods.get_batch_no_of_student(stud_no) + "'")) - tot_payed;

            }
        }
        public static string get_current_date()
        {
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd");
            return sqlFormattedDate;
        }
        public static string get_current_time()
        {
            return (DateTime.Now.ToLongTimeString());
        }
        public static string convert_any_date_to_general_date_format(string date)
        {
            /* DateTime dt = DateTime.ParseExact(DateTime.Today.ToShortDateString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                   return Convert.ToDateTime(date).ToString(dt);*/
            return "";
        }
        public static string[] fill_districts_combobox()
        {
            string[] districts = { "Ampara", "Anuradhapura", "Badulla", "Batticaloa", "Colombo", "Galle", "Gampaha", "Hambantota", "Jaffna", "Kalutara", "Kandy", "Kegalle", "Kilinochchi", "Kurunegala", "Mannar", "Matale", "Matara", "Monaragala", "Mullaitivu", "Nuwara Eliya", "Polonnaruwa", "Puttalam", "Ratnapura", "Trincomalee", "Vavuniya" };
            return districts;
        }
    }
    
}
