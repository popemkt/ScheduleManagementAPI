using System;
using System.Collections.Generic;

namespace ColdSchedulesData.Models
{
    public partial class Specialty
    {
        public Specialty()
        {
            ArrangedScheduleDetails = new HashSet<ArrangedScheduleDetails>();
            EmpSpecialty = new HashSet<EmpSpecialty>();
            ScheduleTemplateDetails = new HashSet<ScheduleTemplateDetails>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArrangedScheduleDetails> ArrangedScheduleDetails { get; set; }
        public virtual ICollection<EmpSpecialty> EmpSpecialty { get; set; }
        public virtual ICollection<ScheduleTemplateDetails> ScheduleTemplateDetails { get; set; }
    }
}
