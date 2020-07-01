using com.github.olo42.ROM.Core.Application;
using AutoMapper;
using com.github.olo42.ROM.Core.Domain;
using com.github.olo42.ROM.Infrastructure.FileStorage;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace com.github.olo42.ROM.Presentation.WebApp
{
  public static class ServiceExtensions
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
      services.AddAutoMapper(typeof(Startup));
      
      // LogType
      services.AddScoped<IRepository<LogType>, LogTypeRepository>();
      services.AddScoped<ICreate<LogType>, BaseCreateAction<LogType>>();
      services.AddScoped<IRead<LogType>, BaseReadAction<LogType>>();
      services.AddScoped<IUpdate<LogType>, BaseUpdateAction<LogType>>();
      services.AddScoped<IDelete<LogType>, BaseDeleteAction<LogType>>();

      return services;
    }
  }
}