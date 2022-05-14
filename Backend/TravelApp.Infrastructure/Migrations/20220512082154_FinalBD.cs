using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelApp.Infrastructure.Migrations
{
    public partial class FinalBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneNumberCountryPrefix = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfFailLoginAttempts = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IstoricVacante",
                columns: table => new
                {
                    VacantaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZborId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cazariid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IstoricVacante", x => x.VacantaId);
                });

            migrationBuilder.CreateTable(
                name: "RecenziiC",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Oras = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mesaj = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecenziiC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdentityUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityRole_IdentityUser_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TokenValue = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    RefreshTokenValue = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTokenRevoked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityUserToken_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserTokenConfirmation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConfirmationTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    ConfirmationToken = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserTokenConfirmation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityUserTokenConfirmation_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IstoricCazari",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    data_venire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_plecare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    oras = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeLoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    buget = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IstoricCazari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IstoricCazari_IdentityUser_IdUser",
                        column: x => x.IdUser,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IstoricCazari_IstoricVacante_Id",
                        column: x => x.Id,
                        principalTable: "IstoricVacante",
                        principalColumn: "VacantaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IstoricVacanteUser",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Vacantaid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IstoricVacanteUser", x => new { x.UserId, x.Vacantaid });
                    table.ForeignKey(
                        name: "FK_IstoricVacanteUser_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IstoricVacanteUser_IstoricVacante_Vacantaid",
                        column: x => x.Vacantaid,
                        principalTable: "IstoricVacante",
                        principalColumn: "VacantaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IstoricZbor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    data_plecare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_retur = table.Column<DateTime>(type: "datetime2", nullable: false),
                    oras_plecare = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    oras_sosire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    buget = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IstoricZbor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IstoricZbor_IdentityUser_IdUser",
                        column: x => x.IdUser,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IstoricZbor_IstoricVacante_Id",
                        column: x => x.Id,
                        principalTable: "IstoricVacante",
                        principalColumn: "VacantaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecenziiUsers",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMesaj = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataMesaj = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecenziiUsers", x => new { x.UserId, x.IdMesaj });
                    table.ForeignKey(
                        name: "FK_RecenziiUsers_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecenziiUsers_RecenziiC_IdMesaj",
                        column: x => x.IdMesaj,
                        principalTable: "RecenziiC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserIdentityRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserIdentityRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_IdentityUserIdentityRole_IdentityRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "IdentityRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityUserIdentityRole_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityRole_IdentityUserId",
                table: "IdentityRole",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserIdentityRole_RoleId",
                table: "IdentityUserIdentityRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserToken_UserId",
                table: "IdentityUserToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserTokenConfirmation_UserId",
                table: "IdentityUserTokenConfirmation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IstoricCazari_IdUser",
                table: "IstoricCazari",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_IstoricVacanteUser_Vacantaid",
                table: "IstoricVacanteUser",
                column: "Vacantaid");

            migrationBuilder.CreateIndex(
                name: "IX_IstoricZbor_IdUser",
                table: "IstoricZbor",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_RecenziiUsers_IdMesaj",
                table: "RecenziiUsers",
                column: "IdMesaj");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUserIdentityRole");

            migrationBuilder.DropTable(
                name: "IdentityUserToken");

            migrationBuilder.DropTable(
                name: "IdentityUserTokenConfirmation");

            migrationBuilder.DropTable(
                name: "IstoricCazari");

            migrationBuilder.DropTable(
                name: "IstoricVacanteUser");

            migrationBuilder.DropTable(
                name: "IstoricZbor");

            migrationBuilder.DropTable(
                name: "RecenziiUsers");

            migrationBuilder.DropTable(
                name: "IdentityRole");

            migrationBuilder.DropTable(
                name: "IstoricVacante");

            migrationBuilder.DropTable(
                name: "RecenziiC");

            migrationBuilder.DropTable(
                name: "IdentityUser");
        }
    }
}
