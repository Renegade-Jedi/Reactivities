using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class RealizationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photos",
                table: "Realizations");

            migrationBuilder.CreateIndex(
                name: "IX_RealizationPhotos_RealizationId",
                table: "RealizationPhotos",
                column: "RealizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealizationPhotos_Realizations_RealizationId",
                table: "RealizationPhotos",
                column: "RealizationId",
                principalTable: "Realizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealizationPhotos_Realizations_RealizationId",
                table: "RealizationPhotos");

            migrationBuilder.DropIndex(
                name: "IX_RealizationPhotos_RealizationId",
                table: "RealizationPhotos");

            migrationBuilder.AddColumn<List<string>>(
                name: "Photos",
                table: "Realizations",
                type: "text[]",
                nullable: true);
        }
    }
}
