using Backend.Model.UserModel;
using Backend.Repository.Abstract;
using Backend.Util;
using System;
namespace Backend.Model.PatientModel
{
    public class Report : Document, IIdentifiable<long>
    {
        public string Comment { get; set; }

        public Report (long id)
        {
            Id = id;
            DateCreated = DateTime.Now;
            Type = DocumentType.REPORT;
        }

        public Report (long id, Patient patient, Doctor doctor, string comment, Diagnosis diagnosis)
        {
            Id = id;
            Patient = patient;
            Doctor = doctor;
            Comment = comment;
            Diagnosis = diagnosis;
            Type = DocumentType.REPORT;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public override bool Equals(object obj)
        {
            var report = obj as Report;
            return report != null &&
                   Id == report.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }

        public override bool meetsCriteria(DocumentSearchCriteria criteria)
        {
            if (!base.meetsCriteria(criteria)) return false;
            if (!Comment.ToLower().Contains(criteria.Comment.ToLower())) return false;
            return true;
        }

        public override bool meetsAdvancedTextCriteria(FilterType filterType, TextFilter textFilter)
        {
            if (filterType == FilterType.COMMENT && meetsCommentCriteria(textFilter)) return true;
            if ((filterType == FilterType.DOCTORS_NAME || filterType == FilterType.DIAGNOSIS_NAME) && base.meetsAdvancedTextCriteria(filterType, textFilter)) return true;
            return false;
        }

        private bool meetsCommentCriteria(TextFilter filter)
        {
            if (filter.Filter == TextmatchFilter.EQUAL && Comment.ToLower().Equals(filter.Text.ToLower())) return true;
            if (filter.Filter == TextmatchFilter.CONTAINS && Comment.ToLower().Contains(filter.Text.ToLower())) return true;
            if (filter.Filter == TextmatchFilter.DOES_NOT_CONTAIN && !Comment.ToLower().Contains(filter.Text.ToLower())) return true;
            return false;
        }
    }
}
