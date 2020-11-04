// File:    DiagnosisRepository.cs
// Author:  Geri
// Created: 23. maj 2020 18:19:34
// Purpose: Definition of Class DiagnosisRepository

using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repository.MySQLRepository.MedicalRepository
{
    public class DiagnosisRepository : MySQLRepository<Diagnosis, long>, IDiagnosisRepository, IEagerRepository<Diagnosis, long>
    {
        private const string ENTITY_NAME = "Diagnosis";
        private string[] INCLUDE_PROPERTIES = { "Therapies", "DiagnosedDisease", "ActiveTherapy", "InactiveTherapy", "Date" };

        public DiagnosisRepository(IMySQLStream<Diagnosis> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Diagnosis>())
        {
        }

        public IEnumerable<Diagnosis> GetAllEager()
            => GetAllEager(INCLUDE_PROPERTIES);

        public Diagnosis GetEager(long id)
            => GetAllEager().SingleOrDefault(diagnosis => diagnosis.GetId() == id);


        public IEnumerable<Diagnosis> GetAllDiagnosisForPatient(Patient patient)
        {
            var diagnosis = GetAllEager();
            /* treba vratiti dijagnoze za pacijenta, a ne sve*/

            return GetAllEager();
        }

        public IEnumerable<Diagnosis> GetDiagnosisByMedicine(Medicine medicine)
        {
            List<Diagnosis> retVal = new List<Diagnosis>();

            IEnumerable<Diagnosis> allDiagnosis = GetAllEager();

            foreach(Diagnosis diagnosis in allDiagnosis)
            {
                
                IEnumerable<Therapy> therapiesForDiagnosis = diagnosis.Therapies; //Therapy contains information about prescriptions.

                foreach(Therapy therapy in therapiesForDiagnosis) 
                {
                    if (therapy.Prescription.MedicalTherapies.Find(mt => mt.Medicine.Equals(medicine)) != null) //Prescription has information about medicine that is given to the patient.
                        retVal.Add(diagnosis);
                }
            }

            return retVal;

        }
     }
}