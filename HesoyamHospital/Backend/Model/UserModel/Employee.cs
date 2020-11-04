// File:    Employee.cs
// Author:  Geri
// Created: 18. april 2020 19:35:17
// Purpose: Definition of Class Employee

using System;

namespace Backend.Model.UserModel
{
    public class Employee : User
    {
        private TimeTable _timeTable;
        public TimeTable TimeTable { get => _timeTable; set { _timeTable = value; _timeTableID = value.Id; } }

        private long _timeTableID;
        public long TimeTableID { get => _timeTableID; set => _timeTableID = value; }

        private Hospital _hospital;
        public Hospital Hospital
        {
            get
            {
                return _hospital;
            }
            set
            {
                if (_hospital == null || !_hospital.Equals(value))
                {
                    if (_hospital != null)
                    {
                        Hospital oldHospital = _hospital;
                        _hospital = null;
                        oldHospital.RemoveEmployee(this);
                    }
                    if (value != null)
                    {
                        _hospital = value;
                        _hospitalID = value.Id;
                        _hospital.AddEmployee(this);
                    }
                }
            }
        }

        private long _hospitalID;
        public long HospitalID { get => _hospitalID; set => _hospitalID = value; }

        public Employee() : base() { }
        public Employee(long id) : base(id) { }

        public Employee(TimeTable timeTable, 
                        Hospital hospital, 
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
                        string email2) 
            : base(userName, password, dateCreated, name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            _timeTable = timeTable;
            _timeTableID = timeTable.Id;
            _hospital = hospital;
            _hospitalID = hospital.Id;
        }

        public Employee(TimeTable timeTable,
                        Hospital hospital,
                        string userName,
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
                        string email2)
            : base(userName, password, name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            _timeTable = timeTable;
            _timeTableID = timeTable.Id;
            _hospital = hospital;
            _hospitalID = hospital.Id;
        }

        public Employee(long id,
                        UserID uid, 
                        TimeTable timeTable, 
                        Hospital hospital, 
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
                        string email2) 
            : base(id, uid, userName, password, dateCreated, name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            _timeTable = timeTable;
            _timeTableID = timeTable.Id;
            _hospital = hospital;
            _hospitalID = hospital.Id;
        }
    }
}