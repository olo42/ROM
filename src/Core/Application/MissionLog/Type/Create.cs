// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;
using com.github.olo42.ROM.Core.Domain;

namespace com.github.olo42.ROM.Core.Application.MissionLog.Type
{
  public class Create : ICreate<LogType>
  {
    private readonly IRepository<LogType> repository;

    public Create(IRepository<LogType> repository)
    {
      this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task Execute(LogType input)
    {
      input = input ?? throw new ArgumentNullException(nameof(input));

      input.Id = Guid.NewGuid().ToString();

      await repository.WriteAsync(input);
    }
  }
}