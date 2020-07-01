// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using com.github.olo42.ROM.Core.Application;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.Function
{
  public class IndexModel : BaseIndexModel<Core.Domain.Function, Core.Domain.Function>
  {
    public IndexModel(IRead<Core.Domain.Function> readAction, IMapper mapper) : base(readAction, mapper)
    {
    }

    public override async Task OnGetAsync()
    {
      var functions = await _readAction.Execute();
      
      var functionsOrdered = functions.OrderBy(x => x.Name);
      
      ViewModel = _mapper.Map<IList<Core.Domain.Function>>(functionsOrdered);
    }
  }
}
