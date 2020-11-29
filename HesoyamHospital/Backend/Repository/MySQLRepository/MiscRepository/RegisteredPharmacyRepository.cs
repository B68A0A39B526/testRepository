using Backend.Model.PharmacyModel;
using Backend.Repository.Abstract.MiscAbstractRepository;
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
    public class RegisteredPharmacyRepository : MySQLRepository<RegisteredPharmacy, long>, IRegisteredPharmacyRepository
    {
        private const string ENTITY_NAME = "RegisteredPharmacy";
        public RegisteredPharmacyRepository(IMySQLStream<RegisteredPharmacy> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<RegisteredPharmacy>())
        {
        }
        public RegisteredPharmacy GetRegisteredPharmacyByName(string pharmacyName)
            => GetAll().SingleOrDefault(pharmacy => pharmacy.PharmacyName.Equals(pharmacyName));
    }
}
