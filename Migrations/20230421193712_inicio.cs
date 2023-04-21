using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AR_Ejercicio2Tablas.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Burguer",
                columns: table => new
                {
                    BurguerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WithCheese = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burguer", x => x.BurguerId);
                });

            migrationBuilder.CreateTable(
                name: "Promo",
                columns: table => new
                {
                    PromoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromoType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaPromo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BurguerId = table.Column<int>(type: "int", nullable: false),
                    PromoId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promo", x => x.PromoId);
                    table.ForeignKey(
                        name: "FK_Promo_Burguer_BurguerId",
                        column: x => x.BurguerId,
                        principalTable: "Burguer",
                        principalColumn: "BurguerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Promo_Promo_PromoId1",
                        column: x => x.PromoId1,
                        principalTable: "Promo",
                        principalColumn: "PromoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Promo_BurguerId",
                table: "Promo",
                column: "BurguerId");

            migrationBuilder.CreateIndex(
                name: "IX_Promo_PromoId1",
                table: "Promo",
                column: "PromoId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promo");

            migrationBuilder.DropTable(
                name: "Burguer");
        }
    }
}
