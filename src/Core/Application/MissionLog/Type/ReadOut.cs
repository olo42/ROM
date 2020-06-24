// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using com.github.olo42.SAROnion.Core.Domain;

namespace com.github.olo42.SAROnion.Core.Application.MissionLog.Type
{
  public class ReadOut
  {
    public Task<LogType> Data { get; set; }
  }
}