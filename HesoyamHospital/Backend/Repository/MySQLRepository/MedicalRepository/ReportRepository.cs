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
    public class ReportRepository : MySQLRepository<Report, long>, IReportRepository
    {
        private const string ENTITY_NAME = "Report";
        public ReportRepository(IMySQLStream<Report> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Report>())
        {
        }
    }
}
