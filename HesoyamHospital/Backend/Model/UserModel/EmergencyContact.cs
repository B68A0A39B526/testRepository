using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model.UserModel
{
    public class EmergencyContact
    {
        private long _id;
        public long Id { get => _id; set => _id = value; }

        private string _name;
        public string Name { get => _name; set => _name = value; }

        private string _surname;
        public string Surname { get => _surname; set => _surname = value; }

        private string _email;
        public string Email { get => _email; set => _email = value; }

        private string _phoneNumber;
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }


        public EmergencyContact(string name, string surname, string email, string phoneNumber)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _phoneNumber = phoneNumber;
        }

        public EmergencyContact() { }

    }
}
