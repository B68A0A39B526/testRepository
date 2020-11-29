using Backend.Model.PatientModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Documents.Service
{
    public class DocumentService : IDocumentService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IReportRepository _reportRepository;

        public DocumentService(IPrescriptionRepository prescriptionRepository, IReportRepository reportRepository)
        {
            _prescriptionRepository = prescriptionRepository;
            _reportRepository = reportRepository;
        }

        public IEnumerable<Document> AdvanceSearchDocs(AdvancedDocumentSearchCriteria criteria, long patientId)
        {
            List<Document> result = new List<Document>();

            if (criteria.ShouldSearchPrescriptions) result.AddRange(getPrescriptionsThatMeetAdvancedCriteria(criteria, patientId));
            if (criteria.ShouldSearchReports) result.AddRange(getReportsThatMeetAdvancedCriteria(criteria, patientId));

            return result;
        }

        public Document Create(Document entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Document entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Document> GetAll()
        {
            List<Document> result = ((List<Report>)_reportRepository.GetAll()).ConvertAll(r => (Document)r);
            result.AddRange(((List<Prescription>)_prescriptionRepository.GetAll()).ConvertAll(p => (Document)p));
            return result;
        }

        public IEnumerable<Document> GetAllByPatient(long patientId)
        {
            List<Document> result = ((List<Report>)_reportRepository.GetAllByPatient(patientId)).ConvertAll(r => (Document)r);
            result.AddRange(((List<Prescription>)_prescriptionRepository.GetAllByPatient(patientId)).ConvertAll(p => (Document)p));
            return result;
        }

        public Document GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Document> SimpleSearchDocs(DocumentSearchCriteria criteria, long patientId)
        {
            List<Document> result = new List<Document>();

            if (criteria.ShouldSearchPrescriptions) result.AddRange(getPrescriptionsThatMeetCriteria(criteria, patientId));
            if (criteria.ShouldSearchReports) result.AddRange(getReportsThatMeetCriteria(criteria, patientId));

            return result;
        }

        public void Update(Document entity)
        {
            throw new NotImplementedException();
        }

        public void Validate(Document entity)
        {
            throw new NotImplementedException();
        }

        private List<Document> getPrescriptionsThatMeetCriteria(DocumentSearchCriteria criteria, long patientId)
        {
            List<Document> result = new List<Document>();

            foreach (Prescription prescription in _prescriptionRepository.GetAllByPatient(patientId))
                if (prescription.meetsCriteria(criteria))
                    result.Add(prescription);

            return result;
        }

        private List<Document> getReportsThatMeetCriteria(DocumentSearchCriteria criteria, long patientId)
        {
            List<Document> result = new List<Document>();

            foreach (Report report in _reportRepository.GetAllByPatient(patientId))
                if (report.meetsCriteria(criteria))
                    result.Add(report);

            return result;
        }

        private List<Document> getPrescriptionsThatMeetAdvancedCriteria(AdvancedDocumentSearchCriteria criteria, long patientId)
        {
            List<Document> currentResult = ((List<Prescription>)_prescriptionRepository.GetAllByPatient(patientId)).ConvertAll(r => (Document)r);
            if (criteria.hasElements())
            {
                criteria.setInitialState();
                for (int i = 0; i < criteria.FilterTypes.Count; i++)
                {
                    List<Document> newResult = new List<Document>();
                    if (criteria.FilterTypes[i] == FilterType.TIME_INTERVAL)
                    {
                        TimeIntervalFilter timeIntervalFilter = criteria.TimeIntervalFilters[0];
                        criteria.TimeIntervalFilters.RemoveAt(0);
                        criteria.TimeIntervalFilters.Add(timeIntervalFilter);
                        newResult = getPrescriptionsThatMeetTimeIntervalCriteria((List<Prescription>)_prescriptionRepository.GetAllByPatient(patientId), timeIntervalFilter).ConvertAll(r => (Document)r);
                    }
                    else
                    {
                        TextFilter textFilter = criteria.TextFilters[0];
                        criteria.TextFilters.RemoveAt(0);
                        criteria.TextFilters.Add(textFilter);
                        if (criteria.FilterTypes[i] == FilterType.COMMENT) continue;
                        newResult = getPrescriptionsThatMeetTextCriteria((List<Prescription>)_prescriptionRepository.GetAllByPatient(patientId), textFilter, criteria.FilterTypes[i]).ConvertAll(r => (Document)r);
                    }
                    currentResult = performLogicalOperation(currentResult, newResult, criteria.LogicalOperators[i]);
                }
            }
            return currentResult;
        }

        private List<Document> getReportsThatMeetAdvancedCriteria(AdvancedDocumentSearchCriteria criteria, long patientId)
        {
            List<Document> currentResult = ((List<Report>)_reportRepository.GetAllByPatient(patientId)).ConvertAll(r => (Document)r);
            if (criteria.hasElements())
            {
                criteria.setInitialState();
                for ( int i = 0; i < criteria.FilterTypes.Count; i++)
                {
                    List<Document> newResult = new List<Document>();
                    if (criteria.FilterTypes[i] == FilterType.TIME_INTERVAL)
                    {
                        TimeIntervalFilter timeIntervalFilter = criteria.TimeIntervalFilters[0];
                        criteria.TimeIntervalFilters.RemoveAt(0);
                        criteria.TimeIntervalFilters.Add(timeIntervalFilter);
                        newResult = getReportsThatMeetTimeIntervalCriteria((List<Report>)_reportRepository.GetAllByPatient(patientId), timeIntervalFilter).ConvertAll(r => (Document)r);
                    } 
                    else
                    {
                        TextFilter textFilter = criteria.TextFilters[0];
                        criteria.TextFilters.RemoveAt(0);
                        criteria.TextFilters.Add(textFilter);
                        if (criteria.FilterTypes[i] == FilterType.MEDICINE_NAME) continue;
                        newResult = getReportsThatMeetTextCriteria((List<Report>)_reportRepository.GetAllByPatient(patientId), textFilter, criteria.FilterTypes[i]).ConvertAll(r => (Document)r);
                    }
                    currentResult = performLogicalOperation(currentResult, newResult, criteria.LogicalOperators[i]);
                }
            }
            return currentResult;
        }

        private List<Report> getReportsThatMeetTimeIntervalCriteria(List<Report> reports, TimeIntervalFilter timeIntervalFilter)
        {
            List<Report> result = new List<Report>();
            foreach (Report report in reports)
                if (report.meetsTimeIntervalCriteria(timeIntervalFilter))
                    result.Add(report);
            return result;
        }

        private List<Prescription> getPrescriptionsThatMeetTimeIntervalCriteria(List<Prescription> prescriptions, TimeIntervalFilter timeIntervalFilter)
        {
            List<Prescription> result = new List<Prescription>();
            foreach (Prescription prescription in prescriptions)
                if (prescription.meetsTimeIntervalCriteria(timeIntervalFilter))
                    result.Add(prescription);
            return result;
        }

        private List<Report> getReportsThatMeetTextCriteria(List<Report> reports, TextFilter filter, FilterType filterType)
        {
            List<Report> result = new List<Report>();
            foreach (Report report in reports)
                if (report.meetsAdvancedTextCriteria(filterType, filter))
                    result.Add(report);
            return result;
        }

        private List<Prescription> getPrescriptionsThatMeetTextCriteria(List<Prescription> prescriptions, TextFilter filter, FilterType filterType)
        {
            List<Prescription> result = new List<Prescription>();
            foreach (Prescription prescription in prescriptions)
                if (prescription.meetsAdvancedTextCriteria(filterType, filter))
                    result.Add(prescription);
            return result;
        }

        private List<Document> performLogicalOperation(List<Document> operandOne, List<Document> operandTwo, LogicalOperator logicalOperator)
        {
            if (logicalOperator == LogicalOperator.AND) return performLogicalOperationAnd(operandOne, operandTwo);
            else return performLogicalOperationOr(operandOne, operandTwo);
        }

        private List<Document> performLogicalOperationAnd(List<Document> operandOne, List<Document> operandTwo)
        {
            List<Document> result = new List<Document>();
            foreach (Document d in operandOne)
                if (operandTwo.Where(doc => doc.Id == d.Id).Count() > 0)
                    result.Add(d);
            return result;
        }

        private List<Document> performLogicalOperationOr(List<Document> operandOne, List<Document> operandTwo)
        {
            List<Document> result = operandTwo;
            foreach (Document d in operandOne)
                if (result.Where(doc => doc.Id == d.Id).Count() == 0)
                    result.Add(d);
            return result;
        }
    }
}
