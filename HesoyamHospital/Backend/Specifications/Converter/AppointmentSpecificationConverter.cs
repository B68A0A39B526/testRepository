// File:    AppointmentSpecificationConverter.cs
// Author:  Geri
// Created: 23. maj 2020 18:41:37
// Purpose: Definition of Class AppointmentSpecificationConverter

using Backend.Model.DoctorModel;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Util;
using System;

namespace Backend.Specifications.Converter
{
    public class AppointmentSpecificationConverter
    {
        private AppointmentFilter _filter;

        public AppointmentSpecificationConverter(AppointmentFilter filter)
        {
            _filter = filter;
        }
        private ISpecification<Appointment> GetSpecificationByDoctorType(DoctorType type)
        {
            return new ExpressionSpecification<Appointment>(o => o.DoctorInAppointment == null ? false : o.DoctorInAppointment.DoctorType == type);
        }

        private ISpecification<Appointment> GetSpecificationByDoctor(Doctor doctor)
        {
            return new ExpressionSpecification<Appointment>(o => o.DoctorInAppointment == null ? false : o.DoctorInAppointment.Equals(doctor));
        }

        private ISpecification<Appointment> GetSpecificationByTimeInterval(Util.TimeInterval timeInterval)
        {
            return new ExpressionSpecification<Appointment>(o => o.TimeInterval == null ? false : o.TimeInterval.Equals(timeInterval));
        }

        private ISpecification<Appointment> GetSpecificationByType(AppointmentType type)
        {
            return new ExpressionSpecification<Appointment>(o => o.AppointmentType.Equals(type));
        }

        public ISpecification<Appointment> GetSpecification()
        {
            ISpecification<Appointment> specification = new ExpressionSpecification<Appointment>(o => true);
            
            specification = specification.And(GetSpecificationByType(_filter.Type));

            if(_filter.TimeInterval != null)
            {
                specification = specification.And(GetSpecificationByTimeInterval(_filter.TimeInterval));
            }

            if(_filter.Doctor != null)
            {
                specification = specification.And(GetSpecificationByDoctor(_filter.Doctor));
            }

            if(_filter.DoctorType != DoctorType.UNDEFINED)
                specification = specification.And(GetSpecificationByDoctorType(_filter.DoctorType));

            return specification;
        }

    }
}