﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories;

#nullable disable

namespace StoreApp.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Entitites.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Book"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Electronic"
                        });
                });

            modelBuilder.Entity("Entitites.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Summary")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 2,
                            ImageUrl = "/images/4.jpeg",
                            Price = 17000m,
                            ProductName = "Computer",
                            Summary = ""
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 2,
                            ImageUrl = "/images/2.jpeg",
                            Price = 1000m,
                            ProductName = "Keyboard",
                            Summary = ""
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 2,
                            ImageUrl = "/images/3.jpeg",
                            Price = 500m,
                            ProductName = "Mouse",
                            Summary = ""
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 2,
                            ImageUrl = "/images/1.jpeg",
                            Price = 7000m,
                            ProductName = "Monitor",
                            Summary = ""
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 2,
                            ImageUrl = "/images/default.jpeg",
                            Price = 1500m,
                            ProductName = "Deck",
                            Summary = ""
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 2,
                            ImageUrl = "/images/default.jpeg",
                            Price = 15000m,
                            ProductName = "Playstation5",
                            Summary = ""
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 1,
                            ImageUrl = "/images/5.jpeg",
                            Price = 100m,
                            ProductName = "History",
                            Summary = ""
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryId = 1,
                            ImageUrl = "/images/6.jpeg",
                            Price = 120m,
                            ProductName = "Hamlet",
                            Summary = ""
                        });
                });

            modelBuilder.Entity("Entitites.Models.Product", b =>
                {
                    b.HasOne("Entitites.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Entitites.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
