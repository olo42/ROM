// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using com.github.olo42.ROM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.github.olo42.ROM.Core.Application.Missions
{
  public class Create : BaseCreate<Mission>
  {
    public Create(IRepository<Mission> repository) : base(repository)
    {
    }

    public override Task<Mission> Execute(Mission input)
    {
      Initialize(input);

      return base.Execute(input);
    }

    private static void Initialize(Mission mission)
    {
      mission.Casualties = new List<Casualty>();
      mission.Contacts = new List<Contact>();
      mission.Documents = new List<Document>();
      mission.Functionaries = new List<Functionary>();
      mission.Log = new List<LogEntry>();
      mission.Units = new List<Unit>();
      mission.State = EMissionState.Runnig;
    }
  }
}
