// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace com.github.olo42.ROM.Core.Domain
{
  public class Contact : Person
  {
    public string Phone { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
  }
}