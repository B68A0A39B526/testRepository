using Castle.DynamicProxy.Generators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.MySQLRepository.MySQL.Stream
{
    public class MySQLStream<T> : IMySQLStream<T> where T : class
    {
        private MyDbContext dbContext;
        public MySQLStream()
        {
            this.dbContext = new MyDbContext();
        }
        public void Append(T entity)
        {
            dbContext.Set<T>().Add(entity);
            SaveAll();
        }

        public IEnumerable<T> ReadAll()
            => dbContext.Set<T>();

        public IEnumerable<T> ReadAllEager(string[] includeProperties)
        {
            IQueryable<T> query = dbContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.ToList();
        }

        public void SaveAll()
        {
            dbContext.SaveChanges();
        }
    }
}
