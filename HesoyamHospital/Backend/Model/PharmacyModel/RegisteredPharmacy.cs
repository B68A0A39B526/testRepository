using Backend.Repository.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Model.PharmacyModel
{
    public class RegisteredPharmacy : IIdentifiable<long>
    {
        [JsonIgnore]
        public long Id { get; set; }
        [Required]
        public string ApiKey { get; set; }
        [Key]
        [Required]
        public string PharmacyName { get; set; }
        [Required]
        public string Endpoint { get; set; }
        public RegisteredPharmacy(string apiKey, string pharmacyName, string endpoint)
        {
            ApiKey = apiKey;
            PharmacyName = pharmacyName;
            Endpoint = endpoint;
        }
        public RegisteredPharmacy() { }

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
