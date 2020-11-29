using Backend.Util;

namespace Backend.Model.PatientModel
{
    public class TimeIntervalFilter
    {
        public TimeInterval TimeInterval { get; set; }
        public IntervalMatchFilter Filter { get; set; }

        public TimeIntervalFilter()
        {

        }
        public TimeIntervalFilter (TimeInterval timeInterval, IntervalMatchFilter filter)
        {
            TimeInterval = timeInterval;
            Filter = filter;
        }
    }
}
