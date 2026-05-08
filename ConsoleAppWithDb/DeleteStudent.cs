using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWithDb
{
    class DeleteStudent
    {

        string connection = "Server=INTERN-PC4\\MSSQLSERVER01;Database=ConsoleAppWithDb;Trusted_Connection=True;";

        public void delete()
        {
            Console.WriteLine("ENTER STUDENT ID YOU WANT TO DELETE");

            int currentId = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection conn = new SqlConnection(connection))
            {
                string query = "DELETE FROM student WHERE id = @currentId";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@currentId", currentId);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                conn.Close();

                if (rows > 0)
                {
                    Console.WriteLine("Student deleted successfully!");
                }
                else
                {
                    Console.WriteLine("No student found with that ID.");
                }
            }
        }
    }
}
