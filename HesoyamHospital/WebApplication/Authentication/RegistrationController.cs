using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Backend;
using Backend.Model.UserModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        [HttpPost]   //POST /api/registration
        public IActionResult Add(NewPatientDTO dto)
        {
            if (dto == null || !RegistrationValidation.IsPatientValid(dto)) return BadRequest();
            AppResources.getInstance().medicalRecordService.Create(NewPatientMapper.NewPatientDTOToMedicalRecord(dto));
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

    }
}
