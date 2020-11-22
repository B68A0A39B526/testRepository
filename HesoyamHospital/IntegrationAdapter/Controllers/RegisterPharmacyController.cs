using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend;
using Backend.Model.PharmacyModel;
using IntegrationAdapter.PharmacyMock;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace IntegrationAdapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterPharmacyController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Pharmacy> Pharmacies = getPharmacies();
            return Ok(Pharmacies);
        }

        [HttpGet("{pharmacyName}")]
        public IActionResult Get(string pharmacyName)
        {
            PharmacyApiKey key = new PharmacyApiKey(pharmacyName + "_1234", pharmacyName);
            AppResources.getInstance().pharmacyApiKeyService.Create(key);
            return Ok();
        }

        private List<Pharmacy> getPharmacies()
        {
            var client = new RestSharp.RestClient("http://localhost:63518");
            var request = new RestRequest("/api/pharmacymock");
            var response = client.Get<List<Pharmacy>>(request);
            return response.Data;

        }
    }
}
