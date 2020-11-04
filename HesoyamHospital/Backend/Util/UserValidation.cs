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
            CheckDateOfBirth(user.DateOfBirth);
            CheckEmail(user.Email1);
            CheckEmail(user.Email2);
            CheckName(user.Name);
            CheckUsername(user.UserName);
            CheckPassword(user.Password);
            CheckPhoneNumber(user.CellPhone); 
            CheckPhoneNumber(user.HomePhone);
            CheckUidn(user.Uidn);
                
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

        public void CheckUidn(string uidn)
        {
            if(!Regex.IsMatch(uidn, Regexes.uidnRegex))
            {
                throw new InvalidUserException("Invalid UIDN!");
            }
        }

        public void CheckDateOfBirth(DateTime date)
        {
            if(DateTime.Now < date)
            {
                throw new InvalidUserException("Invalid date of birth!");
            }
        }

        public void CheckEmail(string email)
        {
            if(!Regex.IsMatch(email, Regexes.emailRegex))
            {
                throw new InvalidUserException("Invalid email!");
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
