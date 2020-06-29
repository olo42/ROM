// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.github.olo42.ROM.Core.Application
{
  public interface IRepository<T>
  {
    Task WriteAsync(T input);
    Task<T> ReadAsync(string id);
    Task<IEnumerable<T>> ReadAsync();
  }
}