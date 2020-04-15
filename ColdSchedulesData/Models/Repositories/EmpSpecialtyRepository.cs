using System;
using System.Collections.Generic;
using System.Text;

namespace ColdSchedulesData.Models.Repositories
{
    public interface IEmpSpecialtyRepository: IBaseRepository<EmpSpecialty>
    {
        void CreateeEmpSpecialty(EmpSpecialty specialty);

        void CreateEmpSpecialtis(List<EmpSpecialty> list);

        void ActiveEmpSpecialty(EmpSpecialty specialty);

        void DeactiveEmpSpecialty(EmpSpecialty specialty);

        EmpSpecialty GetEMpSpecialty(int empID, int specID);
    }
    public class EmpSpecialtyRepository : BaseRepository<EmpSpecialty>, IEmpSpecialtyRepository
    {
        public EmpSpecialtyRepository(ScheduleManagementContext context): base(context)
        {

        }

        public void ActiveEmpSpecialty(EmpSpecialty specialty)
        {
            Activate(specialty);
        }

        public void CreateeEmpSpecialty(EmpSpecialty specialty)
        {
            Add(specialty);
        }

        public void CreateEmpSpecialtis(List<EmpSpecialty> list)
        {
            AddRange(list);
        }

        public void DeactiveEmpSpecialty(EmpSpecialty specialty)
        {
            Deactivate(specialty);
        }

        public EmpSpecialty GetEMpSpecialty(int empID, int specID)
        {
            return FirstOrDefault(q => q.EmpId == empID && q.SpecialtyId == specID);
        }
    }
}
