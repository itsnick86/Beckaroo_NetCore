using Microsoft.EntityFrameworkCore.Migrations;

namespace Beckaroo_NetCore.Migrations
{
    public partial class AdminModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Admin",
                newName: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Admin",
                newName: "UserName");
        }
    }
}
