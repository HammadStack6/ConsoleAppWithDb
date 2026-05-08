using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWithDb
{
    class UpdateStudent
    {
        static string connectionString =
          "Server=INTERN-PC4\\MSSQLSERVER01;Database=ConsoleAppWithDb;Trusted_Connection=True;";

        public void Updatestudent()
        {
            Console.WriteLine("enter id you want to update");
            int currentId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter new name:");
            string newName = Console.ReadLine();

            Console.WriteLine("Enter new Age:");
            int newAge = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Enter new Course :");
            string newCourse = Console.ReadLine();




            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE student 
                 SET Name = @NewName,
                     Age = @newAge,
                     Course = @newCourse
                 WHERE Id = @CurrentId";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@currentId", currentId);
                cmd.Parameters.AddWithValue("@NewName", newName);
                cmd.Parameters.AddWithValue("@newAge", newAge);
                cmd.Parameters.AddWithValue("@newCourse", newCourse);
         
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                connection.Close();

                if (rows > 0)
                {
                    Console.WriteLine("Student updated successfully!");
                }
                else
                {
                    Console.WriteLine("No record found with that name.");
                }
            }
        }
    }
}