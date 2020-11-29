using Backend.Model.PatientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.Abstract.MedicalAbstractRepository
{
    public interface IReportRepository : IRepository<Report, long>
    {
        IEnumerable<Report> GetAllByPatient(long patientId);
    }
}
