using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class modifyExamResult2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a48d905-08ad-4548-8da3-b168be98b43a",
                column: "ConcurrencyStamp",
                value: "eda2fd22-4a5c-471f-9f08-cab88dd5aa5b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a91f4dbc-8020-4052-b7c1-8cb3d46de4fd",
                column: "ConcurrencyStamp",
                value: "35621157-e2ff-42a9-884a-d55b1689a3fa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d98f3528-5b3b-429c-b82d-a30df84f17da",
                column: "ConcurrencyStamp",
                value: "a4a6170b-8f99-4328-983d-69d723078af7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1c5778a-26d7-4d44-844e-74dbe80cc695", "AQAAAAEAACcQAAAAECwo5w3acL5xv92wFuRJ1pyYevYz47SpLXM0BIsGXn2MWllZesATQEEaJk7QudYNZA==", "1b7c34a4-cb8e-47b6-8717-03a5787801eb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a48d905-08ad-4548-8da3-b168be98b43a",
                column: "ConcurrencyStamp",
                value: "dee176e9-15e2-443c-97ee-ded5069dadfc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a91f4dbc-8020-4052-b7c1-8cb3d46de4fd",
                column: "ConcurrencyStamp",
                value: "306d050b-8f97-4b81-90df-d2302697bf3b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d98f3528-5b3b-429c-b82d-a30df84f17da",
                column: "ConcurrencyStamp",
                value: "e7d3f7f0-49dc-4cc4-9f38-71f189f7af4b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "371e3206-0493-4a0b-be00-bbd05246fe1d", "AQAAAAEAACcQAAAAEO/KBych4z/w9ZquLFSPfpGl9mYlBxF0qoz6cCXjJWPGnN4DFGJry7jMLzgb/M6Aag==", "84de80c6-1bd2-4607-ba2a-4bbe8805ae00" });
        }
    }
}
