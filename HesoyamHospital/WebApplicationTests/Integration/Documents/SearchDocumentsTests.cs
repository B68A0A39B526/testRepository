using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System.Net;
using Xunit;
using WebApplication;
using System.Net.Http;
using System;
using Backend.Util;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using Backend.Model.PatientModel;

namespace WebApplicationTests.Integration.Documents
{
    public class SearchDocumentsTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
   
        public SearchDocumentsTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async void Simple_search_status_code_tests(DocumentSearchCriteria criteria, HttpStatusCode expectedStatusCode)
        {
            HttpClient client = _factory.CreateClient();
            StringContent bodyContent = new StringContent(JsonConvert.SerializeObject(criteria), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("/api/document/simple-search/500", bodyContent);

            response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        }

        [Theory]
        [MemberData(nameof(DataAdvanced))]
        public async void Advanced_search_status_code_tests(AdvancedDocumentSearchCriteria criteria, HttpStatusCode expectedStatusCode)
        {
            HttpClient client = _factory.CreateClient();
            StringContent bodyContent = new StringContent(JsonConvert.SerializeObject(criteria), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("/api/document/advanced-search/500", bodyContent);

            response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        }

        

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { null, HttpStatusCode.BadRequest },
            new object[] { new DocumentSearchCriteria(true, true, new TimeInterval(DateTime.Now.AddDays(-5), DateTime.Now), "pera", "ABCD", "", ""), HttpStatusCode.OK }
        };

        public static IEnumerable<object[]> DataAdvanced =>
        new List<object[]>
        {
            new object[] { null, HttpStatusCode.BadRequest },
            new object[] { new AdvancedDocumentSearchCriteria(true, true, new List<FilterType>(), new List<LogicalOperator>(), new List<TextFilter>(), new List<TimeIntervalFilter>()), HttpStatusCode.OK }
        };
    }
}
