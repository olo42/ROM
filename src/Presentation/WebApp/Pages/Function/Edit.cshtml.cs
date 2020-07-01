// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using AutoMapper;
using com.github.olo42.ROM.Core.Application;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.Function
{
  public class EditModel : BaseEditModel<Core.Domain.Function, ViewModel>
  {
    public EditModel(
      IRead<Core.Domain.Function> readAction, 
      IUpdate<Core.Domain.Function> updateAction, 
      IMapper mapper) : base(readAction, updateAction, mapper)
    {
    }
  }
}
