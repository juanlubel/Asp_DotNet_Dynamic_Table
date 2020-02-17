using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiASPLinux.Data.migrations
{
    public partial class RemoveApellidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "Operarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "Operarios",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
