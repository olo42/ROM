// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using AutoMapper;
using com.github.olo42.ROM.Core.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.Function
{
  public class EditModel : PageModel
  {
    private readonly IRead<Core.Domain.Function> _readAction;
    private readonly IUpdate<Core.Domain.Function> _updateAction;
    private readonly IMapper _mapper;

    public EditModel(
      IRead<Core.Domain.Function> readAction,
      IUpdate<Core.Domain.Function> updateAction,
      IMapper mapper)
    {
      _readAction = readAction;
      _updateAction = updateAction;
      _mapper = mapper;
    }

    [BindProperty]
    public ViewModel FunctionViewModel { get; set; }

    public async Task<IActionResult> OnGetAsync(string id)
    {
      if (id == null)
        return NotFound();

      var logType = await _readAction.Execute(new Identifier(id));
      if (logType == null)
        return NotFound();

      FunctionViewModel = _mapper.Map<ViewModel>(logType);
      return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      var function = _mapper.Map<Core.Domain.Function>(FunctionViewModel);
      await _updateAction.Execute(function);

      return RedirectToPage("./Index");
    }
  }
}
