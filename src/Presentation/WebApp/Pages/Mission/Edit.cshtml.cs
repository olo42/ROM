// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using com.github.olo42.ROM.Core.Application;
using AutoMapper;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.Mission
{
  public class EditModel : BaseEditModel<Core.Domain.Mission, Core.Domain.Mission>
  {
    public EditModel(
      IRead<Core.Domain.Mission> readAction, 
      IUpdate<Core.Domain.Mission> updateAction, 
      IMapper mapper) : base(readAction, updateAction, mapper)
    {
    }
  }
}
