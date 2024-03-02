﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiDemo.Data;

#nullable disable

namespace WebApiDemo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231220191428_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApiDemo.Models.Shirt", b =>
                {
                    b.Property<int>("ShirtId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShirtId"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("Size")
                        .HasColumnType("int");

                    b.HasKey("ShirtId");

                    b.ToTable("Shirts");

                    b.HasData(
                        new
                        {
                            ShirtId = 1,
                            Brand = "Puma",
                            Color = "Green",
                            Gender = "Men",
                            Price = 900.0,
                            Size = 9
                        },
                        new
                        {
                            ShirtId = 2,
                            Brand = "Nike",
                            Color = "Blue",
                            Gender = "Women",
                            Price = 700.0,
                            Size = 6
                        },
                        new
                        {
                            ShirtId = 3,
                            Brand = "Sketchers",
                            Color = "White",
                            Gender = "Men",
                            Price = 1900.0,
                            Size = 9
                        },
                        new
                        {
                            ShirtId = 4,
                            Brand = "Apple",
                            Color = "Black",
                            Gender = "Men",
                            Price = 9000.0,
                            Size = 7
                        },
                        new
                        {
                            ShirtId = 5,
                            Brand = "Google",
                            Color = "Black White",
                            Gender = "Men",
                            Price = 800.0,
                            Size = 8
                        });
                });
#pragma warning restore 612, 618
        }
    }
}