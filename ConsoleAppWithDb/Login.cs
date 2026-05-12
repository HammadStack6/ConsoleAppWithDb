 using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleAppWithDb
{
    class Login
    {

        string connection = "Server=INTERN-PC4\\MSSQLSERVER01;Database=ConsoleAppWithDb;Trusted_Connection=True;";
        public bool IsLoggedIn = false;
        public void loginn()
        {
            Console.WriteLine("welcome at hammads practice app");

            Console.WriteLine("enter user name");
            string USERNAME = Console.ReadLine();

            Console.WriteLine("enter password");
            string PASSWORD = Console.ReadLine();

          

            using (SqlConnection conn = new SqlConnection(connection))
            {
                string query = "select username , password from users";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string fromdbusername = reader["username"].ToString();
                    string fromdbpassword = reader["password"].ToString();

                    if (USERNAME.Equals(fromdbusername) & PASSWORD.Equals(fromdbpassword))
                    {
                        Console.WriteLine("login sucessfull");
                        IsLoggedIn = true;

                    }
                    else
                    {
                        Console.WriteLine("hehe abe jaa");
                        IsLoggedIn = false;
                    }


                }


                conn.Close();
            }
        }
    }
}
    

