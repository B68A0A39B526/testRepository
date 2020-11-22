using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.MySQLRepository.MySQL.Stream
{
    public interface IMySQLStream<T>
    {
        void SaveAll();

        IEnumerable<T> ReadAll();

        IEnumerable<T> ReadAllEager(string[] includeProperties);

        void Append(T entity);

        void Update(T entity);
    }
}
