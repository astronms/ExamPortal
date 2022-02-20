using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class AddedFieldIsFinishinActivatedExam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskAnswers_ExamAnswers_ExamAnswersId",
                table: "TaskAnswers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "440922f2-15a2-407d-9f9c-6f9c71f203de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c647c267-d9d4-447e-aed7-409249f1bcb3");

            migrationBuilder.AlterColumn<Guid>(
                name: "ExamAnswersId",
                table: "TaskAnswers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<bool>(
                name: "IsFinish",
                table: "ActivatedExams",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c9ea960f-c0c1-4008-9939-effb284aa79e", "8f02f712-bd19-4bfe-9e1c-adc4ffd9b93c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "903d8359-724a-4877-a9cd-d3f7ac84b675", "0cf2fb8b-1f92-4607-b120-857513c4d49b", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAnswers_ExamAnswers_ExamAnswersId",
                table: "TaskAnswers",
                column: "ExamAnswersId",
                principalTable: "ExamAnswers",
                principalColumn: "ExamAnswersId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskAnswers_ExamAnswers_ExamAnswersId",
                table: "TaskAnswers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "903d8359-724a-4877-a9cd-d3f7ac84b675");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9ea960f-c0c1-4008-9939-effb284aa79e");

            migrationBuilder.DropColumn(
                name: "IsFinish",
                table: "ActivatedExams");

            migrationBuilder.AlterColumn<Guid>(
                name: "ExamAnswersId",
                table: "TaskAnswers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c647c267-d9d4-447e-aed7-409249f1bcb3", "fa67979b-c91f-443d-b5b1-814a756788a8", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "440922f2-15a2-407d-9f9c-6f9c71f203de", "eddf9be0-4e4f-4acd-90f3-c0f748dfe92e", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAnswers_ExamAnswers_ExamAnswersId",
                table: "TaskAnswers",
                column: "ExamAnswersId",
                principalTable: "ExamAnswers",
                principalColumn: "ExamAnswersId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
