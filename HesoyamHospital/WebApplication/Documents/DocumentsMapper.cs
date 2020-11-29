using Backend.Model.PatientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Documents
{
    public static class DocumentsMapper
    {
        private static DocumentDTO DocumentToDocumentDTO(Document document)
        {
            return new DocumentDTO(document.DateCreated, document.Doctor.FullName, document.Diagnosis.DiagnosisName);
        }

        public static List<DocumentDTO> DocumentToDocumentDTO(List<Document> documents)
        {
            List<DocumentDTO> result = new List<DocumentDTO>();
            foreach (Document document in documents)
                result.Add(DocumentToDocumentDTO(document));
            return result;
        }
    }
}
