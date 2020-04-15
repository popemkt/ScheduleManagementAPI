using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColdSchedulesData.Models.Repositories
{
    public interface IScheduleTemplateDetailsRepository : IBaseRepository<ScheduleTemplateDetails>
    {
        void ActiveTemplateDetail(ScheduleTemplateDetails detail);

        void CreateTemplateDetail(ScheduleTemplateDetails detail);

        void CreateTemplateDetails(List<ScheduleTemplateDetails> details);

        void DeactiveTemplateeDetail(ScheduleTemplateDetails detail);

        IQueryable<ScheduleTemplateDetails> GetTemplateDetais(int id);
    }
    public class ScheduleTemplateDetailsRepository : BaseRepository<ScheduleTemplateDetails>, IScheduleTemplateDetailsRepository
    {
        public ScheduleTemplateDetailsRepository(ScheduleManagementContext context): base(context)
        {

        }

        public void ActiveTemplateDetail(ScheduleTemplateDetails detail)
        {
            Activate(detail);
        }

        public void CreateTemplateDetail(ScheduleTemplateDetails detail)
        {
            Add(detail);
        }

        public void CreateTemplateDetails(List<ScheduleTemplateDetails> details)
        {
            AddRange(details);
        }

        public void DeactiveTemplateeDetail(ScheduleTemplateDetails detail)
        {
            Deactivate(detail);
        }

        public IQueryable<ScheduleTemplateDetails> GetTemplateDetais(int id)
        {
            return Get(q => q.ScheduleTemplateId == id);
        }
    }
}
