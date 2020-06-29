using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using com.github.olo42.ROM.Core.Application;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.LogType
{
  public class IndexModel : PageModel
  {
    private readonly IRepository<Core.Domain.LogType> _repository;
    private readonly IMapper _mapper;

    public IndexModel(IRepository<Core.Domain.LogType> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public IList<LogTypeViewModel> LogTypeViewModel { get; set; }

    public async Task OnGetAsync()
    {
      var logTypes = await _repository.ReadAsync();
      var logTypesOrdered = logTypes.OrderBy(x => x.Name);
      LogTypeViewModel = _mapper.Map<IList<LogTypeViewModel>>(logTypesOrdered);
    }
  }
}
