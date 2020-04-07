using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColdSchedulesData.Models.Repositories
{
    public interface IEmpScheduleRegistrationRepository : IBaseRepository<EmpScheduleRegistration>
    {
        void CreateScheduleForWeek(List<EmpScheduleRegistration> list);

        void UpdateScheduleForWeek(List<EmpScheduleRegistration> list);

        void DeactiveScheduleForWeek(List<EmpScheduleRegistration> list);

        IQueryable<EmpScheduleRegistration> GetScheduleForWeek(int id);
    }

    public class EmpScheduleRegistrationRepository : BaseRepository<EmpScheduleRegistration>, IEmpScheduleRegistrationRepository
    {
        public EmpScheduleRegistrationRepository(ScheduleManagementContext context) : base(context)
        {
        }

        public void CreateScheduleForWeek(List<EmpScheduleRegistration> list)
        {
            AddRange(list);
        }

        public void DeactiveScheduleForWeek(List<EmpScheduleRegistration> list)
        {
            foreach(var item in list)
            {
                Edit(item);
            }
        }

        public IQueryable<EmpScheduleRegistration> GetScheduleForWeek(int id)
        {
            return GetActive(q=> q.EmpId == id);
        }

        public void UpdateScheduleForWeek(List<EmpScheduleRegistration> list)
        {
            foreach (var item in list)
            {
                Deactivate(item);
            }
        }
    }
}
