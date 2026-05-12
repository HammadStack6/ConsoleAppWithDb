using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWithDb
{
    class Users
    {

        string connection = "Server=INTERN-PC4\\MSSQLSERVER01;Database=ConsoleAppWithDb;Trusted_Connection=True;";

        public void signup()
        {
            Console.WriteLine("signup bro");
            Console.WriteLine("enter username");
            string NEWUSERNAME = Console.ReadLine();
            Console.WriteLine("enter password");
            string CREATEPASSWORD = Console.ReadLine();


            SqlConnection con = new SqlConnection(connection);

            string query = " insert into users (username,password) values (NEWUSERNAME ,CREATEPASSWORD)";

            using(SqlCommand cmd = new SqlCommand(query,con))
            {
                cmd.Parameters.AddWithValue("@username", NEWUSERNAME);
                cmd.Parameters.AddWithValue ("@password", CREATEPASSWORD);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
    }
}
