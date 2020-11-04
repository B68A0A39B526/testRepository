using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Util
{
    public class RecommendationDTO
    {
        private Doctor _doctor;
        private TimeInterval _doctorShift;
        private List<Appointment> _takenAppointments;

        public RecommendationDTO(Doctor doctor, TimeInterval doctorShift, List<Appointment> takenAppointments)
        {
            _doctor = doctor;
            _doctorShift = doctorShift;
            _takenAppointments = takenAppointments;
        }

        public TimeInterval DoctorShift { get => _doctorShift; set => _doctorShift = value; }
        public List<Appointment> TakenAppointments { get => _takenAppointments; set => _takenAppointments = value; }
        public Doctor Doctor { get => _doctor; set => _doctor = value; }
    }
}
