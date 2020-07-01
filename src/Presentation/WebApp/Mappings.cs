using AutoMapper;
using com.github.olo42.ROM.Core.Domain;
using com.github.olo42.ROM.Presentation.WebApp.Pages.Function;
using com.github.olo42.ROM.Presentation.WebApp.Pages.LogType;

namespace WebApp
{
  public class MappingsProfile : Profile
  {
    public MappingsProfile()
    {
      CreateMap<LogType, LogTypeViewModel>().ReverseMap();
      CreateMap<Function, ViewModel>().ReverseMap();
    }
  }
}
