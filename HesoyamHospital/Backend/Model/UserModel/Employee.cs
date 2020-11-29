// File:    Employee.cs
// Author:  Geri
// Created: 18. april 2020 19:35:17
// Purpose: Definition of Class Employee

using System;

namespace Backend.Model.UserModel
{
    public class Employee : User
    {
        public virtual TimeTable TimeTable { get; set; }
        private Hospital _hospital;
        public virtual Hospital Hospital
        {
            get { return _hospital; }
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
                        _hospital.AddEmployee(this);
                    }
                }
            }
        }

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
                        string jmbg,
                        Sex sex, 
                        DateTime dateOfBirth, 
                        string uidn, 
                        Address address, 
                        string homePhone, 
                        string cellPhone, 
                        string email1, 
                        string email2) 
            : base(userName, password, dateCreated, name, surname, middleName, jmbg, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            TimeTable = timeTable;
            Hospital = hospital;
        }

        public Employee(TimeTable timeTable,
                        Hospital hospital,
                        string userName,
                        string password,
                        string name,
                        string surname,
                        string middleName,
                        string jmbg,
                        Sex sex,
                        DateTime dateOfBirth,
                        string uidn,
                        Address address,
                        string homePhone,
                        string cellPhone,
                        string email1,
                        string email2)
            : base(userName, password, name, surname, middleName, jmbg, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            TimeTable = timeTable;
            Hospital = hospital;
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
                        string jmbg,
                        Sex sex, 
                        DateTime dateOfBirth, 
                        string uidn, 
                        Address address, 
                        string homePhone, 
                        string cellPhone, 
                        string email1, 
                        string email2) 
            : base(id, uid, userName, password, dateCreated, name, surname, middleName, jmbg, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            TimeTable = timeTable;
            Hospital = hospital;
        }
    }
}