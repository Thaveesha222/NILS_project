using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NILS_original
{
    static class Class_student
    {
        public static string studno;
        public static string courseno;
        public static string coursename;
        public static string notes_folder;
        public static string assignment_folder;
        public static string papers_folder;
        public static string lname;
        public static string fname;
        public static string email;
        public static void studcredentials()
        {
                     
            SqlConnection con = new SqlConnection(Credentials.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Stud_details WHERE stud_no='"+studno+"'",con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

                
                courseno = dr.GetValue(17).ToString();
                coursename = General_methods.get_course_name_from_course_no(dr.GetValue(17).ToString());
                fname = dr.GetValue(1).ToString();
                lname = dr.GetValue(2).ToString();
                email = dr.GetValue(14).ToString();
                dr.Close();
                SqlCommand cmd1 = new SqlCommand("SELECT course_name FROM Course_details_master WHERE course_no='" + courseno + "'", con);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                dr1.Read();
                coursename = dr1.GetValue(0).ToString();
                dr1.Close();
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM Folder_ids WHERE course_no='" + courseno + "'", con);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                dr2.Read();
                notes_folder = dr2.GetValue(2).ToString();
                assignment_folder = dr2.GetValue(3).ToString();
                papers_folder = dr2.GetValue(4).ToString();
                dr2.Close();
                
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
