using Microsoft.EntityFrameworkCore;
using DeezKnuxApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DeezKnuxApi.Data 
{
    public class AppDbcontext : IdentityDbContext<ApplicationUser>
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options)
        : base(options)
        { }

        public DbSet<KnuxPhrase> KnuxPhrases { get; set; }
    }
}