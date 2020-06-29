// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Threading.Tasks;
using com.github.olo42.ROM.Core.Application;
using com.github.olo42.ROM.Core.Domain;

namespace com.github.olo42.ROM.Core.Application.MissionLog.Type
{
  public class ReadAll : IReadAll<IEnumerable<LogType>>
  {
    private IRepository<LogType> repository;

    public ReadAll(IRepository<LogType> repository)
    {
      this.repository = repository;
    }

    public Task<IEnumerable<LogType>> Execute()
    {
      return this.repository.ReadAsync();
    }
  }
}