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

        ResponseViewModel UpdateEmployees(EmployeesViewModel model);

        ResponseViewModel DeleteEmployees(int id);
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
            try
            {
                var empRepo = _uow.GetService<IEmployeesRepository>();
                model.Active = true;
                var emp = _mapper.Map<Employees>(model);
                emp.Role = null;
                empRepo.CreateEmp(emp);
                _uow.Save();

                return new ResponseViewModel { Message = "Create sucessfull", Success = true };
            }
            catch (Exception e)
            {
                return new ResponseViewModel { Message = e.Message, Success = false };
            }
        }

        public ResponseViewModel DeleteEmployees(int id)
        {
            try
            {
                var empRepo = _uow.GetService<IEmployeesRepository>();
                var emp = empRepo.GetEmployee(id);
                
                empRepo.DeactiveEmp(emp);
                _uow.Save();

                return new ResponseViewModel { Message = "Delete sucessfull", Success = true };
            }
            catch (Exception e)
            {
                return new ResponseViewModel { Message = e.Message, Success = false };
            }
        }

        public ResponseViewModel GetEmployees()
        {
            try
            {
                var empRepo = _uow.GetService<IEmployeesRepository>();
                var result = _mapper.Map<List<EmployeesViewModel>>(empRepo.GetEmployees().ToList());

                return new ResponseViewModel { Data = result, Success = true };
            }
            catch (Exception e)
            {
                return new ResponseViewModel { Message = e.Message, Success = false };
            }
        }

        public ResponseViewModel UpdateEmployees(EmployeesViewModel model)
        {
            try
            {
                var empRepo = _uow.GetService<IEmployeesRepository>();
                var emp = _mapper.Map<Employees>(model);
                empRepo.UpdateEmp(emp);
                _uow.Save();

                return new ResponseViewModel { Message = "Update sucessfull", Success = true };
            }
            catch (Exception e)
            {
                return new ResponseViewModel { Message = e.Message, Success = false };
            }
        }
    }
}
