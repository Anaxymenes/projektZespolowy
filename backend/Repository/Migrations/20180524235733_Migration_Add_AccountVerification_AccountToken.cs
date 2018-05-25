using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Repository.Migrations
{
    public partial class Migration_Add_AccountVerification_AccountToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountToken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<int>(nullable: false),
                    AuthToken = table.Column<string>(nullable: true),
                    AuthTokenExpires = table.Column<DateTime>(nullable: false),
                    RefreshToken = table.Column<string>(nullable: true),
                    RefreshTokenExpires = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountToken_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountVerification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<int>(nullable: false),
                    CodeVerification = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountVerification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountVerification_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountToken_AccountId",
                table: "AccountToken",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountVerification_AccountId",
                table: "AccountVerification",
                column: "AccountId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountToken");

            migrationBuilder.DropTable(
                name: "AccountVerification");
        }
    }
}
