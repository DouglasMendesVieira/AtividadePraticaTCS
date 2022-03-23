using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtividadePraticaTCS.Migrations
{
    public partial class EntitiesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machine_StatusEvent_StatusEventId",
                table: "Machine");

            migrationBuilder.DropForeignKey(
                name: "FK_Machine_Status_StatusId",
                table: "Machine");

            migrationBuilder.DropIndex(
                name: "IX_Machine_StatusEventId",
                table: "Machine");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "StatusEvent");

            migrationBuilder.DropColumn(
                name: "StatusEventId",
                table: "Machine");

            migrationBuilder.RenameColumn(
                name: "StatusCode",
                table: "StatusEvent",
                newName: "IdStatus");

            migrationBuilder.AddColumn<int>(
                name: "IdMaquina",
                table: "StatusEvent",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Status",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Machine",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Machine",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Machine_Status_StatusId",
                table: "Machine",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machine_Status_StatusId",
                table: "Machine");

            migrationBuilder.DropColumn(
                name: "IdMaquina",
                table: "StatusEvent");

            migrationBuilder.RenameColumn(
                name: "IdStatus",
                table: "StatusEvent",
                newName: "StatusCode");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "StatusEvent",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Status",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Machine",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Machine",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60);

            migrationBuilder.AddColumn<int>(
                name: "StatusEventId",
                table: "Machine",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Machine_StatusEventId",
                table: "Machine",
                column: "StatusEventId");

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
    }
}
