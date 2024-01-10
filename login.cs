using System;
using System.Collections.Generic;
using System.Net;

namespace Projet
{
    class Login : User
    {
        public DateTime Session { get; set; }
        public static Login? CurrentUser { get; internal set; }

        public Login(string username, string password, string role, DateTime session) : base(username, password, role)
        { 
            Session = session;
        }

        
       public static void LoginUser()
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine("              Login To Your Account:                  ");
            Console.WriteLine(new string('=', 40));

            Console.Write("Enter your username: ");
            string username = Console.ReadLine() ?? "";
            Console.WriteLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine() ?? "";
            Console.WriteLine();

            Console.Write("Please Select Your Role (admin, teacher, student): ");
            string role = Console.ReadLine() ?? "";
            Console.WriteLine();

            DateTime session = DateTime.Now;
            Login login = new(username, password, role, session);
            if (login.CheckUser())
            {
                Console.WriteLine("Login Successful!\n");
                Console.WriteLine("Welcome " + login.Username);
                Console.WriteLine("Role: " + login.Role);
                Console.WriteLine("Session: " + login.Session + "\n");
                CurrentUser = login;
            }
            else
            {
                Console.WriteLine("Login Failed! This User does not exist!\n");
            }
        }

        public bool CheckUser()
        {
            foreach (var user in Users)
            {
                if (user.Username == Username && user.Password == Password && user.Role == Role)
                {
                    return true;
                }
            }
            return false;
        }

        public static void LogoutUser(Login login)
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine($"Logging out: {login.Username}\n");
            Console.WriteLine("Session Ended !");
            Console.WriteLine(new string('=', 40));
        }
    }
}