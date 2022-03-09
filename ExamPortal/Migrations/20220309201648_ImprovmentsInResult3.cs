using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class ImprovmentsInResult3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SessionsResult_SessionId",
                table: "SessionsResult");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a48d905-08ad-4548-8da3-b168be98b43a",
                column: "ConcurrencyStamp",
                value: "c5f92353-7fc5-4ef7-b1bb-9a0d633aab13");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a91f4dbc-8020-4052-b7c1-8cb3d46de4fd",
                column: "ConcurrencyStamp",
                value: "3a066e77-645b-491f-bff8-704c97d2956e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d98f3528-5b3b-429c-b82d-a30df84f17da",
                column: "ConcurrencyStamp",
                value: "9e07a0f9-1404-4146-b7b4-dee5fb74f7a9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54c15d06-6ef2-4685-b26a-a39cfa0a0b35", "AQAAAAEAACcQAAAAEO2SKGzldNVczomTdUyT6HsIg/K5qcF6pGGsWhd9CN+S3pKd83deMm1ipeKj/vQcjg==", "d08c9192-0621-4afb-9d25-5fb5036416d0" });

            migrationBuilder.CreateIndex(
                name: "IX_SessionsResult_SessionId",
                table: "SessionsResult",
                column: "SessionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SessionsResult_SessionId",
                table: "SessionsResult");

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

            migrationBuilder.CreateIndex(
                name: "IX_SessionsResult_SessionId",
                table: "SessionsResult",
                column: "SessionId");
        }
    }
}
