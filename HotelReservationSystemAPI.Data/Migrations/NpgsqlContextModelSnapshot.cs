﻿// <auto-generated />
using System;
using HotelReservationSystemAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HotelReservationSystemAPI.Data.Migrations
{
    [DbContext(typeof(NpgsqlContext))]
    partial class NpgsqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AdditionalFacilities");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.AdditionalFacilityOrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AdditionFacilityId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AdditionFacilityId");

                    b.HasIndex("OrderId");

                    b.ToTable("AdditionalFacilitiesInOrders");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.CityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.CountryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.FacilityCostEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AdditionalFacilityId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<int>("HotelId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AdditionalFacilityId");

                    b.HasIndex("HotelId");

                    b.ToTable("FacilityCosts");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.HotelEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.HotelPhotoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Extension")
                        .HasColumnType("text");

                    b.Property<int>("HotelId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelPhotos");
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
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
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

                    b.Property<DateTimeOffset?>("LastView")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("TypeId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.RoomPhotoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Extension")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RoomPhotos");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.RoomPhotoLinksEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("PhotoId")
                        .HasColumnType("integer");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomPhotoLinks");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.RoomTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<int>("HotelId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SeatsCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("RoomTypes");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.AdditionalFacilityOrderEntity", b =>
                {
                    b.HasOne("HotelReservationSystemAPI.Data.Models.AdditionalFacilityEntity", "AdditionalFacility")
                        .WithMany("FacilityOrders")
                        .HasForeignKey("AdditionFacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelReservationSystemAPI.Data.Models.OrderEntity", "Order")
                        .WithMany("AdditionalFacilities")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdditionalFacility");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.CityEntity", b =>
                {
                    b.HasOne("HotelReservationSystemAPI.Data.Models.CountryEntity", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.FacilityCostEntity", b =>
                {
                    b.HasOne("HotelReservationSystemAPI.Data.Models.AdditionalFacilityEntity", "AdditionalFacility")
                        .WithMany("FacilityCosts")
                        .HasForeignKey("AdditionalFacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelReservationSystemAPI.Data.Models.HotelEntity", "Hotel")
                        .WithMany("FacilitiesCosts")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdditionalFacility");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.HotelEntity", b =>
                {
                    b.HasOne("HotelReservationSystemAPI.Data.Models.CityEntity", "City")
                        .WithMany("Hotels")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelReservationSystemAPI.Data.Models.CountryEntity", "Country")
                        .WithMany("Hotels")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.HotelPhotoEntity", b =>
                {
                    b.HasOne("HotelReservationSystemAPI.Data.Models.HotelEntity", "Hotel")
                        .WithMany("Photos")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.OrderEntity", b =>
                {
                    b.HasOne("HotelReservationSystemAPI.Data.Models.PersonEntity", "Person")
                        .WithMany("Orders")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelReservationSystemAPI.Data.Models.RoomEntity", "Room")
                        .WithMany("Orders")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.PersonEntity", b =>
                {
                    b.HasOne("HotelReservationSystemAPI.Data.Models.RoleEntity", "Role")
                        .WithMany("Persons")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("HotelReservationSystemAPI.Data.Models.RefreshTokenEntity", "RefreshToken", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<DateTime>("Created")
                                .HasColumnType("timestamp without time zone");

                            b1.Property<DateTime>("Expires")
                                .HasColumnType("timestamp without time zone");

                            b1.Property<string>("Token")
                                .HasColumnType("text");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner("User")
                                .HasForeignKey("UserId");

                            b1.Navigation("User");
                        });

                    b.Navigation("RefreshToken");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.RoomEntity", b =>
                {
                    b.HasOne("HotelReservationSystemAPI.Data.Models.HotelEntity", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelReservationSystemAPI.Data.Models.RoomTypeEntity", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.RoomPhotoLinksEntity", b =>
                {
                    b.HasOne("HotelReservationSystemAPI.Data.Models.RoomPhotoEntity", "RoomPhoto")
                        .WithMany("RoomsLinks")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelReservationSystemAPI.Data.Models.RoomEntity", "Room")
                        .WithMany("PhotoLinks")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("RoomPhoto");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.RoomTypeEntity", b =>
                {
                    b.HasOne("HotelReservationSystemAPI.Data.Models.HotelEntity", "Hotel")
                        .WithMany("RoomTypes")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.AdditionalFacilityEntity", b =>
                {
                    b.Navigation("FacilityCosts");

                    b.Navigation("FacilityOrders");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.CityEntity", b =>
                {
                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.CountryEntity", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.HotelEntity", b =>
                {
                    b.Navigation("FacilitiesCosts");

                    b.Navigation("Photos");

                    b.Navigation("Rooms");

                    b.Navigation("RoomTypes");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.OrderEntity", b =>
                {
                    b.Navigation("AdditionalFacilities");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.PersonEntity", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.RoleEntity", b =>
                {
                    b.Navigation("Persons");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.RoomEntity", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("PhotoLinks");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.RoomPhotoEntity", b =>
                {
                    b.Navigation("RoomsLinks");
                });

            modelBuilder.Entity("HotelReservationSystemAPI.Data.Models.RoomTypeEntity", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
