using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class changeResultTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResults_AspNetUsers_UserId",
                table: "ExamResults");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamResults_Exams_ExamId",
                table: "ExamResults");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamResults_SessionsResult_SessionResultId",
                table: "ExamResults");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskResult_ExamResults_ExamResultId",
                table: "TaskResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamResults",
                table: "ExamResults");

            migrationBuilder.DropColumn(
                name: "SortId",
                table: "ResultValue");

            migrationBuilder.RenameTable(
                name: "ExamResults",
                newName: "ExamResult");

            migrationBuilder.RenameIndex(
                name: "IX_ExamResults_UserId",
                table: "ExamResult",
                newName: "IX_ExamResult_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamResults_SessionResultId",
                table: "ExamResult",
                newName: "IX_ExamResult_SessionResultId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamResults_ExamId",
                table: "ExamResult",
                newName: "IX_ExamResult_ExamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamResult",
                table: "ExamResult",
                column: "ExamResultId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResult_AspNetUsers_UserId",
                table: "ExamResult",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResult_Exams_ExamId",
                table: "ExamResult",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResult_SessionsResult_SessionResultId",
                table: "ExamResult",
                column: "SessionResultId",
                principalTable: "SessionsResult",
                principalColumn: "SessionResultId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskResult_ExamResult_ExamResultId",
                table: "TaskResult",
                column: "ExamResultId",
                principalTable: "ExamResult",
                principalColumn: "ExamResultId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResult_AspNetUsers_UserId",
                table: "ExamResult");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamResult_Exams_ExamId",
                table: "ExamResult");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamResult_SessionsResult_SessionResultId",
                table: "ExamResult");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskResult_ExamResult_ExamResultId",
                table: "TaskResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamResult",
                table: "ExamResult");

            migrationBuilder.RenameTable(
                name: "ExamResult",
                newName: "ExamResults");

            migrationBuilder.RenameIndex(
                name: "IX_ExamResult_UserId",
                table: "ExamResults",
                newName: "IX_ExamResults_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamResult_SessionResultId",
                table: "ExamResults",
                newName: "IX_ExamResults_SessionResultId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamResult_ExamId",
                table: "ExamResults",
                newName: "IX_ExamResults_ExamId");

            migrationBuilder.AddColumn<int>(
                name: "SortId",
                table: "ResultValue",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamResults",
                table: "ExamResults",
                column: "ExamResultId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a48d905-08ad-4548-8da3-b168be98b43a",
                column: "ConcurrencyStamp",
                value: "985fbd75-a36c-4a9f-9279-8072e8403b1b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a91f4dbc-8020-4052-b7c1-8cb3d46de4fd",
                column: "ConcurrencyStamp",
                value: "b6cd3af8-110f-4caf-b6c2-b1ac7bf81cae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d98f3528-5b3b-429c-b82d-a30df84f17da",
                column: "ConcurrencyStamp",
                value: "7f02e4d1-a12b-452f-9096-ed9e1a928204");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb620ea6-8dc5-4343-9bda-6056314f42af", "AQAAAAEAACcQAAAAEIY4yZrFori7gq6swEVRlDlYrugW/16L32plE/p56eNgN4va5s4XZ5tPqCI1uQ0/8A==", "3944be3b-a963-4e07-8574-b896c48ced0a" });

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResults_AspNetUsers_UserId",
                table: "ExamResults",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResults_Exams_ExamId",
                table: "ExamResults",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResults_SessionsResult_SessionResultId",
                table: "ExamResults",
                column: "SessionResultId",
                principalTable: "SessionsResult",
                principalColumn: "SessionResultId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskResult_ExamResults_ExamResultId",
                table: "TaskResult",
                column: "ExamResultId",
                principalTable: "ExamResults",
                principalColumn: "ExamResultId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
