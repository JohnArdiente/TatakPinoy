﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TatakPinoy.Data;

namespace TatakPinoy.Migrations
{
    [DbContext(typeof(TatakPinoyContext))]
    partial class TatakPinoyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TatakPinoy.Models.Consignee", b =>
                {
                    b.Property<int>("ConsigneeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AgentsName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConsigneesAddr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConsigneesName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConsigneesNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("PickupDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<string>("ShipersName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShipersNo")
                        .HasColumnType("int");

                    b.Property<int?>("ShipmentId")
                        .HasColumnType("int");

                    b.Property<string>("TrackingNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConsigneeId");

                    b.HasIndex("ShipmentId");

                    b.ToTable("Consignee");
                });

            modelBuilder.Entity("TatakPinoy.Models.Shipment", b =>
                {
                    b.Property<int>("ShipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ShipmentNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("ShipmentId");

                    b.HasIndex("StatusId")
                        .IsUnique()
                        .HasFilter("[StatusId] IS NOT NULL");

                    b.ToTable("Shipment");
                });

            modelBuilder.Entity("TatakPinoy.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusDesc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("TatakPinoy.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserModels");
                });

            modelBuilder.Entity("TatakPinoy.Models.Consignee", b =>
                {
                    b.HasOne("TatakPinoy.Models.Shipment", "Shipment")
                        .WithMany("Consignees")
                        .HasForeignKey("ShipmentId");
                });

            modelBuilder.Entity("TatakPinoy.Models.Shipment", b =>
                {
                    b.HasOne("TatakPinoy.Models.Status", "Status")
                        .WithOne("Shipment")
                        .HasForeignKey("TatakPinoy.Models.Shipment", "StatusId");
                });
#pragma warning restore 612, 618
        }
    }
}
