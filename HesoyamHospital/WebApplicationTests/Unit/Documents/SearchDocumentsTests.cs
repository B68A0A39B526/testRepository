using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Util;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using WebApplication.Documents.Service;
using Xunit;

namespace WebApplicationTests.Unit.Documents
{
    public class SearchDocumentsTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Search_documents_with_results(bool shouldSearchPrescriptions, bool shouldSearchReports)
        {
            DocumentService service = new DocumentService(CreateStubPrescriptionRepository(), CreateStubReportRepository());
            DocumentSearchCriteria criteria = new DocumentSearchCriteria(shouldSearchPrescriptions, shouldSearchReports, new TimeInterval(DateTime.Now.AddDays(-10), DateTime.Now.AddDays(1)), "pera", "naziv1", "brufen", "nalaz");

            IEnumerable<Document> documents = service.SimpleSearchDocs(criteria, 500);

            ((List<Document>)documents).Count.ShouldBeGreaterThan(0);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Advance_search_documents_with_results(bool shouldSearchPrescriptions, bool shouldSearchReports)
        {
            DocumentService service = new DocumentService(CreateStubPrescriptionRepository(), CreateStubReportRepository());
            List<FilterType> filterTypes = new List<FilterType>();
            filterTypes.Add(FilterType.DOCTORS_NAME);
            filterTypes.Add(FilterType.TIME_INTERVAL);
            List<LogicalOperator> logicalOperators = new List<LogicalOperator>();
            logicalOperators.Add(LogicalOperator.AND);
            List<TextFilter> textFilters = new List<TextFilter>();
            textFilters.Add(new TextFilter("pera", TextmatchFilter.CONTAINS));
            List<TimeIntervalFilter> timeIntervalFilters = new List<TimeIntervalFilter>();
            timeIntervalFilters.Add(new TimeIntervalFilter(new TimeInterval(DateTime.Now.AddDays(-20), DateTime.Now), IntervalMatchFilter.CONTAINS));
            AdvancedDocumentSearchCriteria criteria = new AdvancedDocumentSearchCriteria(shouldSearchPrescriptions, shouldSearchReports, filterTypes, logicalOperators, textFilters, timeIntervalFilters);

            IEnumerable<Document> documents = service.AdvanceSearchDocs(criteria, 500);

            ((List<Document>)documents).Count.ShouldBeGreaterThan(0);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Search_documents_without_results(bool shouldSearchPrescriptions, bool shouldSearchReports)
        {
            DocumentService service = new DocumentService(CreateStubPrescriptionRepository(), CreateStubReportRepository());
            DocumentSearchCriteria criteria = new DocumentSearchCriteria(shouldSearchPrescriptions, shouldSearchReports, new TimeInterval(DateTime.Now.AddDays(-20), DateTime.Now.AddDays(-16)), "pera", "naziv1", "brufen", "nalaz");

            IEnumerable<Document> documents = service.SimpleSearchDocs(criteria, 500);

            ((List<Document>)documents).Count.ShouldBeEquivalentTo(0);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Advance_search_documents_without_results(bool shouldSearchPrescriptions, bool shouldSearchReports)
        {
            DocumentService service = new DocumentService(CreateStubPrescriptionRepository(), CreateStubReportRepository());
            List<FilterType> filterTypes = new List<FilterType>();
            filterTypes.Add(FilterType.DOCTORS_NAME);
            filterTypes.Add(FilterType.TIME_INTERVAL);
            List<LogicalOperator> logicalOperators = new List<LogicalOperator>();
            logicalOperators.Add(LogicalOperator.AND);
            List<TextFilter> textFilters = new List<TextFilter>();
            textFilters.Add(new TextFilter("tamara", TextmatchFilter.CONTAINS));
            List<TimeIntervalFilter> timeIntervalFilters = new List<TimeIntervalFilter>();
            timeIntervalFilters.Add(new TimeIntervalFilter(new TimeInterval(DateTime.Now.AddDays(-20), DateTime.Now), IntervalMatchFilter.CONTAINS));
            AdvancedDocumentSearchCriteria criteria = new AdvancedDocumentSearchCriteria(shouldSearchPrescriptions, shouldSearchReports, filterTypes, logicalOperators, textFilters, timeIntervalFilters);

            IEnumerable<Document> documents = service.AdvanceSearchDocs(criteria, 500);

            ((List<Document>)documents).Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Search_neither_prescriptions_nor_reports()
        {
            DocumentService service = new DocumentService(CreateStubPrescriptionRepository(), CreateStubReportRepository());
            DocumentSearchCriteria criteria = new DocumentSearchCriteria(false, false, new TimeInterval(DateTime.Now.AddDays(-10), DateTime.Now), "pera", "naziv1", "brufen", "nalaz");

            IEnumerable<Document> documents = service.SimpleSearchDocs(criteria, 500);

            ((List<Document>)documents).Count.ShouldBeEquivalentTo(0);
        }

        private static IPrescriptionRepository CreateStubPrescriptionRepository()
        {
            var stubRepository = new Mock<IPrescriptionRepository>();
            var prescriptions = new List<Prescription>();

            Prescription p1 = new Prescription(0);
            p1.DateCreated = DateTime.Now.AddDays(-10);
            p1.Diagnosis = new Diagnosis(0, "naziv", "ab12");
            p1.Doctor = new Doctor(0);
            p1.Doctor.Name = "Pera";
            p1.Doctor.Surname = "Peric";
            Medicine m = new Medicine("brufen", MedicineType.TABLET, 10, 5);
            List<SingleTherapyDose> st = new List<SingleTherapyDose>();
            st.Add(new SingleTherapyDose(TherapyTime.Evening, 2));
            TherapyDose td = new TherapyDose(st);
            p1.MedicalTherapies.Add(new MedicalTherapy(m, td));

            Prescription p2 = new Prescription(1);
            p2.DateCreated = DateTime.Now.AddDays(-5);
            p2.Diagnosis = new Diagnosis(0, "naziv1", "ab13");
            p2.Doctor = new Doctor(0);
            p2.Doctor.Name = "Pera";
            p2.Doctor.Surname = "Peric";
            p2.MedicalTherapies.Add(new MedicalTherapy(m, td));

            prescriptions.Add(p1);
            prescriptions.Add(p2);

            stubRepository.Setup(r => r.GetAllByPatient(500)).Returns(prescriptions);

            return stubRepository.Object;
        }

        private static IReportRepository CreateStubReportRepository()
        {
            var stubRepository = new Mock<IReportRepository>();
            var reports = new List<Report>();

            Report r1 = new Report(0);
            r1.DateCreated = DateTime.Now.AddDays(-15);
            r1.Diagnosis = new Diagnosis(0, "naziv", "ab12");
            r1.Doctor = new Doctor(0);
            r1.Doctor.Name = "Pera";
            r1.Doctor.Surname = "Peric";
            r1.Comment = "nalaz";

            Report r2 = new Report(1);
            r2.DateCreated = DateTime.Now.AddDays(-7);
            r2.Diagnosis = new Diagnosis(0, "naziv1", "ab13");
            r2.Doctor = new Doctor(0);
            r2.Doctor.Name = "Pera";
            r2.Doctor.Surname = "Peric";
            r2.Comment = "nalaz";

            reports.Add(r1);
            reports.Add(r2);

            stubRepository.Setup(r => r.GetAllByPatient(500)).Returns(reports);

            return stubRepository.Object;
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { true, false },
            new object[] { false, true },
            new object[] { true, true }
        };
    }
}
