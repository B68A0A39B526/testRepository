using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.Abstract.MedicalAbstractRepository;
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

namespace Backend.Repository.MySQLRepository.MedicalRepository
{
    public class PrescriptionRepository : MySQLRepository<Prescription, long>, IPrescriptionRepository, IEagerRepository<Prescription, long>
    {
        private const string ENTITY_NAME = "Prescription";
        private string[] INCLUDE_PROPERTIES = { "Doctor", "Medicine" };

        public PrescriptionRepository(IMySQLStream<Prescription> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Prescription>())
        {
        }

        public IEnumerable<Prescription> GetAllEager()
             => GetAllEager(INCLUDE_PROPERTIES);

        public Prescription GetEager(long id)
            => GetAllEager().SingleOrDefault(prescription => prescription.GetId() == id);
    }
}
