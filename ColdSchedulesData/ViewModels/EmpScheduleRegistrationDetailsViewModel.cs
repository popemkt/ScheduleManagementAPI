using System;
using System.Collections.Generic;
using System.Text;

namespace ColdSchedulesData.ViewModels
{
    public class EmpScheduleRegistrationDetailsViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int HourSlot { get; set; }
        public bool Active { get; set; }
        public int EmpScheduleRegistrationId { get; set; }

        //extend
    }
}
