using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Authentication
{
    public static class NewPatientMapper
    {
        public static Patient NewPatientDTOToPatient(NewPatientDTO dto)
        {
            Address address = new Address(dto.Address, new Location(dto.Country, dto.City));
            Sex sex = GenderToEnum(dto.Gender);
            return new Patient(dto.Username, dto.Password, dto.Name, dto.Surname, dto.MiddleName, dto.Jmbg, sex, dto.DateOfBirth, "300", address, dto.HomePhone, dto.MobilePhone, dto.Email, dto.HealthCardNumber);
        }

        public static MedicalRecord NewPatientDTOToMedicalRecord(NewPatientDTO dto)
        {
            List<Allergy> allergies = MakeAllergiesList(dto.Allergies);
            BloodType bloodType = BloodTypeToEnum(dto.BloodType);
            Patient patient = NewPatientDTOToPatient(dto);

            return new MedicalRecord(patient, bloodType, allergies);
        }

        public static List<Allergy> MakeAllergiesList(List<string> allergiesNames)
        {
            List<Allergy> allergies = new List<Allergy>();
            if (allergiesNames == null) return allergies;

            foreach (string allergyName in allergiesNames)
            {
                Allergy alle = new Allergy();
                alle.Name = allergyName;
                allergies.Add(alle);
            }
            return allergies;
        }

        public static Sex GenderToEnum(string gender)
        {
            try
            {
                Sex sex = (Sex)Enum.Parse(typeof(Sex), gender, false);
                if (Enum.IsDefined(typeof(Sex), sex))
                    return sex;
                else
                    return Sex.OTHER;
            }
            catch (ArgumentException)
            {
                return Sex.OTHER;
            }
        }

        public static BloodType BloodTypeToEnum(string bloodType)
        {
            try
            {
                BloodType bloodTypeEnum = (BloodType)Enum.Parse(typeof(BloodType), bloodType, false);
                if (Enum.IsDefined(typeof(BloodType), bloodTypeEnum))
                    return bloodTypeEnum;
                else
                    return BloodType.NOT_TESTED;
            }
            catch (ArgumentException)
            {
                return BloodType.NOT_TESTED;
            }
        }
    }
}
