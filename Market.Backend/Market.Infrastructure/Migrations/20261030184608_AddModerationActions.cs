using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddModerationActions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModerationActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminUserId = table.Column<int>(type: "int", nullable: false),
                    TargetUserId = table.Column<int>(type: "int", nullable: false),
                    ActionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModerationActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModerationActions_Users_AdminUserId",
                        column: x => x.AdminUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ModerationActions_Users_TargetUserId",
                        column: x => x.TargetUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 10, 30, 18, 46, 7, 775, DateTimeKind.Utc).AddTicks(1091));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 10, 30, 18, 46, 7, 775, DateTimeKind.Utc).AddTicks(1101));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 10, 30, 18, 46, 7, 775, DateTimeKind.Utc).AddTicks(1107));

            migrationBuilder.CreateIndex(
                name: "IX_ModerationActions_AdminUserId",
                table: "ModerationActions",
                column: "AdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ModerationActions_TargetUserId",
                table: "ModerationActions",
                column: "TargetUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModerationActions");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 1, 15, 18, 36, 874, DateTimeKind.Utc).AddTicks(9216));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 1, 15, 18, 36, 874, DateTimeKind.Utc).AddTicks(9222));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 1, 15, 18, 36, 874, DateTimeKind.Utc).AddTicks(9224));
        }
    }
}
