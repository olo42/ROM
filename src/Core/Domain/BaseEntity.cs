// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace com.github.olo42.ROM.Core.Domain
{
  public class BaseEntity : IIdentifiable, IDeletable
  {
    public string Id { get; set; }
    public bool Deleted { get; set; }
  }
}