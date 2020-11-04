using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Util
{
    public class TimeIterator
    {
        private DateTime _frameStart;   // start1
        private DateTime _frameEnd;     // start2
        private DateTime _endTime;
        private int _durationMinutes;

        public TimeIterator(int durationMinutes, TimeInterval time)
        {
            _durationMinutes = durationMinutes;
            _frameStart = time.StartTime;
            _frameEnd = _frameStart.AddMinutes(_durationMinutes);
            _endTime = time.EndTime;
        }

        public TimeInterval GetCurrentTimeFrame()
        {
            return new TimeInterval(_frameStart, _frameEnd);
        }

        public void Next()
        {
            _frameStart = _frameEnd;
            _frameEnd = _frameStart.AddMinutes(_durationMinutes);
        }

        public void SkipInterval(TimeInterval timeInterval)
        {
            _frameStart = timeInterval.EndTime;
            _frameEnd = _frameStart.AddMinutes(_durationMinutes);
        }

        public bool HasNext()
        {
            return _frameEnd < _endTime;
        }
    }
}
