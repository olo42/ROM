// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using com.github.olo42.ROM.Core.Domain;

namespace com.github.olo42.ROM.Core.Application
{
  public class Identifier : IIdentifiable
  {
    public Identifier(string id)
    {
      Id = GetValidId(id);
    }

    public string Id 
    {
      get { return Id;  }
      set { Id = GetValidId(value); } 
    }

    private static string GetValidId(string id)
    {
      if (string.IsNullOrWhiteSpace(id))
        throw new System.ArgumentException("message", nameof(id));

      return id;
    }
  }
}
