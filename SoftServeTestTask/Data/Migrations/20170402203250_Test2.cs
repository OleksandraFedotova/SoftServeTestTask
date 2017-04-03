using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftServeTestTask.Data.Migrations
{
    public partial class Test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organization_AspNetUsers_ApplicationUserId",
                table: "Organization");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Organization",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Organization_ApplicationUserId",
                table: "Organization",
                newName: "IX_Organization_UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_AspNetUsers_UserId1",
                table: "Organization",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organization_AspNetUsers_UserId1",
                table: "Organization");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Organization",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Organization_UserId1",
                table: "Organization",
                newName: "IX_Organization_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_AspNetUsers_ApplicationUserId",
                table: "Organization",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
