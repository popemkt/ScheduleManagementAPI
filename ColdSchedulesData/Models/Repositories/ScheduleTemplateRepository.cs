using System;
using System.Collections.Generic;
using System.Text;

namespace ColdSchedulesData.Models.Repositories
{
    public interface IScheduleTemplateRepository : IBaseRepository<ScheduleTemplate>
    {
        void CreateTemplate(ScheduleTemplate scheduleTemplate);

        void UpdateTemplate(ScheduleTemplate scheduleTemplate);

        void DeleteTemplate(ScheduleTemplate scheduleTemplate);

        ScheduleTemplate GetTemplate(DateTime start, DateTime end);
    }
    public class ScheduleTemplateRepository : BaseRepository<ScheduleTemplate>, IScheduleTemplateRepository
    {
        public ScheduleTemplateRepository(ScheduleManagementContext context) : base(context)
        {

        }

        public void CreateTemplate(ScheduleTemplate scheduleTemplate)
        {
            Add(scheduleTemplate);
        }

        public void DeleteTemplate(ScheduleTemplate scheduleTemplate)
        {
            Deactivate(scheduleTemplate);
        }

        public ScheduleTemplate GetTemplate(DateTime start, DateTime end)
        {
            return FirstOrDefault(q => q.FromDate == start && q.ToDate == end);
        }

        public void UpdateTemplate(ScheduleTemplate scheduleTemplate)
        {
            Edit(scheduleTemplate);
        }
    }
}
