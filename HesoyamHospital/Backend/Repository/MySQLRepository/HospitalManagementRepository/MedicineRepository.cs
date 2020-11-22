// File:    MedicineRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:33:40
// Purpose: Definition of Class MedicineRepository

using Backend.Model.PatientModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.MySQLRepository.MedicalRepository;
using Backend.Repository.Sequencer;
using Backend.Specifications;
using Backend.Specifications.Converter;
using Backend.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repository.MySQLRepository.HospitalManagementRepository
{
    public class MedicineRepository : MySQLRepository<Medicine, long>, IMedicineRepository, IEagerRepository<Medicine, long>
    {
        private const string ENTITY_NAME = "Medicine";
        private string[] INCLUDE_PROPERTIES = { "Ingredient", "UsedFor" };

        public MedicineRepository(IMySQLStream<Medicine> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Medicine>())
        {
        }

        public IEnumerable<Medicine> GetMedicineForDisease(Disease disease)
            => GetAll().Where(med => med.UsedFor.Contains(new DiseaseMedicine(disease, med)));

        public IEnumerable<Medicine> GetMedicineByIngredient(Ingredient ingredient)
            => GetAll().Where(med => med.Ingredient.Contains(ingredient));

        public Medicine GetMedicineByName(string name)
            => GetAll().SingleOrDefault(med => med.Name == name);

        public IEnumerable<Medicine> GetFilteredMedicine(MedicineFilter medicineFilter)
        {
            ISpecification<Medicine> medicineSpecification = new MedicineSpecificationConverter(medicineFilter).GetSpecification();
            var meds = Find(medicineSpecification);
            var eagerMeds = GetAllEager();
            IEnumerable<Medicine> result = new List<Medicine>();
            foreach (var med in meds)
            {
                foreach (var eagerMed in eagerMeds)
                {
                    if (med.Id == eagerMed.Id)
                    {
                        result.Append(eagerMed);
                    }
                }
            }
            return result;
        }

        public IEnumerable<Medicine> GetMedicinePendingApproval()
            => GetAll().Where(med => med.IsValid == false);

        public Medicine GetEager(long id)
            => GetAllEager().SingleOrDefault(med => med.Id == id);

        public IEnumerable<Medicine> GetAllEager()
            => GetAllEager(INCLUDE_PROPERTIES);
    }
}