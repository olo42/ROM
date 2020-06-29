using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using com.github.olo42.ROM.Presentation.WebApp.Data;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.LogType
{
  public class DeleteModel : PageModel
  {
    private readonly WebAppContext _context;

    public DeleteModel(WebAppContext context)
    {
      _context = context;
    }

    [BindProperty]
    public LogTypeViewModel LogTypeViewModel { get; set; }

    public async Task<IActionResult> OnGetAsync(string id)
    {
      if (id == null)
      {
        return NotFound();
      }

      LogTypeViewModel = await _context.LogTypeViewModel.FirstOrDefaultAsync(m => m.Id == id);

      if (LogTypeViewModel == null)
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

      LogTypeViewModel = await _context.LogTypeViewModel.FindAsync(id);

      if (LogTypeViewModel != null)
      {
        _context.LogTypeViewModel.Remove(LogTypeViewModel);
        await _context.SaveChangesAsync();
      }

      return RedirectToPage("./Index");
    }
  }
}
