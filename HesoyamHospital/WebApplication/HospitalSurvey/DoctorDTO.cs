using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.HospitalSurvey
{
    public class DoctorDTO
    {


        public long Id { get; set; }
        public string UserName { get; set; }

        public double AverageGrade { get; set;}
            
        public DoctorDTO() { }
        
        public DoctorDTO(long id, string userName)
        {
            Id = id;
            UserName = userName;
        }
    }
}
