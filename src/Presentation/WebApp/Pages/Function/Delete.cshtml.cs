// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using AutoMapper;
using com.github.olo42.ROM.Core.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.Function
{
  public class DeleteModel : PageModel
  {
    private readonly IRead<Core.Domain.Function> _readAction;
    private readonly IDelete<Core.Domain.Function> _deleteAction;
    private readonly IMapper _mapper;

    public DeleteModel(
      IRead<Core.Domain.Function> readAction,
      IDelete<Core.Domain.Function> deleteAction,
      IMapper mapper)
    { 
      _readAction = readAction;
      _deleteAction = deleteAction;
      _mapper = mapper;
    }

    [BindProperty]
    public ViewModel FunctionViewModel { get; set; }

    public async Task<IActionResult> OnGetAsync(string id)
    {
      if (id == null)
        return NotFound();

      var function = await _readAction.Execute(new Identifier(id));
      if (function == null)
        return NotFound();

      FunctionViewModel = _mapper.Map<ViewModel>(function);

      return Page();
    }

    public async Task<IActionResult> OnPostAsync(string id)
    {
      if (id == null)
        return NotFound();

      await _deleteAction.Execute(new Core.Domain.Function { Id = id });

      return RedirectToPage("./Index");
    }
  }
}
