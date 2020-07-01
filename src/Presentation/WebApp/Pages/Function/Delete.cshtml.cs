// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using AutoMapper;
using com.github.olo42.ROM.Core.Application;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.Function
{
  public class DeleteModel : BaseDeleteModel<Core.Domain.Function, ViewModel>
  {
    public DeleteModel(
      IRead<Core.Domain.Function> readAction, 
      IDelete<Core.Domain.Function> deleteAction, 
      IMapper mapper) : base(readAction, deleteAction, mapper) { }
  }
}
