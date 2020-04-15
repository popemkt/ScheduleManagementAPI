using System;
using System.Collections.Generic;
using System.Text;

namespace ColdSchedulesData.Models.Repositories
{
    public interface ISpecialtyRepository : IBaseRepository<Specialty>
    {

    }
    public class SpecialtyRepository : BaseRepository<Specialty>, ISpecialtyRepository
    {
        public SpecialtyRepository(ScheduleManagementContext context): base(context)
        {

        }
    }
}
