﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Moviy.Data.Context;

#nullable disable

namespace Moviy.Data.Migrations
{
    [DbContext(typeof(MoviyDbContext))]
    partial class MoviyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Moviy.Business.Models.Bus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ActivatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("BusColor")
                        .HasColumnType("int");

                    b.Property<int>("BusNumber")
                        .HasColumnType("int");

                    b.Property<int>("BusSize")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeactivatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("varchar(7)");

                    b.HasKey("Id");

                    b.ToTable("Buses", (string)null);
                });

            modelBuilder.Entity("Moviy.Business.Models.Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ActivatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DeactivatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("DriverLicense")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Drivers", (string)null);
                });

            modelBuilder.Entity("Moviy.Business.Models.LineRoute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ActivatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeactivatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EndPointId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Line")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("LinePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("StartPointId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EndPointId");

                    b.HasIndex("StartPointId");

                    b.ToTable("LineRoutes", (string)null);
                });

            modelBuilder.Entity("Moviy.Business.Models.Local", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Locals", (string)null);
                });

            modelBuilder.Entity("Moviy.Business.Models.Travel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DriverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("FinishedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LineRouteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BusId");

                    b.HasIndex("DriverId");

                    b.HasIndex("LineRouteId");

                    b.ToTable("Travels", (string)null);
                });

            modelBuilder.Entity("Moviy.Business.Models.LineRoute", b =>
                {
                    b.HasOne("Moviy.Business.Models.Local", "EndPoint")
                        .WithMany("EndPoints")
                        .HasForeignKey("EndPointId")
                        .IsRequired();

                    b.HasOne("Moviy.Business.Models.Local", "StartPoint")
                        .WithMany("StartPoints")
                        .HasForeignKey("StartPointId")
                        .IsRequired();

                    b.Navigation("EndPoint");

                    b.Navigation("StartPoint");
                });

            modelBuilder.Entity("Moviy.Business.Models.Travel", b =>
                {
                    b.HasOne("Moviy.Business.Models.Bus", "Bus")
                        .WithMany("Travels")
                        .HasForeignKey("BusId")
                        .IsRequired();

                    b.HasOne("Moviy.Business.Models.Driver", "Driver")
                        .WithMany("Travels")
                        .HasForeignKey("DriverId")
                        .IsRequired();

                    b.HasOne("Moviy.Business.Models.LineRoute", "LineRoute")
                        .WithMany("Travels")
                        .HasForeignKey("LineRouteId")
                        .IsRequired();

                    b.Navigation("Bus");

                    b.Navigation("Driver");

                    b.Navigation("LineRoute");
                });

            modelBuilder.Entity("Moviy.Business.Models.Bus", b =>
                {
                    b.Navigation("Travels");
                });

            modelBuilder.Entity("Moviy.Business.Models.Driver", b =>
                {
                    b.Navigation("Travels");
                });

            modelBuilder.Entity("Moviy.Business.Models.LineRoute", b =>
                {
                    b.Navigation("Travels");
                });

            modelBuilder.Entity("Moviy.Business.Models.Local", b =>
                {
                    b.Navigation("EndPoints");

                    b.Navigation("StartPoints");
                });
#pragma warning restore 612, 618
        }
    }
}
