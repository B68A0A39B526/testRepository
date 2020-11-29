using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.MedicalRecords
{
    public class MedicalRecordDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
        public string MedicalId{ get; set; }
        public string PersonalId { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string BloodType { get; set; }
        public List<string> Alergies { get; set; }
        public List<PrescriptionDTO> Prescriptions { get; set; }

        public MedicalRecordDTO() { }
        public MedicalRecordDTO(string name, string surname, string middleName, string address, string date, string medicalId, string personalId, string phone, string homePhone, string email, string username, string password, string bloodType, List<string> alergies, List<PrescriptionDTO> presc) {
            FirstName = name;
            LastName = surname;
            MiddleName = middleName;
            Address = address;
            DateOfBirth = date;
            MedicalId = medicalId;
            PersonalId = personalId;
            MobilePhone = phone;
            HomePhone = homePhone;
            Email = email;
            Username = username;
            Password = password;
            BloodType = bloodType;
            Alergies = alergies;
            Prescriptions = presc;
        }
    }
}
