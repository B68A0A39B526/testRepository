using System;
using System.Net.Http.Headers;
using Backend;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ISendEmail _sendEmailService;

        public RegistrationController(ISendEmail sendEmalService)
        {
            _sendEmailService = sendEmalService;
        }

        [HttpPost]   //POST /api/registration
        public IActionResult Add(NewPatientDTO dto)
        {
            if (dto == null || !RegistrationValidation.IsPatientValid(dto)) return BadRequest();
            MedicalRecord medicalRecord = AppResources.getInstance().medicalRecordService.Create(NewPatientMapper.NewPatientDTOToMedicalRecord(dto));
            if (medicalRecord != null)
            {
                _sendEmailService.SendActivationEmail(medicalRecord.Patient.Id, medicalRecord.Patient.Email1);
            }
            return Ok();
        }

        [HttpPost("upload"), DisableRequestSizeLimit]   //POST /api/registration/upload
        public IActionResult UploadPicture()
        {
            try
            {
                var file = Request.Form.Files[0];
                if(file.Length > 0)
                {   
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    ImageRepository.SaveImage(file, fileName);
                    return Ok();
                }
                else return BadRequest();
            }
            catch(Exception ex) 
            {
                return StatusCode(500, $"internal server error: {ex}");
            }
        }

        [HttpPost("activate/{token}")]   //POST /api/registration/activate/token123
        public IActionResult Activate(string token)
        {
            long id = _sendEmailService.TokenToId(token);
            Patient patient = AppResources.getInstance().patientService.Activate(id);
            if (patient == null) return BadRequest();
            return Ok();
        }

    }
}
