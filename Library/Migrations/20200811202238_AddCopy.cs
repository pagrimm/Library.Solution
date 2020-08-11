using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class AddCopy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Copies",
                columns: table => new
                {
                    CopyId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CheckoutDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    IsCheckedOut = table.Column<bool>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Copies", x => x.CopyId);
                    table.ForeignKey(
                        name: "FK_Copies_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Copies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Copies_BookId",
                table: "Copies",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Copies_UserId",
                table: "Copies",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Copies");
        }
    }
}
