using System;
using System.Collections.Generic;

namespace ColdSchedulesData.Models
{
    public partial class ArrangedScheduleDetails
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int HourSlot { get; set; }
        public int SpecialtyId { get; set; }
        public int EmpId { get; set; }
        public int ArrangedScheduleId { get; set; }
        public bool Active { get; set; }

        public virtual ArrangedSchedule ArrangedSchedule { get; set; }
        public virtual Employees Emp { get; set; }
        public virtual Specialty Specialty { get; set; }
    }
}
