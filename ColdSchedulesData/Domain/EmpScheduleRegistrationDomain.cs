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
    public interface IEmpScheduleRegistrationDomain
    {
        ResponseViewModel GetScheduleForWeek(int id, DateTime start, DateTime end);

        ResponseViewModel CreateScheduleForWeek(EmpScheduleRegistrationViewModel model);

        ResponseViewModel UpdateScheduleForWeek(EmpScheduleRegistrationViewModel model);

    }
    public class EmpScheduleRegistrationDomain : BaseDomain, IEmpScheduleRegistrationDomain
    {
        private readonly IMapper _mapper;

        public EmpScheduleRegistrationDomain(IMapper mapper, IUnitOfWork uow) : base(uow)
        {
            this._mapper = mapper;
        }

        public ResponseViewModel CreateScheduleForWeek(EmpScheduleRegistrationViewModel model)
        {
            try
            {
                var empSRRepo = _uow.GetService<IEmpScheduleRegistrationRepository>();
                var empSRDRepo = _uow.GetService<IEmpScheduleRegistrationDetailsRepository>();
                var empSR = _mapper.Map<EmpScheduleRegistration>(model);
                var empSRDs = _mapper.Map<List<EmpScheduleRegistrationDetails>>(model.Details);

                empSR.DateCreated = DateTime.Now;
                empSRRepo.CreateScheduleForWeek(empSR);
                _uow.Save();

                foreach (var item in empSRDs)
                {
                    item.Active = true;
                    item.EmpScheduleRegistrationId = empSR.Id;
                }

                empSRDRepo.CreateEmpSRDs(empSRDs);
                _uow.Save();

                return new ResponseViewModel { Success = true, Message = "Create Successfull" };
            }
            catch (Exception e)
            {
                return new ResponseViewModel { Success = false, Message = e.Message };
            }
        }
       
        public ResponseViewModel GetScheduleForWeek(int empID, DateTime start, DateTime end)
        {
            try
            {
                var empSRRepo = _uow.GetService<IEmpScheduleRegistrationRepository>();
                var empSRDRepo = _uow.GetService<IEmpScheduleRegistrationDetailsRepository>();

                var empSR = empSRRepo.GetScheduleForWeek(empID, start, end);
                var result = _mapper.Map<EmpScheduleRegistrationViewModel>(empSR);
                result.Details = _mapper.Map<List<EmpScheduleRegistrationDetailsViewModel>>(empSR.EmpScheduleRegistrationDetails.ToList());

                result.EmpName = empSR.Emp.Fullname;
                result.EmpUsername = empSR.Emp.Username;

                return new ResponseViewModel { Data = result, Success = true };
            }
            catch (Exception e)
            {
                return new ResponseViewModel { Success = false, Message = e.Message };
            }
        }

        public ResponseViewModel UpdateScheduleForWeek(EmpScheduleRegistrationViewModel model)
        {
            try
            {
                var empSRRepo = _uow.GetService<IEmpScheduleRegistrationRepository>();
                var empSRDRepo = _uow.GetService<IEmpScheduleRegistrationDetailsRepository>();

                var empSR = _mapper.Map<EmpScheduleRegistration>(model);
                var oldDetails = empSRRepo.GetScheduleForWeek(model.EmpId, model.FromDate, model.ToDate).EmpScheduleRegistrationDetails;
                var newDetails = _mapper.Map<List<EmpScheduleRegistrationDetails>>(model.Details);

                empSR.DateUpdated = DateTime.Now;

                foreach (var item in oldDetails)
                {
                    if (!newDetails.Contains(item))
                    {
                        empSRDRepo.DeactiveEmpSRD(item);
                    }
                    else
                    {
                        empSRDRepo.Activate(item);
                    }
                }

                foreach (var item in newDetails)
                {
                    if (empSRDRepo.FirstOrDefaultActive(q => q.Id == item.Id) == null)
                    {
                        empSRDRepo.CreateEmpSRD(item);
                    }
                }

                _uow.Save();

                return new ResponseViewModel { Success = true, Message = "Update Successfull" };
            }
            catch (Exception e)
            {
                return new ResponseViewModel { Success = false, Message = e.Message };
            }
        }
    }


}
