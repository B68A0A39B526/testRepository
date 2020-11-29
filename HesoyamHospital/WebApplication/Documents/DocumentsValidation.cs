using Backend.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Documents
{
    public class DocumentsValidation
    {
        public bool isSearchCriteriaValid(DocumentSearchCriteria criteria)
            => criteria != null &&
            criteria.DoctorName != null &&
            criteria.MedicineName != null &&
            criteria.Comment != null &&
            criteria.DiagnosisName != null &&
            criteria.TimeInterval != null &&
            criteria.TimeInterval.IsFullyDefined() &&
            criteria.TimeInterval.IsInOrder() &&
            criteria.TimeInterval.IsInThePast();
    }
}
