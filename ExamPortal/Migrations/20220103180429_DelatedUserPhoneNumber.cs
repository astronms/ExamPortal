using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class DelatedUserPhoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62094a65-ad68-4d0c-853a-88a5f353b9e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fb43be3-f13c-4ba4-9eb2-fd805a25ecd4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "adb2dfeb-28b1-44d5-a3a9-4044c14adfcb", "3051a284-d37c-4011-8890-31c12e74fbb6", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7d04ad9d-7a46-4038-a939-c753c2f1ed68", "2069433f-d5f1-424c-b136-fd7b8637fada", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "62094a65-ad68-4d0c-853a-88a5f353b9e1", "f46dfa49-fec4-42e1-8183-d8529b2767e4", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8fb43be3-f13c-4ba4-9eb2-fd805a25ecd4", "cb0d0052-ef8c-4656-a43f-4b35568a1b9a", "Administrator", "ADMINISTRATOR" });
        }
    }
}
