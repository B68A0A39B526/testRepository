/***********************************************************************
 * Module:  Patient.cs
 * Author:  nikola
 * Purpose: Definition of the Class Patient
 ***********************************************************************/

using Backend.Model.PatientModel;
using System;
using System.Collections.Generic;

namespace Backend.Model.UserModel
{
    public class Patient : User
    {
        private PatientType _patientType;
        public PatientType PatientType { get => _patientType; set => _patientType = value; }

        //public MedicalRecord medicalRecord;

        private EmergencyContact _emergencyContact;
        public EmergencyContact EmergencyContact { get => _emergencyContact; set { _emergencyContact = value; _emergencyContactID = value.Id; } }

        private long _emergencyContactID;
        public long EmergencyContactID { get => _emergencyContactID; set => _emergencyContactID = value; }

        private Doctor _selectedDoctor;
        public Doctor SelectedDoctor { get => _selectedDoctor; set { _selectedDoctor = value; _selectedDoctorID = value.Id; } }

        private long _selectedDoctorID;
        public long SelectedDoctorID { get => _selectedDoctorID; set => _selectedDoctorID = value; }

        public Patient(long id) : base(id) { }
        
        public Patient( string userName, 
                        string password, 
                        DateTime dateCreated, 
                        string name, 
                        string surname, 
                        string middleName, 
                        Sex sex, 
                        DateTime dateOfBirth, 
                        string uidn, 
                        Address address, 
                        string homePhone, 
                        string cellPhone, 
                        string email1, 
                        string email2, 
                        EmergencyContact emergencyContact, 
                        PatientType patientType, 
                        Doctor selectedDoctor) 
            : base(userName, password, dateCreated, name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            _patientType = patientType;
            _selectedDoctor = selectedDoctor;
            _emergencyContact = emergencyContact;
            _selectedDoctorID = selectedDoctor.Id;
            _emergencyContactID = emergencyContact.Id;
        }

        public Patient(string userName,
                        string password,
                        string name,
                        string surname,
                        string middleName,
                        Sex sex,
                        DateTime dateOfBirth,
                        string uidn,
                        Address address,
                        string homePhone,
                        string cellPhone,
                        string email1,
                        string email2,
                        EmergencyContact emergencyContact,
                        PatientType patientType,
                        Doctor selectedDoctor)
            : base(userName, password, name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            _patientType = patientType;
            _selectedDoctor = selectedDoctor;
            _emergencyContact = emergencyContact;
            _selectedDoctorID = selectedDoctor.Id;
            _emergencyContactID = emergencyContact.Id;
        }

        public Patient( long id,
                        UserID uid, 
                        string userName, 
                        string password, 
                        DateTime dateCreated, 
                        string name, 
                        string surname, 
                        string middleName, 
                        Sex sex, 
                        DateTime dateOfBirth, 
                        string uidn, 
                        Address address, 
                        string homePhone, 
                        string cellPhone, 
                        string email1, 
                        string email2, 
                        EmergencyContact emergencyContact, 
                        PatientType patientType, 
                        Doctor selectedDoctor) 
            : base(id, uid, userName, password, dateCreated, name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            _patientType = patientType;
            _selectedDoctor = selectedDoctor;
            _emergencyContact = emergencyContact;
            _selectedDoctorID = selectedDoctor.Id;
            _emergencyContactID = emergencyContact.Id;
        }
    }
}