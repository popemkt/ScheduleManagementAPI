using System;
using System.Collections.Generic;
using System.Text;

namespace ColdSchedulesData.ViewModels
{
    public class EmpScheduleRegistrationViewModel
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? HourSlot { get; set; }
        public int? SpecialtyId { get; set; }
        public int? EmpId { get; set; }
        
        //extend
    }
}
