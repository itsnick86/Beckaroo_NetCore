using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beckaroo_NetCore.Migrations
{
    public partial class ModelUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Animal",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Species",
                table: "Animal",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "Species",
                table: "Animal");
        }
    }
}
