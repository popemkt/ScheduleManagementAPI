﻿using System;
using System.Collections.Generic;

namespace ColdSchedulesData.Models
{
    public partial class Employees
    {
        public Employees()
        {
            ArrangedScheduleDetails = new HashSet<ArrangedScheduleDetails>();
            EmpScheduleRegistration = new HashSet<EmpScheduleRegistration>();
            EmpSpecialty = new HashSet<EmpSpecialty>();
        }

        public int EmpId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public int RoleId { get; set; }
        public bool Active { get; set; }
        public string FirebaseUid { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<ArrangedScheduleDetails> ArrangedScheduleDetails { get; set; }
        public virtual ICollection<EmpScheduleRegistration> EmpScheduleRegistration { get; set; }
        public virtual ICollection<EmpSpecialty> EmpSpecialty { get; set; }
    }
}
