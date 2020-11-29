using System.Collections.Generic;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using IntegrationAdapter;
using Backend.Model.PharmacyModel;
using System.Net;
using System.Net.Http;
using Shouldly;
using Xunit.Abstractions;
using System.Text.Json;
using System.Text;

namespace IntegrationAdapterTests.Integration
{
    public class RegisterPharmacyTests : IClassFixture<WebApplicationFactory<Startup>>
    {

        private readonly WebApplicationFactory<Startup> _factory;
        public RegisterPharmacyTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Theory]
        [MemberData(nameof(Data))]
        public async void Checks_pharmacy_registration_status_code_based_on_data(RegisteredPharmacy pharmacy, HttpStatusCode expectedStatusCode)
        {
            var client = _factory.CreateClient();
           
            StringContent body = new StringContent(JsonSerializer.Serialize(pharmacy), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/registerpharmacy", body);

            response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        }
        public static IEnumerable<object[]> Data()
        {
            List<object[]> retVal = new List<object[]>();

            retVal.Add(new object[] { new RegisteredPharmacy(pharmacyName: "", apiKey: "apikey123", endpoint: "example.org/api"), HttpStatusCode.BadRequest });
            retVal.Add(new object[] { new RegisteredPharmacy(pharmacyName: "Pharmacy1", apiKey: "", endpoint: "example.org/api2"), HttpStatusCode.BadRequest });
            retVal.Add(new object[] { new RegisteredPharmacy(pharmacyName: "Pharmacy2", apiKey: "asdqwezxc", endpoint: ""), HttpStatusCode.BadRequest });

            return retVal;
        }
    }
}
