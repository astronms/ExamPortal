using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class addedAditionScoreFieldsINResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TaskMaxScore",
                table: "TaskResult",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MaxScore",
                table: "ExamResults",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Score",
                table: "AnswerResult",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MaxScore",
                table: "AnswerResult",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a48d905-08ad-4548-8da3-b168be98b43a",
                column: "ConcurrencyStamp",
                value: "aa539273-1e70-4bec-b0c5-ba3d2f4beff5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a91f4dbc-8020-4052-b7c1-8cb3d46de4fd",
                column: "ConcurrencyStamp",
                value: "d1bb2d41-6b0c-4b4e-82ea-189d383b19c0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d98f3528-5b3b-429c-b82d-a30df84f17da",
                column: "ConcurrencyStamp",
                value: "6711c114-844e-446f-beb0-905e87efdd6d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3264e78f-c977-421f-bfd0-855421e1dd84", "AQAAAAEAACcQAAAAEB4pt7kC0ZY/IJpFsbyu9dBs5sVyKLpfwg4lrqFqtl0pmeyaM/bxyuSxAOLWbyZ6nA==", "2d4f38f7-6e94-4352-8208-f889d98f9091" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskMaxScore",
                table: "TaskResult");

            migrationBuilder.DropColumn(
                name: "MaxScore",
                table: "ExamResults");

            migrationBuilder.DropColumn(
                name: "MaxScore",
                table: "AnswerResult");

            migrationBuilder.AlterColumn<string>(
                name: "Score",
                table: "AnswerResult",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

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
    }
}
