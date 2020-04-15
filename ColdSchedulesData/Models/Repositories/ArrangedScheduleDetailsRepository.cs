using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColdSchedulesData.Models.Repositories
{
    public interface IArrangedScheduleDetailsRepository: IBaseRepository<ArrangedScheduleDetails>
    {
        void CreateArrangedSD(List<ArrangedScheduleDetails> details);

        IQueryable<ArrangedScheduleDetails> GetArrangedSDs(int id);
    }
    public class ArrangedScheduleDetailsRepository : BaseRepository<ArrangedScheduleDetails>, IArrangedScheduleDetailsRepository
    {
        public ArrangedScheduleDetailsRepository(ScheduleManagementContext context): base(context)
        {

        }

        public void CreateArrangedSD(List<ArrangedScheduleDetails> details)
        {
            AddRange(details);
        }

        public IQueryable<ArrangedScheduleDetails> GetArrangedSDs(int id)
        {
            return Get(q => q.ArrangedScheduleId == id);
        }
    }
}
