using System;
using System.Collections.Generic;

namespace ColdSchedulesData.Models
{
    public partial class Specialty
    {
        public Specialty()
        {
            ArrangedSchedule = new HashSet<ArrangedSchedule>();
            EmpScheduleRegistration = new HashSet<EmpScheduleRegistration>();
            EmpSpecialty = new HashSet<EmpSpecialty>();
            ScheduleTemplate = new HashSet<ScheduleTemplate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArrangedSchedule> ArrangedSchedule { get; set; }
        public virtual ICollection<EmpScheduleRegistration> EmpScheduleRegistration { get; set; }
        public virtual ICollection<EmpSpecialty> EmpSpecialty { get; set; }
        public virtual ICollection<ScheduleTemplate> ScheduleTemplate { get; set; }
    }
}
