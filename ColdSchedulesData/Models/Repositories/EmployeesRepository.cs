using ColdSchedulesData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColdSchedulesData.Models.Repositories
{
    public interface IEmployeesRepository : IBaseRepository<Employees>
    {
        void CreateEmp(Employees emp);

        void UpdateEmp(Employees emp);

        void Deactive(Employees emp);

        Employees GetEmployee(int id);

        IQueryable<Employees> GetEmployees();
        
    }


    public class EmployeesRepository : BaseRepository<Employees> , IEmployeesRepository
    {
        public EmployeesRepository(ScheduleManagementContext context) : base(context)
        {
        }

        public void CreateEmp(Employees emp)
        {
            Add(emp);
        }

        public void UpdateEmp(Employees emp)
        {
            Edit(emp);
        }

        public void Deactive(Employees emp)
        {
            Deactivate(emp);
        }

        public Employees GetEmployee(int id)
        {
            return GetActive(q => q.EmpId == id).FirstOrDefault();
        }

        public IQueryable<Employees> GetEmployees()
        {
            return GetActive();
        }
    }
}
