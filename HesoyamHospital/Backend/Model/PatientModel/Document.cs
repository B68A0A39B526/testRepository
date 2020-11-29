using Backend.Model.UserModel;
using Backend.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.PatientModel
{
    public class Document
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Diagnosis Diagnosis { get; set; }

        public Document() { }

        public virtual bool meetsCriteria(DocumentSearchCriteria criteria)
        {
            if (!Doctor.FullName.ToLower().Contains(criteria.DoctorName.ToLower())) return false;
            if (!Diagnosis.DiagnosisName.ToLower().Contains(criteria.DiagnosisName.ToLower())) return false;
            if (!criteria.TimeInterval.IsDateTimeBetween(DateCreated)) return false;
            return true;
        }
    }
}
