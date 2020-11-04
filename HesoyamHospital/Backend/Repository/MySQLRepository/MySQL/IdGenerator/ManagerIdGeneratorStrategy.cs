using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository.MySQLRepository.MySQL.IdGenerator
{
    class ManagerIdGeneratorStrategy : IIdGeneratorStrategy<Manager, long>
    {
        public long GetMaxId(IEnumerable<Manager> entities)
        => entities.Count() == 0 ? 0 : entities.Max(entity => entity.GetId());
    }
}
