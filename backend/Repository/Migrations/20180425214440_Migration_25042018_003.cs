using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Repository.Migrations
{
    public partial class Migration_25042018_003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hobby_AccountHobby_AccountHobbyId",
                table: "Hobby");

            migrationBuilder.DropForeignKey(
                name: "FK_Hobby_PostHobby_PostHobbyId",
                table: "Hobby");

            migrationBuilder.DropIndex(
                name: "IX_Hobby_AccountHobbyId",
                table: "Hobby");

            migrationBuilder.DropIndex(
                name: "IX_Hobby_PostHobbyId",
                table: "Hobby");

            migrationBuilder.DropColumn(
                name: "AccountHobbyId",
                table: "Hobby");

            migrationBuilder.DropColumn(
                name: "PostHobbyId",
                table: "Hobby");

            migrationBuilder.AddColumn<int>(
                name: "HoobyId",
                table: "PostHobby",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HobbyId",
                table: "AccountHobby",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostHobby_HoobyId",
                table: "PostHobby",
                column: "HoobyId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountHobby_HobbyId",
                table: "AccountHobby",
                column: "HobbyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountHobby_Hobby_HobbyId",
                table: "AccountHobby",
                column: "HobbyId",
                principalTable: "Hobby",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Post_PostId",
                table: "Comment",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostHobby_Hobby_HoobyId",
                table: "PostHobby",
                column: "HoobyId",
                principalTable: "Hobby",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountHobby_Hobby_HobbyId",
                table: "AccountHobby");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Post_PostId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_PostHobby_Hobby_HoobyId",
                table: "PostHobby");

            migrationBuilder.DropIndex(
                name: "IX_PostHobby_HoobyId",
                table: "PostHobby");

            migrationBuilder.DropIndex(
                name: "IX_Comment_PostId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_AccountHobby_HobbyId",
                table: "AccountHobby");

            migrationBuilder.DropColumn(
                name: "HoobyId",
                table: "PostHobby");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "HobbyId",
                table: "AccountHobby");

            migrationBuilder.AddColumn<int>(
                name: "AccountHobbyId",
                table: "Hobby",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostHobbyId",
                table: "Hobby",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hobby_AccountHobbyId",
                table: "Hobby",
                column: "AccountHobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_Hobby_PostHobbyId",
                table: "Hobby",
                column: "PostHobbyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hobby_AccountHobby_AccountHobbyId",
                table: "Hobby",
                column: "AccountHobbyId",
                principalTable: "AccountHobby",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hobby_PostHobby_PostHobbyId",
                table: "Hobby",
                column: "PostHobbyId",
                principalTable: "PostHobby",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
