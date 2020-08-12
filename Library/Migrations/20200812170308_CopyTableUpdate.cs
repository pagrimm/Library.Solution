using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class CopyTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Copies_AspNetUsers_UserId",
                table: "Copies");

            migrationBuilder.DropIndex(
                name: "IX_Copies_UserId",
                table: "Copies");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Copies",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Copies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Copies_UserId1",
                table: "Copies",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Copies_AspNetUsers_UserId1",
                table: "Copies",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Copies_AspNetUsers_UserId1",
                table: "Copies");

            migrationBuilder.DropIndex(
                name: "IX_Copies_UserId1",
                table: "Copies");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Copies");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Copies",
                nullable: true,
                oldClrType: typeof(int));

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
