// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;
using com.github.olo42.SAROnion.Core.Domain;

namespace com.github.olo42.SAROnion.Core.Application
{
  public class CreateLogType
  {
    private readonly ILogTypeRepository repository;

    public CreateLogType(ILogTypeRepository repository)
    {
      this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public Task<LogType> Run(string name)
    {
      if (name is null) throw new ArgumentNullException(nameof(name));

      var logType = new LogType();
      logType.Id = Guid.NewGuid().ToString();
      logType.Name = name;

      repository.Write(logType);

      return Task.FromResult(logType);
    }
  }
}