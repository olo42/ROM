using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using com.github.olo42.ROM.Presentation.WebApp.Data;
using com.github.olo42.ROM.Core.Application;
using AutoMapper;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.LogType
{
  public class DetailsModel : PageModel
  {
    private readonly IRepository<Core.Domain.LogType> _repository;
    private readonly IMapper _mapper;

    public DetailsModel(IRepository<Core.Domain.LogType> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

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
  }
}
