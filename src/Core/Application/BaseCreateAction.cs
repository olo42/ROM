// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;
using com.github.olo42.ROM.Core.Domain;

namespace com.github.olo42.ROM.Core.Application
{
  public class BaseCreateAction<T> : ICreate<T> where T : IIdentifiable
  {
    protected readonly IRepository<T> repository;

    public BaseCreateAction(IRepository<T> repository)
    {
      this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public virtual async Task Execute(T input)
    {
      input = input ?? throw new ArgumentNullException(nameof(input));

      await repository.WriteAsync(input);
    }
  }
}