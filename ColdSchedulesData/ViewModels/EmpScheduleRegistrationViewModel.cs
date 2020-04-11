using System;
using System.Collections.Generic;
using System.Text;

namespace ColdSchedulesData.ViewModels
{
    public class EmpScheduleRegistrationViewModel
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int EmpId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public List<EmpScheduleRegistrationDetailsViewModel> Details { get; set; }
        //extend

        public string EmpName { get; set; }

        public string EmpUsername { get; set; }
    }
}
