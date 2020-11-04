using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Util
{
    public class AppointmentRecommendationDTO
    {
        private Doctor _doctor;
        private TimeInterval _timeInterval;
        private RecommendationPriority _priority;

        public AppointmentRecommendationDTO(Doctor doctor, TimeInterval timeInterval, RecommendationPriority priority)
        {
            _doctor = doctor;
            _timeInterval = timeInterval;
            _priority = priority;
        }

        public Doctor Doctor { get => _doctor; set => _doctor = value; }
        public TimeInterval TimeInterval { get => _timeInterval; set => _timeInterval = value; }
        public RecommendationPriority Priority { get => _priority; set => _priority = value; }
    }
}
