using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelApp.Infrastructure.Migrations
{
    public partial class Recenzii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "RecenziiUsers",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMesaj = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_RecenziiUsers_IdMesaj",
                table: "RecenziiUsers",
                column: "IdMesaj");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecenziiUsers");

            migrationBuilder.DropTable(
                name: "RecenziiC");
        }
    }
}
