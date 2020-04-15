using System;
using System.Collections.Generic;
using System.Text;

namespace ColdSchedulesData.Models.Repositories
{
    public interface IArrangedScheduleDetailsRepository: IBaseRepository<ArrangedScheduleDetails>
    {

    }
    public class ArrangedScheduleDetailsRepository : BaseRepository<ArrangedScheduleDetails>, IArrangedScheduleDetailsRepository
    {
        public ArrangedScheduleDetailsRepository(ScheduleManagementContext context): base(context)
        {

        }
    }
}
