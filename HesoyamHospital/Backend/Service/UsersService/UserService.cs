using Backend.Model.UserModel;
using Backend.Repository.MySQLRepository.UsersRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service.UsersService
{
    public class UserService : IService<User, long>, IUserService<User>
    {
        private UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Create(User entity)
            => _userRepository.Create(entity);

        public void Delete(User entity)
        {
            entity.Deleted = true;
            Update(entity);
        }

        public IEnumerable<User> GetAll()
            => _userRepository.GetAll();

        public User GetByID(long id)
            => _userRepository.GetByID(id);

        public void Login(string username, string password)
        {
            User user = _userRepository.GetByUsername(username);

            CheckUserCredentials(user, password);
            //AppResources.getInstance().loggedInUser = user;
            LoadUserResources(user);
        }

        private void LoadUserResources(User user)
        {
            switch (user.GetUserType())
            {
                case UserType.DOCTOR:
                    {
                        //AppResources.getInstance().LoadDoctorResources();
                        break;
                    }
                case UserType.MANAGER:
                    {
                        //AppResources.getInstance().LoadManagerResources();
                        break;
                    }
                case UserType.PATIENT:
                    {
                        //AppResources.getInstance().LoadPatientResources();
                        break;
                    }
                case UserType.SECRETARY:
                    {
                        //AppResources.getInstance().LoadSecretaryResources();
                        break;
                    }
            }
        }

        private void CheckUserCredentials(User user, string password)
        {
            if (user == null)
                throw new InvalidLoginException("User not found");

            if (user.Password != password)
                throw new InvalidLoginException("Username/password is not correct");
        }

        public void Update(User entity)
            => _userRepository.Update(entity);

        public void Validate(User entity)
        {
            //throw new NotImplementedException();
        }
    }
}
