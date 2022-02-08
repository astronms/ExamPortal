using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class addedActivatedExams2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivetedExams_AspNetUsers_UserId",
                table: "ActivetedExams");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivetedExams_Exams_ExamId",
                table: "ActivetedExams");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36fde908-5c1f-4f67-a6dc-d0423ff16225");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62a662af-0f8e-443d-94fe-240045aa69dc");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivetedExams_AspNetUsers_UserId",
                table: "ActivetedExams");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivetedExams_Exams_ExamId",
                table: "ActivetedExams");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "652a9b3f-8203-437d-9e09-6f8e21155749");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e58f0988-7080-40be-8000-0711ba15e50d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "36fde908-5c1f-4f67-a6dc-d0423ff16225", "d2f9f28d-f7d1-4faf-8c7a-f62badce4140", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62a662af-0f8e-443d-94fe-240045aa69dc", "d6d68fc4-6489-4e0e-bf93-6ae3f3a25032", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActivetedExams_AspNetUsers_UserId",
                table: "ActivetedExams",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivetedExams_Exams_ExamId",
                table: "ActivetedExams",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
