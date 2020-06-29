using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using com.github.olo42.ROM.Core.Domain;
using com.github.olo42.ROM.Core.Application;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.LogTypes
{
  public class CreateModel : PageModel
    {
        private readonly ICreate<string, LogType> _action;

        public CreateModel(ICreate<string, LogType> action)
        {
            _action = action;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LogTypeViewModel LogTypeViewModel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _action.Execute(LogTypeViewModel.Name);

            return RedirectToPage("./Index");
        }
    }
}
