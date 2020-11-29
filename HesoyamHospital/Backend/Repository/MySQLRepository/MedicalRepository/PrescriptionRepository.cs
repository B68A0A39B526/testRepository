using Backend.Model.PatientModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repository.MySQLRepository.MedicalRepository
{
    public class PrescriptionRepository : MySQLRepository<Prescription, long>, IPrescriptionRepository
    {
        private const string ENTITY_NAME = "Prescription";

        public PrescriptionRepository(IMySQLStream<Prescription> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Prescription>())
        {
        }

        public IEnumerable<Prescription> GetAllByPatient(long patientId)
            => GetAll().Where(presctiprion => presctiprion.Patient.Id == patientId).ToList();
    }
}
