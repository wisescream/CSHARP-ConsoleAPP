using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using Newtonsoft.Json;

namespace Projet
{

    class Module: Course
    {
        public string NameM { get; set; }
        public int CoursesNumber { get; set; }
        public static List<Module> Modules { get; set; } = new List<Module>();

        public Module(string nameM, int coursesNumber, string nameC) : base(nameC, "", "", "", "", "", "", "")
        {
            NameM = nameM;
            CoursesNumber = coursesNumber;
        }

        public static void AddModule()
        {
            
                Console.WriteLine(new string('=', 40));
             Console.WriteLine("                  Add Module:");
                Console.WriteLine(new string('=', 40));
             
            Console.Write("Enter module name : ");
            string moduleName = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Enter courses number : ");
            int coursesNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Module newModule = new(moduleName, coursesNumber, ""); 
            
            Console.WriteLine("Module added successfully !");
            
            Console.WriteLine("");
            SaveModulesToJson();
            Console.WriteLine("");
        }

        public static void AddCourseToModule()
        {
            
                Console.WriteLine(new string('=', 40));
             Console.WriteLine("                  Add Course To Module:");
                Console.WriteLine(new string('=', 40));
             
            Console.Write("Enter module name: ");
            string moduleName = Console.ReadLine();
            Console.WriteLine("\n");
            Module selectedModule = Modules.Find(module => module.NameM == moduleName);

            if (selectedModule != null)
            {
                do
                {
                    Console.Write("Enter course name: ");
                    string courseName = Console.ReadLine();
                    Console.WriteLine("");
                    Course selectedCourse = Courses.Find(course => course.NameC == courseName);
                    if (selectedCourse != null)
                    {
                        Courses.Add(selectedCourse);
                        
                        Console.WriteLine("Course added to module successfully !");
                        
                        Console.WriteLine("");
                        SaveModulesToJson();
                        Console.WriteLine("");
                    }
                    else
                    {
                        
                        Console.WriteLine("Course not found !\n");
                        
                    }

                    Console.Write("Do you want to add another course to this module ? (y/n) : ");

                } while (Console.ReadLine() == "y" || Console.ReadLine() == "Y");
            }
            else
            {
                
                Console.WriteLine("Module not found !\n");
                
            }

        }

        public static void ViewModules()
        {
            
            Console.WriteLine("                  List of Modules:");
            
            LoadModulesFromJson();
            Console.WriteLine("");

            foreach (var module in Modules)
            {
                Console.WriteLine($"Module : {module.NameM}\n");
                foreach (var course in Courses)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;   
                    Console.WriteLine($"Course : {course.NameC},");
                    
                }
            }
        }

        public static void DeleteModule()
        {
            
                Console.WriteLine(new string('=', 40));
             Console.WriteLine("                  Delete Module:");
                Console.WriteLine(new string('=', 40));
             
            Console.Write("Enter module name: ");
            string moduleNameToDelete = Console.ReadLine();
            Console.WriteLine("\n");
            foreach (var module in Modules)
            {
                if (module.NameM == moduleNameToDelete)
                {
                    Modules.Remove(module);
                    
                    Console.WriteLine("Module deleted successfully !");
                    
                    Console.WriteLine("");
                    SaveModulesToJson();
                    Console.WriteLine("");
                    return;
                }
                else
                {
                    
                    Console.WriteLine("Module not found.\n");
                    
                }
            }
        }

        public static void ManageModules()
        {
            do
            {
                
                Console.WriteLine("\n==================================================\n");
                Console.WriteLine("               Modules Management System              ");
                Console.WriteLine("\n==================================================\n");
                Console.WriteLine("1. Add Module\n");
                Console.WriteLine("2. Add Course To Module \n");
                Console.WriteLine("3. Display Module Details\n");
                Console.WriteLine("4. Delete Module\n");
                Console.WriteLine("5. Back to main menu\n");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddModule();
                        break;

                    case 2:
                        AddCourseToModule();
                        break;

                    case 3:
                        ViewModules();
                        break;

                    case 4:
                        DeleteModule();
                        break;

                    case 5:
                        Program.MainMenu(); 
                        break; 

                    default:
                        
                        Console.WriteLine("Invalid choice. Try again.\n");
                        
                        break;
                }

            } while (true); 
        }

        public static void SaveModulesToJson()
        {
            string json = JsonConvert.SerializeObject(Modules, Formatting.Indented);

            try
            {
                
                Console.WriteLine("Saving Modules...");
                File.WriteAllText(@"C:\School Management Console App\JSON\module.json", json);
                Console.WriteLine("Module data saved to 'module.json' successfully !");
                
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error Saving Module Data: {ex.Message}\n");
                
            }
        }

        public static void LoadModulesFromJson()
        {
            try
            {
                if (File.Exists(@"C:\School Management Console App\JSON\module.json"))
                {
                    Console.WriteLine("\nUploading Modules...\n");
                    string json = File.ReadAllText(@"C:\School Management Console App\JSON\module.json");
                    Modules = JsonConvert.DeserializeObject<List<Module>>(json);
                    Console.WriteLine("\nModule data Uploaded from 'module.json' successfully !\n");
                    
                }
                else
                {
                    
                    Console.WriteLine("\n'module.json' file not found. No module data Uploaded !\n");
                    
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"\nError uploading module data: {ex.Message} !\n");
                
            }
        }
    }
}
