using Backend.Model.PatientModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.MedicalRecords
{
    public static class MedicalRecordMapper
    {
        public static MedicalRecordDTO MedicalRecordToMedicalRecordDTO(MedicalRecord medicalRecord)
        {
            MedicalRecordDTO dto = new MedicalRecordDTO
            {
                FirstName = medicalRecord.Patient.Name,
                LastName = medicalRecord.Patient.Surname,
                MiddleName = medicalRecord.Patient.MiddleName,
                Address = medicalRecord.Patient.Address.ToString(),
                DateOfBirth = medicalRecord.Patient.DateOfBirth.ToString("d", CultureInfo.CreateSpecificCulture("de-DE")),
                MedicalId = medicalRecord.Patient.HealthCardNumber,
                PersonalId = medicalRecord.Patient.Jmbg,
                MobilePhone = medicalRecord.Patient.CellPhone,
                HomePhone = medicalRecord.Patient.HomePhone,
                Email = medicalRecord.Patient.Email1,
                Username = medicalRecord.Patient.UserName,
                Password = medicalRecord.Patient.Password,
                BloodType = medicalRecord.BloodTypeToString(medicalRecord.PatientBloodType),
                Alergies = medicalRecord.AllergiesListToString(medicalRecord.Allergy),
                Prescriptions = PrescriptionListToPrescriptionDTOList(medicalRecord.Prescriptions),

            };

            return dto;
        }

        public static List<PrescriptionDTO> PrescriptionListToPrescriptionDTOList(List<Prescription> prescriptions) {
            List<PrescriptionDTO> prescriptionDTOs = new List<PrescriptionDTO>();
            List<string> medicine = new List<string>();

            foreach (Prescription p in prescriptions) {
                foreach (MedicalTherapy mt in p.MedicalTherapies) {
                    medicine.Add(mt.Medicine.Name);
                }
                PrescriptionDTO prescDto = new PrescriptionDTO(medicine, p.StatusToString(p.Status));
                prescriptionDTOs.Add(prescDto);
            }
            return prescriptionDTOs;
        }
    }
}
