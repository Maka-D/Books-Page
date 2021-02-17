using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_2_2.Migrations
{
    public partial class changeAuthorsIdToNullableInBooksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksDetails_AuthorsDetails_AuthorId",
                table: "BooksDetails");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "BooksDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksDetails_AuthorsDetails_AuthorId",
                table: "BooksDetails",
                column: "AuthorId",
                principalTable: "AuthorsDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksDetails_AuthorsDetails_AuthorId",
                table: "BooksDetails");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "BooksDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksDetails_AuthorsDetails_AuthorId",
                table: "BooksDetails",
                column: "AuthorId",
                principalTable: "AuthorsDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
