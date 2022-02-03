using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class ImprovmentsInSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Courses_CourseId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_CourseId",
                table: "Sessions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6ade68-df54-4117-81e8-90b001d0f2b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30e3211f-bdb2-41d6-86a5-44b33826e9f3");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Sessions");

            migrationBuilder.CreateTable(
                name: "CourseSession",
                columns: table => new
                {
                    CourseSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSession", x => x.CourseSessionId);
                    table.ForeignKey(
                        name: "FK_CourseSession_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSession_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bacef949-7c38-426b-9bdb-f7eb7b15ff00", "f6c6b090-0df7-4a33-b678-c1ff35e20df7", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "650fd4a5-347c-4d18-b6a0-78863d1c0d7c", "82f52cf1-ad8a-4cf6-9f09-b902fc75b655", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSession_CourseId",
                table: "CourseSession",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSession_SessionId",
                table: "CourseSession",
                column: "SessionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSession");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "650fd4a5-347c-4d18-b6a0-78863d1c0d7c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bacef949-7c38-426b-9bdb-f7eb7b15ff00");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Sessions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0f6ade68-df54-4117-81e8-90b001d0f2b0", "c7c8486c-a721-4823-9421-09f6cc6cdad6", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "30e3211f-bdb2-41d6-86a5-44b33826e9f3", "26b96bc1-978c-47b9-a680-1e27b6e161ad", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_CourseId",
                table: "Sessions",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Courses_CourseId",
                table: "Sessions",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
