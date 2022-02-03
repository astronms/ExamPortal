using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class addeExternalIdInExam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64b28e24-49d0-4074-8792-f8aa825b469e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ccdc46e3-7d5b-4514-8494-3f73dd8edcf6");

            migrationBuilder.AddColumn<Guid>(
                name: "ExternalId",
                table: "Exams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b17b8121-39fb-4cc6-99d5-369d0640cd55", "4ea7630e-9d66-4ae0-aa28-d79404a47da3", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "516e1f44-17df-402b-adbd-7140beefe9f3", "d65e2d5a-a2e5-42a4-970d-bee340033d2d", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "516e1f44-17df-402b-adbd-7140beefe9f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b17b8121-39fb-4cc6-99d5-369d0640cd55");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Exams");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ccdc46e3-7d5b-4514-8494-3f73dd8edcf6", "875e9c17-6ba5-42ab-acb0-e484b9d22062", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64b28e24-49d0-4074-8792-f8aa825b469e", "4c8bcbd8-6ad9-4f50-b502-13fa1d3bacff", "Administrator", "ADMINISTRATOR" });
        }
    }
}
