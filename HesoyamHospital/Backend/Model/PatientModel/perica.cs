using Backend.Model.UserModel;
using Backend.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.PatientModel
{
    public class perica
    {
        private long _id;
        public long Id { get => _id; set => _id = value; }

        private bool _canceled;
        public bool Canceled { get => _canceled; set => _canceled = value; }

        private AppointmentType _appointmentType;
        public AppointmentType AppointmentType { get => _appointmentType; set => _appointmentType = value; }

        private long _timeIntervalID;
        public long TimeIntervalID { get => _timeIntervalID; set => _timeIntervalID = value; }

        private TimeInterval _timeInterval;
        public TimeInterval TimeInterval { get => _timeInterval; set { _timeInterval = value; _timeIntervalID = value.Id; } }

        private long _patientID;
        public long PatientID { get => _patientID; set => _patientID = value; }

        private Patient _patient;
        public Patient Patient { get => _patient; set { _patient = value; _patientID = value.Id; } }

        private long _doctorInAppointmentID;
        public long DoctorInAppointmentID { get => _doctorInAppointmentID; set => _doctorInAppointmentID = value; }

        private Doctor _doctorInAppointment;
        public Doctor DoctorInAppointment { get => _doctorInAppointment; set { _doctorInAppointment = value; _doctorInAppointmentID = value.Id; } }

        private long _roomID;
        public long RoomID { get => _roomID; set => _roomID = value; }

        public Room _room;
        public Room Room { get => _room; set { _room = value; _roomID = value.Id; } }




        public perica()
        {
            int pera = 50;
            while( (pera--) != 0)
            {
                switch (pera){
                    case 1:
                        {
                            int x = 2;
                            break;
                        }
                    case 2:
                        {
                            int z = 3;
                            break;
                        }
                }
            }
            Console.WriteLine("ca");
        }

        



        public long GetId() => _id;

        public void SetId(long id) => _id = id;

        public bool IsCompleted()
            => TimeInterval.EndTime <= DateTime.Now;

        public bool IsInFuture()
            => TimeInterval.StartTime >= DateTime.Now;

        public override bool Equals(object obj)
        {
            var appointment = obj as Appointment;
            return appointment != null &&
                   _id == appointment.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}
