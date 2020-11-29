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
    public class ActivationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ActivationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async void Account__activation_by_id(long id, HttpStatusCode expectedStatusCode)
        {
            HttpClient client = _factory.CreateClient();
            string prefix = "acdxFDRhijklmno88st3";
            string path = "/api/registration/activate/" + prefix + id.ToString();

            HttpResponseMessage response = await client.PostAsync(path, null);

            response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        }


        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { 1, HttpStatusCode.BadRequest },
            new object[] { 501, HttpStatusCode.OK }
        };
    }
}
