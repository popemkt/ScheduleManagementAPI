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

        EmpScheduleRegistration GetScheduleForWeekByID(int id);
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
            return Get(q => q.EmpId == empID && q.FromDate == start && q.ToDate == end).OrderByDescending(q => q.Id).FirstOrDefault();
        }

        public EmpScheduleRegistration GetScheduleForWeekByID(int id)
        {
            return FirstOrDefault(q => q.Id == id);
        }

        public void UpdateScheduleForWeek(EmpScheduleRegistration empSR)
        {
            Edit(empSR);
        }
    }
}
