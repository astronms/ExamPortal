using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class AddedDbTablesForAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivetedExams_AspNetUsers_UserId",
                table: "ActivetedExams");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivetedExams_Exams_ExamId",
                table: "ActivetedExams");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Tasks_TaskId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsInfos_AspNetUsers_UserId",
                table: "StudentsInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Exams_ExamId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Values_Questions_QuestionId",
                table: "Values");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Values",
                table: "Values");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsInfos",
                table: "StudentsInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivetedExams",
                table: "ActivetedExams");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "652a9b3f-8203-437d-9e09-6f8e21155749");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e58f0988-7080-40be-8000-0711ba15e50d");

            migrationBuilder.RenameTable(
                name: "Values",
                newName: "Value");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "ExamTask");

            migrationBuilder.RenameTable(
                name: "StudentsInfos",
                newName: "StudentInfo");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Question");

            migrationBuilder.RenameTable(
                name: "ActivetedExams",
                newName: "ActivatedExams");

            migrationBuilder.RenameIndex(
                name: "IX_Values_QuestionId",
                table: "Value",
                newName: "IX_Value_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ExamId",
                table: "ExamTask",
                newName: "IX_ExamTask_ExamId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentsInfos_UserId",
                table: "StudentInfo",
                newName: "IX_StudentInfo_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_TaskId",
                table: "Question",
                newName: "IX_Question_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_ActivetedExams_UserId",
                table: "ActivatedExams",
                newName: "IX_ActivatedExams_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ActivetedExams_ExamId",
                table: "ActivatedExams",
                newName: "IX_ActivatedExams_ExamId");

            migrationBuilder.AddColumn<Guid>(
                name: "SessionAnswersId",
                table: "Exams",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ExamAnswersId",
                table: "ActivatedExams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Value",
                table: "Value",
                column: "ValueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamTask",
                table: "ExamTask",
                column: "TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentInfo",
                table: "StudentInfo",
                column: "StudentInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivatedExams",
                table: "ActivatedExams",
                column: "ActivatedExamId");

            migrationBuilder.CreateTable(
                name: "SessionAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionAnswers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExamAnswers",
                columns: table => new
                {
                    ExamAnswersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionAnswersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamAnswers", x => x.ExamAnswersId);
                    table.ForeignKey(
                        name: "FK_ExamAnswers_SessionAnswers_SessionAnswersId",
                        column: x => x.SessionAnswersId,
                        principalTable: "SessionAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamAnswersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskAnswers = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskAnswers_ExamAnswers_ExamAnswersId",
                        column: x => x.ExamAnswersId,
                        principalTable: "ExamAnswers",
                        principalColumn: "ExamAnswersId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskAnswers_ExamAnswers_TaskAnswers",
                        column: x => x.TaskAnswers,
                        principalTable: "ExamAnswers",
                        principalColumn: "ExamAnswersId",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "AnswersValue",
                columns: table => new
                {
                    AnswersValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswersAnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswersValue", x => x.AnswersValueId);
                    table.ForeignKey(
                        name: "FK_AnswersValue_Answers_AnswersAnswerId",
                        column: x => x.AnswersAnswerId,
                        principalTable: "Answers",
                        principalColumn: "AnswerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnswersValue_SessionAnswers_AnswersId",
                        column: x => x.AnswersId,
                        principalTable: "SessionAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6e676b43-8bf4-4558-9208-d9d1684f41e1", "c40ac5fb-d3e2-464d-8fea-882c58bc5862", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ef4a138c-7eac-464c-9cb2-ece6e2bd619f", "6694b97a-eaa2-424a-a949-be3985802211", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_SessionAnswersId",
                table: "Exams",
                column: "SessionAnswersId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivatedExams_ExamAnswersId",
                table: "ActivatedExams",
                column: "ExamAnswersId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_TaskAnswersId",
                table: "Answers",
                column: "TaskAnswersId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnswersValue_AnswersAnswerId",
                table: "AnswersValue",
                column: "AnswersAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswersValue_AnswersId",
                table: "AnswersValue",
                column: "AnswersId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamAnswers_SessionAnswersId",
                table: "ExamAnswers",
                column: "SessionAnswersId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAnswers_ExamAnswersId",
                table: "TaskAnswers",
                column: "ExamAnswersId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAnswers_TaskAnswers",
                table: "TaskAnswers",
                column: "TaskAnswers");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivatedExams_AspNetUsers_UserId",
                table: "ActivatedExams",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivatedExams_ExamAnswers_ExamAnswersId",
                table: "ActivatedExams",
                column: "ExamAnswersId",
                principalTable: "ExamAnswers",
                principalColumn: "ExamAnswersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivatedExams_Exams_ExamId",
                table: "ActivatedExams",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_SessionAnswers_SessionAnswersId",
                table: "Exams",
                column: "SessionAnswersId",
                principalTable: "SessionAnswers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamTask_Exams_ExamId",
                table: "ExamTask",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_ExamTask_TaskId",
                table: "Question",
                column: "TaskId",
                principalTable: "ExamTask",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentInfo_AspNetUsers_UserId",
                table: "StudentInfo",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Value_Question_QuestionId",
                table: "Value",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivatedExams_AspNetUsers_UserId",
                table: "ActivatedExams");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivatedExams_ExamAnswers_ExamAnswersId",
                table: "ActivatedExams");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivatedExams_Exams_ExamId",
                table: "ActivatedExams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_SessionAnswers_SessionAnswersId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamTask_Exams_ExamId",
                table: "ExamTask");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_ExamTask_TaskId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentInfo_AspNetUsers_UserId",
                table: "StudentInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Value_Question_QuestionId",
                table: "Value");

            migrationBuilder.DropTable(
                name: "AnswersValue");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "TaskAnswers");

            migrationBuilder.DropTable(
                name: "ExamAnswers");

            migrationBuilder.DropTable(
                name: "SessionAnswers");

            migrationBuilder.DropIndex(
                name: "IX_Exams_SessionAnswersId",
                table: "Exams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Value",
                table: "Value");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentInfo",
                table: "StudentInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamTask",
                table: "ExamTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivatedExams",
                table: "ActivatedExams");

            migrationBuilder.DropIndex(
                name: "IX_ActivatedExams_ExamAnswersId",
                table: "ActivatedExams");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e676b43-8bf4-4558-9208-d9d1684f41e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef4a138c-7eac-464c-9cb2-ece6e2bd619f");

            migrationBuilder.DropColumn(
                name: "SessionAnswersId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "ExamAnswersId",
                table: "ActivatedExams");

            migrationBuilder.RenameTable(
                name: "Value",
                newName: "Values");

            migrationBuilder.RenameTable(
                name: "StudentInfo",
                newName: "StudentsInfos");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "Questions");

            migrationBuilder.RenameTable(
                name: "ExamTask",
                newName: "Tasks");

            migrationBuilder.RenameTable(
                name: "ActivatedExams",
                newName: "ActivetedExams");

            migrationBuilder.RenameIndex(
                name: "IX_Value_QuestionId",
                table: "Values",
                newName: "IX_Values_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentInfo_UserId",
                table: "StudentsInfos",
                newName: "IX_StudentsInfos_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_TaskId",
                table: "Questions",
                newName: "IX_Questions_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamTask_ExamId",
                table: "Tasks",
                newName: "IX_Tasks_ExamId");

            migrationBuilder.RenameIndex(
                name: "IX_ActivatedExams_UserId",
                table: "ActivetedExams",
                newName: "IX_ActivetedExams_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ActivatedExams_ExamId",
                table: "ActivetedExams",
                newName: "IX_ActivetedExams_ExamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Values",
                table: "Values",
                column: "ValueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsInfos",
                table: "StudentsInfos",
                column: "StudentInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivetedExams",
                table: "ActivetedExams",
                column: "ActivatedExamId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "652a9b3f-8203-437d-9e09-6f8e21155749", "9a6ac6bf-4619-4354-873b-ec2b2fe9586b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e58f0988-7080-40be-8000-0711ba15e50d", "d5692102-e121-42ae-8a5e-6d2ba9843a1c", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActivetedExams_AspNetUsers_UserId",
                table: "ActivetedExams",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivetedExams_Exams_ExamId",
                table: "ActivetedExams",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Tasks_TaskId",
                table: "Questions",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsInfos_AspNetUsers_UserId",
                table: "StudentsInfos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Exams_ExamId",
                table: "Tasks",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Values_Questions_QuestionId",
                table: "Values",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
