using Fiap.Monitoramento.Ambiental.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Monitoramento.Ambiental.Data.Database
{
    public class DatabaseContext : DbContext
    {
        #region Propriedades para manipular as entidades

        public virtual DbSet<DesastresNaturaisModel> desastresNaturais { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DesastresNaturaisModel>(entity =>
            {
                entity.ToTable("TBL_Desastres_Naturais");
                entity.HasKey(e => e.DesastreId);
                entity.Property(e => e.TipoDesastre).HasColumnName("Tipo_Desastre").IsRequired();
                entity.Property(e => e.Lugar).IsRequired();
                entity.Property(e => e.Resolvido).HasConversion(
                    v => v ? 1 : 0, // Converte o bool para numero (1 se true, 0 se false
                    v => v == 1
                    ).IsRequired();

                entity.Property(e => e.Data).HasColumnType("date");
            });
        }

        public DatabaseContext(DbContextOptions options) : base(options) { }
        protected DatabaseContext() { }
    }
}
