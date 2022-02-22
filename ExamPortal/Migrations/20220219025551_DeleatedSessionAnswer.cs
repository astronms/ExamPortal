using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class DeleatedSessionAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswersValue_Answers_AnswersId",
                table: "AnswersValue");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamAnswers_SessionAnswers_SessionAnswersId",
                table: "ExamAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_SessionAnswers_SessionAnswersId",
                table: "Exams");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "SessionAnswers");

            migrationBuilder.DropIndex(
                name: "IX_Exams_SessionAnswersId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_ExamAnswers_SessionAnswersId",
                table: "ExamAnswers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f5b69b0-34c1-4a55-9b5c-8b2a50e57e56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bacb26c6-4a41-4710-a201-0487d275c404");

            migrationBuilder.DropColumn(
                name: "SessionAnswersId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "ExamAnswers");

            migrationBuilder.DropColumn(
                name: "SessionAnswersId",
                table: "ExamAnswers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ExamAnswers");

            migrationBuilder.RenameColumn(
                name: "AnswersId",
                table: "AnswersValue",
                newName: "TaskAnswersId");

            migrationBuilder.RenameIndex(
                name: "IX_AnswersValue_AnswersId",
                table: "AnswersValue",
                newName: "IX_AnswersValue_TaskAnswersId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "09efeb59-924d-4fd2-a0d5-36e4701640bc", "c58bcc1d-2b88-46fe-a2ab-74bee97b54e0", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9b7b06fa-351e-4edc-9f6b-2f8e8aef3ee2", "b33f98d9-883c-4d0c-bcb2-a397b4e0a463", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_AnswersValue_TaskAnswers_TaskAnswersId",
                table: "AnswersValue",
                column: "TaskAnswersId",
                principalTable: "TaskAnswers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswersValue_TaskAnswers_TaskAnswersId",
                table: "AnswersValue");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09efeb59-924d-4fd2-a0d5-36e4701640bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b7b06fa-351e-4edc-9f6b-2f8e8aef3ee2");

            migrationBuilder.RenameColumn(
                name: "TaskAnswersId",
                table: "AnswersValue",
                newName: "AnswersId");

            migrationBuilder.RenameIndex(
                name: "IX_AnswersValue_TaskAnswersId",
                table: "AnswersValue",
                newName: "IX_AnswersValue_AnswersId");

            migrationBuilder.AddColumn<Guid>(
                name: "SessionAnswersId",
                table: "Exams",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExternalId",
                table: "ExamAnswers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SessionAnswersId",
                table: "ExamAnswers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ExamAnswers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskAnswersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_Answers_TaskAnswers_TaskAnswersId",
                        column: x => x.TaskAnswersId,
                        principalTable: "TaskAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionAnswers",
                columns: table => new
                {
                    SessionAnswersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionAnswers", x => x.SessionAnswersId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bacb26c6-4a41-4710-a201-0487d275c404", "7a911516-1870-45ff-bc1b-ec7ef6141f83", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1f5b69b0-34c1-4a55-9b5c-8b2a50e57e56", "e41f6599-b1ac-4f0c-a995-1ff9a2d229db", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_SessionAnswersId",
                table: "Exams",
                column: "SessionAnswersId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamAnswers_SessionAnswersId",
                table: "ExamAnswers",
                column: "SessionAnswersId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_TaskAnswersId",
                table: "Answers",
                column: "TaskAnswersId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AnswersValue_Answers_AnswersId",
                table: "AnswersValue",
                column: "AnswersId",
                principalTable: "Answers",
                principalColumn: "AnswerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamAnswers_SessionAnswers_SessionAnswersId",
                table: "ExamAnswers",
                column: "SessionAnswersId",
                principalTable: "SessionAnswers",
                principalColumn: "SessionAnswersId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_SessionAnswers_SessionAnswersId",
                table: "Exams",
                column: "SessionAnswersId",
                principalTable: "SessionAnswers",
                principalColumn: "SessionAnswersId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
