﻿// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace com.github.olo42.ROM.Core.Application
{
  public interface IUpdate<TInput>
  {
    Task Execute(TInput input);
  }
}