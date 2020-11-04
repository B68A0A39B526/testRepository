using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Service;
using Backend.Service.HospitalManagementService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Hospital> GetAll()
            => AppResources.getInstance().hospitalService.GetAll();
    }
}
