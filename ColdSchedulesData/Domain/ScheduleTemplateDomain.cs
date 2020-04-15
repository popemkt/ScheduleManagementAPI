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
    public interface IScheduleTemplateDomain
    {
        ResponseViewModel GetTemplateForWeek(DateTime start, DateTime end);

        ResponseViewModel CreateTemplateForWeek(EmpScheduleRegistrationViewModel model);

        ResponseViewModel UpdateTempalteForWeek(EmpScheduleRegistrationViewModel model);
    }
    public class ScheduleTemplateDomain : BaseDomain, IScheduleTemplateDomain
    {
        private readonly IMapper _mapper;
        public ScheduleTemplateDomain(IMapper mapper, IUnitOfWork uow) : base(uow)
        {
            this._mapper = mapper;
        }

        public ResponseViewModel CreateTemplateForWeek(EmpScheduleRegistrationViewModel model)
        {
            try
            {
                var templateRepo = _uow.GetService<IScheduleTemplateRepository>();
                var templateDRepo = _uow.GetService<IScheduleTemplateDetailsRepository>();

                var template = _mapper.Map<ScheduleTemplate>(model);
                template.DateCreated = DateTime.Now;
                templateRepo.CreateTemplate(template);
                _uow.Save();

                var details = _mapper.Map<List<ScheduleTemplateDetails>>(model.Details);
                foreach (var item in details)
                {
                    item.ScheduleTemplateId = template.Id;
                }

                templateDRepo.CreateTemplateDetails(details);
                _uow.Save();

                return new ResponseViewModel { Message = "Create successfull", Success = true };
            }
            catch (Exception e)
            {
                return new ResponseViewModel { Success = false, Message = e.Message };
            }
        }

        public ResponseViewModel GetTemplateForWeek(DateTime start, DateTime end)
        {
            try
            {
                var templateRepo = _uow.GetService<IScheduleTemplateRepository>();
                var templateDRepo = _uow.GetService<IScheduleTemplateDetailsRepository>();

                var template = templateRepo.GetTemplate(start, end);

                if (template == null)
                {
                    return new ResponseViewModel { Message = "There is no template for this week", Success = false };
                }

                var result = _mapper.Map<ScheduleTemplateViewModel>(template);
                var details = template.ScheduleTemplateDetails.ToList();
                result.Details = _mapper.Map<List<ScheduleTemplateDetailsViewModel>>(details);


                for (var i = 0; i < details.Count; i++)
                {
                    result.Details[i].SpecialtyName = details[i].Specialty.Name;
                }

                return new ResponseViewModel { Data = result, Success = true };
            }
            catch (Exception e)
            {
                return new ResponseViewModel { Message = e.Message, Success = false };
            }
        }

        public ResponseViewModel UpdateTempalteForWeek(EmpScheduleRegistrationViewModel model)
        {
            try
            {
                var templateRepo = _uow.GetService<IScheduleTemplateRepository>();
                var templateDRepo = _uow.GetService<IScheduleTemplateDetailsRepository>();

                var template = _mapper.Map<ScheduleTemplate>(model);
                template.DateUpdated = DateTime.Now;
                templateRepo.UpdateTemplate(template);

                var oldDetails = templateDRepo.GetTemplateDetais(model.Id).ToList();
                var newDetails = _mapper.Map<List<ScheduleTemplateDetails>>(model.Details);
                foreach (var item in newDetails)
                {
                    if (item.Id != 0)
                    {
                        foreach (var detail in oldDetails)
                        {
                            if (item.Id == detail.Id)
                            {
                                templateDRepo.ActiveTemplateDetail(detail);
                                oldDetails.Remove(detail);
                                break;
                            }
                            else
                            {
                                templateDRepo.DeactiveTemplateeDetail(detail);
                            }
                        }
                    }
                    else
                    {
                        item.ScheduleTemplateId = model.Id;
                        item.ScheduleTemplate = null;
                        templateDRepo.CreateTemplateDetail(item);
                    }
                }

                foreach (var item in oldDetails)
                {
                    templateDRepo.DeactiveTemplateeDetail(item);
                }


                _uow.Save();

                return new ResponseViewModel { Message = "Update successfull", Success = true };
            }
            catch (Exception e)
            {
                return new ResponseViewModel { Message = e.Message, Success = false };
            }
        }
    }
}
