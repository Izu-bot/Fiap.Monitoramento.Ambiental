﻿// <auto-generated />
using System;
using Fiap.Monitoramento.Ambiental.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Fiap.Monitoramento.Ambiental.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240627141407_UserTable")]
    partial class UserTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fiap.Monitoramento.Ambiental.Models.DesastresNaturaisModel", b =>
                {
                    b.Property<int>("DesastreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DesastreId"));

                    b.Property<DateTime?>("Data")
                        .HasColumnType("date");

                    b.Property<string>("Lugar")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("Resolvido")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("TipoDesastre")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Tipo_Desastre");

                    b.HasKey("DesastreId");

                    b.ToTable("TBL_Desastres_Naturais", (string)null);
                });

            modelBuilder.Entity("Fiap.Monitoramento.Ambiental.Models.IrrigacaoModel", b =>
                {
                    b.Property<int>("IrrigacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IrrigacaoId"));

                    b.Property<DateTime>("DataIrrigacao")
                        .HasColumnType("date")
                        .HasColumnName("Data_Irrigacao");

                    b.Property<string>("Lugar")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("MonitoraQualidadeArId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("QualidadeAr")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Qualidade_Ar");

                    b.HasKey("IrrigacaoId");

                    b.HasIndex("MonitoraQualidadeArId")
                        .IsUnique();

                    b.ToTable("TBL_Irrigacao", (string)null);
                });

            modelBuilder.Entity("Fiap.Monitoramento.Ambiental.Models.MonitoraQualidadeArModel", b =>
                {
                    b.Property<int>("MonitorarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MonitorarId"));

                    b.Property<DateTime>("DiaMonitoracao")
                        .HasColumnType("date")
                        .HasColumnName("Dia_Monitoramento");

                    b.Property<string>("Qualidade")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("MonitorarId");

                    b.ToTable("TBL_Monitoramento_Ar", (string)null);
                });

            modelBuilder.Entity("Fiap.Monitoramento.Ambiental.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Password");

                    b.Property<string>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasDefaultValue("Usuario");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("User_Name");

                    b.HasKey("UserId");

                    b.ToTable("TBL_Usuarios", (string)null);
                });

            modelBuilder.Entity("Fiap.Monitoramento.Ambiental.Models.IrrigacaoModel", b =>
                {
                    b.HasOne("Fiap.Monitoramento.Ambiental.Models.MonitoraQualidadeArModel", "MonitoraQualidadeArModel")
                        .WithOne()
                        .HasForeignKey("Fiap.Monitoramento.Ambiental.Models.IrrigacaoModel", "MonitoraQualidadeArId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MonitoraQualidadeArModel");
                });
#pragma warning restore 612, 618
        }
    }
}
