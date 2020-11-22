using Backend.Model.PharmacyModel;
using Backend.Repository.MySQLRepository.MiscRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.MiscService
{
    public class PharmacyApiKeyService : IService<PharmacyApiKey, long>
    {
        private PharmacyApiKeyRepository _pharmacyApiKeyRepository;

        public PharmacyApiKeyService(PharmacyApiKeyRepository pharmacyApiKeyRepository)
        {
            _pharmacyApiKeyRepository = pharmacyApiKeyRepository;
        }
        public PharmacyApiKey Create(PharmacyApiKey entity)
        {
            return _pharmacyApiKeyRepository.Create(entity);
        }

        public void Delete(PharmacyApiKey entity)
        {
            _pharmacyApiKeyRepository.Delete(entity);
        }

        public IEnumerable<PharmacyApiKey> GetAll()
        {
            return _pharmacyApiKeyRepository.GetAll();
        }

        public PharmacyApiKey GetByID(long id)
        {
            return _pharmacyApiKeyRepository.GetByID(id);
        }

        public PharmacyApiKey GetByPharmacyName(string name)
        {
            return _pharmacyApiKeyRepository.GetAll().FirstOrDefault(apiKey => apiKey.PharmacyName.Equals(name));
        }

        public void Update(PharmacyApiKey entity)
        {
            throw new NotImplementedException();
        }

        public void Validate(PharmacyApiKey entity)
        {
            throw new NotImplementedException();
        }
    }
}
