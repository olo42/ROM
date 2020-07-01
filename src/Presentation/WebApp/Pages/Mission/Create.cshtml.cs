// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using com.github.olo42.ROM.Core.Application;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.Mission
{
  public class CreateModel : BaseCreateModel<Core.Domain.Mission, CreateViewModel>
  {
    public CreateModel(ICreate<Core.Domain.Mission> createAction, IMapper mapper) 
      : base(createAction, mapper)
    {
    }

    public override async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      var mission = new Core.Domain.Mission
      {
        Objective = ViewModel.Objective,
        Alert = new Core.Domain.Alert
        {
          Number = ViewModel.AlertNumber,
          DateTime = ViewModel.AlertDateTime
        }
      };

      //var result = _mapper.Map<TModel>(ViewModel);
      await _createAction.Execute(mission);

      return RedirectToPage("./Index");
    }
  }
}
