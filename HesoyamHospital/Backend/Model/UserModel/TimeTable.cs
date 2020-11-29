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
        public long Id { get; set; }
        public virtual List<DailyWorkingHours> WorkingHours { get; set; }

        public TimeTable(List<DailyWorkingHours> workingHours)
        {
            WorkingHours = workingHours;
        }

        public TimeTable(long id, List<DailyWorkingHours> workingHours)
        {
            Id = id;
            WorkingHours = workingHours;
        }

        public TimeTable()
        {
            WorkingHours = new List<DailyWorkingHours>();
        }

        public TimeTable(long id)
        {
            Id = id;
        }

        public bool Edit()
        {
            throw new NotImplementedException();
        }

        public List<DailyWorkingHours> getWorkingHours()
        {
            return WorkingHours;
        }

        public void setWorkingHours(DailyWorkingHours newDailyWorkingHours)
        {
            DailyWorkingHours dwh = WorkingHours.Find(d => d.Day == newDailyWorkingHours.Day);
            if (dwh != null)
            {
                dwh.TimeInterval = newDailyWorkingHours.TimeInterval;
            }
            else
            {
                WorkingHours.Add(newDailyWorkingHours);
            }
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public override bool Equals(object obj)
        {
            var table = obj as TimeTable;
            return table != null &&
                   Id == table.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }
    }
}