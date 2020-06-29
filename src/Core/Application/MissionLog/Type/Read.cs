// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using com.github.olo42.ROM.Core.Domain;

namespace com.github.olo42.ROM.Core.Application.MissionLog.Type
{
  public class Read : IRead<Identifier, LogType>
  { 
    private IRepository<LogType> repository;

    public Read(IRepository<LogType> repository)
    {
      this.repository = repository;
    }

    public Task<LogType> Execute(Identifier identifier)
    {
      return repository.ReadAsync(identifier.Id);
    }
  }
}