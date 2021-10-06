﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantBusiness.App;

namespace RestaurantBusiness.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20210930172238_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestaurantBusiness.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("RestaurantBusiness.Models.EventProducts", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductId");

                    b.HasIndex("EventId");

                    b.ToTable("EventProducts");
                });

            modelBuilder.Entity("RestaurantBusiness.Models.News", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("RestaurantBusiness.Models.OrderEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClientName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ClientPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CostEvent")
                        .HasColumnType("int");

                    b.Property<int>("CountGuest")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("OrderEvent");
                });

            modelBuilder.Entity("RestaurantBusiness.Models.OrderTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClientName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ClientPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountGuest")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("OrderTable");
                });

            modelBuilder.Entity("RestaurantBusiness.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("RestaurantBusiness.Models.Restaurant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("RestaurantBusiness.Models.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("RestaurantBusiness.Models.EventProducts", b =>
                {
                    b.HasOne("RestaurantBusiness.Models.OrderEvent", "OrderEvent")
                        .WithMany("EventProducts")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK_OrderEvent_OrderProducts")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantBusiness.Models.Product", "Product")
                        .WithMany("EventProducts")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_Product_EventProducts")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderEvent");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("RestaurantBusiness.Models.OrderEvent", b =>
                {
                    b.HasOne("RestaurantBusiness.Models.Restaurant", "Restaurant")
                        .WithMany("EventOrders")
                        .HasForeignKey("RestaurantId")
                        .HasConstraintName("FK_Restaurant_EventOrders")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantBusiness.Models.OrderTable", b =>
                {
                    b.HasOne("RestaurantBusiness.Models.Restaurant", "Restaurant")
                        .WithMany("TableOrders")
                        .HasForeignKey("RestaurantId")
                        .HasConstraintName("FK_Restaurant_TableOrders")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantBusiness.Models.Product", b =>
                {
                    b.HasOne("RestaurantBusiness.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Category_Products")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("RestaurantBusiness.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("RestaurantBusiness.Models.OrderEvent", b =>
                {
                    b.Navigation("EventProducts");
                });

            modelBuilder.Entity("RestaurantBusiness.Models.Product", b =>
                {
                    b.Navigation("EventProducts");
                });

            modelBuilder.Entity("RestaurantBusiness.Models.Restaurant", b =>
                {
                    b.Navigation("EventOrders");

                    b.Navigation("TableOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
