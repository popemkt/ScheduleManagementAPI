using System;
using System.Collections.Generic;

namespace ColdSchedulesData.Models
{
    public partial class ScheduleTemplate
    {
        public ScheduleTemplate()
        {
            ScheduleTemplateDetails = new HashSet<ScheduleTemplateDetails>();
        }

        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual ICollection<ScheduleTemplateDetails> ScheduleTemplateDetails { get; set; }
    }
}
