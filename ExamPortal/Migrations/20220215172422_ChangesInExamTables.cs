using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class ChangesInExamTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c2ab088-63d1-4d81-af26-9f2adeb1a063");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca981047-3ebb-4e14-93a2-2e3dd9352ba9");

            migrationBuilder.AlterColumn<int>(
                name: "Time",
                table: "ExamTask",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dde4b825-855f-4e95-8528-4ae2cfb92f3c", "f469fafe-29db-465f-9cec-4e8af74dd0da", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad4cdb52-882e-443d-b9b6-145651c86e17", "77b614c0-0207-4ae2-9d6b-d655de572c37", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad4cdb52-882e-443d-b9b6-145651c86e17");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dde4b825-855f-4e95-8528-4ae2cfb92f3c");

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "ExamTask",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ca981047-3ebb-4e14-93a2-2e3dd9352ba9", "c62d5de3-6439-4ae1-9dee-b14b729a9955", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5c2ab088-63d1-4d81-af26-9f2adeb1a063", "e38a2d1f-44bd-452d-b4b6-8c238c724cb7", "Administrator", "ADMINISTRATOR" });
        }
    }
}
