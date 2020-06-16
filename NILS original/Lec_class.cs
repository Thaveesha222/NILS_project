using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NILS_original
{
    static class Lec_class
    {
        public static string Lecno;
        
        public static string lname;
        public static string fname;
        public static string fullname;
       
        public static void leccredentials()
        {
            //Lecno = "0002";
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-39GK2U8;Initial Catalog=NILS(original);Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Lecture_details WHERE Lecturer_no='" + Lecno + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            
            fname = dr.GetValue(2).ToString();
            lname = dr.GetValue(3).ToString();
            fullname = "" + fname + " " + lname;

            dr.Close();
          
            /*SqlCommand cmd3 = new SqlCommand("SELECT f_name FROM Dip_stud_details WHERE stud_no='" + Class_student.studno + "'", con);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            dr3.Read();
            fname = dr3.GetValue(0).ToString();
            dr3.Close();
            SqlCommand cmd4 = new SqlCommand("SELECT l_name FROM Dip_stud_details WHERE stud_no='" + Class_student.studno + "'", con);
            SqlDataReader dr4 = cmd4.ExecuteReader();
            dr4.Read();
            lname = dr4.GetValue(0).ToString();*/
        }

    }
}
