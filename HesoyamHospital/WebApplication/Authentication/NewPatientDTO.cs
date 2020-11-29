using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Authentication
{
    public class NewPatientDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string HealthCardNumber { get; set; }
        public string Jmbg { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string BloodType { get; set; }
        public List<string> Allergies { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public NewPatientDTO()
        {

        }
        public NewPatientDTO(string name, string surname, string middleName, string gender, string email, string username, string password, DateTime dateOfBirth, string healthCardNumber, string jmbg, string mobilePhone, string homePhone, string bloodType, List<string> allergies, string country, string city, string address)
        {
            Name = name;
            Surname = surname;
            MiddleName = middleName;
            Gender = gender;
            Email = email;
            Username = username;
            Password = password;
            DateOfBirth = dateOfBirth;
            HealthCardNumber = healthCardNumber;
            Jmbg = jmbg;
            MobilePhone = mobilePhone;
            HomePhone = homePhone;
            BloodType = bloodType;
            Allergies = allergies;
            Country = country;
            City = city;
            Address = address;
        }
    }
}
