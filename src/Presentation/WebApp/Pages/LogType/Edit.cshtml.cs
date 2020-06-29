using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using com.github.olo42.ROM.Core.Application;
using AutoMapper;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.LogType
{
  public class EditModel : PageModel
  {
    private readonly IRepository<Core.Domain.LogType> _repository;
    private readonly IMapper _mapper;

    public EditModel(IRepository<Core.Domain.LogType> repository, IMapper mapper)
    {
      _repository = repository;
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

      var logType = await _repository.ReadAsync(id);

      if (logType == null)
      {
        return NotFound();
      }

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
      await _repository.WriteAsync(logType);

      return RedirectToPage("./Index");
    }
  }
}
