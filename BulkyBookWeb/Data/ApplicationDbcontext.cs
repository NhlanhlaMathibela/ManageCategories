using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Data
{
    public class ApplicationDbcontext:DbContext
    {

        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext>options) : base(options) 
        {
           
        }

        public DbSet<Category>Categories { get; set; }

    }
}
