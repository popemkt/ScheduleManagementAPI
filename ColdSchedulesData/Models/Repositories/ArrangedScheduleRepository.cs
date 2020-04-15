using System;
using System.Collections.Generic;
using System.Text;

namespace ColdSchedulesData.Models.Repositories
{
    public interface IArrangedScheduleRepository : IBaseRepository<ArrangedSchedule>
    {

    }
    public class ArrangedScheduleRepository : BaseRepository<ArrangedSchedule>, IArrangedScheduleRepository
    {
        public ArrangedScheduleRepository(ScheduleManagementContext context): base(context)
        {

        }
    }
}
