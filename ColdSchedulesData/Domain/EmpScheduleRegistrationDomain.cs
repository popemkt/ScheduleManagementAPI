using AutoMapper;
using ColdSchedulesData.Global;
using ColdSchedulesData.Models;
using ColdSchedulesData.Models.Repositories;
using ColdSchedulesData.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColdSchedulesData.Domain
{
    public interface IEmpScheduleRegistrationDomain
    {
        ResponseViewModel GetScheduleForWeek(int id);

        ResponseViewModel CreateScheduleForWeek(List<EmpScheduleRegistrationViewModel> modelList);

        ResponseViewModel UpdateScheduleForWeek(List<EmpScheduleRegistrationViewModel> modelList);

        ResponseViewModel DeleteScheduleForWeek(List<EmpScheduleRegistrationViewModel> modelList);
    }
    public class EmpScheduleRegistrationDomain : BaseDomain, IEmpScheduleRegistrationDomain
    {
        private readonly IMapper _mapper;

        public EmpScheduleRegistrationDomain(IMapper mapper, IUnitOfWork uow) : base(uow)
        {
            this._mapper = mapper;
        }

        public ResponseViewModel CreateScheduleForWeek(List<EmpScheduleRegistrationViewModel> modelList)
        {
            try
            {
                var empSRRepo = _uow.GetService<IEmpScheduleRegistrationRepository>();
                var list = _mapper.Map<List<EmpScheduleRegistration>>(modelList);

                empSRRepo.CreateScheduleForWeek(list);
                empSRRepo.Save();

                return new ResponseViewModel {Success = true, Message="Create Successfull" };
            }
            catch (Exception e)
            {
                return new ResponseViewModel {Success = false, Message="Create Failed" };
            }
        }

        public ResponseViewModel DeleteScheduleForWeek(List<EmpScheduleRegistrationViewModel> modelList)
        {
            try
            {
                var empSRRepo = _uow.GetService<IEmpScheduleRegistrationRepository>();
                var list = _mapper.Map<List<EmpScheduleRegistration>>(modelList);

                empSRRepo.DeactiveScheduleForWeek(list);
                empSRRepo.Save();

                return new ResponseViewModel { Success = true, Message = "Delete Successfull" };
            }
            catch (Exception e)
            {
                return new ResponseViewModel { Success = false, Message = "Delete Failed" };
            }
        }

        public ResponseViewModel GetScheduleForWeek(int id)
        {
            try
            {
                var empSRRepo = _uow.GetService<IEmpScheduleRegistrationRepository>();
                var result = empSRRepo.GetScheduleForWeek(id);

                return new ResponseViewModel { Data = result, Success = true };
            }
            catch (Exception e)
            {
                return new ResponseViewModel {Success = false, Message="Cannot get" };
            }
        }

        public ResponseViewModel UpdateScheduleForWeek(List<EmpScheduleRegistrationViewModel> modelList)
        {
            try
            {
                var empSRRepo = _uow.GetService<IEmpScheduleRegistrationRepository>();
                var list = _mapper.Map<List<EmpScheduleRegistration>>(modelList);

                empSRRepo.UpdateScheduleForWeek(list);
                empSRRepo.Save();

                return new ResponseViewModel { Success = true, Message = "Update Successfull" };
            }
            catch (Exception e)
            {
                return new ResponseViewModel { Success = false, Message = "Update Failed" };
            }
        }
    }


}
