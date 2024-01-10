using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Projet
{
    class Teacher : Person
    {
        public string AssignedCourse { get; set; }

        public static List<Teacher> teachers = new();

        public static List<string>? WeeklyTeacherSchedule { get; set; }

        // Constructor
        public Teacher(string firstName, string lastName, string gender, int id, int phoneNumber, string email, string address, DateTime dateOfBirth, string nationality, string assignedCourse) : base(firstName, lastName, gender, id, phoneNumber, email, address, dateOfBirth, nationality)
        {
            AssignedCourse = assignedCourse;
        }

        public static void AddTeacher()
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine("                  Add Teacher:");
            Console.WriteLine(new string('=', 40));
            Console.Write("Enter teacher First name: ");

            string firstName = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Enter teacher Last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Enter Teacher Gender : ");

            string gender = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Enter teacher ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Console.Write("Enter teacher phone number: ");
            int phoneNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Console.Write("Enter teacher Email: ");

            string email = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Enter teacher Address: ");

            string address = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Enter teacher Date of birth: ");
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("");
            Console.Write("Enter teacher Nationality: ");
            string nationality = Console.ReadLine();
            Console.Write("Enter teacher Assigned Course: ");
            string assignedCourse = Console.ReadLine();
            Console.WriteLine("");
            Teacher newTeacher = new(firstName, lastName, gender, id, phoneNumber, email, address, dateOfBirth, nationality, assignedCourse);
            teachers.Add(newTeacher);
            Console.WriteLine("Teacher Added Successfully !");
            Console.WriteLine("");
            // Save teachers to json
            SaveTeachersToJson();
            Console.WriteLine("");
        }

        public static void DisplayTeacherDetails()
        {
                Console.WriteLine(new string('=', 40));
            Console.WriteLine("                   Display Teacher Details:                 ");
                Console.WriteLine(new string('=', 40));
            Console.Write("Enter teacher ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            LoadTeachersFromJson();
            Console.WriteLine("");

            Teacher teacher = teachers.Find(t => t.Id == id);
            if (teacher != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("                Teacher Details:                 ");
                Console.WriteLine($"Teacher ID : {teacher.Id} \t Teacher First Name : {teacher.FirstName} \t Teacher Last Name : {teacher.LastName} \t Teacher Gender : {teacher.Gender} \t Teacher Phone Number : {teacher.PhoneNumber} \t Teacher Email : {teacher.Email} \t Teacher Address: {teacher.Address} \t Teacher Birth Date : {teacher.DateOfBirth} \t Teacher Nationality : {teacher.Nationality} \t Teacher Assigned Course : {teacher.AssignedCourse}");
            }
            else
            {
                Console.WriteLine("Teacher not found !\n");
            }
        }

        public static void ViewTeachers()
        {
                Console.WriteLine(new string('=', 40));
            Console.WriteLine("                   List of Teachers:                 ");
                Console.WriteLine(new string('=', 40));
            LoadTeachersFromJson();
            Console.WriteLine("");
            foreach (var teacher in teachers)
            {
                if (teachers.Count != 0)
                {
                    Console.WriteLine("Teacher N`{0} : ", teachers.IndexOf(teacher) + 1);
                    Console.WriteLine($"Teacher ID : {teacher.Id} \t Teacher Full Name : {teacher.FirstName + " "}{teacher.LastName} ");
                }
                else
                {
                    Console.WriteLine("No Teachers found !");
                }
            }
        }

        public static void UpdateTeacher()
        {
            Console.WriteLine("              Update Teacher:");
            Console.Write("Enter teacher ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());  
            Console.WriteLine("\n");

            Teacher teacherToUpdate = teachers.Find(t => t.Id == id);
    
                if (teacherToUpdate != null)
                {
                    Console.Write("Enter new teacher first name: ");

                    string newFirstName = Console.ReadLine();
                    Console.WriteLine("");
                    Console.Write("Enter new teacher last name: ");

                    string lastName = Console.ReadLine();
                    Console.WriteLine("");
                    Console.WriteLine("Enter new teacher gender: ");

                string gender = Console.ReadLine();
                Console.Write("Enter new teacher ID: ");
                    int id2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("");
                    Console.Write("Enter new teacher phone number: ");
                    int phoneNumber = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("");
                    Console.Write("Enter new teacher email: ");

                    string email = Console.ReadLine();
                    Console.WriteLine("");
                    Console.Write("Enter new teacher address: ");

                    string address = Console.ReadLine();
                    Console.WriteLine("");
                    Console.Write("Enter new teacher date of birth: ");
                    DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("");
                    Console.WriteLine("Enter new teacher nationality");

                string nationality = Console.ReadLine();
                    Console.WriteLine("");
                    Console.Write("Enter new teacher Assigned Course: ");

                    string assignedCourse = Console.ReadLine();
                    Console.WriteLine("");
                teacherToUpdate.FirstName = newFirstName;
                teacherToUpdate.LastName = lastName;
                teacherToUpdate.Gender = gender;
                teacherToUpdate.Id = id2;
                teacherToUpdate.PhoneNumber = phoneNumber;
                teacherToUpdate.Email = email;
                teacherToUpdate.Address = address;
                teacherToUpdate.DateOfBirth = dateOfBirth;
                teacherToUpdate.Nationality = nationality;
                teacherToUpdate.AssignedCourse = assignedCourse;
                teachers.Add(teacherToUpdate);
                Console.WriteLine("Teacher Updated Successfully !");
                Console.WriteLine("");
                SaveTeachersToJson();
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Teacher not found !\n");
            }
        }   

        public static void DeleteTeacher()
        {
            Console.WriteLine("                  Delete Teacher:");
           
            Console.Write("Enter teacher ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            Teacher teacherToRemove = teachers.Find(t => t.Id == id);

            if (teacherToRemove != null)
            {
                teachers.Remove(teacherToRemove);
                Console.WriteLine("Teacher deleted successfully !");
                Console.WriteLine("");
                SaveTeachersToJson();
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Teacher not found !");
            }
        }

        public static void ManageTeachers()
        {
            do
            {
                Console.WriteLine("         Teacher Management System         ");
                Console.WriteLine("1. Add Teacher\n");
                Console.WriteLine("2. Display Teacher Details\n");
                Console.WriteLine("3. View Teachers\n");
                Console.WriteLine("4. Update Teacher\n");
                Console.WriteLine("5. Delete Teacher\n");
                Console.WriteLine("6. Back to main menu\n");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");

                switch (choice)
                {
                    case 1:
                        AddTeacher();
                        break;

                    case 2:
                        DisplayTeacherDetails();
                        break;

                    case 3:
                        ViewTeachers();
                        break;

                    case 4:
                        UpdateTeacher();
                        break;

                    case 5:
                        DeleteTeacher();
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

       public static void SaveTeachersToJson()
        {
            string json = JsonConvert.SerializeObject(teachers, Formatting.Indented);

            try
            {
                Console.WriteLine("\nSaving Teachers...\n");
                File.WriteAllText(@"C:\School Management Console App\JSON\teacher.json", json);
                Console.WriteLine("\nTeacher data saved to 'teacher.json' successfully !\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError Saving Student Data: {ex.Message} !\n");
            }
        }

        public static void LoadTeachersFromJson()
        {
            try
            {
                if (File.Exists(@"C:\School Management Console App\JSON\teacher.json"))
                {
                        Console.WriteLine("\nUploading Teachers...\n");
                    string json = File.ReadAllText(@"C:\School Management Console App\JSON\student.json");
                    teachers = JsonConvert.DeserializeObject<List<Teacher>>(json);
                    Console.WriteLine("\nTeachers data uploaded from 'teacher.json' successfully !\n");
                    }
                else
                {
                        Console.WriteLine("\nFile 'teacher.json' not found. No teacher data Uploaded !\n");
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError Uploading Teachers Data: {ex.Message} !\n");
            }
        }
    }
}
