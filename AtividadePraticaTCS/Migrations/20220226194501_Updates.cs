using Microsoft.EntityFrameworkCore.Migrations;

namespace AtividadePraticaTCS.Migrations
{
    public partial class Updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machine_Status_StatusId",
                table: "Machine");

            migrationBuilder.DropColumn(
                name: "IdMaquina",
                table: "StatusEvent");

            migrationBuilder.DropColumn(
                name: "IdStatus",
                table: "StatusEvent");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Machine",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Machine_Status_StatusId",
                table: "Machine",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machine_Status_StatusId",
                table: "Machine");

            migrationBuilder.AddColumn<int>(
                name: "IdMaquina",
                table: "StatusEvent",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdStatus",
                table: "StatusEvent",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Machine",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Machine_Status_StatusId",
                table: "Machine",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
