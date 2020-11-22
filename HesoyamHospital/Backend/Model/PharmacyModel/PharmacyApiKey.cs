using Backend.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.PharmacyModel
{
    public class PharmacyApiKey : IIdentifiable<long>
    {
        public long Id { get; private set; }
        public string ApiKey { get; private set; }
        [Key]
        public string PharmacyName { get; set; }

        public PharmacyApiKey(string apiKey, string pharmacyName)
        {
            ApiKey = apiKey;
            PharmacyName = pharmacyName;
        }
        public PharmacyApiKey() { }

        public long GetId()
        {
            return Id;
        }

        public void SetId(long id)
        {
            Id = id;
        }
    }
}
