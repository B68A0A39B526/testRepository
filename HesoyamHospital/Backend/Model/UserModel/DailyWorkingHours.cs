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
        public long Id { get; set; }
        public WorkingDaysEnum Day { get; set; }
        public virtual TimeInterval TimeInterval { get; set; }

        public DailyWorkingHours() { }

        public DailyWorkingHours(WorkingDaysEnum day, TimeInterval timeInterval)
        {
            Day = day;
            TimeInterval = timeInterval;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public override bool Equals(object obj)
        {
            var dwh = obj as DailyWorkingHours;
            return dwh != null &&
                   Id == dwh.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }
    }
}
