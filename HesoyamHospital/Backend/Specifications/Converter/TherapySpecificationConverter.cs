// File:    TherapySpecificationConverter.cs
// Author:  nikola
// Created: 24. maj 2020 11:54:18
// Purpose: Definition of Class TherapySpecificationConverter

using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Specifications.Converter
{
    public class TherapySpecificationConverter
    {
        private TherapyFilter _filter;

        public TherapySpecificationConverter(TherapyFilter filter)
        {
            _filter = filter;
        }

        private ISpecification<Therapy> GetSpecificationByDrugName(string drugName)
        {
            return new ExpressionSpecification<Therapy>(o => o.Prescription.MedicalTherapies == null ? false : o.Prescription.MedicalTherapies.Select(m => m.Medicine.Name.ToLower()).Contains(drugName.ToLower()));
        }

        private ISpecification<Therapy> GetSpecificationByTimeInterval(TimeInterval timeInterval)
        {
            return new ExpressionSpecification<Therapy>(o => o.TimeInterval.IsDateTimeBetween(timeInterval));
        }

        private ISpecification<Therapy> GetSpecificationByTherapyTime(TherapyTime time)
        { 
            return new ExpressionSpecification<Therapy>(o => o.Prescription.MedicalTherapies.Select(mt => mt.Dose.Dosage.Find(d => d.TherapyTime.Equals(time)) != null) != null);
        }

        private ISpecification<Therapy> GetSpecificationByTherapyTimes(IEnumerable<TherapyTime> time)
        {
            ISpecification<Therapy> therapyTimeSpecification = new ExpressionSpecification<Therapy>(o => true);

            foreach (TherapyTime therapyTime in time)
            {
                therapyTimeSpecification = therapyTimeSpecification.And(GetSpecificationByTherapyTime(therapyTime));
            }

            return therapyTimeSpecification;
        }

        public ISpecification<Therapy> GetSpecification()
        {
            bool andFilter = true;
            ISpecification<Therapy> specification = new ExpressionSpecification<Therapy>(o => andFilter);

            if (String.IsNullOrEmpty(_filter.DrugName))
            {
                specification = specification.And(GetSpecificationByDrugName(_filter.DrugName));
            }

            if(_filter.TherapyTimes != null)
            {
                specification = specification.And(GetSpecificationByTherapyTimes(_filter.TherapyTimes));
            }

            if(_filter.TimeInterval != null)
            {
                specification = specification.And(GetSpecificationByTimeInterval(_filter.TimeInterval));
            }

            return specification;
        }

    }
}