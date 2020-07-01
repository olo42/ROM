// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using AutoMapper;
using com.github.olo42.ROM.Core.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages
{
  public class BaseCreateModel<TModel, TViewModel> : PageModel
  {
    protected readonly ICreate<TModel> _createAction;
    protected readonly IMapper _mapper;

    public BaseCreateModel(ICreate<TModel> createAction, IMapper mapper)
    {
      _createAction = createAction;
      _mapper = mapper;
    }

    public IActionResult OnGet()
    {
      return Page();
    }

    [BindProperty]
    public TViewModel ViewModel { get; set; }

    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public virtual async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      var result = _mapper.Map<TModel>(ViewModel);
      await _createAction.Execute(result);

      return RedirectToPage("./Index");
    }
  }
}
