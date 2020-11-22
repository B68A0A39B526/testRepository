using Castle.DynamicProxy.Generators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Backend.Repository.MySQLRepository.MySQL.Stream
{
    public class MySQLStream<T> : IMySQLStream<T> where T : class
    {
        private static MyDbContext dbContext = new MyDbContext();
        public MySQLStream()
        {
        }
        public void Append(T entity)
        {
            var ret = dbContext.Set<T>().Attach(entity);
            ret.State = EntityState.Added;
            SaveAll();
        }

        public void Update(T entity)
        {
            //dbContext.Set<T>().Attach(entity);
            //dbContext.Entry(entity).State = EntityState.Modified;
            SaveAll();
        }

        public IEnumerable<T> ReadAll()
            => dbContext.Set<T>();

        public IEnumerable<T> ReadAllEager(string[] includeProperties)
        {
            /*
            IQueryable<T> query = dbContext.Set<T>();
            IQueryable<T> test = dbContext.Set<T>();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var c = properties.FirstOrDefault(c => c.Name == property.Name + "Id" 
                || c.Name == property.Name + "ID"
                || c.Name == property.Name + "id");
                if (c != null)
                {
                    test = query.Include(property.Name);
                }
            }
            return query.ToList();
            */
            return ReadAll();
        }

        public void SaveAll()
        {
            dbContext.SaveChanges();
        }
    }
}
