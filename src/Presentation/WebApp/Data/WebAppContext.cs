using Microsoft.EntityFrameworkCore;
using com.github.olo42.ROM.Presentation.WebApp.Pages.LogType;
using com.github.olo42.ROM.Presentation.WebApp.Pages.Function;

namespace com.github.olo42.ROM.Presentation.WebApp.Data
{
  public class WebAppContext : DbContext
    {
        public WebAppContext (DbContextOptions<WebAppContext> options)
            : base(options)
        {
        }
        public DbSet<com.github.olo42.ROM.Presentation.WebApp.Pages.LogType.LogTypeViewModel> LogTypeViewModel { get; set; }
        public DbSet<com.github.olo42.ROM.Presentation.WebApp.Pages.Function.ViewModel> FunctionViewModel { get; set; }

       
    }
}
