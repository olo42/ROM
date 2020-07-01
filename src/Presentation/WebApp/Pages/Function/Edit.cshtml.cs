// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.Function
{
  public class EditModel : PageModel
    {
        private readonly com.github.olo42.ROM.Presentation.WebApp.Data.WebAppContext _context;

        public EditModel(com.github.olo42.ROM.Presentation.WebApp.Data.WebAppContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FunctionViewModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FunctionViewModelExists(FunctionViewModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FunctionViewModelExists(string id)
        {
            return _context.FunctionViewModel.Any(e => e.Id == id);
        }
    }
}
