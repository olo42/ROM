// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using AutoMapper;
using com.github.olo42.ROM.Core.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.Function
{
  public class DetailsModel : PageModel
  {
    private readonly IRead<Core.Domain.Function> _readAction;
    private readonly IMapper _mapper;

    public DetailsModel(IRead<Core.Domain.Function> readAction, IMapper mapper)
    {
      _readAction = readAction;
      _mapper = mapper;
    }

    public ViewModel FunctionViewModel { get; set; }

    public async Task<IActionResult> OnGetAsync(string id)
    {
      if (id == null)
        return NotFound();

      var identifier = new Identifier(id);
      var function = await _readAction.Execute(identifier);
      if (function == null)
      {
        return NotFound();
      }

      FunctionViewModel = _mapper.Map<ViewModel>(function);
      return Page();
    }
  }
}
