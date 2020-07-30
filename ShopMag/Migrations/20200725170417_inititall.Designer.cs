﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopMag.Data;

namespace ShopMag.Migrations
{
    [DbContext(typeof(AppDBContent))]
    [Migration("20200725170417_inititall")]
    partial class inititall
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShopMag.Data.Models.Car", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("available");

                    b.Property<int>("categoryID");

                    b.Property<string>("img");

                    b.Property<bool>("isFavourite");

                    b.Property<string>("longDesc");

                    b.Property<string>("name");

                    b.Property<int>("price");

                    b.Property<string>("shortDesc");

                    b.HasKey("id");

                    b.HasIndex("categoryID");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("ShopMag.Data.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("categoryName");

                    b.Property<string>("desc");

                    b.HasKey("id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ShopMag.Data.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("adress")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<DateTime>("orderTime");

                    b.Property<string>("phoned")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.HasKey("id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ShopMag.Data.Models.OrderDetail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarID");

                    b.Property<int>("orderID");

                    b.Property<long>("price");

                    b.HasKey("id");

                    b.HasIndex("CarID");

                    b.HasIndex("orderID");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("ShopMag.Data.Models.ShopCartItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ShopCartId");

                    b.Property<int?>("carid");

                    b.Property<int>("price");

                    b.Property<int>("quantity");

                    b.HasKey("id");

                    b.HasIndex("carid");

                    b.ToTable("ShopCartItem");
                });

            modelBuilder.Entity("ShopMag.Data.Models.Car", b =>
                {
                    b.HasOne("ShopMag.Data.Models.Category", "Category")
                        .WithMany("cars")
                        .HasForeignKey("categoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShopMag.Data.Models.OrderDetail", b =>
                {
                    b.HasOne("ShopMag.Data.Models.Car", "car")
                        .WithMany()
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShopMag.Data.Models.Order", "order")
                        .WithMany("orderDetails")
                        .HasForeignKey("orderID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShopMag.Data.Models.ShopCartItem", b =>
                {
                    b.HasOne("ShopMag.Data.Models.Car", "car")
                        .WithMany()
                        .HasForeignKey("carid");
                });
#pragma warning restore 612, 618
        }
    }
}