using Backend.Repository.Abstract;
using Backend.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.UserModel
{
    public class DailyWorkingHours : IIdentifiable<long>
    {
        private long _id;
        public long Id { get => _id; set => _id = value; }

        private WorkingDaysEnum _day;
        public WorkingDaysEnum Day { get => _day; set => _day = value; }

        private TimeInterval _timeInterval;
        public TimeInterval TimeInterval { get => _timeInterval; set { _timeInterval = value; _timeIntervalid = value.Id; } }

        private long _timeIntervalid;
        public long TimeIntervalId { get => _timeIntervalid; set => _timeIntervalid = value; }

        public DailyWorkingHours() { }

        public DailyWorkingHours(WorkingDaysEnum day, TimeInterval timeInterval)
        {
            _day = day;
            _timeInterval = timeInterval;
            _timeIntervalid = timeInterval.Id;
        }

        public long GetId() => _id;

        public void SetId(long id) => _id = id;

        public override bool Equals(object obj)
        {
            var dwh = obj as DailyWorkingHours;
            return dwh != null &&
                   _id == dwh._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}
