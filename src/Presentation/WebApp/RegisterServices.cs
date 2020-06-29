// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using com.github.olo42.ROM.Core.Application;
using com.github.olo42.ROM.Core.Application.MissionLog.Type;
using com.github.olo42.ROM.Core.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace com.github.olo42.ROM.Presentation.WebApp
{
  public static class ServiceExtensions
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
      return services.AddScoped<ICreate<CreateIn, LogType>, Core.Application.MissionLog.Type.Create>();
    }
  }
}


