// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using com.github.olo42.ROM.Core.Domain;
using Microsoft.Extensions.Configuration;

namespace com.github.olo42.ROM.Infrastructure.FileStorage
{
  public class LogTypeRepository : BaseRepository<LogType>
  {
    public LogTypeRepository(IConfiguration configuration) : base(configuration) { }
  }
}
