// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;
using com.github.olo42.SAROnion.Core.Domain;

namespace com.github.olo42.SAROnion.Core.Application.Log.Type
{
  public class Create : ICreate<CreateIn, LogType>
  {
    private readonly IRepository<LogType> repository;

    public Create(IRepository<LogType> repository)
    {
      this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public Task<LogType> Execute(CreateIn input)
    {
      var name = input?.Name ?? throw new ArgumentNullException(nameof(input.Name));

      var logType = new LogType();
      logType.Id = Guid.NewGuid().ToString();
      logType.Name = input.Name;

      repository.Write(logType);

      return Task.FromResult(logType);
    }
  }
}