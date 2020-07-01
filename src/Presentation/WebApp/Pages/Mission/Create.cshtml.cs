// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using com.github.olo42.ROM.Core.Application;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.Mission
{
  public class CreateModel : BaseCreateModel<Core.Domain.Mission, Core.Domain.Mission>
  {
    public CreateModel(ICreate<Core.Domain.Mission> createAction, IMapper mapper) 
      : base(createAction, mapper)
    {
    }
  }
}
