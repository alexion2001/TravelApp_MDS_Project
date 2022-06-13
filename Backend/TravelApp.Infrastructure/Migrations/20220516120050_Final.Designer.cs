﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelApp.Infrastructure.Persistence.DbContexts.Travel;

namespace TravelApp.Infrastructure.Migrations
{
    [DbContext(typeof(TravelDbContext))]
    [Migration("20220516120050_Final")]
    partial class Final
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TravelApp.Domain.Entities.CazariUsers", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CazareId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "CazareId");

                    b.HasIndex("CazareId");

                    b.ToTable("CazariUsers");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IdentityRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdentityUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("IdentityRole");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IdentityUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LockoutEnd")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfFailLoginAttempts")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumberCountryPrefix")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("IdentityUser");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IdentityUserIdentityRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("IdentityUserIdentityRole");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IdentityUserToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsTokenRevoked")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshTokenValue")
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<string>("TokenValue")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("IdentityUserToken");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IdentityUserTokenConfirmation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConfirmationToken")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<byte>("ConfirmationTypeId")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRevoked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("IdentityUserTokenConfirmation");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IstoricCazari", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("buget")
                        .HasColumnType("int");

                    b.Property<DateTime>("data_plecare")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("data_venire")
                        .HasColumnType("datetime2");

                    b.Property<string>("numeLoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("oras")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IstoriceCazari");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IstoricZbor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("buget")
                        .HasColumnType("int");

                    b.Property<DateTime>("data_plecare")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("data_retur")
                        .HasColumnType("datetime2");

                    b.Property<string>("oras_plecare")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("oras_sosire")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IstoricZboruri");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.Recenzii", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Mesaj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oras")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RecenziiC");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.RecenziiUsers", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdMesaj")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataMesaj")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "IdMesaj");

                    b.HasIndex("IdMesaj");

                    b.ToTable("RecenziiUsers");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.ZboruriUsers", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ZborId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "ZborId");

                    b.HasIndex("ZborId");

                    b.ToTable("ZboruriUsers");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.CazariUsers", b =>
                {
                    b.HasOne("TravelApp.Domain.Entities.IstoricCazari", "IstoricCazari")
                        .WithMany("CazariUsers")
                        .HasForeignKey("CazareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelApp.Domain.Entities.IdentityUser", "IdentityUser")
                        .WithMany("CazariUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityUser");

                    b.Navigation("IstoricCazari");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IdentityRole", b =>
                {
                    b.HasOne("TravelApp.Domain.Entities.IdentityUser", null)
                        .WithMany("IdentityRoles")
                        .HasForeignKey("IdentityUserId");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IdentityUserIdentityRole", b =>
                {
                    b.HasOne("TravelApp.Domain.Entities.IdentityRole", "IdentityRole")
                        .WithMany("IdentityUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelApp.Domain.Entities.IdentityUser", "IdentityUser")
                        .WithMany("IdentityUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityRole");

                    b.Navigation("IdentityUser");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IdentityUserToken", b =>
                {
                    b.HasOne("TravelApp.Domain.Entities.IdentityUser", "User")
                        .WithMany("IdentityUserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IdentityUserTokenConfirmation", b =>
                {
                    b.HasOne("TravelApp.Domain.Entities.IdentityUser", "User")
                        .WithMany("IdentityUserTokenConfirmations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.RecenziiUsers", b =>
                {
                    b.HasOne("TravelApp.Domain.Entities.Recenzii", "Recenzii")
                        .WithMany("RecenziiUsers")
                        .HasForeignKey("IdMesaj")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelApp.Domain.Entities.IdentityUser", "IdentityUser")
                        .WithMany("RecenziiUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityUser");

                    b.Navigation("Recenzii");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.ZboruriUsers", b =>
                {
                    b.HasOne("TravelApp.Domain.Entities.IdentityUser", "IdentityUser")
                        .WithMany("ZboruriUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelApp.Domain.Entities.IstoricZbor", "IstoricZbor")
                        .WithMany("ZboruriUsers")
                        .HasForeignKey("ZborId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityUser");

                    b.Navigation("IstoricZbor");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IdentityRole", b =>
                {
                    b.Navigation("IdentityUserRoles");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IdentityUser", b =>
                {
                    b.Navigation("CazariUsers");

                    b.Navigation("IdentityRoles");

                    b.Navigation("IdentityUserRoles");

                    b.Navigation("IdentityUserTokenConfirmations");

                    b.Navigation("IdentityUserTokens");

                    b.Navigation("RecenziiUsers");

                    b.Navigation("ZboruriUsers");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IstoricCazari", b =>
                {
                    b.Navigation("CazariUsers");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IstoricZbor", b =>
                {
                    b.Navigation("ZboruriUsers");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.Recenzii", b =>
                {
                    b.Navigation("RecenziiUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
