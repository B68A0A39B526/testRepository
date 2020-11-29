using Backend.Model.PharmacyModel;
using Backend.Repository.Abstract.MiscAbstractRepository;
using Backend.Service.MiscService;
using IntegrationAdapterTests.Unit;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace IntegrationAdapterTests
{
    public class PharmacyVerificationTests
    {
        [Fact]
        public void Check_if_registered_pharmacy_contains_api_key()
        {
            RegisteredPharmacyService service = new RegisteredPharmacyService(RegisteredPharmacyStubRepository.CreateRepository());

            AssertApiKey((List<RegisteredPharmacy>)service.GetAll());
        }

        private static void AssertApiKey(List<RegisteredPharmacy> registeredPharmacies)
        {
            foreach (RegisteredPharmacy rp in registeredPharmacies)
            {
                rp.ApiKey.ShouldNotBeEmpty();
            }
        }

        [Fact]
        public void Check_if_registered_pharmacy_contains_endpoint()
        {
            RegisteredPharmacyService service = new RegisteredPharmacyService(RegisteredPharmacyStubRepository.CreateRepository());

            AssertEndpoints((List<RegisteredPharmacy>)service.GetAll());
        }

        private static void AssertEndpoints(List<RegisteredPharmacy> registeredPharmacies)
        {
            foreach (RegisteredPharmacy rp in registeredPharmacies)
            {
                rp.Endpoint.ShouldNotBeEmpty();
            }
        }
    }
}
