using Microsoft.EntityFrameworkCore.Migrations;

namespace EsseEhBom.Data.Migrations
{
    public partial class ajuste_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_ApplicationUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Movies_MovieId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "CommentsMovie");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_MovieId",
                table: "CommentsMovie",
                newName: "IX_CommentsMovie_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ApplicationUserId",
                table: "CommentsMovie",
                newName: "IX_CommentsMovie_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentsMovie",
                table: "CommentsMovie",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CommentsBook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentsBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentsBook_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentsBook_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentsSerie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerieId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentsSerie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentsSerie_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentsSerie_Movies_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentsBook_ApplicationUserId",
                table: "CommentsBook",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsBook_BookId",
                table: "CommentsBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsSerie_ApplicationUserId",
                table: "CommentsSerie",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsSerie_SerieId",
                table: "CommentsSerie",
                column: "SerieId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentsMovie_AspNetUsers_ApplicationUserId",
                table: "CommentsMovie",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentsMovie_Movies_MovieId",
                table: "CommentsMovie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentsMovie_AspNetUsers_ApplicationUserId",
                table: "CommentsMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentsMovie_Movies_MovieId",
                table: "CommentsMovie");

            migrationBuilder.DropTable(
                name: "CommentsBook");

            migrationBuilder.DropTable(
                name: "CommentsSerie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentsMovie",
                table: "CommentsMovie");

            migrationBuilder.RenameTable(
                name: "CommentsMovie",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_CommentsMovie_MovieId",
                table: "Comments",
                newName: "IX_Comments_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentsMovie_ApplicationUserId",
                table: "Comments",
                newName: "IX_Comments_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_ApplicationUserId",
                table: "Comments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Movies_MovieId",
                table: "Comments",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
