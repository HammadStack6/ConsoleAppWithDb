using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWithDb
{

        class AddStudent
        {
            static string connectionString =
            "Server=INTERN-PC4\\MSSQLSERVER01;Database=ConsoleAppWithDb;Trusted_Connection=True;";

        public void AddStudentData()
            {
                Console.WriteLine("Add Student");

                Console.WriteLine("Enter Name:");
                string studentName = Console.ReadLine();

                Console.WriteLine("Enter Age:");
                int studentAge = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Course:");
                string studentCourse = Console.ReadLine();

                SqlConnection conn = new SqlConnection(connectionString);

                string query =
                "INSERT INTO student(Name, Age, Course) VALUES (@StudentName, @StudentAge, @StudentCourse)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@StudentName", studentName);
                cmd.Parameters.AddWithValue("@StudentAge", studentAge);
                cmd.Parameters.AddWithValue("@StudentCourse", studentCourse);

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();

                Console.WriteLine("Student Added Successfully");
            }
        }
    }