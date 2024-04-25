using Cp2_DotNet.Models;

using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;

namespace Cp2_DotNet.Persistencia
{
    public class FIAPDbContext : DbContext
    {
       
        public DbSet<Enfermeiro> Enfermeiros { get; set; }
        public DbSet<ClinicoGeral> ClinicoGerais { get; set; }
        public DbSet<Cirurgiao> Cirurgioes { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Pediatra> Pediatras { get; set; }
        public DbSet<CRM> CRMs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClinicoGeral>()
                .HasOne(c => c.CRM)
                .WithOne()
                .HasForeignKey<ClinicoGeral>(c => c.CRMId);
        }
        public FIAPDbContext(DbContextOptions<FIAPDbContext> options) : base(options)
        {

        }
    }
}
