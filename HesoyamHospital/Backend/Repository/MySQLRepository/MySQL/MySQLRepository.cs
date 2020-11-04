using Backend.Exceptions;
using Backend.Repository.Abstract;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using Backend.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.MySQLRepository.MySQL
{
    public class MySQLRepository<T, ID> : IRepository<T, ID>, IEagerRepository<T, ID>
        where T : IIdentifiable<ID>
        where ID : IComparable
    {
        private const string NOT_FOUND_ERROR = "{0} with {1}:{2} can not be found!";

        public string _entityName;
        public IMySQLStream<T> _stream;
        public ISequencer<ID> _sequencer;
        public IIdGeneratorStrategy<T, ID> _idGeneratorStrategy;

        public MySQLRepository(string entityName, IMySQLStream<T> stream, ISequencer<ID> sequencer, IIdGeneratorStrategy<T, ID> idGeneratorStrategy)
        {
            _entityName = entityName;
            _stream = stream;
            _sequencer = sequencer;
            _idGeneratorStrategy = idGeneratorStrategy;
            InitializeId();
        }

        public ID GetMaxId(IEnumerable<T> entities)
            => _idGeneratorStrategy.GetMaxId(entities);

        public void InitializeId()
            => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

        public T Create(T entity)
        {
            entity.SetId(_sequencer.GenerateID());
            _stream.Append(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            var entities = _stream.ReadAll().ToList();
            var entityToRemove = entities.SingleOrDefault(ent => ent.GetId().CompareTo(entity.GetId()) == 0);
            if (entityToRemove != null)
            {
                entities.Remove(entityToRemove);
                _stream.SaveAll();
            }
            else
            {
                ThrowEntityNotFoundException("id", entity.GetId());
            }
        }

        public IEnumerable<T> Find(ISpecification<T> criteria)
            => _stream.ReadAll().Where(o => criteria.IsSatisfiedBy(o));

        public IEnumerable<T> GetAll()
            => _stream.ReadAll();

        public IEnumerable<T> GetAllEager(string[] includeProperties)
            => _stream.ReadAllEager(includeProperties);

        public T GetByID(ID id)
        {
            try
            {
                return _stream
                    .ReadAll()
                    .SingleOrDefault(entity => entity.GetId().CompareTo(id) == 0);
            }
            catch (ArgumentException)
            {
                throw new EntityNotFoundException(string.Format(NOT_FOUND_ERROR, _entityName, "id", id));
            }
        }

        public T GetEager(ID id, string[] includeProperties)
            => GetAllEager(includeProperties).Where(entity => entity.GetId().CompareTo(id) == 0).FirstOrDefault();

        public void Update(T entity)
        {
            try
            {
                var entities = _stream.ReadAll().ToList();
                entities[entities.FindIndex(ent => ent.GetId().CompareTo(entity.GetId()) == 0)] = entity;
                _stream.SaveAll();
            }
            catch (ArgumentException)
            {
                ThrowEntityNotFoundException("id", entity.GetId());
            }
        }

        private void ThrowEntityNotFoundException(string key, object value)
          => throw new EntityNotFoundException(string.Format(NOT_FOUND_ERROR, _entityName, key, value));
    }
}
