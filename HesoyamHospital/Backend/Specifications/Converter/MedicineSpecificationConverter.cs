// File:    MedicineSpecificationConverter.cs
// Author:  Geri
// Created: 24. maj 2020 20:23:07
// Purpose: Definition of Class MedicineSpecificationConverter

using Backend.Model.PatientModel;
using Backend.Util;
using System;

namespace Backend.Specifications.Converter
{
    public class MedicineSpecificationConverter
    {
        private MedicineFilter _filter;

        public MedicineSpecificationConverter(MedicineFilter filter)
        {
            _filter = filter;
        }
        private ISpecification<Medicine> GetSpecificationByName(string name)
        {
            return new ExpressionSpecification<Medicine>(o => o.Name.Equals(name));
        }

        private ISpecification<Medicine> GetSpecificationByDisease(Disease disease)
        {
            return new ExpressionSpecification<Medicine>(o => o.UsedFor == null ? false : o.UsedFor.Contains(new DiseaseMedicine(disease, o)));
        }

        private ISpecification<Medicine> GetSpecificationByType(MedicineType type)
        {
            return new ExpressionSpecification<Medicine>(o => o.MedicineType.Equals(type));
        }

        private ISpecification<Medicine> GetSpecificationByIngredient(Ingredient ingredient)
        {
            return new ExpressionSpecification<Medicine>(o => o.Ingredient == null ? false : o.Ingredient.Equals(ingredient));
        }

        public ISpecification<Medicine> GetSpecification()
        {
            bool andFilter = true;
            ISpecification<Medicine> specification = new ExpressionSpecification<Medicine>(o => andFilter);

            if(_filter.Disease != null)
            {
                specification = specification.And(GetSpecificationByDisease(_filter.Disease));
            }

            if(_filter.Ingredient != null)
            {
                specification = specification.And(GetSpecificationByIngredient(_filter.Ingredient));
            }

            if(!String.IsNullOrEmpty(_filter.Name))
            {
                specification = specification.And(GetSpecificationByName(_filter.Name));
            }

            specification = specification.And(GetSpecificationByType(_filter.Type));

            return specification;
        }

    }
}