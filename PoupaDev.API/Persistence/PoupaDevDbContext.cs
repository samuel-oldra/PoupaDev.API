using Microsoft.EntityFrameworkCore;
using PoupaDev.API.Entities;

namespace PoupaDev.API.Persistence
{
    public class PoupaDevDbContext : DbContext
    {
        public DbSet<ObjetivoFinanceiro> Objetivos { get; set; }

        public PoupaDevDbContext(DbContextOptions<PoupaDevDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ObjetivoFinanceiro>(of =>
            {
                of.HasKey(of => of.Id);

                of.Property(of => of.ValorObjetivo)
                    .HasColumnType("decimal(18,4)");

                of.HasMany(of => of.Operacoes)
                    .WithOne()
                    .HasForeignKey(o => o.IdObjetivo)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Operacao>(op =>
            {
                op.HasKey(op => op.Id);

                op.Property(op => op.Valor)
                    .HasColumnType("decimal(18,4)");
            });
        }
    }
}