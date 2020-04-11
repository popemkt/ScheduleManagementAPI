using System;
using System.Collections.Generic;

namespace ColdSchedulesData.Models
{
    public partial class ArrangedSchedule
    {
        public ArrangedSchedule()
        {
            ArrangedScheduleDetails = new HashSet<ArrangedScheduleDetails>();
        }

        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual ICollection<ArrangedScheduleDetails> ArrangedScheduleDetails { get; set; }
    }
}
