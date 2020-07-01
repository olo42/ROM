// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.Function
{
  public class DeleteModel : PageModel
    {
        private readonly com.github.olo42.ROM.Presentation.WebApp.Data.WebAppContext _context;

        public DeleteModel(com.github.olo42.ROM.Presentation.WebApp.Data.WebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ViewModel FunctionViewModel { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FunctionViewModel = await _context.FunctionViewModel.FirstOrDefaultAsync(m => m.Id == id);

            if (FunctionViewModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FunctionViewModel = await _context.FunctionViewModel.FindAsync(id);

            if (FunctionViewModel != null)
            {
                _context.FunctionViewModel.Remove(FunctionViewModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
