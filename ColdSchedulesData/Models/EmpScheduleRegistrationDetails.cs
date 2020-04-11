using System;
using System.Collections.Generic;

namespace ColdSchedulesData.Models
{
    public partial class EmpScheduleRegistrationDetails
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int HourSlot { get; set; }
        public bool Active { get; set; }
        public int EmpScheduleRegistrationId { get; set; }

        public virtual EmpScheduleRegistration EmpScheduleRegistration { get; set; }
    }
}
