// File:    TimeTable.cs
// Author:  Geri
// Created: 18. april 2020 19:37:52
// Purpose: Definition of Class TimeTable

using Backend.Repository.Abstract;
using Backend.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Model.UserModel
{
    public class TimeTable : IIdentifiable<long>
    {
        private long _id;
        public long Id { get => _id; set => _id = value; }

        private List<DailyWorkingHours> _workingHours;
        public List<DailyWorkingHours> WorkingHours { get => _workingHours; set => _workingHours = value; }

        public TimeTable(List<DailyWorkingHours> workingHours)
        {
            _workingHours = workingHours;
        }

        public TimeTable(long id, List<DailyWorkingHours> workingHours)
        {
            _id = id;
            _workingHours = workingHours;
        }

        public TimeTable()
        {
            _workingHours = new List<DailyWorkingHours>();
        }

        public TimeTable(long id)
        {
            _id = id;
        }

        public bool Edit()
        {
            throw new NotImplementedException();
        }

        public List<DailyWorkingHours> getWorkingHours()
        {
            return _workingHours;
        }

        public void setWorkingHours(DailyWorkingHours newDailyWorkingHours)
        {
            DailyWorkingHours dwh = _workingHours.Find(d => d.Day == newDailyWorkingHours.Day);
            if (dwh != null)
            {
                dwh.TimeInterval = newDailyWorkingHours.TimeInterval;
            }
            else
            {
                _workingHours.Add(newDailyWorkingHours);
            }
        }

        public long GetId() => _id;

        public void SetId(long id) => _id = id;

        public override bool Equals(object obj)
        {
            var table = obj as TimeTable;
            return table != null &&
                   _id == table._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}