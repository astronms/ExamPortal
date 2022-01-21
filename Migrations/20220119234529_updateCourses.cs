using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class updateCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfa8c9d4-5609-4d6b-bc2f-9cba1df458d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2f3f3f8-26c6-41b2-ba37-f5bab5bcb673");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ca6868e8-5d65-4289-91ab-26883b52d37d", "52d9d002-4972-42bc-98c1-a8cba36ca921", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c272d34-72f0-43d8-bf7d-f49295c8a693", "04aaaeb7-1253-4b9f-9437-5d3fe24753ca", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c272d34-72f0-43d8-bf7d-f49295c8a693");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca6868e8-5d65-4289-91ab-26883b52d37d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bfa8c9d4-5609-4d6b-bc2f-9cba1df458d6", "0d6bbb9d-32be-4e99-90c0-6c2497922939", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c2f3f3f8-26c6-41b2-ba37-f5bab5bcb673", "28d5d0eb-04fd-49f9-97b9-569b8589842b", "Administrator", "ADMINISTRATOR" });
        }
    }
}
