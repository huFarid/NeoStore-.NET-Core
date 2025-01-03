﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NeoStore.Data;

#nullable disable

namespace NeoStore.Migrations
{
    [DbContext(typeof(EshopContext))]
    [Migration("20241129110432_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NeoStore.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("NeoStore.Models.CategoryToProduct", b =>
                {
                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.HasKey("ProductID", "CategoryID");

                    b.HasIndex("CategoryID");

                    b.ToTable("CategoryToProduct");
                });

            modelBuilder.Entity("NeoStore.Models.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("Money");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Price = 12m,
                            QuantityInStock = 10
                        },
                        new
                        {
                            ID = 2,
                            Price = 12m,
                            QuantityInStock = 10
                        },
                        new
                        {
                            ID = 3,
                            Price = 12m,
                            QuantityInStock = 10
                        },
                        new
                        {
                            ID = 4,
                            Price = 12m,
                            QuantityInStock = 10
                        },
                        new
                        {
                            ID = 5,
                            Price = 12m,
                            QuantityInStock = 10
                        },
                        new
                        {
                            ID = 6,
                            Price = 12m,
                            QuantityInStock = 10
                        },
                        new
                        {
                            ID = 7,
                            Price = 12m,
                            QuantityInStock = 10
                        },
                        new
                        {
                            ID = 8,
                            Price = 12m,
                            QuantityInStock = 10
                        });
                });

            modelBuilder.Entity("NeoStore.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Safe and Effordable",
                            ItemId = 1,
                            Name = "Car"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Last Generation",
                            ItemId = 2,
                            Name = "Phone"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Last Generation",
                            ItemId = 3,
                            Name = "Phone"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Last Generation",
                            ItemId = 4,
                            Name = "Phone"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Last Generation",
                            ItemId = 5,
                            Name = "Phone"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Last Generation",
                            ItemId = 6,
                            Name = "Phone"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Last Generation",
                            ItemId = 7,
                            Name = "Phone"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Physics",
                            ItemId = 8,
                            Name = "Book"
                        });
                });

            modelBuilder.Entity("NeoStore.Models.CategoryToProduct", b =>
                {
                    b.HasOne("NeoStore.Models.Category", "Category")
                        .WithMany("CategoryToProducts")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NeoStore.Models.Product", "Product")
                        .WithMany("CategoryToProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("NeoStore.Models.Product", b =>
                {
                    b.HasOne("NeoStore.Models.Item", "Item")
                        .WithOne("Product")
                        .HasForeignKey("NeoStore.Models.Product", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("NeoStore.Models.Category", b =>
                {
                    b.Navigation("CategoryToProducts");
                });

            modelBuilder.Entity("NeoStore.Models.Item", b =>
                {
                    b.Navigation("Product")
                        .IsRequired();
                });

            modelBuilder.Entity("NeoStore.Models.Product", b =>
                {
                    b.Navigation("CategoryToProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
