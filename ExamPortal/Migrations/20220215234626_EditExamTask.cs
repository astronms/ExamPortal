using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class EditExamTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Question_TaskId",
                table: "Question");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad4cdb52-882e-443d-b9b6-145651c86e17");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dde4b825-855f-4e95-8528-4ae2cfb92f3c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8759a09c-b945-44b6-9fbc-9c325b50ee47", "0fa12e78-9a6e-44b2-bda9-53783eecf79d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dcdc7f84-91db-41b0-98d9-df36aff61359", "bcd1be33-ee02-41d3-8759-d4d8ed87ff52", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Question_TaskId",
                table: "Question",
                column: "TaskId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Question_TaskId",
                table: "Question");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8759a09c-b945-44b6-9fbc-9c325b50ee47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcdc7f84-91db-41b0-98d9-df36aff61359");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dde4b825-855f-4e95-8528-4ae2cfb92f3c", "f469fafe-29db-465f-9cec-4e8af74dd0da", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad4cdb52-882e-443d-b9b6-145651c86e17", "77b614c0-0207-4ae2-9d6b-d655de572c37", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Question_TaskId",
                table: "Question",
                column: "TaskId");
        }
    }
}
