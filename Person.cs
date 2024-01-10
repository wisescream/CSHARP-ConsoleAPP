using System;
using System.ComponentModel.DataAnnotations;

namespace Projet
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Id { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }

        public Person(string firstName, string lastName, string gender, int id, int phoneNumber, string email, string address, DateTime dateOfBirth, string nationality )
        {
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        Id = id;
        PhoneNumber = phoneNumber;
        Email = email;
        Address = address;
        DateOfBirth = dateOfBirth;
        Nationality = nationality;
        }   
    }
}