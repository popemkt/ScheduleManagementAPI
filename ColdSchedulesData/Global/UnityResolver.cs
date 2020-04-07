using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace ColdSchedulesData.Global
{
    public interface IUnitOfWork
    {
        T GetService<T>();
    }

    public partial class UnitOfWork : IUnitOfWork
    {
		public UnitOfWork(IServiceProvider service)
		{
			this.service = service;
		}

		protected readonly IServiceProvider service;

		public T GetService<T>()
		{
			return service.GetService<T>();
		}
	}
}
