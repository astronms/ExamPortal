using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class afterSessionEndpoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "0f6ade68-df54-4117-81e8-90b001d0f2b0", "c7c8486c-a721-4823-9421-09f6cc6cdad6", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "30e3211f-bdb2-41d6-86a5-44b33826e9f3", "26b96bc1-978c-47b9-a680-1e27b6e161ad", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6ade68-df54-4117-81e8-90b001d0f2b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30e3211f-bdb2-41d6-86a5-44b33826e9f3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6dbce592-bc8f-4ed4-8d73-b5b4daf4c11f", "08b077e8-bcd5-4177-b89d-7b789ff2836c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "793b46fd-263b-4691-bbc3-4d53c25a02d3", "62277999-2cc2-4fcf-aee7-83edf9ca68ba", "Administrator", "ADMINISTRATOR" });
        }
    }
}
