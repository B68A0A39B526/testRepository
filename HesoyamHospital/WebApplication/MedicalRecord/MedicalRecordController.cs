using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.MedicalRecords
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        [HttpGet("show/{id}")]  //GET /api/medicalrecord/show/500
        public IActionResult GetMedicalRecordByPatientId(long id)
        {
            MedicalRecord medicalRecord = AppResources.getInstance().medicalRecordService.GetPatientMedicalRecordByPatientId(id);

            if (medicalRecord == null) return NotFound();

            return Ok(MedicalRecordMapper.MedicalRecordToMedicalRecordDTO(medicalRecord));
        }
    }
}