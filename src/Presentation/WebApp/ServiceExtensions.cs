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
      services.AddScoped<ICreate<LogType>, Core.Application.MissionLog.Type.Create>();
      services.AddScoped<IRead<Identifier, LogType>, Core.Application.MissionLog.Type.Read>();
      services.AddScoped<IReadAll<IEnumerable<LogType>>, Core.Application.MissionLog.Type.ReadAll>();
      services.AddScoped<IUpdate<LogType>, Core.Application.MissionLog.Type.Update>();
      services.AddScoped<IDelete<Identifier>, Core.Application.MissionLog.Type.Delete>();

      return services;
    }
  }
}