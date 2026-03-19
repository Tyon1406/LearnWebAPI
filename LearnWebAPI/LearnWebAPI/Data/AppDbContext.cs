using LearnWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnWebAPI.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Character> Characters => Set<Character>();
    }
}
