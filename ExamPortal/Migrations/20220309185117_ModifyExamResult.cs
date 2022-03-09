using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class ModifyExamResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResult_Exams_ExamId",
                table: "ExamResult");

            migrationBuilder.DropIndex(
                name: "IX_ExamResult_ExamId",
                table: "ExamResult");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a48d905-08ad-4548-8da3-b168be98b43a",
                column: "ConcurrencyStamp",
                value: "246b6e23-c27e-436c-b2e3-a22c8147b218");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a91f4dbc-8020-4052-b7c1-8cb3d46de4fd",
                column: "ConcurrencyStamp",
                value: "fd90a8ed-e1f1-490d-97d5-339e67f32f21");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d98f3528-5b3b-429c-b82d-a30df84f17da",
                column: "ConcurrencyStamp",
                value: "8b9226bc-e21b-4f8a-8143-8d0d2f303dc9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01bfeeef-1fab-4a50-b1b1-01da8a1aecd8", "AQAAAAEAACcQAAAAEGRf5PYJv1WEqluFLdsT4KC1puvCT4v6w4drE3GUMIuYccBbvIG7979bz5i4KnW1KQ==", "5be9cf61-4e98-4345-bf57-825b5e1d43b1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a48d905-08ad-4548-8da3-b168be98b43a",
                column: "ConcurrencyStamp",
                value: "9adc820d-ffd8-4c28-aa02-139c97ae5a18");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a91f4dbc-8020-4052-b7c1-8cb3d46de4fd",
                column: "ConcurrencyStamp",
                value: "bbbe49aa-ff56-4daf-82bc-00ba09b3851e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d98f3528-5b3b-429c-b82d-a30df84f17da",
                column: "ConcurrencyStamp",
                value: "3cdcc084-b11c-4163-b0e4-818ede0d2646");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2a8a45f-ddf6-46f8-a4a5-36da889ebe7e", "AQAAAAEAACcQAAAAENVyHVNaHzbx81inSRGQtZ2Qq2pghsSHg25XXHRieSw0YQS81Y00DAPkxExrjSZtcw==", "b58fada3-d3f2-4842-b5e5-f6266724da7e" });

            migrationBuilder.CreateIndex(
                name: "IX_ExamResult_ExamId",
                table: "ExamResult",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResult_Exams_ExamId",
                table: "ExamResult",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
