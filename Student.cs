using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Projet
{
    class Student : Person
    {
        // Properties

        public string Class { get; set; }

        public string Level { get; set; }

        public string Experise { get; set;}


        

        public static List<Student> students = new();

        // Constructor
           public Student(string firstName, string lastName, string gender, int id, int phoneNumber, string email, string address, DateTime dateOfBirth, string nationality, string classValue, string level, string expertise)
            : base(firstName, lastName, gender, id, phoneNumber, email, address, dateOfBirth, nationality)
        {
            Class = classValue;
            Level = level;
            Experise = expertise;
        }
        public static void AddStudent()
        {
            Console.WriteLine(" Add Student");
            Console.Write("Enter Student First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Enter Student Last Name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Enter Student Gender ( male, female, other): ");
            string gender = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Enter Student ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Console.Write("Enter Student Phone Number: ");
            int phoneNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Console.Write("Enter Student Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Enter Student Address: ");
            string address = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Enter Student Birth Date: ");
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("");
            Console.Write("Enter Student Nationality: ");
            string nationality = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Enter Student Class: ");
                        string cclass = Console.ReadLine();
                        Console.WriteLine("");
            Console.Write("Enter Student Level: ");
                        string level = Console.ReadLine();
                        Console.WriteLine("");
            Console.Write("Enter Student Expertise: ");
                        string expertise = Console.ReadLine();
                        Console.WriteLine("");
            Student newStudent = new(firstName, lastName, gender, id, phoneNumber, email, address, dateOfBirth, nationality, cclass, level, expertise);
            students.Add(newStudent);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Student added successfully !");
            Console.ResetColor();
            Console.WriteLine("");
            // Save students to json file
            SaveStudentsToJson();
        }

        public static void ViewStudents()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("                  List of Students");
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            Console.WriteLine("");
            // Upload students from json file
            LoadStudentsFromJson();
            Console.WriteLine("");
            foreach (var student in students)
            {
                if (students.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No students found !");
                    Console.ResetColor();
                }
                else{
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Student N`{0} : ", students.IndexOf(student) + 1);
                    Console.WriteLine($"Student ID : {student.Id} \t Student Full Name : {student.FirstName + " "}{student.LastName}");
                    Console.WriteLine("");
                    Console.ResetColor();
                }
            }
        }

        public static void DisplayStudentDetails()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("                 Display Student Details");
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            Console.Write("Enter Student ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            // Upload students from json file
            LoadStudentsFromJson();
            Console.WriteLine("");
            // Find student by id
            Student studentToDisplay = students.Find(s => s.Id == id);  
            if (studentToDisplay != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("                  Student Details:                    ");
                Console.WriteLine($"Student ID : {studentToDisplay.Id} \t Student First Name : {studentToDisplay.FirstName} \t Student Last Name : {studentToDisplay.LastName} \t Student Gender : {studentToDisplay.Gender} \t Student Email : {studentToDisplay.Email} \t Student Phone Number : {studentToDisplay.PhoneNumber} \t Student Address : {studentToDisplay.Address} \t Student Birth Date : {studentToDisplay.DateOfBirth} \t Student Nationality : {studentToDisplay.Nationality} \t Student Class : {studentToDisplay.Class} \t Student Level : {studentToDisplay.Level} \t Student Expertise : {studentToDisplay.Experise}");
                Console.ResetColor();   
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Student not found !\n");
                Console.ResetColor();
            }
        }

        public static void UpdateStudent()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("                  Update Student");
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            Console.Write("Enter Student ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Student studentToUpdate = students.Find(s => s.Id == id);
            if (studentToUpdate != null)
            {
                Console.Write("Enter new Student First Name: ");
                string firstName = Console.ReadLine();
                Console.WriteLine("");
                Console.Write("Enter new Student Last Name: ");
                string lastName = Console.ReadLine();
                Console.WriteLine("");
                Console.Write("Enter new student Gender:");
                string gender = Console.ReadLine();
                Console.WriteLine("");
                Console.Write("Enter new Student ID: ");
                int newId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
                Console.Write("Enter new Student Phone Number: ");
                int phoneNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
                Console.Write("Enter new Student Email: ");
                string email = Console.ReadLine();
                Console.WriteLine("");
                Console.Write("Enter new Student Address: ");
                string address = Console.ReadLine();
                Console.WriteLine("");
                Console.Write("Enter new Student Birth Date: ");
                DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("");
                Console.Write("Enter new Student Nationality: ");
                string nationality = Console.ReadLine();
                Console.WriteLine("");
                Console.Write("Enter new Student Class: ");
                string cclass = Console.ReadLine();
                Console.WriteLine("");
                Console.Write("Enter new student level: ");
                string level = Console.ReadLine();
                Console.WriteLine("");
                Console.Write("Enter new student expertise: ");
                string expertise = Console.ReadLine();
                Console.WriteLine("");
                studentToUpdate.FirstName = firstName;
                studentToUpdate.LastName = lastName;
                studentToUpdate.Id = newId;
                studentToUpdate.Gender = gender;
                studentToUpdate.PhoneNumber = phoneNumber;
                studentToUpdate.Email = email;
                studentToUpdate.Address = address;
                studentToUpdate.DateOfBirth = dateOfBirth;
                studentToUpdate.Nationality = nationality;
                studentToUpdate.Class = cclass;
                studentToUpdate.Level = level;
                studentToUpdate.Experise = expertise;
                students.Add(studentToUpdate);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Student updated successfully !");
                Console.ResetColor();
                Console.WriteLine("");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Student not found.\n");
                Console.ResetColor();
            }
            // Save students to json file
            SaveStudentsToJson();
            Console.WriteLine("");
        }

        public static void DeleteStudent()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("                  Delete Student");
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            Console.Write("Enter student ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");
            Student studentToRemove = students.Find(s => s.Id == id);
            if (studentToRemove != null)
            {
                students.Remove(studentToRemove);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Student deleted successfully !");
                Console.ResetColor();
                Console.WriteLine("");
                // Save students to json file
                SaveStudentsToJson();
                Console.WriteLine("");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Student not found.\n");
                Console.ResetColor();
            }
        }

        public static void ManageStudents()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(new string('=', 40));
                Console.WriteLine("                 Student Management System");
                Console.WriteLine(new string('=', 40));
                Console.WriteLine("1. Add Student\n");
                Console.WriteLine("2. Display Student Details\n");
                Console.WriteLine("3. View Students List\n");
                Console.WriteLine("4. Update Student\n");
                Console.WriteLine("5. Delete Student\n");
                Console.WriteLine("6. Back to main menu\n");
                Console.ResetColor(); // Reset color to default
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine('\n');

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;

                    case 2:
                        DisplayStudentDetails();
                        break;

                    case 3:
                        ViewStudents();
                        break;

                    case 4:
                        UpdateStudent();
                        break;

                    case 5:
                        DeleteStudent();
                        break;

                    case 6:
                        Program.MainMenu();
                        break; // Retuns to main menu

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Try again.\n");
                        Console.ResetColor();
                        break;
                    }  

            } while (true); // Loop until user enters 6 to return to main menu
        }

        public static void SaveStudentsToJson()
        {
            string json = JsonConvert.SerializeObject(students, Formatting.Indented);

            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("\nSaving Students...\n");
                File.WriteAllText(@"C:\School Management Console App\JSON\student.json", json);
                Console.WriteLine("\nStudent data saved to 'student.json' successfully !\n");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError Saving Student Data: {ex.Message} !\n");
                Console.ResetColor();
            }
        }

        public static void LoadStudentsFromJson()
        {
            try
            {
                if (File.Exists(@"C:\School Management Console App\JSON\student.json"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nUploading Students...\n");
                    string json = File.ReadAllText(@"C:\School Management Console App\JSON\student.json");
                    students = JsonConvert.DeserializeObject<List<Student>>(json);
                    Console.WriteLine("\nStudents data loaded from 'student.json' successfully !\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nFile 'student.json' not found !\n");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError Uploading Students Data: {ex.Message} !\n");
                Console.ResetColor();
            }
        }
    }
}
