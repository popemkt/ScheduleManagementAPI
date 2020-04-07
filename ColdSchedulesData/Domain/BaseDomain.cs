using AutoMapper;
using ColdSchedulesData.Global;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColdSchedulesData.Domain
{
    public partial class BaseDomain
    {
        protected IUnitOfWork _uow;

        public BaseDomain(IUnitOfWork uow)
        {
            _uow = uow;
        }

    }
}
