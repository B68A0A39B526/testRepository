// File:    AppointmentRepository.cs
// Author:  Geri
// Created: 23. maj 2020 18:19:34
// Purpose: Definition of Class AppointmentRepository

using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using Backend.Specifications;
using Backend.Specifications.Converter;
using Backend.Util;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repository.MySQLRepository.MedicalRepository
{
    public class AppointmentRepository : MySQLRepository<Appointment, long>, IAppointmentRepository, IEagerRepository<Appointment, long>
    {
        private const string ENTITY_NAME = "Appointment";
        private string[] INCLUDE_PROPERTIES = { "DoctorInAppointment", "Room", "Patient", "TimeInterval" };

        public AppointmentRepository(IMySQLStream<Appointment> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Appointment>())
        {
        }

        public IEnumerable<Appointment> GetPatientAppointments(Patient patient)
            => GetAllEager().Where(appointment => IsUserIdsEquals(appointment.Patient, patient));

        private bool IsUserIdsEquals(User appointmentUser, User selectedUser)
            => appointmentUser == null ? false : appointmentUser.GetId().Equals(selectedUser.GetId());

        public IEnumerable<Appointment> GetAppointmentsByTime(TimeInterval timeInterval) //Note (Gergo) : Ima vise smisla da trazimo termine koje se sudaraju sa prosledjenim intervalom
            => GetAllEager().Where(appointment => appointment.TimeInterval.IsOverlappingWith(timeInterval));

        public IEnumerable<Appointment> GetAppointmentsByDoctor(Doctor doctor)
            => GetAllEager().Where(appointment => IsUserIdsEquals(appointment.DoctorInAppointment, doctor));

        public IEnumerable<Appointment> GetCanceledAppointments()
            => GetAllEager().Where(appointment => appointment.Canceled == true);

        public IEnumerable<Appointment> GetAppointmentsByRoom(Room room)
            => GetAllEager().Where(appointment => IsRoomIdsEquals(appointment.Room, room));

        private bool IsRoomIdsEquals(Room appointmentRoom, Room selectedRoom)
            => appointmentRoom == null ? false : appointmentRoom.GetId() == selectedRoom.GetId();

        public IEnumerable<Appointment> GetFilteredAppointment(AppointmentFilter appointmentFilter)
        {
            ISpecification<Appointment> specification = new AppointmentSpecificationConverter(appointmentFilter).GetSpecification();
            var appointments = Find(specification);
            var eagerApps = GetAllEager();
            IEnumerable<Appointment> result = new List<Appointment>();
            foreach (var app in appointments)
            {
                foreach (var eagerApp in eagerApps)
                {
                    if (app.Id == eagerApp.Id)
                    {
                        result.Append(eagerApp);
                    }
                }
            }
            return result;
        }

        public Appointment GetEager(long id)
            => GetAllEager().SingleOrDefault(appointment => appointment.GetId() == id);

        public IEnumerable<Appointment> GetAllEager()
            => GetAllEager(INCLUDE_PROPERTIES);
    }
}