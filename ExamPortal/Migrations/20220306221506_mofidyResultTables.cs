using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class mofidyResultTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerResult");

            migrationBuilder.CreateTable(
                name: "ResultValue",
                columns: table => new
                {
                    ResultValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SortId = table.Column<int>(type: "int", nullable: false),
                    Actual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Score = table.Column<double>(type: "float", nullable: false),
                    MaxScore = table.Column<double>(type: "float", nullable: false),
                    TaskResultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultValue", x => x.ResultValueId);
                    table.ForeignKey(
                        name: "FK_ResultValue_TaskResult_TaskResultId",
                        column: x => x.TaskResultId,
                        principalTable: "TaskResult",
                        principalColumn: "TaskResultId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a48d905-08ad-4548-8da3-b168be98b43a",
                column: "ConcurrencyStamp",
                value: "c4d2b64d-c484-4698-bc8f-daa11850470c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a91f4dbc-8020-4052-b7c1-8cb3d46de4fd",
                column: "ConcurrencyStamp",
                value: "c927e8e7-eb66-4e25-b337-dda52008a788");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d98f3528-5b3b-429c-b82d-a30df84f17da",
                column: "ConcurrencyStamp",
                value: "e6f91534-a5c6-492e-987c-af642163f3cd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4707167c-842b-43a0-81d3-20d3ec2028f2", "AQAAAAEAACcQAAAAEFm+2eeTr1oB2e+D9UguJq0l7ESoSDqzP97vURY4CLqX/aM14PhJZMAbipVA0D4mKw==", "145c507c-663c-4f97-a75a-c5d7d946f7f9" });

            migrationBuilder.CreateIndex(
                name: "IX_ResultValue_TaskResultId",
                table: "ResultValue",
                column: "TaskResultId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultValue");

            migrationBuilder.CreateTable(
                name: "AnswerResult",
                columns: table => new
                {
                    AnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Actual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxScore = table.Column<double>(type: "float", nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false),
                    SortId = table.Column<int>(type: "int", nullable: false),
                    TaskResultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerResult", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_AnswerResult_TaskResult_TaskResultId",
                        column: x => x.TaskResultId,
                        principalTable: "TaskResult",
                        principalColumn: "TaskResultId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AnswerResult_TaskResultId",
                table: "AnswerResult",
                column: "TaskResultId");
        }
    }
}
