using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class fixProblemWitResultTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskScore",
                table: "TaskResult",
                newName: "TotalScore");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a48d905-08ad-4548-8da3-b168be98b43a",
                column: "ConcurrencyStamp",
                value: "372409bb-ae03-4ac1-a02f-e5b249d7a0f6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a91f4dbc-8020-4052-b7c1-8cb3d46de4fd",
                column: "ConcurrencyStamp",
                value: "fb797a58-8df0-4126-871c-9174f818ce20");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d98f3528-5b3b-429c-b82d-a30df84f17da",
                column: "ConcurrencyStamp",
                value: "411d3f66-26ed-4038-b62e-8ca47df3ef19");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc07f010-cfc5-4572-a60b-3189a2172a43", "AQAAAAEAACcQAAAAEHke8rDFQwIADQN0+kJ/OvjVyWLVQuK6PgQP3TOfLNwp+Wytv0tiR27uXWT1o6FoAQ==", "a5ac808e-3f70-4e15-bd33-d9d86673c7e6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalScore",
                table: "TaskResult",
                newName: "TaskScore");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a48d905-08ad-4548-8da3-b168be98b43a",
                column: "ConcurrencyStamp",
                value: "f2742a80-fdea-4c02-925e-8ef557a95793");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a91f4dbc-8020-4052-b7c1-8cb3d46de4fd",
                column: "ConcurrencyStamp",
                value: "70199c6e-6cec-41bf-acc5-c6cba8f63031");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d98f3528-5b3b-429c-b82d-a30df84f17da",
                column: "ConcurrencyStamp",
                value: "2d132ea7-7320-42f1-9aea-97a369314857");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "56ba63a6-36f1-406f-99f4-bdce996b0766", "AQAAAAEAACcQAAAAEIM7SmXEXhBIlkPusxl3J5EMtIN1zUggM2+jq3knRwJGI1YTPefdkM+TNCvQ/ZDoHA==", "a6974efd-ae29-4aa4-b230-2b37d1787be9" });
        }
    }
}
