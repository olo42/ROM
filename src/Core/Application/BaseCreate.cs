// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;
using com.github.olo42.ROM.Core.Domain;

namespace com.github.olo42.ROM.Core.Application
{
  public class BaseCreate<T> : ICreate<T> where T : IIdentifiable
  {
    protected readonly IRepository<T> repository;

    public BaseCreate(IRepository<T> repository)
    {
      this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public virtual async Task<T> Execute(T input)
    {
      input = input ?? throw new ArgumentNullException(nameof(input));
      input.Id = Guid.NewGuid().ToString();

      await repository.WriteAsync(input);
      
      return input;
    }
  }
}