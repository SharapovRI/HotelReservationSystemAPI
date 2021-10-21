﻿// <auto-generated />
using System;
using HotelReservationSystemAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HotelReservationSystemAPI.Data.Migrations
{
    [DbContext(typeof(NpgsqlContext))]
    [Migration("20211020142150_AdjustmentToModelNames_2")]
    partial class AdjustmentToModelNames_2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.AdditionalFacilityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AdditionalServices");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.AdditionalFacilityOrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AdditionServiceId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AdditionServiceId");

                    b.HasIndex("OrderId");

                    b.ToTable("AdditionalServicesInOrders");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.HotelEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.OrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTimeOffset>("CheckInTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("CheckOutTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<int>("PersonId")
                        .HasColumnType("integer");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("RoomId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.PersonEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.RoomEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("HotelId")
                        .HasColumnType("integer");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("TypeId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.RoomTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("SeatsCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("TypesOfRooms");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.RoomsCostEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<int>("HotelId")
                        .HasColumnType("integer");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("TypeId");

                    b.ToTable("CostOfRoomsfRooms");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.ServiceCostEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AdditionalServicesId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<int>("HotelId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AdditionalServicesId");

                    b.HasIndex("HotelId");

                    b.ToTable("CostsOfServices");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.AdditionalFacilityOrderEntity", b =>
                {
                    b.HasOne("HotelReservationSystemAPI.Data.Models.AdditionalFacilityEntity", "AdditionalFacility")
                        .WithMany()
                        .HasForeignKey("AdditionServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelReservationSystemAPI.Data.Models.OrderEntity", "Order")
                        .WithMany("AdditionalServices")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdditionalFacility");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.OrderEntity", b =>
                {
                    b.HasOne("HotelReservationSystemAPI.Data.Models.PersonEntity", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelReservationSystemAPI.Data.Models.RoomEntity", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.PersonEntity", b =>
                {
                    b.HasOne("HotelReservationSystemAPI.Data.Models.RoleEntity", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.RoomEntity", b =>
                {
                    b.HasOne("HotelReservationSystemAPI.Data.Models.HotelEntity", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelReservationSystemAPI.Data.Models.RoomTypeEntity", "RoomTypes")
                        .WithMany("Rooms")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("RoomTypes");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.RoomsCostEntity", b =>
                {
                    b.HasOne("HotelReservationSystemAPI.Data.Models.HotelEntity", "Hotel")
                        .WithMany("RoomsCosts")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelReservationSystemAPI.Data.Models.RoomTypeEntity", "RoomTypes")
                        .WithMany("RoomsCosts")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("RoomTypes");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.ServiceCostEntity", b =>
                {
                    b.HasOne("HotelReservationSystemAPI.Data.Models.AdditionalFacilityEntity", "AdditionalFacility")
                        .WithMany("ServiceCosts")
                        .HasForeignKey("AdditionalServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelReservationSystemAPI.Data.Models.HotelEntity", "Hotel")
                        .WithMany("ServiceCosts")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdditionalFacility");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.AdditionalFacilityEntity", b =>
                {
                    b.Navigation("ServiceCosts");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.HotelEntity", b =>
                {
                    b.Navigation("Rooms");

                    b.Navigation("RoomsCosts");

                    b.Navigation("ServiceCosts");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.OrderEntity", b =>
                {
                    b.Navigation("AdditionalServices");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.RoomTypeEntity", b =>
                {
                    b.Navigation("Rooms");

                    b.Navigation("RoomsCosts");
                });
#pragma warning restore 612, 618
        }
    }
}
