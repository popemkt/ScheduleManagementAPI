using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColdSchedulesData.Models.Repositories
{
    public interface IArrangedScheduleRepository : IBaseRepository<ArrangedSchedule>
    {
        void CreateArrangedSchedule(ArrangedSchedule schedule);

        ArrangedSchedule GetArrangedSchedule(DateTime start, DateTime end);

        void UpdateArrangedSchedule(ArrangedSchedule schedule);
    }
    public class ArrangedScheduleRepository : BaseRepository<ArrangedSchedule>, IArrangedScheduleRepository
    {
        public ArrangedScheduleRepository(ScheduleManagementContext context) : base(context)
        {

        }

        public void CreateArrangedSchedule(ArrangedSchedule schedule)
        {
            Add(schedule);
        }

        public ArrangedSchedule GetArrangedSchedule(DateTime start, DateTime end)
        {
            return FirstOrDefault(q => q.FromDate == start && q.ToDate == end);
        }

        public void UpdateArrangedSchedule(ArrangedSchedule schedule)
        {
            Edit(schedule);
        }
    }
}
