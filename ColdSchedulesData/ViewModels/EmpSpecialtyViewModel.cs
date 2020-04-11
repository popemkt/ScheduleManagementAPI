using System;
using System.Collections.Generic;
using System.Text;

namespace ColdSchedulesData.ViewModels
{
    public class EmpSpecialtyViewModel
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? SpecialtyId { get; set; }

        //extend

        public string EmpName { get; set; }

        public string SpecialtyName { get; set; }
    }
}
