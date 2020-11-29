using System.Collections.Generic;
using System.Linq;
using Backend.Model.PatientModel;
using Backend.Util;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Documents.Service;

namespace WebApplication.Documents
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        private readonly DocumentsValidation _validation;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
            _validation = new DocumentsValidation();
        }

        [HttpPost("simple-search")]
        public IActionResult SimpleSearchDocs([FromBody]DocumentSearchCriteria criteria)
        {
            if (!_validation.isSearchCriteriaValid(criteria)) return BadRequest();

            return Ok(DocumentsMapper.DocumentToDocumentDTO(_documentService.SimpleSearchDocs(criteria).ToList()));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(DocumentsMapper.DocumentToDocumentDTO(_documentService.GetAll().ToList()));
        }
    }
}
