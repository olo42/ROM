// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using AutoMapper;
using com.github.olo42.ROM.Core.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.Function
{
  public class CreateModel : PageModel
  {
    private readonly ICreate<Core.Domain.Function> _createAction;
    private readonly IMapper _mapper;

    public CreateModel(ICreate<Core.Domain.Function> createAction, IMapper mapper)
    {
      _createAction = createAction;
      _mapper = mapper;
    }

    public IActionResult OnGet()
    {
      return Page();
    }

    [BindProperty]
    public ViewModel FunctionViewModel { get; set; }

    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      var function = _mapper.Map<Core.Domain.Function>(FunctionViewModel);
      await _createAction.Execute(function);

      return RedirectToPage("./Index");
    }
  }
}
