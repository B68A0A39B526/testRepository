using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System.Net;
using Xunit;
using WebApplication;
using System.Net.Http;
using System;
using Backend.Util;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using WebApplication.Authentication;

namespace WebApplicationTests.Integration.Authentication
{
    public class RegistrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public RegistrationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async void Registration_tests(NewPatientDTO newPatient, HttpStatusCode expectedStatusCode)
        {
            HttpClient client = _factory.CreateClient();
            StringContent bodyContent = new StringContent(JsonConvert.SerializeObject(newPatient), System.Text.Encoding.UTF8, "application/json");
            
            HttpResponseMessage response = await client.PostAsync("/api/registration", bodyContent);

            response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { null, HttpStatusCode.BadRequest },
            new object[] { new NewPatientDTO("Emina", "Turkovic", "Mirsad", "FEMALE", "team.psw18@gmail.com", new SendEmail().RandomString(10, false), "perapera", new DateTime(1998, 11, 9), "27100785057", "0911998777025", "0605552233", "033244377", "A_NEGATIVE", new List<string>(), "Serbia", "Priboj", "Alekse Santica 4"), HttpStatusCode.OK },
            new object[] { new NewPatientDTO("Emina", "Turkovic", "Mirsad", "FEMALE", "team.psw18@gmail.com", "milijanadj", "perapera", new DateTime(1998, 11, 9), "27100785057", "0911998777025", "0605552233", "033244377", "A_NEGATIVE", new List<string>(), "Serbia", "Priboj", "Alekse Santica 4"), HttpStatusCode.BadRequest }
        };
    }
}
