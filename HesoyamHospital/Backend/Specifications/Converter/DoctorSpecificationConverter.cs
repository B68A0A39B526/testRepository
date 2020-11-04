// File:    DoctorSpecificationConverter.cs
// Author:  Geri
// Created: 24. maj 2020 20:28:14
// Purpose: Definition of Class DoctorSpecificationConverter

using Backend.Model.DoctorModel;
using Backend.Model.UserModel;
using Backend.Util;
using System;

namespace Backend.Specifications.Converter
{
    public class DoctorSpecificationConverter
    {
        private DoctorFilter _filter;

        public DoctorSpecificationConverter(DoctorFilter filter)
        {
            _filter = filter;
        }

        private ISpecification<Doctor> GetSpecificationByName(string name)
        {
            return new ExpressionSpecification<Doctor>(o => o.Name.Equals(name));
        }

        private ISpecification<Doctor> GetSpecificationBySurname(string surname)
        {
            return new ExpressionSpecification<Doctor>(o => o.Surname.Equals(surname));
        }

        private ISpecification<Doctor> GetSpecificationByType(DoctorType type)
        {
            return new ExpressionSpecification<Doctor>(o => o.DoctorType == type);
        }

        public ISpecification<Doctor> GetSpecification()
        {
            bool andSpecification = true;
            ISpecification<Doctor> specification = new ExpressionSpecification<Doctor>(o => andSpecification);

            if (!String.IsNullOrEmpty(_filter.Name))
            {
                specification = specification.And(GetSpecificationByName(_filter.Name));
            }

            if (!String.IsNullOrEmpty(_filter.Surname))
            {
                specification = specification.And(GetSpecificationBySurname(_filter.Surname));
            }

            if(_filter.Type != DoctorType.UNDEFINED)
            {
                specification = specification.And(GetSpecificationByType(_filter.Type));
            }

            return specification;
        }

    }
}