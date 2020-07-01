// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using AutoMapper;
using com.github.olo42.ROM.Core.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages
{
  public class BaseDetailsModel<TModel, TViewModel> : PageModel
  {
    protected readonly IRead<TModel> _readAction;
    protected readonly IMapper _mapper;

    public BaseDetailsModel(IRead<TModel> readAction, IMapper mapper)
    {
      _readAction = readAction;
      _mapper = mapper;
    }

    public TViewModel ViewModel { get; set; }

    public virtual async Task<IActionResult> OnGetAsync(string id)
    {
      if (id == null)
        return NotFound();

      var identifier = new Identifier(id);
      var result = await _readAction.Execute(identifier);
      if (result == null)
      {
        return NotFound();
      }

      ViewModel = _mapper.Map<TViewModel>(result);
      return Page();
    }
  }
}
