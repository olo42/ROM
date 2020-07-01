using AutoMapper;
using com.github.olo42.ROM.Core.Domain;

namespace com.github.olo42.ROM.Presentation.WebApp
{
  public class MappingsProfile : Profile
  {
    public MappingsProfile()
    {
      CreateMap<LogType, Pages.LogType.LogTypeViewModel>().ReverseMap();
      CreateMap<Function, Pages.Function.ViewModel>().ReverseMap();
    }
  }
}
