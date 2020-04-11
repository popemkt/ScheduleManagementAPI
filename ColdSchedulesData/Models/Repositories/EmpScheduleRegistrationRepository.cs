using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColdSchedulesData.Models.Repositories
{
    public interface IEmpScheduleRegistrationRepository : IBaseRepository<EmpScheduleRegistration>
    {
        void CreateScheduleForWeek(EmpScheduleRegistration empSR);

        void UpdateScheduleForWeek(EmpScheduleRegistration empSR);

        EmpScheduleRegistration GetScheduleForWeek(int empID, DateTime start, DateTime end);
    }

    public class EmpScheduleRegistrationRepository : BaseRepository<EmpScheduleRegistration>, IEmpScheduleRegistrationRepository
    {
        public EmpScheduleRegistrationRepository(ScheduleManagementContext context) : base(context)
        {
        }

        public void CreateScheduleForWeek(EmpScheduleRegistration empSR)
        {
            Add(empSR);
        }

        public EmpScheduleRegistration GetScheduleForWeek(int empID, DateTime start, DateTime end)
        {
            return FirstOrDefault(q=> q.EmpId == empID &&  q.FromDate == start && q.ToDate == end);
        }

        public void UpdateScheduleForWeek(EmpScheduleRegistration empSR)
        {
            Edit(empSR);
        }
    }
}
