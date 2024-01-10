using System;
using System.Runtime.InteropServices;
using Newtonsoft.Json;


namespace Projet
{
    class Program
    {
            public static void Main()
        {
            MainMenu();
            Console.Clear();
        }

        public static void MainMenu()
        {
            bool exit = false;

            while (!exit) {
             Console.WriteLine(new string('=', 60));
            Console.WriteLine("                          MAIN MENU                           ");
            Console.WriteLine(new string('=', 60));

            Console.WriteLine("Options:");
            Console.WriteLine("  1. Login (ONLY USERS ACCESS)");
            Console.WriteLine("  2. Display Weekly Schedules For Students");
            Console.WriteLine("  3. The Calendar");
            Console.WriteLine("  4. Display Course Details");
            Console.WriteLine("  5. Manage Users");
            Console.WriteLine("  6. Manage Students");
            Console.WriteLine("  7. Manage Teachers");
            Console.WriteLine("  8. Manage Administrators");
            Console.WriteLine("  9. Manage Courses");
            Console.WriteLine(" 10. Manage Modules");
            Console.WriteLine(" 11. Logout");
            Console.WriteLine(" 12. Exit");

            Console.WriteLine(new string('-', 60));
            Console.Write("Enter your choice: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Login.LoginUser();
                            break;

                        case 2:
                            Administrator.ViewStudentSchedule();
                            break;

                        case 3:
                            Administrator.ViewCalendar();
                            break;

                        case 4:
                            if (Course.CoursePath != null)
                            {
                                Course.DisplayCourseDetails(Course.CoursePath);
                            }
                            else
                            {
                                Console.WriteLine("\nCourse path is null !\n");
                                Console.ResetColor();
                            }
                            break;

                        case 5:
                            User.ManageUsers();
                            break;

                        case 6:
                            Student.ManageStudents();
                            break;

                        case 7:
                            Teacher.ManageTeachers();
                            break;

                        case 8:
                            Administrator.ManageAdministration();
                            break;

                        case 9:
                            Course.ManageCourses();
                            break;

                        case 10: 
                            Module.ManageModules();
                            break;

                        case 11:
                            Login.LogoutUser(Login.CurrentUser);
                            break;

                        case 12:
                            exit = true;
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid choice ! Try again.\n");
                            break;
                            

                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("\nInvalid input ! Please enter a valid number.\n");
                }
                catch (OverflowException)
                {
                    Console.Clear();
                    Console.WriteLine("\nNumber too large! Please enter a valid number.\n");
                }
            }
        }
    }
}
