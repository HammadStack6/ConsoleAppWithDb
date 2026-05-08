using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleAppWithDb
{
    class Program
    {
        static void Main(string[] args)
        {

            AddStudent student = new AddStudent();
            UpdateStudent updateStudent = new UpdateStudent();
            DeleteStudent deleteStudent = new DeleteStudent();

            //testing connection
            string connectionString ="Server=INTERN-PC4\\MSSQLSERVER01;Database=ConsoleAppWithDb;Trusted_Connection=True;";
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                Console.WriteLine("Connection opened successfully!");
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }


            //current page 
            while (true)
            {
                Console.WriteLine("press 1 to add student");
                Console.WriteLine("press 2 to update Student ");
                Console.WriteLine("press 3 to delete Student");


                int num = Convert.ToInt32(Console.ReadLine());



                switch (num)
                {
                    case 1:

                        student.AddStudentData();
                        break;

                    case 2:
                        updateStudent.Updatestudent();
                        break;

                        case 3:
                        deleteStudent.delete();
                        break;


                    default:

                        Console.WriteLine("Invalid Option");
                        break;
                }


            }

        }
    }
}
