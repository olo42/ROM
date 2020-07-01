// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using com.github.olo42.ROM.Core.Application;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.Function
{
  public class IndexModel : PageModel
  {
    private readonly IRead<Core.Domain.Function> _readAction;
    private readonly IMapper _mapper;

    public IndexModel(IRead<Core.Domain.Function> readAction, IMapper mapper)
    {
      _readAction = readAction;
      _mapper = mapper;
    }

    public IList<ViewModel> FunctionViewModel { get; set; }

    public async Task OnGetAsync()
    {
      var functions = await _readAction.Execute();
      var functionsOrdered = functions.OrderBy(x => x.Name);
      FunctionViewModel = _mapper.Map<IList<ViewModel>>(functionsOrdered);
    }
  }
}
