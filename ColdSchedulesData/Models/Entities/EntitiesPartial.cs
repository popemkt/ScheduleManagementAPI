using ColdSchedulesData.Global;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColdSchedulesData.Models
{
    class EntitiesPartial
    {
    }

    public partial class ArrangedSchedule : IEntity
    {
    }

    public partial class ArrangedScheduleDetails : IEntity
    {
    }

    public partial class Employees : IEntity, IActive
    {
    }
    
    public partial class EmpScheduleRegistration : IEntity
    {
    }

    public partial class EmpScheduleRegistrationDetails : IEntity, IActive
    {
    }

    public partial class EmpSpecialty : IEntity
    {
    }

    public partial class Roles : IEntity
    {
    }

    public partial class ScheduleTemplate : IEntity
    {
    }

    public partial class ScheduleTemplateDetails : IEntity, IActive
    {
    }
    
    public partial class Specialty : IEntity
    {
    }
}
