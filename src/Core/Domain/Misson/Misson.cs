// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;

namespace com.github.olo42.SAROnion.Core.Domain
{
  public class Misson : BaseEntity
  {
    public IEnumerable<Log> Logs { get; set; }
    public Person Leader { get; set; }   
    public string Objective { get; set; }
    public IEnumerable<Unit> Units { get; set; }
    public IEnumerable<Casualty> Casualties { get; set; }
    public IEnumerable<Contact> Contacts { get; set; }
    public IEnumerable<Document> Documents { get; set; }
    public EMissionState State { get; set; }
  }
}
