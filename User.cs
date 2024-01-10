using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Projet
{

    class User
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }

        public static List<User> Users { get; set; } = new ();

        // Constructor
        public User(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        public static void AddUser()
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine("                  Add User:");
            Console.WriteLine(new string('=', 40));
            Console.Write("Enter user Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Enter user Password: ");
            string password = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Enter user Role ( admin, teacher, student ): ");
            string role = Console.ReadLine();
            User newUser = new(username, password, role);
            Users ??= new List<User>();
            Users.Add(newUser);
            Console.WriteLine("");
            Console.WriteLine("User added successfully!");
            Console.WriteLine("");
            SaveUsersToJson();
            Console.WriteLine("");
        }

        public static void ViewUsers()
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine("                    List of Users:");
            Console.WriteLine(new string('=', 40));
            LoadUsersFromJson();
            Console.Write("Enter your role (admin, teacher, student): ");
            string role = Console.ReadLine();
            Console.WriteLine("");
            if (role != "admin")
            {
                Console.WriteLine("You are not authorized to view users.\n");
                return;
            }
            else
            {
                Console.WriteLine("You are authorized to view users.\n");
                foreach (var user in Users)
                {
                    Console.WriteLine($"Username: {user.Username}");
                    Console.WriteLine("");
                    Console.WriteLine($"Password: {user.Password}");
                    Console.WriteLine("");
                    Console.WriteLine($"Role: {user.Role}");
                    Console.WriteLine("");
                    Console.WriteLine(new string('=', 40));

                    }
            }
        }

       public static void UpdateUser()
    {
        Console.WriteLine(new string('=', 40));
        Console.WriteLine("       Update User");
        Console.WriteLine(new string('=', 40));
        Console.Write("Enter user Username: ");
        string username = Console.ReadLine().Trim();
        
        User userToUpdate = Users.Find(user => user.Username == username);
        if (userToUpdate != null)
        {
            Console.Write("Enter New User Username: ");
            string newUsername = Console.ReadLine().Trim();
            Console.Write("Enter New User Password: ");
            string newPassword = Console.ReadLine().Trim();
            Console.Write("Enter New User Role: ");
            string newRole = Console.ReadLine().Trim();

            userToUpdate.Username = newUsername;
            userToUpdate.Password = newPassword;
            userToUpdate.Role = newRole;

            SaveUsersToJson(); 
            Console.WriteLine("User Updated Successfully !");
        }
        else
        {
            Console.WriteLine("User not found !");
        }
        Console.WriteLine();
    }

    public static void DeleteUser()
    {
        Console.WriteLine(new string('=', 40));
        Console.WriteLine("       Delete User");
        Console.WriteLine(new string('=', 40));
        Console.Write("Enter user Username: ");
        string username = Console.ReadLine().Trim();

        User userToRemove = Users.Find(user => user.Username == username);
        if (userToRemove != null)
        {
            Users.Remove(userToRemove);
            SaveUsersToJson(); 
            Console.WriteLine("User deleted successfully !");
        }
        else
        {
            Console.WriteLine("User not found !");
        }
        Console.WriteLine();
    }

        public static void ManageUsers()
        {
            do 
            {
                Console.WriteLine(new string('=', 40));
                Console.WriteLine("   User Management System");
                Console.WriteLine(new string('=', 40));
                Console.WriteLine("User Management Options:");
                Console.WriteLine("  1. Add User");
                Console.WriteLine("  2. View Users");
                Console.WriteLine("  3. Update User");
                Console.WriteLine("  4. Delete User");
                Console.WriteLine("  5. Back to Main Menu");
                Console.WriteLine(new string('-', 40)); 
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");

                switch (choice)
                {
                    case 1:
                        AddUser();
                        break;

                    case 2:
                        ViewUsers();
                        break;

                    case 3:
                        UpdateUser();
                        break;

                    case 4:
                        DeleteUser();
                        break;

                    case 5:
                        Program.MainMenu();
                        break; // Return to the main menu
                            
                    default:
                                Console.WriteLine("Invalid choice. Try again !");
                                break;
                }

            } while (true); 
        }

        public static void SaveUsersToJson()
        {
            string json = JsonConvert.SerializeObject(Users, Formatting.Indented);

            try
            {
                Console.WriteLine("\nSaving Users...\n");
                File.WriteAllText(@"C:\School Management Console App\JSON\user.json", json);
                Console.WriteLine("\nUser data saved to 'user.json' successfully !\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError Saving User Data: {ex.Message}\n");
            }
        }

       public static void LoadUsersFromJson()  {
        string filePath = @"C:\School Management Console App\JSON\user.json";

        try
        {
            if (File.Exists(filePath))
            {
                Console.WriteLine("\nLoading Users...\n");
                string json = File.ReadAllText(filePath);
                Users = JsonConvert.DeserializeObject<List<User>>(json);
                Console.WriteLine("\nUser data loaded from 'user.json' successfully!\n");
            }
            else
            {
                Console.WriteLine($"\n'{filePath}' file not found. No user data loaded.\n");
            }
        }
        catch (Exception ex) {
            Console.WriteLine($"\nError loading user data: {ex.Message}\n");
             }
        }   

    }
}