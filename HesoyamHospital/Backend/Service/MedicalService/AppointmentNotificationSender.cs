using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Service.MiscService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service.MedicalService
{
    public class AppointmentNotificationSender
    {
        private NotificationService _notificationService;
        private string _cancelMessage = "Your appointment has been cancelled.\n\n{0} - {1}\nDoctor: {2}\n{3}";
        private string _createMessage = "New appointment has been scheduled.\n\n{0} - {1}\nDoctor: {2}\nRoom: {3}\n{4}";
        private string _updateMessage = "Your appointment has been edited.\n\nOld appointment:\n{0} - {1}\nDoctor: {2}\nRoom: {3}\n{4}\n\nNew appointment:\n{5} - {6}\nDoctor: {7}\nRoom: {8}\n{9}";

        private string _dateFormat = "dd.MM.yyyy. HH:mm";
        public AppointmentNotificationSender(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        private void Send(User user, string message)
        {
            Notification notification = new Notification(message, user);
            _notificationService.Create(notification);
        }

        public void SendCancelNotification(Appointment appointment)
        {
            string message = String.Format(_cancelMessage, GetDateString(appointment.TimeInterval.StartTime), GetDateString(appointment.TimeInterval.EndTime), GetDoctorString(appointment), appointment.AppointmentType);
            Send(appointment.Patient, message);
        }

        public void SendCreateNotification(Appointment appointment)
        {
            string message = String.Format(_createMessage, GetDateString(appointment.TimeInterval.StartTime), GetDateString(appointment.TimeInterval.EndTime), GetDoctorString(appointment), GetRoomString(appointment), appointment.AppointmentType);
            Send(appointment.Patient, message);
        }

        public void SendUpdateNotification(Appointment oldAppointment, Appointment newAppointment)
        {
            string message = String.Format(_updateMessage, GetDateString(oldAppointment.TimeInterval.StartTime), GetDateString(oldAppointment.TimeInterval.EndTime), GetDoctorString(oldAppointment), GetRoomString(oldAppointment), oldAppointment.AppointmentType,
                                                            GetDateString(newAppointment.TimeInterval.StartTime), GetDateString(newAppointment.TimeInterval.EndTime), GetDoctorString(newAppointment), GetRoomString(newAppointment), newAppointment.AppointmentType);
            Send(newAppointment.Patient, message);
        }

        private string GetDateString(DateTime date)
            => date.ToString(_dateFormat);

        private string GetDoctorString(Appointment appointment)
            => appointment.DoctorInAppointment?.FullName;

        private string GetRoomString(Appointment appointment)
            => appointment.Room?.RoomNumber;

    }
}
