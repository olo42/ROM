// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;

namespace com.github.olo42.ROM.Core.Domain
{
  public class Mission : BaseEntity
  {
    public IEnumerable<LogEntry> Log { get; set; }
    public string Objective { get; set; }
    public IEnumerable<Unit> Units { get; set; }
    public IEnumerable<Casualty> Casualties { get; set; }
    public IEnumerable<Functionary> Functionaries { get; set; }
    public IEnumerable<Contact> Contacts { get; set; }
    public IEnumerable<Document> Documents { get; set; }
    public EMissionState State { get; set; }
    public DateTime CreationDateTime{ get; set; }
  }
}
