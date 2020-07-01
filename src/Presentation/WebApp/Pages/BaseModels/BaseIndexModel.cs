// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using com.github.olo42.ROM.Core.Application;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages
{
  public class BaseIndexModel<TModel, TViewModel> : PageModel
  {
    protected readonly IRead<TModel> _readAction;
    protected readonly IMapper _mapper;

    public BaseIndexModel(IRead<TModel> readAction, IMapper mapper)
    {
      _readAction = readAction;
      _mapper = mapper;
    }

    public IList<TViewModel> ViewModel { get; set; }

    public virtual async Task OnGetAsync()
    {
      var result = await _readAction.Execute();

      ViewModel = _mapper.Map<IList<TViewModel>>(result);
    }
  }
}
