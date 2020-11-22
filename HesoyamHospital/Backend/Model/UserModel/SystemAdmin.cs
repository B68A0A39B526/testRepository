using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Model.UserModel
{
    public class SystemAdmin : User
    {
        public SystemAdmin(long id) : base(id)
        {
        }

        public SystemAdmin(string userName,
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

        }
    }
}
