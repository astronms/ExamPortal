using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class AddedDbSetForResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResult_AspNetUsers_UserId",
                table: "ExamResult");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamResult_SessionsResult_SessionResultId",
                table: "ExamResult");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultValue_TaskResult_TaskResultId",
                table: "ResultValue");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskResult_ExamResult_ExamResultId",
                table: "TaskResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskResult",
                table: "TaskResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResultValue",
                table: "ResultValue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamResult",
                table: "ExamResult");

            migrationBuilder.RenameTable(
                name: "TaskResult",
                newName: "TaskResults");

            migrationBuilder.RenameTable(
                name: "ResultValue",
                newName: "ResultValues");

            migrationBuilder.RenameTable(
                name: "ExamResult",
                newName: "ExamResults");

            migrationBuilder.RenameIndex(
                name: "IX_TaskResult_ExamResultId",
                table: "TaskResults",
                newName: "IX_TaskResults_ExamResultId");

            migrationBuilder.RenameIndex(
                name: "IX_ResultValue_TaskResultId",
                table: "ResultValues",
                newName: "IX_ResultValues_TaskResultId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamResult_UserId",
                table: "ExamResults",
                newName: "IX_ExamResults_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamResult_SessionResultId",
                table: "ExamResults",
                newName: "IX_ExamResults_SessionResultId");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "TaskResults",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskResults",
                table: "TaskResults",
                column: "TaskResultId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResultValues",
                table: "ResultValues",
                column: "ResultValueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamResults",
                table: "ExamResults",
                column: "ExamResultId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResults_AspNetUsers_UserId",
                table: "ExamResults",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResults_SessionsResult_SessionResultId",
                table: "ExamResults",
                column: "SessionResultId",
                principalTable: "SessionsResult",
                principalColumn: "SessionResultId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultValues_TaskResults_TaskResultId",
                table: "ResultValues",
                column: "TaskResultId",
                principalTable: "TaskResults",
                principalColumn: "TaskResultId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskResults_ExamResults_ExamResultId",
                table: "TaskResults",
                column: "ExamResultId",
                principalTable: "ExamResults",
                principalColumn: "ExamResultId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResults_AspNetUsers_UserId",
                table: "ExamResults");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamResults_SessionsResult_SessionResultId",
                table: "ExamResults");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultValues_TaskResults_TaskResultId",
                table: "ResultValues");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskResults_ExamResults_ExamResultId",
                table: "TaskResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskResults",
                table: "TaskResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResultValues",
                table: "ResultValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamResults",
                table: "ExamResults");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "TaskResults");

            migrationBuilder.RenameTable(
                name: "TaskResults",
                newName: "TaskResult");

            migrationBuilder.RenameTable(
                name: "ResultValues",
                newName: "ResultValue");

            migrationBuilder.RenameTable(
                name: "ExamResults",
                newName: "ExamResult");

            migrationBuilder.RenameIndex(
                name: "IX_TaskResults_ExamResultId",
                table: "TaskResult",
                newName: "IX_TaskResult_ExamResultId");

            migrationBuilder.RenameIndex(
                name: "IX_ResultValues_TaskResultId",
                table: "ResultValue",
                newName: "IX_ResultValue_TaskResultId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamResults_UserId",
                table: "ExamResult",
                newName: "IX_ExamResult_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamResults_SessionResultId",
                table: "ExamResult",
                newName: "IX_ExamResult_SessionResultId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskResult",
                table: "TaskResult",
                column: "TaskResultId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResultValue",
                table: "ResultValue",
                column: "ResultValueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamResult",
                table: "ExamResult",
                column: "ExamResultId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a48d905-08ad-4548-8da3-b168be98b43a",
                column: "ConcurrencyStamp",
                value: "c5f92353-7fc5-4ef7-b1bb-9a0d633aab13");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a91f4dbc-8020-4052-b7c1-8cb3d46de4fd",
                column: "ConcurrencyStamp",
                value: "3a066e77-645b-491f-bff8-704c97d2956e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d98f3528-5b3b-429c-b82d-a30df84f17da",
                column: "ConcurrencyStamp",
                value: "9e07a0f9-1404-4146-b7b4-dee5fb74f7a9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54c15d06-6ef2-4685-b26a-a39cfa0a0b35", "AQAAAAEAACcQAAAAEO2SKGzldNVczomTdUyT6HsIg/K5qcF6pGGsWhd9CN+S3pKd83deMm1ipeKj/vQcjg==", "d08c9192-0621-4afb-9d25-5fb5036416d0" });

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResult_AspNetUsers_UserId",
                table: "ExamResult",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResult_SessionsResult_SessionResultId",
                table: "ExamResult",
                column: "SessionResultId",
                principalTable: "SessionsResult",
                principalColumn: "SessionResultId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultValue_TaskResult_TaskResultId",
                table: "ResultValue",
                column: "TaskResultId",
                principalTable: "TaskResult",
                principalColumn: "TaskResultId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskResult_ExamResult_ExamResultId",
                table: "TaskResult",
                column: "ExamResultId",
                principalTable: "ExamResult",
                principalColumn: "ExamResultId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
