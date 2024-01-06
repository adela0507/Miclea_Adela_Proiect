﻿// <auto-generated />
using System;
using Miclea_Adela_Proiect.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Miclea_Adela_Proiect.Migrations
{
    [DbContext(typeof(ProductContext))]
    partial class ProductContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Miclea_Adela_Proiect.Models.Brand", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Brand", (string)null);
                });

            modelBuilder.Entity("Miclea_Adela_Proiect.Models.BrandProducer", b =>
                {
                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("BrandID")
                        .HasColumnType("int");

                    b.HasKey("ProductID", "BrandID");

                    b.HasIndex("BrandID");

                    b.ToTable("BrandProducer", (string)null);
                });

            modelBuilder.Entity("Miclea_Adela_Proiect.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("Miclea_Adela_Proiect.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"), 1L, 1);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("ProductID");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("Miclea_Adela_Proiect.Models.Producer", b =>
                {
                    b.Property<string>("ProducerID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProducerCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProducerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProducerID");

                    b.ToTable("Producer", (string)null);
                });

            modelBuilder.Entity("Miclea_Adela_Proiect.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProducerID")
                        .HasColumnType("int");

                    b.Property<string>("ProducerID1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("ProducerID1");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("Miclea_Adela_Proiect.Models.BrandProducer", b =>
                {
                    b.HasOne("Miclea_Adela_Proiect.Models.Brand", "Brand")
                        .WithMany("BrandProducers")
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Miclea_Adela_Proiect.Models.Product", "Product")
                        .WithMany("BrandProducers")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Miclea_Adela_Proiect.Models.Order", b =>
                {
                    b.HasOne("Miclea_Adela_Proiect.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Miclea_Adela_Proiect.Models.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Miclea_Adela_Proiect.Models.Product", b =>
                {
                    b.HasOne("Miclea_Adela_Proiect.Models.Producer", "Producer")
                        .WithMany("Products")
                        .HasForeignKey("ProducerID1");

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("Miclea_Adela_Proiect.Models.Brand", b =>
                {
                    b.Navigation("BrandProducers");
                });

            modelBuilder.Entity("Miclea_Adela_Proiect.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Miclea_Adela_Proiect.Models.Producer", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Miclea_Adela_Proiect.Models.Product", b =>
                {
                    b.Navigation("BrandProducers");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
