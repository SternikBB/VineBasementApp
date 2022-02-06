﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VineBasementApp.Persistance.DataAccess;

#nullable disable

namespace VineBasementApp.Persistance.Migrations
{
    [DbContext(typeof(VineBasementContext))]
    [Migration("20220125120818_InitDatabase")]
    partial class InitDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Vine", b =>
                {
                    b.Property<int>("VineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Vb_VineId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VineId"), 1L, 1);

                    b.Property<float>("Acidity")
                        .HasColumnType("real")
                        .HasColumnName("Vb_Acidity");

                    b.Property<float>("AlcoholPercentage")
                        .HasColumnType("real")
                        .HasColumnName("Vb_AlcoholPercentage");

                    b.Property<int>("AmountOfOwnedBottles")
                        .HasColumnType("int")
                        .HasColumnName("Vb_AmountOfOwnedBottles");

                    b.Property<int>("AmountOfPurchasedBottles")
                        .HasColumnType("int")
                        .HasColumnName("Vb_AmountOfPurchasedBottles");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Vb_PurchaseDate");

                    b.Property<float>("PurchasePrice")
                        .HasColumnType("real")
                        .HasColumnName("Vb_PurchasePrice");

                    b.Property<string>("VineColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Vb_VineColor");

                    b.Property<string>("VineName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Vb_VineName");

                    b.Property<string>("VineType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Vb_VineType");

                    b.Property<int>("VineyardId")
                        .HasColumnType("int")
                        .HasColumnName("Vb_VineyardId");

                    b.Property<string>("YearOfBottling")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Vb_YearOfBottling");

                    b.HasKey("VineId");

                    b.HasIndex("VineyardId");

                    b.ToTable("Vb_Vines");
                });

            modelBuilder.Entity("Domain.Entities.Vineyard", b =>
                {
                    b.Property<int>("VineyardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Vb_VineyardId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VineyardId"), 1L, 1);

                    b.Property<string>("VineyardCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Vb_VineyardCity");

                    b.Property<string>("VineyardCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Vb_VineyardCountry");

                    b.Property<string>("VineyardName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Vb_VineyardName");

                    b.Property<string>("VineyardRegion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Vb_VineyardRegion");

                    b.Property<string>("VineyardYearOfFoundation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Vb_VineyardYearOfFoundation");

                    b.HasKey("VineyardId");

                    b.ToTable("Vb_Vineyards");
                });

            modelBuilder.Entity("Domain.Entities.Vine", b =>
                {
                    b.HasOne("Domain.Entities.Vineyard", "Vineyard")
                        .WithMany("Vines")
                        .HasForeignKey("VineyardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vineyard");
                });

            modelBuilder.Entity("Domain.Entities.Vineyard", b =>
                {
                    b.Navigation("Vines");
                });
#pragma warning restore 612, 618
        }
    }
}
