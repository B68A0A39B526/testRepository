using Backend.Model.PharmacyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.Abstract.MiscAbstractRepository
{
    public interface IRegisteredPharmacyRepository : IRepository<RegisteredPharmacy, long>
    {
        RegisteredPharmacy GetRegisteredPharmacyByName(string pharmacyName);
    }
}
