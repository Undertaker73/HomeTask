using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "book_genre_lnk");
            migrationBuilder.CreateTable(
                name: "book_genre_lnk",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_genre_lnk", x => new { x.BookId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_book_genre_lnk_book_BookId",
                        column: x => x.BookId,
                        principalTable: "book",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_book_genre_lnk_dim_genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "dim_genre",
                        principalColumn: "genre_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_book_author_id",
                table: "book",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_book_genre_lnk_GenreId",
                table: "book_genre_lnk",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_library_card_book_book_id",
                table: "library_card",
                column: "book_book_id");

            migrationBuilder.CreateIndex(
                name: "IX_library_card_person_person_id",
                table: "library_card",
                column: "person_person_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "book_genre_lnk");

        }
    }
}
