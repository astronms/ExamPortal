using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class ChangesInAnswersTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswersValue_TaskAnswers_TaskAnswersId",
                table: "AnswersValue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskAnswers",
                table: "TaskAnswers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09efeb59-924d-4fd2-a0d5-36e4701640bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b7b06fa-351e-4edc-9f6b-2f8e8aef3ee2");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TaskAnswers",
                newName: "ExamTaskId");

            migrationBuilder.AddColumn<Guid>(
                name: "TaskAnswerId",
                table: "TaskAnswers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "SortId",
                table: "AnswersValue",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskAnswers",
                table: "TaskAnswers",
                column: "TaskAnswerId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c647c267-d9d4-447e-aed7-409249f1bcb3", "fa67979b-c91f-443d-b5b1-814a756788a8", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "440922f2-15a2-407d-9f9c-6f9c71f203de", "eddf9be0-4e4f-4acd-90f3-c0f748dfe92e", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_TaskAnswers_ExamTaskId",
                table: "TaskAnswers",
                column: "ExamTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswersValue_TaskAnswers_TaskAnswersId",
                table: "AnswersValue",
                column: "TaskAnswersId",
                principalTable: "TaskAnswers",
                principalColumn: "TaskAnswerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAnswers_ExamTask_ExamTaskId",
                table: "TaskAnswers",
                column: "ExamTaskId",
                principalTable: "ExamTask",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswersValue_TaskAnswers_TaskAnswersId",
                table: "AnswersValue");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAnswers_ExamTask_ExamTaskId",
                table: "TaskAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskAnswers",
                table: "TaskAnswers");

            migrationBuilder.DropIndex(
                name: "IX_TaskAnswers_ExamTaskId",
                table: "TaskAnswers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "440922f2-15a2-407d-9f9c-6f9c71f203de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c647c267-d9d4-447e-aed7-409249f1bcb3");

            migrationBuilder.DropColumn(
                name: "TaskAnswerId",
                table: "TaskAnswers");

            migrationBuilder.DropColumn(
                name: "SortId",
                table: "AnswersValue");

            migrationBuilder.RenameColumn(
                name: "ExamTaskId",
                table: "TaskAnswers",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskAnswers",
                table: "TaskAnswers",
                column: "Id");

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
    }
}
