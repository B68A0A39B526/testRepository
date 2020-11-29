using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Documents
{
    public class DocumentDTO
    {
        public DateTime DateCreated { get; set; }
        public string DoctorName { get; set; }
        public string DiagnosisName { get; set; }

        public DocumentDTO() { }

        public DocumentDTO(DateTime dateCreated, string doctorName, string diagnosisName)
        {
            DateCreated = dateCreated;
            DoctorName = doctorName;
            DiagnosisName = diagnosisName;
        }
    }
}
