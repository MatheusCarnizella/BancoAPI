﻿// <auto-generated />
using System;
using BancoAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BancoAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BancoAPI.Models.Cliente", b =>
                {
                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("chavePix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Nome");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("BancoAPI.Models.Transacao", b =>
                {
                    b.Property<string>("chaveOrigem")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal?>("Valor")
                        .IsRequired()
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.Property<string>("chaveDestino")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("chavePix")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("chaveOrigem");

                    b.HasIndex("chavePix");

                    b.ToTable("Transacao");
                });

            modelBuilder.Entity("BancoAPI.Models.Transacao", b =>
                {
                    b.HasOne("BancoAPI.Models.Cliente", "Cliente")
                        .WithMany("Transacoes")
                        .HasForeignKey("chavePix");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("BancoAPI.Models.Cliente", b =>
                {
                    b.Navigation("Transacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
