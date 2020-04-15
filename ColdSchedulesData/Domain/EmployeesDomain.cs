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

        ResponseViewModel GetEmployee(int id);
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

        public ResponseViewModel GetEmployee(int id)
        {
            try
            {
                var empRepo = _uow.GetService<IEmployeesRepository>();

                var emp = empRepo.GetEmployee(id);
                var result = _mapper.Map<EmployeesViewModel>(emp);

                var empSpec = emp.EmpSpecialty;

                result.Specialty = new List<SpecialtyViewModel>();

                foreach(var item in empSpec)
                {
                    result.Specialty.Add(_mapper.Map<SpecialtyViewModel>(item.Specialty));
                }

                return new ResponseViewModel { Data = result, Success = true };
            }
            catch(Exception e)
            {
                return new ResponseViewModel { Message = e.Message, Success = false };
            }
        }

        public ResponseViewModel GetEmployees()
        {
            try
            {
                var empRepo = _uow.GetService<IEmployeesRepository>();
                var list = empRepo.GetEmployees().ToList();
                var result = _mapper.Map<List<EmployeesViewModel>>(list);

                for(var i = 0; i< list.Count; i++)
                {
                    result[i].Specialty = new List<SpecialtyViewModel>();

                    foreach(var item in list[i].EmpSpecialty)
                    {
                        result[i].Specialty.Add(_mapper.Map<SpecialtyViewModel>(item.Specialty));
                    }

                }

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
                var specRepo = _uow.GetService<IEmpSpecialtyRepository>();
                var emp = _mapper.Map<Employees>(model);

                foreach(var item in model.Specialty)
                {
                    if(specRepo.GetEMpSpecialty(model.EmpId, item.Id) == null)
                    {
                        specRepo.CreateeEmpSpecialty(new EmpSpecialty { EmpId = model.EmpId, SpecialtyId = item.Id });
                    }
                }

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
