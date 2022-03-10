using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class addedImageTypeToTaskResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageType",
                table: "TaskResults",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a48d905-08ad-4548-8da3-b168be98b43a",
                column: "ConcurrencyStamp",
                value: "9135c737-3362-404a-a346-a5fd38939f91");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a91f4dbc-8020-4052-b7c1-8cb3d46de4fd",
                column: "ConcurrencyStamp",
                value: "1730bc25-684c-4235-81e6-f49352a21f24");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d98f3528-5b3b-429c-b82d-a30df84f17da",
                column: "ConcurrencyStamp",
                value: "aff4c8b1-df01-4cce-b9c5-138e4ff6fe4f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1130ca7-7d2a-40e7-83c9-6beebbae221e", "AQAAAAEAACcQAAAAEO8fC5xOUJX29+K7P+b5YJr/1RuImG73kW4iZzn05LwFcEfITHrKvE3iG1lW3RW/yg==", "95681d5b-e87e-4b09-93e3-75fe93b27d8d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageType",
                table: "TaskResults");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a48d905-08ad-4548-8da3-b168be98b43a",
                column: "ConcurrencyStamp",
                value: "3a73718e-e3e5-4ae3-8ebb-7e0e33b44c90");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a91f4dbc-8020-4052-b7c1-8cb3d46de4fd",
                column: "ConcurrencyStamp",
                value: "43acf1e0-360f-4f2c-9e3b-f45dde690846");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d98f3528-5b3b-429c-b82d-a30df84f17da",
                column: "ConcurrencyStamp",
                value: "1317795f-154c-47fd-b801-47d936c79991");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e1ccde0-0c03-4dcf-8559-5096c8458d70", "AQAAAAEAACcQAAAAEPTHI6TrsVadktYYpfowzK/xuYNQWZ1VunyzPn1G35vindaqrnRUOvXgYPGJ7i+xFQ==", "53b2ea0c-37a2-4689-9121-7ba5241e4e08" });
        }
    }
}
