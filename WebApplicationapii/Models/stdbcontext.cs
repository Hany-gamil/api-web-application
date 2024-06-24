using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebApplicationapii.Models;

namespace WebApplicationAPI.Models
{
    public class stdbcontext:IdentityDbContext<applicationUser>
    {
        public stdbcontext(DbContextOptions<stdbcontext> options):base(options)
      

        {

        }
        public DbSet<student>students { get; set; }
    }
}
