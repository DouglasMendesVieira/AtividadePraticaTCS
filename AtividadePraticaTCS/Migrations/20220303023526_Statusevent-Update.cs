using Microsoft.EntityFrameworkCore.Migrations;

namespace AtividadePraticaTCS.Migrations
{
    public partial class StatuseventUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatusEvent_Machine_MachineId",
                table: "StatusEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusEvent_Status_StatusId",
                table: "StatusEvent");

            migrationBuilder.DropIndex(
                name: "IX_StatusEvent_MachineId",
                table: "StatusEvent");

            migrationBuilder.DropIndex(
                name: "IX_StatusEvent_StatusId",
                table: "StatusEvent");

            migrationBuilder.DropColumn(
                name: "MachineId",
                table: "StatusEvent");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "StatusEvent",
                newName: "CodeStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CodeStatus",
                table: "StatusEvent",
                newName: "StatusId");

            migrationBuilder.AddColumn<int>(
                name: "MachineId",
                table: "StatusEvent",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StatusEvent_MachineId",
                table: "StatusEvent",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusEvent_StatusId",
                table: "StatusEvent",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusEvent_Machine_MachineId",
                table: "StatusEvent",
                column: "MachineId",
                principalTable: "Machine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatusEvent_Status_StatusId",
                table: "StatusEvent",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
