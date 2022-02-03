using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class ImprovmentsInSessionTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Courses_SessionId",
                table: "Sessions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c3d8065-1e38-4920-aaf8-199d3a548f21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e494b84d-0587-4b1a-a38b-d77a7ad8f899");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ccdc46e3-7d5b-4514-8494-3f73dd8edcf6", "875e9c17-6ba5-42ab-acb0-e484b9d22062", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64b28e24-49d0-4074-8792-f8aa825b469e", "4c8bcbd8-6ad9-4f50-b502-13fa1d3bacff", "Administrator", "ADMINISTRATOR" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: "64b28e24-49d0-4074-8792-f8aa825b469e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ccdc46e3-7d5b-4514-8494-3f73dd8edcf6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8c3d8065-1e38-4920-aaf8-199d3a548f21", "d20848bb-2fa0-4af0-a355-f76460e980c1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e494b84d-0587-4b1a-a38b-d77a7ad8f899", "9e27d093-93ed-46b2-b0a7-db83693cfe96", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Courses_SessionId",
                table: "Sessions",
                column: "SessionId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
