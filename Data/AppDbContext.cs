using InvestmentControl.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestmentControl.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Investimento> Investimentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Investimento>()
                .Property(i => i.Valor)
                .HasPrecision(18, 2);
        }
    }
}
