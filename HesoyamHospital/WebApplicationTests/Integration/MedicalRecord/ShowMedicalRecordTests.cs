using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System.Net;
using Xunit;
using WebApplication;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using Backend.Model.PatientModel;
using System;

namespace WebApplicationTests.Integration.MedicalRecords
{
    public class ShowMedicalRecordTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ShowMedicalRecordTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async void Medical_Record_Status_Code_Test(long id, HttpStatusCode expectedStatusCode)
        {
            HttpClient client = _factory.CreateClient();
            
            var response = await client.GetAsync("/api/medicalrecord/show/"+ id );

            response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] {500, HttpStatusCode.OK},
            new object[] { 400, HttpStatusCode.NotFound}
            
        };
    }
}
