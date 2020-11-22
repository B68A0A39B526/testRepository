using Backend.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository.MySQLRepository.MySQL.IdGenerator
{
    class LongIdGeneratorStrategy<T> : IIdGeneratorStrategy<T, long>
        where T : IIdentifiable<long>
    {
        public long GetMaxId(IEnumerable<T> entities)
        => entities.Count() == 0 ? 0 : entities.Max(entity => entity.GetId());
    }
}
