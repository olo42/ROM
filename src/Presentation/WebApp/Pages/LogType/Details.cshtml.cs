// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using com.github.olo42.ROM.Core.Application;
using AutoMapper;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.LogType
{
  public class DetailsModel : BaseDetailsModel<Core.Domain.LogType, Core.Domain.LogType>
  {
    public DetailsModel(IRead<Core.Domain.LogType> readAction, IMapper mapper) : base(readAction, mapper)
    {
    }
  }
}
