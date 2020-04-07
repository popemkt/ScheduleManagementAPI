using AutoMapper;
using ColdSchedulesData.Global;
using ColdSchedulesData.Models;
using ColdSchedulesData.Models.Repositories;
using ColdSchedulesData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColdSchedulesData.Domain
{
    public interface IEmployeesDomain
    {
        ResponseViewModel GetEmployees();

        ResponseViewModel CreateEmployees(EmployeesViewModel model);

        ResponseViewModel UpdateEmployees();

        ResponseViewModel DeleteEmployees();
    }

    public class EmployeesDomain : BaseDomain, IEmployeesDomain
    {
        private readonly IMapper _mapper;

        public EmployeesDomain(IMapper mapper, IUnitOfWork uow) : base(uow)
        {
            this._mapper = mapper;
        }

        public ResponseViewModel CreateEmployees(EmployeesViewModel model)
        {
            var empRepo = _uow.GetService<IEmployeesRepository>();
            var emp = _mapper.Map<Employees>(model);

            //empRepo.CreateEmployees(emp);

            return new ResponseViewModel();
        }

        public ResponseViewModel DeleteEmployees()
        {
            //var repo = Dependency Injection IRepo
            return new ResponseViewModel();
        }

        public ResponseViewModel GetEmployees()
        {
            var empRepo = _uow.GetService<IEmployeesRepository>();

            var result = _mapper.Map<List<EmployeesViewModel>>(empRepo.GetEmployees().ToList());
            return new ResponseViewModel { Data = result, Success = true};
        }

        public ResponseViewModel UpdateEmployees()
        {
            //var repo = Dependency Injection IRepo
            return new ResponseViewModel();
        }

      
    }
}
