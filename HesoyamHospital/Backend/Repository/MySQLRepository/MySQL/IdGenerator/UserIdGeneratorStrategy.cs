using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository.MySQLRepository.MySQL.IdGenerator
{
    class UserIdGeneratorStrategy : IIdGeneratorStrategy<User, long>
    {
        public long GetMaxId(IEnumerable<User> entities)
        {
            //TODO: User ID Generator Note:
            //UserRepository never calls this method because every patient's, manager's, secretary's and doctor's ID is generated in their respective generators.
            return 0;
        }
    }
}
