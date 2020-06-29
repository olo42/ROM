using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using com.github.olo42.ROM.Presentation.WebApp.Pages;

/*
    aspnet-codegenerators are not able to create razorpages without dbcontext.
    Stupid but true. 
    So this class should be removed as soon as page generation is no longer necessary.
*/
    public class none : DbContext
    {
        public none (DbContextOptions<none> options)
            : base(options)
        {
        }

        public DbSet<com.github.olo42.ROM.Presentation.WebApp.Pages.LogTypeViewModel> LogTypeViewModel { get; set; }
    }
