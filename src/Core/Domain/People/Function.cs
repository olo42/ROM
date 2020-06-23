// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace com.github.olo42.SAROnion.Core.Domain
{
  public class Function : BaseEntity
  {
    public string Name { get; set; }
    public string Description { get; set; }
  }
}