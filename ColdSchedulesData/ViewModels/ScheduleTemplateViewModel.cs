using System;
using System.Collections.Generic;
using System.Text;

namespace ColdSchedulesData.ViewModels
{
    public class ScheduleTemplateViewModel
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? HourSlot { get; set; }
        public int? NoOfEmp { get; set; }
        public int? SpecialtyId { get; set; }

        //extend
    }
}
