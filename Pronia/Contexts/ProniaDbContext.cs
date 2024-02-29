using Microsoft.EntityFrameworkCore;
using Pronia.Entities;

namespace Pronia.DAL
{
    public class ProniaDbContext:DbContext
    {
        public ProniaDbContext(DbContextOptions<ProniaDbContext> options):base(options)
        {
            
        }
        public DbSet<Slider> Sliders { get; set; }
        public object Categories { get; internal set; }
    }
}
