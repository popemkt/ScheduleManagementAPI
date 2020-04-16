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
    public interface IArrangedScheduleDomain
    {
        ResponseViewModel ArrangeSchedule(DateTime start, DateTime end);

        ResponseViewModel GetArrangeSchedule(DateTime start, DateTime end);

        ResponseViewModel GetArrangedDash(DateTime start, DateTime end);

        ResponseViewModel GetArrangedBySlot(DateTime date, int slot);
    }
    public class ArrangedScheduleDomain : BaseDomain, IArrangedScheduleDomain
    {
        private readonly IMapper _mapper;
        public ArrangedScheduleDomain(IMapper mapper, IUnitOfWork uow): base(uow)
        {
            _mapper = mapper;
        }

        public ResponseViewModel ArrangeSchedule(DateTime start, DateTime end)
        {
            try
            {
                var empSRRepo = _uow.GetService<IEmpScheduleRegistrationRepository>();
                var arrSRepo = _uow.GetService<IArrangedScheduleRepository>();
                var arrSDRepo = _uow.GetService<IArrangedScheduleDetailsRepository>();
                var notiDomain = _uow.GetService<INotiDomain>();

                var regList = empSRRepo.GetScheduleForWeekByDate(start,end);

                if(regList == null)
                {
                    return new ResponseViewModel { Success = false, Message = "Cannot arrange this week" };
                }

               

               using(var trans = _uow.BeginTransation())
                {
                    var regDList = new List<EmpScheduleRegistrationDetails>();

                    foreach (var item in regList)
                    {
                        regDList.AddRange(item.EmpScheduleRegistrationDetails.Where(q => q.Active == true));
                    }

                    var arranged = new ArrangedSchedule
                    {
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        FromDate = start,
                        ToDate = end
                    };
                    arrSRepo.CreateArrangedSchedule(arranged);
                    _uow.Save();

                    foreach(var item in regDList)
                    {
                        var arrangedDetail = _mapper.Map<ArrangedScheduleDetails>(item);

                        arrangedDetail.Id = 0;
                        arrangedDetail.ArrangedScheduleId = arranged.Id;
                        arrangedDetail.SpecialtyId = new Random().Next(1,4);
                        arrangedDetail.EmpId = item.EmpScheduleRegistration.EmpId;
                        arrangedDetail.ArrangedSchedule = null;

                        arrSDRepo.Add(arrangedDetail);
                    }
                    _uow.Save();

                    trans.Commit();
                }

                var mess = new Dictionary<string, string>();

                mess.Add("title", "Arrange Schedule");
                mess.Add("message", "New schedule has been arranged");

                notiDomain.Noti(new FirebaseAdmin.Messaging.Message
                {
                    Topic = "test",
                    Data = mess
                });

                return new ResponseViewModel { Success = true, Message = "Arrange successfull"};
            }
            catch(Exception e)
            {
                return new ResponseViewModel { Success = false , Message = e.Message};
            }
        }

        public ResponseViewModel GetArrangeSchedule(DateTime start, DateTime end)
        {
            try
            {
                var arrSRepo = _uow.GetService<IArrangedScheduleRepository>();
                var arrSDRepo = _uow.GetService<IArrangedScheduleDetailsRepository>();

                var arranged = arrSRepo.GetArrangedSchedule(start, end);

                if (arranged == null)
                {
                    return new ResponseViewModel { Success = false, Message = "This week has not arranged yet" };
                }

                var result = _mapper.Map<ArrangedScheduleViewModel>(arranged);
                var arrDlist = arranged.ArrangedScheduleDetails.ToList();
                result.Details = _mapper.Map<List<ArrangedScheduleDetailsViewModel>>(arrDlist);

                for(var i = 0; i < arrDlist.Count; i++)
                {
                    result.Details[i].EmpName = arrDlist[i].Emp.Fullname;
                    result.Details[i].SpecialtyName = arrDlist[i].Specialty.Name;
                }

                return new ResponseViewModel { Success = true, Data = result };
            }
            catch (Exception e)
            {
                return new ResponseViewModel { Success = false, Message = e.Message };
            }
        }

        public ResponseViewModel GetArrangedDash(DateTime start, DateTime end) 
        {
            try
            {
                var arrSRepo = _uow.GetService<IArrangedScheduleRepository>();
                var arrSDRepo = _uow.GetService<IArrangedScheduleDetailsRepository>();

                var arranged = arrSRepo.GetArrangedSchedule(start, end);

                if (arranged == null)
                {
                    return new ResponseViewModel { Success = false, Message = "This week has not arranged yet" };
                }

                var result = _mapper.Map<ArrangedScheduleViewModel>(arranged);
                var arrDlist = _mapper.Map<List<ArrangedScheduleDetailsViewModel>>(arranged.ArrangedScheduleDetails.OrderBy(q=> q.HourSlot).OrderBy(q => q.Date))
                    .GroupBy(q => new { q.Date, q.HourSlot })
                    .Select(q => q.ToList().GroupBy(q => q.SpecialtyId)
                    .Select(q=> q.ToList())).ToList();
                return new ResponseViewModel { Success = true, Data = arrDlist };
            }
            catch (Exception e)
            {
                return new ResponseViewModel { Success = false, Message = e.Message };
            }
        }

        public ResponseViewModel GetArrangedBySlot(DateTime date, int slot)
        {
            try
            {
                var arrSDRepo = _uow.GetService<IArrangedScheduleDetailsRepository>();
                var arrSlot = arrSDRepo.GetArrangedSDBySlot(date, slot).ToList();

                var result = _mapper.Map<List<ArrangedScheduleDetailsViewModel>>(arrSlot);

                for(var i =0; i< arrSlot.Count; i++)
                {
                    result[i].EmpName = arrSlot[i].Emp.Fullname;
                }

                return new ResponseViewModel { Success = true, Data = result };
            }
            catch(Exception e)
            {
                return new ResponseViewModel { Success = false, Message = e.Message };
            }
        }
    }
}
