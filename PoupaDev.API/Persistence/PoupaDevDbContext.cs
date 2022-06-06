using Microsoft.EntityFrameworkCore;
using PoupaDev.API.Entities;

namespace PoupaDev.API.Persistence
{
    public class PoupaDevDbContext : DbContext
    {
        public DbSet<ObjetivoFinanceiro> Objetivos { get; set; }

        public PoupaDevDbContext(DbContextOptions<PoupaDevDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<ObjetivoFinanceiro>(o => {
                o.HasKey(of => of.Id);
                
                o.Property(of => of.ValorObjetivo)
                    .HasColumnType("decimal(18,4)");

                o.HasMany(of => of.Operacoes)
                    .WithOne()
                    .HasForeignKey(o => o.IdObjetivo)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Operacao>(o => {
                o.HasKey(op => op.Id);

                o.Property(op => op.Valor)
                    .HasColumnType("decimal(18,4)");
            });
        }
    }
}