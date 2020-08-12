using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class CopyUserV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Copies_AspNetUsers_UserId",
                table: "Copies");

            migrationBuilder.DropIndex(
                name: "IX_Copies_UserId",
                table: "Copies");

            migrationBuilder.DropColumn(
                name: "CheckoutDate",
                table: "Copies");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Copies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Copies");

            migrationBuilder.CreateTable(
                name: "CopyApplicationUser",
                columns: table => new
                {
                    CopyApplicationUserId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CopyId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    CheckoutDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Returned = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CopyApplicationUser", x => x.CopyApplicationUserId);
                    table.ForeignKey(
                        name: "FK_CopyApplicationUser_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CopyApplicationUser_Copies_CopyId",
                        column: x => x.CopyId,
                        principalTable: "Copies",
                        principalColumn: "CopyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CopyApplicationUser_ApplicationUserId",
                table: "CopyApplicationUser",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CopyApplicationUser_CopyId",
                table: "CopyApplicationUser",
                column: "CopyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CopyApplicationUser");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckoutDate",
                table: "Copies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Copies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Copies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Copies_UserId",
                table: "Copies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Copies_AspNetUsers_UserId",
                table: "Copies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
