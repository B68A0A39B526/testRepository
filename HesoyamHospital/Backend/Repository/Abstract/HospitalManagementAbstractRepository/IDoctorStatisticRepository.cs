using Backend.Model.ManagerModel;
using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository.Abstract.HospitalManagementAbstractRepository
{
    public interface IDoctorStatisticRepository : IRepository<StatsDoctor, long>
    {
        IEnumerable<StatsDoctor> GetDoctorStatistics();

        IEnumerable<StatsDoctor> GetStatisticsByDoctor(Doctor doctor);



    }
}
