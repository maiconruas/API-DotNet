﻿using ApiDotNet.Application.Mappings;
using ApiDotNet.Application.Services;
using ApiDotNet.Application.Services.Interfaces;
using ApiDotNet.Domain.Repositories;
using ApiDotNet.Infra.Data.Context;
using ApiDotNet.Infra.Data.repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiDotNet.Infra.IoC
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
								  options.UseNpgsql(configuration.GetConnectionString("")));

			services.AddScoped<IPersonRepository, PersonRepository>();
			return services;
		}

		public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddAutoMapper(typeof(DomainToDtoMapping));
			services.AddScoped<IPersonService, PersonService>();
			return services;
		}
	}
}
