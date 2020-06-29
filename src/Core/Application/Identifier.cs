// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace com.github.olo42.ROM.Core.Application
{
  public class Identifier
  {
    public Identifier(string id)
    {
      if (string.IsNullOrEmpty(id))
      {
        throw new System.ArgumentException("message", nameof(id));
      }

      Id = id;
    }
    public string Id { get; }
  }
}
