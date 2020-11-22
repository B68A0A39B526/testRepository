using Backend.Exceptions;
using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Util
{
    public class SecretaryPatientValidation : UserValidation
    {
        public new void Validate(User user)
        {
            CheckUsername(user.UserName);
            CheckName(user.Name);
            CheckSurname(user.Surname);
        }

        public new void CheckUsername(string username)
        {
            if(string.IsNullOrEmpty(username))
                throw new InvalidUserException("Invalid username!");
        }

        public new void CheckName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new InvalidUserException("Invalid name!");
        }

        public void CheckSurname(string surname)
        {
            if (string.IsNullOrEmpty(surname))
                throw new InvalidUserException("Invalid surname!");
        }
    }
}
