using AutoMapper;
using ColdSchedulesData.Global;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColdSchedulesData.Domain
{
    public interface ISpecialtyDomain
    {

    }
    public class SpecialtyDomain : BaseDomain, ISpecialtyDomain
    {
        private readonly IMapper _mapper;

        public SpecialtyDomain(IMapper mapper, IUnitOfWork uow):base(uow)
        {
            _mapper = mapper;
        }
    }
}
