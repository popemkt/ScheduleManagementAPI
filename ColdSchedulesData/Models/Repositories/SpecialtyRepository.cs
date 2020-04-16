using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColdSchedulesData.Models.Repositories
{
    public interface ISpecialtyRepository : IBaseRepository<Specialty>
    {
        IQueryable<Specialty> GetSpecialties();

        void CreateSpecialty(Specialty specialty);

        void UpdateSpecialty(Specialty specialty);
    }
    public class SpecialtyRepository : BaseRepository<Specialty>, ISpecialtyRepository
    {
        public SpecialtyRepository(ScheduleManagementContext context): base(context)
        {

        }

        public void CreateSpecialty(Specialty specialty)
        {
            Add(specialty);
        }

        public IQueryable<Specialty> GetSpecialties()
        {
            return Get();
        }

        public void UpdateSpecialty(Specialty specialty)
        {
            Edit(specialty);
        }
    }
}
