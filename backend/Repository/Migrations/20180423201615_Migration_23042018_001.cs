using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Repository.Migrations
{
    public partial class Migration_23042018_001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostType",
                table: "Post",
                newName: "Content");

            migrationBuilder.AddColumn<int>(
                name: "PostTypeId",
                table: "Post",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PostType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_PostTypeId",
                table: "Post",
                column: "PostTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_PostType_PostTypeId",
                table: "Post",
                column: "PostTypeId",
                principalTable: "PostType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_PostType_PostTypeId",
                table: "Post");

            migrationBuilder.DropTable(
                name: "PostType");

            migrationBuilder.DropIndex(
                name: "IX_Post_PostTypeId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "PostTypeId",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Post",
                newName: "PostType");
        }
    }
}
