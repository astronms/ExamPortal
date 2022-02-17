using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class addImageTypeToExamTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27203353-5b06-4c8e-ad82-62a228ebe6bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c332250-ebe0-4951-977c-17fa2a41ad46");

            migrationBuilder.AddColumn<string>(
                name: "ImageType",
                table: "ExamTask",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ffc169df-6a8c-4b61-9657-ac22dcc56e21", "a300e95c-b115-4612-8c36-76d88e24d4e4", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2995c053-638f-4355-afc2-0224116f6375", "c8ba0f72-b9f3-4321-8ebb-18c511db7902", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2995c053-638f-4355-afc2-0224116f6375");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffc169df-6a8c-4b61-9657-ac22dcc56e21");

            migrationBuilder.DropColumn(
                name: "ImageType",
                table: "ExamTask");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "27203353-5b06-4c8e-ad82-62a228ebe6bb", "2655a37d-6ee7-428d-afc8-f776dafacc9d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3c332250-ebe0-4951-977c-17fa2a41ad46", "19f561bb-9c74-4760-bb6d-4574ce9393cc", "Administrator", "ADMINISTRATOR" });
        }
    }
}
