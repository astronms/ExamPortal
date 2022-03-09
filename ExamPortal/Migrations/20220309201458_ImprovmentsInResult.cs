using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamPortal.Migrations
{
    public partial class ImprovmentsInResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SessionId",
                table: "SessionsResult",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a48d905-08ad-4548-8da3-b168be98b43a",
                column: "ConcurrencyStamp",
                value: "de9e976f-c463-4989-84c6-675871e840fb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a91f4dbc-8020-4052-b7c1-8cb3d46de4fd",
                column: "ConcurrencyStamp",
                value: "dc410db0-27b8-459b-ae3d-e23ed2b05265");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d98f3528-5b3b-429c-b82d-a30df84f17da",
                column: "ConcurrencyStamp",
                value: "aed0aab3-cce9-4582-85ba-8458d47c3d10");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3ea80f0-aabe-413b-a35d-23cecbeb9d94", "AQAAAAEAACcQAAAAEOmOKLRpq/suVsOh4i6dOXq9qgaqhh8E2ZtosUSKRFryRQxnlwf8fLszxlntDEOwwA==", "153e5692-05b9-4c5c-af2b-cb349ee412ee" });

            migrationBuilder.CreateIndex(
                name: "IX_SessionsResult_SessionId",
                table: "SessionsResult",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionsResult_Sessions_SessionId",
                table: "SessionsResult",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "SessionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionsResult_Sessions_SessionId",
                table: "SessionsResult");

            migrationBuilder.DropIndex(
                name: "IX_SessionsResult_SessionId",
                table: "SessionsResult");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "SessionsResult");

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
    }
}
