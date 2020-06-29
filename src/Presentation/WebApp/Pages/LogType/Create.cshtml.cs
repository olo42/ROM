using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using com.github.olo42.ROM.Presentation.WebApp.Data;
using com.github.olo42.ROM.Core.Application;
using AutoMapper;
using System;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.LogType
{
  public class CreateModel : PageModel
  {
    private readonly IRepository<Core.Domain.LogType> _repository;
    private readonly IMapper _mapper;

    public CreateModel(IRepository<Core.Domain.LogType> repository, IMapper mapper)
    {
      _repository = repository;
      this._mapper = mapper;
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

      var logType = _mapper.Map<Core.Domain.LogType>(LogTypeViewModel);
      logType.Id = Guid.NewGuid().ToString();

      await _repository.WriteAsync(logType);

      return RedirectToPage("./Index");
    }
  }
}
