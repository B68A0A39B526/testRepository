// File:    TherapyRepository.cs
// Author:  nikola
// Created: 24. maj 2020 11:52:17
// Purpose: Definition of Class TherapyRepository

using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using Backend.Specifications.Converter;
using Backend.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Specifications;

namespace Backend.Repository.MySQLRepository.MedicalRepository
{
    public class TherapyRepository : MySQLRepository<Therapy, long>, ITherapyRepository, IEagerRepository<Therapy, long>
    {
        private const string ENTITY_NAME = "Therapy";
        private string[] INCLUDE_PROPERTIES = { "TimeInterval", "Prescription" };


        public TherapyRepository(IMySQLStream<Therapy> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Therapy>())
        {

        }

        public Therapy GetEager(long id)
            => GetAllEager().SingleOrDefault(therapy => therapy.GetId() == id);

        public IEnumerable<Therapy> GetAllEager()
            => GetAllEager(INCLUDE_PROPERTIES);

        public IEnumerable<Therapy> GetTherapyByDate(TimeInterval dateRange) //Return all therapies where therapy time interval is inside passed time interval(dateRange).
            => GetAllEager().Where(therapy => dateRange.IsDateTimeBetween(therapy.TimeInterval));

        public IEnumerable<Therapy> GetTherapyByMedicine(Medicine medicine)
            => GetAllEager().Where(therapy => therapy.Prescription.MedicalTherapies.Find(mt => mt.Medicine.Equals(medicine)) != null);

        public IEnumerable<Therapy> GetTherapyByPatient(Patient patient)
        {
            var retVal = GetAllEager();
            /* treba vratiti po pacijentu*/

            return retVal;
        }

        public IEnumerable<Therapy> GetFilteredTherapy(TherapyFilter filter)
        {
            ISpecification<Therapy> therapySpecification = new TherapySpecificationConverter(filter).GetSpecification();
            IEnumerable <Therapy> therapies = Find(therapySpecification);
            var eagerTs = GetAllEager();
            IEnumerable<Therapy> result = new List<Therapy>();
            foreach (var ther in therapies)
            {
                foreach (var eagerT in eagerTs)
                {
                    if (ther._id == eagerT._id)
                    {
                        result.Append(eagerT);
                    }
                }
            }
            return result;
        }

        public IEnumerable<Therapy> GetTherapyByDiagnosis(Diagnosis diagnosis)
            => diagnosis.Therapies;

        public IEnumerable<Therapy> GetActiveTherapyForPatient(Patient patient)
        {
            /*
            List<Therapy> retVal = new List<Therapy>();

            IEnumerable<Diagnosis> diagnosisList = _diagnosisCSVRepository.GetAllDiagnosisForPatient(patient);

            foreach (Diagnosis diagnosis in diagnosisList)
                retVal.AddRange(diagnosis.ActiveTherapy);

            return retVal;*/
            return GetAllEager();
        }

        public IEnumerable<Therapy> GetPastTherapyForPatient(Patient patient)
        {
            /*
            List<Therapy> retVal = new List<Therapy>();

            IEnumerable<Diagnosis> diagnosisList = _diagnosisCSVRepository.GetAllDiagnosisForPatient(patient);

            foreach (Diagnosis diagnosis in diagnosisList)
                retVal.AddRange(diagnosis.InactiveTherapy);

            return retVal;*/
            return GetAllEager();
        }

        public IEnumerable<Therapy> GetActiveTherapyForDiagnosis(Diagnosis diagnosis)
            => diagnosis.ActiveTherapy;

        public IEnumerable<Therapy> GetPastTherapiesForDiagnosis(Diagnosis diagnosis)
            => diagnosis.InactiveTherapy;

        public TherapySpecificationConverter therapySpecificationConverter;

    }
}