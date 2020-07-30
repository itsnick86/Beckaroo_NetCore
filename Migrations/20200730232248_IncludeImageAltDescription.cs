using Microsoft.EntityFrameworkCore.Migrations;

namespace Beckaroo_NetCore.Migrations
{
    public partial class IncludeImageAltDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageAlt",
                table: "Blog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageMainAlt",
                table: "Animal",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageSecondaryAlt",
                table: "Animal",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageAlt",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "ImageMainAlt",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "ImageSecondaryAlt",
                table: "Animal");
        }
    }
}
