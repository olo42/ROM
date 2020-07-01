// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.Function
{
  public class IndexModel : PageModel
    {
        private readonly com.github.olo42.ROM.Presentation.WebApp.Data.WebAppContext _context;

        public IndexModel(com.github.olo42.ROM.Presentation.WebApp.Data.WebAppContext context)
        {
            _context = context;
        }

        public IList<ViewModel> FunctionViewModel { get;set; }

        public async Task OnGetAsync()
        {
            FunctionViewModel = await _context.FunctionViewModel.ToListAsync();
        }
    }
}
