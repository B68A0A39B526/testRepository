using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Util
{
    public class DocumentSearchCriteria
    {
        public bool ShouldSearchReports { get; set; }
        public bool ShouldSearchPrescriptions { get; set; }
        public TimeInterval TimeInterval { get; set; }
        public string DoctorName { get; set; }
        public string DiagnosisName { get; set; }
        public string MedicineName { get; set; }
        public string Comment { get; set; }

        public DocumentSearchCriteria() { }

        public DocumentSearchCriteria(bool shouldSearchReports, bool shouldSearchPrescriptions, TimeInterval timeInterval, string doctorName, string diagnosisName, string medicineName, string comment)
        {
            ShouldSearchReports = shouldSearchReports;
            ShouldSearchPrescriptions = shouldSearchPrescriptions;
            TimeInterval = timeInterval;
            DoctorName = doctorName;
            DiagnosisName = diagnosisName;
            MedicineName = medicineName;
            Comment = comment;
        }
    }
}
