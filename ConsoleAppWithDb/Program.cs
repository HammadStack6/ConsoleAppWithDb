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
            Login login = new Login();
            Users user = new Users();   
            AddStudent student = new AddStudent();
            UpdateStudent updateStudent = new UpdateStudent();
            DeleteStudent deleteStudent = new DeleteStudent();
            View studentView = new View();


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


            Console.WriteLine("Press 1 to Login");
            Console.WriteLine("Press 2 to Signup");
            int appstart = Convert.ToInt32(Console.ReadLine());

            if (appstart == 1)
            {

                login.loginn();

            }

            else if (appstart == 2)
            {

                user.signup();
            }

                bool condition = login.IsLoggedIn;

                if (condition == false) {
                    Console.WriteLine("your password is in correct ");
                }

              
            

            //current page 
            while (condition)
            {
                Console.WriteLine("press 1 to add student and Deparment");
                Console.WriteLine("press 2 to update Student ");
                Console.WriteLine("press 3 to delete Student");
                Console.WriteLine("press 4 to view Student");



                int num = Convert.ToInt32(Console.ReadLine());



                switch (num)
                {
                    case 1:

                        student.AddStudentData();
                        student.AddDepartment();
                        break;

                    case 2:
                        updateStudent.Updatestudent();
                        break;

                        case 3:
                        deleteStudent.delete();
                        break;


                    case 4:
                        Console.WriteLine("to view all student Press 1");
                        Console.WriteLine("to view student with id  Press 2");

                        int selectview = Convert.ToInt32(Console.ReadLine());

                        if (selectview == 1)
                        {
                            studentView.ViewAllStudents();
                        }
                        else if (selectview == 2)
                        {
                            studentView.viewstudentWithDepartment();
                        }
                            break;


                    default:

                        Console.WriteLine("Invalid Option");
                        break;
                }


            }

        }
    }
}
