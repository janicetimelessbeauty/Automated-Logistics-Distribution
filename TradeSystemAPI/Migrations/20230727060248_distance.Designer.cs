﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TradeSystemAPI.Data;

#nullable disable

namespace TradeSystemAPI.Migrations
{
    [DbContext(typeof(TradeContext))]
    [Migration("20230727060248_distance")]
    partial class distance
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TradeSystemAPI.Models.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateofBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("dist")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mobilePhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TradeSystemAPI.Models.ImageUpload", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("fileDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("filePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("fileSize")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("ImageUploads");
                });

            modelBuilder.Entity("TradeSystemAPI.Models.NewOrder", b =>
                {
                    b.Property<Guid>("NewOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("NewOrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("NewOrder");
                });

            modelBuilder.Entity("TradeSystemAPI.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<Guid>("NewOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NewOrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TradeSystemAPI.Models.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Distributor")
                        .HasColumnType("int");

                    b.Property<string>("ProductCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductPrice")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("d048f7ab-5b75-4d37-8f4e-ad939e8dba0a"),
                            Distributor = 12,
                            ProductCategory = "Electric",
                            ProductDescription = "Good for your night sleep with coziness and comfort",
                            ProductImgUrl = "https://tamhome.vn/wp-content/uploads/2017/07/IMG_4969.jpg",
                            ProductName = "Mickey Mouse",
                            ProductPrice = 500
                        },
                        new
                        {
                            ProductId = new Guid("53dc9e8c-c3dd-4b5a-8ef0-80535bf66bbb"),
                            Distributor = 22,
                            ProductCategory = "Detox",
                            ProductDescription = "Healthy with a rich source of vitamins C",
                            ProductImgUrl = "https://drivemehungry.com/wp-content/uploads/2022/08/korean-banana-milk-5.jpg",
                            ProductName = "Banana Milk",
                            ProductPrice = 20
                        },
                        new
                        {
                            ProductId = new Guid("569289df-6346-4e75-a15d-923f97cac8ac"),
                            Distributor = 25,
                            ProductCategory = "Dessert",
                            ProductDescription = "Perfect for ending your meal with some sweet treats",
                            ProductImgUrl = "https://leitesculinaria.com/wp-content/uploads/2020/01/panna-cotta.jpg",
                            ProductName = "Panna Cotta",
                            ProductPrice = 30
                        });
                });

            modelBuilder.Entity("TradeSystemAPI.Models.Warehouse", b =>
                {
                    b.Property<Guid>("WarehouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CentralDistance")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstimatedTime")
                        .HasColumnType("int");

                    b.Property<string>("License")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WareName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WarehouseId");

                    b.ToTable("Warehouses");

                    b.HasData(
                        new
                        {
                            WarehouseId = new Guid("b7f822ef-493b-4f15-802a-5c75de666e8d"),
                            CentralDistance = "21",
                            EstimatedTime = 3,
                            License = "2012",
                            WareName = "Felix"
                        },
                        new
                        {
                            WarehouseId = new Guid("e5e31796-666d-4d99-9805-c25ab4343098"),
                            CentralDistance = "15",
                            EstimatedTime = 2,
                            License = "2005",
                            WareName = "FedX"
                        },
                        new
                        {
                            WarehouseId = new Guid("a64608dc-8140-47f2-b886-e3948926ff1a"),
                            CentralDistance = "12",
                            EstimatedTime = 4,
                            License = "2014",
                            WareName = "AUPost"
                        });
                });

            modelBuilder.Entity("TradeSystemAPI.Models.orderWare", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("NewOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WarehouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("totalAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NewOrderId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("OrderWares");
                });

            modelBuilder.Entity("TradeSystemAPI.Models.NewOrder", b =>
                {
                    b.HasOne("TradeSystemAPI.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("TradeSystemAPI.Models.Order", b =>
                {
                    b.HasOne("TradeSystemAPI.Models.NewOrder", "NewOrder")
                        .WithMany()
                        .HasForeignKey("NewOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TradeSystemAPI.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NewOrder");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TradeSystemAPI.Models.orderWare", b =>
                {
                    b.HasOne("TradeSystemAPI.Models.NewOrder", "NewOrder")
                        .WithMany()
                        .HasForeignKey("NewOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TradeSystemAPI.Models.Warehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NewOrder");

                    b.Navigation("Warehouse");
                });
#pragma warning restore 612, 618
        }
    }
}
