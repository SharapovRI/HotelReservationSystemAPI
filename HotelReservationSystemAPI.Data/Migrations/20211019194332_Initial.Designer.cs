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
    [Migration("20211019194332_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.AdditionalFacility", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("additional_services");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.AdditionalServicesInOrder", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("addition_service_id")
                        .HasColumnType("integer");

                    b.Property<int>("order_id")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("addition_service_id");

                    b.HasIndex("order_id");

                    b.ToTable("additional_services_in_orders");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.CostOfRooms", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("cost")
                        .HasColumnType("numeric");

                    b.Property<int>("hotel_id")
                        .HasColumnType("integer");

                    b.Property<int>("type_id")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("hotel_id");

                    b.HasIndex("type_id");

                    b.ToTable("cost_of_rooms");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.CostsOfServices", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("additional_services_id")
                        .HasColumnType("integer");

                    b.Property<decimal>("cost")
                        .HasColumnType("numeric");

                    b.Property<int>("hotel_id")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("additional_services_id");

                    b.HasIndex("hotel_id");

                    b.ToTable("costs_of_services");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.Hotel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("address")
                        .HasColumnType("text");

                    b.Property<string>("city")
                        .HasColumnType("text");

                    b.Property<string>("country")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("hotels");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTimeOffset>("check_in_time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("check_out_time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("cost")
                        .HasColumnType("numeric");

                    b.Property<int>("room_id")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("room_id");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.Person", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("login")
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .HasColumnType("text");

                    b.Property<int>("role_id")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("role_id");

                    b.ToTable("persons");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.Role", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.RoomEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("hotel_id")
                        .HasColumnType("integer");

                    b.Property<int>("type_id")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("hotel_id");

                    b.HasIndex("type_id");

                    b.ToTable("rooms");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.TypesOfRooms", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("amount_of_seats")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("types_of_rooms");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.AdditionalServicesInOrder", b =>
                {
                    b.HasOne("HotelReservationSystemAPI.Data.Models.AdditionalFacility", "AdditionalFacility")
                        .WithMany()
                        .HasForeignKey("addition_service_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelReservationSystemAPI.Data.Models.Order", "Order")
                        .WithMany("AdditionalFacilities")
                        .HasForeignKey("order_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdditionalFacility");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.CostOfRooms", b =>
                {
                    b.HasOne("HotelReservationSystemAPI.Data.Models.Hotel", "Hotel")
                        .WithMany("CostsOfRooms")
                        .HasForeignKey("hotel_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelReservationSystemAPI.Data.Models.TypesOfRooms", "TypeOfRooms")
                        .WithMany("CostsOfRooms")
                        .HasForeignKey("type_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("TypeOfRooms");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.CostsOfServices", b =>
                {
                    b.HasOne("HotelReservationSystemAPI.Data.Models.AdditionalFacility", "AdditionalFacility")
                        .WithMany("CostsOfService")
                        .HasForeignKey("additional_services_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelReservationSystemAPI.Data.Models.Hotel", "Hotel")
                        .WithMany("CostsOfServices")
                        .HasForeignKey("hotel_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdditionalFacility");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.Order", b =>
                {
                    b.HasOne("HotelReservationSystemAPI.Data.Models.RoomEntity", "RoomEntity")
                        .WithMany()
                        .HasForeignKey("room_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomEntity");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.Person", b =>
                {
                    b.HasOne("HotelReservationSystemAPI.Data.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.RoomEntity", b =>
                {
                    b.HasOne("HotelReservationSystemAPI.Data.Models.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("hotel_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelReservationSystemAPI.Data.Models.TypesOfRooms", "TypeOfRooms")
                        .WithMany("Rooms")
                        .HasForeignKey("type_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("TypeOfRooms");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.AdditionalFacility", b =>
                {
                    b.Navigation("CostsOfService");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.Hotel", b =>
                {
                    b.Navigation("CostsOfRooms");

                    b.Navigation("CostsOfServices");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.Order", b =>
                {
                    b.Navigation("AdditionalFacilities");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.TypesOfRooms", b =>
                {
                    b.Navigation("CostsOfRooms");

                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
