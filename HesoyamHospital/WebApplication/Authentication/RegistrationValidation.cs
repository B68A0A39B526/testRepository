using Backend;
using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApplication.Authentication
{
    public static class RegistrationValidation
    {  
        public static bool IsNewPatientValid(NewPatientDTO patient)
        {
            Regex names = new Regex(@"[A-Za-z]{2,20}");
            Regex surnames = new Regex(@"[A-Za-z ]{2,20}");
            Regex username = new Regex(@"[A-Za-z_01-9]{2,20}");
            Regex password = new Regex(@"[A-Za-z]{8,20}");
            Regex healthCardNumbers = new Regex(@"[01-9]{11}");
            Regex jmbgNumbers = new Regex(@"[01-9]{13}");
            Regex phone = new Regex(@"[01-9]{8,11}");
            Regex address = new Regex(@"[A-Za-z 0-9]{1,50}");

            if (
                names.IsMatch(patient.Name) &&
                surnames.IsMatch(patient.Surname) &&
                names.IsMatch(patient.MiddleName) &&
                IsEmailValid(patient.Email) &&
                username.IsMatch(patient.Username) &&
                password.IsMatch(patient.Password) &&
                IsDateInThePast(patient.DateOfBirth) &&
                healthCardNumbers.IsMatch(patient.HealthCardNumber) &&
                jmbgNumbers.IsMatch(patient.Jmbg) &&
                phone.IsMatch(patient.MobilePhone) &&
                IsHomePhoneValid(patient.HomePhone) &&
                AreAllergiesValid(patient.Allergies) &&
                address.IsMatch(patient.City) &&
                address.IsMatch(patient.Country) &&
                address.IsMatch(patient.Address)
                ) 
                return true;
            return false;
        }

        public static bool IsPatientValid(NewPatientDTO dto)
        {
            List<Patient> patients = AppResources.getInstance().patientService.GetAll().ToList();
            if (IsNewPatientValid(dto) && IsUsernameUnique(dto.Username, patients)) return true;
            return false;
        }


        public static bool IsUsernameUnique(string username, List<Patient> patients)
        {
            if (patients == null || patients.Count == 0) return true;
            foreach (Patient patient in patients)
            {
                if (patient.UserName == username) return false;
            }
            return true;
        }

        public static bool IsEmailValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool IsDateInThePast(DateTime dateTime)
        {
            DateTime dateTimeNow = DateTime.Now;
            if (dateTimeNow <= dateTime) return false;
            return true;
        }

        public static bool IsHomePhoneValid(string homePhone)
        {
            Regex phone = new Regex(@"[01-9]{8,11}");
            if (phone.IsMatch(homePhone) || homePhone == "" || homePhone == null) return true;
            return false;
        }

        public static bool AreAllergiesValid(List<string> allergies)
        {
            Regex pattern = new Regex(@"[A-Za-z]{1,20}");
            if (allergies == null || allergies.Count == 0) return true;
            foreach (string allergy in allergies)
            {
                if (!pattern.IsMatch(allergy)) return false;
            }
            return true;
        }
    }
}
