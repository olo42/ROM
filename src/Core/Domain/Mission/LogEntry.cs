// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace com.github.olo42.SAROnion.Core.Domain
{
  public class LogEntry : BaseEntity
  {
    public LogType Type { get; set; }
    public DateTime CreationDateTime { get; set; }
    public string Message { get; set; }
  }
}