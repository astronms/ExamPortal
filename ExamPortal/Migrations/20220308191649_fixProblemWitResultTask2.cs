using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class fixProblemWitResultTask2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: "78cc6e09-3abe-49e9-b39b-74aca2a5fa9e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a91f4dbc-8020-4052-b7c1-8cb3d46de4fd",
                column: "ConcurrencyStamp",
                value: "e83ec187-0311-4873-b6f9-23427e90ea64");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d98f3528-5b3b-429c-b82d-a30df84f17da",
                column: "ConcurrencyStamp",
                value: "7c882d9a-876a-4717-849c-43903d47f508");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc863745-2f42-4635-9be7-fe93ba2792c9", "AQAAAAEAACcQAAAAEFCLf6o/KTnzmwCTnzWari6kt/nZkyrRAm++W5G41FA/OfN2JEHLt/H14eL97mOMpw==", "695570e1-d18d-4fbf-b3e6-6a5a511252f2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
