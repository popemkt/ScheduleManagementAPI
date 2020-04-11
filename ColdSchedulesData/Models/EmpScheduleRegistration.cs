using System;
using System.Collections.Generic;

namespace ColdSchedulesData.Models
{
    public partial class EmpScheduleRegistration
    {
        public EmpScheduleRegistration()
        {
            EmpScheduleRegistrationDetails = new HashSet<EmpScheduleRegistrationDetails>();
        }

        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int EmpId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual Employees Emp { get; set; }
        public virtual ICollection<EmpScheduleRegistrationDetails> EmpScheduleRegistrationDetails { get; set; }
    }
}
