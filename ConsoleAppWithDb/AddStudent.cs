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

            Console.WriteLine("Enter department id:");
            int StudentdepartmentId = Convert.ToInt32(Console.ReadLine());

            SqlConnection checkConn = new SqlConnection(connectionString);

            string checkQuery = "SELECT COUNT(*) FROM department WHERE departmentId = @id";

            SqlCommand checkCmd = new SqlCommand(checkQuery, checkConn);

            checkCmd.Parameters.AddWithValue("@id", StudentdepartmentId);

            checkConn.Open();

            int count = (int)checkCmd.ExecuteScalar();

            checkConn.Close();

            if (count == 0)
            {
                Console.WriteLine("Invalid Department ID");
                return;
            }

            SqlConnection conn = new SqlConnection(connectionString);

                string query =
                "INSERT INTO student(Name, Age, Course, departmentId) VALUES (@StudentName, @StudentAge, @StudentCourse, @StudentdepartmentId)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@StudentName", studentName);
                cmd.Parameters.AddWithValue("@StudentAge", studentAge);
                cmd.Parameters.AddWithValue("@StudentCourse", studentCourse);
                cmd.Parameters.AddWithValue("@StudentdepartmentId", StudentdepartmentId);

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();

                Console.WriteLine("Student Added Successfully");
            }

        public void AddDepartment()
        {
            Console.WriteLine("Add department name:");
            string DepartmentName = Console.ReadLine();

            SqlConnection connn = new SqlConnection(connectionString);

            string Departmentquery =
            "INSERT INTO department(departmentName) VALUES (@DepartmentName)";

            SqlCommand cmddepartment = new SqlCommand(Departmentquery, connn);

            cmddepartment.Parameters.AddWithValue("@DepartmentName", DepartmentName);

            connn.Open();

            cmddepartment.ExecuteNonQuery();

            connn.Close();

            Console.WriteLine("Department Added Successfully");
        }



     

    }
    }