// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using com.github.olo42.ROM.Core.Application;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.LogType
{
  public class IndexModel : BaseIndexModel<Core.Domain.LogType, LogTypeViewModel>
  {
    public IndexModel(IRead<Core.Domain.LogType> readAction, IMapper mapper) : base(readAction, mapper)
    {
    }

    public override async Task OnGetAsync()
    {
      var logTypes = await _readAction.Execute();
      
      var logTypesOrdered = logTypes.OrderBy(x => x.Name);
      
      ViewModel = _mapper.Map<IList<LogTypeViewModel>>(logTypesOrdered);
    }
  }
}
