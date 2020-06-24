// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Threading.Tasks;
using com.github.olo42.SAROnion.Core.Domain;

namespace com.github.olo42.SAROnion.Core.Application.MissionLog.Type
{
  public class Read : IRead<ReadIn, ReadOut>
  { 
    private IRepository<LogType> repository;

    public Read(IRepository<LogType> repository)
    {
      this.repository = repository;
    }

    public ReadOut Execute(ReadIn input)
    {
      return new ReadOut { Data = repository.Read(input.Id) };
    }
  }
}