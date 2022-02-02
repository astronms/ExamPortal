using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class XmlNodesToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "3a9ab08a-9721-4af2-ad57-e6465a67f154", "28fa3323-452d-4397-bcd1-0c8a0da9579c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5893ecc2-f090-4b30-bde1-85788c4fa5be", "6f42bc30-a45e-4db9-bec8-727c7041191a", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a9ab08a-9721-4af2-ad57-e6465a67f154");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5893ecc2-f090-4b30-bde1-85788c4fa5be");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ca6868e8-5d65-4289-91ab-26883b52d37d", "52d9d002-4972-42bc-98c1-a8cba36ca921", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c272d34-72f0-43d8-bf7d-f49295c8a693", "04aaaeb7-1253-4b9f-9437-5d3fe24753ca", "Administrator", "ADMINISTRATOR" });
        }
    }
}
