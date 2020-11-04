using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository.MySQLRepository.MySQL.IdGenerator
{
    class SecretaryIdGeneratorStrategy : IIdGeneratorStrategy<Secretary, long>
    {
        public long GetMaxId(IEnumerable<Secretary> entities)
            => entities.Count() == 0 ? 0 : entities.Max(entity => entity.GetId());
    }
}
