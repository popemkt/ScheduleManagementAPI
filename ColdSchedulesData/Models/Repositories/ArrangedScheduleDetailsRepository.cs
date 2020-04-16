using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColdSchedulesData.Models.Repositories
{
    public interface IArrangedScheduleDetailsRepository: IBaseRepository<ArrangedScheduleDetails>
    {
        void CreateArrangedSD(ArrangedScheduleDetails detail);

        void CreateArrangedSDs(List<ArrangedScheduleDetails> details);

        IQueryable<ArrangedScheduleDetails> GetArrangedSDs(int id);

        IQueryable<ArrangedScheduleDetails> GetArrangedSDByASID(int id);

        IQueryable<ArrangedScheduleDetails> GetArrangedSDBySlot(DateTime date, int slot);
    }
    public class ArrangedScheduleDetailsRepository : BaseRepository<ArrangedScheduleDetails>, IArrangedScheduleDetailsRepository
    {
        public ArrangedScheduleDetailsRepository(ScheduleManagementContext context): base(context)
        {

        }

        public void CreateArrangedSDs(List<ArrangedScheduleDetails> details)
        {
            AddRange(details);
        }

        public IQueryable<ArrangedScheduleDetails> GetArrangedSDs(int id)
        {
            return Get(q => q.ArrangedScheduleId == id);
        }

        public IQueryable<ArrangedScheduleDetails> GetArrangedSDByASID(int id)
        {
            return Get(q => q.ArrangedScheduleId == id);
        }

        public IQueryable<ArrangedScheduleDetails> GetArrangedSDBySlot(DateTime date,int slot)
        {
            return Get(q => q.Date == date && q.HourSlot == slot);
        }

        public void CreateArrangedSD(ArrangedScheduleDetails detail)
        {
            Add(detail);
        }
    }
}
