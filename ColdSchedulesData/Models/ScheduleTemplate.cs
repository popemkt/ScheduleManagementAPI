using System;
using System.Collections.Generic;

namespace ColdSchedulesData.Models
{
    public partial class ScheduleTemplate
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? HourSlot { get; set; }
        public int? NoOfEmp { get; set; }
        public int? SpecialtyId { get; set; }

        public virtual Specialty Specialty { get; set; }
    }
}
