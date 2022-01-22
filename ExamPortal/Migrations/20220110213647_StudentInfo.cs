using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class StudentInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d04ad9d-7a46-4038-a939-c753c2f1ed68");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adb2dfeb-28b1-44d5-a3a9-4044c14adfcb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4963cc85-1ba5-4b63-ae6b-28cb675af366", "c48842e6-61c4-4c50-b280-66f5e33322dc", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9cd6d2c0-1fa8-4963-be5b-e2169a443587", "c4d200dd-f1ff-47c6-8657-e9a19198d065", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4963cc85-1ba5-4b63-ae6b-28cb675af366");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9cd6d2c0-1fa8-4963-be5b-e2169a443587");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "adb2dfeb-28b1-44d5-a3a9-4044c14adfcb", "3051a284-d37c-4011-8890-31c12e74fbb6", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7d04ad9d-7a46-4038-a939-c753c2f1ed68", "2069433f-d5f1-424c-b136-fd7b8637fada", "Administrator", "ADMINISTRATOR" });
        }
    }
}
