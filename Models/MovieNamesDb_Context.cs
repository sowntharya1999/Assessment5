using Microsoft.EntityFrameworkCore;

namespace Assessment5.Models
{
    public class MovieNamesDb_Context:DbContext
    {
        public MovieNamesDb_Context(DbContextOptions<MovieNamesDb_Context> options) : base(options)
        {



        }
        public DbSet<Movies> movies { get; set; }
        public DbSet<UserDetails> userdetails { get; set; }
    }
}
