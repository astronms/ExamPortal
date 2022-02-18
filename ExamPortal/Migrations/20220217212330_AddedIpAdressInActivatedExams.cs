using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class AddedIpAdressInActivatedExams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e2ed26a-661c-4a01-b8b2-ec2e5f3354d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a92b8343-0595-4f04-b658-c79bba0eb92e");

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "ActivatedExams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bacb26c6-4a41-4710-a201-0487d275c404", "7a911516-1870-45ff-bc1b-ec7ef6141f83", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1f5b69b0-34c1-4a55-9b5c-8b2a50e57e56", "e41f6599-b1ac-4f0c-a995-1ff9a2d229db", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f5b69b0-34c1-4a55-9b5c-8b2a50e57e56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bacb26c6-4a41-4710-a201-0487d275c404");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "ActivatedExams");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7e2ed26a-661c-4a01-b8b2-ec2e5f3354d4", "4481d370-282c-432a-a583-fd4283571dc8", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a92b8343-0595-4f04-b658-c79bba0eb92e", "542345e6-f5bc-4dc8-8b2d-e56b37455ece", "Administrator", "ADMINISTRATOR" });
        }
    }
}
