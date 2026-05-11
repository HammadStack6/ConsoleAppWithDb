using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWithDb
{
    class View
    {

        string connection = "Server=INTERN-PC4\\MSSQLSERVER01;Database=ConsoleAppWithDb;Trusted_Connection=True;";


        public void ViewAllStudents()
        {

            Console.WriteLine("current  registered Students");

            SqlConnection conn = new SqlConnection(connection);

            string query = "Select * from student";

            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();



            while(reader.Read())
            {

                Console.WriteLine(
                    $"ID: {reader["id"]} | " +
                    $"Name: {reader["Name"]} | " +
                    $"Age: {reader["Age"]} | " +
                    $"Course: {reader["Course"]}"
                );

            }
           conn.Close();
        }


        public void viewstudentWithDepartment()
        {
            Console.WriteLine("enter student id you want to see data for");

            int EnterIdForSearch = Convert.ToInt32(Console.ReadLine());

            SqlConnection conn = new SqlConnection(connection);

            string query = @"
            select 
                student.id,
                student.Name,
                student.Course,
                student.departmentId As fromStudenttable,
                department.departmentId As fromDepartmenttable,
                department.departmentName
            from student
            inner join department
            on student.departmentId = department.departmentId
            where student.id = @EnterIdForSearch";

            using (SqlCommand cmd = new SqlCommand(query, conn)) {

                cmd.Parameters.AddWithValue("@EnterIdForSearch", EnterIdForSearch);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    Console.WriteLine(
          $"ID: {reader["id"]} | " +
          $"Name: {reader["Name"]} | " +
          $"Course: {reader["Course"]} | " +
          $"Student Dept ID: {reader["fromStudenttable"]} | " +
          $"Department Dept ID: {reader["fromDepartmenttable"]} | " +
          $"Department Name: {reader["departmentName"]}"
      );
                }
            conn.Close();
            }

        }
    }
}
