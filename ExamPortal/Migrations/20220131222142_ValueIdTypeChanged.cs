using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class ValueIdTypeChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "6dbce592-bc8f-4ed4-8d73-b5b4daf4c11f", "08b077e8-bcd5-4177-b89d-7b789ff2836c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "793b46fd-263b-4691-bbc3-4d53c25a02d3", "62277999-2cc2-4fcf-aee7-83edf9ca68ba", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6dbce592-bc8f-4ed4-8d73-b5b4daf4c11f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "793b46fd-263b-4691-bbc3-4d53c25a02d3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3a9ab08a-9721-4af2-ad57-e6465a67f154", "28fa3323-452d-4397-bcd1-0c8a0da9579c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5893ecc2-f090-4b30-bde1-85788c4fa5be", "6f42bc30-a45e-4db9-bec8-727c7041191a", "Administrator", "ADMINISTRATOR" });
        }
    }
}
