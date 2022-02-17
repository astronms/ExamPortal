using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class ChangeImageTypeInExamTask2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05e043bb-cc4b-47d7-a73d-3e479296668f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6564b1e7-c4f9-450f-9a85-410c0a554f7f");

            migrationBuilder.RenameColumn(
                name: "ImageBytes",
                table: "ExamTask",
                newName: "Image");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "27203353-5b06-4c8e-ad82-62a228ebe6bb", "2655a37d-6ee7-428d-afc8-f776dafacc9d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3c332250-ebe0-4951-977c-17fa2a41ad46", "19f561bb-9c74-4760-bb6d-4574ce9393cc", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27203353-5b06-4c8e-ad82-62a228ebe6bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c332250-ebe0-4951-977c-17fa2a41ad46");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "ExamTask",
                newName: "ImageBytes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "05e043bb-cc4b-47d7-a73d-3e479296668f", "bd386c0d-a965-4cf1-9635-d85d12ffb1bf", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6564b1e7-c4f9-450f-9a85-410c0a554f7f", "b61c6156-4b79-4872-867d-508285eb4514", "Administrator", "ADMINISTRATOR" });
        }
    }
}
