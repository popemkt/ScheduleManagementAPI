using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColdSchedulesData.Models.Repositories
{
    public interface IEmpScheduleRegistrationDetailsRepository : IBaseRepository<EmpScheduleRegistrationDetails>
    {
        void CreateEmpSRD(EmpScheduleRegistrationDetails detail);

        void CreateEmpSRDs(List<EmpScheduleRegistrationDetails> details);

        void DeactiveEmpSRD(EmpScheduleRegistrationDetails detail);

        IQueryable<EmpScheduleRegistrationDetails> GetEmpSRDs(int empSRID);
    }

    public class EmpScheduleRegistrationDetailsRepository : BaseRepository<EmpScheduleRegistrationDetails>, IEmpScheduleRegistrationDetailsRepository
    {

        public EmpScheduleRegistrationDetailsRepository(ScheduleManagementContext context) : base(context)
        {

        }

        public void CreateEmpSRD(EmpScheduleRegistrationDetails detail)
        {
            Add(detail);
        }

        public void CreateEmpSRDs(List<EmpScheduleRegistrationDetails> details)
        {
            AddRange(details);
        }

        public void DeactiveEmpSRD(EmpScheduleRegistrationDetails detail)
        {
            Deactivate(detail);
        }

        public IQueryable<EmpScheduleRegistrationDetails> GetEmpSRDs(int empSRID)
        {
            return Get(q => q.EmpScheduleRegistrationId == empSRID);
        }
    }
}
