// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using AutoMapper;
using com.github.olo42.ROM.Core.Application;
using com.github.olo42.ROM.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages
{
  public class BaseDeleteModel<TModel, TViewModel> : PageModel where TModel : IIdentifiable
  {
    protected readonly IRead<TModel> _readAction;
    protected readonly IDelete<TModel> _deleteAction;
    protected readonly IMapper _mapper;

    public BaseDeleteModel(
      IRead<TModel> readAction,
      IDelete<TModel> deleteAction,
      IMapper mapper)
    {
      _readAction = readAction;
      _deleteAction = deleteAction;
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

    public virtual async Task<IActionResult> OnPostAsync(string id)
    {
      if (id == null)
        return NotFound();

      await _deleteAction.Execute(new Identifier(id));

      return RedirectToPage("./Index");
    }
  }
}
