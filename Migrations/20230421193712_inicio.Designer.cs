﻿// <auto-generated />
using System;
using AR_Ejercicio2Tablas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AR_Ejercicio2Tablas.Migrations
{
    [DbContext(typeof(AR_DBContext))]
    [Migration("20230421193712_inicio")]
    partial class inicio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AR_Ejercicio2Tablas.Models.Burguer", b =>
                {
                    b.Property<int>("BurguerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BurguerId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("WithCheese")
                        .HasColumnType("bit");

                    b.HasKey("BurguerId");

                    b.ToTable("Burguer");
                });

            modelBuilder.Entity("AR_Ejercicio2Tablas.Models.Promo", b =>
                {
                    b.Property<int>("PromoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PromoId"), 1L, 1);

                    b.Property<int>("BurguerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaPromo")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PromoId1")
                        .HasColumnType("int");

                    b.Property<string>("PromoType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PromoId");

                    b.HasIndex("BurguerId");

                    b.HasIndex("PromoId1");

                    b.ToTable("Promo");
                });

            modelBuilder.Entity("AR_Ejercicio2Tablas.Models.Promo", b =>
                {
                    b.HasOne("AR_Ejercicio2Tablas.Models.Burguer", "Burguer")
                        .WithMany()
                        .HasForeignKey("BurguerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AR_Ejercicio2Tablas.Models.Promo", null)
                        .WithMany("Promos")
                        .HasForeignKey("PromoId1");

                    b.Navigation("Burguer");
                });

            modelBuilder.Entity("AR_Ejercicio2Tablas.Models.Promo", b =>
                {
                    b.Navigation("Promos");
                });
#pragma warning restore 612, 618
        }
    }
}