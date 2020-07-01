// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using com.github.olo42.ROM.Core.Domain;
using System.Threading.Tasks;

namespace com.github.olo42.ROM.Core.Application
{
  public interface IDelete<T> where T : IIdentifiable, IDeletable
  {
    Task Execute(T input);
  }
}
