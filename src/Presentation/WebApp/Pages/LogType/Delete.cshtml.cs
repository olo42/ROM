using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using com.github.olo42.ROM.Core.Application;
using AutoMapper;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.LogType
{
  public class DeleteModel : PageModel
  {
    private readonly IRead<Identifier, Core.Domain.LogType> _readAction;
    private readonly IDelete<Identifier> _deleteAction;
    private readonly IMapper _mapper;

    public DeleteModel(
      IRead<Identifier, Core.Domain.LogType> readAction,
      IDelete<Identifier> deleteAction,
      IMapper mapper)
    {
      _readAction = readAction;
      _deleteAction = deleteAction;
      _mapper = mapper;
    }

    [BindProperty]
    public LogTypeViewModel LogTypeViewModel { get; set; }

    public async Task<IActionResult> OnGetAsync(string id)
    {
      if (id == null)
        return NotFound();

      var logType = await _readAction.Execute(new Identifier(id));
      if (logType == null)
        return NotFound();

      LogTypeViewModel = _mapper.Map<LogTypeViewModel>(logType);
      
      return Page();
    }

    public async Task<IActionResult> OnPostAsync(string id)
    {
      if (id == null)
        return NotFound();

      await _deleteAction.Execute(new Identifier(id));
      
      return RedirectToPage("./Index");
    }
  }
}
