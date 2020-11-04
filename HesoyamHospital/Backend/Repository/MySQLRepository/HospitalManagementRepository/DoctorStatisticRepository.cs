using Backend.Model.ManagerModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository.MySQLRepository.HospitalManagementRepository
{
    public class DoctorStatisticRepository : MySQLRepository<StatsDoctor, long>, IDoctorStatisticRepository, IEagerRepository<StatsDoctor, long>
    {
        private const string ENTITY_NAME = "Doctor Statistics Repository";
        private string[] INCLUDE_PROPERTIES = {"Doctor"};
        public DoctorStatisticRepository(IMySQLStream<StatsDoctor> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<StatsDoctor>()) { }

        public IEnumerable<StatsDoctor> GetAllEager()
            => GetAllEager(INCLUDE_PROPERTIES);

        public IEnumerable<StatsDoctor> GetDoctorStatistics()
            => GetAll();

        public StatsDoctor GetEager(long id)
            => GetAllEager().SingleOrDefault(stat => stat.GetId() == id);

        public IEnumerable<StatsDoctor> GetStatisticsByDoctor(Doctor doctor)
            => GetAll().Where(stat => stat.Doctor.GetId().Equals(doctor));
    }
}
