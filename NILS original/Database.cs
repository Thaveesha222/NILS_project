using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Windows.Forms;

namespace NILS_original
{
    public class Database
    {
        public SqlConnection con;
         public SqlDataReader dr;
        public SqlCommand cmd;
        //Data Source=udeesha.database.windows.net;Initial Catalog=NILS(original);Persist Security Info=True;User ID=udeesha;Password=Plusgo12#;Connection Timeout=10;
        public Database()
        {
            con = new SqlConnection(Credentials.connection);

        }
        public void Open()
        {
            try
            {

            }
            catch(SqlException)
            {
                MessageBox.Show("Couldn't Connect to your Online Server ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Open();
            }
        }
        public void Close()
        {
            con.Close();
        }

        public void insert(string command)
        {
                con.Open();
                SqlCommand cmd = new SqlCommand(command, con);
                cmd.ExecuteNonQuery();
                con.Close();
           
         
        }
        public void update(string command)
        {
           
            con.Open();
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.ExecuteNonQuery();
            con.Close();
          
        }
        public void delete(string command)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(command, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error during deleting of data");

            }
        }
        public void fillComboBox(string a, ComboBox b) //Use this for fill combo boxes
        {
            con.Open();
            cmd = new SqlCommand(a, con);
            dr = cmd.ExecuteReader();
            b.Items.Clear();
            while (dr.Read())
            {
                if (dr[0] == DBNull.Value)
                    continue;
                b.Items.Add(dr[0]);
            }
            con.Close();
        }
        public string singleString(string command)
        {
            /*try
            {*/
                string x;
                con.Open();
                cmd = new SqlCommand(command, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                x = (dr[0]).ToString();
                con.Close();
                return x;
            /*}
            catch (Exception e)
            {
                MessageBox.Show("Error during taking a single string");
                return "X";
            }*/

        }
        public int singleInt(string command)
        {
            try
            {
                int x;
                con.Open();
                cmd = new SqlCommand(command, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                x = Convert.ToInt32(dr[0]);
                //dr.Close();
                con.Close();
                // dr.Close();
                return x;
            }
            catch (Exception e)
            {
                return 0;
            }
            
        }
        public DataTable show(string command)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(command,con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;           
        }
        public string[] selectStringArray(string command) //For select an array of string
        {
            List<string> list = new List<string>();
            con.Open();
            cmd = new SqlCommand(command, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr[0] == DBNull.Value)
                    continue;
                list.Add(dr[0].ToString());
            }
            con.Close();
            string[] array = list.ToArray();
            return array;
        }
        public void datareader(string command)
        {
           
        }

        public string ID(string a) //To execute stored procedures
        {
            con.Open();
            cmd = new SqlCommand(a, con);
            cmd.CommandType = CommandType.StoredProcedure;
            object obj = cmd.ExecuteScalar();
            con.Close();
            return obj.ToString();
        }

    }
}
