using Microsoft.EntityFrameworkCore.Migrations;

namespace AtividadePraticaTCS.Migrations
{
    public partial class updatecode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Status",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "Status",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
