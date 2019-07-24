using Microsoft.EntityFrameworkCore;
using DeezKnuxApi.Models;

namespace DeezKnuxApi.Data 
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options)
        : base(options)
        { }

        public DbSet<Person> People { get; set; }
        public DbSet<KnuxPhrase> KnuxPhrases { get; set; }
    }
}