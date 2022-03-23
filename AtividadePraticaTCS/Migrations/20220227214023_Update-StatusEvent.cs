using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtividadePraticaTCS.Migrations
{
    public partial class UpdateStatusEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "StatusEvent",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MachineId",
                table: "StatusEvent",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Date",
                table: "StatusEvent");

            migrationBuilder.DropColumn(
                name: "MachineId",
                table: "StatusEvent");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "StatusEvent");
        }
    }
}
