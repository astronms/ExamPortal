using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class addedNameToExamResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SessionsResult",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a48d905-08ad-4548-8da3-b168be98b43a",
                column: "ConcurrencyStamp",
                value: "0d20907d-c723-4b0b-b46f-eaa300f4e454");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a91f4dbc-8020-4052-b7c1-8cb3d46de4fd",
                column: "ConcurrencyStamp",
                value: "9a6734bd-8a35-4e03-ac52-dd42697f0b68");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d98f3528-5b3b-429c-b82d-a30df84f17da",
                column: "ConcurrencyStamp",
                value: "73b64ffd-8896-4278-8f37-ef539801bc47");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0e0b8ef-17c2-4ecf-8839-26dc1a9e2004", "AQAAAAEAACcQAAAAEI5pQiqwEdLmeI+yAY5l4DwBTv94mRLPPSOUr2F71jCsAiDcjxxTEDmFpy40sd5XPw==", "96e0b390-e9e4-448f-876c-75a8ce07869f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "SessionsResult");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a48d905-08ad-4548-8da3-b168be98b43a",
                column: "ConcurrencyStamp",
                value: "8e9aa841-6d38-4cf6-b671-3aa12fd1e052");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a91f4dbc-8020-4052-b7c1-8cb3d46de4fd",
                column: "ConcurrencyStamp",
                value: "7bbbeb9e-6286-44dc-881b-f750190f71b6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d98f3528-5b3b-429c-b82d-a30df84f17da",
                column: "ConcurrencyStamp",
                value: "40647d87-9316-4b85-a768-659238e31c0f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cf72daa-99f4-47a8-bfad-35c3ae858bb7", "AQAAAAEAACcQAAAAEPOtdcAS4b3DYuSD3zlGvTSrkxwlPs13Xi4oPBd58o3FGvXskLNCoCPbHH7j5bNZbA==", "69d69e2a-5883-49e4-a811-08e9edcba123" });
        }
    }
}
