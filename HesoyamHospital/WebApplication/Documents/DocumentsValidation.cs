using Backend.Model.PatientModel;
using Backend.Util;

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

        public bool isAdvancedSearchCriteriaValid(AdvancedDocumentSearchCriteria criteria)
            => criteria != null &&
            criteria.LogicalOperators != null &&
            criteria.TextFilters != null &&
            criteria.TimeIntervalFilters != null &&
            criteria.FilterTypes != null &&
            criteria.isConsistent();
    }
}
