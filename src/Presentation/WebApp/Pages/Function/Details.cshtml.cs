// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using AutoMapper;
using com.github.olo42.ROM.Core.Application;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.Function
{
  public class DetailsModel : BaseDetailsModel<Core.Domain.Function, Core.Domain.Function>
  {
    public DetailsModel(
      IRead<Core.Domain.Function> readAction, 
      IMapper mapper) : base(readAction, mapper)
    {
    }
  }
}
