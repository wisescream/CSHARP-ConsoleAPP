using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Projet
{
    class Course
    {
        public string NameC { get; set; }
        public string AssociatedModule { get; set; }
        public string CourseDebutDate { get; set; }
        public string CourseEndDate { get; set; }
        public string CourseTeacherName { get; set; }
        public string CourseClassroom { get; set; }
        public string CourseClass { get; set; }
        public static string? CoursePath { get; set; }
        public static List<Course> Courses { get; set; } = new List<Course>();


        public Course(string namec, string associatedModule, string courseDebutDate, string courseEndDate, string courseTeacherName, string courseClassroom, string courseClass, string coursePath)
        {
            NameC = namec;
            AssociatedModule = associatedModule;
            CourseDebutDate = courseDebutDate;
            CourseEndDate = courseEndDate;
            CourseTeacherName = courseTeacherName;
            CourseClassroom = courseClassroom;
            CourseClass = courseClass;
            CoursePath = coursePath;
        }
        public static void AddCourse()
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine("                  Add Course:");
            Console.WriteLine(new string('=', 40));
            Console.Write("Enter course name : ");
            string name = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Enter associated module : ");
            string associatedModule = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Enter course debut date: ");
            string courseDebutDate = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Enter course end date: ");
            string courseEndDate = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Enter course teacher name: ");
            string courseTeacherName = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Enter course classroom number: ");
            string courseClassroom = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Enter course class: ");
                        string courseClass = Console.ReadLine();
                        Console.WriteLine("");
            Console.Write("Enter course file path: ");
                        string coursePath = Console.ReadLine();
                        Console.WriteLine("");
            Course newCourse = new(name, associatedModule, courseDebutDate, courseEndDate, courseTeacherName, courseClassroom, courseClass, coursePath);
            Courses.Add(newCourse);
            Console.WriteLine("Course added successfully !");
            Console.WriteLine("");
            SaveCoursesToJson();
            Console.WriteLine("");
        }

        public static void ViewCourses()
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine("                    List of Courses  ");
            Console.WriteLine(new string('=', 40));
            LoadCoursesFromJson();
            Console.WriteLine("");

            foreach (var course in Courses)
            {
                Console.WriteLine($"Course Name: {course.NameC}, Associated Module: {course.AssociatedModule}, Course Path: {CoursePath}\n");
            }
        }

        public static void UpdateCourse()
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine("                  Update Course:");
            Console.WriteLine(new string('=', 40));
            Console.Write("Enter course name to update: "); 
            string name = Console.ReadLine();
            Console.WriteLine("\n");
            foreach (var course in Courses)
            {
                if (course.NameC == name)
                {
                    Console.Write("Enter new course name: ");
                    string newNameC = Console.ReadLine();
                    Console.WriteLine("");
                    Console.Write("Enter new course associated module: ");
                    string newAssociatedModule = Console.ReadLine();
                    Console.WriteLine("");
                    Console.Write("Enter new course file path: ");
                    string newCoursePath = Console.ReadLine();
                    Console.WriteLine("");
                    Console.Write("Enter new course debut date: ");
                    string newCourseDebutDate = Console.ReadLine();
                    Console.WriteLine("");
                    Console.Write("Enter new course end date: ");
                    string newCourseEndDate = Console.ReadLine();
                    Console.WriteLine("");
                    Console.Write("Enter new course teacher name: ");
                    string newCourseTeacherName = Console.ReadLine();
                    Console.WriteLine("");
                    Console.Write("Enter new course classroom number: ");
                    string newCourseClassroom = Console.ReadLine();
                    Console.WriteLine("");
                    Console.Write("Enter new course class: ");
                    string newCourseClass = Console.ReadLine();         
                    Console.WriteLine("");
                    course.CourseClass = newCourseClass;
                    course.CourseClassroom = newCourseClassroom;
                    course.CourseTeacherName = newCourseTeacherName;
                    course.CourseEndDate = newCourseEndDate;
                    course.CourseDebutDate = newCourseDebutDate;
                    CoursePath = newCoursePath;
                    course.NameC = newNameC;
                    course.AssociatedModule = newAssociatedModule;
                        Console.WriteLine("");
                    Console.WriteLine("Course updated successfully !");
                        Console.WriteLine("");
                    SaveCoursesToJson();
                    Console.WriteLine("");
                    return;
                }
                else
                {
                   
                    Console.WriteLine("Course not found !\n");
                    }
            }
        }

        public static void DeleteCourse()
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine("                  Delete Course:");
            Console.WriteLine(new string('=', 40));
            Console.Write("Enter course name to delete: ");
            string nameToDelete = Console.ReadLine();       

            foreach(var course in Courses)
            {
                if (course.NameC == nameToDelete)
                {
                    Courses.Remove(course);
                        Console.WriteLine("Course deleted successfully.\n");
                        Console.WriteLine("");
                    SaveCoursesToJson();
                    Console.WriteLine("");
                    return;
                }
                else
                {
                   
                    Console.WriteLine("Course not found.\n");
                    }
            }
        }

        public static void DisplayCourseDetails(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    Console.WriteLine(File.ReadAllText(filePath));
                }
                else
                {
                   
                    Console.WriteLine("File not found.\n");
                    }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static void ManageCourses()
        {
            do
            {
             Console.WriteLine(new string('=', 50));
             Console.WriteLine("      Courses Management System");
             Console.WriteLine(new string('=', 50));
             Console.WriteLine("Options:");
             Console.WriteLine("  1. Add Course");
             Console.WriteLine("  2. View Courses");
             Console.WriteLine("  3. Display Course Details");
             Console.WriteLine("  4. Update Course");
             Console.WriteLine("  5. Delete Course"); 
             Console.WriteLine("  6. Back to Main Menu");  
             Console.WriteLine(new string('-', 50)); 
             Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine('\n');

                switch (choice)
                {
                    case 1:
                        AddCourse();
                        break;

                    case 2:
                        ViewCourses();
                        break;

                    case 3:
                        DisplayCourseDetails(CoursePath);
                        break;

                    case 4:
                        UpdateCourse();
                        break;

                    case 5:
                        DeleteCourse();
                        break;

                    case 6:
                        Program.MainMenu();
                        break; 
                    default:
                       
                        Console.WriteLine("Invalid choice. Try again.\n");
                                break;
                } 

            } while (true); 
        }

        public static void SaveCoursesToJson()
        {
            string json = JsonConvert.SerializeObject(Courses, Formatting.Indented);

            try
            {
                Console.WriteLine("Saving Courses...");
                File.WriteAllText(@"C:\School Management Console App\JSON\course.json", json);
                Console.WriteLine("Course data saved to 'course.json' successfully !");
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Error Saving Course Data: {ex.Message}\n");
            }
        }

        public static void LoadCoursesFromJson()
        {
            try
            {
                if (File.Exists(@"C:\School Management Console App\JSON\course.json"))
                {
                        Console.WriteLine("");
                    Console.WriteLine("Uploading Courses...");
                    string json = File.ReadAllText(@"C:\School Management Console App\JSON\course.json");
                    Courses = JsonConvert.DeserializeObject<List<Course>>(json);
                    Console.WriteLine("");
                    Console.WriteLine("Admin data Uploaded from 'course.json' successfully !\n");
                    }
                else
                {
                   
                    Console.WriteLine("\n'course.json' file not found. No course data Uploaded !\n");
                    }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"\nError Uploading course data: {ex.Message} !\n");
            }
        }
    }
}