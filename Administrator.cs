using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.SymbolStore;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Newtonsoft.Json;
using System.Data.Common;

namespace Projet
{
    class Administrator : Person 
    {
        public string Grade { get; set; }
        public string? ClassName { get; set; }
        public string? ModuleName { get; set; }
        public string? CourseName { get; set; }
        public DateTime UpcomingCourseDebutTime { get; set; }
        public DateTime UpComingCourseEndTime { get; set; }
        public DateTime ExamDate { get; set; }
        public DateTime ProjectDeadLine { get; set; }
        public string? CourseTeacherName { get; set; }
        public DateTime StudentPerformanceReportDate { get; set; }
        public string? StudentPerformanceReportText { get; set; }
        public DateTime TeacherPerformanceReportDate { get; set; }
        public string? TeacherPerformanceReportText { get; set; }
        public static string? SymLanguageType { get; private set; }

        public static List<string> weekDays = new() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        public static List<string>? WeeklyTeacherSchedule { get; set; }
        public static List<string>? WeeklyStudentSchedule { get; set; }
        public static List<Administrator> administrators = new();
        public static List<Administrator> examsDatesAndDeadlines = new();
        public static List<Administrator> upcomingModulesAndCourses = new();
        public static List<Administrator> studentPerformanceReportsList = new();
        public static List<Administrator> teacherPerformanceReportsList = new();

        public Administrator(string firstName, string lastName, string gender, int id, int phoneNumber, string email, string address, DateTime dateOfBirth, string nationality, string grade, string? className, string? moduleName, string? courseName, DateTime upComingDebutTime, DateTime upComingEndTime, DateTime examDate, DateTime projectDeadline, string courseTeacherName, DateTime studentPerformanceReportDate, string? studentPerformanceReportText, DateTime teacherPerformanceReportDate, string? teacherPerformanceReportText) : base(firstName, lastName, gender, id, phoneNumber, email, address, dateOfBirth, nationality)
        {
            Grade = grade;
            ClassName = className;
            ModuleName = moduleName;
            CourseName = courseName;
            UpcomingCourseDebutTime = upComingDebutTime;
            UpComingCourseEndTime = upComingEndTime;
            ExamDate = examDate;
            ProjectDeadLine = projectDeadline;
            CourseTeacherName = courseTeacherName;
            StudentPerformanceReportDate = studentPerformanceReportDate;
            StudentPerformanceReportText = studentPerformanceReportText;
            TeacherPerformanceReportDate = teacherPerformanceReportDate;
            TeacherPerformanceReportText = teacherPerformanceReportText;
        }

        public static void ManageAdministration()
        {
            do
            {
                
                Console.WriteLine("\n==================================================\n");
                Console.WriteLine("                 Manage Administration");
                Console.WriteLine("\n==================================================\n");
                Console.WriteLine("1. Manage Students < ONLY ADMIN ACCESS ! >\n");
                Console.WriteLine("2. Manage Teachers < ONLY ADMIN ACCESS ! >\n");
                Console.WriteLine("3. Manage Modules < ONLY ADMIN ACCESS ! >\n");
                Console.WriteLine("4. Manage Courses < ONLY ADMIN ACCESS ! >\n");
                Console.WriteLine("5. Manage Admininstrator < ONLY ADMIN ACCESS ! >\n");
                Console.WriteLine("6. Calendar and Schedule < ONLY ADMIN ACCESS ! >\n");
                Console.WriteLine("7. Generate Reports < ONLY ADMIN ACCESS ! >\n");
                Console.WriteLine("8. System Settings < ONLY ADMIN ACCESS ! >\n");
                Console.WriteLine("9. Back to main menu\n");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");

                switch (choice)
                {
                    case 1:
                        Student.ManageStudents();
                        break;

                    case 2:
                        Teacher.ManageTeachers();
                        break;

                    case 3:
                        Module.ManageModules();
                        break;

                    case 4:
                        Course.ManageCourses();
                        break;

                    case 5:
                        ManageAdministrator();
                        break;

                    case 6:
                        CalendarAndSchedule();
                        break;

                    case 7:
                        GenerateReports();
                        break;

                    case 8:
                        SystemSettings();
                        break;

                    case 9:
                        Program.MainMenu();
                        break; 

                    default:
                        Console.WriteLine("Invalid choice. Try again.\n");
                        break;
                }
                
            } while (true); 
        }

        private static void ManageAdministrator()
        {
            do
            {
                
                Console.WriteLine("******************************************************\n");
                Console.WriteLine("              Administrator Management System          ");
                Console.WriteLine("\n****************************************************\n");
                Console.WriteLine("1. Add Administrator\n");
                Console.WriteLine("2. Display Administrator Details\n");
                Console.WriteLine("3. View Administrators List\n");
                Console.WriteLine("4. Update Administrator\n");
                Console.WriteLine("5. Delete Administrator\n");
                Console.WriteLine("6. Back to Admin Menu\n");
                ;
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        AddAdministrator();
                        break;

                    case 2:
                        DisplayAdministratorDetails();
                        break;

                    case 3:
                        ViewAdministratorsList();
                        break;

                    case 4:
                        UpdateAdministrator();
                        break;

                    case 5:
                        DeleteAdministrator();
                        break;

                    case 6:
                        return; 

                    default:
                        
                        Console.WriteLine("Invalid choice. Try again.\n");
                        ;
                        break;
                }

            } while (true); 
        }

        private static void AddAdministrator()
        {
            
            Console.WriteLine("*****************************************\n");
            Console.WriteLine("            Add Administrator             ");
            Console.WriteLine("\n****************************************\n");
            Console.Write("Enter Administrator First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("");
            Console.Write("Enter Administrator Last Name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Administrtor Gender : ");
                        string gender = Console.ReadLine();
                        Console.Write("");
            Console.Write("Enter Administrator ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("");
            Console.Write("Enter Administrator Phone Number: ");
            int phoneNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("");
            Console.Write("Enter Administrator Email: ");
            string email = Console.ReadLine();
            Console.Write("");
            Console.Write("Enter Administrator Address: ");
            string address = Console.ReadLine();
            Console.Write("");
            Console.Write("Enter Administrator Birth Date: ");
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.Write("");
            Console.Write("Enter Administrator Nationality: ");
                        string nationality = Console.ReadLine();
                        Console.Write("");
            Console.WriteLine("Enter Administrator Grade: ");
                        string grade = Console.ReadLine();
            Administrator newAdmin = new(firstName, lastName, gender, id, phoneNumber, email, address, dateOfBirth, nationality, grade, null, null, null, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, null, DateTime.Now, null, DateTime.Now, null);
            administrators.Add(newAdmin);
            
            Console.WriteLine("Administrator added successfully !");
            ;
            Console.WriteLine(""); 
            SaveAdministratorsToJson();
            Console.WriteLine("");
        }

        private static void DisplayAdministratorDetails()
        {
            
            Console.WriteLine("*****************************************\n");
            Console.WriteLine("            View Administrator Details            ");
            Console.WriteLine("\n****************************************\n");
            Console.Write("Enter Administrator ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            LoadAdminsFromJson();
            Console.WriteLine("");
            Administrator adminToDislayDetails = administrators.Find(admin => admin.Id == id);
            if (adminToDislayDetails != null)
            {
                
                Console.WriteLine($"Administrator  ID: {adminToDislayDetails.Id} \t Administrator Full Name: {adminToDislayDetails.FirstName + " "} {adminToDislayDetails.LastName} \t  Administrator Gender : {adminToDislayDetails.Gender} \t Administrator Email : {adminToDislayDetails.Email} \t Admininstrator Phone Number : {adminToDislayDetails.PhoneNumber} \t Administrator Address : {adminToDislayDetails.Address} \t Admininstrator Birth Date : {adminToDislayDetails.DateOfBirth} \t AddAdministrator Nationality : {adminToDislayDetails.Nationality} \t Administrator Grade : {adminToDislayDetails.Grade}");
                ;
            }
            else
            {
                
                Console.WriteLine("Administrator not found.\n");
                ;
            }
        }

        private static void ViewAdministratorsList()
        {
            
            Console.WriteLine("**********************************************\n");
            Console.WriteLine("            View Administrators List            ");
            Console.WriteLine("\n*********************************************\n");
            ;
            LoadAdminsFromJson();
            Console.WriteLine("");
            foreach (var admin in administrators)
            {
                if (administrators.Count == 0)
                {
                    
                    Console.WriteLine("No administrators found !");
                    ;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Administrator N`{0} ", administrators.IndexOf(admin) + 1);
                    Console.WriteLine($"Administrator ID : {admin.Id} \t Administrator Full Name : {admin.FirstName + " "} {admin.LastName}");
                    ;

                }
            }
        }

        private static void UpdateAdministrator()
        {
            
            Console.WriteLine("*****************************************\n");
            Console.WriteLine("            Update Administrator             ");
            Console.WriteLine("\n****************************************\n");
            Console.Write("Enter Administrator ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");
            Administrator adminToUpdate = administrators.Find(admin => admin.Id == id);
            if (adminToUpdate != null)
            {
                Console.Write("Enter New Administrator First Name: ");
                string firstName = Console.ReadLine();
                Console.Write("");
                Console.Write("Enter New Administrator Last Name: ");
                string lastName = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("Enter New Administrator Gender : ");
                string gender = Console.ReadLine();
                Console.Write("");
                Console.Write("Enter New Administrator ID: ");
                int newId = Convert.ToInt32(Console.ReadLine());
                Console.Write("");
                Console.Write("Enter New Administrator Phone Number: ");
                int phoneNumber = Convert.ToInt32(Console.ReadLine());
                Console.Write("");
                Console.Write("Enter New Administrator Email: ");
                string email = Console.ReadLine();
                Console.Write("");
                Console.Write("Enter New Administrator Address: ");
                string address = Console.ReadLine();
                Console.Write("");
                Console.Write("Enter New Administrator Date of Birth: ");
                DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
                Console.Write("");
                Console.WriteLine("Enter New Administrator Nationality: ");
                string nationality = Console.ReadLine();
                Console.Write("");
                Console.WriteLine("Enter New Administrator Grade: ");
                string grade = Console.ReadLine();
                adminToUpdate.FirstName = firstName;
                adminToUpdate.LastName = lastName;
                adminToUpdate.Gender = gender;
                adminToUpdate.Id = newId;
                adminToUpdate.PhoneNumber = phoneNumber;
                adminToUpdate.Email = email;
                adminToUpdate.Address = address;
                adminToUpdate.DateOfBirth = dateOfBirth;
                adminToUpdate.Nationality = nationality;
                adminToUpdate.Grade = grade;
                administrators.Add(adminToUpdate); 
                
                Console.WriteLine("Administrator updated successfully !");
                ;
                Console.WriteLine("");
                SaveAdministratorsToJson();
                Console.WriteLine("");
            }
            else
            {
                
                Console.WriteLine("Administrator not found.\n");
                ;
            }
        }

        private static void DeleteAdministrator()
        {
            
            Console.WriteLine("*****************************************\n");
            Console.WriteLine("            Delete Administrator             ");
            Console.WriteLine("\n****************************************\n");
            Console.Write("Enter Administrator ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");
            Administrator adminToDelete = administrators.Find(admin => admin.Id == id);
            if (adminToDelete != null)
            {
                administrators.Remove(adminToDelete);
                
                Console.WriteLine("Administrator deleted successfully !");
                ;
                Console.WriteLine("");
                SaveAdministratorsToJson();
                Console.WriteLine("");
            }
            else
            {
                
                Console.WriteLine("Administrator not found.\n");
                ;
            }
        }
        
        private static void CalendarAndSchedule()
        {
            do
            {
                
                Console.WriteLine("*****************************************\n");
                Console.WriteLine("            Calendar and Schedule           ");
                Console.WriteLine("\n****************************************\n");
                Console.WriteLine("1. Manage Calendar < ONLY ADMIN ACCESS ! >\n");
                Console.WriteLine("2. Manage Weekly Schedule < ONLY ADMIN ACCESS ! >\n");
                Console.WriteLine("3. View Weekly Schedule\n"); 
                Console.WriteLine("4. View Calendar\n"); 
                Console.WriteLine("5. Back to Admin Menu\n");
                ;
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        ManageCalender();
                        break;

                    case 2:
                        ManageWeeklySchedule();
                        break;

                    case 3:
                        ViewSchedule();
                        break;

                    case 4:
                        ViewCalendar();
                        break;

                    case 5:
                        ManageAdministration();
                        break;

                    default:
                        
                        Console.WriteLine("Invalid choice. Try again.\n");
                        ;
                        break;
                }

            } while (true); 
        }

        private static void ManageWeeklySchedule()
        {
            do
            {
                
                Console.WriteLine("*****************************************\n");
                Console.WriteLine("            Manage Weekly Schedule             ");
                Console.WriteLine("\n****************************************\n");
                Console.WriteLine("1. Manage Weekly Students Schedule\n");
                Console.WriteLine("2. Manage Weekly Teachers Schedule\n");
                Console.WriteLine("3. Back To Calendar and Schedule Menu\n");
                ;
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        ManageStudentSchedule();
                        break;

                    case 2:
                        ManageTeacherSchedule();
                        break;

                    case 3:
                        CalendarAndSchedule(); 
                        break;

                    default:
                        
                        Console.WriteLine("Invalid choice. Try again.\n");
                        ;
                        break;
                }

            } while (true); 
        }

        private static void ManageStudentSchedule()
        {
            
            Console.WriteLine("*****************************************************\n");
            Console.WriteLine("            Manage Weekly Students Schedule             ");
            Console.WriteLine("\n*****************************************************\n");
            Console.WriteLine("Enter Weekly Students Schedule Class: ");
            string className = Console.ReadLine();
            Console.WriteLine("");
            foreach (var day in weekDays)
            {
                
                Console.WriteLine($"Enter Weekly Students Schedule Details for {day}: ");
                Console.WriteLine("");
                Console.WriteLine("Enter Weekly Students Schedule Module: ");  
                    string moduleName = Console.ReadLine();
                    Console.WriteLine("");
                Console.WriteLine("Enter Weekly Students Schedule Course: ");
                                string courseName = Console.ReadLine();
                                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Enter Weekly Students Schedule Debut Time: ");
                _ = DateTime.TryParse(Console.ReadLine(), out DateTime debutTime);
                Console.WriteLine("");
                Console.WriteLine("Enter Weekly Students Schedule End Time: ");
                _ = DateTime.TryParse(Console.ReadLine(), out DateTime endTime);
                Console.WriteLine("");
                Console.WriteLine("Enter Weekly Students Schedule Teacher: ");
                                string teacher = Console.ReadLine();
                                Console.WriteLine("");
                Console.WriteLine("Enter Weekly Students Schedule ClassRoom: ");
                                string classRoom = Console.ReadLine();
                                Console.WriteLine("");
                WeeklyStudentSchedule.Add($"{day}: {moduleName} {courseName} {debutTime} {endTime} {teacher} {classRoom}");
                ;
            }
            WeeklyStudentSchedule.Add(className);
            
            Console.WriteLine("\nWeekly Students Schedule Added Successfully!\n");
            SaveStudentWeeklyScheduleToJson();
            ;
        }

        private static void ManageTeacherSchedule()
        {
            
            Console.WriteLine("*****************************************************\n");
            Console.WriteLine("            Manage Weekly Teachers Schedule             ");
            Console.WriteLine("\n*****************************************************\n");
            Console.WriteLine("Enter Weekly Teachers Schedule Class: ");
            string className = Console.ReadLine();
            Console.WriteLine("");
            foreach (var day in weekDays)
            {
                
                Console.WriteLine($"Enter Weekly Teachers Schedule Details for {day}: ");
                Console.WriteLine("");
                Console.WriteLine("Enter Weekly Teachers Schedule Module: ");
                                string moduleName = Console.ReadLine();
                                Console.WriteLine("");
                Console.WriteLine("Enter Weekly Teachers Schedule Course: ");
                                string courseName = Console.ReadLine();
                                Console.WriteLine("");
                Console.WriteLine("Enter Weekly Teachers Schedule Debut Time: ");
                _ = DateTime.TryParse(Console.ReadLine(), out DateTime debutTime);
                Console.WriteLine("");
                Console.WriteLine("Enter Weekly Teachers Schedule End Time: ");
                _ = DateTime.TryParse(Console.ReadLine(), out DateTime endTime);
                Console.WriteLine("");
                Console.WriteLine("Enter Weekly Teachers Schedule Teacher: ");
                                string teacher = Console.ReadLine();
                                Console.WriteLine("");
                Console.WriteLine("Enter Weekly Teachers Schedule ClassRoom: ");
                                string ClassRoom = Console.ReadLine();
                                Console.WriteLine("");
                WeeklyTeacherSchedule.Add($"{day}: {moduleName} {courseName} {debutTime} {endTime} {teacher} {ClassRoom}");
                ;
            }
            WeeklyTeacherSchedule.Add(className);
            
            Console.WriteLine("");
            Console.WriteLine("Weekly Teachers Schedule Added Successfully !");
            SaveTeacherWeeklyScheduleToJson();
            ;
        }

        public static void ViewSchedule()
        {
            do
            {
                
                Console.WriteLine("*****************************************\n");
                Console.WriteLine("            View  Weekly Schedule             ");
                Console.WriteLine("\n****************************************\n");
                Console.WriteLine("1. View Weekly Students Schedule\n");
                Console.WriteLine("2. View Weekly Teachers Schedule\n");
                Console.WriteLine("3. Back To Calendar and Schedule Menu\n");
                ;
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        ViewStudentSchedule();
                        break;

                    case 2:
                        ViewTeacherSchedule();
                        break;

                    case 3:
                        CalendarAndSchedule(); 
                        break;

                    default:
                        
                        Console.WriteLine("Invalid choice. Try again.\n");
                        ;
                        break;
                }

            } while (true); 
        }

        public static void ViewStudentSchedule()
        {
            
            Console.WriteLine("*****************************************\n");
            Console.WriteLine("         View Weekly Student Schedule       ");
            Console.WriteLine("\n***************************************\n");
            Console.Write("Enter student Class: ");
            string cclass = Console.ReadLine();
            Console.WriteLine("");
            LoadStudentWeeklyScheduleFromJson();
            Student student = Student.students.Find(s => s.Class == cclass);
            List<string> weeklySchedule = WeeklyStudentSchedule;

            if (weeklySchedule != null && weeklySchedule.Count > 0)
            {
                    
                Console.WriteLine($"Students Class: {student.Class}\n");
                Console.WriteLine("\nWeekly Schedule:\n");

                    foreach (var daySchedule in weeklySchedule)
                    {
                        Console.WriteLine(daySchedule);
                    }
                ;
                Console.WriteLine("");
            }
            else
            {
                
                Console.WriteLine("No schedule available for this Class.\n");
                ;
            }
        }

         public static void ViewTeacherSchedule()
        {
            
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("          View weekly Teacher Schedule:              ");
            Console.WriteLine("\n************************************************\n");
            ;
            Console.Write("Enter teacher ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            // Upload Teachers from the json file
            LoadTeacherWeeklyScheduleFromJson();
            Teacher teacherToView = Teacher.teachers.Find(t => t.Id == id);
            List<string> weeklySchedule = WeeklyTeacherSchedule;
            if (weeklySchedule != null && weeklySchedule.Count > 0)
            {
                
                Console.WriteLine($"Teacher Full Name: {teacherToView.FirstName} {teacherToView.LastName}\n");
                Console.WriteLine("Weekly Schedule: ");
                foreach (var daySchedule in weeklySchedule)
                {
                    Console.WriteLine(daySchedule);
                }
                ;
                Console.WriteLine("\n");
            }
            else
            {
                
                Console.WriteLine("No schedule available for this teacher.");
                ;
            }
        }

        public static void ViewCalendar()
        {
            do
            {
                
                Console.WriteLine("\n*****************************************\n");
                Console.WriteLine("            View Calendar             ");
                Console.WriteLine("\n****************************************\n");
                Console.WriteLine("1. View Exam Dates and Deadlines\n");
                Console.WriteLine("2. View Upcoming Modules and Courses\n");
                Console.WriteLine("3. Back To Calendar and Schedule Menu\n");
                ;
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        ViewExamDatesAndDeadlines();
                        break;

                    case 2:
                        ViewUpcomingModulesAndCourses();
                        break;

                    case 3:
                        CalendarAndSchedule(); 
                        break;

                    default:
                        
                        Console.WriteLine("Invalid choice. Try again.\n");
                        ;
                        break;
                }

            } while (true); 
        }

        private static void ManageCalender()
        {
            do
            {
                
                Console.WriteLine("*****************************************\n");
                Console.WriteLine("            Manage Calendar             ");
                Console.WriteLine("\n****************************************\n");
                Console.WriteLine("1. Manage Exam Dates and Deadlines\n");
                Console.WriteLine("2. Manage Upcoming Modules and Courses\n");
                Console.WriteLine("3. Back To Calendar and Schedule Menu\n");
                ;
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        ManageExamDatesAndDeadlines();
                        break;

                    case 2:
                        ManageUpcomingModulesAndCourses();
                        break;

                    case 3:
                        CalendarAndSchedule();
                        break;

                    default:
                        
                        Console.WriteLine("Invalid choice. Try again.\n");
                        ;
                        break;
                }

            } while (true);
        }

        private static void ManageExamDatesAndDeadlines()
        {
            
            Console.WriteLine("*****************************************************\n");
            Console.WriteLine("               Manage Exam Dates and Deadlines          ");
            Console.WriteLine("\n****************************************************\n");
            Console.Write("Enter Class Name: ");
            string className = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Enter Module Name: ");
            string moduleName = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Enter Course Name: ");
                        string courseName = Console.ReadLine();
                        Console.WriteLine("");
            Console.Write("Enter Exam Date: ");
            DateTime examDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("");
            Console.Write("Enter Project Deadline: ");
            DateTime projectDeadline = Convert.ToDateTime(Console.ReadLine());
            examsDatesAndDeadlines.Add(new Administrator(null, null, null, 0, 0, null, null, DateTime.Now, null, null, className, moduleName, courseName, DateTime.Now, DateTime.Now, examDate, projectDeadline, null, DateTime.Now, null, DateTime.Now, null));
            
            Console.WriteLine("");
            Console.WriteLine("Exam Date and Deadline added successfully !");
            SaveExamsDatesAndDeadlinesToJson();
            ;
        }

        private static void ManageUpcomingModulesAndCourses()
        {
            
            Console.WriteLine("*****************************************************\n");
            Console.WriteLine("            View Upcoming Modules and Courses          ");
            Console.WriteLine("\n***************************************************\n");
            Console.WriteLine("Enter Class Name: ");
            string className = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Enter Upcoming Module Name: ");
            string upcomingModuleName = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Enter Upcoming Course Name: ");
                        string upcomingCourseName = Console.ReadLine();
                        Console.WriteLine("");
            Console.WriteLine("Enter Upcoming Course Debut Date: ");
            DateTime upcomingCourseDebutDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Enter Upcoming Course End Date: ");
            DateTime upcomingCourseEndDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Enter Course Teacher Name: ");
                        string courseTeacherName = Console.ReadLine();
            upcomingModulesAndCourses.Add(new Administrator(null, null, null, 0, 0, null, null, DateTime.Now, null, null, className, upcomingModuleName, upcomingCourseName, upcomingCourseDebutDate, upcomingCourseEndDate, DateTime.Now, DateTime.Now, courseTeacherName, DateTime.Now, null, DateTime.Now, null));
            
            Console.WriteLine("");
            Console.WriteLine("Upcoming Module and Course added successfully !");
            SaveUpcomingModulesAndCoursesToJson();
            ;
        }
            

        public static void ViewExamDatesAndDeadlines()
        {
            
            Console.WriteLine("******************************************\n");
            Console.WriteLine("        View Exam Dates and Deadlines       ");
            Console.WriteLine("\n****************************************\n");
            ;
            Console.Write("Enter Class Name: ");
            string className = Console.ReadLine();
            LoadExamsDatesAndDeadlinesFromJson();
            Administrator examDateToView = examsDatesAndDeadlines.Find(examDate => examDate.ClassName == className);
            if (examDateToView != null)
            {
                
                Console.WriteLine("Class Name: " + examDateToView.ClassName);
                Console.WriteLine("Module Name: " + examDateToView.ModuleName);
                Console.WriteLine("Course Name: " + examDateToView.CourseName);
                Console.WriteLine("Exam Date: " + examDateToView.ExamDate);
                Console.WriteLine("Project Deadline: " + examDateToView.ProjectDeadLine + "\n");
                ;
            }
            else
            {
                
                Console.WriteLine("Exam Date and Deadline not found !\n");
                ;
            }
        }

        public static void ViewUpcomingModulesAndCourses()
        {
            
            Console.WriteLine("**********************************************\n");
            Console.WriteLine("        View Upcoming Modules and Courses       ");
            Console.WriteLine("\n********************************************\n");
            ;
            Console.Write("Enter Class Name: ");
            string className = Console.ReadLine();
            LoadUpcomingModulesAndCoursesFromJson();
            Administrator upcomingModuleAndCourseToView = upcomingModulesAndCourses.Find(upcomingModuleAndCourse => upcomingModuleAndCourse.ClassName == className);
            if (upcomingModuleAndCourseToView != null)
            {
                
                Console.WriteLine("Class Name: " + upcomingModuleAndCourseToView.ClassName);
                Console.WriteLine("Upcoming Module Name: " + upcomingModuleAndCourseToView.ModuleName);
                Console.WriteLine("Upcoming Course Name: " + upcomingModuleAndCourseToView.CourseName);
                Console.WriteLine("Upcoming Course Debut Date: " + upcomingModuleAndCourseToView.UpcomingCourseDebutTime);
                Console.WriteLine("Upcoming Course End Date: " + upcomingModuleAndCourseToView.UpComingCourseEndTime);
                Console.WriteLine("Course Teacher Name: " + upcomingModuleAndCourseToView.CourseTeacherName + "\n");
                ;
            }
            else
            {
                
                Console.WriteLine("Upcoming Module and Course not found !\n");
                ;
            }
        }


        private static void GenerateReports()
        {
            do
            {
                
                Console.WriteLine("*****************************************\n");
                Console.WriteLine("            Generate Reports             ");
                Console.WriteLine("\n****************************************\n");
                Console.WriteLine("1. Generate Student Performance Report\n");
                Console.WriteLine("2. Generate Teacher Performance Report\n");
                Console.WriteLine("3. Back to Admin Menu\n");
                ;
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        StudentPerformanceReport();
                        break;

                    case 2:
                        TeacherPerformanceReport();
                        break;

                    case 3:
                        ManageAdministration(); 
                        break;

                    default:
                        
                        Console.WriteLine("Invalid choice. Try again.\n");
                        ;
                        break;
                }

            } while (true);
        }

        private static void StudentPerformanceReport()                                                          
        {
            do
            {
                
                Console.WriteLine("**********************************************************\n");
                Console.WriteLine("            Student Performance Report             ");
                Console.WriteLine("\n**********************************************************\n");
                Console.WriteLine("1. View Students List\n");
                Console.WriteLine("2. Generate Student Performance Report\n");
                Console.WriteLine("3. Dispay Student Performance Report\n");
                Console.WriteLine("4. Back to Generate Report Menu\n");
                ;
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Student.ViewStudents();
                        break;

                    case 2:
                        GenerateStudentPerformanceReport();
                        break;

                    case 3:
                        ViewStudentPerformanceReport();
                        break;

                    case 4:
                        GenerateReports(); 
                        break;

                    default:
                        
                        Console.WriteLine("Invalid choice. Try again.\n");
                        ;
                        break;
                }

            } while (true); 
        }

        
        private static void GenerateStudentPerformanceReport()
        {
            
            Console.WriteLine("**********************************************************\n");
            Console.WriteLine("            Generate Student Performance Report             ");
            Console.WriteLine("\n********************************************************\n");
            ;
            Console.WriteLine("Enter Student ID: ");
            int studentID = Convert.ToInt32(Console.ReadLine());
            Student student = Student.students.Find(student => student.Id == studentID);
            if (student != null)
            {
                
                Console.WriteLine("Student Full Name: " + student.FirstName + " " + student.LastName + "Registred in : " + student.Class + "\n");
                ;
                Console.Write("Enter The Student Performance Report Date: ");
                DateTime studentPerformanceReportDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("");
                Console.WriteLine("Enter The Student Performance Report: ");
                Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
                string studentPerformanceReportText = Console.ReadLine();
                Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
#pragma warning disable CS8625 
                studentPerformanceReportsList.Add(new Administrator(null, null, null, 0, 0, null, null, DateTime.Now, null, null, null, null, null, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, null, studentPerformanceReportDate, studentPerformanceReportText, DateTime.Now, null));
#pragma warning restore CS8625 
                
                Console.WriteLine("\nStudent Performance Report added successfully !");
                SaveStudentPerformanceReportsToJson();
                ;
            }
            else
            {
                
                Console.WriteLine("Student not found!\n");
                ;
                
            }
        }

        private static void ViewStudentPerformanceReport()
        {
            
            Console.WriteLine("**********************************************************\n");
            Console.WriteLine("            View Student Performance Report             ");
            Console.WriteLine("\n********************************************************\n");
            ;
            Console.Write("Enter Student ID: ");
            int studentID = Convert.ToInt32(Console.ReadLine());
            LoadStudentPerformanceReportsFromJson();
            Student student = Student.students.Find(student => student.Id == studentID);
            if (student != null)
            {
                foreach (var studentPerformanceReport in studentPerformanceReportsList)
                {
                    
                    Console.WriteLine("Student Full Name: " + student.FirstName + " " + student.LastName + "Registred in : " + student.Class + "\n");
                    Console.WriteLine("Student Performance Report: " + studentPerformanceReport + "\n");
                    ;
                }
            }
            else
            {
                
                Console.WriteLine("Student not found!\n");
                ;
            }
        }

        private static void TeacherPerformanceReport()             
        {
            do 
            {
                
                Console.WriteLine("**********************************************************\n");
                Console.WriteLine("            Teacher Performance Report             ");
                Console.WriteLine("\n**********************************************************\n");
                Console.WriteLine("1. View Teachers List\n");
                Console.WriteLine("2. Generate Teacher Performance Report\n");
                Console.WriteLine("3. Dispay Teacher Performance Report\n");
                Console.WriteLine("4. Back to Generate Report Menu\n");
                ;
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Teacher.ViewTeachers();
                        break;

                    case 2:
                        GenerateTeacherPerformanceReport();
                        break;

                    case 3:
                        ViewTeacherPerformanceReport();
                        break;

                    case 4:
                        GenerateReports();  
                        break; 

                    default:
                        
                        Console.WriteLine("Invalid choice. Try again.\n");
                        ;
                        break;
                }

            } while (true); 
        }

        private static void GenerateTeacherPerformanceReport()
        {
            
            Console.WriteLine("**********************************************************\n");
            Console.WriteLine("            Generate Teacher Performance Report             ");
            Console.WriteLine("\n********************************************************\n");
            ;
            Console.Write("Enter Teacher ID: ");
            int teacherID = Convert.ToInt32(Console.ReadLine());
            Teacher teacher = Teacher.teachers.Find(teacher => teacher.Id == teacherID);
            if (teacher != null)
            {
                
                Console.WriteLine("Teacher Full Name: " + teacher.FirstName + " " + teacher.LastName + "Course Assigned : " + teacher.AssignedCourse + "\n");
                ;
                Console.WriteLine("Enter The Teacher Performance Report Date: ");
                DateTime teacherPerformanceReportDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("");
                Console.WriteLine("Enter The Teacher Performance Report: ");
                Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
                string teacherPerformanceReportText = Console.ReadLine();
                Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
                teacherPerformanceReportsList.Add(new Administrator(null, null, null, 0, 0, null, null, DateTime.Now, null, null, null, null, null, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, null, DateTime.Now, null, teacherPerformanceReportDate, teacherPerformanceReportText));
                
                Console.WriteLine("\nTeacher Performance Report added successfully !");
                // Save Teacher Performance Report to the json file
                SaveTeacherPerformanceReportsToJson();
                ;
            }
            else
            {
                
                Console.WriteLine("Teacher not found!\n");
                ;
            }
        }

        private static void ViewTeacherPerformanceReport()
        {
            
            Console.WriteLine("**********************************************************\n");
            Console.WriteLine("            View Teacher Performance Report             ");
            Console.WriteLine("\n********************************************************\n");
            ;
            Console.Write("Enter Teacher ID: ");
            int teacherID = Convert.ToInt32(Console.ReadLine());
            // Upload Teacher Performance Reports from the json file
            LoadTeacherPerformanceReportsFromJson();
            Teacher teacher = Teacher.teachers.Find(teacher => teacher.Id == teacherID);
            if (teacher != null)
            {
                foreach (var teacherPerformanceReport in teacherPerformanceReportsList)
                {
                    
                    Console.WriteLine("Teacher Full Name: " + teacher.FirstName + " " + teacher.LastName + "Course Assigned : " + teacher.AssignedCourse + "\n");
                    Console.WriteLine("Teacher Performance Report: " + teacherPerformanceReport + "\n");
                    ;
                }
            }
            else
            {
                
                Console.WriteLine("Teacher not found!\n");
                ;
            }
        }

        private static void SystemSettings()
        {
            do
            {
                
                Console.WriteLine("*****************************************\n");
                Console.WriteLine("              System Settings                ");
                Console.WriteLine("\n****************************************\n");
                Console.WriteLine("1. Configure System Parameters\n");
                Console.WriteLine("2. Configure Email Notifications\n");
                Console.WriteLine("3. Back to Admin Menu\n");
                ;
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        ConfigureSystemParameters();
                        break;

                    case 2:
                        ConfigureEmailNotifications();
                        break;

                    case 3:
                        ManageAdministration(); 
                        break;

                    default:
                        
                        Console.WriteLine("Invalid choice. Try again.\n");
                        ;
                        break;
                }

            } while (true);
        }

        private static void ConfigureSystemParameters()
        {
            do
            {
                
                Console.WriteLine("**************************************************\n");
                Console.WriteLine("            Configure System Parameters             ");
                Console.WriteLine("\n************************************************\n");
                Console.WriteLine("1. Configure System Language\n");
                Console.WriteLine("2. Configure System Time Zone\n");
                Console.WriteLine("3. Back to System Settings Menu\n");
                ;
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        ConfigureSystemLanguage();
                        break;

                    case 2:
                        ConfigureSystemTimeZone();
                        break;

                    case 3:
                        SystemSettings(); 
                        break;

                    default:
                        
                        Console.WriteLine("Invalid choice. Try again.\n");
                        ;
                        break;
                }

            } while (true); 
        }

        private static void ConfigureSystemLanguage()
        {
            do
            {
                
                Console.WriteLine("**************************************************\n");
                Console.WriteLine("            Configure System Language             ");
                Console.WriteLine("\n************************************************\n");
                Console.WriteLine("1. English\n");
                Console.WriteLine("2. French\n");
                Console.WriteLine("3. Spanish\n");
                Console.WriteLine("4. Arabic\n");
                Console.WriteLine("5. Back to System Settings Menu\n");
                ;
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        
                        SymLanguageType = "en-US";
                        Console.WriteLine("System language changed to English!\n");
                        ;
                        break;

                    case 2:
                        
                        SymLanguageType = "fr-FR";
                        Console.WriteLine("System language changed to French!\n");
                        ;
                        break;

                    case 3:
                        
                        SymLanguageType = "es-ES";
                        Console.WriteLine("System language changed to Spanish!\n");
                        ;
                        break;

                    case 4:
                        
                        SymLanguageType = "ar-AR";
                        Console.WriteLine("System language changed to Arabic!\n");
                        ;
                        break;

                    case 5:
                        SystemSettings(); 
                        break;

                    default:
                        
                        Console.WriteLine("Invalid choice. Try again.\n");
                        ;
                        break;
                }

            } while (true); 
        }

        private static void ConfigureSystemTimeZone()
        {
            do
            {
                
                Console.WriteLine("**************************************************\n");
                Console.WriteLine("            Configure System Time Zone             ");
                Console.WriteLine("\n************************************************\n");
                Console.WriteLine("1. GMT\n");
                Console.WriteLine("2. UTC\n");
                Console.WriteLine("3. EST\n");
                Console.WriteLine("4. Back to System Settings Menu\n");
                ;
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        
                        var timeNow = DateTime.Now;
                        TimeZoneInfo symTimeZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
                        var gmtTime = TimeZoneInfo.ConvertTime(timeNow, TimeZoneInfo.Local, symTimeZone);
                        Console.WriteLine($"System time zone changed to GMT! Converted time: {gmtTime}\n");
                        ;
                        break;

                    case 2:
                        
                        var timeNow1 = DateTime.Now;
                        var utcTime = TimeZoneInfo.ConvertTime(timeNow1, TimeZoneInfo.Local, TimeZoneInfo.Utc);
                        Console.WriteLine($"System time zone changed to UTC! Converted time: {utcTime}\n");
                        ;
                        break;

                    case 3:
                        
                        var timeUtc = DateTime.UtcNow;
                        TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                        var timeEastern = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);
                        Console.WriteLine($"System time zone changed to EST! Converted time: {timeEastern}\n");
                        ;
                        break;

                    case 4:
                        SystemSettings(); 
                        break;

                    default:
                        
                        Console.WriteLine("Invalid choice. Try again.\n");
                        ;
                        break;
                }

            } while (true);
        }

        private static void ConfigureEmailNotifications()
        {
            do
            {
                
                Console.WriteLine("**************************************************");
                Console.WriteLine("        Configure Email Notifications        ");
                Console.WriteLine("**************************************************");

                Console.WriteLine("1. Enable Email Notifications");
                Console.WriteLine("2. Disable Email Notifications");
                Console.WriteLine("3. Back to System Settings Menu");

                Console.WriteLine("--------------------------------------------------");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        
                        Console.WriteLine("Email notifications enabled !\n");
                        ;
                        break;

                    case 2:
                        
                        Console.WriteLine("Email notifications disabled !\n");
                        ;
                        break;

                    case 3:
                        SystemSettings(); // Return to the configure system parameters menu
                        break;

                    default:
                        
                        Console.WriteLine("Invalid choice. Try again.\n");
                        ;
                        break;
                }

            } while (true); 
        }

        public static void SaveAdministratorsToJson()
        {
            string json = JsonConvert.SerializeObject(administrators, Formatting.Indented);

            try
            {
                
                Console.WriteLine("\nSaving Administrators...\n");
                File.WriteAllText(@"C:\School Management Console App\JSON\admin.json", json);
                Console.WriteLine("\nAdmin data saved to 'admin.json' successfully !\n");
                ;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"\nError Saving Admin Data: {ex.Message}\n");
                ;
            }
        }

        public static void LoadAdminsFromJson()
        {
            try
            {
                if (File.Exists(@"C:\School Management Console App\JSON\admin.json"))
                {
                    
                    Console.WriteLine("\nUploading Admins...\n");
                    string json = File.ReadAllText(@"C:\School Management Console App\JSON\admin.json");
                    administrators = JsonConvert.DeserializeObject<List<Administrator>>(json);
                    Console.WriteLine("\nAdmin data Uploaded from 'admin.json' successfully !\n");
                    ;
                }
                else
                {
                    
                    Console.WriteLine("\n'admin.json' file not found. No admin data Uploaded !\n");
                    ;
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"\nError Uploading admin data: {ex.Message} !\n");
                ;
            }
        }

        public static void SaveStudentWeeklyScheduleToJson()
        {
            string json = JsonConvert.SerializeObject(WeeklyStudentSchedule, Formatting.Indented);

            try
            {
                
                Console.WriteLine("\nSaving Student Weekly Schedule...\n");
                File.WriteAllText(@"C:\School Management Console App\JSON\studentWeeklySchedule.json", json);
                Console.WriteLine("\nStudent Weekly Schedule data saved to 'studentWeeklySchedule.json' successfully !\n");
                ;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"\nError Saving Student Weekly Schedule Data: {ex.Message}\n");
                ;
            }
        }

        public static void LoadStudentWeeklyScheduleFromJson()
        {
            try
            {
                if (File.Exists(@"C:\School Management Console App\JSON\studentWeeklySchedule.json"))
                {
                    
                    Console.WriteLine("\nUploading Students Weekly Schedule...\n");
                    string json = File.ReadAllText(@"C:\School Management Console App\JSON\studentWeeklySchedule.json");
                    WeeklyStudentSchedule = JsonConvert.DeserializeObject<List<string>>(json);
                    Console.WriteLine("\nStudent Weekly Schedule data Uploaded from 'studentWeeklySchedule.json' successfully !\n");
                    ;
                }
                else
                {
                    
                    Console.WriteLine("\n'studentWeeklySchedule.json' file not found. No Students Weekly Schedule data Uploaded !\n");
                    ;
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"\nError Uploading Teacher Weekly Schedule data: {ex.Message} !\n");
                ;
            }
        }

        public static void SaveTeacherWeeklyScheduleToJson()
        {
            string json = JsonConvert.SerializeObject(WeeklyTeacherSchedule, Formatting.Indented);

            try
            {
                
                Console.WriteLine("\nSaving Teacher Weekly Schedule...\n");
                File.WriteAllText(@"C:\School Management Console App\JSON\teacherWeeklySchedule.json", json);
                Console.WriteLine("\nTeacher Weekly Schedule data saved to 'teacherWeeklySchedule.json' successfully !\n");
                ;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"\nError Saving Teacher Weekly Schedule Data: {ex.Message}\n");
                ;
            }
        }

        public static void LoadTeacherWeeklyScheduleFromJson()
        {
            try
            {
                if (File.Exists(@"C:\School Management Console App\JSON\teacherWeeklySchedule.json"))
                {
                    
                    Console.WriteLine("\nUploading Teachers Weekly Schedule...\n");
                    string json = File.ReadAllText(@"C:\School Management Console App\JSON\teacherWeeklySchedule.json");
                    WeeklyTeacherSchedule = JsonConvert.DeserializeObject<List<string>>(json);
                    Console.WriteLine("\nTeacher Weekly Schedule data Uploaded from 'teacherWeeklySchedule.json' successfully !\n");
                    ;
                }
                else
                {
                    
                    Console.WriteLine("\n'teacherWeeklySchedule.json' file not found. No Teachers Weekly Schedule data Uploaded !\n");
                    ;
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"\nError Uploading Student Weekly Schedule data: {ex.Message} !\n");
                ;
            }
        }

        public static void SaveExamsDatesAndDeadlinesToJson()
        {
            string json = JsonConvert.SerializeObject(examsDatesAndDeadlines, Formatting.Indented);

            try
            {
                
                Console.WriteLine("\nSaving Exams Dates and Deadlines...\n");
                File.WriteAllText(@"C:\School Management Console App\JSON\examsDatesAndDeadlines.json", json);
                Console.WriteLine("\nExams Dates and Deadlines data saved to 'examsDatesAndDeadlines.json' successfully !\n");
                ;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"\nError Saving Exams Dates and Deadlines Data: {ex.Message}\n");
                ;
            }
        }

        public static void LoadExamsDatesAndDeadlinesFromJson()
        {
            try
            {
                if (File.Exists(@"C:\School Management Console App\JSON\examsDatesAndDeadlines.json"))
                {
                    
                    Console.WriteLine("\nUploading Exams Dates and Deadlines...\n");
                    string json = File.ReadAllText(@"C:\School Management Console App\JSON\examsDatesAndDeadlines.json");
                    examsDatesAndDeadlines = JsonConvert.DeserializeObject<List<Administrator>>(json);
                    Console.WriteLine("\nExams Dates and Deadlines data Uploaded from 'examsDatesAndDeadlines.json' successfully !\n");
                    ;
                }
                else
                {
                    
                    Console.WriteLine("\n'examsDatesAndDeadlines.json' file not found. No Exams Dates and Deadlines data Uploaded !\n");
                    ;
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"\nError Uploading Exams Dates and Deadlines data: {ex.Message} !\n");
                ;
            }
        }

        public static void SaveUpcomingModulesAndCoursesToJson()
        {
            string json = JsonConvert.SerializeObject(upcomingModulesAndCourses, Formatting.Indented);

            try
            {
                
                Console.WriteLine("\nSaving Upcoming Modules and Courses...\n");
                File.WriteAllText(@"C:\School Management Console App\JSON\upcomingModulesAndCourses.json", json);
                Console.WriteLine("\nUpcoming Modules and Courses data saved to 'upcomingModulesAndCourses.json' successfully !\n");
                ;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"\nError Saving Upcoming Modules and Courses Data: {ex.Message}\n");
                ;
            }
        }

        public static void LoadUpcomingModulesAndCoursesFromJson()
        {
            try
            {
                if (File.Exists(@"C:\School Management Console App\JSON\upcomingModulesAndCourses.json"))
                {
                    
                    Console.WriteLine("\nUploading Upcoming Modules and Courses...\n");
                    string json = File.ReadAllText(@"C:\School Management Console App\JSON\upcomingModulesAndCourses.json");
                    upcomingModulesAndCourses = JsonConvert.DeserializeObject<List<Administrator>>(json);
                    Console.WriteLine("\nUpcoming Modules and Courses data Uploaded from 'upcomingModulesAndCourses.json' successfully !\n");
                    ;
                }
                else
                {
                    
                    Console.WriteLine("\n'upcomingModulesAndCourses.json' file not found. No Upcoming Modules and Courses data Uploaded !\n");
                    ;
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"\nError Uploading Upcoming Modules and Courses data: {ex.Message} !\n");
                ;
            }
        }

        public static void SaveStudentPerformanceReportsToJson()
        {
            string json = JsonConvert.SerializeObject(studentPerformanceReportsList, Formatting.Indented);

            try
            {
                
                Console.WriteLine("\nSaving Student Performance Reports...\n");
                File.WriteAllText(@"C:\School Management Console App\JSON\studentPerformanceReportsList.json", json);
                Console.WriteLine("\nStudent Performance Reports data saved to 'studentPerformanceReportsList.json' successfully !\n");
                ;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"\nError Saving Student Performance Reports Data: {ex.Message}\n");
                ;
            }
        }

        public static void LoadStudentPerformanceReportsFromJson()
        {
            try
            {
                if (File.Exists(@"C:\School Management Console App\JSON\studentPerformanceReportsList.json"))
                {
                    
                    Console.WriteLine("\nUploading Student Performance Reports...\n");
                    string json = File.ReadAllText(@"C:\School Management Console App\JSON\studentPerformanceReportsList.json");
                    studentPerformanceReportsList = JsonConvert.DeserializeObject<List<Administrator>>(json);
                    Console.WriteLine("\nStudent Performance Reports data Uploaded from 'studentPerformanceReportsList.json' successfully !\n");
                    ;
                }
                else
                {
                    
                    Console.WriteLine("\n'studentPerformanceReportsList.json' file not found. No Student Performance Reports data Uploaded !\n");
                    ;
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"\nError Uploading Student Performance Reports data: {ex.Message} !\n");
                ;
            }
        }

        public static void SaveTeacherPerformanceReportsToJson()
        {
            string json = JsonConvert.SerializeObject(teacherPerformanceReportsList, Formatting.Indented);

            try
            {
                
                Console.WriteLine("\nSaving Teacher Performance Reports...\n");
                File.WriteAllText(@"C:\School Management Console App\JSON\teacherPerformanceReportsList.json", json);
                Console.WriteLine("\nTeacher Performance Reports data saved to 'teacherPerformanceReportsList.json' successfully !\n");
                ;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"\nError Saving Teacher Performance Reports Data: {ex.Message}\n");
                ;
            }
        }

        public static void LoadTeacherPerformanceReportsFromJson()
        {
            try
            {
                if (File.Exists(@"C:\School Management Console App\JSON\teacherPerformanceReportsList.json"))
                {
                    
                    Console.WriteLine("\nUploading Teacher Performance Reports...\n");
                    string json = File.ReadAllText(@"C:\School Management Console App\JSON\teacherPerformanceReportsList.json");
                    teacherPerformanceReportsList = JsonConvert.DeserializeObject<List<Administrator>>(json);
                    Console.WriteLine("\nTeacher Performance Reports data Uploaded from 'teacherPerformanceReportsList.json' successfully !\n");
                    ;
                }
                else
                {
                    
                    Console.WriteLine("\n'teacherPerformanceReportsList.json' file not found. No Teacher Performance Reports data Uploaded !\n");
                    ;
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"\nError Uploading Teacher Performance Reports data: {ex.Message} !\n");
                ;
            }
        }

    }
}