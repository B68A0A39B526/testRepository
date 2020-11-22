// File:    Person.cs
// Author:  Geri
// Created: 18. april 2020 19:35:17
// Purpose: Definition of Class Person

using System;

namespace Backend.Model.UserModel
{
    public class Person
    {
        private string _uidn;
        public string Uidn { get => _uidn; set => _uidn = value; }

        private string _name;
        public string Name { get => _name; set => _name = value; }

        private string _surname;
        public string Surname { get => _surname; set => _surname = value; }

        private string _middleName;
        public string MiddleName { get => _middleName; set => _middleName = value; }

        private DateTime _dateOfBirth;
        public DateTime DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }

        private string _homePhone;
        public string HomePhone { get => _homePhone; set => _homePhone = value; }

        private string _cellPhone;
        public string CellPhone { get => _cellPhone; set => _cellPhone = value; }

        private string _email1;
        public string Email1 { get => _email1; set => _email1 = value; }

        private string _email2;
        public string Email2 { get => _email2; set => _email2 = value; }

        private Address _address;
        public Address Address { get => _address; set { _address = value; _addressID = value.Id; } }

        private long _addressID;
        public long AddressID { get => _addressID; set => _addressID = value; }

        private Sex _sex;
        public Sex Sex { get => _sex; set => _sex = value; }

        public string FullName
        {
            get
            {
                if (_middleName != null && _middleName.Equals(""))
                    return _name + " " + _surname;
                else
                    return _name + " " + _middleName + " " + _surname;
            }
        }

        public Person() { }
        public Person(  string name, 
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
        {
            _name = name;
            _surname = surname;
            _middleName = middleName;
            _sex = sex;
            _dateOfBirth = dateOfBirth;
            _uidn = uidn;
            _address = address;
            _addressID = address.Id;
            _homePhone = homePhone;
            _cellPhone = cellPhone;
            _email1 = email1;
            _email2 = email2;
        }
    }
}