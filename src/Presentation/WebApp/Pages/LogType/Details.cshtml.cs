using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using com.github.olo42.ROM.Core.Application;
using AutoMapper;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.LogType
{
  public class DetailsModel : PageModel
  {
    private readonly IRead<Core.Domain.LogType> _readAction;
    private readonly IMapper _mapper;

    public DetailsModel(IRead<Core.Domain.LogType> readAction, IMapper mapper)
    {
      _readAction = readAction;
      _mapper = mapper;
    }

    public LogTypeViewModel LogTypeViewModel { get; set; }

    public async Task<IActionResult> OnGetAsync(string id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var logType = await _readAction.Execute(new Identifier(id));
      if (logType == null)
      {
        return NotFound();
      }
      
      LogTypeViewModel = _mapper.Map<LogTypeViewModel>(logType);
      return Page();
    }
  }
}
