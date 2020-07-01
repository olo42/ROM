// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using com.github.olo42.ROM.Core.Domain;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.github.olo42.ROM.Core.Application
{
  public interface IRead<T>
  {
    Task<T> Execute(IIdentifiable input);
    
    Task<IEnumerable<T>> Execute();
  }
}