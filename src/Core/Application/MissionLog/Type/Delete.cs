// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using com.github.olo42.ROM.Core.Domain;
using System;
using System.Threading.Tasks;

namespace com.github.olo42.ROM.Core.Application.MissionLog.Type
{
  public class Delete : IDelete<Identifier>
  {
    private readonly IRepository<LogType> _repository;

    public Delete(IRepository<LogType> repository)
    {
      _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public async Task Execute(Identifier identifier)
    {
      await _repository.Delete(identifier.Id);
    }
  }
}
