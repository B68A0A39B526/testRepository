using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.MySQLRepository.MySQL
{
    public interface IEagerRepository<T, ID>
    {
        T GetEager(ID id);

        IEnumerable<T> GetAllEager();
    }
}
