using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using com.github.olo42.ROM.Core.Application;
using AutoMapper;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.LogType
{
  public class EditModel : PageModel
  {
    private readonly IRead<Core.Domain.LogType> _readAction;
    private readonly IUpdate<Core.Domain.LogType> _updateAction;
    private readonly IMapper _mapper;

    public EditModel(
      IRead<Core.Domain.LogType> readAction,
      IUpdate<Core.Domain.LogType> updateAction,
      IMapper mapper)
    {
      _readAction = readAction;
      _updateAction = updateAction;
      _mapper = mapper;
    }

    [BindProperty]
    public LogTypeViewModel LogTypeViewModel { get; set; }

    public async Task<IActionResult> OnGetAsync(string id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var logType = await _readAction.Execute(new Identifier(id));
      if (logType == null)
        return NotFound();

      LogTypeViewModel = _mapper.Map<LogTypeViewModel>(logType);
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

      var logType = _mapper.Map<Core.Domain.LogType>(LogTypeViewModel);
      await _updateAction.Execute(logType);

      return RedirectToPage("./Index");
    }
  }
}
