// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using com.github.olo42.ROM.Core.Application;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.LogType
{
  public class IndexModel : PageModel
  {
    private readonly IRead<Core.Domain.LogType> _readAction;
    private readonly IMapper _mapper;

    public IndexModel(IRead<Core.Domain.LogType> readAction, IMapper mapper)
    {
      _readAction = readAction;
      _mapper = mapper;
    }

    public IList<LogTypeViewModel> LogTypeViewModel { get; set; }

    public async Task OnGetAsync()
    {
      var logTypes = await _readAction.Execute();
      var logTypesOrdered = logTypes.OrderBy(x => x.Name);
      LogTypeViewModel = _mapper.Map<IList<LogTypeViewModel>>(logTypesOrdered);
    }
  }
}
