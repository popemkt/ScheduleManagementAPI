using System;
using System.Collections.Generic;
using System.Text;

namespace ColdSchedulesData.ViewModels
{
    public partial class ScheduleTemplateDetailsViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int HourSlot { get; set; }
        public int NoOfEmp { get; set; }
        public int SpecialtyId { get; set; }
        public int ScheduleTemplateId { get; set; }

        //extend

        public string SpecialtyName { get; set; }
    }
}
