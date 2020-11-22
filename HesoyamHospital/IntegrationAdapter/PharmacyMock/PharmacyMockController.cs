using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAdapter.PharmacyMock
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyMockController : ControllerBase
    {
        List<Pharmacy> Pharmacies = new List<Pharmacy>();
        private static List<Pharmacy> loadPharmacies()
        {
            Pharmacy pharmacy1 = new Pharmacy("pharmacy1");
            Pharmacy pharmacy2 = new Pharmacy("pharmacy2");
            Pharmacy pharmacy3 = new Pharmacy("pharmacy3");
            List<Pharmacy> ret = new List<Pharmacy>();
            ret.Add(pharmacy1);
            ret.Add(pharmacy2);
            ret.Add(pharmacy3);
            return ret;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Pharmacy> pharmacies = loadPharmacies();
            return Ok(pharmacies);
        }

        [HttpGet("{pharmacyName}")]
        public IActionResult Get(string pharmacyName)
        {
            return Ok();
        }
    }
}
