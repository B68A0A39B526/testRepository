using Backend.Model.PharmacyModel;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.MySQLRepository.MiscRepository
{
    public class PharmacyApiKeyRepository : MySQLRepository<PharmacyApiKey, long>
    {
        private const string ENTITY_NAME = "PharmacyApiKey";
        public PharmacyApiKeyRepository(IMySQLStream<PharmacyApiKey> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<PharmacyApiKey>())
        {
        }
    }
}
