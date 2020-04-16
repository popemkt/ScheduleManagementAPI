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
    public interface ISpecialtyDomain
    {
        ResponseViewModel GetSpecialties();

        ResponseViewModel CreateSpecialty(SpecialtyViewModel model);

        ResponseViewModel UpdateSpecialty(SpecialtyViewModel model);
    }
    public class SpecialtyDomain : BaseDomain, ISpecialtyDomain
    {
        private readonly IMapper _mapper;

        public SpecialtyDomain(IMapper mapper, IUnitOfWork uow):base(uow)
        {
            _mapper = mapper;
        }

        public ResponseViewModel CreateSpecialty(SpecialtyViewModel model)
        {
            try
            {
                var specRepo = _uow.GetService<ISpecialtyRepository>();
                var spec = _mapper.Map<Specialty>(model);

                specRepo.CreateSpecialty(spec);
                _uow.Save();

                return new ResponseViewModel { Message = "Create successfull", Success = true };
            }
            catch(Exception e)
            {
                return new ResponseViewModel { Message = e.Message, Success = false };
            }
        }

        public ResponseViewModel GetSpecialties()
        {
            try
            {
                var specRepo = _uow.GetService<ISpecialtyRepository>();
                var result = specRepo.GetSpecialties();

                return new ResponseViewModel { Data = result, Success = true };
            }
            catch (Exception e)
            {
                return new ResponseViewModel { Message = e.Message, Success = false };
            }
        }

        public ResponseViewModel UpdateSpecialty(SpecialtyViewModel model)
        {
            try
            {
                var specRepo = _uow.GetService<ISpecialtyRepository>();
                var spec = _mapper.Map<Specialty>(model);

                specRepo.UpdateSpecialty(spec);
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
