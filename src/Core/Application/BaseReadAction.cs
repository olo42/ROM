// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Threading.Tasks;
using com.github.olo42.ROM.Core.Domain;

namespace com.github.olo42.ROM.Core.Application
{
  public class BaseReadAction<T> : IRead<T> where T : IIdentifiable
  { 
    protected readonly IRepository<T> repository;

    public BaseReadAction(IRepository<T> repository)
    {
      this.repository = repository;
    }

    public virtual Task<T> Execute(IIdentifiable input)
    {
      return repository.ReadAsync(input.Id);
    }

    public virtual Task<IEnumerable<T>> Execute()
    {
      return repository.ReadAsync();
    }
  }
}