using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class ImprovmentsInResult2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a48d905-08ad-4548-8da3-b168be98b43a",
                column: "ConcurrencyStamp",
                value: "b7686620-4ef2-41cc-974f-50d12fde82e2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a91f4dbc-8020-4052-b7c1-8cb3d46de4fd",
                column: "ConcurrencyStamp",
                value: "0065c032-013d-48e5-b743-5b1ba85e06d4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d98f3528-5b3b-429c-b82d-a30df84f17da",
                column: "ConcurrencyStamp",
                value: "6e3dce2c-be63-484d-933a-0d00ed0ccf5b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85e61940-905b-4d62-bfab-6c8ff08a04a0", "AQAAAAEAACcQAAAAECQl70gSPa/rko0Z81pwf/gt3KvJAywBHBvNWOiJE1dSBzNtgqA26Vb2GBSnzoxprA==", "d86190fe-3821-4a5f-9ecd-84de71f971f0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a48d905-08ad-4548-8da3-b168be98b43a",
                column: "ConcurrencyStamp",
                value: "de9e976f-c463-4989-84c6-675871e840fb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a91f4dbc-8020-4052-b7c1-8cb3d46de4fd",
                column: "ConcurrencyStamp",
                value: "dc410db0-27b8-459b-ae3d-e23ed2b05265");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d98f3528-5b3b-429c-b82d-a30df84f17da",
                column: "ConcurrencyStamp",
                value: "aed0aab3-cce9-4582-85ba-8458d47c3d10");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3ea80f0-aabe-413b-a35d-23cecbeb9d94", "AQAAAAEAACcQAAAAEOmOKLRpq/suVsOh4i6dOXq9qgaqhh8E2ZtosUSKRFryRQxnlwf8fLszxlntDEOwwA==", "153e5692-05b9-4c5c-af2b-cb349ee412ee" });
        }
    }
}
