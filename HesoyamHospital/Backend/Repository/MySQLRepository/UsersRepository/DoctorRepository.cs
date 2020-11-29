// File:    DoctorRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:27:33
// Purpose: Definition of Class DoctorRepository

using Backend.Model.DoctorModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using Backend.Specifications;
using Backend.Specifications.Converter;
using Backend.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repository.MySQLRepository.UsersRepository
{
    public class DoctorRepository : MySQLRepository<Doctor, long>, IDoctorRepository, IEagerRepository<Doctor, long>
    {
        private const string ENTITY_NAME = "Doctor";
        private readonly IUserRepository _userRepository;
        private const string NOT_UNIQUE_ERROR = "Doctor username {0} is not unique!";

        public DoctorRepository(IMySQLStream<Doctor> stream, ISequencer<long> sequencer, IUserRepository userRepository) : base(ENTITY_NAME, stream, sequencer, new DoctorIdGeneratorStrategy())
        {
            _userRepository = userRepository;
        }

        public new Doctor Create(Doctor doctor)
        {
            if (IsUsernameUnique(doctor.UserName))
            {
                doctor.DateCreated = DateTime.Now;
                doctor = base.Create(doctor);
                _userRepository.AddUser(doctor);
                return doctor;
            }
            else
                throw new NotUniqueException(string.Format(NOT_UNIQUE_ERROR, doctor.UserName));
        }

        public new void Update(Doctor doctor)
        {
            _userRepository.Update(doctor);
            base.Update(doctor);
        }

        private bool IsUsernameUnique(string userName)
            => _userRepository.GetByUsername(userName) == null;

        public IEnumerable<Doctor> GetDoctorByType(DoctorType doctorType)
            => _stream.ReadAll().Where(doctor => doctor.DoctorType == doctorType);

        public IEnumerable<Doctor> GetFilteredDoctors(DoctorFilter filter)
        {
            ISpecification<Doctor> specification = new DoctorSpecificationConverter(filter).GetSpecification();
            var doctors = Find(specification);
            var eagerDocs = GetAllEager();
            IEnumerable<Doctor> result = new List<Doctor>();
            foreach (var doctor in doctors)
            {
                foreach (var eagerDoc in eagerDocs)
                {
                    if (doctor.GetId() == eagerDoc.GetId())
                    {
                        result.Append(eagerDoc);
                    }
                }
            }
            return result;
        }
    }
}