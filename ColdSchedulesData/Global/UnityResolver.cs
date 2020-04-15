using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ColdSchedulesData.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace ColdSchedulesData.Global
{
    public interface IUnitOfWork
    {
        T GetService<T>();

		void Save();

		IDbContextTransaction BeginTransation();

	}

    public partial class UnitOfWork : IUnitOfWork
    {

		public UnitOfWork(IServiceProvider service, ScheduleManagementContext context)
		{
			this.service = service;
			this.context = context;
		}

		protected readonly IServiceProvider service;
		protected readonly ScheduleManagementContext context;

		public T GetService<T>()
		{
			return service.GetService<T>();
		}

		public void Save()
		{
			context.SaveChanges();
		}

		public IDbContextTransaction BeginTransation()
		{
			return context.Database.BeginTransaction();
		}

	}
}
