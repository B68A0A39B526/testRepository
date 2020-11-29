using Backend.Model.UserModel;
using Backend.Util;
using System;

namespace Backend.Model.PatientModel
{
    public class Document
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Diagnosis Diagnosis { get; set; }
        public DocumentType Type { get; set; }

        public Document() { }

        public virtual bool meetsCriteria(DocumentSearchCriteria criteria)
        {
            if (!Doctor.FullName.ToLower().Contains(criteria.DoctorName.ToLower())) return false;
            if (!Diagnosis.DiagnosisName.ToLower().Contains(criteria.DiagnosisName.ToLower())) return false;
            if (!criteria.TimeInterval.IsDateTimeBetween(DateCreated)) return false;
            return true;
        }

        public virtual bool meetsAdvancedTextCriteria(FilterType filterType, TextFilter textFilter)
        {
            if (filterType == FilterType.DOCTORS_NAME && meetsDoctorNameCriteria(textFilter)) return true;
            if (filterType == FilterType.DIAGNOSIS_NAME && meetsDiagnosisNameCriteria(textFilter)) return true;
            return false;
        }

        public bool meetsTimeIntervalCriteria(TimeIntervalFilter filter)
        {
            if (filter.TimeInterval.IsDateTimeBetween(DateCreated) && filter.Filter == IntervalMatchFilter.CONTAINS) return true;
            if (!filter.TimeInterval.IsDateTimeBetween(DateCreated) && filter.Filter == IntervalMatchFilter.DOES_NOT_CONTAIN) return true;
            return false;
        }

        private bool meetsDoctorNameCriteria(TextFilter filter)
        {
            if (filter.Filter == TextmatchFilter.EQUAL && Doctor.FullName.ToLower().Equals(filter.Text.ToLower())) return true;
            if (filter.Filter == TextmatchFilter.CONTAINS && Doctor.FullName.ToLower().Contains(filter.Text.ToLower())) return true;
            if (filter.Filter == TextmatchFilter.DOES_NOT_CONTAIN && !Doctor.FullName.ToLower().Contains(filter.Text.ToLower())) return true;
            return false;
        }

        private bool meetsDiagnosisNameCriteria(TextFilter filter)
        {
            if (filter.Filter == TextmatchFilter.EQUAL && Diagnosis.DiagnosisName.ToLower().Equals(filter.Text.ToLower())) return true;
            if (filter.Filter == TextmatchFilter.CONTAINS && Diagnosis.DiagnosisName.ToLower().Contains(filter.Text.ToLower())) return true;
            if (filter.Filter == TextmatchFilter.DOES_NOT_CONTAIN && !Diagnosis.DiagnosisName.ToLower().Contains(filter.Text.ToLower())) return true;
            return false;
        }
    }
}
