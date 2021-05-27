using Microsoft.EntityFrameworkCore.Migrations;

namespace EsseEhBom.Data.Migrations
{
    public partial class ajuste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Catalog_CatalogId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Catalog_CatalogId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_MainCastMovies_Actors_ActorId",
                table: "MainCastMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_MainCastMovies_Movies_MovieId",
                table: "MainCastMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_MainCastSeries_Actors_ActorId",
                table: "MainCastSeries");

            migrationBuilder.DropForeignKey(
                name: "FK_MainCastSeries_Series_SerieId",
                table: "MainCastSeries");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Catalog_CatalogId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Series_Catalog_CatalogId",
                table: "Series");

            migrationBuilder.DropTable(
                name: "Catalog");

            migrationBuilder.DropIndex(
                name: "IX_Series_CatalogId",
                table: "Series");

            migrationBuilder.DropIndex(
                name: "IX_Movies_CatalogId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CatalogId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Books_CatalogId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CatalogId",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "CatalogId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "CatalogId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CatalogId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "SerieId",
                table: "MainCastSeries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActorId",
                table: "MainCastSeries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "MainCastMovies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActorId",
                table: "MainCastMovies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MovieId",
                table: "Comments",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Movies_MovieId",
                table: "Comments",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MainCastMovies_Actors_ActorId",
                table: "MainCastMovies",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MainCastMovies_Movies_MovieId",
                table: "MainCastMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MainCastSeries_Actors_ActorId",
                table: "MainCastSeries",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MainCastSeries_Series_SerieId",
                table: "MainCastSeries",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Movies_MovieId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_MainCastMovies_Actors_ActorId",
                table: "MainCastMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_MainCastMovies_Movies_MovieId",
                table: "MainCastMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_MainCastSeries_Actors_ActorId",
                table: "MainCastSeries");

            migrationBuilder.DropForeignKey(
                name: "FK_MainCastSeries_Series_SerieId",
                table: "MainCastSeries");

            migrationBuilder.DropIndex(
                name: "IX_Comments_MovieId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "CatalogId",
                table: "Series",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CatalogId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SerieId",
                table: "MainCastSeries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ActorId",
                table: "MainCastSeries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "MainCastMovies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ActorId",
                table: "MainCastMovies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CatalogId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CatalogId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Series_CatalogId",
                table: "Series",
                column: "CatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CatalogId",
                table: "Movies",
                column: "CatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CatalogId",
                table: "Comments",
                column: "CatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CatalogId",
                table: "Books",
                column: "CatalogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Catalog_CatalogId",
                table: "Books",
                column: "CatalogId",
                principalTable: "Catalog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Catalog_CatalogId",
                table: "Comments",
                column: "CatalogId",
                principalTable: "Catalog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MainCastMovies_Actors_ActorId",
                table: "MainCastMovies",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MainCastMovies_Movies_MovieId",
                table: "MainCastMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MainCastSeries_Actors_ActorId",
                table: "MainCastSeries",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MainCastSeries_Series_SerieId",
                table: "MainCastSeries",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Catalog_CatalogId",
                table: "Movies",
                column: "CatalogId",
                principalTable: "Catalog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Catalog_CatalogId",
                table: "Series",
                column: "CatalogId",
                principalTable: "Catalog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
