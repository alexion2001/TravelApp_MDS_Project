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
    [Migration("20220509012850_Final")]
    partial class Final
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.ToTable("IstoricCazari");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IstoricCazariUser", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Cazareid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "Cazareid");

                    b.HasIndex("Cazareid");

                    b.ToTable("IstoricCazariUser");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IstoricVacante", b =>
                {
                    b.Property<Guid>("VacantaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Cazareid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ZborId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("VacantaId");

                    b.ToTable("IstoricVacante");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IstoricVacanteUser", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Vacantaid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "Vacantaid");

                    b.HasIndex("Vacantaid");

                    b.ToTable("IstoricVacanteUser");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IstoricZbor", b =>
                {
                    b.Property<Guid>("Id")
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

                    b.ToTable("IstoricZbor");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IstoricZborUser", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ZborId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "ZborId");

                    b.HasIndex("ZborId");

                    b.ToTable("IstoricZborUser");
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

            modelBuilder.Entity("TravelApp.Domain.Entities.IstoricCazari", b =>
                {
                    b.HasOne("TravelApp.Domain.Entities.IstoricVacante", "IstoricVacanta")
                        .WithOne("IstoricCazari")
                        .HasForeignKey("TravelApp.Domain.Entities.IstoricCazari", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IstoricVacanta");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IstoricCazariUser", b =>
                {
                    b.HasOne("TravelApp.Domain.Entities.IstoricCazari", "IstoricCazari")
                        .WithMany("IstoricCazariUsers")
                        .HasForeignKey("Cazareid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelApp.Domain.Entities.IdentityUser", "IdentityUser")
                        .WithMany("IstoricCazariUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityUser");

                    b.Navigation("IstoricCazari");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IstoricVacanteUser", b =>
                {
                    b.HasOne("TravelApp.Domain.Entities.IdentityUser", "IdentityUser")
                        .WithMany("IstoricVacanteUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelApp.Domain.Entities.IstoricVacante", "IstoricVacante")
                        .WithMany("IstoricVacanteUsers")
                        .HasForeignKey("Vacantaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityUser");

                    b.Navigation("IstoricVacante");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IstoricZbor", b =>
                {
                    b.HasOne("TravelApp.Domain.Entities.IstoricVacante", "IstoricVacante")
                        .WithOne("IstoricZbor")
                        .HasForeignKey("TravelApp.Domain.Entities.IstoricZbor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IstoricVacante");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IstoricZborUser", b =>
                {
                    b.HasOne("TravelApp.Domain.Entities.IdentityUser", "IdentityUser")
                        .WithMany("IstoricZborUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelApp.Domain.Entities.IstoricZbor", "IstoricZbor")
                        .WithMany("IstoricZborUsers")
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
                    b.Navigation("IdentityRoles");

                    b.Navigation("IdentityUserRoles");

                    b.Navigation("IdentityUserTokenConfirmations");

                    b.Navigation("IdentityUserTokens");

                    b.Navigation("IstoricCazariUsers");

                    b.Navigation("IstoricVacanteUsers");

                    b.Navigation("IstoricZborUsers");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IstoricCazari", b =>
                {
                    b.Navigation("IstoricCazariUsers");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IstoricVacante", b =>
                {
                    b.Navigation("IstoricCazari");

                    b.Navigation("IstoricVacanteUsers");

                    b.Navigation("IstoricZbor");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.IstoricZbor", b =>
                {
                    b.Navigation("IstoricZborUsers");
                });
#pragma warning restore 612, 618
        }
    }
}