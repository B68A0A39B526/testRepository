using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System.Net;
using Xunit;
using WebApplication;
using System.Net.Http;
using WebApplication.Documents;
using System;
using Backend.Util;
using System.Collections.Generic;
using Newtonsoft.Json;
using Backend.Model.UserModel;
using WebApplication.HospitalSurvey;

namespace WebApplicationTests.Integration.HospitalSurvey
{
    public class SendAnswersTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public SendAnswersTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async void Sending_answers_status_code_tests(SurveyDTO dto, HttpStatusCode expectedStatusCode)
        {
            HttpClient client = _factory.CreateClient();
            StringContent bodyContent = new StringContent(JsonConvert.SerializeObject(dto), System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("/api/survey/send-answers", bodyContent);
            
            response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
          
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] {null, HttpStatusCode.BadRequest},
            new object[] { new SurveyDTO( 1, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5),  HttpStatusCode.OK },
            new object[] { new SurveyDTO( 1, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 8),  HttpStatusCode.BadRequest }
        };

    }
}
