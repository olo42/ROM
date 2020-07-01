// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using AutoMapper;
using com.github.olo42.ROM.Core.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages
{
  public class BaseEditModel<TModel, TViewModel> : PageModel
  {
    protected readonly IRead<TModel> _readAction;
    protected readonly IUpdate<TModel> _updateAction;
    protected readonly IMapper _mapper;

    public BaseEditModel(
      IRead<TModel> readAction,
      IUpdate<TModel> updateAction,
      IMapper mapper)
    {
      _readAction = readAction;
      _updateAction = updateAction;
      _mapper = mapper;
    }

    [BindProperty]
    public TViewModel ViewModel { get; set; }

    public virtual async Task<IActionResult> OnGetAsync(string id)
    {
      if (id == null)
        return NotFound();

      var result = await _readAction.Execute(new Identifier(id));
      if (result == null)
        return NotFound();

      ViewModel = _mapper.Map<TViewModel>(result);
      return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public virtual async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      var result = _mapper.Map<TModel>(ViewModel);
      await _updateAction.Execute(result);

      return RedirectToPage("./Index");
    }
  }
}
