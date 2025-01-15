using GayaProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GayaProject.Data
{
    public class ProcessActionDbContext : DbContext
    {
        public ProcessActionDbContext(DbContextOptions<ProcessActionDbContext> options)
            : base(options) { }


        public DbSet<ProcessAction> ProcessAction { get; set; }
    }
}
