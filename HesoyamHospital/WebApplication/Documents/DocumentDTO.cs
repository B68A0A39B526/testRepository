using Backend.Model.PatientModel;
using System;

namespace WebApplication.Documents
{
    public class DocumentDTO
    {
        public DateTime DateCreated { get; set; }
        public string DoctorName { get; set; }
        public string DiagnosisName { get; set; }
        public string Type { get; set; }

        public DocumentDTO() { }

        public DocumentDTO(DateTime dateCreated, string doctorName, string diagnosisName, string type)
        {
            DateCreated = dateCreated;
            DoctorName = doctorName;
            DiagnosisName = diagnosisName;
            Type = type;
        }
    }
}
