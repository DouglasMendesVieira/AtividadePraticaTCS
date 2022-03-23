using Microsoft.EntityFrameworkCore.Migrations;

namespace AtividadePraticaTCS.Migrations
{
    public partial class StatusForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machine_StatusEvent_StatusEventId",
                table: "Machine");

            migrationBuilder.DropForeignKey(
                name: "FK_Machine_Status_StatusId",
                table: "Machine");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Machine",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusEventId",
                table: "Machine",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Machine_StatusEvent_StatusEventId",
                table: "Machine",
                column: "StatusEventId",
                principalTable: "StatusEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Machine_StatusEvent_StatusEventId",
                table: "Machine");

            migrationBuilder.DropForeignKey(
                name: "FK_Machine_Status_StatusId",
                table: "Machine");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Machine",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "StatusEventId",
                table: "Machine",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Machine_StatusEvent_StatusEventId",
                table: "Machine",
                column: "StatusEventId",
                principalTable: "StatusEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
