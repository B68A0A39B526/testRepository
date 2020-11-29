using Backend.Model.PatientModel;
using Backend.Service;
using Backend.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Documents.Service
{
    public interface IDocumentService : IService<Document, long>
    {
        public IEnumerable<Document> SimpleSearchDocs(DocumentSearchCriteria criteria);
    }
}
