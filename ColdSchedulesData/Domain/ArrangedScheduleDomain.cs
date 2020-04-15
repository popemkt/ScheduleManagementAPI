using AutoMapper;
using ColdSchedulesData.Global;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColdSchedulesData.Domain
{
    public interface IArrangedScheduleDomain
    {

    }
    public class ArrangedScheduleDomain : BaseDomain
    {
        private readonly IMapper _mapper;
        public ArrangedScheduleDomain(IMapper mapper, IUnitOfWork uow): base(uow)
        {
            _mapper = mapper;
        }
    }
}
