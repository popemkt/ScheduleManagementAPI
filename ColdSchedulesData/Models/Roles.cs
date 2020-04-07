using System;
using System.Collections.Generic;

namespace ColdSchedulesData.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Employees = new HashSet<Employees>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
