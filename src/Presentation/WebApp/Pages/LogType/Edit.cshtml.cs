// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using com.github.olo42.ROM.Core.Application;
using AutoMapper;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.LogType
{
  public class EditModel : BaseEditModel<Core.Domain.LogType, Core.Domain.LogType>
  {
    public EditModel(
      IRead<Core.Domain.LogType> readAction, 
      IUpdate<Core.Domain.LogType> updateAction, 
      IMapper mapper) : base(readAction, updateAction, mapper)
    {
    }
  }
}
