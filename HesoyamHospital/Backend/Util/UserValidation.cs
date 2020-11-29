using Backend.Exceptions;
using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Backend.Util;

namespace Backend.Util
{
    public class UserValidation : IUserValidation
    {
        public void Validate(User user)
        {
            CheckUsername(user.UserName);
            CheckPassword(user.Password);
                
        }

        public void CheckUsername(string username)
        {
            if (!Regex.IsMatch(username, Regexes.usernameRegex))
            {
                throw new InvalidUserException("Invalid username!");
            }
        }

        public void CheckPassword(string password)
        {
            if (!Regex.IsMatch(password, Regexes.passwordRegex))
            {
                throw new InvalidUserException("Invalid password!");
            }
        }

        public void CheckName(string name)
        {
            if (Regex.IsMatch(name, Regexes.illegalNameCharactersRegex))
            {
                throw new InvalidUserException("Invalid name!");
            }
        }

        public void CheckDateOfBirth(DateTime date)
        {
            if(DateTime.Now < date)
            {
                throw new InvalidUserException("Invalid date of birth!");
            }
        }

        public void CheckPhoneNumber(string phoneNumber)
        {
            if(!Regex.IsMatch(phoneNumber, Regexes.phoneRegex))
            {
                throw new InvalidUserException("Invalid phone number!");
            }
        }

    }
}
