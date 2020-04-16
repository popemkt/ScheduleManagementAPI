using AutoMapper;
using ColdSchedulesData.Domain;
using ColdSchedulesData.Models;
using ColdSchedulesData.Models.Repositories;
using ColdSchedulesData.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColdSchedulesData.Global
{
	public static partial class Global
	{
		public static IMapper Mapper { get; private set; }
		private static List<Action<IMapperConfigurationExpression>> MapperConfigs
			= new List<Action<IMapperConfigurationExpression>>();

		private static void ConfigureAutomapper()
		{
			//AutoMapper
			var mapConfig = new MapperConfiguration(cfg =>
			{
				foreach (var c in MapperConfigs)
				{
					c.Invoke(cfg);
				}
			});
			Global.Mapper = mapConfig.CreateMapper();

		}

		private static void ConfigureIoC(IServiceCollection services)
		{
			//IoC
			services.AddScoped<UnitOfWork>()
				.AddScoped<IUnitOfWork, UnitOfWork>()
				.AddScoped<DbContext, ScheduleManagementContext>()
				.AddScoped<IEmployeesRepository,EmployeesRepository>()
				.AddScoped<IEmpScheduleRegistrationRepository, EmpScheduleRegistrationRepository>()
				.AddScoped<IScheduleTemplateRepository, ScheduleTemplateRepository>()
				.AddScoped<IScheduleTemplateDetailsRepository, ScheduleTemplateDetailsRepository>()
				.AddScoped<IArrangedScheduleRepository, ArrangedScheduleRepository>()
				.AddScoped<IArrangedScheduleDetailsRepository, ArrangedScheduleDetailsRepository>()
				.AddScoped<ISpecialtyRepository, SpecialtyRepository>()
				.AddScoped<IEmpSpecialtyRepository, EmpSpecialtyRepository>()
				.AddScoped<IEmpScheduleRegistrationDetailsRepository, EmpScheduleRegistrationDetailsRepository>();
		}

		public static void Configure(IServiceCollection services)
		{
			MapperConfigs.Add(cfg =>
			{
				cfg.CreateMap<Employees, EmployeesViewModel>().ReverseMap();
				cfg.CreateMap<ArrangedScheduleDetails, EmpScheduleRegistrationViewModel>().ReverseMap();
				cfg.CreateMap<EmpScheduleRegistrationDetails, EmpScheduleRegistrationDetailsViewModel>().ReverseMap();
				cfg.CreateMap<ArrangedSchedule, ArrangedScheduleViewModel>().ReverseMap();
				cfg.CreateMap<ArrangedScheduleDetails, ArrangedScheduleDetailsViewModel>().ReverseMap();
				cfg.CreateMap<ScheduleTemplate, ScheduleTemplateViewModel>().ReverseMap();
				cfg.CreateMap<ScheduleTemplateDetails, ScheduleTemplateDetailsViewModel>().ReverseMap();
				cfg.CreateMap<EmpSpecialty, EmpSpecialtyViewModel>().ReverseMap();
				cfg.CreateMap<ScheduleTemplateDetails, ScheduleTemplateDetailsViewModel>().ReverseMap();
				cfg.CreateMap<ScheduleTemplate, ScheduleTemplateViewModel>().ReverseMap();
				cfg.CreateMap<Specialty, SpecialtyViewModel>().ReverseMap();
				cfg.CreateMap<ArrangedScheduleDetails, EmpScheduleRegistrationDetails>().ReverseMap();
			});
			ConfigureAutomapper();
			services.AddSingleton(Mapper);
			services.AddDbContext<ScheduleManagementContext>();
			ConfigureIoC(services);
			//extra
			services.AddScoped<IEmployeesDomain, EmployeesDomain>()
				.AddScoped<IAuthorizationDomain, AuthorizationDomain>()
				.AddScoped<INotiDomain, NotiDomain>()
				.AddScoped<ISpecialtyDomain, SpecialtyDomain>()
				.AddScoped<IArrangedScheduleDomain, ArrangedScheduleDomain>()
				.AddScoped<IScheduleTemplateDomain, ScheduleTemplateDomain>()
				.AddScoped<IEmpScheduleRegistrationDomain, EmpScheduleRegistrationDomain>();

		}
	}
}
