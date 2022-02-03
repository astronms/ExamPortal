using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class ImprovmentsInSessionRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "650fd4a5-347c-4d18-b6a0-78863d1c0d7c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bacef949-7c38-426b-9bdb-f7eb7b15ff00");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "39061a5d-cf37-4de1-8381-fb205a68f872", "cb634dcc-af47-4faa-9fc1-74105c407696", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "350c3eca-2975-4393-b1b5-7ff7d90fa2f0", "3fecd467-7d53-44e3-a3e2-f9a7e7f8a6e7", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350c3eca-2975-4393-b1b5-7ff7d90fa2f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39061a5d-cf37-4de1-8381-fb205a68f872");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bacef949-7c38-426b-9bdb-f7eb7b15ff00", "f6c6b090-0df7-4a33-b678-c1ff35e20df7", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "650fd4a5-347c-4d18-b6a0-78863d1c0d7c", "82f52cf1-ad8a-4cf6-9f09-b902fc75b655", "Administrator", "ADMINISTRATOR" });
        }
    }
}
