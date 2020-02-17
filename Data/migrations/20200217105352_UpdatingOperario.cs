using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiASPLinux.Data.migrations
{
    public partial class UpdatingOperario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Operarios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Operarios");
        }
    }
}
