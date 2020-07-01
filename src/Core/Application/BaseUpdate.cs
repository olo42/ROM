// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;
using com.github.olo42.ROM.Core.Domain;

namespace com.github.olo42.ROM.Core.Application
{
  public class BaseUpdate<T> : IUpdate<T> where T : IIdentifiable
  {
    private readonly IRepository<T> repository;

    public BaseUpdate(IRepository<T> repository)
    {
      this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task Execute(T input)
    {
      input = input ?? throw new ArgumentNullException(nameof(input));

      await repository.WriteAsync(input);
    }
  }
}