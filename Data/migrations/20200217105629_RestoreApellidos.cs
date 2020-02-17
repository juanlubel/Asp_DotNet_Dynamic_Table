using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiASPLinux.Data.migrations
{
    public partial class RestoreApellidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "Operarios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "Operarios");
        }
    }
}
