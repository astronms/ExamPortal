using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class modifyExamResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResults_SessionsResult_SessionResultId",
                table: "ExamResults");

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionResultId",
                table: "ExamResults",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a48d905-08ad-4548-8da3-b168be98b43a",
                column: "ConcurrencyStamp",
                value: "dee176e9-15e2-443c-97ee-ded5069dadfc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a91f4dbc-8020-4052-b7c1-8cb3d46de4fd",
                column: "ConcurrencyStamp",
                value: "306d050b-8f97-4b81-90df-d2302697bf3b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d98f3528-5b3b-429c-b82d-a30df84f17da",
                column: "ConcurrencyStamp",
                value: "e7d3f7f0-49dc-4cc4-9f38-71f189f7af4b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "371e3206-0493-4a0b-be00-bbd05246fe1d", "AQAAAAEAACcQAAAAEO/KBych4z/w9ZquLFSPfpGl9mYlBxF0qoz6cCXjJWPGnN4DFGJry7jMLzgb/M6Aag==", "84de80c6-1bd2-4607-ba2a-4bbe8805ae00" });

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResults_SessionsResult_SessionResultId",
                table: "ExamResults",
                column: "SessionResultId",
                principalTable: "SessionsResult",
                principalColumn: "SessionResultId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResults_SessionsResult_SessionResultId",
                table: "ExamResults");

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionResultId",
                table: "ExamResults",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a48d905-08ad-4548-8da3-b168be98b43a",
                column: "ConcurrencyStamp",
                value: "0d0eff4f-0ac3-49a2-bbcd-2b8d2f5bef7f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a91f4dbc-8020-4052-b7c1-8cb3d46de4fd",
                column: "ConcurrencyStamp",
                value: "d19a938a-c6c7-4dcb-8f1e-bb02c53eb16f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d98f3528-5b3b-429c-b82d-a30df84f17da",
                column: "ConcurrencyStamp",
                value: "7d21474a-c1df-4946-894c-d5a34ebaa137");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c9681fa-0c85-46cb-a996-6dd72291a440", "AQAAAAEAACcQAAAAEOvFvX/4sSq8tt4Zi9JK3RDWYktYjCG+ERS2mQD5w9W9akb+UsGDBoy118BB3x04Vg==", "3611bab1-229a-4524-a8d9-8e7ca5e375a0" });

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResults_SessionsResult_SessionResultId",
                table: "ExamResults",
                column: "SessionResultId",
                principalTable: "SessionsResult",
                principalColumn: "SessionResultId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
