using Fiap.Monitoramento.Ambiental.Models;
using Fiap.Monitoramento.Ambiental.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Monitoramento.Ambiental.Data.Database
{
    public class DatabaseContext : DbContext
    {
        #region Propriedades para manipular as entidades

        public virtual DbSet<DesastresNaturaisModel> desastresNaturais { get; set; }
        public virtual DbSet<MonitoraQualidadeArModel> MonitoraQualidadeArModels { get; set; }
        public virtual DbSet<IrrigacaoModel> IrrigacaoModels { get; set; }

        #endregion

        public DatabaseContext(DbContextOptions options) : base(options) { }
        protected DatabaseContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Criando a tabela Desastres Naturais
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

            // Criando a tabela Monitoramento do Ar
            modelBuilder.Entity<MonitoraQualidadeArModel>(entity =>
            {
                entity.ToTable("TBL_Monitoramento_Ar");
                entity.HasKey(e => e.MonitorarId);
                entity.Property(e => e.DiaMonitoracao)
                    .HasColumnName("Dia_Monitoramento")
                    .HasColumnType("date")
                    .IsRequired();
                entity.Property(e => e.Qualidade).IsRequired();
            });

            // Criando a tabela Irrigação
            modelBuilder.Entity<IrrigacaoModel>(entity =>
            {
                entity.ToTable("TBL_Irrigacao");
                entity.HasKey(e => e.IrrigacaoId);
                entity.Property(e => e.QualidadeAr).HasColumnName("Qualidade_Ar").IsRequired();
                entity.Property(e => e.DataIrrigacao)
                    .HasColumnName("Data_Irrigacao")
                    .IsRequired()
                    .HasColumnType("date");
                entity.Property(e => e.Lugar) .IsRequired();

                // Referencia da chave estrangeira
                entity.HasIndex(e => e.MonitoraQualidadeArId).IsUnique();
            });

            // Configurando Enum para ser armazenado como String
            modelBuilder.Entity<MonitoraQualidadeArModel>()
                .Property(m => m.Qualidade)
                .HasConversion<string>();

            modelBuilder.Entity<IrrigacaoModel>()
                .Property(i => i.QualidadeAr)
                .HasConversion<string>();

            // Configurar relação 1:1 entre Irrigação e MonitoramentoQualidadeAr
            modelBuilder.Entity<IrrigacaoModel>()
                .HasOne(i => i.MonitoraQualidadeArModel)
                .WithOne()
                .HasForeignKey<IrrigacaoModel>(i => i.MonitoraQualidadeArId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
