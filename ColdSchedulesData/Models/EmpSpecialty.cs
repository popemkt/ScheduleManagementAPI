using System;
using System.Collections.Generic;

namespace ColdSchedulesData.Models
{
    public partial class EmpSpecialty
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? SpecialtyId { get; set; }

        public virtual Employees Emp { get; set; }
        public virtual Specialty Specialty { get; set; }
    }
}
