using System;
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

        [HttpPost("simple-search/{id}")]
        public IActionResult SimpleSearchDocs([FromBody] DocumentSearchCriteria criteria, long id)
        {
            if (!_validation.isSearchCriteriaValid(criteria)) return BadRequest();

            return Ok(DocumentsMapper.DocumentToDocumentDTO(_documentService.SimpleSearchDocs(criteria, id).ToList()));
        }

        [HttpPost("advanced-search/{id}")]
        public IActionResult AdvanceSearchDocs([FromBody] AdvancedDocumentSearchCriteria criteria, long id)
        {
            if (!_validation.isAdvancedSearchCriteriaValid(criteria)) return BadRequest();

            return Ok(DocumentsMapper.DocumentToDocumentDTO(_documentService.AdvanceSearchDocs(criteria, id).ToList()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return Ok(DocumentsMapper.DocumentToDocumentDTO(_documentService.GetAllByPatient(id).ToList()));
        }
    }
}
